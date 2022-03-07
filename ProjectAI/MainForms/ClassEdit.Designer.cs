namespace ProjectAI.MainForms
{
    partial class ClassEdit
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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMOK = new MetroFramework.Controls.MetroButton();
            this.btnMCancel = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMClassAdd = new MetroFramework.Controls.MetroButton();
            this.btnMClassColor = new MetroFramework.Controls.MetroButton();
            this.txtMClassName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.panelMClassButton = new MetroFramework.Controls.MetroPanel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelMClassButton, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(393, 408);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel2.Controls.Add(this.btnMOK, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnMCancel, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 373);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(393, 35);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnMOK
            // 
            this.btnMOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMOK.Location = new System.Drawing.Point(192, 3);
            this.btnMOK.Name = "btnMOK";
            this.btnMOK.Size = new System.Drawing.Size(96, 29);
            this.btnMOK.TabIndex = 7;
            this.btnMOK.Text = "OK (&O)";
            this.btnMOK.UseSelectable = true;
            this.btnMOK.Click += new System.EventHandler(this.BtnMOKClick);
            // 
            // btnMCancel
            // 
            this.btnMCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMCancel.Location = new System.Drawing.Point(294, 3);
            this.btnMCancel.Name = "btnMCancel";
            this.btnMCancel.Size = new System.Drawing.Size(96, 29);
            this.btnMCancel.TabIndex = 8;
            this.btnMCancel.Text = "Cancel (&C)";
            this.btnMCancel.UseSelectable = true;
            this.btnMCancel.Click += new System.EventHandler(this.BtnMCancelClick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel3.Controls.Add(this.btnMClassAdd, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnMClassColor, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtMClassName, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(393, 35);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnMClassAdd
            // 
            this.btnMClassAdd.Location = new System.Drawing.Point(345, 3);
            this.btnMClassAdd.Name = "btnMClassAdd";
            this.btnMClassAdd.Size = new System.Drawing.Size(45, 29);
            this.btnMClassAdd.TabIndex = 8;
            this.btnMClassAdd.Text = "Add";
            this.btnMClassAdd.UseSelectable = true;
            this.btnMClassAdd.Click += new System.EventHandler(this.BtnMClassAddClick);
            // 
            // btnMClassColor
            // 
            this.btnMClassColor.Location = new System.Drawing.Point(294, 3);
            this.btnMClassColor.Name = "btnMClassColor";
            this.btnMClassColor.Size = new System.Drawing.Size(45, 29);
            this.btnMClassColor.TabIndex = 9;
            this.btnMClassColor.Text = "Color";
            this.btnMClassColor.UseSelectable = true;
            this.btnMClassColor.Click += new System.EventHandler(this.BtnMClassColorClick);
            // 
            // txtMClassName
            // 
            // 
            // 
            // 
            this.txtMClassName.CustomButton.Image = null;
            this.txtMClassName.CustomButton.Location = new System.Drawing.Point(257, 1);
            this.txtMClassName.CustomButton.Name = "";
            this.txtMClassName.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtMClassName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMClassName.CustomButton.TabIndex = 1;
            this.txtMClassName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMClassName.CustomButton.UseSelectable = true;
            this.txtMClassName.CustomButton.Visible = false;
            this.txtMClassName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMClassName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtMClassName.Lines = new string[0];
            this.txtMClassName.Location = new System.Drawing.Point(3, 3);
            this.txtMClassName.MaxLength = 32767;
            this.txtMClassName.Name = "txtMClassName";
            this.txtMClassName.PasswordChar = '\0';
            this.txtMClassName.PromptText = "Add Class Name";
            this.txtMClassName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMClassName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMClassName.SelectedText = "";
            this.txtMClassName.SelectionLength = 0;
            this.txtMClassName.SelectionStart = 0;
            this.txtMClassName.ShortcutsEnabled = true;
            this.txtMClassName.Size = new System.Drawing.Size(285, 29);
            this.txtMClassName.TabIndex = 10;
            this.txtMClassName.UseSelectable = true;
            this.txtMClassName.WaterMark = "Add Class Name";
            this.txtMClassName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMClassName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(3, 35);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(387, 25);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Select Class";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMClassButton
            // 
            this.panelMClassButton.AutoScroll = true;
            this.panelMClassButton.AutoScrollMinSize = new System.Drawing.Size(393, 313);
            this.panelMClassButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMClassButton.HorizontalScrollbar = true;
            this.panelMClassButton.HorizontalScrollbarBarColor = true;
            this.panelMClassButton.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMClassButton.HorizontalScrollbarSize = 10;
            this.panelMClassButton.Location = new System.Drawing.Point(0, 60);
            this.panelMClassButton.Margin = new System.Windows.Forms.Padding(0);
            this.panelMClassButton.Name = "panelMClassButton";
            this.panelMClassButton.Size = new System.Drawing.Size(393, 313);
            this.panelMClassButton.TabIndex = 3;
            this.panelMClassButton.VerticalScrollbar = true;
            this.panelMClassButton.VerticalScrollbarBarColor = true;
            this.panelMClassButton.VerticalScrollbarHighlightOnWheel = false;
            this.panelMClassButton.VerticalScrollbarSize = 10;
            // 
            // ClassEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 488);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassEdit";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ClassEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClassEditFormClosing);
            this.Load += new System.EventHandler(this.ClassEditLoad);
            this.Shown += new System.EventHandler(this.ClassEditShown);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroButton btnMOK;
        private MetroFramework.Controls.MetroButton btnMCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MetroFramework.Controls.MetroButton btnMClassAdd;
        private MetroFramework.Controls.MetroButton btnMClassColor;
        private MetroFramework.Controls.MetroTextBox txtMClassName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel panelMClassButton;
    }
}