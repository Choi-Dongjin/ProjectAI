using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

using System.Management;

namespace ProjectAI
{
    public partial class StartForm : Form
    {
        /// <summary>
        /// 싱글톤 패턴 구현
        /// </summary>
        private static StartForm startForm;

        /// <summary>
        /// 싱글톤 패턴 Class 호출에 사용
        /// </summary>
        /// <returns></returns>
        public static StartForm GetInstance()
        {
            if (StartForm.startForm == null)
            {
                StartForm.startForm = new StartForm();
            }
            return StartForm.startForm;
        }

        /// <summary>
        /// StartFormOptions 호출
        /// </summary>
        private ProjectAI.StartForms.StartFormOptions StartFormOptions = ProjectAI.StartForms.StartFormOptions.GetInstance();

        private FormsManiger formsManiger = FormsManiger.GetInstance(); // Forms 관리 Class
        private JsonDataManiger jsonDataManiger = JsonDataManiger.GetInstance(); // Json File 관리 Class

        public StartForm()
        {
            InitializeComponent();

            //this.StyleManager = styleManagerStartForm; // Form StyleManager 설정 -> MetroForm으로 사용시 적용
            this.Icon = Properties.Resources.synapseimaging2; // 아이콘 설정

            //FormsManiger.StartForm = this; // formsManiger를 호출하면 startForm을 먼저 등록 해야함. 아니면 다른 처리가 필요. 안하면 // Handler 등록에 문제 발생

            // 각 Forms Calss formStyleManager Update Handler 등록
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            // StartForm, StartFormOptions 변경시를 관리 Update Handler 등록
            FormsManiger.m_startFormOptionsManagerHandler += this.IfStartOptionsChange;

            // 각 해당 Class 에서 관리 하도록 수정
            //formsManiger.FormStyleManagerHandlerEnrollment();
            //formsManiger.FormlanguageManagerHandlerEnrollment();
            //formsManiger.StartFormOptionsManagerHandlerEnrollment();

            StartProgramChackSetOptions(); // StartForm 시작전 프로그램 기본 파일, 폴더, 설정 변수 확인, 적용 생성
            StartFormStartComponentSeting(); // StartForm 시작전 Component에 기본 값 설정
        }

        private void StartFormLoad(object sender, EventArgs e)
        {
            formsManiger.m_StyleManager.Style = MetroColorStyle.Lime;
            formsManiger.m_StyleManager.Theme = MetroThemeStyle.Light;
            this.BackColor = formsManiger.GetThemeRGBClor("Light");

            FormsManiger.m_formStyleManagerHandler(formsManiger.m_StyleManager);
        }

        private void StartFormShown(object sender, EventArgs e)
        {
            HardwareInformation.GetHardwareInformation();
        }


        /// <summary>
        /// StartForm 시작전 프로그램 기본 파일, 폴더, 설정 변수 확인, 적용 생성
        /// </summary>
        private void StartProgramChackSetOptions()
        {
            #region WriteLine
            Console.WriteLine($"ProgramVariables.m_programVersion: {ProgramVariables.m_programVersion}");
            Console.WriteLine($"ProgramVariables.m_programSpacePath: {ProgramVariables.m_programSpacePath}");
            Console.WriteLine($"ProgramVariables.m_programOptionsSpace: {ProgramVariables.m_programOptionsSpacePath}");
            Console.WriteLine($"ProgramVariables.m_programlog: {ProgramVariables.m_programlogPath}");
            Console.WriteLine($"ProgramVariables.m_programgiulogPath: {ProgramVariables.m_programgiulogPath}");
            Console.WriteLine($"ProgramVariables.m_programWokrSpace: {ProgramVariables.m_programWokrSpacePath}");
            Console.WriteLine($"ProgramVariables.m_programWokrSpace_Defalt: {ProgramVariables.ProgramWokrSpacePathDefalt}");
            #endregion

            CustomIOMainger.DirChackExistsAndCreate(ProgramVariables.m_programSpacePath); // 프로그램 작업 폴더 유무 확인 있으면 true, 없으면 폴더를 만들고 false 반환
            CustomIOMainger.DirChackExistsAndCreate(ProgramVariables.m_programlogPath); // 프로그램 log 폴더 유무 확인 있으면 true, 없으면 폴더를 만들고 false 반환
            CustomIOMainger.DirChackExistsAndCreate(ProgramVariables.m_programgiulogPath); // 프로그램 guilog 폴더 유무 확인 있으면 true, 없으면 폴더를 만들고 false 반환

            #region 프로그램 Start Program Option 파일 읽고 값 가져오기
            if (CustomIOMainger.DirChackExistsAndCreate(ProgramVariables.m_programOptionsSpacePath)) // 프로그램 Option 폴더 유무 확인 있으면 true, 없으면 폴더를 만들고 false 반환
            {
                if (jsonDataManiger.JsonChackFileAndCreate(ProgramVariables.m_programOptionsFileJsonPath)) // 프로그램 실행 옵션 설정 Json 파일 유무 확인 있으면 true, 없으면 폴더를 만들고 false 반환
                {
                    // 파일이 있으면 데이터 읽어오기
                    JObject programOptions = jsonDataManiger.GetJsonObject(ProgramVariables.m_programOptionsFileJsonPath, ProgramOptionsDataIntegrityCheck); // programOptions Json 파일 읽고 무결성 검사

                    jsonDataManiger.PushJsonObject(ProgramVariables.m_programOptionsFileJsonPath, programOptions); // 설정된 파일 저장
                    var programStartPathOptionsJson = programOptions["programStartPathOptions"];
                    Console.WriteLine(programStartPathOptionsJson.ToString());

                    // 데이터 처리
                    ProgramVariables.m_programSpacePath = programStartPathOptionsJson["string_m_programSpace"].ToString(); // m_programSpacePath
                    ProgramVariables.m_programOptionsSpacePath = programStartPathOptionsJson["string_m_programOptionsSpace"].ToString(); // m_programOptionsSpace
                    ProgramVariables.m_programOptionsFileJsonPath = programStartPathOptionsJson["string_m_programOptionsFileJsonPath"].ToString(); // m_programOptionsSpace
                    ProgramVariables.m_programlogPath = programStartPathOptionsJson["string_m_programlog"].ToString(); // m_programlog
                    ProgramVariables.m_programgiulogPath = programStartPathOptionsJson["string_m_programgiulog"].ToString(); // m_programgiulogPath
                    ProgramVariables.m_programWokrSpacePath = programStartPathOptionsJson["string_m_programWokrSpace"].ToString(); // m_programWokrSpace_Defalt
                }
                else
                {
                    JObject ProgramStartPathOptions = ProgramStartOptionsDefaltSetting(); // ProgramStartPathOptions - JObject 다시 만들고 기본값으로 설정
                    jsonDataManiger.PushJsonObject(ProgramVariables.m_programOptionsFileJsonPath, ProgramStartPathOptions); // 설정된 파일 저장
                    //Console.WriteLine(programOptions.ToString());
                }
            }
            else
            {
                jsonDataManiger.JsonChackFileAndCreate(ProgramVariables.m_programOptionsFileJsonPath); //Json 파일 만들기
                JObject ProgramStartPathOptions = ProgramStartOptionsDefaltSetting(); // ProgramStartOptions - JObject 다시 만들고 기본값으로 설정
                jsonDataManiger.PushJsonObject(ProgramVariables.m_programOptionsFileJsonPath, ProgramStartPathOptions); // 설정된 파일 저장
            }
        }

        /// <summary>
        /// ProgramStartOptions -JObject 다시 만들고 기본값으로 설정 
        /// </summary>
        /// <returns></returns>
        public static JObject ProgramStartOptionsDefaltSetting()
        {
            JObject ProgramStartPathOptions = ProgramStartPathOptionsDefaltSetting(); // ProgramStartPathOptions - JObject 다시 만들고 기본값으로 설정
            JObject programOptions = new JObject(); // 최종 출력 programOptions 아래 옵션들 programOptions에 병합
            programOptions.Merge(ProgramStartPathOptions, new JsonMergeSettings // ProgramStartPathOptions programOptions에 병합
            {
                MergeArrayHandling = MergeArrayHandling.Union // union array values together to avoid duplicates
            });

            // 다른 ProgramStartOptions이 추가되면 아래로 추가 

            //Console.WriteLine(programOptions.ToString());
            return programOptions;
        }

        /// <summary>
        /// ProgramStartPathOptions -JObject 다시 만들고 기본값으로 설정 
        /// </summary>
        /// <returns></returns>
        public static JObject ProgramStartPathOptionsDefaltSetting()
        {
            object programStartPathOptions = new
            {
                string_m_programSpace = ProgramVariables.ProgramSpacePathDefalt,
                string_m_programOptionsSpace = ProgramVariables.ProgramOptionsSpacePathDefalt,
                string_m_programOptionsFileJsonPath = ProgramVariables.ProgramOptionsFileJsonPathDefalt,
                string_m_programlog = ProgramVariables.ProgramlogPathDefalt,
                string_m_programgiulog = ProgramVariables.ProgramgiulogPathDefalt,
                string_m_programWokrSpace = ProgramVariables.ProgramWokrSpacePathDefalt
            };

            JObject programStartPathOptionsJson = JObject.FromObject(programStartPathOptions);
            JObject programOptions = new JObject
            {
                    { "programStartPathOptions", programStartPathOptionsJson }
            };
            return programOptions;
        }


        /// <summary>
        /// ProgramStartPathOptions 값이 수정되면 Start Form에서 변경되는 Componet 수정, Json 파일 수정
        /// </summary>
        public void IfStartOptionsChange()
        {
            JObject programOptionsJObject = jsonDataManiger.GetJsonObject(ProgramVariables.m_programOptionsFileJsonPath, ProgramOptionsDataIntegrityCheck); // programOptions Json 파일 읽고 무결성 검사
            JObject programStartPathOptions = (JObject)programOptionsJObject["programStartPathOptions"]; //  programEntryPointOptions 객체 있음을 확인 

            // 값 반영
            programStartPathOptions["string_m_programSpace"] = ProgramVariables.m_programSpacePath;
            programStartPathOptions["string_m_programOptionsSpace"] = ProgramVariables.m_programOptionsSpacePath;
            programStartPathOptions["string_m_programOptionsFileJsonPath"] = ProgramVariables.m_programOptionsFileJsonPath;
            programStartPathOptions["string_m_programlog"] = ProgramVariables.m_programlogPath;
            programStartPathOptions["string_m_programgiulog"] = ProgramVariables.m_programgiulogPath;
            programStartPathOptions["string_m_programWokrSpace"] = ProgramVariables.m_programWokrSpacePath;

            // 옵션이 추가되면 작성

            IfStartOptionsChangeComponet(); //Componet 변경사항 적용
            jsonDataManiger.PushJsonObject(ProgramVariables.m_programOptionsFileJsonPath, programOptionsJObject); // Json 파일 저장 
        }
        // Componet 변경사항 확인 적용
        private void IfStartOptionsChangeComponet()
        {
            txtMprogramWorkSpacePath.Text = ProgramVariables.m_programWokrSpacePath;
        }


        /// <summary>
        /// ProgramOptions Json 파일 데이터 무결성 검사
        /// </summary>
        /// <param name="jsonData"> 검사할 programEntryPoint 파일 JObject</param>
        public static JObject ProgramOptionsDataIntegrityCheck(JObject programOptionsJObject)
        {
            if (programOptionsJObject != null) // jsonDataManiger에서 GetJsonObject을 타고 넘어온 programOptionsJObject 객체가 데이터 읽기에 실패 하였는지 확인
            {
                //Console.WriteLine(programOptionsJObject.ToString());

                #region programOptionsJObject 관리
                if (programOptionsJObject["programStartPathOptions"] != null) // programEntryPointOptions 객체 확인
                {
                    //Console.WriteLine("1 ProgramEntryPointOptionsDataIntegrityCheck");
                    JObject programStartPathOptions = (JObject)programOptionsJObject["programStartPathOptions"]; //  programEntryPointOptions 객체 있음을 확인 

                    if (programStartPathOptions["string_m_programSpace"] == null) //  string_m_programSpace 객체 없음을 확인 
                        programStartPathOptions.Add(new JProperty("string_m_programSpace", ProgramVariables.ProgramSpacePathDefalt));
                    if (programStartPathOptions["string_m_programOptionsSpace"] == null) //  string_m_programOptionsSpace 객체 없음을 확인 
                        programStartPathOptions.Add(new JProperty("string_m_programOptionsSpace", ProgramVariables.ProgramOptionsSpacePathDefalt));
                    if (programStartPathOptions["string_m_programOptionsFileJsonPath"] == null) //  string_m_programOptionsSpace 객체 없음을 확인 
                        programStartPathOptions.Add(new JProperty("string_m_programOptionsFileJsonPath", ProgramVariables.ProgramOptionsFileJsonPathDefalt));
                    if (programStartPathOptions["string_m_programlog"] == null) //  string_m_programlog 객체 없음을 확인 
                        programStartPathOptions.Add(new JProperty("string_m_programlog", ProgramVariables.ProgramlogPathDefalt));
                    if (programStartPathOptions["string_m_programgiulog"] == null) //  string_m_programgiulog 객체 없음을 확인 
                        programStartPathOptions.Add(new JProperty("string_m_programgiulog", ProgramVariables.ProgramgiulogPathDefalt));
                    if (programStartPathOptions["string_m_programWokrSpace"] == null) //  string_m_programWokrSpace 객체 없음을 확인 
                        programStartPathOptions.Add(new JProperty("string_m_programWokrSpace", ProgramVariables.ProgramWokrSpacePathDefalt));
                }
                else
                {
                    JObject ProgramStartPathOptions = ProgramStartPathOptionsDefaltSetting(); // ProgramStartPathOptions -JObject 다시 만들고 기본값으로 설정 
                    programOptionsJObject.Merge(ProgramStartPathOptions); // programOptionsJObject 와 데이터 병합
                }
                #endregion
                // 다른 ProgramStartOptions이 추가되면 아래로 추가 
            }
            else
                programOptionsJObject = ProgramStartOptionsDefaltSetting(); // ProgramStartOptions -JObject 다시 만들고 기본값으로 설정 

            //Console.WriteLine(programOptionsJObject.ToString());
            return programOptionsJObject;
        }
        #endregion

        /// <summary>
        /// StartForm 시작전 Component에 기본 값 설정
        /// </summary>
        private void StartFormStartComponentSeting()
        {
            txtMprogramWorkSpacePath.Text = ProgramVariables.m_programWokrSpacePath;
        }

        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            this.styleManagerStartForm.Style = styleManager.Style;
            this.styleManagerStartForm.Theme = styleManager.Theme;

            if (styleManager.Theme == MetroThemeStyle.Light)
                PanelMainLogo.BackgroundImage = Properties.Resources.iconlogoB_X2;

            else
                PanelMainLogo.BackgroundImage = Properties.Resources.iconlogoW_X2;

        }

        private void ButtonStartClick(object sender, EventArgs e)
        {
            /// <summary>
            /// MainForm 호출
            /// </summary>
            ProjectAI.MainForms.MainForm MainForm = ProjectAI.MainForms.MainForm.GetInstance();
            MainForm.Show();
            //Hiding the window, because closing it makes the window unaccessible.
            //this.Hide();
            //this.Parent = null;
            //e.Cancel = true; //hides the form, cancels closing event
        }

        private void ButtonExitClick(object sender, EventArgs e)
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

        private void ButtonStyleChangeClick(object sender, EventArgs e)
        {
            if (formsManiger.m_isDarkMode) // Dark로 변경시 진입
            {
                formsManiger.m_isDarkMode = false;
                formsManiger.m_StyleManager.Style = MetroColorStyle.Silver;
                formsManiger.m_StyleManager.Theme = MetroThemeStyle.Dark;
                this.BackColor = formsManiger.GetThemeRGBClor("Dark");

            }
            else // Light로 변경시 진입
            {
                formsManiger.m_isDarkMode = true;
                formsManiger.m_StyleManager.Style = MetroColorStyle.Lime;
                formsManiger.m_StyleManager.Theme = MetroThemeStyle.Light;
                this.BackColor = formsManiger.GetThemeRGBClor("Light");
            }

            FormsManiger.m_formStyleManagerHandler(formsManiger.m_StyleManager);
        }

        private void ButtonStartOptionClick(object sender, EventArgs e)
        {
            this.StartFormOptions.Show();
        }

        private void BtnMprogramWorkSpaceChangeClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = ProgramVariables.m_programWokrSpacePath;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    ProgramVariables.m_programWokrSpacePath = folderBrowserDialog.SelectedPath;
                    FormsManiger.m_startFormOptionsManagerHandler(); // StartForm 변경사항 반영
                    CustomIOMainger.DirChackExistsAndCreate(ProgramVariables.m_programWokrSpacePath); // 경로에 폴더가 있는지 확인
                }
            }
        }

        private void tableLayoutMainIcons_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

