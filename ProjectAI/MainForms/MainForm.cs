using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;


namespace ProjectAI.MainForms
{
    public partial class MainForm : Form
    {
        // private List<WorkSpaceButton> m_workSpaceButtons = new List<WorkSpaceButton>();
        private JsonDataManiger jsonDataManiger = JsonDataManiger.GetInstance(); // Json File 관리 Class

        public MainForm()
        {
            InitializeComponent();

            // Forms Calss formStyleManager Update Handler 등록
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            WorkSpaceEarlyDataSet();
            MainFormCallUISeting();
        }

        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            FormsManiger formsManiger = FormsManiger.GetInstance(); // Forms 관리 Class
            this.styleManagerMainForm.Style = styleManager.Style;
            this.styleManagerMainForm.Theme = styleManager.Theme;
            this.BackColor = formsManiger.GetThemeRGBClor(styleManager.Theme.ToString());
        }

        /// <summary>
        /// MainForm 시작전 WorkSpaceEarlyData 기본 파일, 폴더, 설정 변수 확인, 적용 생성 
        /// </summary>
        private void WorkSpaceEarlyDataSet()
        {
            #region 프로그램 WorkSpaceEarlyData 파일 읽고 값 가져오기
            JObject workSpacData;
            if (CustomIOMainger.DirChackExistsAndCreate(WorkSpaceEarlyData.m_workSpacDataPath)) // 프로그램 폴더 유무 확인 있으면 true, 없으면 폴더를 만들고 false 반환
            {
                if (jsonDataManiger.JsonChackFileAndCreate(WorkSpaceEarlyData.m_workSpacDataFilePath)) // 프로그램 실행 옵션 설정 Json 파일 유무 확인 있으면 true, 없으면 폴더를 만들고 false 반환
                {
                    // Json 파일이 있으면 데이터 읽어오기
                    workSpacData = jsonDataManiger.GetJsonObject(WorkSpaceEarlyData.m_workSpacDataFilePath, WorkSpaceEarlyDataSetIntegrityCheck); // programOptions Json 파일 읽고 무결성 검사
                    jsonDataManiger.PushJsonObject(WorkSpaceEarlyData.m_workSpacDataFilePath, workSpacData); // Json 파일 저장 
                }
                else
                {
                    // Json 파일이 없는 경우
                    workSpacData = MainForm.WorkSpaceEarlyDataDefaltSetting();
                    jsonDataManiger.PushJsonObject(WorkSpaceEarlyData.m_workSpacDataFilePath, workSpacData); // Json 파일 저장 
                }
            }
            else
            {
                // Work Spaces 폴더가 없는 경우
                workSpacData = MainForm.WorkSpaceEarlyDataDefaltSetting();
                jsonDataManiger.PushJsonObject(WorkSpaceEarlyData.m_workSpacDataFilePath, workSpacData); // Json 파일 저장 
            }

            // 값 반영
            WorkSpaceEarlyData.workSpaceEarlyDataJobject = workSpacData; // Jobject 반영
            #endregion
        }

        /// <summary>
        /// UI 초기 셋팅
        /// </summary>
        private void MainFormCallUISeting()
        {
            this.panelMWorkSpase.Visible = true; // WorkSpase 판넬 보이기

            this.panelTrainOptions.Visible = false; // TrainO ptions 폼 안보이기
            this.tableLayoutDataReview.Visible = false; // Data Review 폼 안보이기

            this.panelMWorkSpase.Size = new System.Drawing.Size(400, 100); // WorkSpase 판넬 사이즈 조정

            this.panelTrainOptions.Size = new System.Drawing.Size(500, 100); // panel Train Options 판넬 사이즈 조정

            this.panelstatus.Visible = false; // 상태 표시 panelstatus 숨기기 
            foreach (string workSpaceName in WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceNameList"])
            {
                CreateWorkSpaceButton(workSpaceName,
                    WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceName"][workSpaceName]["string_m_workSpaceSize"].ToString(),
                    WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceName"][workSpaceName]["string_m_workSpaceVersion"].ToString(),
                    Convert.ToInt32(WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceName"][workSpaceName]["int_m_workSpacIndex"])
                    );
            }
        }

        /// <summary>
        /// WorkSpaceEarlyDataDefaltSetting -JObject 다시 만들고 기본값으로 설정 
        /// </summary>
        public static JObject WorkSpaceEarlyDataDefaltSetting()
        {
            JObject programStartPathOptions = WorkSpaceEarlyDataProgramStartPathOptionsDefaltSetting(); // ProgramStartPathOptions - JObject 다시 만들고 기본값으로 설정
            JObject workSpaceNameList = WorkSpaceEarlyDataWorkSpaceNameListDefaltSetting(); // ProgramStartPathOptions - JObject 다시 만들고 기본값으로 설정

            JObject workSpaceEarlyData = new JObject(); // 최종 출력 programOptions 아래 옵션들 programOptions에 병합
            workSpaceEarlyData.Merge(programStartPathOptions);
            workSpaceEarlyData.Merge(workSpaceNameList);

            // 다른 orkSpaceEarlyData 이(가) 추가되면 아래로 추가 

            //Console.WriteLine(programOptions.ToString());
            return workSpaceEarlyData;
        }

        /// <summary>
        /// WorkSpaceEarlyDataDefaltSetting - programStartPathOptions -JObject 다시 만들고 기본값으로 설정 
        /// </summary>
        public static JObject WorkSpaceEarlyDataProgramStartPathOptionsDefaltSetting()
        {
            object programStartPathOptions = new
            {
                string_m_workSpacDataPath = WorkSpaceEarlyData.m_workSpacDataPath,
                string_m_workSpacDataFilePath = WorkSpaceEarlyData.m_workSpacDataFilePath
            };

            JObject programStartPathOptionsJson = JObject.FromObject(programStartPathOptions);
            JObject workSpaceEarlyData = new JObject
            {
                    { "programStartPathOptions", programStartPathOptionsJson }
            };
            return workSpaceEarlyData;
        }

        /// <summary>
        /// WorkSpaceEarlyDataDefaltSetting - workSpaceNameList -JObject 다시 만들고 기본값으로 설정 
        /// </summary>
        public static JObject WorkSpaceEarlyDataWorkSpaceNameListDefaltSetting()
        {
            JObject workSpaceNameList = new JObject
            {
                    { "workSpaceNameList", JArray.FromObject(new string[] { }) }
            };
            JObject workSpaceName = new JObject();
            for (int i = 0; i < workSpaceNameList["workSpaceNameList"].Count(); i++)
            {
                string iworkSpeaceName = workSpaceNameList["workSpaceNameList"][i].ToString();
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(Path.Combine(WorkSpaceEarlyData.m_workSpacDataPath, iworkSpeaceName));
                long fileSize = 0;
                try
                {
                    fileSize = fileInfo.Length;
                }
                catch
                {
                    fileSize = 0;
                }

                object workSpaceNameOptions = new
                {
                    string_m_workSpacePath = System.IO.Path.Combine(WorkSpaceEarlyData.m_workSpacDataPath, iworkSpeaceName),
                    string_m_workSpaceSize = (CustomIOMainger.FormatBytes(fileSize)),
                    string_m_workSpaceVersion = "1",
                    string_m_workSpaceIndex = i.ToString()
                };

                JObject workSpaceNameOptionsJson = JObject.FromObject(workSpaceNameOptions);
                workSpaceName.Add(iworkSpeaceName, workSpaceNameOptionsJson);
            }
            workSpaceNameList.Add("workSpaceName", workSpaceName);

            return workSpaceNameList;
        }

        /// <summary>
        /// WorkSpaceEarlyData Json 파일 데이터 무결성 검사
        /// </summary>
        /// <param name="jsonData"> 검사할 programEntryPoint 파일 JObject</param>
        public static JObject WorkSpaceEarlyDataSetIntegrityCheck(JObject workSpaceEarlyDataSetJObject)
        {
           
            if (workSpaceEarlyDataSetJObject != null) // workSpaceEarlyDataSetJObject 에서 GetJsonObject을 타고 넘어온 workSpaceEarlyDataSetJObject 객체가 데이터 읽기에 실패 하였는지 확인
            {
                #region programStartPathOptions 관리
                if (workSpaceEarlyDataSetJObject["programStartPathOptions"] != null) // programStartPathOptions 객체 확인
                {
                    // 사용하지 않기 때문에 아직까지는 처리 하지 않음.
                }
                else
                {
                    // 사용하지 않기 테스트 용으로 구현만
                    workSpaceEarlyDataSetJObject.Merge(MainForm.WorkSpaceEarlyDataProgramStartPathOptionsDefaltSetting());
                }
                #endregion

                #region workSpaceNameList 관리
                // workSpaceNameList 객체 확인
                if (workSpaceEarlyDataSetJObject["workSpaceNameList"] != null)
                {
                    // workSpaceName 객체 확인
                    if (workSpaceEarlyDataSetJObject["workSpaceName"] != null) 
                    {
                        #region workSpaceName 관리
                        JObject workSpaceName = (JObject)workSpaceEarlyDataSetJObject["workSpaceName"]; //  programEntryPointOptions 객체 있음을 확인 

                        for (int i = 0; i < workSpaceEarlyDataSetJObject["workSpaceNameList"].Count(); i++)
                        {
                            string iworkSpeaceName = workSpaceEarlyDataSetJObject["workSpaceNameList"][i].ToString();

                            // workSpaceName의 workSpaceName Options 가 있는지 확인
                            if (workSpaceEarlyDataSetJObject["workSpaceName"][iworkSpeaceName] != null) 
                            {
                                JObject workSpaceNameOptions = (JObject)workSpaceEarlyDataSetJObject["workSpaceName"][iworkSpeaceName]; //  programEntryPointOptions 객체 있음을 확인 
                                

                                if (workSpaceNameOptions["string_m_workSpacePath"] == null)
                                    workSpaceNameOptions.Add(new JProperty("string_m_programSpace", Path.Combine(WorkSpaceEarlyData.m_workSpacDataPath, iworkSpeaceName)));
                                if (workSpaceName[iworkSpeaceName]["string_m_workSpaceSize"] == null)
                                    workSpaceNameOptions.Add(new JProperty("string_m_workSpaceSize", CustomIOMainger.FormatBytes(CustomIOMainger.DirSize(Path.Combine(WorkSpaceEarlyData.m_workSpacDataPath, iworkSpeaceName)))));
                                if (workSpaceName[iworkSpeaceName]["string_m_workSpaceVersion"] == null)
                                    workSpaceNameOptions.Add(new JProperty("string_m_workSpaceVersion", "1"));
                                if (workSpaceName[iworkSpeaceName]["int_m_workSpacIndex"] == null)
                                    workSpaceNameOptions.Add(new JProperty("int_m_workSpacIndex", i));
                                else //Name List와 같아야됨
                                    workSpaceName[iworkSpeaceName]["int_m_workSpacIndex"] = i;

                                workSpaceNameOptions["string_m_workSpaceSize"] = CustomIOMainger.FormatBytes(CustomIOMainger.DirSize(Path.Combine(WorkSpaceEarlyData.m_workSpacDataPath, iworkSpeaceName)));

                            }
                            // workSpaceName의 workSpaceName Options 이 없음을 확인
                            else
                            {
                                // workSpaceName의 workSpaceName Options 내용 체우기
                                System.IO.FileInfo fileInfo = new System.IO.FileInfo(Path.Combine(WorkSpaceEarlyData.m_workSpacDataPath, iworkSpeaceName));
                                long fileSize = 0;
                                try{ fileSize = fileInfo.Length;}
                                catch{ fileSize = 0;}

                                object workSpaceNameOptions = new
                                {
                                    string_m_workSpacePath = System.IO.Path.Combine(WorkSpaceEarlyData.m_workSpacDataPath, iworkSpeaceName),
                                    string_m_workSpaceSize = (CustomIOMainger.FormatBytes(fileSize)),
                                    string_m_workSpaceVersion = "1",
                                    int_m_workSpacIndex = i
                                };

                                JObject workSpaceNameOptionsJson = JObject.FromObject(workSpaceNameOptions);
                                workSpaceNameOptionsJson = new JObject
                                {
                                    { iworkSpeaceName ,workSpaceNameOptionsJson }
                                };
                                JObject workSpaceEarlyDataSetWorkSpaceName = (JObject)workSpaceEarlyDataSetJObject["workSpaceName"];
                                workSpaceEarlyDataSetWorkSpaceName.Merge(workSpaceNameOptionsJson); // 합병
                            }
                        }
                        #endregion
                    }
                    // workSpaceName 이 없으면 
                    else
                    {
                        JObject workSpaceName = new JObject();
                        for (int i = 0; i < workSpaceEarlyDataSetJObject["workSpaceNameList"].Count(); i++)
                        {
                            string iworkSpeaceName = workSpaceEarlyDataSetJObject["workSpaceNameList"][i].ToString();
                            System.IO.FileInfo fileInfo = new System.IO.FileInfo(Path.Combine(WorkSpaceEarlyData.m_workSpacDataPath, iworkSpeaceName));
                            long fileSize = 0;
                            try
                            {
                                 fileSize = fileInfo.Length;
                            }
                            catch
                            {
                                fileSize = 0;
                            }

                            object workSpaceNameOptions = new
                            {
                                string_m_workSpacePath = System.IO.Path.Combine(WorkSpaceEarlyData.m_workSpacDataPath, iworkSpeaceName),
                                string_m_workSpaceSize = (CustomIOMainger.FormatBytes(fileSize)),
                                string_m_workSpaceVersion = "1",
                                int_m_workSpacIndex = i
                            };

                            JObject workSpaceNameOptionsJson = JObject.FromObject(workSpaceNameOptions);
                            workSpaceName.Add(iworkSpeaceName, workSpaceNameOptionsJson);
                        }
                        workSpaceEarlyDataSetJObject.Add("workSpaceName", workSpaceName);
                    }
                }
                // workSpaceNameList 가 없으면 
                else 
                {
                    workSpaceEarlyDataSetJObject.Merge(MainForm.WorkSpaceEarlyDataWorkSpaceNameListDefaltSetting());
                }
                #endregion
            }
            else
            {
                MainForm.WorkSpaceEarlyDataProgramStartPathOptionsDefaltSetting();
            }
            Console.WriteLine(workSpaceEarlyDataSetJObject.ToString());
            return workSpaceEarlyDataSetJObject;
        }

        /// <summary>
        /// MainForm 종료 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            //Hiding the window, because closing it makes the window unaccessible.
            this.Hide();
            this.Parent = null;
            e.Cancel = true; //hides the form, cancels closing event
        }

        /// <summary>
        /// WorkSpace 열기 버튼 클릭시 동작 Button Event 형식 = Start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkSpaceLoadButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int workSpaceIndex = button.TabIndex;
            string activeWorkSpaceName = WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceNameList"][workSpaceIndex].ToString();

            //Console.WriteLine(workSpaceIndex);
            //Console.WriteLine(activeWorkSpaceName);

            foreach (string activeProjectName in WorkSpaceData.m_projectMaingersDictionary.Keys)
            {
                if (activeProjectName == activeWorkSpaceName)
                {
                    MetroMessageBox.Show(this, "열려 있는 프로젝트", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    WorkSpaceData.m_activeProjectMainger = WorkSpaceData.m_projectMaingersDictionary[activeProjectName]; // 활성화된 프로젝트 적용
                    FormsManiger.m_mainFormsUIResetHandler(); // 이전 UI 초기화
                    WorkSpaceData.m_activeProjectMainger.ProjectIdleUISet(); // 초기 UI 적용
                    panelMWorkSpase.Visible = false;
                    // #3 프로젝트가 열리고 데이터를 읽어왔으면 해야되는 일 
                    // 1. 이미지 리스트 UI 에 뿌려주기
                    // 2. 프로젝트 선택할수 있는 UI 만들기
                    // 3. 프로젝트가 선택됬으면 말맞은 UI 뿌려주기
                    return;
                }
            }

            ProjectMainger projectMainger = new ProjectMainger(activeWorkSpaceName);
            WorkSpaceData.m_projectMaingersDictionary.Add(activeWorkSpaceName, projectMainger); // 활성화된 Project 추가
            WorkSpaceEarlyData.m_workSpaceButtons[workSpaceIndex].WorkSpaceStatus = Color.Lime; // 활성화된 버튼 상태 색색상 적용

            WorkSpaceData.m_activeProjectMainger = WorkSpaceData.m_projectMaingersDictionary[activeWorkSpaceName]; // 활성화된 프로젝트 적용
            FormsManiger.m_mainFormsUIResetHandler?.Invoke();  // 이전 UI 초기화
            WorkSpaceData.m_activeProjectMainger.ProjectIdleUISet(); // 초기 UI 적용
            FormsManiger.m_mainFormsUIResetHandler += WorkSpaceData.m_activeProjectMainger.ProjectUIRemove; // UI 초기화 핸들러 등록
            panelMWorkSpase.Visible = false;

            //Console.WriteLine(WorkSpaceData.m_projectMaingersDictionary.Keys.ToString());
            //foreach (string i in WorkSpaceData.m_projectMaingersDictionary.Keys)
            //{
            //    Console.WriteLine(i);
            //}
        }

        private void BtnMTrainOptionsOpenClick(object sender, EventArgs e)
        {
            panelTrainOptions.Visible = panelTrainOptions.Visible == true ? false : true;
        }

        private void BtnMDataReviewOpenClick(object sender, EventArgs e)
        {
            tableLayoutDataReview.Visible = tableLayoutDataReview.Visible == true ? false : true;
        }

        private void BtnMWorkSpaseOpenClick(object sender, EventArgs e)
        {
            panelMWorkSpase.Visible = true;
        }

        private void BtnMWorkSpaseCloseClick(object sender, EventArgs e)
        {
            panelMWorkSpase.Visible = false;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
        }
        
        private void TsmProjectWorkSpaceNewProjectClick(object sender, EventArgs e)
        {
            this.WorkSpaceCreatSequence();
        }

        private void TsmProjectWorkSpaceTestButtonClick(object sender, EventArgs e)
        {
            panelstatus.Visible = panelstatus.Visible == true ? false : true;
            Console.WriteLine();
        }

        private void toolStripMenuItem1Click(object sender, EventArgs e)
        {

        }

        private void TsmProjectWorSpaceDeleteProjectClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Programs 종료 시퀀스
        /// </summary>
        /// <param name="
        /// sender"></param>
        /// <param name="e"></param>
        private void TsmProjectWorSpaceProgramExitClick(object sender, EventArgs e)
        {
            this.ProgramEndSequence();
        }

        /// <summary>
        /// WorkSpace 생성 버튼 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMnewWorkSpaceClick(object senders, EventArgs e)
        {
            this.WorkSpaceCreatSequence();
        }

        /// <summary>
        /// NEW WorkSpace 생성 시춴스
        /// </summary>
        private void WorkSpaceCreatSequence()
        {
            MakeWorkSpaceForm makeWorkSpaceForm = new MakeWorkSpaceForm(); // WorkSpace Button Form 가져오기
            DialogResult dialogResult = makeWorkSpaceForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string CreatWorkSpaceName = makeWorkSpaceForm.GetWorkSpaceName(); // 검증 완료됨 WorkSpace 이름 가져오기
                CreateWorkSpaceButton(CreatWorkSpaceName); // WorkSpaceButton 생성
            }
            // #2
            // 생성된 WorkSpace가 기존에 데이터가 존제한다면 
        }

        /// <summary>
        /// WorkSpaceButton 코어 함수(생성 셋팅) - 이 함수를에 접근하여 사용하지말고 CreateWorkSpaceButton 함수를 호출하여 사용
        /// </summary>
        /// <param name="workSpaceName"> WorkSpace 이름</param>
        /// <param name="workSpaceSize"> WorkSpace Size</param>
        /// <param name="workSpaceVersion"> WorkSpace Vertion</param>
        /// <param name="workSpaceIndex"> WorkSpace Index</param>
        private void CreateWorkSpaceButtonCore(string workSpaceName, string workSpaceSize, string workSpaceVersion, int workSpaceIndex)
        {
            MainForms.WorkSpaceButton newWorkSpaceButton = new MainForms.WorkSpaceButton();
            this.panelWorkSpaseButton.Controls.Add(newWorkSpaceButton);
            this.styleExtenderMainForm.SetApplyMetroTheme(newWorkSpaceButton, true);
            newWorkSpaceButton.BackColor = System.Drawing.Color.Transparent;
            newWorkSpaceButton.Dock = System.Windows.Forms.DockStyle.Top;
            newWorkSpaceButton.Location = new System.Drawing.Point(2, 2);
            newWorkSpaceButton.Margin = new System.Windows.Forms.Padding(0);
            //newWorkSpaceButton.Name = "workSpaceButton1";
            newWorkSpaceButton.Padding = new System.Windows.Forms.Padding(5);
            newWorkSpaceButton.WorkSpaceStatus = System.Drawing.Color.Gray;

            newWorkSpaceButton.Size = new System.Drawing.Size(400, 35);
            newWorkSpaceButton.TabIndex = workSpaceIndex;
            newWorkSpaceButton.WorkSpaceName = workSpaceName;
            newWorkSpaceButton.WorkSpaceSize = workSpaceSize;
            newWorkSpaceButton.WorkSpaceVersion = workSpaceVersion;
            newWorkSpaceButton.WorkSpaceButtonIndex = workSpaceIndex;

            WorkSpaceEarlyData.m_workSpaceButtons.Add(newWorkSpaceButton);
            newWorkSpaceButton.BtnWorkSpaceOpenClickEvnetHandler += new System.EventHandler(this.WorkSpaceLoadButtonClick);
            //Console.WriteLine(workSpaceIndex);
        }
        /// <summary>
        /// WorkSpaceButton 만들기 - 데이터 읽어와서 사용
        /// </summary>
        /// <param name="workSpaceName"> WorkSpace 이름</param>
        /// <param name="workSpaceSize"> WorkSpace Size</param>
        /// <param name="workSpaceVersion"> WorkSpace Vertion</param>
        /// <param name="workSpaceIndex"> WorkSpace Index</param>
        private void CreateWorkSpaceButton(string workSpaceName, string workSpaceSize, string workSpaceVersion, int workSpaceIndex)
        {
            CreateWorkSpaceButtonCore(workSpaceName, workSpaceSize, workSpaceVersion, workSpaceIndex);
        }
        /// <summary>
        /// WorkSpaceButton 만들기 - 처음 만드는 경우, 
        /// </summary>
        /// <param name="workSpaceName"></param>
        private void CreateWorkSpaceButton(string workSpaceName)
        {
            JArray workSpaceNameListJArray = (JArray)WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceNameList"];
            int workSpaceIndex = workSpaceNameListJArray.Count(); // workSpaceIndex 초기화
            string workSpaceVersion = "1"; // 버전 초기화

            // 파일 사이즈 가져오기
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(Path.Combine(WorkSpaceEarlyData.m_workSpacDataPath, workSpaceName));
            long workSpaceSize = 0;
            try
            {
                workSpaceSize = fileInfo.Length;
            }
            catch
            {
                workSpaceSize = 0;
            }

            // WorkSpaceButton 생성
            CreateWorkSpaceButtonCore(workSpaceName, CustomIOMainger.FormatBytes(workSpaceSize), workSpaceVersion, workSpaceIndex);
            workSpaceNameListJArray.Add(workSpaceName); // 추가된 workSpaceName workSpaceNameListJobject에 추가 
            WorkSpaceEarlyDataSetIntegrityCheck(WorkSpaceEarlyData.workSpaceEarlyDataJobject); // 무결성 검사 이용하여 생성된 workSpaceEarlyData 초기 대이터 생성.
            jsonDataManiger.PushJsonObject(WorkSpaceEarlyData.m_workSpacDataFilePath, WorkSpaceEarlyData.workSpaceEarlyDataJobject); // Json 파일 저장 
        }

        /// <summary>
        /// Programs 종료 시퀀스
        /// </summary>
        private void ProgramEndSequence()
        {
            try
            {
                Application.ExitThread();
            }
            catch { }

            if (Application.MessageLoop == true)
            {
                Application.Exit();
            }
            else
            {
                Environment.Exit(1);
            }
            this.Close();
        }

        private void BtnMimagePageNextClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                lblImageListpage.Text = WorkSpaceData.m_activeProjectMainger.ImageListPageNext().ToString();
        }

        private void BtnMimagePageReverseClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                lblImageListpage.Text = WorkSpaceData.m_activeProjectMainger.ImageListPageReverse().ToString();
        }

        private void ClassToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                    WorkSpaceData.m_activeProjectMainger.classEdit.ShowDialog(); // Class Edit 실행 
        }

        private void TrainToolStripMenuItemClick(object sender, EventArgs e)
        {
            
        }

        private void GridImageListSelectionChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = null;

            // dgvData_Model에서 모델 이름 불러오기
            try
            {
                DataGridViewRow row = gridImageList.SelectedRows[0]; //선택된 Row 값 가져옴.
                string data = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[0]) = name

                if (data != null)
                    pictureBox1.Image = Image.FromFile(Path.Combine(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectImage, data));
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageFilesAddToolStripMenuItem1Click(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                WorkSpaceData.m_activeProjectMainger.ImageAdding();
        }
    }
}


            