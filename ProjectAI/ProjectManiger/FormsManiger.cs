using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace ProjectAI
{
    /// <summary>
    /// 이 클레스를 직접 호출하지 마세요. 싱글톤 구조가 적용되어 있음. GetInstance를 호출 하여 Class 획득
    /// </summary>
    public class FormsManiger
    {
        private static FormsManiger formsManiger; // 싱글톤 패턴 구현을 위한 FormsManiger

        // 각 Form Class 정의
        public StartForm startForm { get; set; }
        public StartForms.StartFormOptions startFormOptions { get; }
        public MainForms.MainForm mainForm { get; }

        public delegate void FormStyleManagerHandler(MetroStyleManager FormStyleManager); // Form Style 변경시를 관리 옵저버 패턴(변형) 구현을 위한 delegate
        public static FormStyleManagerHandler m_formStyleManagerHandler; // Form Style 관리 Update Handler

        public delegate void FormlanguageManagerHandler(string FormlanguageManager); // Form language 변경시를 관리 옵저버 패턴(변형) 구현을 위한 delegate
        public static FormlanguageManagerHandler m_formlanguageManagerHandler; // Form language 관리 Update Handler


        public delegate void StartFormOptionsManagerHandler(); // StartForm, StartFormOptions 변경시를 관리 옵저버 패턴(변형) 구현을 위한 delegate
        public static StartFormOptionsManagerHandler m_startFormOptionsManagerHandler; // StartForm, StartFormOptions 변경시를 관리 Update Handler

        public delegate void MainFormsUIResetHandler(); // MainForms UI 적용된 부분 모두 비활성화 변경시를 관리 옵저버 패턴(변형) 구현을 위한 delegate
        public static MainFormsUIResetHandler m_mainFormsUIResetHandler; // MainForms UI 적용된 부분 모두 비활성화를 관리 Update Handler

        // forms Dark Mode chacker
        public bool m_isDarkMode = true;
        public MetroStyleManager m_StyleManager = new MetroStyleManager();

        private FormsManiger()
        {
            this.startFormOptions = new StartForms.StartFormOptions();
            this.mainForm = new MainForms.MainForm();
        }
        
        /// <summary>
        /// Class 호출에 사용
        /// </summary>
        /// <returns></returns>
        public static FormsManiger GetInstance()
        {
            if (formsManiger == null)
            {
                FormsManiger.formsManiger = new FormsManiger();
            }
            return formsManiger;
        }

        /// <summary>
        /// 각 Forms Calss formStyleManager Update Handler 등록
        /// </summary>
        public void FormStyleManagerHandlerEnrollment()
        {
            // 각 해당 Class 에서 관리 하도록 수정
            //if (startForm != null)
            //    FormsManiger.m_formStyleManagerHandler += this.startForm.UpdataFormStyleManager;
            //FormsManiger.m_formStyleManagerHandler += this.startFormOptions.UpdataFormStyleManager;
            //FormsManiger.m_formStyleManagerHandler += this.mainForm.UpdataFormStyleManager;
        }

        /// <summary>
        /// 각 Forms Calss mformlanguageManagerHandler 등록
        /// </summary>
        public void FormlanguageManagerHandlerEnrollment()
        {

        }

        /// <summary>
        /// StartForm, StartFormOptions 변경시를 관리 Update Handler 등록
        /// </summary>
        public void StartFormOptionsManagerHandlerEnrollment()
        {
            // 각 해당 Class 에서 관리 하도록 수정
            //if (startForm != null)
            //    FormsManiger.m_startFormOptionsManagerHandler += this.startForm.IfStartOptionsChange;
            //FormsManiger.m_startFormOptionsManagerHandler += Program.IfProgramEntryPointOptionsChange;
            //FormsManiger.m_startFormOptionsManagerHandler += WorkSpaceEarlyData.ProgramVariablesChange;
        }


        internal System.Drawing.Color GetStyleRGBClor(string colorName)
        {
            Color color = new Color();

            if (colorName == "Lime") { color = Color.FromArgb(142, 188, 0); }
            else if (colorName == "Silver") { color = Color.FromArgb(85, 85, 85); }
            return color;
        }
        internal System.Drawing.Color GetThemeRGBClor(string colorName)
        {
            Color color = new Color();

            if (colorName == "Light") { color = Color.FromArgb(255, 255, 255); }
            else if (colorName == "Dark") { color = Color.FromArgb(17, 17, 17); }
            return color;
        }
    }
}
