using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace ProjectAI.StartForms
{
    public partial class StartFormOptions : MetroForm
    {
        /// <summary>
        /// 싱글톤 패턴 구현
        /// </summary>
        private static StartFormOptions startFormOptions;

        /// <summary>
        /// 싱글톤 패턴 Class 호출에 사용
        /// </summary>
        /// <returns></returns>
        public static StartFormOptions GetInstance()
        {
            if (StartFormOptions.startFormOptions == null)
            {
                StartFormOptions.startFormOptions = new StartFormOptions();
            }
            return StartFormOptions.startFormOptions;
        }

        private readonly JsonDataManiger jsonDataManiger = JsonDataManiger.GetInstance(); // Json File 관리 Class

        public StartFormOptions()
        {
            InitializeComponent();

            this.StyleManager = styleManagerStartFormOptions;
            // Forms Calss formStyleManagerHandler 등록
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
        }

        private void StartFormOptionsLoad(object sender, EventArgs e)
        {
            StartFormOptionsComponentSeting(); // StartForm 시작전 Component에 기본 값 설정
        }

        /// <summary>
        /// StartForm 시작전 Component에 기본 값 설정
        /// </summary>
        private void StartFormOptionsComponentSeting()
        {
            cmbMoptionLanguage.Text = ProgramEntryPointVariables.m_language;
        }

        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            this.StyleManager.Style = styleManager.Style;
            this.StyleManager.Theme = styleManager.Theme;
        }

        private void StartFormOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Hiding the window, because closing it makes the window unaccessible.
            this.Hide();
            this.Parent = null;
            e.Cancel = true; //hides the form, cancels closing event
        }

        private void BtnMstartOptionsApplyClick(object sender, EventArgs e)
        {
            ProgramEntryPointVariables.m_language = cmbMoptionLanguage.Text;

            FormsManiger.m_startFormOptionsManagerHandler(); // StartFormOptions 변경사항 반영
        }

        private void BtnMstartOptionsCancelClick(object sender, EventArgs e)
        {
            //Hiding the window, because closing it makes the window unaccessible.
            this.Hide();
            this.Parent = null;
        }

        private void BtnMstartOptionsOKClick(object sender, EventArgs e)
        {
            BtnMstartOptionsApplyClick(sender, e);
            //Hiding the window, because closing it makes the window unaccessible.
            this.Hide();
            this.Parent = null;
        }

        private void BtnMoptionResetClick(object sender, EventArgs e)
        {
            ProgramVariables.m_programWokrSpacePath = ProgramVariables.ProgramWokrSpacePath_Defalt;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //FormsManiger formsManiger = FormsManiger.GetInstance();
            //for (int i=0; i<3; i++)
            //{
            //    formsManiger.CustomIOManigerFoem.CreateFileCopyList(i);
            //}
        }
    }
}
