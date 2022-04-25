using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ProjectAI
{
    public static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            #region 프로그램 Entry Optins 파일 읽고 값 가져오기

            JsonDataManiger jsonDataManiger = JsonDataManiger.GetInstance(); // Json File 관리 Class

            #region StartForm, StartFormOptions 변경시를 관리 Update Handler 등록

            FormsManiger.m_startFormOptionsManagerHandler += Program.IfProgramEntryPointOptionsChange;
            FormsManiger.m_startFormOptionsManagerHandler += WorkSpaceEarlyData.ProgramVariablesChange;

            #endregion StartForm, StartFormOptions 변경시를 관리 Update Handler 등록

            if (jsonDataManiger.JsonChackFileAndCreate(ProgramEntryPointVariables.m_programEntryOptionsFileJsonPath)) // 프로그램 실행 옵션 설정 Json 파일 확인, 파일이 없다면 생성.
            {
                // 파일이 있으면 데이터 읽어오기
                JObject programEntryPointOptions = jsonDataManiger.GetJsonObject(ProgramEntryPointVariables.m_programEntryOptionsFileJsonPath, ProgramEntryPointOptionsDataIntegrityCheck); // programEntryPointOptions Json 파일 읽고 무결성 검사
                jsonDataManiger.PushJsonObject(ProgramEntryPointVariables.m_programEntryOptionsFileJsonPath, programEntryPointOptions); // Json 파일 저장

                var programEntryPointOptionsJson = programEntryPointOptions["programEntryPointOptions"];
                //Console.WriteLine(programEntryPointOptionsJson.ToString());

                // 데이터 처리
                ProgramEntryPointVariables.m_language = programEntryPointOptionsJson["string_m_language"].ToString();
                ProgramEntryPointVariables.m_prohramClassificationCorePath = programEntryPointOptionsJson["string_m_classificationPath"].DeepClone().ToString();
            }
            else
            {
                JObject programEntryPointOptions = ProgramEntryPointOptionsDefaltSetting(); // Entry Optins 값, 데이터 파일 초기화
                jsonDataManiger.PushJsonObject(ProgramEntryPointVariables.m_programEntryOptionsFileJsonPath, programEntryPointOptions); // Json 파일 저장
            }

            #endregion 프로그램 Entry Optins 파일 읽고 값 가져오기

            #region 프로그램 언어 설정

            Console.WriteLine(ProgramEntryPointVariables.m_language);
            if (ProgramEntryPointVariables.m_language == "en-US")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            }
            else if (ProgramEntryPointVariables.m_language == "ko-KR")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ko-KR");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ko-KR");
            }

            #endregion 프로그램 언어 설정

            // 프로그램 시작
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(StartForm.GetInstance());
        }

        /// <summary>
        /// ProgramEntryPointOptions JObject 다시 만들고 기본값으로 설정
        /// </summary>
        public static JObject ProgramEntryPointOptionsDefaltSetting()
        {
            object programEntryPointOptions = new
            {
                string_m_language = CultureInfo.CurrentCulture.Name, // 시스템 기본 언어 설정 가져오기
                string_m_classificationPath = ProgramEntryPointVariables.ProhramClassificationCorePathDefalt
            };

            JObject programEntryPointOptionsJson = JObject.FromObject(programEntryPointOptions);
            JObject programOptions = new JObject
            {
                { "programEntryPointOptions", programEntryPointOptionsJson }
            };
            return programOptions;
        }

        /// <summary>
        /// ProgramEntryPointOptions 값이 수정되면 변경되는 Componet 수정, Json 파일 수정
        /// </summary>
        public static void IfProgramEntryPointOptionsChange()
        {
            JsonDataManiger jsonDataManiger = JsonDataManiger.GetInstance(); // JsonDataManiger 호출

            string language = ProgramEntryPointVariables.m_language;
            string corePath = ProgramEntryPointVariables.m_prohramClassificationCorePath.ToString();

            JObject programEntryPoint = jsonDataManiger.GetJsonObject(ProgramEntryPointVariables.m_programEntryOptionsFileJsonPath, ProgramEntryPointOptionsDataIntegrityCheck); // programEntryPointOptions Json 파일 읽고 무결성 검사
            JObject programEntryPointOptions = (JObject)programEntryPoint["programEntryPointOptions"]; //  programEntryPointOptions 객체 있음을 확인

            // 값 반영
            programEntryPointOptions["string_m_language"] = language;
            programEntryPointOptions["string_m_classificationPath"] = corePath;

            // 옵션 추가시 작성
            jsonDataManiger.PushJsonObject(ProgramEntryPointVariables.m_programEntryOptionsFileJsonPath, programEntryPoint); // Json 파일 저장
        }

        /// <summary>
        /// ProgramEntryPointOptions Json 파일 데이터 무결성 검사
        /// </summary>
        /// <param name="jsonData"> 검사할 programEntryPoint 파일 JObject</param>
        public static JObject ProgramEntryPointOptionsDataIntegrityCheck(JObject programEntryPoint)
        {
            if (programEntryPoint != null) // jsonDataManiger에서 GetJsonObject을 타고 넘어온 programEntryPoint 객체가 데이터 읽기에 실패 하였는지 확인
            {
                //Console.WriteLine(programEntryPoint.ToString());

                #region programEntryPointOptions 관리

                if (programEntryPoint["programEntryPointOptions"] != null) // programEntryPointOptions 객체 확인
                {
                    //Console.WriteLine("1 ProgramEntryPointOptionsDataIntegrityCheck");
                    JObject programEntryPointOptions = (JObject)programEntryPoint["programEntryPointOptions"]; //  programEntryPointOptions 객체 있음을 확인

                    if (programEntryPointOptions["string_m_language"] == null) //  string_m_language 객체 없음을 확인
                        programEntryPointOptions.Add(new JProperty("string_m_language", $"{CultureInfo.CurrentCulture.Name}"));
                    else //  string_m_language 객체가 있을을 확인
                    {
                        string string_m_language = programEntryPointOptions["string_m_language"].ToString();
                        bool chack = (string_m_language == "ko-KR" || string_m_language == "en-US");
                        if (!chack) //  string_m_language 객체가 선택된 범위내에 값인지 확인
                        {
                            programEntryPointOptions["string_m_language"] = CultureInfo.CurrentCulture.Name; //  string_m_language 객체가 선택된 범위내에 값이 아니라면 값을 기본값으로 초기화
                            string_m_language = CultureInfo.CurrentCulture.Name;
                        }
                    }

                    if (programEntryPointOptions["string_m_classificationPath"] == null)
                        programEntryPointOptions.Add(new JProperty("string_m_classificationPath", $"{ProgramEntryPointVariables.ProhramClassificationCorePathDefalt}"));
                    else
                    {
                        ProgramEntryPointVariables.m_prohramClassificationCorePath = programEntryPointOptions["string_m_classificationPath"].DeepClone().ToString();
                    }
                }
                else // programEntryPointOptions 객체가 없음을 확인
                    programEntryPoint = ProgramEntryPointOptionsDefaltSetting(); // 데이터 초기값으로 생성.

                #endregion programEntryPointOptions 관리

                //Console.WriteLine(programEntryPoint.ToString());
                // 데이터 무결성 검사 완료
            }
            else
                programEntryPoint = ProgramEntryPointOptionsDefaltSetting(); // jsonDataManiger에서 GetJsonObject의 Json 파일이 손상된것을 확인 초기값으로 데이터 조정.

            return programEntryPoint;
        }
    }
}