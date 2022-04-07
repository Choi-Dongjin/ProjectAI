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
        /// <summary>
        /// 싱글톤 패턴 구현
        /// </summary>
        private static MainForm mainForm;

        /// <summary>
        /// 싱글톤 패턴 Class 호출에 사용
        /// </summary>
        /// <returns></returns>
        public static MainForm GetInstance()
        {
            if (MainForm.mainForm == null)
            {
                MainForm.mainForm = new MainForm();
            }
            return MainForm.mainForm;
        }

        // private List<WorkSpaceButton> m_workSpaceButtons = new List<WorkSpaceButton>();
        /// <summary>
        /// Json File 관리 Class
        /// </summary>
        private JsonDataManiger jsonDataManiger = JsonDataManiger.GetInstance(); // Json File 관리 Class
        /// <summary>
        /// Forms 관리 Class
        /// </summary>
        private FormsManiger formsManiger = FormsManiger.GetInstance(); // Forms 관리 Class
        /// <summary>
        /// CustomIOManigerFoem 관리 Class
        /// </summary>
        private ProjectManiger.CustomIOManigerFoem CustomIOManigerFoem = ProjectManiger.CustomIOManigerFoem.GetInstance();
        /// <summary>
        /// TrainForm 호출
        /// </summary>
        private ProjectAI.TrainForms.TrainForm TrainForm;


        /// <summary>
        /// Label TextBox 안전 접근 
        /// </summary>
        /// <param name="textBox"> </param>
        /// <param name="text"></param>
        private delegate void SafeCallLabelText(System.Object textBoxObject, string text);
        /// <summary>
        /// Label TextBox 안전 접근 쓰기 함수
        /// </summary>
        /// <param name="labelObject"> TextBox Object </param>
        /// <param name="text"> 출력할 텍스트 </param>
        public void SafeWriteLabelText(Object labelObject, string text)
        {
            if (labelObject.GetType() == typeof(MetroFramework.Controls.MetroLabel))
            {
                MetroFramework.Controls.MetroLabel label = (MetroFramework.Controls.MetroLabel)labelObject;
                if (label.InvokeRequired)
                {
                    var d = new SafeCallLabelText(SafeWriteLabelText);
                    Invoke(d, new object[] { label, text });
                }
                else
                {
                    label.Text = text;
                }
            }
            else if (labelObject.GetType() == typeof(System.Windows.Forms.Label))
            {
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)labelObject;
                if (label.InvokeRequired)
                {
                    var d = new SafeCallLabelText(SafeWriteLabelText);
                    Invoke(d, new object[] { label, text });
                }
                else
                {
                    label.Text = text;
                }
            }
        }

        /// <summary>
        /// ProgressBar 안전 접근 
        /// </summary>
        /// <param name="progressBarObject"> ProgressBar Object </param>
        /// <param name="maximum"> 최대값 </param>
        /// <param name="value"> 현재값 </param>
        private delegate void SafeCallProgressBar(System.Object progressBarObject, int maximum, int value);
        /// <summary>
        /// ProgressBar 안전 접근 함수
        /// </summary>
        /// <param name="progressBarObject"> ProgressBar Object </param>
        /// <param name="maximum"> 최대값 </param>
        /// <param name="value"> 현재값 </param>
        public void SafeWriteProgressBar(Object progressBarObject, int maximum, int value)
        {
            if (progressBarObject.GetType() == typeof(MetroFramework.Controls.MetroProgressBar))
            {
                MetroFramework.Controls.MetroProgressBar progressBar = (MetroFramework.Controls.MetroProgressBar)progressBarObject;
                if (progressBar.InvokeRequired)
                {
                    var d = new SafeCallProgressBar(SafeWriteProgressBar);
                    Invoke(d, new object[] { progressBar, maximum, value });
                }
                else
                {
                    progressBar.Maximum = maximum;
                    progressBar.Value = value;
                }
            }
            else if (progressBarObject.GetType() == typeof(System.Windows.Forms.ProgressBar))
            {
                System.Windows.Forms.ProgressBar progressBar = (System.Windows.Forms.ProgressBar)progressBarObject;
                if (progressBar.InvokeRequired)
                {
                    var d = new SafeCallProgressBar(SafeWriteProgressBar);
                    Invoke(d, new object[] { progressBar, maximum, value });
                }
                else
                {
                    progressBar.Maximum = maximum;
                    progressBar.Value = value;
                }
            }
        }

        /// <summary>
        /// 안전 접근 Panel Visible 상태 확인용 
        /// </summary>
        /// <param name="panelObject"> 확인할 Panel </param>
        /// <returns></returns>
        private delegate bool SafeCallPanelVisibleStatus(Object panelObject);
        /// <summary>
        /// 안전 접근 Panel Visible 값 변경용
        /// </summary>
        /// <param name="panelObject"> 확인할 Panel </param>
        /// <param name="visible"> 적용할 값 </param>
        private delegate void SafeCallPanelVisible(Object panelObject, bool visible);

        /// <summary>
        /// Panel Visible 상태 확인 안전 접근 함수
        /// </summary>
        /// <param name="panelObject"></param>
        public bool SafeVisiblePanel(Object panelObject)
        {
            if (panelObject.GetType() == typeof(System.Windows.Forms.Panel))
            {
                System.Windows.Forms.Panel panel = (System.Windows.Forms.Panel)panelObject;
                if (panel.InvokeRequired)
                {
                    var d = new SafeCallPanelVisibleStatus(SafeVisiblePanel);
                    Invoke(d, new object[] { panel });
                }
                else
                {
                    return panel.Visible;
                }
            }
            else if (panelObject.GetType() == typeof(MetroFramework.Controls.MetroPanel))
            {
                MetroFramework.Controls.MetroPanel panel = (MetroFramework.Controls.MetroPanel)panelObject;
                if (panel.InvokeRequired)
                {
                    var d = new SafeCallPanelVisibleStatus(SafeVisiblePanel);
                    Invoke(d, new object[] { panel });
                }
                else
                {
                    return panel.Visible;
                }
            }
            return false;
        }
        int a = 1;
        /// <summary>
        /// Panel Visible 값 적용 안전 접근 함수
        /// </summary>
        /// <param name="panelObject"> 접근할 Panel </param>
        /// <param name="visible"> 적용할 값 </param>
        public void SafeVisiblePanel(Object panelObject, bool visible)
        {
            if (panelObject.GetType() == typeof(System.Windows.Forms.Panel))
            {
                System.Windows.Forms.Panel panel = (System.Windows.Forms.Panel)panelObject;
                if (panel.InvokeRequired)
                {
                    var d = new SafeCallPanelVisible(SafeVisiblePanel);
                    Invoke(d, new object[] { panel, visible });
                }
                else
                {
                    panel.Visible = visible;
                }
            }
            else if (panelObject.GetType() == typeof(MetroFramework.Controls.MetroPanel))
            {
                MetroFramework.Controls.MetroPanel panel = (MetroFramework.Controls.MetroPanel)panelObject;
                if (panel.InvokeRequired)
                {
                    var d = new SafeCallPanelVisible(SafeVisiblePanel);
                    Invoke(d, new object[] { panel, visible });
                }
                else
                {
                    panel.Visible = visible;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();

            // Forms Calss formStyleManager Update Handler 등록
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;

            btnMnewWorkSpace.FlatAppearance.BorderSize = 0;
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            WorkSpaceEarlyDataSet();
        }

        private void MainFormShown(object sender, EventArgs e)
        {
            MainFormCallUISeting();
            this.TrainForm = ProjectAI.TrainForms.TrainForm.GetInstance();
        }

        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            if (this.formsManiger.m_isDarkMode) // Light로 변경시 진입
            {
                // Metro Style, Theme 변경
                this.styleManagerMainForm.Style = styleManager.Style;
                this.styleManagerMainForm.Theme = styleManager.Theme;
                // 배경 색 변경, Forms에 Metro Forms 적용하지 않은 경우
                this.BackColor = this.formsManiger.GetThemeRGBClor(styleManager.Theme.ToString());
                // Image 색에 맞게 수정
                this.panelMWorkSpaceString1.BackgroundImage = global::ProjectAI.Properties.Resources.Workspace;
                this.panelMWorkSpaceString2.BackgroundImage = global::ProjectAI.Properties.Resources.Workspace;
                this.panelMTrainParameterString.BackgroundImage = global::ProjectAI.Properties.Resources.TrainParameter;
                this.panelMDataBaseInfoString.BackgroundImage = global::ProjectAI.Properties.Resources.DatabaseInfo;
                this.panelProjectInfo.BackgroundImage = global::ProjectAI.Properties.Resources.logoBX2DeepLearningStudio;
            }
            else // Dark로 변경시 진입
            {
                // Metro Style, Theme 변경
                this.styleManagerMainForm.Style = styleManager.Style;
                this.styleManagerMainForm.Theme = styleManager.Theme;
                // 배경 색 변경, Forms에 Metro Forms 적용하지 않은 경우
                this.BackColor = this.formsManiger.GetThemeRGBClor(styleManager.Theme.ToString());
                // Image 색에 맞게 수정
                this.panelMWorkSpaceString1.BackgroundImage = global::ProjectAI.Properties.Resources.WorkspaceW;
                this.panelMWorkSpaceString2.BackgroundImage = global::ProjectAI.Properties.Resources.WorkspaceW;
                this.panelMTrainParameterString.BackgroundImage = global::ProjectAI.Properties.Resources.TrainParameterW;
                this.panelMDataBaseInfoString.BackgroundImage = global::ProjectAI.Properties.Resources.DatabaseInfoW;
                this.panelProjectInfo.BackgroundImage = global::ProjectAI.Properties.Resources.logoBX2DeepLearningStudioW;
            }
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

            this.tableLayoutDataReview.Size = new System.Drawing.Size(300, 100); // panel Data Review 판넬 사이즈 조정

            this.panelstatus.Visible = false; // 상태 표시 panelstatus 숨기기 
            foreach (string workSpaceName in WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceNameList"]) // 버튼 생성
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
            if (WorkSpaceData.m_activeProjectMainger != null)
            {
                WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName = null;
            }

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

            ProjectContral projectMainger = new ProjectContral(activeWorkSpaceName);
            WorkSpaceData.m_projectMaingersDictionary.Add(activeWorkSpaceName, projectMainger); // 활성화된 워크스페이스 추가
            WorkSpaceEarlyData.m_workSpaceButtons[activeWorkSpaceName].WorkSpaceStatus = Color.Lime; // 활성화된 버튼 상태 색색상 적용

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
            if (panelTrainOptions.Visible)
                btnMTrainOptionsOpen.BackgroundImage = global::ProjectAI.Properties.Resources.arrowLeft2;
            else
                btnMTrainOptionsOpen.BackgroundImage = global::ProjectAI.Properties.Resources.arrowRight2;
            
        }

        private void BtnMDataReviewOpenClick(object sender, EventArgs e)
        {
            tableLayoutDataReview.Visible = tableLayoutDataReview.Visible == true ? false : true;
            if (tableLayoutDataReview.Visible)
                btnMDataReviewOpen.BackgroundImage = global::ProjectAI.Properties.Resources.arrowRight2;
            else
                btnMDataReviewOpen.BackgroundImage = global::ProjectAI.Properties.Resources.arrowLeft2;
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
            //panelstatus.Visible = panelstatus.Visible == true ? false : true;
            //Console.WriteLine();
            //splitContainer1.Panel2Collapsed = splitContainer1.Panel2Collapsed ? false : true;
            //Console.WriteLine($"splitContainer1.Panel2Collapsed: {splitContainer1.Panel2Collapsed}");
            //pictureBox2.Visible = splitContainer1.Panel2Collapsed ? false : true;
            //Console.WriteLine($"pictureBox2.Visible: {pictureBox2.Visible}");
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    JObject jObject = new JObject();
                    WorkSpaceData.m_activeProjectMainger.GetTrainDataClassification(jObject); 
                }
            //this.TrainForm.Show();
        }

        private void toolStripMenuItem1Click(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    JObject jObject = new JObject();
                    WorkSpaceData.m_activeProjectMainger.m_classificationTrainOptionDictionary[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName].GetTrainOptions(jObject);
                    jsonDataManiger.PushJsonObject(@"C:\Users\USER\AppData\Roaming\SynapseNet\SynapseNet 0.1\workspaces\Test.Json", jObject);
                }
        }

        private void TsmProjectAllWorkSpaceSaveClick(object sender, EventArgs e)
        {
            foreach (string workSpaceName in WorkSpaceData.m_projectMaingersDictionary.Keys)
            {
                if (WorkSpaceData.m_projectMaingersDictionary[workSpaceName].saveWorkSpace)
                {
                    jsonDataManiger.PushJsonObject(WorkSpaceData.m_projectMaingersDictionary[workSpaceName].m_pathActiveProjectInfo, WorkSpaceData.m_projectMaingersDictionary[workSpaceName].m_activeProjectInfoJObject);
                    jsonDataManiger.PushJsonObject(WorkSpaceData.m_projectMaingersDictionary[workSpaceName].m_pathActiveProjectDataImageList, WorkSpaceData.m_projectMaingersDictionary[workSpaceName].m_activeProjectImageListJObject);
                    jsonDataManiger.PushJsonObject(WorkSpaceData.m_projectMaingersDictionary[workSpaceName].m_pathActiveProjectDataImageListData, WorkSpaceData.m_projectMaingersDictionary[workSpaceName].m_activeProjectDataImageListDataJObject);
                    jsonDataManiger.PushJsonObject(WorkSpaceData.m_projectMaingersDictionary[workSpaceName].m_pathActiveProjectCalssInfo, WorkSpaceData.m_projectMaingersDictionary[workSpaceName].m_activeProjectCalssInfoJObject);
                    jsonDataManiger.PushJsonObject(WorkSpaceData.m_projectMaingersDictionary[workSpaceName].m_pathActiveProjectModelInfo, WorkSpaceData.m_projectMaingersDictionary[workSpaceName].m_activeProjectModelInfoJObject);

                    WorkSpaceData.m_projectMaingersDictionary[workSpaceName].saveWorkSpace = false;
                }
            }
            WorkSpaceData.m_workSpaceSave = false;
            this.tsmProjectWorkSpaceSave.Enabled = false;
            this.tsmProjectAllWorkSpaceSave.Enabled = false;
        }

        private void TsmProjectWorSpaceSaveProjectClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
            {
                jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectInfo, WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject);
                jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectDataImageList, WorkSpaceData.m_activeProjectMainger.m_activeProjectImageListJObject);
                jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectDataImageListData, WorkSpaceData.m_activeProjectMainger.m_activeProjectDataImageListDataJObject);
                jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectCalssInfo, WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject);
                jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectModelInfo, WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject);

                WorkSpaceData.m_activeProjectMainger.saveWorkSpace = false;
                this.tsmProjectWorkSpaceSave.Enabled = false;
            }
        }

        private void TsmDeleteWorkSpaceClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (MetroMessageBox.Show(this, $"Are you really Deleting the workspace?\nDelete WorkSpace Name: \"{WorkSpaceData.m_activeProjectMainger.m_activeProjectName.ToString()}\"\nAll related data will be deleted.", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    this.DeletWorkSpace(WorkSpaceData.m_activeProjectMainger.m_activeProjectName.ToString());
        }

        private void TsmProjectDeleteClick(object sender, EventArgs e)
        {
            //if (WorkSpaceData.m_activeProjectMainger != null)
            //    if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                    //this.DeletWorkSpace(WorkSpaceData.m_activeProjectMainger.m_activeProjectName.ToString());
        }

        private void DeletWorkSpace(string deleteWorkSpaceName)
        {
            if (deleteWorkSpaceName == WorkSpaceData.m_activeProjectMainger.m_activeProjectName.ToString()) // 실행중인 Work Space 와 같은 Work Space 삭제하는지 확인
            {
                // 적용중인 워크 스페이스 UI, 값 초기화
                // WorkSpaceEarlyDataSet(); // 초기화
                FormsManiger.m_mainFormsUIResetHandler?.Invoke();  // 이전 UI 초기화 -> 초기화 안하면 종속성으로 인해서 오류 발생
            }
            // UI Set
            MainForms.WorkSpaceButton deleteWorkSpaceButton = WorkSpaceEarlyData.m_workSpaceButtons[deleteWorkSpaceName]; // 삭제할 WorkSpaceButton 가져오기
            this.panelWorkSpaseButton.Controls.Remove(deleteWorkSpaceButton); //panelWorkSpaseButton 판넬에서 해당 WorkSpaceButton 삭제

            // 등록된 WorkSpace 데이터 삭제
            WorkSpaceEarlyData.m_workSpaceButtons.Remove(deleteWorkSpaceName); // 해당 WorkSpaceButton 삭제
            deleteWorkSpaceButton.Dispose(); // deleteWorkSpaceButton 초기화
            ProjectContral deleteProjectContral = WorkSpaceData.m_projectMaingersDictionary[deleteWorkSpaceName];
            WorkSpaceData.m_activeProjectMainger = null; // 활성화된 Project 초기화 
            deleteProjectContral.Dispose(); // 변수 매모리에서 해제
            WorkSpaceData.m_projectMaingersDictionary.Remove(deleteWorkSpaceName); // 해당 WorkSpace projectMaingers 삭제

            // 파일 삭제 등록
            string deleteFolderPath = WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceName"][deleteWorkSpaceName]["string_m_workSpacePath"].ToString(); // 삭제할 폴더 Path 불러오기
            CustomIOManigerFoem.DeleteDictionary(deleteFolderPath); // 해당 폴더 삭제

            // WorkSpace JObject 데이터 수정
            int deleteWorkSpacIndex = Convert.ToInt32(WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceName"][deleteWorkSpaceName]["int_m_workSpacIndex"]); // 삭제 하는 데이터 int_m_workSpacIndex 가져오기
            JObject workSpaceNameJToken = (JObject)WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceName"];
            workSpaceNameJToken.Remove(deleteWorkSpaceName); // 해당 WorkSpace Data 삭제

            WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceNameList"][deleteWorkSpacIndex].Remove(); // workSpaceNameList 데이터 삭제

            foreach (string workSpaceName in WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceNameList"]) // Index 다시 맞추기
            {
                int workSpacIndex = Convert.ToInt32(WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceName"][workSpaceName]["int_m_workSpacIndex"]); // 비교하는 데이터 int_m_workSpacIndex

                if (workSpacIndex > deleteWorkSpacIndex) // 삭제된 데이터보다 Index 가 크면 하나씩 줄이기
                {
                    WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceName"][workSpaceName]["int_m_workSpacIndex"] = Convert.ToInt32(WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceName"][workSpaceName]["int_m_workSpacIndex"]) - 1;
                }
            }
            jsonDataManiger.PushJsonObject(WorkSpaceEarlyData.m_workSpacDataFilePath, WorkSpaceEarlyData.workSpaceEarlyDataJobject); // Json 파일 저장
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
            using (MakeWorkSpaceForm makeWorkSpaceForm = new MakeWorkSpaceForm()) // WorkSpace Button Form 가져오기
            {
                DialogResult dialogResult = makeWorkSpaceForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    string CreatWorkSpaceName = makeWorkSpaceForm.GetWorkSpaceName(); // 검증 완료됨 WorkSpace 이름 가져오기
                    CreateWorkSpaceButton(CreatWorkSpaceName); // WorkSpaceButton 생성
                }
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

            WorkSpaceEarlyData.m_workSpaceButtons.Add(workSpaceName, newWorkSpaceButton);
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

        private void BtnimagePageNextClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                lblImageListpage.Text = WorkSpaceData.m_activeProjectMainger.ImageListPageNext().ToString();
        }

        private void BtnimagePageReverseClick(object sender, EventArgs e)
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
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    #region 학습 Option Info 가져오기
                    JObject trainOptions = new JObject();
                    trainOptions = WorkSpaceData.m_activeProjectMainger.GetTrainInfo(trainOptions);
                    #endregion 

                    #region 학습 이미지 정보 가져오기
                    JObject trainImageData = new JObject();
                    trainImageData = WorkSpaceData.m_activeProjectMainger.GetTrainDataClassification(trainImageData);
                    #endregion

                    #region 학습 정보 넣어주기
                    this.TrainForm.ClassificationPushTrainData(
                        (JObject)trainOptions.DeepClone(),
                        (JObject)trainImageData.DeepClone(),
                        WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectTask,
                        "Train",
                        WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject["string_projectListInfo"][WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["string_selectProjectInputDataType"].ToString(),
                        WorkSpaceData.m_activeProjectMainger.m_activeProjectName,
                        WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName);
                    #endregion
                }
        }

        private void TrainToolStripMenuItem1Click(object sender, EventArgs e)
        {
            this.TrainForm.Show();
        }

        private void GridImageListSelectionChanged(object sender, EventArgs e)
        {
            if(this.pictureBox1.Image != null)
                this.pictureBox1.Image = null;
            try
            {
                DataGridViewRow row = gridImageList.SelectedRows[0]; //선택된 Row 값 가져옴.
                string data = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[0]) = name

                if (data != null)
                {
                    this.pictureBox1.Image = CustomIOMainger.LoadBitmap(Path.Combine(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectImage, data));
                }
            }
            catch
            {
                if (this.pictureBox1.Image != null)
                    this.pictureBox1.Image = null;
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

        private void ImageFolderAddToolStripMenuItem1Click(object sender, EventArgs e)
        {

        }

        private void ImageDeleteToolStripMenuItem1Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = null;
            this.pictureBox2.Image = null;

            if (WorkSpaceData.m_activeProjectMainger != null)
                WorkSpaceData.m_activeProjectMainger.ImageDel(this.gridImageList);
        }

        private void ImageLabelingToolStripMenuItem1Click(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    WorkSpaceData.m_activeProjectMainger.ImageLabeling(this.gridImageList);
                }
        }

        private void ImageSetTrainToolStripMenuItem1Click(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    WorkSpaceData.m_activeProjectMainger.ImageTrainSet(this.gridImageList);
                }
        }

        private void ImageSetTestToolStripMenuItem1Click(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    WorkSpaceData.m_activeProjectMainger.ImageTestSet(this.gridImageList);
                }
        }

        private void ImageLabelInfoResetToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    WorkSpaceData.m_activeProjectMainger.ImageLabelInfoReset(this.gridImageList);
                }
        }

        private void ImageSetInfoResetToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    WorkSpaceData.m_activeProjectMainger.ImageDataSetInfoReset(this.gridImageList);
                }
        }

        private void BtnMDeleteWorkSpaceClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if( MetroMessageBox.Show(this, $"Are you really Deleting the workspace?\nDelete WorkSpace Name: \"{WorkSpaceData.m_activeProjectMainger.m_activeProjectName.ToString()}\"\nAll related data will be deleted.", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    this.DeletWorkSpace(WorkSpaceData.m_activeProjectMainger.m_activeProjectName.ToString());
        }
    }
}


            