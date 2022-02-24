namespace ProjectAI
{
    partial class StartForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.tableLayoutProjectAIMain = new System.Windows.Forms.TableLayoutPanel();
            this.PanelMainLogo = new MetroFramework.Controls.MetroPanel();
            this.tableLayoutMainIcons = new System.Windows.Forms.TableLayoutPanel();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.buttonStart = new MetroFramework.Controls.MetroButton();
            this.buttonStyleChange = new MetroFramework.Controls.MetroButton();
            this.buttonStartOption = new MetroFramework.Controls.MetroButton();
            this.tableLayoutMainIconPath = new System.Windows.Forms.TableLayoutPanel();
            this.labMprogramWorkSpacePath = new MetroFramework.Controls.MetroLabel();
            this.btnMprogramWorkSpaceChange = new MetroFramework.Controls.MetroButton();
            this.txtMprogramWorkSpacePath = new MetroFramework.Controls.MetroTextBox();
            this.styleManagerStartForm = new MetroFramework.Components.MetroStyleManager(this.components);
            this.styleExtenderStartForm = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.tableLayoutProjectAIMain.SuspendLayout();
            this.tableLayoutMainIcons.SuspendLayout();
            this.tableLayoutMainIconPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleManagerStartForm)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutProjectAIMain
            // 
            this.tableLayoutProjectAIMain.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.tableLayoutProjectAIMain, "tableLayoutProjectAIMain");
            this.tableLayoutProjectAIMain.Controls.Add(this.PanelMainLogo, 0, 0);
            this.tableLayoutProjectAIMain.Controls.Add(this.tableLayoutMainIcons, 1, 0);
            this.tableLayoutProjectAIMain.Name = "tableLayoutProjectAIMain";
            // 
            // PanelMainLogo
            // 
            this.PanelMainLogo.BackColor = System.Drawing.Color.Transparent;
            this.PanelMainLogo.BackgroundImage = global::ProjectAI.Properties.Resources.iconlogoB_X2;
            resources.ApplyResources(this.PanelMainLogo, "PanelMainLogo");
            this.PanelMainLogo.HorizontalScrollbarBarColor = true;
            this.PanelMainLogo.HorizontalScrollbarHighlightOnWheel = false;
            this.PanelMainLogo.HorizontalScrollbarSize = 10;
            this.PanelMainLogo.Name = "PanelMainLogo";
            this.PanelMainLogo.VerticalScrollbarBarColor = true;
            this.PanelMainLogo.VerticalScrollbarHighlightOnWheel = false;
            this.PanelMainLogo.VerticalScrollbarSize = 10;
            // 
            // tableLayoutMainIcons
            // 
            resources.ApplyResources(this.tableLayoutMainIcons, "tableLayoutMainIcons");
            this.tableLayoutMainIcons.Controls.Add(this.metroButton4, 2, 3);
            this.tableLayoutMainIcons.Controls.Add(this.buttonStart, 2, 1);
            this.tableLayoutMainIcons.Controls.Add(this.buttonStyleChange, 2, 7);
            this.tableLayoutMainIcons.Controls.Add(this.buttonStartOption, 2, 5);
            this.tableLayoutMainIcons.Controls.Add(this.tableLayoutMainIconPath, 0, 7);
            this.tableLayoutMainIcons.Name = "tableLayoutMainIcons";
            this.tableLayoutMainIcons.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutMainIcons_Paint);
            // 
            // metroButton4
            // 
            resources.ApplyResources(this.metroButton4, "metroButton4");
            this.metroButton4.Highlight = true;
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.ButtonExitClick);
            // 
            // buttonStart
            // 
            resources.ApplyResources(this.buttonStart, "buttonStart");
            this.buttonStart.Highlight = true;
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.UseSelectable = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStartClick);
            // 
            // buttonStyleChange
            // 
            resources.ApplyResources(this.buttonStyleChange, "buttonStyleChange");
            this.buttonStyleChange.Highlight = true;
            this.buttonStyleChange.Name = "buttonStyleChange";
            this.buttonStyleChange.UseSelectable = true;
            this.buttonStyleChange.Click += new System.EventHandler(this.ButtonStyleChangeClick);
            // 
            // buttonStartOption
            // 
            resources.ApplyResources(this.buttonStartOption, "buttonStartOption");
            this.buttonStartOption.Highlight = true;
            this.buttonStartOption.Name = "buttonStartOption";
            this.buttonStartOption.UseSelectable = true;
            this.buttonStartOption.Click += new System.EventHandler(this.ButtonStartOptionClick);
            // 
            // tableLayoutMainIconPath
            // 
            resources.ApplyResources(this.tableLayoutMainIconPath, "tableLayoutMainIconPath");
            this.tableLayoutMainIconPath.Controls.Add(this.labMprogramWorkSpacePath, 0, 0);
            this.tableLayoutMainIconPath.Controls.Add(this.btnMprogramWorkSpaceChange, 2, 0);
            this.tableLayoutMainIconPath.Controls.Add(this.txtMprogramWorkSpacePath, 1, 0);
            this.tableLayoutMainIconPath.Name = "tableLayoutMainIconPath";
            // 
            // labMprogramWorkSpacePath
            // 
            resources.ApplyResources(this.labMprogramWorkSpacePath, "labMprogramWorkSpacePath");
            this.labMprogramWorkSpacePath.BackColor = System.Drawing.Color.Transparent;
            this.labMprogramWorkSpacePath.FontSize = MetroFramework.MetroLabelSize.Small;
            this.labMprogramWorkSpacePath.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labMprogramWorkSpacePath.Name = "labMprogramWorkSpacePath";
            // 
            // btnMprogramWorkSpaceChange
            // 
            resources.ApplyResources(this.btnMprogramWorkSpaceChange, "btnMprogramWorkSpaceChange");
            this.btnMprogramWorkSpaceChange.Name = "btnMprogramWorkSpaceChange";
            this.btnMprogramWorkSpaceChange.UseSelectable = true;
            this.btnMprogramWorkSpaceChange.Click += new System.EventHandler(this.BtnMprogramWorkSpaceChangeClick);
            // 
            // txtMprogramWorkSpacePath
            // 
            // 
            // 
            // 
            this.txtMprogramWorkSpacePath.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.txtMprogramWorkSpacePath.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode")));
            this.txtMprogramWorkSpacePath.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.txtMprogramWorkSpacePath.CustomButton.Name = "";
            this.txtMprogramWorkSpacePath.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.txtMprogramWorkSpacePath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMprogramWorkSpacePath.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            this.txtMprogramWorkSpacePath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMprogramWorkSpacePath.CustomButton.UseSelectable = true;
            this.txtMprogramWorkSpacePath.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
            resources.ApplyResources(this.txtMprogramWorkSpacePath, "txtMprogramWorkSpacePath");
            this.txtMprogramWorkSpacePath.Lines = new string[0];
            this.txtMprogramWorkSpacePath.MaxLength = 32767;
            this.txtMprogramWorkSpacePath.Name = "txtMprogramWorkSpacePath";
            this.txtMprogramWorkSpacePath.PasswordChar = '\0';
            this.txtMprogramWorkSpacePath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMprogramWorkSpacePath.SelectedText = "";
            this.txtMprogramWorkSpacePath.SelectionLength = 0;
            this.txtMprogramWorkSpacePath.SelectionStart = 0;
            this.txtMprogramWorkSpacePath.ShortcutsEnabled = true;
            this.txtMprogramWorkSpacePath.UseSelectable = true;
            this.txtMprogramWorkSpacePath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMprogramWorkSpacePath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // styleManagerStartForm
            // 
            this.styleManagerStartForm.Owner = this;
            // 
            // StartForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.tableLayoutProjectAIMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.StartFormLoad);
            this.tableLayoutProjectAIMain.ResumeLayout(false);
            this.tableLayoutMainIcons.ResumeLayout(false);
            this.tableLayoutMainIconPath.ResumeLayout(false);
            this.tableLayoutMainIconPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleManagerStartForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutProjectAIMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMainIcons;
        private MetroFramework.Controls.MetroPanel PanelMainLogo;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton buttonStart;
        private MetroFramework.Controls.MetroButton buttonStyleChange;
        private MetroFramework.Controls.MetroButton buttonStartOption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMainIconPath;
        private MetroFramework.Controls.MetroLabel labMprogramWorkSpacePath;
        private MetroFramework.Controls.MetroButton btnMprogramWorkSpaceChange;
        private MetroFramework.Controls.MetroTextBox txtMprogramWorkSpacePath;
        private MetroFramework.Components.MetroStyleManager styleManagerStartForm;
        private MetroFramework.Components.MetroStyleExtender styleExtenderStartForm;
    }
}

