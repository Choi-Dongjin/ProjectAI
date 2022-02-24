using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace ProjectAI
{
    /// <summary>
    /// Program 시작에 필요한 기본적인 데이터 관리 -> 프로그램 시작시 필요한 중요 데이터, 데이터를 읽어올시 데이터 무결성 검사 필요, 오류시 복원 필요
    /// </summary>
    public struct ProgramEntryPointVariables
    {
        public static string m_programEntryOptionsSpacePath = System.Windows.Forms.Application.StartupPath;
        public static string m_programEntryOptionsFileJsonPath = Path.Combine(m_programEntryOptionsSpacePath, "EntryOptions.Json");
        public static string m_language = System.Windows.Forms.Application.StartupPath;
    }
    /// <summary>
    /// StartForm에서 Program의 구동에 필요한 기본적인 데이터 관리 -> StartForm Class 호출단에서 Json파일 읽어서 데이터를 모두 처리해야함.
    /// </summary>
    public struct ProgramVariables
    {
        // 프로그램 버전
        public static string m_programVersion = "0.1";
        // 프로그램 기본 경로
        public static string m_programSpacePath = @"C:\Users\USER\AppData\Roaming\SynapseNet\SynapseNet" + " " + m_programVersion;

        // 프로그램 option 데이터 경로
        public static string m_programOptionsSpacePath = Path.Combine(ProgramVariables.m_programSpacePath, "options");
        public static string m_programOptionsFileJsonPath = Path.Combine(ProgramVariables.m_programOptionsSpacePath, "options " + m_programVersion + ".Json");

        // log 경로
        public static string m_programlogPath = Path.Combine(ProgramVariables.m_programSpacePath, "log");
        public static string m_programgiulogPath = Path.Combine(ProgramVariables.m_programSpacePath, "guilog");

        // 프로젝트 워크 스페이스 경로
        public static string m_programWokrSpacePath;

        // Defalt 값 readonly
        public static string ProgramSpacePath_Defalt { get { return @"C:\Users\USER\AppData\Roaming\SynapseNet\SynapseNet" + " " + m_programVersion; } }
        public static string ProgramOptionsSpacePath_Defalt { get { return Path.Combine(ProgramVariables.m_programSpacePath, "options"); } }
        public static string ProgramOptionsFileJsonPath_Defalt { get { return Path.Combine(ProgramVariables.m_programOptionsSpacePath, "options " + m_programVersion + ".Json"); } }
        public static string ProgramlogPath_Defalt { get { return Path.Combine(ProgramVariables.m_programSpacePath, "log"); } }
        public static string ProgramgiulogPath_Defalt { get { return Path.Combine(ProgramVariables.m_programSpacePath, "guilog"); } }
        public static string ProgramWokrSpacePath_Defalt { get { return Path.Combine(ProgramVariables.m_programSpacePath, "workspaces"); } }
    }
    /// <summary>
    /// MainForm 시작시 WorkSpace들의 기본적인 데이터 관리 -> MainForm Class 호출단에서 Json파일 읽어서 데이터를 모두 처리해야함.
    /// </summary>    
    public struct WorkSpaceEarlyData
    {
        /// <summary>
        /// workSpaceEarlyData Jobject 관리
        /// </summary>
        public static JObject workSpaceEarlyDataJobject = new JObject();

        /// <summary>
        /// Program Wokr Space 경로
        /// </summary>
        public static string m_workSpacDataPath = ProgramVariables.m_programWokrSpacePath;
        /// <summary>
        /// ProgramWokr Space Optin File 경로
        /// </summary>
        public static string m_workSpacDataFilePath = Path.Combine(ProgramVariables.m_programWokrSpacePath, "workspacesdata.Json");

        /// <summary>
        /// ProgramVariables즉 StartForm, StartFormOptions에서 ProgramVariables값에 해당하는 값이 변경되면 호출 
        /// </summary>
        public static void ProgramVariablesChange()
        {
            m_workSpacDataPath = ProgramVariables.m_programWokrSpacePath;
            m_workSpacDataFilePath = Path.Combine(ProgramVariables.m_programWokrSpacePath, "workspacesdata.Json");
        }

        /// <summary>
        /// workSpace들의 이름 정보를 필요 처음으로 읽어서 각 workSpace의 데이터를 읽어오는데 사용
        /// </summary>
        // public static List<string> m_workSpaceNameList = new List<string>();

        /// <summary>
        /// WorkSpaceButton List 관리
        /// </summary>
        public static List<MainForms.WorkSpaceButton> m_workSpaceButtons = new List<MainForms.WorkSpaceButton>();

        /// <summary>
        /// workSpace 이름 내부 정보를 읽어오기 위애서 사용
        /// </summary>
        public static string m_workSpaceName;
        // 각 workSpace 내부 정보
        public static string m_workSpacePath;
        public static string m_workSpaceSize;
        public static string m_workSpaceVersion;
    }

    /// <summary>
    /// MainForm 시작시 WorkSpace들의 기본적인 데이터 관리 -> MainForm Class 호출단에서 Json파일 읽어서 데이터를 모두 처리해야함.
    /// </summary>    
    public struct WorkSpaceData
    {
        /// <summary>
        /// 실행중인 project 관리 Dictionary
        /// </summary>
        public static Dictionary<string, ProjectMainger> m_projectMaingersDictionary = new Dictionary<string, ProjectMainger>();

        public static ProjectMainger m_actionProjectMainger;
    }

    /// <summary>
    /// WorkSpace 가 호출되면 호출되는 Class,각 WorkSpace의 데이터 관리
    /// </summary>
    public class ProjectMainger
    {
        #region ProjectMainger에 종속된 Forms 정의

        /// <summary>
        /// 프로젝트 선택 폼
        /// </summary>
        public MainForms.DeeplearningProjectSelectForm deeplearningProjectSelectForm = new MainForms.DeeplearningProjectSelectForm();

        #endregion ProjectMainger에 종속된 Forms 정의
        //=== === === === === === === === === === === === === === === 
        #region ProjectMainger에 종속된 UserContral 정의

        /// <summary>
        /// 프로젝트 아이들 상태 유저 컨트롤
        /// </summary>
        public ProjectAI.CustomComponent.MainForms.Idle.TrainOptions m_idleTrainOption = new ProjectAI.CustomComponent.MainForms.Idle.TrainOptions();

        #endregion ProjectMainger에 종속된 UserContral 정의

        /// <summary>
        /// Json File 관리 Class
        /// </summary>
        private readonly JsonDataManiger jsonDataManiger = JsonDataManiger.GetInstance();
        /// <summary>
        /// 각 폼의 변수 관리
        /// </summary>
        private readonly FormsManiger formsManiger = FormsManiger.GetInstance();

        /// <summary>
        /// 활성화된 프로젝으 이름
        /// </summary>
        public string m_activeProjectName;

        /// <summary>
        /// 활설화된 프로젝트 경로
        /// </summary>
        public string m_pathActiveProject;

        /// <summary>
        /// 프로젝트 데이터 폴터
        /// </summary>
        public string m_pathActiveProjectData;

        /// <summary>
        /// 이미지 리스트 관리 자료 경로
        /// </summary>
        public string m_pathActiveProjectDataImageList;
        /// <summary>
        /// 이미지 리스트 관리 자료
        /// </summary>
        public JObject m_activeProjectImageListJObject;

        /// <summary>
        ///  각 이미지 정보 관리 자료 경로
        /// </summary>
        public string m_pathActiveProjectDataImageListData;
        /// <summary>
        /// 각 이미지 정보 관리 자료
        /// </summary>
        public JObject m_ActiveProjectDataImageListDataJObject;

        /// <summary>
        /// 실 이미지 관리 경로
        /// </summary>
        public string m_pathActiveProjectImage;

        /// <summary>
        /// 모델 관리 경로
        /// </summary>
        public string m_pathActiveProjectModel;
        /// <summary>
        /// 모델 학습 정보 관리 자료 경로
        /// </summary>
        public string m_pathActiveProjectModelInfo;
        /// <summary>
        /// 모델 학습 정보 관리 자료 자료
        /// </summary>
        public JObject m_ActiveProjectModelInfoJObject;

        /// <summary>
        /// Class 정보 관리 자료 경로 
        /// </summary>
        public string m_pathActiveProjectClassInfo;
        /// <summary>
        /// Class 정보 관리 자료 자료
        /// </summary>
        public JObject m_ActiveProjectClassInfoJObject;

        /// <summary>
        /// 워크 스패이스내 프로젝트 정보 관리 자료 경로 
        /// </summary>
        public string m_pathActiveProjectInnerProjectInfo;
        /// <summary>
        /// 워크 스패이스내 프로젝트 정보 관리 자료
        /// </summary>
        public JObject m_ActiveProjectInnerProjectInfoJObject;


        /// <summary>
        /// Project 에 필요한 폴터 리스트
        /// </summary>
        readonly List<string> m_projectFolderList = new List<string>();
        /// <summary>
        /// Project 에 필요한 데이터 파일 리스트
        /// </summary>
        readonly List<string> m_jsonFileList = new List<string>();


        /// <summary>
        /// 프로젝트 #Class 처음 진입시
        /// </summary>
        /// <param name="workSpaceName"> 워크 스페이스 이름</param>
        public ProjectMainger(string workSpaceName)
        {
            this.m_activeProjectName = workSpaceName;
            Console.WriteLine(workSpaceName);

            this.ActiveProjectIdleContralsSetting(); // Idle UI Consrals 셋업
            this.ActiveProjectPathDataInitialization(); // 활성화된 Project 경로 변수 초기화
            this.ActiveProjectEntry(); // 프로젝트 폴더 확인, 문제가 없다면 기존의 데이터 읽어오기
            
        }

        /// <summary>
        /// 활성화된 Project 경로 변수 초기화
        /// </summary>
        private void ActiveProjectPathDataInitialization()
        {
            this.m_pathActiveProject = Path.Combine(WorkSpaceEarlyData.m_workSpacDataPath,this.m_activeProjectName);

            this.m_pathActiveProjectData = Path.Combine(m_pathActiveProject, "data");

            this.m_pathActiveProjectDataImageList = Path.Combine(this.m_pathActiveProject, "data", "imagelist.Json");
            this.m_pathActiveProjectDataImageListData = Path.Combine(this.m_pathActiveProject, "data", "imageListData.Json");

            this.m_pathActiveProjectImage = Path.Combine(this.m_pathActiveProject, "images");

            this.m_pathActiveProjectModel = Path.Combine(this.m_pathActiveProject, "model");
            this.m_pathActiveProjectModelInfo = Path.Combine(this.m_pathActiveProject, "data", "ModelInfo.Json");

            this.m_pathActiveProjectClassInfo = Path.Combine(this.m_pathActiveProject, "data", "classificationCalssInfo.Json");

            this.m_pathActiveProjectInnerProjectInfo = Path.Combine(this.m_pathActiveProject, "data", "innerProjectInfo.Json");


            this.m_projectFolderList.Add(this.m_pathActiveProjectData);
            this.m_projectFolderList.Add(this.m_pathActiveProjectModel);
            this.m_projectFolderList.Add(this.m_pathActiveProjectImage);

            this.m_jsonFileList.Add(this.m_pathActiveProjectDataImageList);
            this.m_jsonFileList.Add(this.m_pathActiveProjectDataImageListData);
            this.m_jsonFileList.Add(this.m_pathActiveProjectModelInfo);
            this.m_jsonFileList.Add(this.m_pathActiveProjectClassInfo);
            this.m_jsonFileList.Add(this.m_pathActiveProjectInnerProjectInfo);
        }

        /// <summary>
        /// 프로젝트 초기화
        /// </summary>
        private void ActiveProjectReset()
        {
            // 폴더 초기화
            foreach (string folder in m_projectFolderList)
                CustomIOMainger.DirChackExistsAndCreate(Path.Combine(this.m_pathActiveProject, folder));

            // Json 파일 초기화, Json 파일 데이터 가져오기
            foreach (string folderPath in m_jsonFileList)
            {
                this.jsonDataManiger.JsonChackFileAndCreate(folderPath); // Json 파일 생성

                this.jsonDataManiger.JsonChackFileAndCreate(folderPath); // 파일 초기화
                JObject jObject = new JObject() { };
                this.jsonDataManiger.PushJsonObject(folderPath, jObject);
            }

            this.AvtiveProjectJsonDataReadAll(); // Json Data File Read
        }

        /// <summary>
        /// Json 데이터 파일 읽어오기
        /// </summary>
        private void AvtiveProjectJsonDataReadAll()
        {
            //Json 파일 데이터 가져오기
            this.m_activeProjectImageListJObject = jsonDataManiger.GetJsonObject(m_pathActiveProjectDataImageList);
            this.m_ActiveProjectDataImageListDataJObject = jsonDataManiger.GetJsonObject(m_pathActiveProjectDataImageListData);
            this.m_ActiveProjectModelInfoJObject = jsonDataManiger.GetJsonObject(m_pathActiveProjectModelInfo);
            this.m_ActiveProjectClassInfoJObject = jsonDataManiger.GetJsonObject(m_pathActiveProjectClassInfo);
            this.m_ActiveProjectInnerProjectInfoJObject = jsonDataManiger.GetJsonObject(m_pathActiveProjectInnerProjectInfo);
        }

        /// <summary>
        /// 프로젝트 폴더 확인, 문제가 없다면 기존의 데이터 읽어오기
        /// </summary>
        private void ActiveProjectEntry()
        {
            if (CustomIOMainger.DirChackExistsAndCreate(m_pathActiveProject))
            {
                // 생성된 폴더가 있는 경우
                if (CustomIOMainger.DirChackExistsAndCreate(m_pathActiveProjectData))
                {
                    this.ActiveProjectEntryDataRead(); // 기존 데이터 읽어오기
                } // Data 폴더가 있는지 확인
                else 
                {
                    // Error #1
                    MetroMessageBox.Show(formsManiger.mainForm, "프로젝트 데이터 손상 초기화", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ActiveProjectReset(); // 프로젝트 초기화
                } // Data 폴더가 없는 경우

                foreach (string folderName in m_projectFolderList)
                {
                    CustomIOMainger.DirChackExistsAndCreate(Path.Combine(this.m_pathActiveProject, folderName));
                }
            } // 폴더 생성
            else
            {
                this.ActiveProjectReset(); // 프로젝트 초기화
            } // NEW 프로젝트 생성 
        }

        /// <summary>
        /// 프로젝트 진입시 프로젝트 데이터 읽어오고 문제가 없는지 확인
        /// </summary>
        public void ActiveProjectEntryDataRead()
        {
            this.ActiveProjectImageListRead(); // 이미지 리스트 데이터 읽어오기
            this.ActiveProjectImageDataRead(); // 이미지 데이터 읽어오기
            this.ActiveProjectModelInfoRead(); // 프로젝트 모델 정보 데이터 읽어오기
            this.ActiveProjectClassInfoRead(); // 프로젝트 클래스 정보 데이터 읽어오기
            this.ActiveProjectInnerProjectInfoRead(); // 활성화된 프로젝트 딥 러닝 프로젝트 정보 읽어오기 
        }
        /// <summary>
        /// 이미지 리스트 데이터 읽어오고 문제가 있으면 초기화
        /// </summary>
        private void ActiveProjectImageListRead()
        {
            #region m_activeProjectImageListJObject File 읽기
            if (this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectDataImageList)) // DataImageList Json 데이터 파일이 있는지 확인
            {
                if ((this.m_activeProjectImageListJObject = jsonDataManiger.GetJsonObject(this.m_pathActiveProjectDataImageList)) != null) // Json 파일을 읽을수 있는지 확인
                {
                    // this.m_activeProjectImageListJObject 
                    // 읽어온 데이터 처리 가 필요하면 작성
                }
                else // Json 데이터 파일 읽어오기 오류
                {
                    MetroMessageBox.Show(formsManiger.mainForm, "m_pathActiveProjectDataImageList.Json 데이터 읽어오기 오류", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CustomIOMainger.FileRemove(this.m_pathActiveProjectDataImageList); // 오류난 파일 삭제
                    CustomIOMainger.FileIODelay(100); // 딜레이

                    this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectDataImageList); // 파일 초기화
                    JObject jObject = new JObject() { };
                    this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectDataImageList, jObject);
                }
            }
            else // Json 데이터 파일이 없음. 
            {
                MetroMessageBox.Show(formsManiger.mainForm, "m_pathActiveProjectDataImageList.Json 데이터 없음 초기화", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectDataImageList); // 파일 초기화
                JObject jObject = new JObject() { };
                this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectDataImageList, jObject);
            }
            #endregion m_activeProjectImageListJObject File 읽기
        }
        /// <summary>
        /// 각 이미지 데이터 읽어오고 문제가 있으면 초기화
        /// </summary>
        private void ActiveProjectImageDataRead()
        {
            #region m_ActiveProjectDataImageListDataJObject File 읽기
            if (this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectDataImageListData)) // ImageListData Json 데이터 파일이 있는지 확인
            {
                if ((this.m_ActiveProjectDataImageListDataJObject = jsonDataManiger.GetJsonObject(this.m_pathActiveProjectDataImageListData)) != null) // Json 파일을 읽을수 있는지 확인
                {
                    // this.m_ActiveProjectDataImageListDataJObject 
                    // 읽어온 데이터 처리 가 필요하면 작성
                }
                else // Json 데이터 파일 읽어오기 오류
                {
                    MetroMessageBox.Show(formsManiger.mainForm, "m_pathActiveProjectDataImageListData.Json 데이터 읽어오기 오류", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CustomIOMainger.FileRemove(this.m_pathActiveProjectDataImageListData); // 오류난 파일 삭제
                    CustomIOMainger.FileIODelay(100); // 딜레이

                    this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectDataImageListData); // 파일 초기화
                    JObject jObject = new JObject() { };
                    this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectDataImageListData, jObject);
                }
            }
            else // Json 데이터 파일이 없음. 
            {
                MetroMessageBox.Show(formsManiger.mainForm, "m_pathActiveProjectDataImageListData.Json 데이터 없음 초기화", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectDataImageListData); // 파일 초기화
                JObject jObject = new JObject() { };
                this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectDataImageListData, jObject);
            }
            #endregion m_ActiveProjectDataImageListDataJObject File 읽기
        }
        /// <summary>
        /// 프로젝트 모델 정보 읽어오고 문제가 있으면 초기화
        /// </summary>
        private void ActiveProjectModelInfoRead()
        {
            #region m_ActiveProjectModelInfoJObject File 읽기
            if (this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectModelInfo)) // ImageListData Json 데이터 파일이 있는지 확인
            {
                if ((this.m_ActiveProjectModelInfoJObject = jsonDataManiger.GetJsonObject(this.m_pathActiveProjectModelInfo)) != null) // Json 파일을 읽을수 있는지 확인
                {
                    // this.m_ActiveProjectModelInfoJObject 
                    // 읽어온 데이터 처리 가 필요하면 작성
                }
                else // Json 데이터 파일 읽어오기 오류
                {
                    MetroMessageBox.Show(formsManiger.mainForm, "m_ActiveProjectModelInfoJObject.Json 데이터 읽어오기 오류", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CustomIOMainger.FileRemove(this.m_pathActiveProjectModelInfo); // 오류난 파일 삭제
                    CustomIOMainger.FileIODelay(100); // 딜레이

                    this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectModelInfo); // 파일 초기화
                    JObject jObject = new JObject() { };
                    this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectModelInfo, jObject);
                }
            }
            else // Json 데이터 파일이 없음. 
            {
                MetroMessageBox.Show(formsManiger.mainForm, "m_ActiveProjectModelInfoJObject.Json 데이터 없음 초기화", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectModelInfo); // 파일 초기화
                JObject jObject = new JObject() { };
                this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectModelInfo, jObject);
            }
            #endregion m_ActiveProjectModelInfoJObject File 읽기
        }
        /// <summary>
        /// 프로젝트 클래스 정보 읽어오고 문제가 있으면 초기화
        /// </summary>
        private void ActiveProjectClassInfoRead()
        {
            #region m_ActiveProjectClassInfoJObject File 읽기
            if (this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectClassInfo)) // ImageListData Json 데이터 파일이 있는지 확인
            {
                if ((this.m_ActiveProjectClassInfoJObject = jsonDataManiger.GetJsonObject(this.m_pathActiveProjectClassInfo)) != null) // Json 파일을 읽을수 있는지 확인
                {
                    // this.m_ActiveProjectClassInfoJObject 
                    // 읽어온 데이터 처리 가 필요하면 작성
                }
                else // Json 데이터 파일 읽어오기 오류
                {
                    MetroMessageBox.Show(formsManiger.mainForm, "m_ActiveProjectClassInfoJObject.Json 데이터 읽어오기 오류", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CustomIOMainger.FileRemove(this.m_pathActiveProjectClassInfo); // 오류난 파일 삭제
                    CustomIOMainger.FileIODelay(100); // 딜레이

                    this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectClassInfo); // 파일 초기화
                    JObject jObject = new JObject() { };
                    this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectClassInfo, jObject);
                }
            }
            else // Json 데이터 파일이 없음. 
            {
                MetroMessageBox.Show(formsManiger.mainForm, "m_ActiveProjectClassInfoJObject.Json 데이터 없음 초기화", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectClassInfo); // 파일 초기화
                JObject jObject = new JObject() { };
                this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectClassInfo, jObject);
            }
            #endregion m_ActiveProjectClassInfoJObject File 읽기
        }
        /// <summary>
        /// 활성화된 프로젝트 딥 러닝 프로젝트 정보 읽어오고 문제가 있으면 초기화
        /// </summary>
        private void ActiveProjectInnerProjectInfoRead()
        {
            #region m_ActiveProjectClassInfoJObject File 읽기
            if (this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectInnerProjectInfo)) // ImageListData Json 데이터 파일이 있는지 확인
            {
                if ((this.m_ActiveProjectInnerProjectInfoJObject = jsonDataManiger.GetJsonObject(this.m_pathActiveProjectInnerProjectInfo)) != null) // Json 파일을 읽을수 있는지 확인
                {
                    // this.m_ActiveProjectClassInfoJObject 
                    // 읽어온 데이터 처리 가 필요하면 작성
                }
                else // Json 데이터 파일 읽어오기 오류
                {
                    MetroMessageBox.Show(formsManiger.mainForm, "m_ActiveProjectClassInfoJObject.Json 데이터 읽어오기 오류", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CustomIOMainger.FileRemove(this.m_pathActiveProjectInnerProjectInfo); // 오류난 파일 삭제
                    CustomIOMainger.FileIODelay(100); // 딜레이

                    this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectInnerProjectInfo); // 파일 초기화
                    JObject jObject = new JObject() { };
                    this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectInnerProjectInfo, jObject);
                }
            }
            else // Json 데이터 파일이 없음. 
            {
                MetroMessageBox.Show(formsManiger.mainForm, "m_ActiveProjectInnerProjectInfoJObject.Json 데이터 없음 초기화", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectInnerProjectInfo); // 파일 초기화
                JObject jObject = new JObject() { };
                this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectInnerProjectInfo, jObject);
            }
            #endregion m_ActiveProjectClassInfoJObject File 읽기
        }
        
        /// <summary>
        /// Idle UI Consrals 셋업
        /// </summary>
        private void ActiveProjectIdleContralsSetting()
        {
            #region TrainOption 설정
            formsManiger.mainForm.styleExtenderMainForm.SetApplyMetroTheme(this.m_idleTrainOption, true);
            this.m_idleTrainOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_idleTrainOption.Location = new System.Drawing.Point(0, 0);
            this.m_idleTrainOption.Margin = new System.Windows.Forms.Padding(0);
            this.m_idleTrainOption.Padding = new System.Windows.Forms.Padding(20, 20, 10, 20);
            //this.m_idleTrainOption.Name = "sts";
            //this.m_idleTrainOption.TabIndex = 0;
            #endregion TrainOption 설정
        }

        /// <summary>
        /// IdleUI 적용
        /// </summary>
        public void ProjectIdleUISet()
        {
            formsManiger.mainForm.panelTrainOptions.Controls.Add(this.m_idleTrainOption);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ProjectUIRemove()
        {
            ProjectIdleUIRemove();
        }
        /// <summary>
        /// IdleUI 적용된 부분 삭제
        /// </summary>
        public void ProjectIdleUIRemove()
        {
            formsManiger.mainForm.panelTrainOptions.Controls.Remove(this.m_idleTrainOption);
        }



        public void Test1()
        {

        }
    }
}
