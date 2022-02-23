namespace ProjectAI.MainForms
{
    partial class MakeWorkSpaceForm
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
            this.styleManagerMakeWorkSpaceForm = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tableLayoutStartOptionMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMworkSpaceName = new MetroFramework.Controls.MetroLabel();
            this.txtMworkSpaceName = new MetroFramework.Controls.MetroTextBox();
            this.btnMCancel = new MetroFramework.Controls.MetroButton();
            this.btnMOK = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.styleManagerMakeWorkSpaceForm)).BeginInit();
            this.tableLayoutStartOptionMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManagerMakeWorkSpaceForm
            // 
            this.styleManagerMakeWorkSpaceForm.Owner = null;
            // 
            // tableLayoutStartOptionMain
            // 
            this.tableLayoutStartOptionMain.ColumnCount = 4;
            this.tableLayoutStartOptionMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutStartOptionMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutStartOptionMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutStartOptionMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutStartOptionMain.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutStartOptionMain.Controls.Add(this.btnMCancel, 3, 1);
            this.tableLayoutStartOptionMain.Controls.Add(this.btnMOK, 2, 1);
            this.tableLayoutStartOptionMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutStartOptionMain.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutStartOptionMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutStartOptionMain.Name = "tableLayoutStartOptionMain";
            this.tableLayoutStartOptionMain.RowCount = 2;
            this.tableLayoutStartOptionMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutStartOptionMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutStartOptionMain.Size = new System.Drawing.Size(560, 109);
            this.tableLayoutStartOptionMain.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutStartOptionMain.SetColumnSpan(this.tableLayoutPanel1, 4);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblMworkSpaceName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMworkSpaceName, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(560, 74);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblMworkSpaceName
            // 
            this.lblMworkSpaceName.AutoSize = true;
            this.lblMworkSpaceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMworkSpaceName.Location = new System.Drawing.Point(3, 38);
            this.lblMworkSpaceName.Margin = new System.Windows.Forms.Padding(3);
            this.lblMworkSpaceName.Name = "lblMworkSpaceName";
            this.lblMworkSpaceName.Size = new System.Drawing.Size(169, 29);
            this.lblMworkSpaceName.TabIndex = 0;
            this.lblMworkSpaceName.Text = "metroLabel1";
            this.lblMworkSpaceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMworkSpaceName
            // 
            // 
            // 
            // 
            this.txtMworkSpaceName.CustomButton.Image = null;
            this.txtMworkSpaceName.CustomButton.Location = new System.Drawing.Point(351, 1);
            this.txtMworkSpaceName.CustomButton.Name = "";
            this.txtMworkSpaceName.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtMworkSpaceName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMworkSpaceName.CustomButton.TabIndex = 1;
            this.txtMworkSpaceName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMworkSpaceName.CustomButton.UseSelectable = true;
            this.txtMworkSpaceName.CustomButton.Visible = false;
            this.txtMworkSpaceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMworkSpaceName.Lines = new string[0];
            this.txtMworkSpaceName.Location = new System.Drawing.Point(178, 38);
            this.txtMworkSpaceName.MaxLength = 32767;
            this.txtMworkSpaceName.Name = "txtMworkSpaceName";
            this.txtMworkSpaceName.PasswordChar = '\0';
            this.txtMworkSpaceName.PromptText = "Work Space Name";
            this.txtMworkSpaceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMworkSpaceName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMworkSpaceName.SelectedText = "";
            this.txtMworkSpaceName.SelectionLength = 0;
            this.txtMworkSpaceName.SelectionStart = 0;
            this.txtMworkSpaceName.ShortcutsEnabled = true;
            this.txtMworkSpaceName.Size = new System.Drawing.Size(379, 29);
            this.txtMworkSpaceName.TabIndex = 1;
            this.txtMworkSpaceName.UseSelectable = true;
            this.txtMworkSpaceName.WaterMark = "Work Space Name";
            this.txtMworkSpaceName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMworkSpaceName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnMCancel
            // 
            this.btnMCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMCancel.Location = new System.Drawing.Point(461, 77);
            this.btnMCancel.Name = "btnMCancel";
            this.btnMCancel.Size = new System.Drawing.Size(96, 29);
            this.btnMCancel.TabIndex = 6;
            this.btnMCancel.Text = "Cancel (&C)";
            this.btnMCancel.UseSelectable = true;
            this.btnMCancel.Click += new System.EventHandler(this.BtnMCancelClick);
            // 
            // btnMOK
            // 
            this.btnMOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMOK.Location = new System.Drawing.Point(359, 77);
            this.btnMOK.Name = "btnMOK";
            this.btnMOK.Size = new System.Drawing.Size(96, 29);
            this.btnMOK.TabIndex = 5;
            this.btnMOK.Text = "OK (&O)";
            this.btnMOK.UseSelectable = true;
            this.btnMOK.Click += new System.EventHandler(this.BtnMOKClick);
            // 
            // MakeWorkSpaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 189);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutStartOptionMain);
            this.Name = "MakeWorkSpaceForm";
            this.Resizable = false;
            this.Text = "WorkSpace";
            ((System.ComponentModel.ISupportInitialize)(this.styleManagerMakeWorkSpaceForm)).EndInit();
            this.tableLayoutStartOptionMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager styleManagerMakeWorkSpaceForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutStartOptionMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton btnMOK;
        private MetroFramework.Controls.MetroButton btnMCancel;
        private MetroFramework.Controls.MetroLabel lblMworkSpaceName;
        private MetroFramework.Controls.MetroTextBox txtMworkSpaceName;
    }
}