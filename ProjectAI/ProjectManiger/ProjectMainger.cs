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
        public static string m_programEntryOptionsFileJsonPath = Path.Combine( ProgramEntryPointVariables.m_programEntryOptionsSpacePath, "EntryOptions.Json");
        public static string m_language = System.Windows.Forms.Application.StartupPath;
    }
    /// <summary>
    /// StartForm에서 Program의 구동에 필요한 기본적인 데이터 관리 -> StartForm Class 호출단에서 Json파일 읽어서 데이터를 모두 처리해야함.
    /// </summary>
    public struct ProgramVariables
    {
        // 프로그램 ApplicationData 경로 가져오기
        private static string m_programApplicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //@"C:\Users\USER\AppData\Roaming"


        // 프로그램 버전
        public static string m_programVersion = "0.1";
        // 프로그램 기본 경로
        public static string m_programSpacePath = Path.Combine( m_programApplicationDataPath, @"SynapseNet\SynapseNet" + " " + m_programVersion);

        // 프로그램 option 데이터 경로
        public static string m_programOptionsSpacePath = Path.Combine(ProgramVariables.m_programSpacePath, "options");
        public static string m_programOptionsFileJsonPath = Path.Combine(ProgramVariables.m_programOptionsSpacePath, "options " + m_programVersion + ".Json");

        // log 경로
        public static string m_programlogPath = Path.Combine(ProgramVariables.m_programSpacePath, "log");
        public static string m_programgiulogPath = Path.Combine(ProgramVariables.m_programSpacePath, "guilog");

        // 프로젝트 워크 스페이스 경로
        public static string m_programWokrSpacePath;

        // Defalt 값 readonly
        public static string ProgramSpacePath_Defalt { get { return Path.Combine(ProgramEntryPointVariables.m_programEntryOptionsSpacePath, @"SynapseNet\SynapseNet" + " " + m_programVersion); } }
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

        public static ProjectMainger m_activeProjectMainger;
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
        /// <summary>
        /// Class 편집 폼
        /// </summary>
        public MainForms.ClassEdit classEdit = new MainForms.ClassEdit();

        #endregion ProjectMainger에 종속된 Forms 정의
        //=== === === === === === === === === === === === === === === 
        #region ProjectMainger에 종속된 UserContral 정의

        /// <summary>
        /// 프로젝트 아이들 상태 유저 컨트롤
        /// </summary>
        public ProjectAI.CustomComponent.MainForms.Idle.TrainOptions m_idleTrainOption = new ProjectAI.CustomComponent.MainForms.Idle.TrainOptions();

        /// <summary>
        /// 프로젝트 아이들 상태 유저 컨트롤
        /// </summary>
        public ProjectAI.CustomComponent.MainForms.Classification.TrainOptions m_classificationTrainOption = new ProjectAI.CustomComponent.MainForms.Classification.TrainOptions();

        #endregion ProjectMainger에 종속된 UserContral 정의

        private readonly ProjectAI.MainForms.MainForm MainForm = ProjectAI.MainForms.MainForm.GetInstance();

        /// <summary>
        /// Json File 관리 Class
        /// </summary>
        private readonly JsonDataManiger jsonDataManiger = JsonDataManiger.GetInstance();
        /// <summary>
        /// 각 폼의 변수 관리
        /// </summary>
        private readonly FormsManiger formsManiger = FormsManiger.GetInstance();

        /// <summary>
        /// 활성화된 네임스페이스 이름
        /// </summary>
        public string m_activeProjectName;

        /// <summary>
        /// 활성화된 네임스페이스 경로
        /// </summary>
        public string m_pathActiveProject;

        /// <summary>
        /// 활성화된 네임스페이스 데이터 폴터
        /// </summary>
        public string m_pathActiveProjectData;

        /// <summary>
        /// 활성화된 네임스페이스 내의 활성화된 프로젝트, 초기 선택이 없을시 null 처리 필요
        /// </summary>
        public string m_activeInnerProjectName = null;

        /// <summary>
        /// 활성화된 네임스페이스 이미지 리스트 관리 자료 경로
        /// </summary>
        public string m_pathActiveProjectDataImageList;
        /// <summary>
        /// 활성화된 네임스페이스 이미지 리스트 관리 자료
        /// </summary>
        public JObject m_activeProjectImageListJObject;

        /// <summary>
        /// 활성화된 네임스페이스 각 이미지 정보 관리 자료 경로
        /// </summary>
        public string m_pathActiveProjectDataImageListData;
        /// <summary>
        /// 활성화된 네임스페이스 각 이미지 정보 관리 자료
        /// </summary>
        public JObject m_activeProjectDataImageListDataJObject;

        /// <summary>
        /// 활성화된 네임스페이스 실 이미지 관리 경로
        /// </summary>
        public string m_pathActiveProjectImage;

        /// <summary>
        /// 활성화된 네임스페이스 모델 관리 경로
        /// </summary>
        public string m_pathActiveProjectModel;
        /// <summary>
        /// 활성화된 네임스페이스 모델 학습 정보 관리 자료 경로
        /// </summary>
        public string m_pathActiveProjectModelInfo;
        /// <summary>
        /// 활성화된 네임스페이스 모델 학습 정보 관리 자료 자료
        /// </summary>
        public JObject m_activeProjectModelInfoJObject;

        /// <summary>
        /// 활성화된 네임스페이스 워크 스패이스내 프로젝트 정보 관리 자료 경로 
        /// </summary>
        public string m_pathActiveProjectInfo;
        /// <summary>
        /// 활성화된 네임스페이스 워크 스패이스내 프로젝트 정보 관리 자료
        /// </summary>
        public JObject m_activeProjectInfoJObject;

        /// <summary>
        /// 활성화된 네임스페이스 Class 정보 관리 자료 경로 
        /// </summary>
        public string m_pathCalssInfo;
        /// <summary>
        /// 활성화된 네임스페이스 Class 프로젝트 정보 관리 자료 자료
        /// </summary>
        public JObject m_calssInfoJObject;

        /*
         * m_activeProjectImageListJObject;
         * m_activeProjectDataImageListDataJObject;
         * m_activeProjectModelInfoJObject;
         * m_activeProjectInfoJObject;
         * m_calssInfoJObject;
        */

        /// <summary>
        /// Project 에 필요한 폴터 리스트
        /// </summary>
        readonly List<string> m_projectFolderList = new List<string>();
        /// <summary>
        /// Project 에 필요한 데이터 파일 리스트
        /// </summary>
        readonly List<string> m_jsonFileList = new List<string>();

        /// <summary>
        /// 이미지 리스트 내의 이미지 갯수 기본값 - Test로 5로 정함 이미 프로젝트에서 정한 값은 몰?루
        /// </summary>
        private readonly int m_imageeListSetnumber = 5;

        /// <summary>
        /// 현제 이미지 페이지
        /// </summary>
        private int imageListPage = 0;

        /// <summary>
        /// 프로젝트 #Class 처음 진입시
        /// </summary>
        /// <param name="workSpaceName"> 워크 스페이스 이름</param>
        public ProjectMainger(string workSpaceName)
        {
            this.m_activeProjectName = workSpaceName;
            Console.WriteLine(workSpaceName);

            this.ActiveProjectIdleContralsSetting(); // Idle UI Consrals 셋업
            this.ActiveProjectClassificationContralsSetting(); // Classification UI Consrals 셋업

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

            this.m_pathActiveProjectInfo = Path.Combine(this.m_pathActiveProject, "data", "ActiveProjectInfo.Json");

            this.m_pathCalssInfo = Path.Combine(this.m_pathActiveProject, "data", "ClassInfo.Json");

            
            this.m_projectFolderList.Add(this.m_pathActiveProjectData);
            this.m_projectFolderList.Add(this.m_pathActiveProjectModel);
            this.m_projectFolderList.Add(this.m_pathActiveProjectImage);

            this.m_jsonFileList.Add(this.m_pathActiveProjectDataImageList);
            this.m_jsonFileList.Add(this.m_pathActiveProjectDataImageListData);
            this.m_jsonFileList.Add(this.m_pathActiveProjectModelInfo);
            this.m_jsonFileList.Add(this.m_pathActiveProjectInfo);
        }

        /// <summary>
        /// // 프로젝트 초기화, 데이터 읽어오기
        /// </summary>
        private void ActiveProjectReset()
        {
            // 폴더 초기화
            foreach (string folder in m_projectFolderList)
                CustomIOMainger.DirChackExistsAndCreate(Path.Combine(this.m_pathActiveProject, folder));

            // Json 파일 초기화, Json 파일 데이터 가져오기
            this.ActiveProjectEntryDataRead();
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
                    MetroMessageBox.Show(this.MainForm, "프로젝트 데이터 손상 초기화", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ActiveProjectReset(); // 프로젝트 초기화 데이터 읽어오기
                } // Data 폴더가 없는 경우

                foreach (string folderName in m_projectFolderList)
                {
                    CustomIOMainger.DirChackExistsAndCreate(Path.Combine(this.m_pathActiveProject, folderName));
                }
            } // 폴더 생성
            else
            {
                this.ActiveProjectReset(); // 프로젝트 초기화 데이터 읽어오기
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
            this.ActiveProjectInfoRead(); // 프로젝트 딥 러닝 프로젝트 정보 읽어오기 

            this.ClassificationInfoRead(); // Classification 정보 데이터 읽어오기
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
                    if (this.m_activeProjectImageListJObject["int_imageTotalNumber"] == null)
                    {
                        JObject jObject = this.ActiveProjectImageListReset(); // 리셋 값 적용
                        this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectDataImageList, jObject);
                        this.m_activeProjectImageListJObject = jObject; // 값 적용
                    }
                       
                }
                else // Json 데이터 파일 읽어오기 오류
                {
                    MetroMessageBox.Show(this.MainForm, "m_pathActiveProjectDataImageList.Json 데이터 읽어오기 오류", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CustomIOMainger.FileRemove(this.m_pathActiveProjectDataImageList); // 오류난 파일 삭제
                    CustomIOMainger.FileIODelay(100); // 딜레이

                    this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectDataImageList); // 파일 초기화
                    JObject jObject = this.ActiveProjectImageListReset(); // 리셋 값 적용
                    this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectDataImageList, jObject);
                    this.m_activeProjectImageListJObject = jObject; // 값 적용
                }
            }
            else // Json 데이터 파일이 없음. 
            {
                MetroMessageBox.Show(this.MainForm, "m_pathActiveProjectDataImageList.Json 데이터 없음 초기화", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectDataImageList); // 파일 초기화

                JObject jObject = this.ActiveProjectImageListReset(); // 리셋 값 적용
                this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectDataImageList, jObject);
                this.m_activeProjectImageListJObject = jObject; // 값 적용
            }
            #endregion m_activeProjectImageListJObject File 읽기
        }
        /// <summary>
        /// 이미지 리스트 데이터 초기화 데이터 생성
        /// </summary>
        private JObject ActiveProjectImageListReset()
        {
            List<string> imageList = CustomIOMainger.ImageFileFileSearch(this.m_pathActiveProjectImage, false);
            int ImageListnumber = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(imageList.Count) / this.m_imageeListSetnumber));

            JObject imageListJObject = new JObject() { };
            JObject iJObject = new JObject() { };

            for (int i = 0; i < ImageListnumber; i++)
            {
                List<string> iImageList = new List<string>();
                try
                {
                    iImageList = imageList.GetRange(i * this.m_imageeListSetnumber, this.m_imageeListSetnumber);
                }

                catch
                {
                    iImageList = imageList.GetRange(i * this.m_imageeListSetnumber, imageList.Count - i * this.m_imageeListSetnumber);
                }

                //object imageListdata = new
                //{
                //    array_string_imageList = iImageList,
                //    int_number = i
                //};

                //iJObject[i.ToString()] = JObject.FromObject(imageListdata);
                iJObject[i.ToString()] = JArray.FromObject(iImageList.ToArray());

                var fje = JArray.FromObject(iImageList.ToArray()).ToArray();

                //var array = ;

            }
            imageListJObject["imageList"] = iJObject;

            if (ImageListnumber == 0)
                ImageListnumber++;

            object newObject = new
            {
                int_imageTotalNumber = imageList.Count,
                int_ImageListnumber = ImageListnumber,
                int_imageeListSetnumber = this.m_imageeListSetnumber,
                string_ImageListDataPath = this.m_pathActiveProjectDataImageListData,
            };
            JObject jObject = JObject.FromObject(newObject);
            jObject.Merge(imageListJObject);
            return jObject;
        } // 이미지 리스트 데이터 초기화 데이터 생성

        /// <summary>
        /// 각 이미지 데이터 읽어오고 문제가 있으면 초기화
        /// </summary>
        private void ActiveProjectImageDataRead()
        {
            #region m_ActiveProjectDataImageListDataJObject File 읽기
            if (this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectDataImageListData)) // ImageListData Json 데이터 파일이 있는지 확인
            {
                if ((this.m_activeProjectDataImageListDataJObject = jsonDataManiger.GetJsonObject(this.m_pathActiveProjectDataImageListData)) != null) // Json 파일을 읽을수 있는지 확인
                {
                    // this.m_activeProjectDataImageListDataJObject 
                    // 읽어온 데이터 처리 가 필요하면 작성
                }
                else // Json 데이터 파일 읽어오기 오류
                {
                    MetroMessageBox.Show(this.MainForm, "m_pathActiveProjectDataImageListData.Json 데이터 읽어오기 오류", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CustomIOMainger.FileRemove(this.m_pathActiveProjectDataImageListData); // 오류난 파일 삭제
                    CustomIOMainger.FileIODelay(100); // 딜레이

                    this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectDataImageListData); // 파일 초기화
                    JObject jObject = this.ActiveProjectImageDataReset();
                    this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectDataImageListData, jObject);
                    this.m_activeProjectDataImageListDataJObject = jObject; //값 적용
                }
            }
            else // Json 데이터 파일이 없음. 
            {
                MetroMessageBox.Show(this.MainForm, "m_pathActiveProjectDataImageListData.Json 데이터 없음 초기화", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectDataImageListData); // 파일 초기화
                JObject jObject = this.ActiveProjectImageDataReset();
                this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectDataImageListData, jObject);
                this.m_activeProjectDataImageListDataJObject = jObject; //값 적용
            }
            #endregion m_ActiveProjectDataImageListDataJObject File 읽기
        }
        /// <summary>
        /// Project Image Data 초기화
        /// </summary>
        /// <returns>리셋된 Project Image Data jObject</returns>
        private JObject ActiveProjectImageDataReset()
        {
            bool success = Int32.TryParse(m_activeProjectImageListJObject["int_ImageListnumber"].ToString(), out int ImageListnumber);
            //this.m_activeProjectImageListJObject["imageList"];
            int totalNumber = 1;
            JObject jObject = new JObject() { };
            for (int i = 0; i < ImageListnumber; i++)
            {
                JArray imageFiles = (JArray)m_activeProjectImageListJObject["imageList"][i.ToString()];

                if (imageFiles != null)
                {
                    foreach (string imageFile in imageFiles)
                    {
                        object imageInfo = new
                        {
                            int_ImageNumber = totalNumber,
                            string_ImagePath = Path.Combine(this.m_pathActiveProjectImage, imageFile)
                        };

                        JObject imageInfoJObject = new JObject
                        {
                            { imageFile, JObject.FromObject(imageInfo)}
                        };

                        jObject.Merge(imageInfoJObject);
                        totalNumber++;
                    }
                }
            }
            return jObject;
        }

        /// <summary>
        /// 프로젝트 모델 정보 읽어오고 문제가 있으면 초기화
        /// </summary>
        private void ActiveProjectModelInfoRead()
        {
            #region m_ActiveProjectModelInfoJObject File 읽기
            if (this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectModelInfo)) // ImageListData Json 데이터 파일이 있는지 확인
            {
                if ((this.m_activeProjectModelInfoJObject = jsonDataManiger.GetJsonObject(this.m_pathActiveProjectModelInfo)) != null) // Json 파일을 읽을수 있는지 확인
                {
                    // this.m_activeProjectModelInfoJObject 
                    // 읽어온 데이터 처리 가 필요하면 작성
                }
                else // Json 데이터 파일 읽어오기 오류
                {
                    MetroMessageBox.Show(ProjectAI.MainForms.MainForm.GetInstance(), "m_activeProjectModelInfoJObject.Json 데이터 읽어오기 오류", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CustomIOMainger.FileRemove(this.m_pathActiveProjectModelInfo); // 오류난 파일 삭제
                    CustomIOMainger.FileIODelay(100); // 딜레이

                    this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectModelInfo); // 파일 초기화
                    JObject jObject = new JObject() { };
                    this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectModelInfo, jObject);
                    this.m_activeProjectModelInfoJObject = jObject; //값 적용
                }
            }
            else // Json 데이터 파일이 없음. 
            {
                MetroMessageBox.Show(this.MainForm, "m_activeProjectModelInfoJObject.Json 데이터 없음 초기화", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectModelInfo); // 파일 초기화
                JObject jObject = new JObject() { };
                this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectModelInfo, jObject);
                this.m_activeProjectModelInfoJObject = jObject; //값 적용
            }
            #endregion m_ActiveProjectModelInfoJObject File 읽기
        }

        /// <summary>
        /// ActiveProjectInfo.Json 활성화된 프로젝트 내부 딥 러닝 프로젝트 정보 읽어오고 문제가 있으면 초기화
        /// </summary>
        private void ActiveProjectInfoRead()
        {
            #region m_ActiveProjectClassInfoJObject File 읽기
            if (this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectInfo)) // ImageListData Json 데이터 파일이 있는지 확인
            {
                if ((this.m_activeProjectInfoJObject = jsonDataManiger.GetJsonObject(this.m_pathActiveProjectInfo)) != null) // Json 파일을 읽을수 있는지 확인
                {
                    // this.m_calssInfoJObject 
                    // 읽어온 데이터 처리 가 필요하면 작성
                }
                else // Json 데이터 파일 읽어오기 오류
                {
                    MetroMessageBox.Show(this.MainForm, "ActiveProjectInfo.Json 데이터 읽어오기 오류", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CustomIOMainger.FileRemove(this.m_pathActiveProjectInfo); // 오류난 파일 삭제
                    CustomIOMainger.FileIODelay(100); // 딜레이

                    this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectInfo); // 파일 초기화
                    JObject jObject = ActiveProjectInfoReset();
                    this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectInfo, jObject);
                    this.m_activeProjectInfoJObject = jObject; //값 적용
                }
            }
            else // Json 데이터 파일이 없음. 
            {
                MetroMessageBox.Show(this.MainForm, "ActiveProjectInfo.Json 데이터 없음 초기화", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectInfo); // 파일 초기화
                JObject jObject = ActiveProjectInfoReset();
                this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectInfo, jObject);
                this.m_activeProjectInfoJObject = jObject; //값 적용
            }
            #endregion m_ActiveProjectClassInfoJObject File 읽기
        }
        /// <summary>
        /// 활성화된 프로젝트 내부 딥 러닝 프로젝트 정보 초기화
        /// </summary>
        /// <returns></returns>
        private JObject ActiveProjectInfoReset()
        {
            JArray projectList = new JArray() { };
            JObject projectListInfo = new JObject() { };

            JObject activeProjectInfo = new JObject() { };

            activeProjectInfo["array_string_projectList"] = projectList;
            activeProjectInfo["string_projectListInfo"] = projectListInfo;
            activeProjectInfo["int_projectListNumber"] = 0;

            return activeProjectInfo;
        }

        /// <summary>
        /// Class 정보 읽어오고 문제가 있으면 초기화
        /// </summary>
        private void ClassificationInfoRead()
        {
            #region m_calssInfoJObject File 읽기

            if (this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathCalssInfo)) // CalssInfo Json 데이터 파일이 있는지 확인
            {
                if ((this.m_calssInfoJObject = jsonDataManiger.GetJsonObject(this.m_pathCalssInfo)) != null) // Json 파일을 읽을수 있는지 확인
                {
                    // this.m_calssInfoJObject 
                    // 읽어온 데이터 처리 가 필요하면 작성
                }
                else // Json 데이터 파일 읽어오기 오류
                {
                    MetroMessageBox.Show(this.MainForm, "m_calssInfoJObject.Json 데이터 읽어오기 오류", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CustomIOMainger.FileRemove(this.m_pathCalssInfo); // 오류난 파일 삭제
                    CustomIOMainger.FileIODelay(100); // 딜레이

                    this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathCalssInfo); // 파일 초기화
                    JObject jObject = new JObject() { };
                    this.jsonDataManiger.PushJsonObject(this.m_pathCalssInfo, jObject);
                    this.m_calssInfoJObject = jObject; //값 적용
                }
            }
            else // Json 데이터 파일이 없음. 
            {
                MetroMessageBox.Show(this.MainForm, "m_calssInfoJObject.Json 데이터 없음 초기화", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathCalssInfo); // 파일 초기화
                JObject jObject = new JObject() { };
                this.jsonDataManiger.PushJsonObject(this.m_pathCalssInfo, jObject);
                this.m_calssInfoJObject = jObject; //값 적용
            }
            #endregion
        }

        /// <summary>
        /// Idle UI Consrals 셋업, 컴포넌트 정의 과정
        /// </summary>
        private void ActiveProjectIdleContralsSetting()
        {
            #region TrainOption 설정
            this.MainForm.styleExtenderMainForm.SetApplyMetroTheme(this.m_idleTrainOption, true);
            this.m_idleTrainOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_idleTrainOption.Location = new System.Drawing.Point(0, 0);
            this.m_idleTrainOption.Margin = new System.Windows.Forms.Padding(0);
            this.m_idleTrainOption.Padding = new System.Windows.Forms.Padding(20, 20, 10, 20);
            //this.m_idleTrainOption.Name = "sts";
            //this.m_idleTrainOption.TabIndex = 0;
            #endregion TrainOption 설정
        }
        /// <summary>
        /// Classification UI Consrals 셋업, 컴포넌트 정의 과정, Auto scroll 정상 동작함.Dock
        /// </summary>
        private void ActiveProjectClassificationContralsSetting()
        {
            this.MainForm.styleExtenderMainForm.SetApplyMetroTheme(this.m_classificationTrainOption, true);
            this.m_classificationTrainOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_classificationTrainOption.Location = new System.Drawing.Point(0, 0);
            this.m_classificationTrainOption.Margin = new System.Windows.Forms.Padding(0);
            this.m_classificationTrainOption.Padding = new System.Windows.Forms.Padding(20, 20, 10, 20);
        }

        /// <summary>
        /// 초기 UI 적용
        /// </summary>
        public void ProjectIdleUISet()
        {
            this.MainForm.panelTrainOptions.Controls.Add(this.m_idleTrainOption); // panelTrainOptions 패널에 m_idleTrainOption 창 적용

            this.UISetImageNumberInfo(); // 이미지 갯수 정보 UI 적용
            this.UISetImageListInfo(); // 이미지 리스트 정보 UI 적용

            this.UISetActiveProjectInnerProjectInfo(); // 프로젝트 내부 딥 러닝 프로젝트 버튼 셋업
        }

        /// <summary>
        /// 적용된 UI ReSet
        /// </summary>
        public void ProjectUIRemove()
        {
            ProjectIdleUIRemove();
            InnerProjectUIRemove();
        }
        /// <summary>
        /// IdleUI 적용된 부분 삭제
        /// </summary>
        public void ProjectIdleUIRemove()
        {
            this.MainForm.panelTrainOptions.Controls.Clear();
        }
        /// <summary>
        /// InnerProjectUI 적용된 부분 삭제
        /// </summary>
        public void InnerProjectUIRemove()
        {
            this.MainForm.panelProjectInfo.Controls.Clear();
        }


        /// <summary>
        /// 이미지 갯수 정보 UI 적용
        /// </summary>
        public void UISetImageNumberInfo()
        {
            bool success = Int32.TryParse(m_activeProjectImageListJObject["int_ImageListnumber"].ToString(), out int ImageListnumber);
            this.MainForm.iclTotal.ImageCount = this.m_activeProjectImageListJObject["int_imageTotalNumber"].ToString();
            this.MainForm.lblImageListpageTotal.Text = ImageListnumber.ToString();
            // 선택된 프로젝트가 있으면
            if (this.m_activeInnerProjectName != null && this.m_activeInnerProjectName != "AddProject")
            {
                // 선택된 프로젝트 정보 확인
                // 정보 UI에 적용
                this.MainForm.iclLabeled.ImageCount = this.m_activeProjectInfoJObject["string_projectListInfo"][m_activeInnerProjectName]["int_imageLabeledNumber"].ToString();
                this.MainForm.iclTrain.ImageCount = this.m_activeProjectInfoJObject["string_projectListInfo"][m_activeInnerProjectName]["int_imageTrainNumber"].ToString();
                this.MainForm.iclTest.ImageCount = this.m_activeProjectInfoJObject["string_projectListInfo"][m_activeInnerProjectName]["int_imageTrainNumber"].ToString();
            }
        }

        /// <summary>
        /// 이미지 리스트 정보 UI 적용
        /// </summary>
        private void UISetImageListInfo()
        {
            #region gridImageList 값 적용 초기화
            this.MainForm.gridImageList.DataSource = null;
            this.MainForm.gridImageList.Columns.Clear();
            this.MainForm.gridImageList.Rows.Clear();
            this.MainForm.gridImageList.Refresh();

            this.MainForm.gridImageList.ColumnCount = 5;
            this.MainForm.gridImageList.Columns[0].Name = "NO";
            this.MainForm.gridImageList.Columns[1].Name = "Files Name";
            this.MainForm.gridImageList.Columns[2].Name = "Set"; //Train Test
            this.MainForm.gridImageList.Columns[3].Name = "Class";
            this.MainForm.gridImageList.Columns[4].Name = "확률";
            

            bool success = Int32.TryParse(m_activeProjectImageListJObject["int_ImageListnumber"].ToString(), out int ImageListnumber);
            //this.m_activeProjectImageListJObject["imageList"];

            this.UISetImageList(this.imageListPage);
            #endregion gridImageList 값 적용 초기화


            this.MainForm.lblImageListpage.Text = "1";
            this.MainForm.lblImageListpageTotal.Text = ImageListnumber.ToString();
        }
        /// <summary>
        /// 이미지 리스트 페이지 적용 - Data Grid view 타입
        /// </summary>
        private void UISetImageList(int page)
        {
            this.MainForm.gridImageList.Rows.Clear();
            JArray imageFiles = (JArray)m_activeProjectImageListJObject["imageList"][page.ToString()];
            if (imageFiles != null)
            {
                foreach (string imageFile in imageFiles)
                {
                    if (imageFile != null && imageFile != "")
                    {
                        int imageNumber = Convert.ToInt32(this.m_activeProjectDataImageListDataJObject[imageFile]["int_ImageNumber"]);
                        string set = null;
                        string activeClass = null;
                        double threshold = 0.0;

                        if (this.m_activeProjectDataImageListDataJObject[imageFile]["string_DataSet"] != null)
                            set = this.m_activeProjectDataImageListDataJObject[imageFile]["string_DataSet"].ToString();
                        if (this.m_activeProjectDataImageListDataJObject[imageFile]["string_classificationCalss"] != null)
                            activeClass = this.m_activeProjectDataImageListDataJObject[imageFile]["string_classificationCalss"].ToString();
                        if (this.m_activeProjectDataImageListDataJObject[imageFile]["double_threshold"] != null)
                            threshold = Convert.ToDouble(this.m_activeProjectDataImageListDataJObject[imageFile]["double_threshold"]);

                        this.MainForm.gridImageList.Rows.Add(imageNumber, imageFile, set, activeClass, threshold);
                    }
                }
            }
            
        }
        /// <summary>
        /// 이미지 페이지 이동 Forward
        /// </summary>
        /// <returns></returns>
        public int ImageListPageNext()
        {
            int imageListnumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"].ToString());
            if (this.imageListPage < imageListnumber-1)
                this.UISetImageList(++this.imageListPage);
            return imageListPage + 1;
        }
        /// <summary>
        /// 이미지 페이지 이동 Backward
        /// </summary>
        /// <returns></returns>
        public int ImageListPageReverse()
        {
            if (this.imageListPage > 0)
                this.UISetImageList(--this.imageListPage);
            return imageListPage + 1;
        }

        /// <summary>
        /// 프로젝트 내부 딥 러닝 프로젝트 버튼 셋업
        /// </summary>
        public void UISetActiveProjectInnerProjectInfo()
        {
            this.UISetActiveProjectInnerProjectButton("AddProject", "Add Project", MetroColorStyle.Silver);
            foreach (string innerProjectName in this.m_activeProjectInfoJObject["array_string_projectList"])
            {
                string selectProject = this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["string_selectProject"].ToString();
                string selectProjectInputDataType = this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["string_selectProjectInputDataType"].ToString();

                MetroFramework.MetroColorStyle style;
                if (selectProject == "Classification")
                    style = MetroColorStyle.Green;
                else if (selectProject == "Segmentation")
                    style = MetroColorStyle.Red;
                else if (selectProject == "ObjectDetection")
                    style = MetroColorStyle.Blue;
                else
                    style = MetroColorStyle.Yellow;

                this.UISetActiveProjectInnerProjectButton(innerProjectName, selectProject, style);
            }
        }
        /// <summary>
        /// 버튼 셋업
        /// </summary>
        /// <param name="name"> 컴포넌트 이름 </param>
        /// <param name="text"> 출력 Text </param>
        /// <param name="style"> 색 </param>
        public void UISetActiveProjectInnerProjectButton(string name, string text, MetroFramework.MetroColorStyle style)
        {
            MetroFramework.Controls.MetroTile metroTile = new MetroFramework.Controls.MetroTile();

            // 
            // metroTile
            // 
            metroTile.ActiveControl = null;
            metroTile.Dock = System.Windows.Forms.DockStyle.Left;
            metroTile.Location = new System.Drawing.Point(10, 10);
            metroTile.Name = name;
            metroTile.Margin = new System.Windows.Forms.Padding(5);
            metroTile.Size = new System.Drawing.Size(150, 86);
            metroTile.Style = style;
            //metroTile.TabIndex = 2;
            metroTile.Text = text;
            metroTile.UseSelectable = true;
            metroTile.UseStyleColors = true;
            metroTile.Click += new System.EventHandler(this.UISetActiveProjecttInnerProject);

            this.MainForm.panelProjectInfo.Controls.Add(metroTile);
        }
        /// <summary>
        /// 버튼 활성화시 실행 함수 - 프로젝트 UI 뿌려주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UISetActiveProjecttInnerProject(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTile button = (MetroFramework.Controls.MetroTile)sender;
            Console.WriteLine(button.Name);

            if (button.Name == "AddProject")
            {
                this.deeplearningProjectSelectForm.ShowDialog(); // 프로젝트 추가
            }
            else if (this.m_activeProjectInfoJObject["string_projectListInfo"][button.Name]["string_selectProject"].ToString() == "Classification")
            {
                this.ProjectIdleUIRemove(); // IdleUI 삭제
                this.MainForm.panelTrainOptions.Controls.Add(this.m_classificationTrainOption); // panelTrainOptions 패널에 m_classificationTrainOption 창 적용
                this.m_activeInnerProjectName = button.Name; // 활성화된 함수 적용
            }
            else if (this.m_activeProjectInfoJObject["string_projectListInfo"][button.Name]["string_selectProject"].ToString() == "Segmentation")
            {
                this.ProjectIdleUIRemove(); // IdleUI 삭제
                this.m_activeInnerProjectName = button.Name; // 활성화된 함수 적용
            }
            else if (this.m_activeProjectInfoJObject["string_projectListInfo"][button.Name]["string_selectProject"].ToString() == "ObjectDetection")
            {
                this.ProjectIdleUIRemove(); // IdleUI 삭제
                this.m_activeInnerProjectName = button.Name; // 활성화된 함수 적용
            }
        }

        /// <summary>
        /// 이미지 추가
        /// </summary>
        public void ImageAdding()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"\";
                openFileDialog.Filter = "그림 파일 (*.jpg, *.png, *.bmp) | *.jpg; *.png; *.bmp; | 모든 파일 (*.*) | *.*;";
                openFileDialog.Multiselect = true; // 파일 다중 선택

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] files = openFileDialog.SafeFileNames;
                    string[] filesPath = openFileDialog.FileNames;

                    int imageTotalNumber = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectImageListJObject["int_imageTotalNumber"]);
                    int imageListNumber = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectImageListJObject["int_ImageListnumber"]);
                    int imageeListSetNumber = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectImageListJObject["int_imageeListSetnumber"]);

                    JObject imageListJObject = (JObject)WorkSpaceData.m_activeProjectMainger.m_activeProjectImageListJObject["imageList"];

                    JArray imageList = (JArray)imageListJObject[(imageListNumber - 1).ToString()];

                    List<string> imageListList = new List<string>();
                    if (imageList != null)
                    {
                        foreach (string data in imageList)
                        {
                            imageListList.Add(data);
                        } 
                    }

                    imageListList.AddRange(files.ToList());
                    int totalImageListnumber = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(imageListList.Count) / imageeListSetNumber));

                    // image List 값 반영
                    for (int i = 0; i < totalImageListnumber; i++)
                    {
                        List<string> iImageList;

                        try
                        {
                            iImageList = imageListList.GetRange(i * imageeListSetNumber, imageeListSetNumber);
                        }
                        catch
                        {
                            iImageList = imageListList.GetRange(i * imageeListSetNumber, imageListList.Count - i * imageeListSetNumber);
                        }

                        WorkSpaceData.m_activeProjectMainger.m_activeProjectImageListJObject["imageList"][(i + imageListNumber - 1).ToString()] = JArray.FromObject(iImageList.ToArray());
                    }
                    // Image List Data 값 반영
                    for (int i = 0; i < files.Length; i++)
                    {
                        imageTotalNumber++;
                        object imageData = new
                        {
                            int_ImageNumber = imageTotalNumber,
                            string_ImagePath = filesPath[i].ToString()
                        };
                        WorkSpaceData.m_activeProjectMainger.m_activeProjectDataImageListDataJObject[files[i].ToString()] = JObject.FromObject(imageData);
                    }

                    // 변경된 값 반영
                    WorkSpaceData.m_activeProjectMainger.m_activeProjectImageListJObject["int_ImageListnumber"] = (totalImageListnumber + imageListNumber - 1);
                    WorkSpaceData.m_activeProjectMainger.m_activeProjectImageListJObject["int_imageeListSetnumber"] = imageeListSetNumber;
                    WorkSpaceData.m_activeProjectMainger.m_activeProjectImageListJObject["int_imageTotalNumber"] = imageTotalNumber;

                    Console.WriteLine(WorkSpaceData.m_activeProjectMainger.m_activeProjectImageListJObject.ToString());
                    Console.WriteLine(WorkSpaceData.m_activeProjectMainger.m_activeProjectDataImageListDataJObject.ToString());

                    //UI 적용 
                    WorkSpaceData.m_activeProjectMainger.UISetImageNumberInfo(); // 이미지 숫자 적용
                }
            }
        }



        /*
        * m_activeProjectImageListJObject;
        * m_activeProjectDataImageListDataJObject;
        * m_activeProjectModelInfoJObject;
        * m_activeProjectInfoJObject;
        * m_calssInfoJObject;
        */

        public void Test1()
        {

        }
    }
}
