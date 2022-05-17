namespace ProjectAI.StartForms
{
    partial class StartFormOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartFormOptions));
            this.styleManagerStartFormOptions = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tlpSystemOption = new System.Windows.Forms.TableLayoutPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblMoptionLanguage = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.cmbMoptionLanguage = new MetroFramework.Controls.MetroComboBox();
            this.btnMGetSystemInfo = new MetroFramework.Controls.MetroButton();
            this.lblMoptionReset = new MetroFramework.Controls.MetroLabel();
            this.btnMoptionReset = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.togMgpuSetting = new MetroFramework.Controls.MetroToggle();
            this.tlpgpuSetting = new System.Windows.Forms.TableLayoutPanel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cmbMdetectedGPU = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.lblMGpuName = new MetroFramework.Controls.MetroLabel();
            this.lblMAdapterDACType = new MetroFramework.Controls.MetroLabel();
            this.lblMDriverVersion = new MetroFramework.Controls.MetroLabel();
            this.lblVideoProcessor = new MetroFramework.Controls.MetroLabel();
            this.txtMAdapterRAM = new MetroFramework.Controls.MetroTextBox();
            this.tableLayoutStartOptionMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnMstartOptionsOK = new MetroFramework.Controls.MetroButton();
            this.btnMstartOptionsCancel = new MetroFramework.Controls.MetroButton();
            this.btnMstartOptionsApply = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.styleManagerStartFormOptions)).BeginInit();
            this.tlpSystemOption.SuspendLayout();
            this.tlpgpuSetting.SuspendLayout();
            this.tableLayoutStartOptionMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManagerStartFormOptions
            // 
            this.styleManagerStartFormOptions.Owner = this;
            // 
            // tlpSystemOption
            // 
            this.tlpSystemOption.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.tlpSystemOption, "tlpSystemOption");
            this.tableLayoutStartOptionMain.SetColumnSpan(this.tlpSystemOption, 4);
            this.tlpSystemOption.Controls.Add(this.metroLabel1, 0, 4);
            this.tlpSystemOption.Controls.Add(this.lblMoptionLanguage, 0, 3);
            this.tlpSystemOption.Controls.Add(this.metroLabel2, 0, 2);
            this.tlpSystemOption.Controls.Add(this.cmbMoptionLanguage, 2, 3);
            this.tlpSystemOption.Controls.Add(this.btnMGetSystemInfo, 2, 2);
            this.tlpSystemOption.Controls.Add(this.lblMoptionReset, 0, 1);
            this.tlpSystemOption.Controls.Add(this.btnMoptionReset, 2, 1);
            this.tlpSystemOption.Controls.Add(this.metroLabel3, 0, 0);
            this.tlpSystemOption.Controls.Add(this.togMgpuSetting, 2, 4);
            this.tlpSystemOption.Controls.Add(this.tlpgpuSetting, 0, 5);
            this.tlpSystemOption.Name = "tlpSystemOption";
            // 
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Name = "metroLabel1";
            // 
            // lblMoptionLanguage
            // 
            resources.ApplyResources(this.lblMoptionLanguage, "lblMoptionLanguage");
            this.lblMoptionLanguage.Name = "lblMoptionLanguage";
            // 
            // metroLabel2
            // 
            resources.ApplyResources(this.metroLabel2, "metroLabel2");
            this.metroLabel2.Name = "metroLabel2";
            // 
            // cmbMoptionLanguage
            // 
            this.cmbMoptionLanguage.FormattingEnabled = true;
            resources.ApplyResources(this.cmbMoptionLanguage, "cmbMoptionLanguage");
            this.cmbMoptionLanguage.Items.AddRange(new object[] {
            resources.GetString("cmbMoptionLanguage.Items"),
            resources.GetString("cmbMoptionLanguage.Items1")});
            this.cmbMoptionLanguage.Name = "cmbMoptionLanguage";
            this.cmbMoptionLanguage.UseSelectable = true;
            // 
            // btnMGetSystemInfo
            // 
            this.btnMGetSystemInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.btnMGetSystemInfo, "btnMGetSystemInfo");
            this.btnMGetSystemInfo.Name = "btnMGetSystemInfo";
            this.btnMGetSystemInfo.UseSelectable = true;
            this.btnMGetSystemInfo.Click += new System.EventHandler(this.BtnMGetSystemInfoClick);
            // 
            // lblMoptionReset
            // 
            resources.ApplyResources(this.lblMoptionReset, "lblMoptionReset");
            this.lblMoptionReset.Name = "lblMoptionReset";
            // 
            // btnMoptionReset
            // 
            this.btnMoptionReset.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.btnMoptionReset, "btnMoptionReset");
            this.btnMoptionReset.Name = "btnMoptionReset";
            this.btnMoptionReset.UseSelectable = true;
            this.btnMoptionReset.Click += new System.EventHandler(this.BtnMoptionResetClick);
            // 
            // metroLabel3
            // 
            resources.ApplyResources(this.metroLabel3, "metroLabel3");
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Name = "metroLabel3";
            // 
            // togMgpuSetting
            // 
            resources.ApplyResources(this.togMgpuSetting, "togMgpuSetting");
            this.togMgpuSetting.Name = "togMgpuSetting";
            this.togMgpuSetting.UseSelectable = true;
            this.togMgpuSetting.CheckedChanged += new System.EventHandler(this.TogMgpuSettingCheckedChanged);
            // 
            // tlpgpuSetting
            // 
            resources.ApplyResources(this.tlpgpuSetting, "tlpgpuSetting");
            this.tlpSystemOption.SetColumnSpan(this.tlpgpuSetting, 3);
            this.tlpgpuSetting.Controls.Add(this.metroLabel4, 0, 0);
            this.tlpgpuSetting.Controls.Add(this.metroLabel5, 0, 1);
            this.tlpgpuSetting.Controls.Add(this.cmbMdetectedGPU, 2, 0);
            this.tlpgpuSetting.Controls.Add(this.metroLabel6, 0, 2);
            this.tlpgpuSetting.Controls.Add(this.metroLabel7, 0, 3);
            this.tlpgpuSetting.Controls.Add(this.metroLabel8, 0, 4);
            this.tlpgpuSetting.Controls.Add(this.metroLabel10, 0, 5);
            this.tlpgpuSetting.Controls.Add(this.lblMGpuName, 2, 1);
            this.tlpgpuSetting.Controls.Add(this.lblMAdapterDACType, 2, 3);
            this.tlpgpuSetting.Controls.Add(this.lblMDriverVersion, 2, 4);
            this.tlpgpuSetting.Controls.Add(this.lblVideoProcessor, 2, 5);
            this.tlpgpuSetting.Controls.Add(this.txtMAdapterRAM, 2, 2);
            this.tlpgpuSetting.Name = "tlpgpuSetting";
            // 
            // metroLabel4
            // 
            resources.ApplyResources(this.metroLabel4, "metroLabel4");
            this.metroLabel4.Name = "metroLabel4";
            // 
            // metroLabel5
            // 
            resources.ApplyResources(this.metroLabel5, "metroLabel5");
            this.metroLabel5.Name = "metroLabel5";
            // 
            // cmbMdetectedGPU
            // 
            resources.ApplyResources(this.cmbMdetectedGPU, "cmbMdetectedGPU");
            this.cmbMdetectedGPU.FormattingEnabled = true;
            this.cmbMdetectedGPU.Name = "cmbMdetectedGPU";
            this.cmbMdetectedGPU.UseSelectable = true;
            this.cmbMdetectedGPU.SelectedIndexChanged += new System.EventHandler(this.CmbMdetectedGPUSelectedIndexChanged);
            // 
            // metroLabel6
            // 
            resources.ApplyResources(this.metroLabel6, "metroLabel6");
            this.metroLabel6.Name = "metroLabel6";
            // 
            // metroLabel7
            // 
            resources.ApplyResources(this.metroLabel7, "metroLabel7");
            this.metroLabel7.Name = "metroLabel7";
            // 
            // metroLabel8
            // 
            resources.ApplyResources(this.metroLabel8, "metroLabel8");
            this.metroLabel8.Name = "metroLabel8";
            // 
            // metroLabel10
            // 
            resources.ApplyResources(this.metroLabel10, "metroLabel10");
            this.metroLabel10.Name = "metroLabel10";
            // 
            // lblMGpuName
            // 
            resources.ApplyResources(this.lblMGpuName, "lblMGpuName");
            this.lblMGpuName.Name = "lblMGpuName";
            // 
            // lblMAdapterDACType
            // 
            resources.ApplyResources(this.lblMAdapterDACType, "lblMAdapterDACType");
            this.lblMAdapterDACType.Name = "lblMAdapterDACType";
            // 
            // lblMDriverVersion
            // 
            resources.ApplyResources(this.lblMDriverVersion, "lblMDriverVersion");
            this.lblMDriverVersion.Name = "lblMDriverVersion";
            // 
            // lblVideoProcessor
            // 
            resources.ApplyResources(this.lblVideoProcessor, "lblVideoProcessor");
            this.lblVideoProcessor.Name = "lblVideoProcessor";
            // 
            // txtMAdapterRAM
            // 
            resources.ApplyResources(this.txtMAdapterRAM, "txtMAdapterRAM");
            // 
            // 
            // 
            this.txtMAdapterRAM.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.txtMAdapterRAM.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.txtMAdapterRAM.CustomButton.Name = "";
            this.txtMAdapterRAM.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.txtMAdapterRAM.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMAdapterRAM.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            this.txtMAdapterRAM.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMAdapterRAM.CustomButton.UseSelectable = true;
            this.txtMAdapterRAM.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
            this.txtMAdapterRAM.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtMAdapterRAM.Lines = new string[0];
            this.txtMAdapterRAM.MaxLength = 32767;
            this.txtMAdapterRAM.Name = "txtMAdapterRAM";
            this.txtMAdapterRAM.PasswordChar = '\0';
            this.txtMAdapterRAM.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMAdapterRAM.SelectedText = "";
            this.txtMAdapterRAM.SelectionLength = 0;
            this.txtMAdapterRAM.SelectionStart = 0;
            this.txtMAdapterRAM.ShortcutsEnabled = true;
            this.txtMAdapterRAM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMAdapterRAM.UseSelectable = true;
            this.txtMAdapterRAM.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMAdapterRAM.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tableLayoutStartOptionMain
            // 
            resources.ApplyResources(this.tableLayoutStartOptionMain, "tableLayoutStartOptionMain");
            this.tableLayoutStartOptionMain.Controls.Add(this.tlpSystemOption, 0, 0);
            this.tableLayoutStartOptionMain.Controls.Add(this.btnMstartOptionsOK, 1, 1);
            this.tableLayoutStartOptionMain.Controls.Add(this.btnMstartOptionsCancel, 2, 1);
            this.tableLayoutStartOptionMain.Controls.Add(this.btnMstartOptionsApply, 3, 1);
            this.tableLayoutStartOptionMain.Name = "tableLayoutStartOptionMain";
            // 
            // btnMstartOptionsOK
            // 
            this.btnMstartOptionsOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnMstartOptionsOK, "btnMstartOptionsOK");
            this.btnMstartOptionsOK.Name = "btnMstartOptionsOK";
            this.btnMstartOptionsOK.UseSelectable = true;
            this.btnMstartOptionsOK.Click += new System.EventHandler(this.BtnMstartOptionsOKClick);
            // 
            // btnMstartOptionsCancel
            // 
            this.btnMstartOptionsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnMstartOptionsCancel, "btnMstartOptionsCancel");
            this.btnMstartOptionsCancel.Name = "btnMstartOptionsCancel";
            this.btnMstartOptionsCancel.UseSelectable = true;
            this.btnMstartOptionsCancel.Click += new System.EventHandler(this.BtnMstartOptionsCancelClick);
            // 
            // btnMstartOptionsApply
            // 
            resources.ApplyResources(this.btnMstartOptionsApply, "btnMstartOptionsApply");
            this.btnMstartOptionsApply.Name = "btnMstartOptionsApply";
            this.btnMstartOptionsApply.UseSelectable = true;
            this.btnMstartOptionsApply.Click += new System.EventHandler(this.BtnMstartOptionsApplyClick);
            // 
            // StartFormOptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutStartOptionMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartFormOptions";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartFormOptions_FormClosing);
            this.Load += new System.EventHandler(this.StartFormOptionsLoad);
            ((System.ComponentModel.ISupportInitialize)(this.styleManagerStartFormOptions)).EndInit();
            this.tlpSystemOption.ResumeLayout(false);
            this.tlpSystemOption.PerformLayout();
            this.tlpgpuSetting.ResumeLayout(false);
            this.tlpgpuSetting.PerformLayout();
            this.tableLayoutStartOptionMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager styleManagerStartFormOptions;
        private System.Windows.Forms.TableLayoutPanel tlpSystemOption;
        private MetroFramework.Controls.MetroLabel lblMoptionLanguage;
        private MetroFramework.Controls.MetroLabel lblMoptionReset;
        private MetroFramework.Controls.MetroButton btnMoptionReset;
        private MetroFramework.Controls.MetroComboBox cmbMoptionLanguage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutStartOptionMain;
        private MetroFramework.Controls.MetroButton btnMstartOptionsOK;
        private MetroFramework.Controls.MetroButton btnMstartOptionsCancel;
        private MetroFramework.Controls.MetroButton btnMstartOptionsApply;
        private MetroFramework.Controls.MetroButton btnMGetSystemInfo;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroToggle togMgpuSetting;
        private System.Windows.Forms.TableLayoutPanel tlpgpuSetting;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cmbMdetectedGPU;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel lblMGpuName;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel lblMAdapterDACType;
        private MetroFramework.Controls.MetroLabel lblMDriverVersion;
        private MetroFramework.Controls.MetroLabel lblVideoProcessor;
        private MetroFramework.Controls.MetroTextBox txtMAdapterRAM;
    }
}