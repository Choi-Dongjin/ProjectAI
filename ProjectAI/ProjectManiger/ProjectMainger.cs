using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        /// ProgramWokr Space 경로
        /// </summary>
        public static string m_workSpacDataPath = ProgramVariables.m_programWokrSpacePath;
        /// <summary>
        /// ProgramWokr Space Optin File 경로
        /// </summary>
        public static string m_workSpacDataFilePath = Path.Combine(ProgramVariables.m_programWokrSpacePath, "workspacesdata.Json");

        /// <summary>
        /// workSpaceEarlyData Jobject 관리
        /// </summary>
        public static JObject workSpaceEarlyDataJobject = new JObject();

        /// <summary>
        /// workSpace들의 이름 정보를 필요 처음으로 읽어서 각 workSpace의 데이터를 읽어오는데 사용
        /// </summary>
        public static List<string> m_workSpaceNameList = new List<string>();

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

        // ProgramVariables즉 StartForm, StartFormOptions에서 ProgramVariables값에 해당하는 값이 변경되면 호출 
        public static void ProgramVariablesChange()
        {
            m_workSpacDataPath = ProgramVariables.m_programWokrSpacePath;
            m_workSpacDataFilePath = Path.Combine(ProgramVariables.m_programWokrSpacePath, "workspacesdata.Json");
        }
    }
    /// <summary>
    /// WorkSpaceData 정보
    /// </summary>    
    public struct WorkSpaceData
    {

    }


    class ProjectMainger
    {

    }
}
