using MetroFramework;
using Newtonsoft.Json.Linq;
using ProjectAI.ProjectManiger;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAI
{
    /// <summary>
    /// Hardware Information (하드웨어 정보)
    /// </summary>
    public struct HardwareInformation
    {
        public static JObject systemHardwareInfoJObject;

        /// <summary>
        /// Hardware Information 하드웨어 정보 가져오기
        /// </summary>
        public static JObject GetHardwareInformation()
        {
            HardwareInformation.systemHardwareInfoJObject = new JObject();

            // OS 정보 얻기
            using (var searcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem"))
            {
                Console.WriteLine("");
                Console.WriteLine("OS 정보 얻기");
                int number = 1;
                JObject infoJObject = new JObject();

                foreach (ManagementObject obj in searcher.Get())
                {
                    Console.WriteLine("Computer Name  -  " + obj["CSName"].ToString());
                    Console.WriteLine("Caption  -  " + obj["Caption"]);
                    Console.WriteLine("Version  -  " + obj["Version"]);
                    Console.WriteLine("BuildNumber  -  " + obj["BuildNumber"]);
                    Console.WriteLine("BuildType  -  " + obj["BuildType"]);
                    Console.WriteLine("OSProductSuite  -  " + obj["OSProductSuite"]);
                    Console.WriteLine("OSArchitecture  -  " + obj["OSArchitecture"]);
                    Console.WriteLine("OSType  -  " + obj["OSType"]);
                    Console.WriteLine("OtherTypeDescription  -  " + obj["OtherTypeDescription"]);
                    Console.WriteLine("ServicePackMajorVersion  -  " + obj["ServicePackMajorVersion"]);

                    JObject jObject = new JObject
                    {
                        ["ComputerName"] = obj["CSName"]?.ToString(),
                        ["Caption"] = obj["Caption"]?.ToString(),
                        ["Version"] = obj["Version"]?.ToString(),
                        ["BuildNumber"] = obj["BuildNumber"]?.ToString(),
                        ["BuildType"] = obj["BuildType"]?.ToString(),
                        ["OSProductSuite"] = obj["OSProductSuite"]?.ToString(),
                        ["OSArchitecture"] = obj["OSArchitecture"]?.ToString(),
                        ["OSType"] = obj["OSType"]?.ToString(),
                        ["OtherTypeDescription"] = obj["OtherTypeDescription"]?.ToString(),
                        ["ServicePackMajorVersion"] = obj["ServicePackMajorVersion"]?.ToString()
                    };
                    infoJObject.Add($"OS_{number}", jObject);
                    number++;
                }
                HardwareInformation.systemHardwareInfoJObject.Add($"OS", infoJObject);
            }

            // Processors 정보 얻기
            using (var searcher = new ManagementObjectSearcher("select * from Win32_ComputerSystem"))
            {
                Console.WriteLine("");
                Console.WriteLine("Processors 정보 얻기");
                int number = 1;
                JObject infoJObject = new JObject();

                foreach (ManagementObject obj in searcher.Get())
                {
                    Console.WriteLine("NumberOfProcessors  -  " + obj["NumberOfProcessors"]);
                    Console.WriteLine("NumberOfLogicalProcessors  -  " + obj["NumberOfLogicalProcessors"]);
                    Console.WriteLine("PCSystemType  -  " + obj["PCSystemType"]);

                    JObject jObject = new JObject()
                    {
                        ["NumberOfProcessors"] = obj["NumberOfProcessors"]?.ToString(),
                        ["NumberOfLogicalProcessors"] = obj["NumberOfLogicalProcessors"]?.ToString(),
                        ["PCSystemType"] = obj["PCSystemType"]?.ToString()
                    };

                    infoJObject.Add($"Processors_{number}", jObject);
                    number++;
                }
                HardwareInformation.systemHardwareInfoJObject[$"Processors"] = infoJObject;
            }

            //CPU 정보 얻기
            using (var searcher = new ManagementObjectSearcher("select * from Win32_Processor"))
            {
                Console.WriteLine("");
                Console.WriteLine("CPU 정보 얻기");
                int number = 1;
                JObject infoJObject = new JObject();

                foreach (ManagementObject obj in searcher.Get())
                {
                    Console.WriteLine("NumberOfLogicalProcessors: {0}", Environment.ProcessorCount);

                    Console.WriteLine("Manufacturer  -  " + obj["Manufacturer"]);
                    Console.WriteLine("Name  -  " + obj["Name"]);
                    Console.WriteLine("Description  -  " + obj["Description"]);
                    Console.WriteLine("ProcessorID  -  " + obj["ProcessorID"]);
                    Console.WriteLine("Architecture  -  " + obj["Architecture"]);
                    Console.WriteLine("AddressWidth  -  " + obj["AddressWidth"]);
                    Console.WriteLine("NumberOfCores  -  " + obj["NumberOfCores"]);
                    Console.WriteLine("DataWidth  -  " + obj["DataWidth"]);
                    Console.WriteLine("Family  -  " + obj["Family"]);

                    JObject jObject = new JObject()
                    {
                        ["Manufacturer"] = obj["Manufacturer"]?.ToString(),
                        ["Name"] = obj["Name"]?.ToString(),
                        ["Description"] = obj["Description"]?.ToString(),
                        ["ProcessorID"] = obj["ProcessorID"]?.ToString(),
                        ["Architecture"] = obj["Architecture"]?.ToString(),
                        ["AddressWidth"] = obj["AddressWidth"]?.ToString(),
                        ["NumberOfCores"] = obj["NumberOfCores"]?.ToString(),
                        ["DataWidth"] = obj["DataWidth"]?.ToString(),
                        ["Family"] = obj["Family"]?.ToString()
                    };
                    infoJObject[$"CPU_{number}"] = jObject;
                    number++;
                }
                HardwareInformation.systemHardwareInfoJObject["CPU"] = infoJObject;
            }

            //GRAPHIC 카드 정보 얻기
            using (var searcher = new ManagementObjectSearcher("select * from Win32_VideoController"))
            {
                Console.WriteLine("");
                Console.WriteLine("GRAPHIC 카드 정보 얻기");
                int number = 1;
                JObject infoJObject = new JObject();
                string ramNVIDIA = null;

                foreach (ManagementObject obj in searcher.Get())
                {
                    string sAdapterRAM = obj["AdapterRAM"]?.ToString();
                    if (obj["Name"].ToString().ToUpper().Contains("NVIDIA"))
                    {
                        ramNVIDIA = String.Format("{0:0.000#}", (float)HardwareInformation.getCudaGpuInfo() / 1024.0F / 1024.0F);
                        sAdapterRAM = ramNVIDIA;
                    }
                    else
                    {
                        if (double.TryParse(sAdapterRAM, out double lAdapterRAM))
                        {
                            sAdapterRAM = CustomIOMainger.FormatBytesGB(lAdapterRAM);
                        }
                    }

                    Console.WriteLine("Name  -  " + obj["Name"]);
                    Console.WriteLine("DeviceID  -  " + obj["DeviceID"]);
                    Console.WriteLine("AdapterRAM  -  " + sAdapterRAM);
                    Console.WriteLine("AdapterDACType  -  " + obj["AdapterDACType"]);
                    Console.WriteLine("Monochrome  -  " + obj["Monochrome"]);
                    Console.WriteLine("InstalledDisplayDrivers  -  " + obj["InstalledDisplayDrivers"]);
                    Console.WriteLine("DriverVersion  -  " + obj["DriverVersion"]);
                    Console.WriteLine("VideoProcessor  -  " + obj["VideoProcessor"]);
                    Console.WriteLine("VideoArchitecture  -  " + obj["VideoArchitecture"]);
                    Console.WriteLine("VideoMemoryType  -  " + obj["VideoMemoryType"]);

                    JObject jObject = new JObject()
                    {
                        ["Name"] = obj["Name"]?.ToString(),
                        ["DeviceID"] = obj["DeviceID"]?.ToString(),
                        ["AdapterRAM"] = sAdapterRAM,
                        ["AdapterDACType"] = obj["AdapterDACType"]?.ToString(),
                        ["Monochrome"] = obj["Monochrome"]?.ToString(),
                        ["InstalledDisplayDrivers"] = obj["InstalledDisplayDrivers"]?.ToString(),
                        ["DriverVersion"] = obj["DriverVersion"]?.ToString(),
                        ["VideoProcessor"] = obj["VideoProcessor"]?.ToString(),
                        ["VideoArchitecture"] = obj["VideoArchitecture"]?.ToString(),
                        ["VideoMemoryType"] = obj["VideoMemoryType"]?.ToString()
                    };
                    infoJObject[$"GRAPHIC_{number}"] = jObject;
                    number++;
                }

                if (ramNVIDIA == null)
                {
                    string messText = "A supported GPU card does not exist. \n An error occurs when using training GPU-related tasks.";
                    ProjectAI.CustomMessageBox.CustomMessageBoxOKCancel customMessageBoxOKCancel = new CustomMessageBox.CustomMessageBoxOKCancel(MessageBoxIcon.Error, messText);
                }

                infoJObject["AdapterRAM"] = ramNVIDIA;
                HardwareInformation.systemHardwareInfoJObject["GRAPHIC"] = infoJObject;
            }

            //메모리 정보 얻기
            using (ManagementObjectSearcher win32CompSys = new ManagementObjectSearcher("select * from Win32_ComputerSystem"))
            {
                Console.WriteLine("");
                Console.WriteLine("//메모리 정보 얻기");
                int number = 1;
                JObject infoJObject = new JObject();
                foreach (ManagementObject obj in win32CompSys.Get())
                {
                    string sTotalphysicalmemory = obj["totalphysicalmemory"]?.ToString();
                    if (double.TryParse(sTotalphysicalmemory, out double lTotalphysicalmemory))
                    {
                        sTotalphysicalmemory = CustomIOMainger.FormatBytesGB(lTotalphysicalmemory);
                    }
                    Console.WriteLine(sTotalphysicalmemory);

                    JObject jObject = new JObject()
                    {
                        ["totalphysicalmemory"] = sTotalphysicalmemory
                    };
                    infoJObject[$"MEMORY_{number}"] = jObject;
                    number++;
                }
                HardwareInformation.systemHardwareInfoJObject[$"MEMORY"] = infoJObject;
            }

            JsonDataManiger jsonDataManiger = JsonDataManiger.GetInstance();
            jsonDataManiger.PushJsonObject(ProgramVariables.m_programHardwareInformation, HardwareInformation.systemHardwareInfoJObject);

            return HardwareInformation.systemHardwareInfoJObject;
        }

        [DllImport("CudaGPUInfo.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int getCudaGpuInfo();
    }

    /// <summary>
    /// Program 시작에 필요한 기본적인 데이터 관리 -> 프로그램 시작시 필요한 중요 데이터, 데이터를 읽어올시 데이터 무결성 검사 필요, 오류시 복원 필요
    /// </summary>
    public struct ProgramEntryPointVariables
    {
        public static string m_programEntryOptionsSpacePath = System.Windows.Forms.Application.StartupPath;
        public static string m_programEntryOptionsFileJsonPath = Path.Combine(ProgramEntryPointVariables.m_programEntryOptionsSpacePath, "EntryOptions.Json");
        public static string m_language;

        /// <summary>
        /// Classification Core 경로
        /// </summary>
        public static string m_prohramClassificationCorePath;

        /// <summary>
        /// Classification Core 경로 기본값
        /// </summary>
        public static string ProhramClassificationCorePathDefalt { get { return Path.Combine(ProgramEntryPointVariables.m_programEntryOptionsSpacePath, "Core", "Classification"); } }
    }

    /// <summary>
    /// StartForm에서 Program의 구동에 필요한 기본적인 데이터 관리 -> StartForm Class 호출단에서 Json파일 읽어서 데이터를 모두 처리해야함.
    /// </summary>
    public struct ProgramVariables
    {
        /// <summary>
        /// 프로그램 ApplicationData 경로 가져오기
        /// </summary>
        private static string m_programApplicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //@"C:\Users\USER\AppData\Roaming"

        /// <summary>
        /// 프로그램 버전
        /// </summary>
        public static string m_programVersion = "0.1";

        /// <summary>
        /// 프로그램 기본 경로
        /// </summary>
        public static string m_programSpacePath = Path.Combine(m_programApplicationDataPath, @"SynapseNet\SynapseNet" + " " + m_programVersion);

        /// <summary>
        /// 프로그램 option 데이터 경로
        /// </summary>
        public static string m_programOptionsSpacePath = Path.Combine(ProgramVariables.m_programSpacePath, "options");

        public static string m_programOptionsFileJsonPath = Path.Combine(ProgramVariables.m_programOptionsSpacePath, "options " + m_programVersion + ".Json");

        public static string m_programHardwareInformation = Path.Combine(ProgramVariables.m_programOptionsSpacePath, "HardwareInformation " + m_programVersion + ".Json");

        /// <summary>
        /// log 경로
        /// </summary>
        public static string m_programlogPath = Path.Combine(ProgramVariables.m_programSpacePath, "log");

        /// <summary>
        /// Gui log 경로
        /// </summary>
        public static string m_programgiulogPath = Path.Combine(ProgramVariables.m_programSpacePath, "guilog");

        /// <summary>
        /// 프로젝트 워크 스페이스 경로
        /// </summary>
        public static string m_programWokrSpacePath;

        // Defalt 값 readonly
        /// <summary>
        /// 프로그램 버전 기본값
        /// </summary>
        public static string ProgramSpacePathDefalt { get { return Path.Combine(ProgramVariables.m_programApplicationDataPath, @"SynapseNet\SynapseNet" + " " + m_programVersion); } }

        /// <summary>
        /// 프로그램 기본 경로 기본값
        /// </summary>
        public static string ProgramOptionsSpacePathDefalt { get { return Path.Combine(ProgramVariables.m_programSpacePath, "options"); } }

        /// <summary>
        /// 프로그램 option 데이터 경로 기본값
        /// </summary>
        public static string ProgramOptionsFileJsonPathDefalt { get { return Path.Combine(ProgramVariables.m_programOptionsSpacePath, "options " + m_programVersion + ".Json"); } }

        /// <summary>
        /// log 경로 기본값
        /// </summary>
        public static string ProgramlogPathDefalt { get { return Path.Combine(ProgramVariables.m_programSpacePath, "log"); } }

        /// <summary>
        /// Gui log 경로 기본값
        /// </summary>
        public static string ProgramgiulogPathDefalt { get { return Path.Combine(ProgramVariables.m_programSpacePath, "guilog"); } }

        /// <summary>
        /// 프로젝트 워크 스페이스 경로 기본값
        /// </summary>
        public static string ProgramWokrSpacePathDefalt { get { return Path.Combine(ProgramVariables.m_programSpacePath, "workspaces"); } }
    }

    /// <summary>
    /// MainForm 시작시 WorkSpace들의 기본적인 데이터 관리 -> MainForm Class 호출단에서 Json파일 읽어서 데이터를 모두 처리해야함.
    /// </summary>
    public struct WorkSpaceEarlyData
    {
        public static Object LockObject = new object();

        /// <summary>
        /// workSpaceEarlyData Jobject 관리
        /// </summary>
        public static JObject workSpaceEarlyDataJobject;

        /// <summary>
        /// Train System Jobject 관리
        /// </summary>
        public static JObject m_trainFormJobject;

        /// <summary>
        /// Program Wokr Space 경로
        /// </summary>
        public static string m_workSpacDataPath = ProgramVariables.m_programWokrSpacePath;

        /// <summary>
        /// ProgramWokr Space Optin File 경로
        /// </summary>
        public static string m_workSpacDataFilePath = Path.Combine(ProgramVariables.m_programWokrSpacePath, "workspacesdata.Json");

        /// <summary>
        /// Train System Json 파일 관리
        /// </summary>
        public static string m_trainFormPath = Path.Combine(ProgramVariables.m_programWokrSpacePath, "TrainSystem.Json");

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
        public static Dictionary<string, MainForms.WorkSpaceButton> m_workSpaceButtons = new Dictionary<string, MainForms.WorkSpaceButton>();

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
        /// 실행중인 WorkSpace 관리 Dictionary
        /// </summary>
        public static Dictionary<string, ProjectContral> m_projectMaingersDictionary = new Dictionary<string, ProjectContral>();

        /// <summary>
        /// 실행중인 WorkSpace
        /// </summary>
        public static ProjectContral m_activeProjectMainger;

        /// <summary>
        /// 실행중진 WorkSpace 저장 유무
        /// </summary>
        public static bool m_workSpaceSave = false;
    }

    /// <summary>
    /// WorkSpace 가 호출되면 호출되는 Class,각 WorkSpace의 데이터 관리
    /// </summary>
    public class ProjectContral
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

        private ProjectAI.MainForms.MainForm mainForm = ProjectAI.MainForms.MainForm.GetInstance();

        #endregion ProjectMainger에 종속된 Forms 정의

        //=== === === === === === === === === === === === === === ===

        #region ProjectMainger에 종속된 UserContral 정의

        /// <summary>
        /// 프로젝트 아이들 상태 유저 컨트롤
        /// </summary>
        public ProjectAI.CustomComponent.MainForms.Idle.IdelTrainOptions m_idleTrainOption = new ProjectAI.CustomComponent.MainForms.Idle.IdelTrainOptions();

        public PictureBox m_idelPictureBox = new PictureBox();

        public ProjectAI.MainForms.UserContral.ImageList.GridViewImageList m_idelGridViewImageList = new MainForms.UserContral.ImageList.GridViewImageList();

        /// <summary>
        /// Classification IdelTrainOptions 관리
        /// </summary>
        public Dictionary<string, ProjectAI.CustomComponent.MainForms.Classification.ClassificationTrainOptions>
            m_classificationTrainOptionDictionary = new Dictionary<string, CustomComponent.MainForms.Classification.ClassificationTrainOptions>();

        /// <summary>
        /// ClassViewer 관리
        /// </summary>
        public Dictionary<string, ProjectAI.MainForms.UserContral.Monitoring.ClassViewer>
            m_classViewerDictionary = new Dictionary<string, MainForms.UserContral.Monitoring.ClassViewer>();

        /// <summary>
        /// 이미지 Viewer 관리
        /// </summary>
        public Dictionary<string, object>
            m_imageViewDictionary = new Dictionary<string, object>();

        /// <summary>
        /// 이미지 List 관리
        /// </summary>
        public Dictionary<string, object>
            m_imageListDictionary = new Dictionary<string, object>();

        #endregion ProjectMainger에 종속된 UserContral 정의

        /// <summary>
        /// MainForma 가져오기
        /// </summary>
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
        /// File IO 등록 Forms
        /// </summary>
        private ProjectAI.ProjectManiger.CustomIOManigerFoem customIOManigerFoem = ProjectAI.ProjectManiger.CustomIOManigerFoem.GetInstance();

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
        /// 활성화된 네임스페이스 내의 활성화된 프로젝트 Task Type 저장 "Classification, Segmentation, ObjectDetection"
        /// </summary>
        public string m_activeInnerProjectTask = null;

        /// <summary>
        /// 활성화된 네임스페이스 내의 활성화된 프로젝트 Input Image Type
        /// </summary>
        public string m_activeInnerProjectInputImageType = null;

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
        /// 활성화된 네임스페이스 실 CAD 이미지 관리 경로
        /// </summary>
        public string m_pathActiveProjectCADImage;

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
        public string m_pathActiveProjectCalssInfo;

        /// <summary>
        /// 활성화된 네임스페이스 Class 프로젝트 정보 관리 자료 자료
        /// </summary>
        public JObject m_activeProjectCalssInfoJObject;

        /// <summary>
        /// 활성화된 네임스페이스 waitingProsecce 폴더 경로
        /// </summary>
        public string m_pathActiveProjectWaitingProcess;

        /// <summary>
        /// 선택한 모델
        /// </summary>
        public string m_avtiveModelsName;

        /// <summary>
        /// 선택한 내부 모델 이름
        /// </summary>
        public string m_avtiveinnerModelsName;

        /// <summary>
        /// 히트맵 이미지 리스트
        /// </summary>
        public string[] m_activeInnerModelsHeatMapImageList;

        /*
         * m_activeProjectImageListJObject;
         * m_activeProjectDataImageListDataJObject;
         * m_activeProjectModelInfoJObject;
         * m_activeProjectInfoJObject;
         * m_activeProjectCalssInfoJObject;
        */

        /// <summary>
        /// Project 에 필요한 폴터 리스트
        /// </summary>
        private readonly List<string> m_projectFolderList = new List<string>();

        /// <summary>
        /// Project 에 필요한 데이터 파일 리스트
        /// </summary>
        private readonly List<string> m_jsonFileList = new List<string>();

        /// <summary>
        /// 이미지 리스트 내의 이미지 갯수 기본값 - Test로 5로 정함 이미 프로젝트에서 정한 값은 몰?루
        /// </summary>
        private readonly int m_imageeListSetnumber = 50;

        /// <summary>
        /// 현제 이미지 페이지
        /// </summary>
        private int imageListPage = 1;

        /// <summary>
        /// 활성화된 WorkSpace 저장 유무
        /// </summary>
        public bool saveWorkSpace = false;

        /// <summary>
        /// 내부 프로젝트 버튼 관리 Dictionary
        /// </summary>
        public Dictionary<string, MetroFramework.Controls.MetroTile> m_activeInnerProjectButton = new Dictionary<string, MetroFramework.Controls.MetroTile>();

        /// <summary>
        /// 이미지 개수 정보 변경시 변경되는 함수 등록
        /// </summary>
        public delegate void ImageNumberChangeDelegate();

        /// <summary>
        /// 이미지 개수 정보 변경시 호출
        /// 이미지 개수 정보 업데이터
        /// </summary>
        public ImageNumberChangeDelegate m_imageNumberChangeUpdater; // 이미지 개수 정보 업데이터

        public delegate void ClassInfoChangeDelegate();

        /// <summary>
        ///  Class 정보 변경시 업데이터
        /// </summary>
        public ClassInfoChangeDelegate m_classInfoChangeUpdater; // Class 정보 변경시 업데이터

        /// <summary>
        /// Logo Panel
        /// </summary>
        public MetroFramework.Controls.MetroPanel panelLogo;

        /// <summary>
        /// CADImage가 OriginImage와 부합되는 이미지만 저장
        /// </summary>
        public List<string> CADImageSaveList = new List<string>();

        //#9
        public System.Collections.ArrayList gridViewAddList = new System.Collections.ArrayList();

        // Declare a Customer object to store data for a row being edited.
        public GridViewDataIntegrity customerInEdit;

        public int rowInEdit = -1;


        /// <summary>
        /// 프로젝트 #Class 처음 진입시
        /// </summary>
        /// <param name="workSpaceName"> 워크 스페이스 이름</param>
        public ProjectContral(string workSpaceName)
        {
            this.m_activeProjectName = workSpaceName;
            Console.WriteLine(workSpaceName);

            this.ActiveProjectIdleContralsSetting(); // Idle UI Consrals 셋업

            this.SaveButoonChacked(); // Save Button 확인

            this.ActiveProjectPathDataInitialization(); // 활성화된 Project 경로 변수 초기화
            this.ActiveProjectEntry(); // 프로젝트 폴더 확인, 문제가 없다면 기존의 데이터 읽어오기

            this.m_imageNumberChangeUpdater += this.UISetImageNumberInfo; // 이미지 개수 변경시 동작 함수 등록

            this.panelLogo = this.UISetLogo(); // Logo 적용.
        } //

        public void Dispose()
        {
            this.deeplearningProjectSelectForm.Dispose();
            this.classEdit.Dispose();
            this.customIOManigerFoem = null;
            this.m_activeProjectName = null;
            this.m_pathActiveProject = null;
            this.m_pathActiveProjectData = null;
            this.m_activeInnerProjectName = null;
            this.m_pathActiveProjectDataImageList = null;
            this.m_activeProjectImageListJObject = null;
            this.m_pathActiveProjectDataImageListData = null;
            this.m_activeProjectDataImageListDataJObject = null;
            this.m_pathActiveProjectImage = null;
            this.m_pathActiveProjectModel = null;
            this.m_pathActiveProjectModelInfo = null;
            this.m_activeProjectModelInfoJObject = null;
            this.m_pathActiveProjectInfo = null;
            this.m_activeProjectInfoJObject = null;
            this.m_pathActiveProjectCalssInfo = null;
            this.m_activeProjectCalssInfoJObject = null; ;
            this.m_imageNumberChangeUpdater = null;

            GC.SuppressFinalize(this);
        }

        ~ProjectContral()
        {
            this.deeplearningProjectSelectForm.Dispose();
            this.classEdit.Dispose();
            this.customIOManigerFoem = null;
            this.m_activeProjectName = null;
            this.m_pathActiveProject = null;
            this.m_pathActiveProjectData = null;
            this.m_activeInnerProjectName = null;
            this.m_pathActiveProjectDataImageList = null;
            this.m_activeProjectImageListJObject = null;
            this.m_pathActiveProjectDataImageListData = null;
            this.m_activeProjectDataImageListDataJObject = null;
            this.m_pathActiveProjectImage = null;
            this.m_pathActiveProjectModel = null;
            this.m_pathActiveProjectModelInfo = null;
            this.m_activeProjectModelInfoJObject = null;
            this.m_pathActiveProjectInfo = null;
            this.m_activeProjectInfoJObject = null;
            this.m_pathActiveProjectCalssInfo = null;
            this.m_activeProjectCalssInfoJObject = null;
            this.m_imageNumberChangeUpdater = null;
        }

        private void WorkspaceDataReset()
        {
        }

        /// <summary>
        /// 활성화된 Project 경로 변수 초기화
        /// </summary>
        private void ActiveProjectPathDataInitialization()
        {
            this.m_pathActiveProject = Path.Combine(WorkSpaceEarlyData.m_workSpacDataPath, this.m_activeProjectName);

            this.m_pathActiveProjectData = Path.Combine(m_pathActiveProject, "data");

            this.m_pathActiveProjectDataImageList = Path.Combine(this.m_pathActiveProject, "data", "imagelist.Json");
            this.m_pathActiveProjectDataImageListData = Path.Combine(this.m_pathActiveProject, "data", "imageListData.Json");

            this.m_pathActiveProjectImage = Path.Combine(this.m_pathActiveProject, "images");

            this.m_pathActiveProjectCADImage = Path.Combine(this.m_pathActiveProject, "CADimages");

            this.m_pathActiveProjectModel = Path.Combine(this.m_pathActiveProject, "model");
            this.m_pathActiveProjectModelInfo = Path.Combine(this.m_pathActiveProject, "data", "ModelInfo.Json");

            this.m_pathActiveProjectInfo = Path.Combine(this.m_pathActiveProject, "data", "ActiveProjectInfo.Json");

            this.m_pathActiveProjectCalssInfo = Path.Combine(this.m_pathActiveProject, "data", "ClassInfo.Json");

            this.m_pathActiveProjectWaitingProcess = Path.Combine(this.m_pathActiveProject, "waitingProsecce");

            this.m_projectFolderList.Add(this.m_pathActiveProjectData);
            this.m_projectFolderList.Add(this.m_pathActiveProjectModel);
            this.m_projectFolderList.Add(this.m_pathActiveProjectImage);
            this.m_projectFolderList.Add(this.m_pathActiveProjectWaitingProcess);
            this.m_projectFolderList.Add(this.m_pathActiveProjectCADImage);

            this.m_jsonFileList.Add(this.m_pathActiveProjectDataImageList);
            this.m_jsonFileList.Add(this.m_pathActiveProjectDataImageListData);
            this.m_jsonFileList.Add(this.m_pathActiveProjectModelInfo);
            this.m_jsonFileList.Add(this.m_pathActiveProjectInfo);
            this.m_jsonFileList.Add(this.m_pathActiveProjectCalssInfo);
        }

        /// <summary>
        /// 활성화된 워크 스페이스 Json 데이터 저장,
        /// 각 데이터 저장 한번에 처리 하도록 예) 이미지 관련 Json 파일 묶어서 처리
        /// </summary>
        /// <param name="saveCase"> 0: Project 기존 정보 저장 처리 관련, 1: ImageData 관련 저장, 2: Class Info 관련 저장 처리 </param>
        public void JsonDataSave(int saveCase)
        {
            switch (saveCase)
            {
                case 0:
                    jsonDataManiger.PushJsonObject(this.m_pathActiveProjectInfo, this.m_activeProjectInfoJObject);
                    break;

                case 1:
                    jsonDataManiger.PushJsonObject(this.m_pathActiveProjectDataImageList, this.m_activeProjectImageListJObject);
                    jsonDataManiger.PushJsonObject(this.m_pathActiveProjectDataImageListData, this.m_activeProjectDataImageListDataJObject);
                    break;

                case 2:
                    jsonDataManiger.PushJsonObject(this.m_pathActiveProjectCalssInfo, this.m_activeProjectCalssInfoJObject);
                    break;

                case 3:
                    jsonDataManiger.PushJsonObject(this.m_pathActiveProjectModelInfo, this.m_activeProjectModelInfoJObject);
                    break;
            }
        }

        /// <summary>
        /// 저장 상태 확인
        /// </summary>
        public void SaveButoonChacked()
        {
            if (WorkSpaceData.m_workSpaceSave)
                MainForm.tsmProjectAllWorkSpaceSave.Enabled = WorkSpaceData.m_workSpaceSave;
            else
                MainForm.tsmProjectAllWorkSpaceSave.Enabled = WorkSpaceData.m_workSpaceSave;

            if (this.saveWorkSpace)
                MainForm.tsmProjectWorkSpaceSave.Enabled = WorkSpaceData.m_workSpaceSave;
            else
                MainForm.tsmProjectWorkSpaceSave.Enabled = WorkSpaceData.m_workSpaceSave;
        }

        /// <summary>
        /// 저장 활성화
        /// </summary>
        public void SaveEnabled()
        {
            this.saveWorkSpace = true;
            WorkSpaceData.m_workSpaceSave = true;
        }

        #region 각 설정 초기화

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
                iJObject[i.ToString()] = JArray.FromObject(iImageList.ToArray());
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
                            string_ImagePath = Path.Combine(this.m_pathActiveProjectImage, imageFile),
                            Labeled = new JObject() { }
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
                    // this.m_activeProjectCalssInfoJObject
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

            if (this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectCalssInfo)) // CalssInfo Json 데이터 파일이 있는지 확인
            {
                if ((this.m_activeProjectCalssInfoJObject = jsonDataManiger.GetJsonObject(this.m_pathActiveProjectCalssInfo)) != null) // Json 파일을 읽을수 있는지 확인
                {
                    // this.m_activeProjectCalssInfoJObject
                    // 읽어온 데이터 처리 가 필요하면 작성
                }
                else // Json 데이터 파일 읽어오기 오류
                {
                    MetroMessageBox.Show(this.MainForm, "m_activeProjectCalssInfoJObject.Json 데이터 읽어오기 오류", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CustomIOMainger.FileRemove(this.m_pathActiveProjectCalssInfo); // 오류난 파일 삭제
                    CustomIOMainger.FileIODelay(100); // 딜레이

                    this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectCalssInfo); // 파일 초기화
                    JObject jObject = new JObject() { };
                    this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectCalssInfo, jObject);
                    this.m_activeProjectCalssInfoJObject = jObject; //값 적용
                }
            }
            else // Json 데이터 파일이 없음.
            {
                MetroMessageBox.Show(this.MainForm, "m_activeProjectCalssInfoJObject.Json 데이터 없음 초기화", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Form1 form1 = new Form1();
                //form1.SetMessageBox(MetroColorStyle.Red, formsManiger.m_StyleManager.Theme, "ERROR", "Calss Info 데이터 없음 초기화");
                //form1.ShowDialog();

                this.jsonDataManiger.JsonChackFileAndCreate(this.m_pathActiveProjectCalssInfo); // 파일 초기화
                JObject jObject = new JObject() { };
                this.jsonDataManiger.PushJsonObject(this.m_pathActiveProjectCalssInfo, jObject);
                this.m_activeProjectCalssInfoJObject = jObject; //값 적용
            }

            #endregion m_calssInfoJObject File 읽기
        }

        /// <summary>
        /// Image List 설정된 값에 따라서 Reset 하기
        /// </summary>
        public void ResetImageList()
        {
            List<string> imageFileNames = new List<string>();

            // 이미지 이름 모두 가져와서 List 화
            for (int i = 0; i < this.m_activeProjectImageListJObject["imageList"].Count(); i++)
            {
                foreach (string imageName in this.m_activeProjectImageListJObject["imageList"][i.ToString()])
                {
                    if (imageName != null)
                        imageFileNames.Add(imageName);
                }
            }

            // List화 된 이미지 Image List Json 에 잘라서 적용
            int imageListNumber = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(imageFileNames.Count) / this.m_imageeListSetnumber));
            if (imageListNumber == 0)
                imageListNumber++;

            JObject iJObject = new JObject() { };

            for (int i = 0; i < imageListNumber; i++)
            {
                List<string> iImageList = new List<string>();
                try
                {
                    iImageList = imageFileNames.GetRange(i * this.m_imageeListSetnumber, this.m_imageeListSetnumber);
                }
                catch
                {
                    iImageList = imageFileNames.GetRange(i * this.m_imageeListSetnumber, imageFileNames.Count - i * this.m_imageeListSetnumber);
                }
                iJObject[i.ToString()] = JArray.FromObject(iImageList.ToArray());
            }
            this.m_activeProjectImageListJObject["imageList"] = iJObject;

            // Image List Data Number 다시 쓰기
            int number = 1;
            foreach (string imageFileName in imageFileNames)
            {
                this.m_activeProjectDataImageListDataJObject[imageFileName]["int_ImageNumber"] = number++;
            }

            // 이미지 정보 데이터 적용
            this.m_activeProjectImageListJObject["int_imageTotalNumber"] = imageFileNames.Count;
            this.m_activeProjectImageListJObject["int_ImageListnumber"] = imageListNumber;
            this.m_activeProjectImageListJObject["int_imageeListSetnumber"] = this.m_imageeListSetnumber;
        }

        #endregion 각 설정 초기화

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

            #region m_idelPictureBox 설정

            if (this.formsManiger.m_isDarkMode) // 밝은 모드
            {
                this.m_idelPictureBox.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Brightness;
            }
            else // 다크 모드
            {
                this.m_idelPictureBox.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Black;
            }
            this.m_idelPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_idelPictureBox.Location = new System.Drawing.Point(0, 0);
            this.m_idelPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.m_idelPictureBox.Name = "pictureBox1";
            this.m_idelPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.m_idelPictureBox.TabStop = false;

            #endregion m_idelPictureBox 설정
        }

        /// <summary>
        /// Classification UI Consrals 셋업, 컴포넌트 정의 과정, Auto scroll 정상 동작함.Dock
        /// </summary>
        private ProjectAI.CustomComponent.MainForms.Classification.ClassificationTrainOptions ActiveProjectClassificationContralsSetting(ProjectAI.CustomComponent.MainForms.Classification.ClassificationTrainOptions m_classificationTrainOption)
        {
            this.MainForm.styleExtenderMainForm.SetApplyMetroTheme(m_classificationTrainOption, true);
            m_classificationTrainOption.Dock = System.Windows.Forms.DockStyle.Fill;
            m_classificationTrainOption.Location = new System.Drawing.Point(0, 0);
            m_classificationTrainOption.Margin = new System.Windows.Forms.Padding(0);
            m_classificationTrainOption.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            return m_classificationTrainOption;
        }

        /// <summary>
        /// 초기 UI 적용
        /// </summary>
        public void ProjectIdleUISet()
        {
            this.MainForm.panelTrainOptions.Controls.Add(this.m_idleTrainOption); // panelTrainOptions 패널에 m_idleTrainOption 창 적용
            this.MainForm.splitContainerImageAndImageList.Panel1.Controls.Add(this.m_idelPictureBox); // 이미지 픽처 박스 초기 모델 적용
            this.MainForm.splitContainerImageAndImageList.Panel2.Controls.Add(this.m_idelGridViewImageList); // 이미지 픽처 박스 초기 모델 적용

            this.m_imageNumberChangeUpdater(); // 이미지 개수 정보 업데이트
            this.UISetImageListInfo(); // 이미지 리스트 정보 UI 적용

            this.UISetActiveProjectInnerProjectInfo(); // 프로젝트 내부 딥 러닝 프로젝트 버튼 셋업

            //Test
            this.ResetImageList();
        }

        /// <summary>
        /// 블러와서 적용된 UI ReSet -- Project 컴포넌트가 적용된 상태
        /// Project 컴포넌트가 적용된 상태에서만 사용 **아니면 관리 디렉토리 검색 방법을 모두 수정
        /// </summary>
        public void ProjectUIRemove()
        {
            this.ProjectIdleUIRemove(); // UI 초기화
            this.InnerProjectUIRemove(); // 내부 프로젝트 초기화
            this.InnerProjectDataReset(); // 이전에 적용된 모델 관련 데이터 초기화

            this.m_idelGridViewImageList.gridImageList.Rows.Clear();

            this.m_idelGridViewImageList.lblImageListpage.Text = "1";
            this.m_idelGridViewImageList.lblImageListpageTotal.Text = "1";

            this.MainForm.iclTotal.ImageCount = "0";
            this.MainForm.iclLabeled.ImageCount = "0";
            this.MainForm.iclTrain.ImageCount = "0";
            this.MainForm.iclTest.ImageCount = "0";
        }

        /// <summary>
        /// IdleUI 적용된 부분 삭제
        /// </summary>
        public void ProjectIdleUIRemove()
        {
            this.MainForm.panelTrainOptions.Controls.Clear();
            this.MainForm.panelDataReview.Controls.Clear();
            this.MainForm.splitContainerImageAndImageList.Panel1.Controls.Clear();
            this.MainForm.splitContainerImageAndImageList.Panel2.Controls.Clear();
            //#33
        }

        /// <summary>
        /// 이전 Inner Project에서 사용된 Train Model 정보 초기화
        /// </summary>
        private void InnerProjectDataReset()
        {
            this.m_avtiveModelsName = null;
            this.m_avtiveinnerModelsName = null;
            this.m_activeInnerModelsHeatMapImageList = null;
        }


        /// <summary>
        /// InnerProjectUI 적용된 부분 삭제
        /// </summary>
        public void InnerProjectUIRemove()
        {
            this.MainForm.panelProjectInfo.Controls.Clear();
            this.MainForm.panelDataReview.Controls.Clear();
            this.MainForm.splitContainerImageAndImageList.Panel1.Controls.Clear();
            this.MainForm.splitContainerImageAndImageList.Panel2.Controls.Clear();
            //#33
        }

        /// <summary>
        /// 이미지 개수 정보 UI 적용
        /// </summary>
        public void UISetImageNumberInfo()
        {
            bool success = Int32.TryParse(m_activeProjectImageListJObject["int_ImageListnumber"].ToString(), out int ImageListnumber);
            this.MainForm.iclTotal.ImageCount = this.m_activeProjectImageListJObject["int_imageTotalNumber"].ToString();
            this.m_idelGridViewImageList.lblImageListpageTotal.Text = ImageListnumber.ToString();
            this.m_idelGridViewImageList.lblImageListpage.Text = this.imageListPage.ToString();

            // 선택된 프로젝트가 있으면
            if (this.m_activeInnerProjectName != null && this.m_activeInnerProjectName != "AddProject")
            {
                // 선택된 프로젝트 정보 확인
                // 정보 UI에 적용
                this.MainForm.iclLabeled.ImageCount = this.m_activeProjectInfoJObject["string_projectListInfo"][m_activeInnerProjectName]["int_imageLabeledNumber"].ToString();
                this.MainForm.iclTrain.ImageCount = this.m_activeProjectInfoJObject["string_projectListInfo"][m_activeInnerProjectName]["int_imageTrainNumber"].ToString();
                this.MainForm.iclTest.ImageCount = this.m_activeProjectInfoJObject["string_projectListInfo"][m_activeInnerProjectName]["int_imageTestNumber"].ToString();
            }
        }

        /// <summary>
        /// 이미지 리스트 정보 UI 적용
        /// </summary>
        private void UISetImageListInfo()
        {
            #region gridImageList 값 적용 초기화

            #region m_idelGridViewImageList 설정

            this.m_idelGridViewImageList = this.GridViewImageListContralsSetting(this.m_idelGridViewImageList);

            #endregion m_idelGridViewImageList 설정

            Int32.TryParse(m_activeProjectImageListJObject["int_ImageListnumber"].ToString(), out int ImageListnumber);
            //this.m_activeProjectImageListJObject["imageList"];

            // this.UISetImageListDataGridview(this.imageListPage, this.MainForm.gridImageList, this.MainForm.ckbMdataGridViewAutoSize);

            this.UISetImageListDataGridview(this.imageListPage, this.m_idelGridViewImageList.gridImageList, this.m_idelGridViewImageList.ckbMdataGridViewAutoSize);
            //#33

            #endregion gridImageList 값 적용 초기화

            this.m_idelGridViewImageList.lblImageListpage.Text = "1";
            this.m_idelGridViewImageList.lblImageListpageTotal.Text = ImageListnumber.ToString();
        }

        /// <summary>
        /// 이미지 리스트 페이지 적용 - DataGridview 타입
        /// </summary>
        private void UISetImageListDataGridview(int page, MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize)
        {
            try
            {
                metroGrid.Rows.Clear();
                page = page - 1;
                JArray imageFiles = (JArray)m_activeProjectImageListJObject["imageList"][page.ToString()];
                if (imageFiles != null)
                {
                    int i = 0;
                    foreach (string imageFile in imageFiles)
                    {
                        if (imageFile != null && imageFile != "")
                        {
                            int imageNumber = Convert.ToInt32(this.m_activeProjectDataImageListDataJObject[imageFile]["int_ImageNumber"]);
                            string set = null;
                            string activeClass = null;
                            string activeClassColor = null;
                            string predictionClass = null;
                            double threshold = 0.0;

                            if (this.m_activeInnerProjectName != null)
                            {
                                if (this.m_activeProjectDataImageListDataJObject[imageFile]["Labeled"][this.m_activeInnerProjectName] != null)
                                {
                                    if (this.m_activeProjectDataImageListDataJObject[imageFile]["Labeled"][this.m_activeInnerProjectName]["bool_Train"] != null)
                                        if (Convert.ToBoolean(this.m_activeProjectDataImageListDataJObject[imageFile]["Labeled"][this.m_activeInnerProjectName]["bool_Train"]))
                                            set = "Train";

                                    if (this.m_activeProjectDataImageListDataJObject[imageFile]["Labeled"][this.m_activeInnerProjectName]["bool_Test"] != null)
                                        if (Convert.ToBoolean(this.m_activeProjectDataImageListDataJObject[imageFile]["Labeled"][this.m_activeInnerProjectName]["bool_Test"]))
                                            if (set != null)
                                                set += ", Test";
                                            else
                                                set = "Test";

                                    if (this.m_activeProjectDataImageListDataJObject[imageFile]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"] != null)
                                        if (Convert.ToBoolean(this.m_activeProjectDataImageListDataJObject[imageFile]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"]))
                                            if (set != null)
                                                set += ", Validation";
                                            else
                                                set = "Validation";

                                    if (this.m_activeProjectDataImageListDataJObject[imageFile]["Labeled"][this.m_activeInnerProjectName]["string_Label"] != null)
                                    {
                                        activeClass = this.m_activeProjectDataImageListDataJObject[imageFile]["Labeled"][this.m_activeInnerProjectName]["string_Label"].ToString();
                                        activeClassColor = this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][activeClass]["string_classColor"].ToString();
                                    }

                                    if (this.m_activeProjectDataImageListDataJObject[imageFile]["Labeled"][this.m_activeInnerProjectName]["double_threshold"] != null)
                                        threshold = Convert.ToDouble(this.m_activeProjectDataImageListDataJObject[imageFile][this.m_activeInnerProjectName]["Labeled"]["double_threshold"]);
                                }
                            }
                            /*
                            this.MainForm.gridImageList.Columns[0].Name = "NO";
                            this.MainForm.gridImageList.Columns[1].Name = "Files Name";
                            this.MainForm.gridImageList.Columns[2].Name = "Set"; //Train Test
                            this.MainForm.gridImageList.Columns[3].Name = "Class";
                            this.MainForm.gridImageList.Columns[4].Name = "Probability";
                            */

                            //#9 GridView Add
                            metroGrid.Rows.Add(imageNumber, imageFile, set, activeClass, predictionClass, threshold);
                            //ProjectAI.MainForms.UserContral.ImageList.GridViewImageList gridViewImageList =
                            //    (ProjectAI.MainForms.UserContral.ImageList.GridViewImageList)this.m_imageListDictionary[this.m_activeInnerProjectName];
                            //gridViewImageList.GridDataAdd(imageNumber.ToString(), imageFile, set, activeClass, predictionClass, threshold.ToString(), i);
                            //i++;
                            // arraylist input 확인
                            //this.gridViewAddList.Add(new GridViewDataIntegrity(imageNumber, imageFile, set, activeClass, predictionClass, threshold));
                            //GridViewDataIntegrity tmp = null;
                            //tmp = (GridViewDataIntegrity)this.gridViewAddList[i];
                            //Console.WriteLine(tmp.FilesName);
                            if (activeClassColor != null)
                                metroGrid.Rows[metroGrid.RowCount - 1].Cells[3].Style.ForeColor = ColorTranslator.FromHtml(activeClassColor);
                        }
                    }

                }

                int size = 0;
                for (int i = 0; i < metroGrid.Columns.Count; i++)
                {
                    size += metroGrid.Columns[i].Width;
                }
                // Data Grid View Size 조정
                if (ckbMdataGridViewAutoSize.Checked)
                {
                    try
                    {
                        if (this.MainForm.splitContainerImageAndImageList.Width - size > 0)
                            this.MainForm.splitContainerImageAndImageList.SplitterDistance = this.MainForm.splitContainerImageAndImageList.Width - size - 5;
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// 이미지 페이지 이동 Forward
        /// </summary>
        /// <returns></returns>
        public int ImageListPageNext(MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize)
        {
            int imageListnumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"].ToString());
            if (this.imageListPage < imageListnumber)
                this.UISetImageListDataGridview(++this.imageListPage, metroGrid, ckbMdataGridViewAutoSize);
            return imageListPage;
        }

        /// <summary>
        /// 이미지 페이지 이동 Backward
        /// </summary>
        /// <returns></returns>
        public int ImageListPageReverse(MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize)
        {
            if (this.imageListPage > 1)
                this.UISetImageListDataGridview(--this.imageListPage, metroGrid, ckbMdataGridViewAutoSize);
            return imageListPage;
        }

        public int ImageListPageManual(int page, MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize)
        {
            int imageListnumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"].ToString());
            if (page >= 0 && page <= imageListnumber && this.imageListPage != page)
            {
                this.imageListPage = page;
                this.UISetImageListDataGridview(this.imageListPage, metroGrid, ckbMdataGridViewAutoSize);
            }
            return imageListPage;
        }

        /// <summary>
        /// 프로젝트 내부 딥 러닝 프로젝트 버튼 만들기
        /// </summary>
        public void UISetActiveProjectInnerProjectInfo()
        {
            this.MainForm.panelProjectInfo.Controls.Clear();

            if (m_activeInnerProjectButton.ContainsKey("AddProject")) // 해당 Button이 만들어 져있는지 확인
            {
                this.MainForm.panelProjectInfo.Controls.Add(this.m_activeInnerProjectButton["AddProject"]); // 만들어져있는 Button이라면 값 가져오고 Main Fomes에 컨트롤 추가
            }
            else
            {
                this.MainForm.panelProjectInfo.Controls.Add(this.UISetActiveProjectInnerProjectButton("AddProject", "Add Project", MetroColorStyle.Silver)); // 없으면 만들기 -> Main Fomes에 컨트롤 추가
            }

            foreach (string innerProjectName in this.m_activeProjectInfoJObject["array_string_projectList"])
            {
                string selectProject = this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["string_selectProject"].ToString();
                string selectProjectInputDataType = this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["string_selectProjectInputDataType"].ToString();

                MetroFramework.MetroColorStyle style;
                if (selectProject == "Classification")
                    style = MetroColorStyle.Purple;
                else if (selectProject == "Segmentation")
                    style = MetroColorStyle.Red;
                else if (selectProject == "ObjectDetection")
                    style = MetroColorStyle.Blue;
                else
                    style = MetroColorStyle.Yellow;

                if (m_activeInnerProjectButton.ContainsKey(innerProjectName)) // 해당 Button이 만들어 져있는지 확인
                {
                    this.MainForm.panelProjectInfo.Controls.Add(this.m_activeInnerProjectButton[innerProjectName]); // 만들어져있는 Button이라면 값 가져오고 Main Fomes에 컨트롤 추가
                }
                else
                {
                    this.MainForm.panelProjectInfo.Controls.Add(this.UISetActiveProjectInnerProjectButton(innerProjectName, selectProject, style)); // 없으면 만들기 -> Main Fomes에 컨트롤 추가
                }
            }
            this.MainForm.panelProjectInfo.Controls.Add(this.panelLogo); // Logo 추가
        }

        /// <summary>
        /// 내부 딥러닝 프로젝트 버튼 설정 함수
        /// </summary>
        /// <param name="name"> 컴포넌트 이름 </param>
        /// <param name="text"> 출력 Text </param>
        /// <param name="style"> 색 </param>
        public MetroFramework.Controls.MetroTile UISetActiveProjectInnerProjectButton(string name, string text, MetroFramework.MetroColorStyle style)
        {
            MetroFramework.Controls.MetroTile metroTile = new MetroFramework.Controls.MetroTile
            {   // metroTile
                ActiveControl = null,
                Dock = System.Windows.Forms.DockStyle.Left,
                Location = new System.Drawing.Point(10, 10),
                Name = name,
                Margin = new System.Windows.Forms.Padding(5),
                Size = new System.Drawing.Size(110, 86),
                TileTextFontSize = MetroFramework.MetroTileTextSize.Small,
                TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold,
                Style = style,
                //metroTile.TabIndex = 2;
                Text = text,
                UseSelectable = true,
                UseStyleColors = true
            };
            metroTile.Click += new System.EventHandler(this.UISetActiveProjecttInnerProject);

            this.m_activeInnerProjectButton.Add(name, metroTile); // 버튼 관리 Dictionary에 추가
            return metroTile;
        }

        private MetroFramework.Controls.MetroPanel UISetLogo()
        {   // panelMlogo
            MetroFramework.Controls.MetroPanel panelMlogo = new MetroFramework.Controls.MetroPanel();
            if (formsManiger.m_isDarkMode)
            {
                panelMlogo.BackgroundImage = global::ProjectAI.Properties.Resources.logoBX2DeepLearningStudio;
            }
            else
            {
                panelMlogo.BackgroundImage = global::ProjectAI.Properties.Resources.logoBX2DeepLearningStudioW;
            }

            panelMlogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            panelMlogo.Dock = System.Windows.Forms.DockStyle.Right;
            panelMlogo.HorizontalScrollbarBarColor = true;
            panelMlogo.HorizontalScrollbarHighlightOnWheel = false;
            panelMlogo.HorizontalScrollbarSize = 10;
            panelMlogo.Location = new System.Drawing.Point(10, 10);
            panelMlogo.Margin = new System.Windows.Forms.Padding(0);
            panelMlogo.MinimumSize = new System.Drawing.Size(409, 84);
            //panelMlogo.Name = "panelMlogo";
            panelMlogo.Size = new System.Drawing.Size(409, 84);
            //panelMlogo.TabIndex = 2;
            panelMlogo.VerticalScrollbarBarColor = true;
            panelMlogo.VerticalScrollbarHighlightOnWheel = false;
            panelMlogo.VerticalScrollbarSize = 10;
            panelMlogo.BackColor = System.Drawing.Color.Transparent;

            return panelMlogo;
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

            if (this.m_activeInnerProjectName != button.Name) // 기존에 열려있는 프로젝트와 이름이 같은지 확인
            {
                if (button.Name == "AddProject")
                {
                    this.deeplearningProjectSelectForm.ShowDialog(); // 프로젝트 추가
                    this.UISetActiveProjectInnerProjectInfo(); // 프로젝트 내부 딥 러닝 프로젝트 버튼 셋업
                }
                else if (this.m_activeProjectInfoJObject["string_projectListInfo"][button.Name]["string_selectProject"].ToString() == "Classification")
                {
                    this.m_activeInnerProjectName = button.Name; // 활성화된 프로젝트 등록
                    this.m_activeInnerProjectTask = this.m_activeProjectInfoJObject["string_projectListInfo"][button.Name]["string_selectProject"].ToString();
                    this.m_activeInnerProjectInputImageType = this.m_activeProjectInfoJObject["string_projectListInfo"][button.Name]["string_selectProjectInputDataType"].ToString();

                    bool alreadyOpenedProjectClassification = false; // Classification 내부 프로젝트가 실행되고 있는지 확인용 변수
                    bool alreadyOpenedProjectClassViewer = false; // Classification 내부 프로젝트가 실행되고 있는지 확인용 변수
                    bool alreadyOpenedProjectImageViewer = false; // Classification 내부 프로젝트가 실행되고 있는지 확인용 변수
                    bool alreadyOpenedProjectImageList = false; // Classification 내부 프로젝트가 실행되고 있는지 확인용 변수

                    #region panelTrainOptions

                    // panelTrainOptions 설정
                    foreach (string activeInnerProjectName in this.m_classificationTrainOptionDictionary.Keys) // 이미 실행된 내부 프로젝트인지 확인
                        if (activeInnerProjectName != null || activeInnerProjectName != "") // 내부 프로젝트 이름 확인 필터
                            if (activeInnerProjectName == button.Name) // 내부 프로젝트 이름이 이미 실행되어 있는지 확인
                            {
                                alreadyOpenedProjectClassification = true; // 실행되어 있다면 확인용 변수 True로 변경
                                break;
                            }
                    if (!alreadyOpenedProjectClassification) // 처음 실행된 내부 프로젝트 라면
                    {
                        ProjectAI.CustomComponent.MainForms.Classification.ClassificationTrainOptions m_classificationTrainOptionl =
                            new CustomComponent.MainForms.Classification.ClassificationTrainOptions(); // Classification TrainOption 생성
                        m_classificationTrainOptionl = this.ActiveProjectClassificationContralsSetting(m_classificationTrainOptionl); // 생성된 Classification TrainOption 셋업

                        this.m_classInfoChangeUpdater += m_classificationTrainOptionl.UISetupDataReadClassWeightControlReset; // Class 업데이터 등록
                        this.m_imageNumberChangeUpdater += m_classificationTrainOptionl.UISetupTrainNumberUpdataer; // 이미지 개수 변경시 업데이터 등록

                        this.m_classificationTrainOptionDictionary.Add(this.m_activeInnerProjectName, m_classificationTrainOptionl); // 관리 Dictionary에 추가
                    } // 처음 실행된 내부 프로젝트 라면

                    #endregion panelTrainOptions

                    #region panelDataReview

                    // panelDataReview 설정
                    foreach (string activeInnerProjectName in this.m_classViewerDictionary.Keys) // 이미 실행된 내부 프로젝트인지 확인
                        if (activeInnerProjectName != null || activeInnerProjectName != "") // 내부 프로젝트 이름 확인 필터
                            if (activeInnerProjectName == button.Name) // 내부 프로젝트 이름이 이미 실행되어 있는지 확인
                            {
                                alreadyOpenedProjectClassViewer = true; // 실행되어 있다면 확인용 변수 True로 변경
                                break;
                            }
                    if (!alreadyOpenedProjectClassViewer)
                    {
                        ProjectAI.MainForms.UserContral.Monitoring.ClassViewer classViewer = this.UISetClassViewerContralsSetting(); // ClassViewer 생성
                        this.m_classInfoChangeUpdater += classViewer.UpdateClassInfo; // Class 업데이터 등록
                        this.m_classViewerDictionary.Add(this.m_activeInnerProjectName, classViewer); // 관리 Dictionary에 추가
                    }

                    #endregion panelDataReview

                    #region ImageList

                    //foreach ()m_imageListDictionary
                    // Image Lust 설정
                    foreach (string activeInnerProjectName in this.m_imageListDictionary.Keys) // 이미 실행된 내부 프로젝트인지 확인
                        if (activeInnerProjectName != null || activeInnerProjectName != "") // 내부 프로젝트 이름 확인 필터
                            if (activeInnerProjectName == button.Name) // 내부 프로젝트 이름이 이미 실행되어 있는지 확인
                            {
                                alreadyOpenedProjectImageList = true; // 실행되어 있다면 확인용 변수 True로 변경
                                break;
                            }
                    if (!alreadyOpenedProjectImageList)
                    {
                        ProjectAI.MainForms.UserContral.ImageList.GridViewImageList gridViewImageList = new MainForms.UserContral.ImageList.GridViewImageList();
                        gridViewImageList = this.GridViewImageListContralsSetting(gridViewImageList);
                        this.m_imageListDictionary.Add(this.m_activeInnerProjectName, gridViewImageList);
                        WorkSpaceData.m_activeProjectMainger.m_imageNumberChangeUpdater += gridViewImageList.ImageTotalNumberUpdate;
                    }

                    #endregion ImageList

                    #region ImageViewer

                    if (this.m_activeProjectInfoJObject["string_projectListInfo"][button.Name]["string_selectProjectInputDataType"].ToString() == "SingleImage")
                    {
                        Console.WriteLine("Classification");
                        Console.WriteLine("SingleImage");
                        //SingleImage(button.Name); // 바로 아래 region

                        // ImageViewer 설정
                        foreach (string activeInnerProjectName in this.m_imageViewDictionary.Keys) // 이미 실행된 내부 프로젝트인지 확인
                            if (activeInnerProjectName != null || activeInnerProjectName != "") // 내부 프로젝트 이름 확인 필터
                                if (activeInnerProjectName == button.Name) // 내부 프로젝트 이름이 이미 실행되어 있는지 확인
                                {
                                    alreadyOpenedProjectImageViewer = true; // 실행되어 있다면 확인용 변수 True로 변경
                                    break;
                                }
                        if (!alreadyOpenedProjectImageViewer)
                        {
                            ProjectAI.MainForms.UserContral.ImageView.SimpleTwoImageViewer simpleTwoImageViewer = new MainForms.UserContral.ImageView.SimpleTwoImageViewer();
                            simpleTwoImageViewer = this.SimpleTwoImageViewerrContralsSetting(simpleTwoImageViewer);
                            this.m_imageViewDictionary.Add(this.m_activeInnerProjectName, simpleTwoImageViewer);
                        }
                    }
                    else if (this.m_activeProjectInfoJObject["string_projectListInfo"][button.Name]["string_selectProjectInputDataType"].ToString() == "MultiImage")
                    {
                        Console.WriteLine("Classification");
                        Console.WriteLine("MultiImage");

                        // ImageViewer 설정
                        foreach (string activeInnerProjectName in this.m_imageViewDictionary.Keys) // 이미 실행된 내부 프로젝트인지 확인
                            if (activeInnerProjectName != null || activeInnerProjectName != "") // 내부 프로젝트 이름 확인 필터
                                if (activeInnerProjectName == button.Name) // 내부 프로젝트 이름이 이미 실행되어 있는지 확인
                                {
                                    alreadyOpenedProjectImageViewer = true; // 실행되어 있다면 확인용 변수 True로 변경
                                    break;
                                }
                        if (!alreadyOpenedProjectImageViewer)
                        {
                            ProjectAI.MainForms.UserContral.ImageView.SimpleTwoImageViewer simpleTwoImageViewer = new MainForms.UserContral.ImageView.SimpleTwoImageViewer();
                            simpleTwoImageViewer = this.SimpleTwoImageViewerrContralsSetting(simpleTwoImageViewer);
                            this.m_imageViewDictionary.Add(this.m_activeInnerProjectName, simpleTwoImageViewer);
                        }
                    }
                    else if (this.m_activeProjectInfoJObject["string_projectListInfo"][button.Name]["string_selectProjectInputDataType"].ToString().Equals("CADImage"))
                    {
                        Console.WriteLine("Classification");
                        Console.WriteLine("CADImage");
                        int itemNum = 0;
                        // CadImage(button.Name); //바로 아래 region
                        ProjectAI.MainForms.UserContral.ImageList.GridViewImageList gridViewImageList = (ProjectAI.MainForms.UserContral.ImageList.GridViewImageList)this.m_imageListDictionary[this.m_activeInnerProjectName];

                        //cmsMImageListToolKit에서 CAD iamge select Visible = true
                        foreach (var item in gridViewImageList.cmsMImageListToolKit.Items)
                        {
                            if (item.ToString() == "Image CAD Select")
                            {
                                gridViewImageList.cmsMImageListToolKit.Items[itemNum - 1].Visible = true;
                                gridViewImageList.cmsMImageListToolKit.Items[itemNum].Visible = true;
                                gridViewImageList.cmsMImageListToolKit.Items[itemNum + 1].Visible = true;
                            }
                            itemNum++;
                        }
                        // ImageViewer 설정
                        foreach (string activeInnerProjectName in this.m_imageViewDictionary.Keys) // 이미 실행된 내부 프로젝트인지 확인
                            if (activeInnerProjectName != null || activeInnerProjectName != "") // 내부 프로젝트 이름 확인 필터
                                if (activeInnerProjectName == button.Name) // 내부 프로젝트 이름이 이미 실행되어 있는지 확인
                                {
                                    alreadyOpenedProjectImageViewer = true; // 실행되어 있다면 확인용 변수 True로 변경
                                    break;
                                }
                        if (!alreadyOpenedProjectImageViewer)
                        {
                            ProjectAI.MainForms.UserContral.ImageView.CadImageViewer cadImageViewer = new MainForms.UserContral.ImageView.CadImageViewer();
                            cadImageViewer = this.CadImageViewerContralsSetting(cadImageViewer);
                            this.m_imageViewDictionary.Add(this.m_activeInnerProjectName, cadImageViewer);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Classification");
                        Console.WriteLine("NoneImageType");
                        // ImageViewer 설정
                        foreach (string activeInnerProjectName in this.m_imageViewDictionary.Keys) // 이미 실행된 내부 프로젝트인지 확인
                            if (activeInnerProjectName != null || activeInnerProjectName != "") // 내부 프로젝트 이름 확인 필터
                                if (activeInnerProjectName == button.Name) // 내부 프로젝트 이름이 이미 실행되어 있는지 확인
                                {
                                    alreadyOpenedProjectImageViewer = true; // 실행되어 있다면 확인용 변수 True로 변경
                                    break;
                                }
                        if (!alreadyOpenedProjectImageViewer)
                        {
                            ProjectAI.MainForms.UserContral.ImageView.SimpleTwoImageViewer simpleTwoImageViewer = new MainForms.UserContral.ImageView.SimpleTwoImageViewer();
                            simpleTwoImageViewer = this.SimpleTwoImageViewerrContralsSetting(simpleTwoImageViewer);
                            this.m_imageViewDictionary.Add(this.m_activeInnerProjectName, simpleTwoImageViewer);
                        }
                    }

                    #endregion ImageViewer

                    this.ProjectIdleUIRemove(); // IdleUI 삭제 // panelTrainOptions 설정
                    this.InnerProjectDataReset(); // 이전에 적용된 모델 관련 데이터 초기화

                    #region 컨트롤 추가

                    this.MainForm.panelTrainOptions.Controls.Add(this.m_classificationTrainOptionDictionary[this.m_activeInnerProjectName]); // panelTrainOptions 패널에 m_classificationTrainOption 창 적용
                    this.MainForm.panelDataReview.Controls.Add(this.m_classViewerDictionary[this.m_activeInnerProjectName]);// panelDataReview 설정
                    this.MainForm.splitContainerImageAndImageList.Panel1.Controls.Add((System.Windows.Forms.Control)this.m_imageViewDictionary[this.m_activeInnerProjectName]);
                    this.MainForm.splitContainerImageAndImageList.Panel2.Controls.Add((System.Windows.Forms.Control)this.m_imageListDictionary[this.m_activeInnerProjectName]);

                    #endregion 컨트롤 추가

                    this.m_imageNumberChangeUpdater(); // 이미지 개수 정보 업데이트 // 이미지 번호 정보 초기화

                    #region gridImageList 값 적용 초기화

                    if (this.m_imageListDictionary[this.m_activeInnerProjectName] is ProjectAI.MainForms.UserContral.ImageList.GridViewImageList GridViewImageList)
                    {
                        if (this.m_imageListDictionary[this.m_activeInnerProjectName] is ProjectAI.MainForms.UserContral.ImageList.GridViewImageList gridViewImageList)
                        {
                            Int32.TryParse(m_activeProjectImageListJObject["int_ImageListnumber"].ToString(), out int innerImageListnumber);
                            //this.m_activeProjectImageListJObject["imageList"];

                            gridViewImageList.lblImageListpage.Text = this.imageListPage.ToString();
                            gridViewImageList.lblImageListpageTotal.Text = innerImageListnumber.ToString();
                            this.UISetImageListDataGridview(this.imageListPage, gridViewImageList.gridImageList, gridViewImageList.ckbMdataGridViewAutoSize);
                        }
                    }

                    #endregion gridImageList 값 적용 초기화

                    //#33

                    // trainForm 학습 결과 폼
                    TrainForms.TrainForm trainForm = TrainForms.TrainForm.GetInstance();
                    // Model 정보 업데이트
                    trainForm.UpdateModelView();
                }
                else if (this.m_activeProjectInfoJObject["string_projectListInfo"][button.Name]["string_selectProject"].ToString() == "Segmentation")
                {
                    this.m_activeInnerProjectName = button.Name; // 활성화된 함수 적용
                    this.m_activeInnerProjectTask = "Segmentation";

                    this.ProjectIdleUIRemove(); // IdleUI 삭제
                    this.InnerProjectDataReset(); // 이전에 적용된 모델 관련 데이터 초기화
                }
                else if (this.m_activeProjectInfoJObject["string_projectListInfo"][button.Name]["string_selectProject"].ToString() == "ObjectDetection")
                {
                    this.m_activeInnerProjectName = button.Name; // 활성화된 함수 적용
                    this.m_activeInnerProjectTask = "ObjectDetection";

                    this.ProjectIdleUIRemove(); // IdleUI 삭제
                    this.InnerProjectDataReset(); // 이전에 적용된 모델 관련 데이터 초기화
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        private ProjectAI.MainForms.UserContral.Monitoring.ClassViewer UISetClassViewerContralsSetting()
        {
            ProjectAI.MainForms.UserContral.Monitoring.ClassViewer classViewer = new ProjectAI.MainForms.UserContral.Monitoring.ClassViewer();
            classViewer.Dock = System.Windows.Forms.DockStyle.Top;
            classViewer.Location = new System.Drawing.Point(0, 0);
            classViewer.Margin = new System.Windows.Forms.Padding(0);
            classViewer.Name = "classViewer";
            classViewer.Size = new System.Drawing.Size(300, 193);
            classViewer.TabIndex = 0;
            return classViewer;
        }

        /// <summary>
        /// 수정 중 DataGridView 수정, 이미지 출력 부분 수정
        /// </summary>
        private ProjectAI.MainForms.UserContral.ImageView.SimpleTwoImageViewer SimpleTwoImageViewerrContralsSetting(ProjectAI.MainForms.UserContral.ImageView.SimpleTwoImageViewer simpleTwoImageViewer)
        {
            //this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            //((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            //this.splitContainer1.Panel1.SuspendLayout();
            //this.splitContainer1.Panel2.SuspendLayout();
            //this.splitContainer1.SuspendLayout();
            //this.splitContainerImageAndImageList.Panel1.Controls.Add(this.splitContainer1);
            ////
            //// splitContainer1
            ////
            //this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            //this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            //this.splitContainer1.Name = "splitContainer1";
            ////
            //// splitContainer1.Panel1
            ////
            //this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            ////
            //// splitContainer1.Panel2
            ////
            //this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
            //this.splitContainer1.Panel2Collapsed = true;
            //this.splitContainer1.Size = new System.Drawing.Size(200, 665);
            //this.splitContainer1.SplitterDistance = 25;
            //this.splitContainer1.TabIndex = 4;
            //
            // simpleTwoImageViewer
            //
            simpleTwoImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            simpleTwoImageViewer.Location = new System.Drawing.Point(0, 0);
            simpleTwoImageViewer.Name = "simpleTwoImageViewer1";
            simpleTwoImageViewer.Size = new System.Drawing.Size(200, 665);
            //simpleTwoImageViewer.TabIndex = 5;
            return simpleTwoImageViewer;
        }

        private ProjectAI.MainForms.UserContral.ImageView.CadImageViewer CadImageViewerContralsSetting(ProjectAI.MainForms.UserContral.ImageView.CadImageViewer cadImageViewer)
        {
            //this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            //((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            //this.splitContainer1.Panel1.SuspendLayout();
            //this.splitContainer1.Panel2.SuspendLayout();
            //this.splitContainer1.SuspendLayout();
            //this.splitContainerImageAndImageList.Panel1.Controls.Add(this.splitContainer1);
            ////
            //// splitContainer1
            ////
            //this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            //this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            //this.splitContainer1.Name = "splitContainer1";
            ////
            //// splitContainer1.Panel1
            ////
            //this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            ////
            //// splitContainer1.Panel2
            ////
            //this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
            //this.splitContainer1.Panel2Collapsed = true;
            //this.splitContainer1.Size = new System.Drawing.Size(200, 665);
            //this.splitContainer1.SplitterDistance = 25;
            //this.splitContainer1.TabIndex = 4;
            //
            // simpleTwoImageViewer
            //

            cadImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            cadImageViewer.Location = new System.Drawing.Point(0, 0);
            cadImageViewer.Name = "cadImageViewer1";
            cadImageViewer.Size = new System.Drawing.Size(200, 665);
            //simpleTwoImageViewer.TabIndex = 5;
            return cadImageViewer;
        }

        private ProjectAI.MainForms.UserContral.ImageList.GridViewImageList GridViewImageListContralsSetting(ProjectAI.MainForms.UserContral.ImageList.GridViewImageList gridViewImageList)
        {
            gridViewImageList.gridImageList.Rows.Clear();

            gridViewImageList.gridImageList.DataSource = null;
            gridViewImageList.gridImageList.Columns.Clear();
            gridViewImageList.gridImageList.Rows.Clear();
            gridViewImageList.gridImageList.Refresh();

            gridViewImageList.gridImageList.ColumnCount = 6;
            gridViewImageList.gridImageList.Columns[0].Name = "NO";
            gridViewImageList.gridImageList.Columns[1].Name = "Files Name";
            gridViewImageList.gridImageList.Columns[2].Name = "Set"; //Train Test
            gridViewImageList.gridImageList.Columns[3].Name = "Labeled";
            gridViewImageList.gridImageList.Columns[4].Name = "Prediction";
            gridViewImageList.gridImageList.Columns[5].Name = "Probability";
            //#9
            //DataGridViewTextBoxColumn numberColumn = new DataGridViewTextBoxColumn();
            //numberColumn.HeaderText = "NO";
            //numberColumn.Name = "Num Name";

            //DataGridViewTextBoxColumn filesNameColumn = new DataGridViewTextBoxColumn();
            //filesNameColumn.HeaderText = "Files Name";
            //filesNameColumn.Name = "Files Name";

            //DataGridViewTextBoxColumn setColumn = new DataGridViewTextBoxColumn();
            //setColumn.HeaderText = "Set";
            //setColumn.Name = "Set";

            //DataGridViewTextBoxColumn labeledColumn = new DataGridViewTextBoxColumn();
            //setColumn.HeaderText = "Labeled";
            //setColumn.Name = "Labeled";

            //DataGridViewTextBoxColumn predictionColumn = new DataGridViewTextBoxColumn();
            //setColumn.HeaderText = "Prediction";
            //setColumn.Name = "Prediction";

            //DataGridViewTextBoxColumn probabilityColumn = new DataGridViewTextBoxColumn();
            //setColumn.HeaderText = "Probability";
            //setColumn.Name = "Probability";

            //gridViewImageList.gridImageList.Columns.Add(numberColumn);
            //gridViewImageList.gridImageList.Columns.Add(filesNameColumn);
            //gridViewImageList.gridImageList.Columns.Add(setColumn);
            //gridViewImageList.gridImageList.Columns.Add(labeledColumn);
            //gridViewImageList.gridImageList.Columns.Add(predictionColumn);
            //gridViewImageList.gridImageList.Columns.Add(probabilityColumn);


            gridViewImageList.Dock = System.Windows.Forms.DockStyle.Fill;
            gridViewImageList.Location = new System.Drawing.Point(0, 0);
            return gridViewImageList;
        }

        public void PrintImage(string imageName)
        {
            if (this.m_activeInnerProjectName != null)
            {
                if (this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["string_selectProject"].ToString() == "Classification")
                {
                    if (this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["string_selectProjectInputDataType"].ToString() == "SingleImage")
                    {
                        ProjectAI.MainForms.UserContral.ImageView.SimpleTwoImageViewer imageViewer = (ProjectAI.MainForms.UserContral.ImageView.SimpleTwoImageViewer)this.m_imageViewDictionary[this.m_activeInnerProjectName];
                        string heatMapPath = null;
                        string heatMapImage = null;
                        bool heatMapImageEnable = false;

                        if (this.m_avtiveModelsName != null)
                        {
                            if (this.m_avtiveinnerModelsName != null)
                            {
                                try
                                {
                                    heatMapPath = System.IO.Path.Combine(this.m_pathActiveProjectModel, this.m_activeInnerProjectName, this.m_avtiveModelsName, "heatmap", this.m_avtiveinnerModelsName);
                                    heatMapImage = Array.Find(this.m_activeInnerModelsHeatMapImageList, element => element.Contains(Path.GetFileNameWithoutExtension(imageName)));
                                    //imageViewer.pictureBox2.Image = CustomIOMainger.LoadBitmap(Path.Combine(heatMapPath, heatMapImage));
                                    heatMapImageEnable = true;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                    heatMapImageEnable = false;
                                }
                            }
                        }

                        // 이미지 출력
                        if (heatMapImageEnable && heatMapPath != null && heatMapImage != null)
                        {
                            if (imageViewer.splitContainer1.Panel2Collapsed)
                                imageViewer.splitContainer1.Panel2Collapsed = false;
                            imageViewer.OrignalImageInput(CustomIOMainger.LoadBitmap(Path.Combine(this.m_pathActiveProjectImage, imageName)));
                            imageViewer.HeatmapImageInput(CustomIOMainger.LoadBitmap(Path.Combine(heatMapPath, heatMapImage)));
                        }
                        else
                        {
                            if (!imageViewer.splitContainer1.Panel2Collapsed)
                                imageViewer.splitContainer1.Panel2Collapsed = true;
                            imageViewer.OrignalImageInput(CustomIOMainger.LoadBitmap(Path.Combine(this.m_pathActiveProjectImage, imageName)));
                        }
                    }
                    else if (this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["string_selectProjectInputDataType"].ToString() == "CADImage")
                    {
                        ProjectAI.MainForms.UserContral.ImageView.CadImageViewer imageViewer = (ProjectAI.MainForms.UserContral.ImageView.CadImageViewer)this.m_imageViewDictionary[this.m_activeInnerProjectName];

                        //imageViewer.pictureBox1.Image = CustomIOMainger.LoadBitmap(Path.Combine(this.m_pathActiveProjectImage, imageName));

                        imageViewer.PrintOrignalImage(CustomIOMainger.LoadBitmap(Path.Combine(this.m_pathActiveProjectImage, imageName)));

                        string CADImageFolder = Path.Combine(this.m_pathActiveProjectCADImage, this.m_activeInnerProjectName);

                        if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName] != null)
                        {
                            if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["CADImage"] != null)
                            {
                                string CADImageName = Path.GetFileName(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["CADImage"].ToString());

                                string orignalImagePath = Path.Combine(this.m_pathActiveProjectImage, imageName);
                                string cadImagePath = this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["CADImage"].ToString();

                                Bitmap cadBitmapImage = CustomIOMainger.LoadBitmap(cadImagePath);

                                // imageViewer.OverlayImagePrint(imageName, CADImageName, CADImageFolder);
                                // imageViewer.OverlayImagePrint(imageName, CADImageName, CADImageFolder); // bitmap overlay로 처리 변경
                                // imageViewer.pictureBox2.Image = ProjectAI.ProjectManiger.CustomImageProcess.BitmapImageOverlay24bppRgb(orignaBitmapImagel, cadBitmapImage, 0.8);

                                if (File.Exists(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["CADImage"].ToString()))
                                {
                                    //imageViewer.pictureBox2.Image = CustomIOMainger.LoadBitmap(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["CADImage"].ToString());
                                    imageViewer.PrintCADImage(cadBitmapImage);
                                }
                                imageViewer.PrintOverlayImage();

                                // Heatmap Image 수정
                                try
                                {
                                    if (this.m_avtiveModelsName != null)
                                    {
                                        if (this.m_avtiveinnerModelsName != null)
                                        {
                                            try
                                            {
                                                string heatMapPath = System.IO.Path.Combine(this.m_pathActiveProjectModel, this.m_activeInnerProjectName, this.m_avtiveModelsName, "heatmap", this.m_avtiveinnerModelsName);
                                                string heatMapImage = Array.Find(this.m_activeInnerModelsHeatMapImageList, element => element.Contains(Path.GetFileNameWithoutExtension(imageName)));
                                                //imageViewer.pictureBox2.Image = CustomIOMainger.LoadBitmap(Path.Combine(heatMapPath, heatMapImage));
                                                if (heatMapImage != null)
                                                    imageViewer.PrintHeatmapImage(CustomIOMainger.LoadBitmap(Path.Combine(heatMapPath, heatMapImage)));
                                                else
                                                    imageViewer.PrintHeatmapImage(null);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex);
                                                imageViewer.PrintHeatmapImage(null);
                                            }
                                            finally
                                            {
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                    imageViewer.PrintHeatmapImage(null);
                                }
                                //if (this.CADImageFileCheck(CADImageName, CADImageFolder))
                                //imageViewer.pictureBox2.Image = CustomIOMainger.LoadBitmap(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["CADImage"].ToString());
                            }
                        }
                    }
                }
                else
                {
                    this.m_idelPictureBox.Image = CustomIOMainger.LoadBitmap(Path.Combine(this.m_pathActiveProjectImage, imageName));
                }
            }
            else
            {
                this.m_idelPictureBox.Image = CustomIOMainger.LoadBitmap(Path.Combine(this.m_pathActiveProjectImage, imageName));
            }
        }

        /// <summary>
        /// 활성화된 워크스페이스 이미지 추가
        /// </summary>
        public void ImageFilesAdding(MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize)
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

                    int countNumber = files.Length;
                    List<int> delIndexs = new List<int>();
                    for (int i = 0; i < countNumber; i++)
                    {
                        if (this.m_activeProjectDataImageListDataJObject[files[i].ToString()] != null)
                        {
                            //MetroMessageBox.Show(this.MainForm, "존재하는 이미지 데이터", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            delIndexs.Add(i);
                        }
                    }
                    delIndexs.Reverse(); // List 뒤에서 부터 삭제 => 뒤에서 부터 삭제 해야 인덱스 불일치가 안뜸.
                    // 동일한 이름 데이터 삭제
                    foreach (int delIndex in delIndexs)
                    {
                        files = files.Where(condition => condition != files[delIndex]).ToArray();
                        filesPath = filesPath.Where(condition => condition != filesPath[delIndex]).ToArray();
                    }
                    if (files.Length == 0) // 파일이 없으면
                        return;

                    //this.MainForm.panelstatus.Visible = true;

                    int imageTotalNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageTotalNumber"]);
                    int imageListNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"]);
                    int imageeListSetNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageeListSetnumber"]);

                    JObject imageListJObject = (JObject)this.m_activeProjectImageListJObject["imageList"];

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

                    // Image List Data 값 반영
                    for (int i = 0; i < files.Length; i++)
                    {
                        imageTotalNumber++;
                        object imageData = new
                        {
                            int_ImageNumber = imageTotalNumber,
                            string_ImagePath = Path.Combine(this.m_pathActiveProjectImage, files[i]),
                            Labeled = new JObject() { }
                        };
                        this.m_activeProjectDataImageListDataJObject[files[i].ToString()] = JObject.FromObject(imageData);
                    }

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

                        this.m_activeProjectImageListJObject["imageList"][(i + imageListNumber - 1).ToString()] = JArray.FromObject(iImageList.ToArray());
                    }

                    // File IO Task 등록
                    customIOManigerFoem.CreateFileCopyList(filesPath.ToList(), this.m_pathActiveProjectImage, ProjectManiger.CustomIOManigerFoem.FileCopyListSet.PathToPath,
                                                            MainForm.pgbMfileIOstatus, MainForm.lblMwaorkInNumber, MainForm.lblMtotalNumber, MainForm.lblMIOStatus, MainForm.lblMworkInFileName);

                    // 변경된 값 반영
                    this.m_activeProjectImageListJObject["int_ImageListnumber"] = (totalImageListnumber + imageListNumber - 1);
                    this.m_activeProjectImageListJObject["int_imageeListSetnumber"] = imageeListSetNumber;
                    this.m_activeProjectImageListJObject["int_imageTotalNumber"] = imageTotalNumber;

                    Console.WriteLine(this.m_activeProjectImageListJObject.ToString());
                    Console.WriteLine(this.m_activeProjectDataImageListDataJObject.ToString());

                    //UI 적용
                    this.m_imageNumberChangeUpdater(); // 이미지 개수 정보 업데이트
                    this.UISetImageListDataGridview(this.imageListPage, metroGrid, ckbMdataGridViewAutoSize); // 이미지 Data Grid View UI적용

                    // Json 파일 저장
                    this.JsonDataSave(1);
                    this.JsonDataSave(2);
                    this.JsonDataSave(3);
                }
            }
        }

        public void ImageFilesAddingWizard(MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize)
        {
            this.classEdit.ShowDialog(); // Class Edit 창 띄우기
            DialogResult dialogResult = this.classEdit.selectDialogResult; // 버튼 클릭 결과 가져오기
            if (dialogResult == DialogResult.OK)
            {
                string modifyClassName = this.classEdit.selectClassName;  // 변경되는 Class 이름
                string modifyClassColor = this.classEdit.selectClassColor; // 변경되는 Class 색

                ProjectAI.MainForms.DatasetSelect datasetSelect = new MainForms.DatasetSelect();
                if (datasetSelect.ShowDialog() == DialogResult.OK)
                {
                    string dataSet = datasetSelect.selectDataset; // 선택된 Dataset

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = @"\";
                        openFileDialog.Filter = "그림 파일 (*.jpg, *.png, *.bmp) | *.jpg; *.png; *.bmp; | 모든 파일 (*.*) | *.*;";
                        openFileDialog.Multiselect = true; // 파일 다중 선택

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // 이미지 가져오기
                            string[] files = openFileDialog.SafeFileNames;
                            string[] filesPath = openFileDialog.FileNames;

                            int countNumber = files.Length;
                            List<int> delIndexs = new List<int>();
                            for (int i = 0; i < countNumber; i++)
                            {
                                if (this.m_activeProjectDataImageListDataJObject[files[i].ToString()] != null)
                                {
                                    //MetroMessageBox.Show(this.MainForm, "존제하는 이미지 데이터", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    delIndexs.Add(i);
                                }
                            }
                            delIndexs.Reverse(); // List 뒤에서 부터 삭제 => 뒤에서 부터 삭제 해야 인덱스 불일치가 안뜸.
                                                 // 동일한 이름 데이터 삭제
                            foreach (int delIndex in delIndexs)
                            {
                                files = files.Where(condition => condition != files[delIndex]).ToArray();
                                filesPath = filesPath.Where(condition => condition != filesPath[delIndex]).ToArray();
                            }

                            if (files.Length == 0) // 파일이 없으면
                                return;

                            //this.MainForm.panelstatus.Visible = true;

                            int imageTotalNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageTotalNumber"]);
                            int imageListNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"]);
                            int imageeListSetNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageeListSetnumber"]);

                            JObject imageListJObject = (JObject)this.m_activeProjectImageListJObject["imageList"];

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

                            // Image List Data 값 반영
                            for (int i = 0; i < files.Length; i++)
                            {
                                imageTotalNumber++;
                                object imageData = new
                                {
                                    int_ImageNumber = imageTotalNumber,
                                    string_ImagePath = Path.Combine(this.m_pathActiveProjectImage, files[i]),
                                    Labeled = new JObject() { }
                                };
                                this.m_activeProjectDataImageListDataJObject[files[i].ToString()] = JObject.FromObject(imageData);
                            }

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

                                this.m_activeProjectImageListJObject["imageList"][(i + imageListNumber - 1).ToString()] = JArray.FromObject(iImageList.ToArray());
                            }

                            // File IO Task 등록
                            customIOManigerFoem.CreateFileCopyList(filesPath.ToList(), this.m_pathActiveProjectImage, ProjectManiger.CustomIOManigerFoem.FileCopyListSet.PathToPath,
                                                                    MainForm.pgbMfileIOstatus, MainForm.lblMwaorkInNumber, MainForm.lblMtotalNumber, MainForm.lblMIOStatus, MainForm.lblMworkInFileName);

                            // 변경된 값 반영
                            this.m_activeProjectImageListJObject["int_ImageListnumber"] = (totalImageListnumber + imageListNumber - 1);
                            this.m_activeProjectImageListJObject["int_imageeListSetnumber"] = imageeListSetNumber;
                            this.m_activeProjectImageListJObject["int_imageTotalNumber"] = imageTotalNumber;

                            Console.WriteLine(this.m_activeProjectImageListJObject.ToString());
                            Console.WriteLine(this.m_activeProjectDataImageListDataJObject.ToString());

                            // Dataset 적용
                            if (datasetSelect.selectDataset.Equals("Train"))
                            {
                                this.ImageAddingTrainSet(files.ToList());
                            }
                            else if (datasetSelect.selectDataset.Equals("Test"))
                            {
                                this.ImageAddingTestSet(files.ToList());
                            }

                            // Data Grid View 초기화 조건
                            int imageListnumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"].ToString());
                            if (this.imageListPage == imageListnumber)
                                this.UISetImageListDataGridview(this.imageListPage, metroGrid, ckbMdataGridViewAutoSize);

                            // Label 정보 적용
                            this.ImageAddingLabeling(files.ToList(), modifyClassName);

                            // 5. 변경된 UI 적용
                            this.m_imageNumberChangeUpdater?.Invoke(); // 이미지 개수 정보 업데이트
                                                                       //this.UISetImageListDataGridview(this.imageListPage);
                                                                       // 6. 저장 버튼 활성화
                            this.SaveEnabled(); // 저장 활성화
                            this.SaveButoonChacked(); // 저장 버튼 확인
                            this.m_classInfoChangeUpdater?.Invoke(); // Class 정보 관련 사항 업데이트

                            //UI 적용
                            this.UISetImageListDataGridview(this.imageListPage, metroGrid, ckbMdataGridViewAutoSize); // 이미지 Data Grid View UI적용

                            // Json 파일 저장
                            this.JsonDataSave(0);
                            this.JsonDataSave(1);
                            this.JsonDataSave(2);
                            this.JsonDataSave(3);
                        }
                    }
                }
            }
        }

        public void ImageFolderAddingWizard(MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize)
        {
            this.classEdit.ShowDialog(); // Class Edit 창 띄우기
            DialogResult dialogResult = this.classEdit.selectDialogResult; // 버튼 클릭 결과 가져오기
            if (dialogResult == DialogResult.OK)
            {
                string modifyClassName = this.classEdit.selectClassName;  // 변경되는 Class 이름
                string modifyClassColor = this.classEdit.selectClassColor; // 변경되는 Class 색

                ProjectAI.MainForms.DatasetSelect datasetSelect = new MainForms.DatasetSelect();
                if (datasetSelect.ShowDialog() == DialogResult.OK)
                {
                    string dataSet = datasetSelect.selectDataset; // 선택된 Dataset
                    if (dataSet == null)
                        return;
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = @"\";
                        openFileDialog.Filter = "그림 파일 (*.jpg, *.png, *.bmp) | *.jpg; *.png; *.bmp; | 모든 파일 (*.*) | *.*;";
                        openFileDialog.ValidateNames = false;
                        openFileDialog.CheckFileExists = false;
                        openFileDialog.CheckPathExists = true;
                        openFileDialog.Multiselect = true; // 파일 다중 선택
                        openFileDialog.FileName = "Folder Selection.";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // 이미지 가져오기
                            string[] files = CustomIOMainger.DirFileSerch(System.IO.Path.GetDirectoryName(openFileDialog.FileName), "Name").ToArray();
                            string[] filesPath = CustomIOMainger.DirFileSerch(System.IO.Path.GetDirectoryName(openFileDialog.FileName), "Full").ToArray();

                            int countNumber = files.Length;
                            List<int> delIndexs = new List<int>();
                            for (int i = 0; i < countNumber; i++)
                            {
                                if (this.m_activeProjectDataImageListDataJObject[files[i].ToString()] != null)
                                {
                                    //MetroMessageBox.Show(this.MainForm, "존제하는 이미지 데이터", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    delIndexs.Add(i);
                                }
                            }
                            delIndexs.Reverse(); // List 뒤에서 부터 삭제 => 뒤에서 부터 삭제 해야 인덱스 불일치가 안뜸.
                                                 // 동일한 이름 데이터 삭제
                                                 //foreach (int delIndex in delIndexs)
                                                 //{
                                                 //    files = files.Where(condition => condition != files[delIndex]).ToArray();
                                                 //    filesPath = filesPath.Where(condition => condition != filesPath[delIndex]).ToArray();
                                                 //}

                            //if (files.Length == 0) // 파일이 없으면
                            //    return;

                            //this.MainForm.panelstatus.Visible = true;

                            int imageTotalNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageTotalNumber"]);
                            int imageListNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"]);
                            int imageeListSetNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageeListSetnumber"]);

                            JObject imageListJObject = (JObject)this.m_activeProjectImageListJObject["imageList"];

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

                            // Image List Data 값 반영
                            for (int i = 0; i < files.Length; i++)
                            {
                                imageTotalNumber++;
                                object imageData = new
                                {
                                    int_ImageNumber = imageTotalNumber,
                                    string_ImagePath = Path.Combine(this.m_pathActiveProjectImage, files[i]),
                                    Labeled = new JObject() { }
                                };
                                this.m_activeProjectDataImageListDataJObject[files[i].ToString()] = JObject.FromObject(imageData);
                            }

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

                                this.m_activeProjectImageListJObject["imageList"][(i + imageListNumber - 1).ToString()] = JArray.FromObject(iImageList.ToArray());
                            }

                            // File IO Task 등록
                            customIOManigerFoem.CreateFileCopyList(filesPath.ToList(), this.m_pathActiveProjectImage, ProjectManiger.CustomIOManigerFoem.FileCopyListSet.PathToPath,
                                                                    MainForm.pgbMfileIOstatus, MainForm.lblMwaorkInNumber, MainForm.lblMtotalNumber, MainForm.lblMIOStatus, MainForm.lblMworkInFileName);

                            // 변경된 값 반영
                            this.m_activeProjectImageListJObject["int_ImageListnumber"] = (totalImageListnumber + imageListNumber - 1);
                            this.m_activeProjectImageListJObject["int_imageeListSetnumber"] = imageeListSetNumber;
                            this.m_activeProjectImageListJObject["int_imageTotalNumber"] = imageTotalNumber;

                            //Console.WriteLine(this.m_activeProjectImageListJObject.ToString());
                            //Console.WriteLine(this.m_activeProjectDataImageListDataJObject.ToString());

                            // Dataset 적용
                            if (dataSet.Equals("Train"))
                            {
                                this.ImageAddingTrainSet(files.ToList());
                            }
                            else if (dataSet.Equals("Test"))
                            {
                                this.ImageAddingTestSet(files.ToList());
                            }

                            // Data Grid View 초기화 조건
                            int imageListnumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"].ToString());
                            if (this.imageListPage == imageListnumber)
                                this.UISetImageListDataGridview(this.imageListPage, metroGrid, ckbMdataGridViewAutoSize);

                            // Label 정보 적용
                            this.ImageAddingLabeling(files.ToList(), modifyClassName);

                            // 5. 변경된 UI 적용
                            this.m_imageNumberChangeUpdater?.Invoke(); // 이미지 개수 정보 업데이트
                                                                       //this.UISetImageListDataGridview(this.imageListPage);
                                                                       // 6. 저장 버튼 활성화
                            this.SaveEnabled(); // 저장 활성화
                            this.SaveButoonChacked(); // 저장 버튼 확인
                            this.m_classInfoChangeUpdater?.Invoke(); // Class 정보 관련 사항 업데이트

                            //UI 적용
                            this.UISetImageListDataGridview(this.imageListPage, metroGrid, ckbMdataGridViewAutoSize); // 이미지 Data Grid View UI적용
                            //#33

                            // Json 파일 저장
                            this.JsonDataSave(0);
                            this.JsonDataSave(1);
                            this.JsonDataSave(2);
                            this.JsonDataSave(3);
                        }
                    }
                }
            }
        }

        #region CAD Image 관련 함수

        /// <summary>
        /// CadImageSelect - CAD Image Select 폼을 띄우는 함수
        /// </summary>
        public void CADInitImageForm(MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize)
        {
            ProjectAI.MainForms.CadImageSelect cadImageSelect = new MainForms.CadImageSelect();

            if (cadImageSelect.ShowDialog() == DialogResult.OK)
            {
                this.CADImageAdding(cadImageSelect, metroGrid, ckbMdataGridViewAutoSize);
                this.CADImageViewerPrintImage(cadImageSelect);
            }
            else //Form Cancel
            {
                if (cadImageSelect.pictureBox1.Image != null)
                {
                    cadImageSelect.pictureBox1.Image.Dispose();
                    cadImageSelect.pictureBox1.Image = null;
                }
                if (cadImageSelect.pictureBox2.Image != null)
                {
                    cadImageSelect.pictureBox2.Image.Dispose();
                    cadImageSelect.pictureBox2.Image = null;
                }
                cadImageSelect.Close();
                cadImageSelect.Dispose();
            }
        }

        /// <summary>
        /// CadImageSelect - CAD Image Select 폼을 띄우는 함수
        /// </summary>
        public void CADImageForm(MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize, string imageName)
        {
            ProjectAI.MainForms.CadImageSelect cadImageSelect = new MainForms.CadImageSelect();
            if (this.m_activeProjectDataImageListDataJObject.ToString().Contains(imageName))
            {
                cadImageSelect.pictureBox1.Image = CustomIOMainger.LoadBitmap(Path.Combine(this.m_pathActiveProjectImage, imageName));
                cadImageSelect.imageTempName = imageName;
            }
            if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"].ToString().Contains(this.m_activeInnerProjectName))
                if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName].ToString().Contains("CADImage"))
                    cadImageSelect.pictureBox2.Image = CustomIOMainger.LoadBitmap(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["CADImage"].ToString());
            if (cadImageSelect.ShowDialog() == DialogResult.OK)
            {
                this.CADImageAdding(cadImageSelect, metroGrid, ckbMdataGridViewAutoSize);
                this.CADImageViewerPrintImage(cadImageSelect);
            }
            else //Form Cancel
            {
                if (cadImageSelect.pictureBox1.Image != null)
                {
                    cadImageSelect.pictureBox1.Image.Dispose();
                    cadImageSelect.pictureBox1.Image = null;
                }
                if (cadImageSelect.pictureBox2.Image != null)
                {
                    cadImageSelect.pictureBox2.Image.Dispose();
                    cadImageSelect.pictureBox2.Image = null;
                }
                cadImageSelect.Close();
                cadImageSelect.Dispose();
            }
        }

        /// <summary>
        /// CadImageSelect - CAD Image Select 폼을 띄우는 함수
        /// </summary>
        public void CADMultiImageForm(MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize, string modifyClassName, string dataSet)
        {
            using (ProjectAI.MainForms.CadImageSelect cadImageSelect = new MainForms.CadImageSelect(1))
            {
                cadImageSelect.ShowDialog();
                Console.WriteLine(cadImageSelect.DialogResult);

                if (cadImageSelect.DialogResult == DialogResult.OK)
                {
                    //this.CADMultiImageAdding(cadImageSelect, metroGrid, ckbMdataGridViewAutoSize, modifyClassName, dataSet);
                    this.CADImageManyAdding(cadImageSelect, metroGrid, ckbMdataGridViewAutoSize, modifyClassName, dataSet);
                    this.CADImageViewerPrintImage(cadImageSelect);
                }
                else //Form Cancel
                {
                    if (cadImageSelect.pictureBox1.Image != null)
                    {
                        cadImageSelect.pictureBox1.Image.Dispose();
                        cadImageSelect.pictureBox1.Image = null;
                    }
                    if (cadImageSelect.pictureBox2.Image != null)
                    {
                        cadImageSelect.pictureBox2.Image.Dispose();
                        cadImageSelect.pictureBox2.Image = null;
                    }
                    //cadImageSelect.Close();
                    //cadImageSelect.Dispose();
                }
            }
        }

        /// <summary>
        /// CadImageSelect - CAD Image Select 폼을 띄우는 함수
        /// </summary>
        public void CADImageFolderForm(MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize, string modifyClassName, string dataSet)
        {
            using (ProjectAI.MainForms.CadImageSelect cadImageSelect = new MainForms.CadImageSelect(2))
            {
                cadImageSelect.ShowDialog();
                if (cadImageSelect.DialogResult == DialogResult.OK)
                {
                    this.CADImageManyAdding(cadImageSelect, metroGrid, ckbMdataGridViewAutoSize, modifyClassName, dataSet);
                    this.CADImageViewerPrintImage(cadImageSelect);
                }
                else //Form Cancel
                {
                    if (cadImageSelect.pictureBox1.Image != null)
                    {
                        cadImageSelect.pictureBox1.Image.Dispose();
                        cadImageSelect.pictureBox1.Image = null;
                    }
                    if (cadImageSelect.pictureBox2.Image != null)
                    {
                        cadImageSelect.pictureBox2.Image.Dispose();
                        cadImageSelect.pictureBox2.Image = null;
                    }
                    //cadImageSelect.Close();
                    //cadImageSelect.Dispose();
                }
            }
        }

        /// <summary>
        /// 기본 이미지와 CAD이미지를 선택한 후 OK 누를 때 기본 이미지 정보에 CAD이미지의 PATH를 저장하여 JSON에 저장
        /// </summary>
        public void CADImageAdding(ProjectAI.MainForms.CadImageSelect cadImageSelect, MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize)
        {
            //CADImage 저장 폴더
            CustomIOMainger.DirChackExistsAndCreate(Path.Combine(this.m_pathActiveProjectCADImage, this.m_activeInnerProjectName));

            int CheckIndex = 1; // 같은 이미지가 있는지 확인하는 변수
            JObject labeledDatainnerProjectLabelName = new JObject();
            List<int> delIndexs = new List<int>();
            string[] file = new string[1];
            file[0] = cadImageSelect.imageTempName;

            if (this.m_activeProjectDataImageListDataJObject[file[0].ToString()] != null)
            {
                MetroMessageBox.Show(this.MainForm, "존재하는 이미지 데이터", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckIndex = 0;
            }

            //this.MainForm.panelstatus.Visible = true;
            int imageTotalNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageTotalNumber"]);
            int imageListNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"]);
            int imageListSetNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageeListSetnumber"]);
            JObject imageListJObject = (JObject)this.m_activeProjectImageListJObject["imageList"];
            JArray imageList = (JArray)imageListJObject[(imageListNumber - 1).ToString()];

            List<string> imageListList = new List<string>();
            if (imageList != null)
            {
                foreach (string data in imageList)
                    imageListList.Add(data);
            }

            //OriginImage가 같은 파일명일 때 imageListList.Json에 Write 제한
            if (CheckIndex == 1)
                imageListList.AddRange(file.ToList());

            int totalImageListnumber = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(imageListList.Count) / imageListSetNumber));

            //CADImage를 저장할 폴더 명
            string CADImageFolder = Path.Combine(this.m_pathActiveProjectCADImage, this.m_activeInnerProjectName);

            //CADImage가 저장된 폴더 내의 이미지 이름 확인
            if (this.CADImageNameCheck(cadImageSelect.CADImageName[0], CADImageFolder))
                return;

            //찾은 이미지와 같은 이미지가 존재하지 않을 겨우
            if (CheckIndex > 0)
            {
                // Image List Data 값 반영
                imageTotalNumber++;
                object imageData = new
                {
                    int_ImageNumber = imageTotalNumber,
                    string_ImagePath = Path.Combine(this.m_pathActiveProjectImage, file[0]),
                    Labeled = new JObject() { }
                };
                this.m_activeProjectDataImageListDataJObject[file[0].ToString()] = JObject.FromObject(imageData);

                //Labeled -> 해당 프로젝트 -> CadImage: 1:1 대응되는 CadImage 정보 확인
                labeledDatainnerProjectLabelName = new JObject
                {
                    { "CADImage", Path.Combine(CADImageFolder, cadImageSelect.CADImageName[0]) }
                };

                JObject labeledDatainnerProject = new JObject
                    {
                        { this.m_activeInnerProjectName, labeledDatainnerProjectLabelName}
                    };

                JObject labeledData = (JObject)this.m_activeProjectDataImageListDataJObject[file[0]]["Labeled"];
                labeledData.Merge(labeledDatainnerProject);
            }
            // 같은 이미지가 존재할 경우
            else if (CheckIndex == 0)
            {
                labeledDatainnerProjectLabelName = new JObject
                {
                    { "CADImage", Path.Combine(CADImageFolder, cadImageSelect.CADImageName[0]) }
                };

                JObject labeledDatainnerProject = new JObject
                    {
                        { this.m_activeInnerProjectName, labeledDatainnerProjectLabelName}
                    };

                JObject labeledData = (JObject)this.m_activeProjectDataImageListDataJObject[file[0]]["Labeled"];
                labeledData.Merge(labeledDatainnerProject);
            }
            // image List 값 반영
            for (int i = 0; i < totalImageListnumber; i++)
            {
                List<string> iImageList;

                try
                {
                    iImageList = imageListList.GetRange(i * imageListSetNumber, imageListSetNumber);
                }
                catch
                {
                    iImageList = imageListList.GetRange(i * imageListSetNumber, imageListList.Count - i * imageListSetNumber);
                }
                this.m_activeProjectImageListJObject["imageList"][(i + imageListNumber - 1).ToString()] = JArray.FromObject(iImageList.ToArray());
            }

            // 찾은 이미지와 같은 이미지가 존재하지 않을 겨우
            if (CheckIndex > 0)
            {
                // OriginImage File IO Task 등록
                customIOManigerFoem.CreateFileCopyList(cadImageSelect.OriginImagePath.ToList(), this.m_pathActiveProjectImage, ProjectManiger.CustomIOManigerFoem.FileCopyListSet.PathToPath,
                      MainForm.pgbMfileIOstatus, MainForm.lblMwaorkInNumber, MainForm.lblMtotalNumber, MainForm.lblMIOStatus, MainForm.lblMworkInFileName);

                // CADImage File IO Task 등록
                customIOManigerFoem.CreateFileCopyList(cadImageSelect.CADImagePath.ToList(), Path.Combine(this.m_pathActiveProjectCADImage, this.m_activeInnerProjectName), ProjectManiger.CustomIOManigerFoem.FileCopyListSet.PathToPath,
                      MainForm.pgbMfileIOstatus, MainForm.lblMwaorkInNumber, MainForm.lblMtotalNumber, MainForm.lblMIOStatus, MainForm.lblMworkInFileName);
            }
            else if (CheckIndex == 0) // 같은 이미지가 존재할 경우 CADImage만 저장
            {
                // CADImage File IO Task 등록
                customIOManigerFoem.CreateFileCopyList(cadImageSelect.CADImagePath.ToList(), Path.Combine(this.m_pathActiveProjectCADImage, this.m_activeInnerProjectName), ProjectManiger.CustomIOManigerFoem.FileCopyListSet.PathToPath,
                      MainForm.pgbMfileIOstatus, MainForm.lblMwaorkInNumber, MainForm.lblMtotalNumber, MainForm.lblMIOStatus, MainForm.lblMworkInFileName);
            }
            CustomIOMainger.FileIODelay(20); // 10ms
            // 변경된 값 반영
            this.m_activeProjectImageListJObject["int_ImageListnumber"] = (totalImageListnumber + imageListNumber - 1);
            this.m_activeProjectImageListJObject["int_imageeListSetnumber"] = imageListSetNumber;
            this.m_activeProjectImageListJObject["int_imageTotalNumber"] = imageTotalNumber;

            //Console.WriteLine(this.m_activeProjectImageListJObject.ToString());
            //Console.WriteLine(this.m_activeProjectDataImageListDataJObject.ToString());
            //UI 적용
            this.m_imageNumberChangeUpdater(); // 이미지 개수 정보 업데이트
            this.UISetImageListDataGridview(this.imageListPage, metroGrid, ckbMdataGridViewAutoSize); // 이미지 Data Grid View UI적용

            // Json 파일 저장
            this.JsonDataSave(0);
            this.JsonDataSave(1);
            this.JsonDataSave(2);
            this.JsonDataSave(3);
        }

        #region 임시차단 (CADMultiImageAdding)
        /*
        /// <summary>
        /// 많은 이미지를 선택하고 OK 누를 때 OriginImage와 CADImage가 1:1매칭으로 전부 등록된다. 1:1이 안되면 안되는 채로 OriginImage가 저장
        /// </summary>
        public async void CADMultiImageAdding(ProjectAI.MainForms.CadImageSelect cadImageSelect, MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize, string modifyClassName, string dataSet)
        {
            //#35 UI로 묶여져 있는 변수들을 만들어진 List로 관리해야 함
            //CADImage 저장 폴더
            CustomIOMainger.DirChackExistsAndCreate(Path.Combine(this.m_pathActiveProjectCADImage, this.m_activeInnerProjectName));
            JObject labeledDatainnerProjectLabelName = new JObject();

            //CAD image에 담긴 요소 초기화
            if (CADImageSaveList.Count != 0)
                CADImageSaveList.RemoveAll(x => true);

            int OriginRowsCount = cadImageSelect.OriginGridView.Rows.Count; //Origin Grid의 이미지 개수
            int CADRowsCount = cadImageSelect.CADGridView.Rows.Count; //CAD Grid의 이미지 개수
            string[] files = new string[OriginRowsCount]; // Origin 기준으로 새로 들어온 이미지 관리
            string[] SameFiles = new string[OriginRowsCount]; // Origin 기준으로 이미 Grid에 같은 이름의 이미지가 있을 때 관리
            string[] filesPath = new string[OriginRowsCount]; // Origin 기준으로 새로 들어온 이미지의 FullPath
            string[] CADImagePath = new string[CADRowsCount]; // CAD 기준, 이미지 FullPath

            int maxValue = OriginRowsCount > CADRowsCount ? OriginRowsCount : CADRowsCount;
            for (int i = 0; i < maxValue; i++)
            {
                if (i < OriginRowsCount)
                {
                    files[i] = cadImageSelect.OriginGridView.Rows[i].Cells[1].Value.ToString();
                    filesPath[i] = Path.Combine(cadImageSelect.OriginGridView.Rows[i].Cells[2].Value.ToString(), files[i]);
                    SameFiles[i] = cadImageSelect.OriginGridView.Rows[i].Cells[1].Value.ToString();
                }
                if (i < CADRowsCount)
                    CADImagePath[i] = Path.Combine(cadImageSelect.CADGridView.Rows[i].Cells[2].Value.ToString(), cadImageSelect.CADGridView.Rows[i].Cells[1].Value.ToString());
            }


            int countNumber = files.Length;
            List<int> delIndexs = new List<int>();
            List<int> FileIndexs = new List<int>(); //이름은 있는데 CADImage 매칭이 안된 Image들
            for (int i = 0; i < countNumber; i++)
            {
                if (this.m_activeProjectDataImageListDataJObject[files[i].ToString()] != null)
                {
                    delIndexs.Add(i);
                    //MetroMessageBox.Show(this.MainForm, "존재하는 이미지 데이터", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (this.m_activeProjectDataImageListDataJObject[files[i].ToString()]["Labeled"] != null)
                    {
                        if (this.m_activeProjectDataImageListDataJObject[files[i].ToString()]["Labeled"][this.m_activeInnerProjectName] != null)
                        {
                            if (this.m_activeProjectDataImageListDataJObject[files[i].ToString()]["Labeled"][this.m_activeInnerProjectName]["CADImage"] == null)
                                FileIndexs.Add(i);
                        }
                        else if (this.m_activeProjectDataImageListDataJObject[files[i].ToString()]["Labeled"][this.m_activeInnerProjectName] == null)
                            FileIndexs.Add(i);
                    }
                }
            }
            delIndexs.Reverse(); // List 뒤에서 부터 삭제 => 뒤에서 부터 삭제 해야 인덱스 불일치가 안뜸.
                                 // 동일한 이름 데이터 삭제
            foreach (int delIndex in delIndexs)
            {
                files = files.Where(condition => condition != files[delIndex]).ToArray();
                filesPath = filesPath.Where(condition => condition != filesPath[delIndex]).ToArray();
            }
            int num = FileIndexs.Count;
            string[] newSameFiles = new string[num]; // 이름은 있는데 CADImage 매칭이 안된 Image, Labeled 안에 프로젝트 이름이 없는 Image를 담는 string[]
            int c = -1;
            if (num > 0)
            {
                foreach (int FileIndex in FileIndexs)
                {
                    if (++c < num)
                        newSameFiles[c] = SameFiles[FileIndex]; // 이름은 있는데 CADImage 매칭이 안된 Image, Labeled 안에 프로젝트 이름이 없는 Image를 넣어줌
                }
            }
            if (files.Length == 0 && newSameFiles.Length == 0) // 파일이 없으면
                return;

            int imageTotalNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageTotalNumber"]);
            int imageListNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"]);
            int imageeListSetNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageeListSetnumber"]);

            JObject imageListJObject = (JObject)this.m_activeProjectImageListJObject["imageList"];

            JArray imageList = (JArray)imageListJObject[(imageListNumber - 1).ToString()];

            List<string> imageListList = new List<string>();
            if (imageList != null)
            {
                foreach (string data in imageList)
                {
                    imageListList.Add(data);
                }
            }
            if (!(files.Length == 0))
                imageListList.AddRange(files.ToList());
            int totalImageListnumber = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(imageListList.Count) / imageeListSetNumber));

            //CADImage를 저장할 폴더 명
            string CADImageFolder = Path.Combine(this.m_pathActiveProjectCADImage, this.m_activeInnerProjectName);

            string[] inputFiles1 = new string[files.Length];
            string[] inputFiles2 = new string[newSameFiles.Length];
            for (int i = 0; i < files.Length; i++)
            {
                string[] fileNameSplit = files[i].Split('_');
                string fileName = null;
                for (int j = 0; j < fileNameSplit.Length - 1; j++)
                {
                    if (fileName == null)
                        fileName = fileNameSplit[j];
                    else
                        fileName += "_" + fileNameSplit[j];
                }

                //fileList1[i] = fileName + $".{System.IO.Path.GetExtension(fileList1[i])}"; // 확장자 포함
                inputFiles1[i] = fileName; // 확장자 미 포함
            }
            for (int i = 0; i < newSameFiles.Length; i++)
            {
                string[] fileNameSplit = newSameFiles[i].Split('_');
                string fileName = null;
                for (int j = 0; j < fileNameSplit.Length - 1; j++)
                {
                    if (fileName == null)
                        fileName = fileNameSplit[j];
                    else
                        fileName += "_" + fileNameSplit[j];
                }

                //fileList1[i] = fileName + $".{System.IO.Path.GetExtension(fileList1[i])}"; // 확장자 포함
                inputFiles2[i] = fileName; // 확장자 미 포함
            }

            System.Threading.CancellationTokenSource searchAlgorithmCancellTokenSource = new System.Threading.CancellationTokenSource();
            ProjectAlgorithm.SearchAlgorithmString searchAlgorithmString = new ProjectAlgorithm.SearchAlgorithmString();
            Task<string[]> searchAlgorithmStringTaskFiles = Task.Run(() => searchAlgorithmString.StringArraySearchManager(files, cadImageSelect.CADNameGridList.ToArray(), searchAlgorithmCancellTokenSource.Token));
            Task<string[]> searchAlgorithmStringTaskNewSameFiles = Task.Run(() => searchAlgorithmString.StringArraySearchManager(files, cadImageSelect.CADNameGridList.ToArray(), searchAlgorithmCancellTokenSource.Token));

            if (!mainForm.SafeVisiblePanel(mainForm.panelstatus))
                mainForm.SafeVisiblePanel(mainForm.panelstatus, true);
            mainForm.SafeWriteProgressBar(mainForm.pgbMfileIOstatus, OriginRowsCount, 0);
            mainForm.SafeWriteLabelText(mainForm.lblMwaorkInNumber, "0");
            mainForm.SafeWriteLabelText(mainForm.lblMtotalNumber, OriginRowsCount.ToString());
            mainForm.SafeWriteLabelText(mainForm.lblMIOStatus, "Pogressing");
            mainForm.SafeWriteLabelText(mainForm.lblMworkInFileName, "Image Matching");

            await searchAlgorithmStringTaskFiles;
            string[] searchDataArrayFiles = await searchAlgorithmStringTaskFiles;


            // Image List Data 값 반영
            for (int i = 0; i < files.Length; i++)
            {
                imageTotalNumber++;
                object imageData = new
                {
                    int_ImageNumber = imageTotalNumber,
                    string_ImagePath = Path.Combine(this.m_pathActiveProjectImage, files[i]),
                    Labeled = new JObject() { }
                };
                this.m_activeProjectDataImageListDataJObject[files[i].ToString()] = JObject.FromObject(imageData);
                WriteImageListData(cadImageSelect, labeledDatainnerProjectLabelName, CADImageFolder, files[i], searchDataArrayFiles[i]);
            }

            await searchAlgorithmStringTaskNewSameFiles;
            string[] searchDataArraynewSameFiles = await searchAlgorithmStringTaskNewSameFiles;

            for (int i = 0; i < newSameFiles.Length; i++)
            {
                WriteImageListData(cadImageSelect, labeledDatainnerProjectLabelName, CADImageFolder, newSameFiles[i], searchDataArraynewSameFiles[i]);
            }

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

                this.m_activeProjectImageListJObject["imageList"][(i + imageListNumber - 1).ToString()] = JArray.FromObject(iImageList.ToArray());
            }

            // File IO Task 등록
            customIOManigerFoem.CreateFileCopyList(filesPath.ToList(), this.m_pathActiveProjectImage, ProjectManiger.CustomIOManigerFoem.FileCopyListSet.PathToPath,
                                                    MainForm.pgbMfileIOstatus, MainForm.lblMwaorkInNumber, MainForm.lblMtotalNumber, MainForm.lblMIOStatus, MainForm.lblMworkInFileName);
            customIOManigerFoem.CreateFileCopyList(CADImageSaveList.ToList(), Path.Combine(this.m_pathActiveProjectCADImage, this.m_activeInnerProjectName), ProjectManiger.CustomIOManigerFoem.FileCopyListSet.PathToPath,
                     MainForm.pgbMfileIOstatus, MainForm.lblMwaorkInNumber, MainForm.lblMtotalNumber, MainForm.lblMIOStatus, MainForm.lblMworkInFileName);
            // 변경된 값 반영
            this.m_activeProjectImageListJObject["int_ImageListnumber"] = (totalImageListnumber + imageListNumber - 1);
            this.m_activeProjectImageListJObject["int_imageeListSetnumber"] = imageeListSetNumber;
            this.m_activeProjectImageListJObject["int_imageTotalNumber"] = imageTotalNumber;


            // Dataset 적용
            if (dataSet.Equals("Train"))
            {
                this.ImageAddingTrainSet(files.ToList());
                if (newSameFiles.Length > 0)
                    this.ImageAddingTrainSet(newSameFiles.ToList());
            }
            else if (dataSet.Equals("Test"))
            {
                this.ImageAddingTestSet(files.ToList());
                if (newSameFiles.Length > 0)
                    this.ImageAddingTestSet(newSameFiles.ToList());
            }
            // Data Grid View 초기화 조건
            int imageListnumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"].ToString());
            if (this.imageListPage == imageListnumber)
                this.UISetImageListDataGridview(this.imageListPage, metroGrid, ckbMdataGridViewAutoSize);

            // Label 정보 적용
            this.ImageAddingLabeling(files.ToList(), modifyClassName);
            if (newSameFiles.Length > 0)
                this.ImageAddingLabeling(newSameFiles.ToList(), modifyClassName);
            // 5. 변경된 UI 적용
            this.m_imageNumberChangeUpdater?.Invoke(); // 이미지 개수 정보 업데이트
                                                       //this.UISetImageListDataGridview(this.imageListPage);
                                                       // 6. 저장 버튼 활성화
            this.SaveEnabled(); // 저장 활성화
            this.SaveButoonChacked(); // 저장 버튼 확인
            this.m_classInfoChangeUpdater?.Invoke(); // Class 정보 관련 사항 업데이트

            //UI 적용
            this.UISetImageListDataGridview(this.imageListPage, metroGrid, ckbMdataGridViewAutoSize); // 이미지 Data Grid View UI적용

            // Json 파일 저장
            this.JsonDataSave(0);
            this.JsonDataSave(1);
            this.JsonDataSave(2);
            this.JsonDataSave(3);
        }
        */
        #endregion 임시차단 (CADMultiImageAdding)

        /// <summary>
        /// Folder 내에 있는 이미지를 바로 반영하여 넣어줍니다.
        /// </summary>
        public async void CADImageManyAdding(ProjectAI.MainForms.CadImageSelect cadImageSelect, MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize, string modifyClassName, string dataSet)
        {
            //#35 UI로 묶여져 있는 변수들을 만들어진 List로 관리해야 함
            //CADImage 저장 폴더
            CustomIOMainger.DirChackExistsAndCreate(Path.Combine(this.m_pathActiveProjectCADImage, this.m_activeInnerProjectName));
            JObject labeledDatainnerProjectLabelName = new JObject();

            //CAD image에 담긴 요소 초기화
            if (CADImageSaveList.Count != 0)
                CADImageSaveList.RemoveAll(x => true);

            string[] files = cadImageSelect.OriginImageName.ToArray(); // Origin 기준으로 새로 들어온 이미지 관리
            string[] SameFiles = cadImageSelect.OriginImageName.ToArray(); // Origin 기준으로 이미 Grid에 같은 이름의 이미지가 있을 때 관리
            string[] filesPath = cadImageSelect.OriginImagePath.ToArray(); // Origin 기준으로 새로 들어온 이미지의 FullPath


            int countNumber = files.Length;
            List<int> delIndexs = new List<int>();
            List<int> FileIndexs = new List<int>(); //이름은 있는데 CADImage 매칭이 안된 Image들
            for (int i = 0; i < countNumber; i++)
            {
                if (this.m_activeProjectDataImageListDataJObject[files[i].ToString()] != null)
                {
                    delIndexs.Add(i);
                    //MetroMessageBox.Show(this.MainForm, "존재하는 이미지 데이터", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (this.m_activeProjectDataImageListDataJObject[files[i].ToString()]["Labeled"] != null)
                    {
                        if (this.m_activeProjectDataImageListDataJObject[files[i].ToString()]["Labeled"][this.m_activeInnerProjectName] != null)
                        {
                            if (this.m_activeProjectDataImageListDataJObject[files[i].ToString()]["Labeled"][this.m_activeInnerProjectName]["CADImage"] == null)
                                FileIndexs.Add(i);
                        }
                        else if (this.m_activeProjectDataImageListDataJObject[files[i].ToString()]["Labeled"][this.m_activeInnerProjectName] == null)
                            FileIndexs.Add(i);
                    }
                }
            }
            delIndexs.Reverse(); // List 뒤에서 부터 삭제 => 뒤에서 부터 삭제 해야 인덱스 불일치가 안뜸.
                                 // 동일한 이름 데이터 삭제
            foreach (int delIndex in delIndexs)
            {
                files = files.Where(condition => condition != files[delIndex]).ToArray();
                filesPath = filesPath.Where(condition => condition != filesPath[delIndex]).ToArray();
            }
            int num = FileIndexs.Count;
            string[] newSameFiles = new string[num]; // 이름은 있는데 CADImage 매칭이 안된 Image, Labeled 안에 프로젝트 이름이 없는 Image를 담는 string[]
            int c = -1;
            if (num > 0)
            {
                foreach (int FileIndex in FileIndexs)
                {
                    if (++c < num)
                        newSameFiles[c] = SameFiles[FileIndex]; // 이름은 있는데 CADImage 매칭이 안된 Image, Labeled 안에 프로젝트 이름이 없는 Image를 넣어줌
                }
            }
            if (files.Length == 0 && newSameFiles.Length == 0) // 파일이 없으면
                return;

            int imageTotalNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageTotalNumber"]);
            int imageListNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"]);
            int imageeListSetNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageeListSetnumber"]);

            JObject imageListJObject = (JObject)this.m_activeProjectImageListJObject["imageList"];

            JArray imageList = (JArray)imageListJObject[(imageListNumber - 1).ToString()];

            List<string> imageListList = new List<string>();
            if (imageList != null)
            {
                foreach (string data in imageList)
                {
                    imageListList.Add(data);
                }
            }
            if (!(files.Length == 0))
                imageListList.AddRange(files.ToList());
            int totalImageListnumber = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(imageListList.Count) / imageeListSetNumber));

            //CADImage를 저장할 폴더 명
            string CADImageFolder = Path.Combine(this.m_pathActiveProjectCADImage, this.m_activeInnerProjectName);

            //CADImage가 있는 폴더
            string CADFolder = cadImageSelect.CADGridView.Rows[0].Cells[2].Value.ToString();


            Task<int> CADOkTask = Task.Run(() => JsonImageWrite(cadImageSelect, this.m_pathActiveProjectImage, this.m_activeProjectDataImageListDataJObject, labeledDatainnerProjectLabelName, files, newSameFiles, imageTotalNumber, CADImageFolder));
            await CADOkTask;
            imageTotalNumber = CADOkTask.Result;


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

                this.m_activeProjectImageListJObject["imageList"][(i + imageListNumber - 1).ToString()] = JArray.FromObject(iImageList.ToArray());
            }

            // File IO Task 등록
            customIOManigerFoem.CreateFileCopyList(filesPath.ToList(), this.m_pathActiveProjectImage, ProjectManiger.CustomIOManigerFoem.FileCopyListSet.PathToPath,
                                                    MainForm.pgbMfileIOstatus, MainForm.lblMwaorkInNumber, MainForm.lblMtotalNumber, MainForm.lblMIOStatus, MainForm.lblMworkInFileName);
            customIOManigerFoem.CreateFileCopyList(CADImageSaveList.ToList(), Path.Combine(this.m_pathActiveProjectCADImage, this.m_activeInnerProjectName), ProjectManiger.CustomIOManigerFoem.FileCopyListSet.PathToPath,
                     MainForm.pgbMfileIOstatus, MainForm.lblMwaorkInNumber, MainForm.lblMtotalNumber, MainForm.lblMIOStatus, MainForm.lblMworkInFileName);
            // 변경된 값 반영
            this.m_activeProjectImageListJObject["int_ImageListnumber"] = (totalImageListnumber + imageListNumber - 1);
            this.m_activeProjectImageListJObject["int_imageeListSetnumber"] = imageeListSetNumber;
            this.m_activeProjectImageListJObject["int_imageTotalNumber"] = imageTotalNumber;

            // Dataset 적용
            if (dataSet.Equals("Train"))
            {
                this.ImageAddingTrainSet(files.ToList());
                if (newSameFiles.Length > 0)
                    this.ImageAddingTrainSet(newSameFiles.ToList());
            }
            else if (dataSet.Equals("Test"))
            {
                this.ImageAddingTestSet(files.ToList());
                if (newSameFiles.Length > 0)
                    this.ImageAddingTestSet(newSameFiles.ToList());
            }
            // Data Grid View 초기화 조건
            int imageListnumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"].ToString());
            if (this.imageListPage == imageListnumber)
                this.UISetImageListDataGridview(this.imageListPage, metroGrid, ckbMdataGridViewAutoSize);

            // Label 정보 적용
            this.ImageAddingLabeling(files.ToList(), modifyClassName);
            if (newSameFiles.Length > 0)
                this.ImageAddingLabeling(newSameFiles.ToList(), modifyClassName);
            // 5. 변경된 UI 적용
            this.m_imageNumberChangeUpdater?.Invoke(); // 이미지 개수 정보 업데이트
                                                       //this.UISetImageListDataGridview(this.imageListPage);
                                                       // 6. 저장 버튼 활성화
            this.SaveEnabled(); // 저장 활성화
            this.SaveButoonChacked(); // 저장 버튼 확인
            this.m_classInfoChangeUpdater?.Invoke(); // Class 정보 관련 사항 업데이트

            //UI 적용
            this.UISetImageListDataGridview(this.imageListPage, metroGrid, ckbMdataGridViewAutoSize); // 이미지 Data Grid View UI적용

            // Json 파일 저장
            this.JsonDataSave(0);
            this.JsonDataSave(1);
            this.JsonDataSave(2);
            this.JsonDataSave(3);
        }


        public void WriteImageListData(ProjectAI.MainForms.CadImageSelect cadImageSelect, JObject labeledDatainnerProjectLabelName, string CADImageFolder, string file, string MatchingName)
        {
            if (MatchingName != null)
            {
                CADImageSaveList.Add(Path.Combine(Path.GetDirectoryName(cadImageSelect.CADAddressGridList[0].ToString()), MatchingName));
                labeledDatainnerProjectLabelName = new JObject
                {
                    { "CADImage", Path.Combine(CADImageFolder, MatchingName) }
                };
                JObject labeledDatainnerProject = new JObject
                {
                    { this.m_activeInnerProjectName, labeledDatainnerProjectLabelName}
                };
                JObject labeledData = (JObject)this.m_activeProjectDataImageListDataJObject[file]["Labeled"];
                labeledData.Merge(labeledDatainnerProject);
            }
        }

        /// <summary>
        /// 기존에 있던 CAD Image와 중복 이름일 때 선택지 (덮어쓰기 or 취소)
        /// </summary>
        /// <param name="CADImageName"></param>
        /// <param name="CADImageFolder"></param>
        /// <returns></returns>
        public bool CADImageNameCheck(string CADImageName, string CADImageFolder)
        {
            if (Directory.Exists(CADImageFolder))
            {
                DirectoryInfo di = new DirectoryInfo(CADImageFolder);
                foreach (var item in di.GetFiles())
                {
                    if (CADImageName == item.Name)
                    {
                        if (MetroMessageBox.Show(this.MainForm, "선택한 CAD Image가 다른 폴더의 이미지 파일과 중복된 이름인지 확인하여 넣어주세요.\n선택한 CAD Image가 맞다면 Yes를 눌러주세요. 파일을 덮어씌우시겠습니까?",
                            "CADImages 폴더 내 파일명 중복 메시지.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes) { return false; }
                        else return true;
                    }
                }
            }
            else
            {
                CustomIOMainger.DirChackExistsAndCreate(Path.Combine(this.m_pathActiveProjectCADImage, this.m_activeInnerProjectName));
                DirectoryInfo di = new DirectoryInfo(CADImageFolder);
                foreach (var item in di.GetFiles())
                {
                    if (CADImageName == item.Name)
                    {
                        if (MetroMessageBox.Show(this.MainForm, "선택한 CAD Image가 다른 폴더의 이미지 파일과 중복된 이름인지 확인하여 넣어주세요.\n선택한 CAD Image가 맞다면 Yes를 눌러주세요. 파일을 덮어씌우시겠습니까?",
                            "CADImages 폴더 내 파일명 중복 메시지.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes) { return false; }
                        else return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// MainForm에서 CADImage View할 때 파일의 유무 확인
        /// </summary>
        /// <param name="CADImageName"></param>
        /// <param name="CADImageFolder"></param>
        /// <returns></returns>
        public bool CADImageFileCheck(string CADImageName, string CADImageFolder)
        {
            int exist = 0;
            if (Directory.Exists(CADImageFolder))
            {
                DirectoryInfo di = new DirectoryInfo(CADImageFolder);
                foreach (var item in di.GetFiles())
                {
                    if (CADImageName == item.Name)
                        exist++;
                }
            }
            else
            {
                CustomIOMainger.DirChackExistsAndCreate(Path.Combine(this.m_pathActiveProjectCADImage, this.m_activeInnerProjectName));
                DirectoryInfo di = new DirectoryInfo(CADImageFolder);
                foreach (var item in di.GetFiles())
                {
                    if (CADImageName == item.Name)
                        exist++;
                }
            }
            if (exist == 0)
            {
                return false;
            }
            else if (exist > 0)
                return true;
            return false;
        }

        public void CADImageViewerPrintImage(ProjectAI.MainForms.CadImageSelect cadImageSelect)
        {
            if (this.m_activeInnerProjectName != null)
            {
                if (this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["string_selectProject"].ToString() == "Classification")
                {
                    if (this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["string_selectProjectInputDataType"].ToString() == "CADImage")
                    {
                        ProjectAI.MainForms.UserContral.ImageView.CadImageViewer imageViewer = (ProjectAI.MainForms.UserContral.ImageView.CadImageViewer)this.m_imageViewDictionary[this.m_activeInnerProjectName];

                        string CADImageFolder = Path.Combine(this.m_pathActiveProjectCADImage, this.m_activeInnerProjectName);

                        imageViewer.PrintOrignalImage(CustomIOMainger.LoadBitmap(Path.Combine(this.m_pathActiveProjectImage, cadImageSelect.imageTempName)));
                        imageViewer.PrintCADImage(CustomIOMainger.LoadBitmap(Path.Combine(CADImageFolder, cadImageSelect.CADImageName[0])));
                    }
                }
            }
            else
            {
                this.m_idelPictureBox.Image = CustomIOMainger.LoadBitmap(Path.Combine(this.m_pathActiveProjectImage, cadImageSelect.OriginImageName[0]));
            }
        }

        public void CADImageMultiSelect(MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize)
        {
            this.classEdit.ShowDialog(); // Class Edit 창 띄우기
            DialogResult dialogResult = this.classEdit.selectDialogResult; // 버튼 클릭 결과 가져오기
            if (dialogResult == DialogResult.OK)
            {
                string modifyClassName = this.classEdit.selectClassName;  // 변경되는 Class 이름
                string modifyClassColor = this.classEdit.selectClassColor; // 변경되는 Class 색

                ProjectAI.MainForms.DatasetSelect datasetSelect = new MainForms.DatasetSelect();
                if (datasetSelect.ShowDialog() == DialogResult.OK)
                {
                    string dataSet = datasetSelect.selectDataset; // 선택된 Dataset
                    if (dataSet == null)
                        return;
                    if (this.m_activeInnerProjectName != null)
                        this.CADMultiImageForm(metroGrid, ckbMdataGridViewAutoSize, modifyClassName, dataSet);
                }
            }
        }

        public void CADImageFolderSelect(MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize)
        {
            this.classEdit.ShowDialog(); // Class Edit 창 띄우기
            DialogResult dialogResult = this.classEdit.selectDialogResult; // 버튼 클릭 결과 가져오기
            if (dialogResult == DialogResult.OK)
            {
                string modifyClassName = this.classEdit.selectClassName;  // 변경되는 Class 이름
                string modifyClassColor = this.classEdit.selectClassColor; // 변경되는 Class 색

                ProjectAI.MainForms.DatasetSelect datasetSelect = new MainForms.DatasetSelect();
                if (datasetSelect.ShowDialog() == DialogResult.OK)
                {
                    string dataSet = datasetSelect.selectDataset; // 선택된 Dataset
                    if (dataSet == null)
                        return;
                    if (this.m_activeInnerProjectName != null)
                        this.CADImageFolderForm(metroGrid, ckbMdataGridViewAutoSize, modifyClassName, dataSet);
                }
            }
        }

        #endregion CAD Image 관련 함수

        /// <summary>
        /// 활성화된 워크스페이스 이미지 제거, MetroGrid 타입
        /// </summary>
        /// <param name="metroGrid"> 적용된 이미지 List 관리 컨트롤 </param>
        public void ImageDel(MetroFramework.Controls.MetroGrid metroGrid, MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize)
        {
            List<int> delIndexs = new List<int>();
            List<string> delFileNames = new List<string>();
            List<string> delfilePaths = new List<string>();

            //이미지 제거시 라벨링, 데이터 셋 설정되있는지 확인하고 숫자 조정하기

            // 선택된 이미지 정보 가져오기
            for (int i = 0; i < metroGrid.SelectedRows.Count; i++)
            {
                if (metroGrid.SelectedRows[i].Cells[1].Value != null)
                {
                    string fileName = metroGrid.SelectedRows[i].Cells[1].Value.ToString();

                    delIndexs.Add(metroGrid.SelectedRows[i].Index);
                    delFileNames.Add(fileName);
                    delfilePaths.Add(Path.Combine(this.m_pathActiveProjectImage, fileName));
                }
            }

            delIndexs.Sort();
            delIndexs.Reverse();

            foreach (int delIndex in delIndexs)
            {
                metroGrid.Rows.Remove(metroGrid.Rows[delIndex]);
            }
            // 삭제할 이미지 데이터 추출

            // 삭제할 이미지 List Number 추출
            List<int> delImageNumbers = new List<int>();
            foreach (string delFileName in delFileNames)
            {
                delImageNumbers.Add(Convert.ToInt32(this.m_activeProjectDataImageListDataJObject[delFileName]["int_ImageNumber"])); // 이미지 Number 저장

                JToken imageLabeledData = this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"];

                foreach (JProperty data in imageLabeledData) // 이미지에 젹용된 내부 프로젝트 이름 추출
                {
                    Console.WriteLine("key name : " + data.Name);
                    string innerProjectName = data.Name; // 젹용된 내부 프로젝트 이름

                    // 1. Label 데이터 관현 사항 수정 -> Class Info
                    if (this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["string_Label"] != null)
                    {
                        string labelName = this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["string_Label"].ToString();
                        // ClassInfo -> int_classImageTrainNumber 감소
                        this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageTotalNumber"] =
                            Convert.ToInt32(this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageTotalNumber"]) - 1;
                        // 2-4  Labeled Number Data 관련 사항 수정 -> ActiveProjectInfo
                        this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageLabeledNumber"] =
                            Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageLabeledNumber"]) - 1;

                        if (this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Train"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Train"].ToString(), out bool parseConfirm))
                                if (parseConfirm)// Class Train Number 감소
                                    this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageTrainNumber"] =
                                        Convert.ToInt32(this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageTrainNumber"]) - 1;

                        if (this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Test"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Test"].ToString(), out bool parseConfirm))
                                if (parseConfirm) // Class Test Number 감소
                                    this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageTestNumber"] =
                                        Convert.ToInt32(this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageTestNumber"]) - 1;

                        if (this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Validation"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Validation"].ToString(), out bool parseConfirm))
                                if (parseConfirm) // Class Validation Number 감소
                                    this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageValidationNumber"] =
                                        Convert.ToInt32(this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageValidationNumber"]) - 1;
                    }

                    // 2-1. Train Data 관련 사항 수정 -> ActiveProjectInfo
                    if (this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Train"] != null)
                        if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Train"].ToString(), out bool parseConfirm))
                            if (parseConfirm) // ActivateProjectInco -> int_imageTrainNumber 감소
                                this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageTrainNumber"] =
                                    Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageTrainNumber"]) - 1;
                    // 2-2. Test Data 관련 사항 수정 -> ActiveProjectInfo
                    if (this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Test"] != null)
                        if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Test"].ToString(), out bool parseConfirm))
                            if (parseConfirm) // ActivateProjectInco -> int_imageTrainNumber 감소
                                this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageTestNumber"] =
                                    Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageTestNumber"]) - 1;
                    // 2-3. Validation Data 관련 사항 수정 -> ActiveProjectInfo
                    if (this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Validation"] != null)
                        if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Validation"].ToString(), out bool parseConfirm))
                            if (parseConfirm) // ActivateProjectInco -> int_imageTrainNumber 감소
                                this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageValidationNumber"] =
                                    Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageValidationNumber"]) - 1;
                }
                this.m_activeProjectDataImageListDataJObject.Remove(delFileName); // ImageListData에서 데이터 삭제
            }

            // ImageListJObject에서 데이터 삭제
            int imageTotalNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageTotalNumber"]);
            int imageListNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"]);
            int imageeListSetNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageeListSetnumber"]);

            delImageNumbers.Sort();
            delImageNumbers.Reverse();

            foreach (int delImageNumber in delImageNumbers)
            {
                int delImageListNumber = Convert.ToInt32(System.Math.Truncate(Convert.ToDouble(delImageNumber - 1) / Convert.ToDouble(imageeListSetNumber)));
                Console.WriteLine(this.m_activeProjectImageListJObject["imageList"][delImageListNumber.ToString()][(delImageNumber - 1) % imageeListSetNumber]);
                this.m_activeProjectImageListJObject["imageList"][delImageListNumber.ToString()][(delImageNumber - 1) % imageeListSetNumber].Remove();
            }
            // 삭제된 이미지에 맞춰서 ImageList Json 파일 다시 만들기
            this.ResetImageList();

            // File IO Task 등록
            customIOManigerFoem.CreateFileDelList(delfilePaths, MainForm.pgbMfileIOstatus, MainForm.lblMwaorkInNumber, MainForm.lblMtotalNumber, MainForm.lblMIOStatus, MainForm.lblMworkInFileName);

            // UI 적용
            this.m_imageNumberChangeUpdater(); // 이미지 개수 정보 업데이트
            this.UISetImageListDataGridview(this.imageListPage, metroGrid, ckbMdataGridViewAutoSize); // 이미지 Data Grid View UI적용

            // Json 파일 저장
            this.JsonDataSave(0);
            this.JsonDataSave(1);
            this.JsonDataSave(2);
            this.m_classInfoChangeUpdater?.Invoke(); // Class 정보 관련 사항 업데이트
        }

        /// <summary>
        /// 활성화된 워크스페이스 이미지 제거, DataGridView 타입
        /// </summary>
        /// <param name="metroGrid"> 적용된 이미지 List 관리 컨트롤 </param>
        public void ImageDel(System.Windows.Forms.DataGridView metroGrid, System.Windows.Forms.CheckBox ckbMdataGridViewAutoSize)
        {
            List<int> delIndexs = new List<int>();
            List<string> delFileNames = new List<string>();
            List<string> delfilePaths = new List<string>();

            //이미지 제거시 라벨링, 데이터 셋 설정되있는지 확인하고 숫자 조정하기

            // 선택된 이미지 정보 가져오기
            for (int i = 0; i < metroGrid.SelectedRows.Count; i++)
            {
                if (metroGrid.SelectedRows[i].Cells[1].Value != null)
                {
                    string fileName = metroGrid.SelectedRows[i].Cells[1].Value.ToString();

                    delIndexs.Add(metroGrid.SelectedRows[i].Index);
                    delFileNames.Add(fileName);
                    delfilePaths.Add(Path.Combine(this.m_pathActiveProjectImage, fileName));
                }
            }

            delIndexs.Sort();
            delIndexs.Reverse();

            foreach (int delIndex in delIndexs)
            {
                metroGrid.Rows.Remove(metroGrid.Rows[delIndex]);
            }
            // 삭제할 이미지 데이터 추출

            // 삭제할 이미지 List Number 추출
            List<int> delImageNumbers = new List<int>();
            foreach (string delFileName in delFileNames)
            {
                delImageNumbers.Add(Convert.ToInt32(this.m_activeProjectDataImageListDataJObject[delFileName]["int_ImageNumber"])); // 이미지 Number 저장

                JToken imageLabeledData = this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"];

                foreach (JProperty data in imageLabeledData) // 이미지에 젹용된 내부 프로젝트 이름 추출
                {
                    Console.WriteLine("key name : " + data.Name);
                    string innerProjectName = data.Name; // 젹용된 내부 프로젝트 이름

                    // 1. Label 데이터 관현 사항 수정 -> Class Info
                    if (this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["string_Label"] != null)
                    {
                        string labelName = this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["string_Label"].ToString();
                        // ClassInfo -> int_classImageTrainNumber 감소
                        this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageTotalNumber"] =
                            Convert.ToInt32(this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageTotalNumber"]) - 1;
                        // 2-4  Labeled Number Data 관련 사항 수정 -> ActiveProjectInfo
                        this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageLabeledNumber"] =
                            Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageLabeledNumber"]) - 1;

                        if (this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Train"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Train"].ToString(), out bool parseConfirm))
                                if (parseConfirm)// Class Train Number 감소
                                    this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageTrainNumber"] =
                                        Convert.ToInt32(this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageTrainNumber"]) - 1;

                        if (this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Test"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Test"].ToString(), out bool parseConfirm))
                                if (parseConfirm) // Class Test Number 감소
                                    this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageTestNumber"] =
                                        Convert.ToInt32(this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageTestNumber"]) - 1;

                        if (this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Validation"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Validation"].ToString(), out bool parseConfirm))
                                if (parseConfirm) // Class Validation Number 감소
                                    this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageValidationNumber"] =
                                        Convert.ToInt32(this.m_activeProjectCalssInfoJObject[innerProjectName][labelName]["int_classImageValidationNumber"]) - 1;
                    }

                    // 2-1. Train Data 관련 사항 수정 -> ActiveProjectInfo
                    if (this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Train"] != null)
                        if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Train"].ToString(), out bool parseConfirm))
                            if (parseConfirm) // ActivateProjectInco -> int_imageTrainNumber 감소
                                this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageTrainNumber"] =
                                    Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageTrainNumber"]) - 1;
                    // 2-2. Test Data 관련 사항 수정 -> ActiveProjectInfo
                    if (this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Test"] != null)
                        if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Test"].ToString(), out bool parseConfirm))
                            if (parseConfirm) // ActivateProjectInco -> int_imageTrainNumber 감소
                                this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageTestNumber"] =
                                    Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageTestNumber"]) - 1;
                    // 2-3. Validation Data 관련 사항 수정 -> ActiveProjectInfo
                    if (this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Validation"] != null)
                        if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[delFileName]["Labeled"][innerProjectName]["bool_Validation"].ToString(), out bool parseConfirm))
                            if (parseConfirm) // ActivateProjectInco -> int_imageTrainNumber 감소
                                this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageValidationNumber"] =
                                    Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][innerProjectName]["int_imageValidationNumber"]) - 1;
                }
                this.m_activeProjectDataImageListDataJObject.Remove(delFileName); // ImageListData에서 데이터 삭제
            }

            // ImageListJObject에서 데이터 삭제
            int imageTotalNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageTotalNumber"]);
            int imageListNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_ImageListnumber"]);
            int imageeListSetNumber = Convert.ToInt32(this.m_activeProjectImageListJObject["int_imageeListSetnumber"]);

            delImageNumbers.Sort();
            delImageNumbers.Reverse();

            foreach (int delImageNumber in delImageNumbers)
            {
                int delImageListNumber = Convert.ToInt32(System.Math.Truncate(Convert.ToDouble(delImageNumber - 1) / Convert.ToDouble(imageeListSetNumber)));
                Console.WriteLine(this.m_activeProjectImageListJObject["imageList"][delImageListNumber.ToString()][(delImageNumber - 1) % imageeListSetNumber]);
                this.m_activeProjectImageListJObject["imageList"][delImageListNumber.ToString()][(delImageNumber - 1) % imageeListSetNumber].Remove();
            }
            // 삭제된 이미지에 맞춰서 ImageList Json 파일 다시 만들기
            this.ResetImageList();

            // File IO Task 등록
            customIOManigerFoem.CreateFileDelList(delfilePaths, MainForm.pgbMfileIOstatus, MainForm.lblMwaorkInNumber, MainForm.lblMtotalNumber, MainForm.lblMIOStatus, MainForm.lblMworkInFileName);

            // UI 적용
            this.m_imageNumberChangeUpdater(); // 이미지 개수 정보 업데이트
            this.UISetImageListDataGridview(this.imageListPage, (MetroFramework.Controls.MetroGrid)metroGrid, (MetroFramework.Controls.MetroCheckBox)ckbMdataGridViewAutoSize); // 이미지 Data Grid View UI적용

            // Json 파일 저장
            this.JsonDataSave(0);
            this.JsonDataSave(1);
            this.JsonDataSave(2);

            // 업데이터 실행
            this.m_classInfoChangeUpdater?.Invoke(); // Class 정보 관련 사항 업데이트
        }

        /// <summary>
        /// 이미지 라벨링을 위한 함수, MetroGrid 타입
        /// </summary>
        /// <param name="metroGrid"> 적용된 이미지 List 관리 컨트롤 </param>
        public void ImageLabeling(MetroFramework.Controls.MetroGrid metroGrid)
        {
            this.classEdit.ShowDialog(); // Class Edit 창 띄우기
            DialogResult dialogResult = this.classEdit.selectDialogResult; // 버튼 클릭 결과 가져오기
            if (dialogResult == DialogResult.OK)
            {
                /* #5
                 * 1. 선택한 라벨링 정보 가져오기
                 * 2. 선택된 이미지 정보 가져오기
                 * 3. 이미지 데이터에 라벨링 정보 적용하기 ImageListData
                 * 4. Class 정보 수정 적용하기 ClassInfo
                 * 5. 라벨링 정보 수정 적용하기 ActiveProjectInfo
                 * 6. 변경된 UI 적용
                 * 7. 저장 버튼 활성화
                 */

                // 1. 선택한 라벨링 정보 가져오기
                if (this.classEdit.selectClassName == null || this.classEdit.selectClassColor == null) // 선택된 값이 없으면
                    return; // 함수 종료

                string modifyClassName = this.classEdit.selectClassName;  // 변경되는 Class 이름
                string modifyClassColor = this.classEdit.selectClassColor; // 변경되는 Class 색
                int labeledImageNumber = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageTotalNumber"]); // 총 이미지 데이터 수, 기존 데이터 가져오기
                int trainImageNumber = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageTrainNumber"]); // 학습 이미지 데이터 수, 기존 데이터 가져오기
                int testImageNumber = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageTestNumber"]); // 테스트 이미지 데이터 수, 기존 데이터 가져오기
                int validationImageNumber = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageValidationNumber"]); // 검증 이미지 데이터 수, 기존 데이터 가져오기

                // 2. 선택된 이미지 정보 가져오기
                List<int> labelImageIndexs = new List<int>(); // 선택된 이미지 데이터 index
                List<string> labelImageNames = new List<string>(); // 선택된 이미지 데이터 이름

                if (metroGrid.SelectedRows.Count == 0) // 선택된 이미지 데이터가 없으면
                    return; // 함수 종료
                for (int i = 0; i < metroGrid.SelectedRows.Count; i++)
                {
                    if (metroGrid.SelectedRows[i].Cells[1].Value != null)
                    {
                        string fileName = metroGrid.SelectedRows[i].Cells[1].Value.ToString();

                        metroGrid.SelectedRows[i].Cells[3].Value = modifyClassName; // Gridview 값 적용

                        labelImageIndexs.Add(metroGrid.SelectedRows[i].Index);
                        labelImageNames.Add(fileName);
                    }
                }

                // 3. 이미지 데이터에 라벨링 정보 적용하기 ImageListData
                if (this.m_activeInnerProjectName == null) // 선택된 내부 프로젝트가 없으면
                    return; // 함수 종료

                // 4. Class 정보 수정 적용하기 ClassInfo
                foreach (string labelImageName in labelImageNames) // 선택된 파일수 만큼 실행
                {
                    //JObject labelImageDataJObject = (JObject)this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]; // 이미지 데이터 정보

                    if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName] != null) // 활성화된 내부 프로젝트 데이터가 있는지 확인
                    {
                        if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"] != null) // 확성화된 내부 프로젝트 데이터 안에 기존의 Label 데이터가 있는지 확인
                        {
                            string previousClassName = this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"].ToString(); // 기존의 라밸링된 데이터 이름 확인
                            if (previousClassName != modifyClassName) // 기존데이터화 변경되는 데이터가 같은지 비교, 같으면 Pass, 다르면 기존의 데이터 수정
                            {
                                this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"] = modifyClassName; // Class Label 변경

                                // 이전 Class Total Number 감소
                                this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTotalNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTotalNumber"]) - 1;
                                labeledImageNumber++; // 라벨링 되는 이미지 개수 추가
                                if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"] != null)
                                    if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"].ToString(), out bool parseConfirm))
                                        if (parseConfirm)
                                        {
                                            // 이전 Class Train Number 감소
                                            this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTrainNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTrainNumber"]) - 1;
                                            trainImageNumber++; // 변경된 Class 학습 이미지 수 증가
                                        }
                                if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"] != null)
                                    if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"].ToString(), out bool parseConfirm))
                                        if (parseConfirm)
                                        {
                                            // 이전 Class Test Number 감소
                                            this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTestNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTestNumber"]) - 1;
                                            testImageNumber++; // 변경된 Class 테스트 이미지 수 증가
                                        }
                                if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"] != null)
                                    if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"].ToString(), out bool parseConfirm))
                                        if (parseConfirm)
                                        {
                                            // 이전 Class Validation Number 감소
                                            this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageValidationNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageValidationNumber"]) - 1;
                                            validationImageNumber++; // 변경된 Class 검증 이미지 수 증가
                                        }
                            }// 기존데이터화 변경되는 데이터가 같은지 비교, 같으면 Pass, 다르면 기존의 데이터 수정
                            else // 기존데이터와 같으면 그냥 넘어가기
                            {
                            }// 기존데이터와 같으면 그냥 넘어가기
                        }
                        else // 기존의 데이터 없음
                        {
                            JObject labeledDatainnerProjectLabelName = new JObject
                            {
                                {"string_Label", modifyClassName}
                            }; // Label Data 생성
                            JObject labeledDatainnerProject = (JObject)this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName];
                            labeledDatainnerProject.Merge(labeledDatainnerProjectLabelName); // 생성된 Label Data 기존 데이터에 병합

                            labeledImageNumber++; // 라벨링 되는 이미지 개수 추가
                            if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"] != null)
                                if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"].ToString(), out bool parseConfirm))
                                    if (parseConfirm)
                                        trainImageNumber++; // 학습 이미지 수
                            if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"] != null)
                                if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"].ToString(), out bool parseConfirm))
                                    if (parseConfirm)
                                        testImageNumber++; // 테스트 이미지 수
                            if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"] != null)
                                if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"].ToString(), out bool parseConfirm))
                                    if (parseConfirm)
                                        validationImageNumber++; // 검증 이미지 수
                        }// 기존의 데이터 없음
                    }
                    else // 활성화된 프로젝트 데이터 없음.
                    {
                        JObject labeledDatainnerProjectLabelName = new JObject
                        {
                             { "string_Label", modifyClassName }
                        };
                        JObject labeledDatainnerProject = new JObject
                        {
                            { this.m_activeInnerProjectName, labeledDatainnerProjectLabelName}
                        };

                        JObject labeledData = (JObject)this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"];
                        labeledData.Merge(labeledDatainnerProject);

                        labeledImageNumber++; // 라벨링 되는 이미지 개수 추가
                    }
                } // foreach (string imageName in labelImageNames)

                // 5. 라벨링 정보 수정 적용하기 ActiveProjectInfo

                #region 라벨링 정보 수정 적용하기 ActiveProjectInfo

                // Class Info 정보 변경
                this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageTotalNumber"] = labeledImageNumber;
                this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageTrainNumber"] = trainImageNumber;
                this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageTestNumber"] = testImageNumber;
                this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageValidationNumber"] = validationImageNumber;

                int activeProjectInfoImageLabeledNumber = 0;

                // Active Project Info 변경
                foreach (string className in this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName]["string_array_classList"])
                    if (className != null || className == "")
                        activeProjectInfoImageLabeledNumber += Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][className]["int_classImageTotalNumber"]);

                // 데이터 activeProjectInfo에 적용
                this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageLabeledNumber"] = activeProjectInfoImageLabeledNumber;

                #endregion 라벨링 정보 수정 적용하기 ActiveProjectInfo

                // 6. 변경된 UI 적용
                this.m_imageNumberChangeUpdater(); // 이미지 개수 정보 업데이트
                //this.UISetImageListDataGridview(this.imageListPage);

                this.JsonDataSave(0); // Json 데이터 저장
                this.JsonDataSave(1); // Json 데이터 저장
                this.JsonDataSave(2); // Json 데이터 저장

                // 7. 저장 버튼 활성화
                this.SaveEnabled(); // 저장 활성화
                this.SaveButoonChacked(); // 저장 버튼 확인
                this.m_classInfoChangeUpdater?.Invoke(); // Class 정보 관련 사항 업데이트
            } // if (dialogResult == DialogResult.OK)
            else if (dialogResult == DialogResult.Cancel)
            {
            } // else if (dialogResult == DialogResult.Cancel)
        }

        /// <summary>
        /// 이미지 라벨링을 위한 함수
        /// </summary>
        /// <param name="dataFileList"></param>
        /// <param name="modifyClassName"></param>
        public void ImageAddingLabeling(List<string> dataFileList, string modifyClassName)
        {
            /* 라벨링 정보 적용
            * 1. 선택한 라벨링 정보 가져오기
            * 2. 선택된 이미지 정보 가져오기
            * 3. 이미지 데이터에 라벨링 정보 적용하기 ImageListData
            * 4. Class 정보 수정 적용하기 ClassInfo
            * 5. 라벨링 정보 수정 적용하기 ActiveProjectInfo
            * 6. 변경된 UI 적용
            * 7. 저장 버튼 활성화
            */

            // 1. 선택한 라벨링 정보 가져오기
            if (this.classEdit.selectClassName == null || this.classEdit.selectClassColor == null) // 선택된 값이 없으면
                return; // 함수 종료

            int labeledImageNumber = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageTotalNumber"]); // 총 이미지 데이터 수, 기존 데이터 가져오기
            int trainImageNumber = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageTrainNumber"]); // 학습 이미지 데이터 수, 기존 데이터 가져오기
            int testImageNumber = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageTestNumber"]); // 테스트 이미지 데이터 수, 기존 데이터 가져오기
            int validationImageNumber = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageValidationNumber"]); // 검증 이미지 데이터 수, 기존 데이터 가져오기

            // 2. 이미지 정보 가져오기

            if (dataFileList.Count == 0) // 선택된 이미지 데이터가 없으면
                return; // 함수 종료

            // 3. 이미지 데이터에 라벨링 정보 적용하기 ImageListData
            if (this.m_activeInnerProjectName == null) // 선택된 내부 프로젝트가 없으면
                return; // 함수 종료

            // 4. Class 정보 수정 적용하기 ClassInfo
            foreach (string labelImageName in dataFileList) // 선택된 파일수 만큼 실행
            {
                //JObject labelImageDataJObject = (JObject)this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]; // 이미지 데이터 정보

                if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName] != null) // 활성화된 내부 프로젝트 데이터가 있는지 확인
                {
                    if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"] != null) // 확성화된 내부 프로젝트 데이터 안에 기존의 Label 데이터가 있는지 확인
                    {
                        string previousClassName = this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"].ToString(); // 기존의 라밸링된 데이터 이름 확인
                        if (previousClassName != modifyClassName) // 기존데이터화 변경되는 데이터가 같은지 비교, 같으면 Pass, 다르면 기존의 데이터 수정
                        {
                            this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"] = modifyClassName; // Class Label 변경

                            // 이전 Class Total Number 감소
                            this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTotalNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTotalNumber"]) - 1;
                            labeledImageNumber++; // 라벨링 되는 이미지 개수 추가
                            if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"] != null)
                                if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"].ToString(), out bool parseConfirm))
                                    if (parseConfirm)
                                    {
                                        // 이전 Class Train Number 감소
                                        this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTrainNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTrainNumber"]) - 1;
                                        trainImageNumber++; // 변경된 Class 학습 이미지 수 증가
                                    }
                            if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"] != null)
                                if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"].ToString(), out bool parseConfirm))
                                    if (parseConfirm)
                                    {
                                        // 이전 Class Test Number 감소
                                        this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTestNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTestNumber"]) - 1;
                                        testImageNumber++; // 변경된 Class 테스트 이미지 수 증가
                                    }
                            if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"] != null)
                                if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"].ToString(), out bool parseConfirm))
                                    if (parseConfirm)
                                    {
                                        // 이전 Class Validation Number 감소
                                        this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageValidationNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageValidationNumber"]) - 1;
                                        validationImageNumber++; // 변경된 Class 검증 이미지 수 증가
                                    }
                        }// 기존데이터화 변경되는 데이터가 같은지 비교, 같으면 Pass, 다르면 기존의 데이터 수정
                        else // 기존데이터와 같으면 그냥 넘어가기
                        {
                        }// 기존데이터와 같으면 그냥 넘어가기
                    }
                    else // 기존의 데이터 없음
                    {
                        JObject labeledDatainnerProjectLabelName = new JObject
                            {
                                {"string_Label", modifyClassName}
                            }; // Label Data 생성
                        JObject labeledDatainnerProject = (JObject)this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName];
                        labeledDatainnerProject.Merge(labeledDatainnerProjectLabelName); // 생성된 Label Data 기존 데이터에 병합

                        labeledImageNumber++; // 라벨링 되는 이미지 개수 추가
                        if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"].ToString(), out bool parseConfirm))
                                if (parseConfirm)
                                    trainImageNumber++; // 학습 이미지 수
                        if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"].ToString(), out bool parseConfirm))
                                if (parseConfirm)
                                    testImageNumber++; // 테스트 이미지 수
                        if (this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"].ToString(), out bool parseConfirm))
                                if (parseConfirm)
                                    validationImageNumber++; // 검증 이미지 수
                    }// 기존의 데이터 없음
                }
                else // 활성화된 프로젝트 데이터 없음.
                {
                    JObject labeledDatainnerProjectLabelName = new JObject
                        {
                             { "string_Label", modifyClassName }
                        };
                    JObject labeledDatainnerProject = new JObject
                        {
                            { this.m_activeInnerProjectName, labeledDatainnerProjectLabelName}
                        };

                    JObject labeledData = (JObject)this.m_activeProjectDataImageListDataJObject[labelImageName]["Labeled"];
                    labeledData.Merge(labeledDatainnerProject);

                    labeledImageNumber++; // 라벨링 되는 이미지 개수 추가
                }
            } // foreach (string imageName in labelImageNames)

            // 5. 라벨링 정보 수정 적용하기 ActiveProjectInfo

            #region 라벨링 정보 수정 적용하기 ActiveProjectInfo

            // Class Info 정보 변경
            this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageTotalNumber"] = labeledImageNumber;
            this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageTrainNumber"] = trainImageNumber;
            this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageTestNumber"] = testImageNumber;
            this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][modifyClassName]["int_classImageValidationNumber"] = validationImageNumber;

            int activeProjectInfoImageLabeledNumber = 0;

            // Active Project Info 변경
            foreach (string className in this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName]["string_array_classList"])
                if (className != null || className == "")
                    activeProjectInfoImageLabeledNumber += Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][className]["int_classImageTotalNumber"]);

            // 데이터 activeProjectInfo에 적용
            this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageLabeledNumber"] = activeProjectInfoImageLabeledNumber;

            #endregion 라벨링 정보 수정 적용하기 ActiveProjectInfo
        }

        /// <summary>
        /// 이미지 Train Data Set으로 적용, MetroGrid 타입
        /// </summary>
        /// <param name="metroGrid"> 적용된 이미지 List 관리 컨트롤 </param>
        public void ImageTrainSet(MetroFramework.Controls.MetroGrid metroGrid)
        {
            /* #6
             * 1. 선택된 이미지 정보 가져오기
             * 2. 선택한 이미지 데이터 Train Status 정보 가져오기
             * 3. Train Status 이미지 데이터에 적용 imageListData
             * 4. 라벨링 정보 수정 적용하기 ActiveProjectInfo
             * 5. 변경된 UI 적용
             * 6. 저장 버튼 활성화
             */

            // 1. 선택된 이미지 정보 가져오기
            List<int> imageIndexs = new List<int>(); // 선택된 이미지 데이터 index
            List<string> imageNames = new List<string>(); // 선택된 이미지 데이터 이름

            if (metroGrid.SelectedRows.Count == 0) // 선택된 이미지 데이터가 없으면
                return; // 함수 종료
            for (int i = 0; i < metroGrid.SelectedRows.Count; i++)
            {
                if (metroGrid.SelectedRows[i].Cells[1].Value != null)
                {
                    string fileName = metroGrid.SelectedRows[i].Cells[1].Value.ToString(); // 파일 이름 가져오기
                    imageIndexs.Add(metroGrid.SelectedRows[i].Index); // Index 추가
                    imageNames.Add(fileName); // 파일 이름 추가

                    bool test = false;
                    bool validation = false;
                    if (metroGrid.SelectedRows[i].Cells[2].Value != null)
                    {
                        test = metroGrid.SelectedRows[i].Cells[2].Value.ToString().Contains("Test");
                        validation = metroGrid.SelectedRows[i].Cells[2].Value.ToString().Contains("Validation");
                    }
                    string value = "Train";

                    if (test)
                        value += ", Test";

                    if (validation)
                    {
                        value += ", Validation";
                    }
                    metroGrid.SelectedRows[i].Cells[2].Value = value; // Data Grid View 값 적용
                }
            }

            // 2. 선택한 이미지 데이터 Train Status 정보 가져오기
            int imageTrainNumber = Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageTrainNumber"]); // imageTestNumber 값 가져오기

            // 3. Train Status 이미지 데이터에 적용 imageListData
            foreach (string imageName in imageNames)
            {
                if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName] != null) // 프로젝트 이름 데이터 정보가 있는지 확인
                {
                    if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"] != null) // 프로젝트 정보에 bool_Train 정보가 있는지 확인
                    {
                        if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"].ToString(), out bool parseConfirm))
                            if (!parseConfirm)
                            {
                                // Train Class 라벨링이 완료 되어있는 경우
                                if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"] != null)
                                {
                                    string label = this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"].ToString();
                                    // Train Class Number 증가
                                    this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTrainNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTrainNumber"]) + 1;
                                }

                                this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"] = true;
                                imageTrainNumber++;
                            }
                    }
                    else // 프로젝트 정보에 bool_Train 정보가 없는 경우
                    {
                        // Train Class 라벨링이 완료 되어있는 경우
                        if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"] != null)
                        {
                            string label = this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"].ToString();
                            // Train Class Number 증가
                            this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTrainNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTrainNumber"]) + 1;
                        }

                        JObject labeledData = (JObject)this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName];
                        labeledData["bool_Train"] = true;
                        imageTrainNumber++;
                    }
                }
                else // 프로젝트 이름 데이터 정보가 없는 경우
                {
                    JObject labeledDatainnerProjectLabelName = new JObject
                        {
                             { "bool_Train", true }
                        };
                    JObject labeledDatainnerProject = new JObject
                        {
                            { this.m_activeInnerProjectName, labeledDatainnerProjectLabelName}
                        };

                    JObject labeledData = (JObject)this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"];
                    labeledData.Merge(labeledDatainnerProject);
                    imageTrainNumber++;
                }
            }

            // 4. 라벨링 정보 수정 적용하기 ActiveProjectInfo
            this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageTrainNumber"] = imageTrainNumber; // imageTestNumber 값 적용

            // 5. 변경된 UI 적용
            this.m_imageNumberChangeUpdater?.Invoke(); // 이미지 개수 정보 업데이트
            //this.UISetImageListDataGridview(this.imageListPage);

            this.JsonDataSave(0); // Json 데이터 저장
            this.JsonDataSave(1); // Json 데이터 저장
            this.JsonDataSave(2); // Json 데이터 저장

            // 6. 저장 버튼 활성화
            this.SaveEnabled(); // 저장 활성화
            this.SaveButoonChacked(); // 저장 버튼 확인
            this.m_classInfoChangeUpdater?.Invoke(); // Class 정보 관련 사항 업데이트
        }

        public void ImageAddingTrainSet(List<string> dataFileList)
        {
            /* #6
            * 1. 선택된 이미지 정보 가져오기
            * 2. 선택한 이미지 데이터 Train Status 정보 가져오기
            * 3. Train Status 이미지 데이터에 적용 imageListData
            * 4. 라벨링 정보 수정 적용하기 ActiveProjectInfo
            * 5. 변경된 UI 적용
            * 6. 저장 버튼 활성화
            */

            // 1. 선택된 이미지 정보 가져오기
            if (dataFileList.Count == 0) // 이미지 데이터가 없으면
                return; // 함수 종료

            // 2. 선택한 이미지 데이터 Train Status 정보 가져오기
            int imageTrainNumber = Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageTrainNumber"]); // imageTestNumber 값 가져오기

            // 3. Train Status 이미지 데이터에 적용 imageListData
            foreach (string imageName in dataFileList)
            {
                if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName] != null) // 프로젝트 이름 데이터 정보가 있는지 확인
                {
                    if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"] != null) // 프로젝트 정보에 bool_Train 정보가 있는지 확인
                    {
                        if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"].ToString(), out bool parseConfirm))
                            if (!parseConfirm)
                            {
                                // Train Class 라벨링이 완료 되어있는 경우
                                if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"] != null)
                                {
                                    string label = this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"].ToString();
                                    // Train Class Number 증가
                                    this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTrainNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTrainNumber"]) + 1;
                                }

                                this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"] = true;
                                imageTrainNumber++;
                            }
                    }
                    else // 프로젝트 정보에 bool_Train 정보가 없는 경우
                    {
                        // Train Class 라벨링이 완료 되어있는 경우
                        if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"] != null)
                        {
                            string label = this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"].ToString();
                            // Train Class Number 증가
                            this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTrainNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTrainNumber"]) + 1;
                        }

                        JObject labeledData = (JObject)this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName];
                        labeledData["bool_Train"] = true;
                        imageTrainNumber++;
                    }
                }
                else // 프로젝트 이름 데이터 정보가 없는 경우
                {
                    JObject labeledDatainnerProjectLabelName = new JObject
                        {
                             { "bool_Train", true }
                        };
                    JObject labeledDatainnerProject = new JObject
                        {
                            { this.m_activeInnerProjectName, labeledDatainnerProjectLabelName}
                        };

                    JObject labeledData = (JObject)this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"];
                    labeledData.Merge(labeledDatainnerProject);
                    imageTrainNumber++;
                }
            }

            // 4. 라벨링 정보 수정 적용하기 ActiveProjectInfo
            this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageTrainNumber"] = imageTrainNumber; // imageTestNumber 값 적용
        }

        /// <summary>
        /// 이미지 Test Data Set으로 적용, MetroGrid 타입
        /// </summary>
        /// <param name="metroGrid"> 적용된 이미지 List 관리 컨트롤 </param>
        public void ImageTestSet(MetroFramework.Controls.MetroGrid metroGrid)
        {
            /* #6
             * 1. 선택된 이미지 정보 가져오기
             * 2. 선택한 이미지 데이터 Test Status 정보 가져오기
             * 3. Test Status 이미지 데이터에 적용 imageListData
             * 4. 라벨링 정보 수정 적용하기 ActiveProjectInfo
             * 5. 변경된 UI 적용
             * 6. 저장 버튼 활성화
             */

            // 1. 선택된 이미지 정보 가져오기
            List<int> imageIndexs = new List<int>(); // 선택된 이미지 데이터 index
            List<string> imageNames = new List<string>(); // 선택된 이미지 데이터 이름

            if (metroGrid.SelectedRows.Count == 0) // 선택된 이미지 데이터가 없으면
                return; // 함수 종료
            for (int i = 0; i < metroGrid.SelectedRows.Count; i++)
            {
                if (metroGrid.SelectedRows[i].Cells[1].Value != null)
                {
                    string fileName = metroGrid.SelectedRows[i].Cells[1].Value.ToString(); // 파일 이름 가져오기
                    imageIndexs.Add(metroGrid.SelectedRows[i].Index); // Index 추가
                    imageNames.Add(fileName); // 파일 이름 추가

                    bool train = false;
                    bool validation = false;
                    if (metroGrid.SelectedRows[i].Cells[2].Value != null)
                    {
                        train = metroGrid.SelectedRows[i].Cells[2].Value.ToString().Contains("Train");
                        validation = metroGrid.SelectedRows[i].Cells[2].Value.ToString().Contains("Validation");
                    }
                    string value = "Test";

                    if (train)
                        value = "Train, Test";
                    if (validation)
                        value += ", Validation";

                    metroGrid.SelectedRows[i].Cells[2].Value = value; // Data Grid View 값 적용
                }
            }

            // 2. 선택한 이미지 데이터 Test Status 정보 가져오기
            int imageTestNumber = Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageTestNumber"]); // imageTestNumber 값 가져오기

            // 3. Test Status 이미지 데이터에 적용 imageListData
            foreach (string imageName in imageNames)
            {
                if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName] != null) // 프로젝트 이름 데이터 정보가 있는지 확인
                {
                    if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"] != null) // 프로젝트 정보에 bool_Train 정보가 있는지 확인
                    {
                        if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"].ToString(), out bool parseConfirm))
                            if (!parseConfirm)
                            {
                                // Train Class 라벨링이 완료 되어있는 경우
                                if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"] != null)
                                {
                                    string label = this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"].ToString();
                                    // Train Class Number 증가
                                    this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTestNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTestNumber"]) + 1;
                                }

                                this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"] = true;
                                imageTestNumber++;
                            }
                    }
                    else // 프로젝트 정보에 bool_Train 정보가 없는 경우
                    {
                        // Train Class 라벨링이 완료 되어있는 경우
                        if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"] != null)
                        {
                            string label = this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"].ToString();
                            // Train Class Number 증가
                            this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTestNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTestNumber"]) + 1;
                        }

                        JObject labeledData = (JObject)this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName];
                        labeledData["bool_Test"] = true;
                        imageTestNumber++;
                    }
                }
                else // 프로젝트 이름 데이터 정보가 없는 경우
                {
                    JObject labeledDatainnerProjectLabelName = new JObject
                        {
                             { "bool_Test", true }
                        };
                    JObject labeledDatainnerProject = new JObject
                        {
                            { this.m_activeInnerProjectName, labeledDatainnerProjectLabelName}
                        };

                    JObject labeledData = (JObject)this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"];
                    labeledData.Merge(labeledDatainnerProject);
                    imageTestNumber++;
                }
            }

            // 4. 라벨링 정보 수정 적용하기 ActiveProjectInfo
            this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageTestNumber"] = imageTestNumber; // imageTestNumber 값 적용

            // 5. 변경된 UI 적용
            this.m_imageNumberChangeUpdater(); // 이미지 개수 정보 업데이트
            //this.UISetImageListDataGridview(this.imageListPage);

            this.JsonDataSave(0); // Json 데이터 저장
            this.JsonDataSave(1); // Json 데이터 저장
            this.JsonDataSave(2); // Json 데이터 저장

            // 6. 저장 버튼 활성화
            this.SaveEnabled(); // 저장 활성화
            this.SaveButoonChacked(); // 저장 버튼 확인
            this.m_classInfoChangeUpdater?.Invoke(); // Class 정보 관련 사항 업데이트
        }

        public void ImageAddingTestSet(List<string> dataFileList)
        {
            /* #6
             * 1. 선택된 이미지 정보 가져오기
             * 2. 선택한 이미지 데이터 Test Status 정보 가져오기
             * 3. Test Status 이미지 데이터에 적용 imageListData
             * 4. 라벨링 정보 수정 적용하기 ActiveProjectInfo
             * 5. 변경된 UI 적용
             * 6. 저장 버튼 활성화
             */

            // 1. 선택된 이미지 정보 가져오기
            if (dataFileList.Count == 0) // 선택된 이미지 데이터가 없으면
                return; // 함수 종료

            // 2. 선택한 이미지 데이터 Test Status 정보 가져오기
            int imageTestNumber = Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageTestNumber"]); // imageTestNumber 값 가져오기

            // 3. Test Status 이미지 데이터에 적용 imageListData
            foreach (string imageName in dataFileList)
            {
                if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName] != null) // 프로젝트 이름 데이터 정보가 있는지 확인
                {
                    if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"] != null) // 프로젝트 정보에 bool_Train 정보가 있는지 확인
                    {
                        if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"].ToString(), out bool parseConfirm))
                            if (!parseConfirm)
                            {
                                // Train Class 라벨링이 완료 되어있는 경우
                                if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"] != null)
                                {
                                    string label = this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"].ToString();
                                    // Train Class Number 증가
                                    this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTestNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTestNumber"]) + 1;
                                }

                                this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"] = true;
                                imageTestNumber++;
                            }
                    }
                    else // 프로젝트 정보에 bool_Train 정보가 없는 경우
                    {
                        // Train Class 라벨링이 완료 되어있는 경우
                        if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"] != null)
                        {
                            string label = this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"].ToString();
                            // Train Class Number 증가
                            this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTestNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][label]["int_classImageTestNumber"]) + 1;
                        }

                        JObject labeledData = (JObject)this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName];
                        labeledData["bool_Test"] = true;
                        imageTestNumber++;
                    }
                }
                else // 프로젝트 이름 데이터 정보가 없는 경우
                {
                    JObject labeledDatainnerProjectLabelName = new JObject
                        {
                             { "bool_Test", true }
                        };
                    JObject labeledDatainnerProject = new JObject
                        {
                            { this.m_activeInnerProjectName, labeledDatainnerProjectLabelName}
                        };

                    JObject labeledData = (JObject)this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"];
                    labeledData.Merge(labeledDatainnerProject);
                    imageTestNumber++;
                }
            }

            // 4. 라벨링 정보 수정 적용하기 ActiveProjectInfo
            this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageTestNumber"] = imageTestNumber; // imageTestNumber 값 적용
        }

        /// <summary>
        /// 이미지 라벨링 정보 초기화
        /// </summary>
        /// <param name="metroGrid"> 적용된 이미지 List 관리 컨트롤 </param>
        public void ImageLabelInfoReset(MetroFramework.Controls.MetroGrid metroGrid)
        {
            /* #7
             * 1. 선택된 이미지 정보 가져오기, GridDataView 에 Class 정보 초기화
             * 2. 선택된 내부 프로젝트 확인
             * 3. 이미지 데이터에 라벨링 초기화 적용하기 ImageListData, Class 정보 수정 적용하기 ClassInfo
             * 4. 라벨링 정보 수정 적용하기 ActiveProjectInfo
             * 5. 변경된 UI 적용
             * 6. 저장 버튼 활성화
             */

            // 1. 선택된 이미지 정보 가져오기, GridDataView 에 Class 정보 초기화
            List<int> imageIndexs = new List<int>(); // 선택된 이미지 데이터 index
            List<string> imageNames = new List<string>(); // 선택된 이미지 데이터 이름

            if (metroGrid.SelectedRows.Count == 0) // 선택된 이미지 데이터가 없으면
                return; // 함수 종료
            for (int i = 0; i < metroGrid.SelectedRows.Count; i++)
            {
                if (metroGrid.SelectedRows[i].Cells[1].Value != null)
                {
                    string fileName = metroGrid.SelectedRows[i].Cells[1].Value.ToString(); // 파일 이름 가져오기

                    metroGrid.SelectedRows[i].Cells[3].Value = null; // Class 정보 초기화

                    imageIndexs.Add(metroGrid.SelectedRows[i].Index);
                    imageNames.Add(fileName);
                }
            }

            // 2. 선택된 내부 프로젝트 확인
            if (this.m_activeInnerProjectName == null) // 선택된 내부 프로젝트가 없으면
                return; // 함수 종료

            // 3. 이미지 데이터에 라벨링 초기화 적용하기 ImageListData, Class 정보 수정 적용하기 ClassInfo
            foreach (string imageName in imageNames) // 선택된 파일수 만큼 실행
            {
                //JObject labelImageDataJObject = (JObject)this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]; // 이미지 데이터 정보

                if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName] != null) // 활성화된 내부 프로젝트 데이터가 있는지 확인
                {
                    if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"] != null) // 확성화된 내부 프로젝트 데이터 안에 기존의 Label 데이터가 있는지 확인
                    {
                        string previousClassName = this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"].ToString(); // 기존의 라밸링된 데이터 이름 확인
                        JObject activeInnerProjectNameImageDataJObject = (JObject)this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName];
                        activeInnerProjectNameImageDataJObject.Remove("string_Label"); // Class Label 삭제

                        // 이전 Class Total Number 감소
                        this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTotalNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTotalNumber"]) - 1;
                        if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"].ToString(), out bool parseConfirm))
                                if (parseConfirm)
                                {
                                    // 이전 Class Train Number 감소
                                    this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTrainNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTrainNumber"]) - 1;
                                }
                        if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"].ToString(), out bool parseConfirm))
                                if (parseConfirm)
                                {
                                    // 이전 Class Test Number 감소
                                    this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTestNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageTestNumber"]) - 1;
                                }
                        if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"].ToString(), out bool parseConfirm))
                                if (parseConfirm)
                                {
                                    // 이전 Class Validation Number 감소
                                    this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageValidationNumber"] = Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][previousClassName]["int_classImageValidationNumber"]) - 1;
                                }
                    }
                }
            } // foreach (string imageName in labelImageNames)

            // 4. 라벨링 정보 수정 적용하기 ActiveProjectInfo

            #region 라벨링 정보 수정 적용하기 ActiveProjectInfo

            // Active Project Info 변경
            int activeProjectInfoImageLabeledNumber = 0;
            if (this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName] != null)
            {
                foreach (string className in this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName]["string_array_classList"])
                    if (className != null || className == "")
                        activeProjectInfoImageLabeledNumber += Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][className]["int_classImageTotalNumber"]);

                this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageLabeledNumber"] = activeProjectInfoImageLabeledNumber; // 데이터 activeProjectInfo에 적용
            }

            #endregion 라벨링 정보 수정 적용하기 ActiveProjectInfo

            // Json 파일 저장
            this.JsonDataSave(0);
            this.JsonDataSave(1);
            this.JsonDataSave(2);

            // 5. 변경된 UI 적용
            this.m_imageNumberChangeUpdater(); // 이미지 개수 정보 업데이트

            // 6. 저장 버튼 활성화
            this.SaveEnabled(); // 저장 활성화
            this.SaveButoonChacked(); // 저장 버튼 확인
            this.m_classInfoChangeUpdater?.Invoke(); // Class 정보 관련 사항 업데이트
        }

        /// <summary>
        /// 이미지 Data Set 정보 초기화
        /// </summary>
        /// <param name="metroGrid"> 적용된 이미지 List 관리 컨트롤 </param>
        public void ImageDataSetInfoReset(MetroFramework.Controls.MetroGrid metroGrid)
        {
            /* #9
             * 1. 선택된 이미지 정보 가져오기
             * 2. Image Status 초기화 이미지 데이터에 적용 -> imageListData
             * 3. 변경된 UI 적용
             * 4. 저장 버튼 활성화
             */

            // 1. 선택된 이미지 정보 가져오기
            List<int> imageIndexs = new List<int>(); // 선택된 이미지 데이터 index
            List<string> imageNames = new List<string>(); // 선택된 이미지 데이터 이름

            if (metroGrid.SelectedRows.Count == 0) // 선택된 이미지 데이터가 없으면
                return; // 함수 종료
            for (int i = 0; i < metroGrid.SelectedRows.Count; i++)
            {
                if (metroGrid.SelectedRows[i].Cells[1].Value != null)
                {
                    string fileName = metroGrid.SelectedRows[i].Cells[1].Value.ToString();

                    metroGrid.SelectedRows[i].Cells[2].Value = null; // Data Set 정보 초기화

                    imageIndexs.Add(metroGrid.SelectedRows[i].Index);
                    imageNames.Add(fileName);
                }
            }

            // 2. Image Status 초기화 이미지 데이터에 적용 -> imageListData
            foreach (string imageName in imageNames)
            {
                // 2-1. Label 데이터 관현 사항 수정 -> Class Info
                if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName] != null)
                {
                    if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"] != null)
                    {
                        string labelName = this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["string_Label"].ToString();

                        // 2-1-1 ClassInfo -> Class Train Number, int_classImageTrainNumber 감소
                        if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"].ToString(), out bool parseConfirm))
                                if (parseConfirm)// Class Train Number 감소
                                    this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][labelName]["int_classImageTrainNumber"] =
                                        Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][labelName]["int_classImageTrainNumber"]) - 1;
                        // 2-1-2 ClassInfo -> Class Test Number, int_classImageTestNumber 감소
                        if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"].ToString(), out bool parseConfirm))
                                if (parseConfirm) // Class Test Number 감소
                                    this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][labelName]["int_classImageTestNumber"] =
                                        Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][labelName]["int_classImageTestNumber"]) - 1;
                        // 2-1-3 ClassInfo -> Class Validation Number, int_classImageValidationNumber 감소
                        if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"] != null)
                            if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"].ToString(), out bool parseConfirm))
                                if (parseConfirm) // Class Validation Number 감소
                                    this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][labelName]["int_classImageValidationNumber"] =
                                        Convert.ToInt32(this.m_activeProjectCalssInfoJObject[this.m_activeInnerProjectName][labelName]["int_classImageValidationNumber"]) - 1;
                    }

                    // 2-2. DataSet 관련 사항 수정 -> ActiveProjectInfo
                    // 2-2-1 ActiveProjectInfo -> Train Data 관련 사항 수정
                    if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"] != null)
                        if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"].ToString(), out bool parseConfirm))
                            if (parseConfirm)
                            {
                                this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageTrainNumber"] =
                                    Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageTrainNumber"]) - 1; // ActivateProjectInco -> int_imageTrainNumber 감소
                                this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Train"] = false; // DataSet 초기화
                            }

                    // 2-2-2 ActiveProjectInfo -> Test Data 관련 사항 수정
                    if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"] != null)
                        if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"].ToString(), out bool parseConfirm))
                            if (parseConfirm)
                            {
                                this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageTestNumber"] =
                                    Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageTestNumber"]) - 1; // ActivateProjectInco -> int_imageTrainNumber 감소
                                this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Test"] = false; // DataSet 초기화
                            }

                    // 2-2-3 ActiveProjectInfo -> Validation Data 관련 사항 수정
                    if (this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"] != null)
                        if (Boolean.TryParse(this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["bool_Validation"].ToString(), out bool parseConfirm))
                            if (parseConfirm)
                            {
                                this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageValidationNumber"] =
                                    Convert.ToInt32(this.m_activeProjectInfoJObject["string_projectListInfo"][this.m_activeInnerProjectName]["int_imageValidationNumber"]) - 1; // ActivateProjectInco -> int_imageTrainNumber 감소
                                this.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][this.m_activeInnerProjectName]["int_imageValidationNumber"] = false; // DataSet 초기화
                            }
                }
            }
            // 3. 변경된 UI 적용
            this.m_imageNumberChangeUpdater(); // 이미지 개수 정보 업데이트

            // Json 파일 저장
            this.JsonDataSave(0);
            this.JsonDataSave(1);
            this.JsonDataSave(2);

            // 4. 저장 버튼 활성화
            this.SaveEnabled(); // 저장 활성화
            this.SaveButoonChacked(); // 저장 버튼 확인
            this.m_classInfoChangeUpdater?.Invoke(); // Class 정보 관련 사항 업데이트
        }

        /// <summary>
        /// 내부 프로젝트 삭제 함수
        /// </summary>
        public void ProjectDelete(string deleteInnerProjectName)
        {
            this.m_activeInnerProjectName = null; // 활성화 중인 프로젝트 삭제
            this.ProjectUIRemove(); // 활성화된 UI, 정보 초기화
            MetroFramework.Controls.MetroTile deleteButton = this.m_activeInnerProjectButton[deleteInnerProjectName]; // 삭제할 버튼 불러오기
            this.m_activeInnerProjectButton.Remove(deleteInnerProjectName); // 삭제할 버튼 관리 변수에서 삭제
            this.MainForm.panelProjectInfo.Controls.Remove(deleteButton); // 삭제할 버튼 Main Fomes에 컨트롤 삭제

            // Json 파일 저장
            this.JsonDataSave(0);
            this.JsonDataSave(1);
            this.JsonDataSave(2);
        }

        /// <summary>
        /// Options 가져오기
        /// </summary>
        /// <returns></returns>
        public JObject GetTrainInfo(JObject trainOptions)
        {
            if (this.m_activeInnerProjectTask == "Classification")
            {
                trainOptions = this.m_classificationTrainOptionDictionary[this.m_activeInnerProjectName].GetTrainOptions(trainOptions); // Train 옵션 값 가져오기
            }
            else if (this.m_activeInnerProjectTask == "Segmentation")
            {
            }
            else if (this.m_activeInnerProjectTask == "ObjectDetection")
            {
            }
            return trainOptions;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public JObject GetTrainData(JObject trainData)
        {
            if (this.m_activeInnerProjectTask == "Classification")
            {
                trainData = this.GetTrainDataClassification(trainData);
            }
            else if (this.m_activeInnerProjectTask == "Segmentation")
            {
            }
            else if (this.m_activeInnerProjectTask == "ObjectDetection")
            {
            }
            return trainData;
        }

        /// <summary>
        /// 학습에 사용할 이미지 데이터 정보 출력 -> Image 이름, 이미지 경로 정보, 이미지 Labeled 정보만 TrainForm에 넘겨주면 TrainForms에서 알맞은 라벨링 정보 색인 하기
        /// </summary>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public JObject GetTrainDataClassification(JObject trainData)
        {
            if (this.m_activeInnerProjectInputImageType.Equals("SingleImage"))
            {
                foreach (JProperty imageData in (JToken)this.m_activeProjectDataImageListDataJObject)
                {
                    if (this.m_activeProjectDataImageListDataJObject[imageData.Name]["Labeled"] != null)
                    {
                        if (this.m_activeProjectDataImageListDataJObject[imageData.Name]["Labeled"][this.m_activeInnerProjectName] != null)
                        {
                            JObject jObject = new JObject
                            {
                                ["string_ImagePath"] = this.m_activeProjectDataImageListDataJObject[imageData.Name]["string_ImagePath"],
                                ["Labeled"] = this.m_activeProjectDataImageListDataJObject[imageData.Name]["Labeled"][this.m_activeInnerProjectName]
                            };
                            trainData[imageData.Name] = jObject;
                        }
                    }
                }
            }
            else if (this.m_activeInnerProjectInputImageType.Equals("MultiImage"))
            {
            }
            else if (this.m_activeInnerProjectInputImageType.Equals("CADImage"))
            {
                foreach (JProperty imageData in (JToken)this.m_activeProjectDataImageListDataJObject)
                {
                    if (this.m_activeProjectDataImageListDataJObject[imageData.Name]["Labeled"] != null)
                    {
                        if (this.m_activeProjectDataImageListDataJObject[imageData.Name]["Labeled"][this.m_activeInnerProjectName] != null)
                        {
                            if (this.m_activeProjectDataImageListDataJObject[imageData.Name]["Labeled"][this.m_activeInnerProjectName]["CADImage"] != null)
                            {
                                JObject jObject = new JObject
                                {
                                    ["string_ImagePath"] = this.m_activeProjectDataImageListDataJObject[imageData.Name]["string_ImagePath"],
                                    ["Labeled"] = this.m_activeProjectDataImageListDataJObject[imageData.Name]["Labeled"][this.m_activeInnerProjectName]
                                };
                                trainData[imageData.Name] = jObject;
                            }
                        }
                    }
                }
            }
            return trainData;
        }

        private async Task<int> JsonImageWrite(ProjectAI.MainForms.CadImageSelect cadImageSelect, string m_pathActiveProjectImage, JObject m_activeProjectDataImageListDataJObject,
            JObject labeledDatainnerProjectLabelName, string[] files, string[] newSameFiles, int imageTotalNumber, string CADImageFolder)
        {
            int totalFileNumber = files.Count();
            int workInNumber = 1;

            System.Threading.CancellationTokenSource searchAlgorithmCancellTokenSource = new System.Threading.CancellationTokenSource();
            ProjectAlgorithm.SearchAlgorithmString searchAlgorithmString = new ProjectAlgorithm.SearchAlgorithmString();

            string[] inputFiles1 = new string[files.Length];
            string[] inputFiles2 = new string[newSameFiles.Length];
            for (int i = 0; i < files.Length; i++)
            {
                string[] fileNameSplit = files[i].Split('_');
                string fileName = null;
                for (int j = 0; j < fileNameSplit.Length - 1; j++)
                {
                    if (fileName == null)
                        fileName = fileNameSplit[j];
                    else
                        fileName += "_" + fileNameSplit[j];
                }

                //fileList1[i] = fileName + $".{System.IO.Path.GetExtension(fileList1[i])}"; // 확장자 포함
                inputFiles1[i] = fileName; // 확장자 미 포함
            }
            for (int i = 0; i < newSameFiles.Length; i++)
            {
                string[] fileNameSplit = newSameFiles[i].Split('_');
                string fileName = null;
                for (int j = 0; j < fileNameSplit.Length - 1; j++)
                {
                    if (fileName == null)
                        fileName = fileNameSplit[j];
                    else
                        fileName += "_" + fileNameSplit[j];
                }

                //fileList1[i] = fileName + $".{System.IO.Path.GetExtension(fileList1[i])}"; // 확장자 포함
                inputFiles2[i] = fileName; // 확장자 미 포함
            }

            Task<string[]> searchAlgorithmStringTaskFiles = Task.Run(() => searchAlgorithmString.StringArraySearchManager(inputFiles1, cadImageSelect.CADNameGridList.ToArray(), searchAlgorithmCancellTokenSource.Token));
            Task<string[]> searchAlgorithmStringTaskNewSameFiles = Task.Run(() => searchAlgorithmString.StringArraySearchManager(inputFiles2, cadImageSelect.CADNameGridList.ToArray(), searchAlgorithmCancellTokenSource.Token));

            if (!mainForm.SafeVisiblePanel(mainForm.panelstatus))
                mainForm.SafeVisiblePanel(mainForm.panelstatus, true);
            mainForm.SafeWriteProgressBar(mainForm.pgbMfileIOstatus, totalFileNumber, 0);
            mainForm.SafeWriteLabelText(mainForm.lblMwaorkInNumber, "0");
            mainForm.SafeWriteLabelText(mainForm.lblMtotalNumber, totalFileNumber.ToString());
            mainForm.SafeWriteLabelText(mainForm.lblMIOStatus, "Pogressing");
            mainForm.SafeWriteLabelText(mainForm.lblMworkInFileName, "Image Matching");

            await searchAlgorithmStringTaskFiles;
            string[] searchDataArrayFiles = searchAlgorithmStringTaskFiles.Result;

            for (int i = 0; i < files.Length; i++)
            {
                if (i % 200 == 0)
                {
                    if (!mainForm.SafeVisiblePanel(mainForm.panelstatus))
                        mainForm.SafeVisiblePanel(mainForm.panelstatus, true);
                    mainForm.SafeWriteProgressBar(mainForm.pgbMfileIOstatus, totalFileNumber, workInNumber);
                    mainForm.SafeWriteLabelText(mainForm.lblMwaorkInNumber, workInNumber.ToString());
                    mainForm.SafeWriteLabelText(mainForm.lblMtotalNumber, totalFileNumber.ToString());
                    mainForm.SafeWriteLabelText(mainForm.lblMIOStatus, "Pogressing");
                    mainForm.SafeWriteLabelText(mainForm.lblMworkInFileName, Path.GetFileName(files[i])); 
                }
                workInNumber++;


                imageTotalNumber++;
                object imageData = new
                {
                    int_ImageNumber = imageTotalNumber,
                    string_ImagePath = Path.Combine(m_pathActiveProjectImage, files[i]),
                    Labeled = new JObject() { }
                };
                m_activeProjectDataImageListDataJObject[files[i].ToString()] = JObject.FromObject(imageData);
                WriteImageListData(cadImageSelect, labeledDatainnerProjectLabelName, CADImageFolder, files[i], searchDataArrayFiles[i]);
            }

            await searchAlgorithmStringTaskNewSameFiles;
            string[] searchDataArrayNewSameFiles = searchAlgorithmStringTaskNewSameFiles.Result;

            for (int i = 0; i < newSameFiles.Length; i++)
            {
                if (i % 200 == 0)
                {
                    mainForm.SafeWriteLabelText(mainForm.lblMwaorkInNumber, workInNumber.ToString());
                    mainForm.SafeWriteLabelText(mainForm.lblMtotalNumber, totalFileNumber.ToString());
                    mainForm.SafeWriteLabelText(mainForm.lblMIOStatus, "Pogressing");
                    mainForm.SafeWriteLabelText(mainForm.lblMworkInFileName, Path.GetFileName(files[i]));
                }
                workInNumber++;

                //WriteImageListData(cadImageSelect, labeledDatainnerProjectLabelName, CADImageFolder, newSameFiles[i], searchDataArrayNewSameFiles[i]);
            }
            mainForm.SafeWriteLabelText(mainForm.lblMIOStatus, "AllCompleted");
            mainForm.SafeVisiblePanel(mainForm.panelstatus, false);

            return imageTotalNumber;
        }
    }
}