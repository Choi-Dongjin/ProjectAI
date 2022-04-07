using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace ProjectAI
{
    /// <summary>
    /// 이 클레스를 직접 호출하지 마세요. 싱글톤 구조가 적용되어 있음. GetInstance를 호출 하여 Class 획득
    /// </summary>
    internal class JsonDataManiger
    {
        private static JsonDataManiger jsonDataManiger; // 싱글톤 패턴 구현을 위한 FormsManiger

        private JsonDataManiger()
        {
        }

        public static JsonDataManiger GetInstance()
        {
            if (jsonDataManiger == null)
                jsonDataManiger = new JsonDataManiger();

            return jsonDataManiger;
        }

        /// <summary>
        /// Json 파일 확인 기존의 파일이 있으면 true 반환 아니면 만들고 false반환
        /// </summary>
        /// <param name="chackJsonFilePath"> 확인 하려는 파일 Full path </param>
        /// <returns></returns>
        internal bool JsonChackFileAndCreate(string chackJsonFilePath)
        {
            if (!File.Exists(chackJsonFilePath))
            {
                using (File.Create(chackJsonFilePath))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Json 파일 읽고 jObject로 출력, Json 파일이 어떠한 이유에서든 손상되어 읽을수 없다면 Null을 반환 !!!!!! *** Null에 대한 회피코드를 무결성 코드에 추가할 것.
        /// </summary>
        /// <param name="jsonFilePath"></param>
        /// <returns></returns>
        internal JObject GetJsonObject(string jsonFilePath)
        {
            JObject jObject = new JObject();

            using (var stream = File.OpenText(jsonFilePath))
            using (JsonTextReader reader = new JsonTextReader(stream))
            {
                try
                {
                    jObject = (JObject)JToken.ReadFrom(reader);
                }
                catch (Newtonsoft.Json.JsonReaderException)
                {
                    jObject = null;
                }
                catch
                {
                    jObject = null;
                }
            }

            return jObject;
        }

        internal delegate JObject DataIntegrityCheckFuntionInputJObject(JObject jObject);

        /// <summary>
        /// Json 파일 읽고 Json 파일 데이터 무결성 검사 진행후(무결성 검사 함수가 필요) jObject로 출력, Json 파일이 어떠한 이유에서든 손상되어 읽을수 없다면 Null을 반환 !!!!!! *** Null에 대한 회피코드를 무결성 코드에 추가할 것.
        /// </summary>
        /// <param name="jsonFilePath"> 읽고 검사할 Json 파일 경로</param>
        /// <param name="dataIntegrityCheckFuntion"> 무결성 검사를 진행할 함수 인자로 jObject 넣기</param>
        /// <returns></returns>
        internal JObject GetJsonObject(string jsonFilePath, DataIntegrityCheckFuntionInputJObject dataIntegrityCheckFuntion)
        {
            JObject jObject = new JObject();

            using (var stream = File.OpenText(jsonFilePath))
            using (JsonTextReader reader = new JsonTextReader(stream))
            {
                try
                {
                    jObject = (JObject)JToken.ReadFrom(reader);
                }
                catch (Newtonsoft.Json.JsonReaderException)
                {
                    jObject = null;
                }
            }
            jObject = dataIntegrityCheckFuntion(jObject);
            return jObject;
        }

        internal JObject GetJsonObjectShare(string filePath)
        {
            JObject jObject;
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
                jObject = JObject.Parse(streamReader.ReadToEnd());
            }
            return jObject;
        }

        /// <summary>
        /// Json 파일 저장
        /// </summary>
        /// <param name="pishFilePath"> 저장 파일 경로</param>
        /// <param name="jObject"> 저장할 Json Object</param>
        internal void PushJsonObject(string pishFilePath, JObject jObject)
        {
            File.WriteAllText(pishFilePath, jObject.ToString());
        }
    }
}