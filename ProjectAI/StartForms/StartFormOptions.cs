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

        private Size defaultSize = new Size(600, 300);

        public StartFormOptions()
        {
            InitializeComponent();

            this.StyleManager = this.styleManagerStartFormOptions;
            // Forms Calss formStyleManagerHandler 등록
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;

            // 초기 UI SetUP
            this.Size = this.defaultSize;
            this.ActiveControl = this.btnMstartOptionsOK;
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
            ProgramVariables.m_programWokrSpacePath = ProgramVariables.ProgramWokrSpacePathDefalt;
            ProgramEntryPointVariables.m_prohramClassificationCorePath = ProgramEntryPointVariables.ProhramClassificationCorePathDefalt;
        }

        private void MetroButton1Click(object sender, EventArgs e)
        {
            ProjectAI.ProjectManiger.CustomIOManigerFoem customIOManigerFoem = ProjectAI.ProjectManiger.CustomIOManigerFoem.GetInstance();

            MainForms.MainForm mainForm = MainForms.MainForm.GetInstance();
            mainForm.panelstatus.Visible = true;

            for (int i = 0; i < 3; i++)
            {
                //customIOManigerFoem.CreateFileCopyList(i, mainForm.pgbMfileIOstatus);
            }
        }

        private void BtnMGetSystemInfoClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.ValidateNames = false;
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;
                openFileDialog.FileName = "Folder Selection.";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                    folderPath = System.IO.Path.Combine(folderPath, "HardwareInfo.Json");
                    HardwareInformation.GetHardwareInformation();
                    jsonDataManiger.PushJsonObject(folderPath, HardwareInformation.systemHardwareInfoJObject);
                }
            }
        }

        private void TogMgpuSettingCheckedChanged(object sender, EventArgs e)
        {
            if (togMgpuSetting.Checked)
            {
                ProjectAI.CustomMessageBox.CustomMessageBoxOKCancel customMessageBoxOKCancel = new CustomMessageBox.CustomMessageBoxOKCancel(MessageBoxIcon.Warning);
                if (customMessageBoxOKCancel.ShowDialog().Equals(DialogResult.OK))
                {
                    this.GpuSetting();
                    this.Size = new Size(600, this.defaultSize.Height + this.tlpgpuSetting.Height);
                }
                else
                {
                    this.togMgpuSetting.Checked = false;
                }
            }
            else
            {
                this.Size = this.defaultSize;
            }
        }

        private void GpuSetting()
        {
            this.tlpSystemOption.RowStyles[5].Height = 210;
            HardwareInformation.GetHardwareInformation();
            foreach (JProperty gpuName in HardwareInformation.systemHardwareInfoJObject["GRAPHIC"])
            {
                this.cmbMdetectedGPU.Items.Add(gpuName.Name);
            }
        }

        private void CmbMdetectedGPUSelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.cmbMdetectedGPU.Text);
            this.lblMGpuName.Text = HardwareInformation.systemHardwareInfoJObject["GRAPHIC"][this.cmbMdetectedGPU.Text]["Name"].ToString();
            this.txtMAdapterRAM.Text = HardwareInformation.systemHardwareInfoJObject["GRAPHIC"][this.cmbMdetectedGPU.Text]["AdapterRAM"].ToString();
            this.lblMAdapterDACType.Text = HardwareInformation.systemHardwareInfoJObject["GRAPHIC"][this.cmbMdetectedGPU.Text]["AdapterDACType"].ToString();
            this.lblMDriverVersion.Text = HardwareInformation.systemHardwareInfoJObject["GRAPHIC"][this.cmbMdetectedGPU.Text]["DriverVersion"].ToString();
            this.lblVideoProcessor.Text = HardwareInformation.systemHardwareInfoJObject["GRAPHIC"][this.cmbMdetectedGPU.Text]["VideoProcessor"].ToString();
        }
    }
}