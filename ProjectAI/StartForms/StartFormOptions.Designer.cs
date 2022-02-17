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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMoptionLanguage = new MetroFramework.Controls.MetroLabel();
            this.lblMoptionReset = new MetroFramework.Controls.MetroLabel();
            this.btnMoptionReset = new MetroFramework.Controls.MetroButton();
            this.cmbMoptionLanguage = new MetroFramework.Controls.MetroComboBox();
            this.tableLayoutStartOptionMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnMstartOptionsOK = new MetroFramework.Controls.MetroButton();
            this.btnMstartOptionsCancel = new MetroFramework.Controls.MetroButton();
            this.btnMstartOptionsApply = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.styleManagerStartFormOptions)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutStartOptionMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManagerStartFormOptions
            // 
            this.styleManagerStartFormOptions.Owner = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutStartOptionMain.SetColumnSpan(this.tableLayoutPanel1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblMoptionLanguage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMoptionReset, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMoptionReset, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbMoptionLanguage, 2, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // lblMoptionLanguage
            // 
            resources.ApplyResources(this.lblMoptionLanguage, "lblMoptionLanguage");
            this.lblMoptionLanguage.Name = "lblMoptionLanguage";
            // 
            // lblMoptionReset
            // 
            resources.ApplyResources(this.lblMoptionReset, "lblMoptionReset");
            this.lblMoptionReset.Name = "lblMoptionReset";
            // 
            // btnMoptionReset
            // 
            resources.ApplyResources(this.btnMoptionReset, "btnMoptionReset");
            this.btnMoptionReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMoptionReset.Name = "btnMoptionReset";
            this.btnMoptionReset.UseSelectable = true;
            this.btnMoptionReset.Click += new System.EventHandler(this.BtnMoptionResetClick);
            // 
            // cmbMoptionLanguage
            // 
            resources.ApplyResources(this.cmbMoptionLanguage, "cmbMoptionLanguage");
            this.cmbMoptionLanguage.FormattingEnabled = true;
            this.cmbMoptionLanguage.Items.AddRange(new object[] {
            resources.GetString("cmbMoptionLanguage.Items"),
            resources.GetString("cmbMoptionLanguage.Items1")});
            this.cmbMoptionLanguage.Name = "cmbMoptionLanguage";
            this.cmbMoptionLanguage.UseSelectable = true;
            // 
            // tableLayoutStartOptionMain
            // 
            resources.ApplyResources(this.tableLayoutStartOptionMain, "tableLayoutStartOptionMain");
            this.tableLayoutStartOptionMain.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutStartOptionMain.Controls.Add(this.btnMstartOptionsOK, 1, 1);
            this.tableLayoutStartOptionMain.Controls.Add(this.btnMstartOptionsCancel, 2, 1);
            this.tableLayoutStartOptionMain.Controls.Add(this.btnMstartOptionsApply, 3, 1);
            this.tableLayoutStartOptionMain.Name = "tableLayoutStartOptionMain";
            // 
            // btnMstartOptionsOK
            // 
            resources.ApplyResources(this.btnMstartOptionsOK, "btnMstartOptionsOK");
            this.btnMstartOptionsOK.Name = "btnMstartOptionsOK";
            this.btnMstartOptionsOK.UseSelectable = true;
            this.btnMstartOptionsOK.Click += new System.EventHandler(this.BtnMstartOptionsOKClick);
            // 
            // btnMstartOptionsCancel
            // 
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
            this.Controls.Add(this.tableLayoutStartOptionMain);
            this.Name = "StartFormOptions";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartFormOptions_FormClosing);
            this.Load += new System.EventHandler(this.StartFormOptionsLoad);
            ((System.ComponentModel.ISupportInitialize)(this.styleManagerStartFormOptions)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutStartOptionMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager styleManagerStartFormOptions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroLabel lblMoptionLanguage;
        private MetroFramework.Controls.MetroLabel lblMoptionReset;
        private MetroFramework.Controls.MetroButton btnMoptionReset;
        private MetroFramework.Controls.MetroComboBox cmbMoptionLanguage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutStartOptionMain;
        private MetroFramework.Controls.MetroButton btnMstartOptionsOK;
        private MetroFramework.Controls.MetroButton btnMstartOptionsCancel;
        private MetroFramework.Controls.MetroButton btnMstartOptionsApply;
    }
}