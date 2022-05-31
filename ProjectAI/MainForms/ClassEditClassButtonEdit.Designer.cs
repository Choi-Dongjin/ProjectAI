namespace ProjectAI.MainForms
{
    partial class ClassEditClassButtonEdit
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMOK = new MetroFramework.Controls.MetroButton();
            this.btnMCancel = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tilMColor = new MetroFramework.Controls.MetroTile();
            this.txtMClassName = new MetroFramework.Controls.MetroTextBox();
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
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(313, 111);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 76);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(313, 35);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnMOK
            // 
            this.btnMOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMOK.Location = new System.Drawing.Point(112, 3);
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
            this.btnMCancel.Location = new System.Drawing.Point(214, 3);
            this.btnMCancel.Name = "btnMCancel";
            this.btnMCancel.Size = new System.Drawing.Size(96, 29);
            this.btnMCancel.TabIndex = 8;
            this.btnMCancel.Text = "Cancel (&C)";
            this.btnMCancel.UseSelectable = true;
            this.btnMCancel.Click += new System.EventHandler(this.BtnMCancelClick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tilMColor, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtMClassName, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(313, 76);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tilMColor
            // 
            this.tilMColor.ActiveControl = null;
            this.tilMColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilMColor.Location = new System.Drawing.Point(3, 3);
            this.tilMColor.Name = "tilMColor";
            this.tilMColor.Size = new System.Drawing.Size(307, 30);
            this.tilMColor.TabIndex = 3;
            this.tilMColor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tilMColor.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tilMColor.UseCustomBackColor = true;
            this.tilMColor.UseCustomForeColor = true;
            this.tilMColor.UseSelectable = true;
            this.tilMColor.UseStyleColors = true;
            this.tilMColor.Click += new System.EventHandler(this.TileMColorClick);
            // 
            // txtMClassName
            // 
            // 
            // 
            // 
            this.txtMClassName.CustomButton.Image = null;
            this.txtMClassName.CustomButton.Location = new System.Drawing.Point(279, 2);
            this.txtMClassName.CustomButton.Name = "";
            this.txtMClassName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtMClassName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMClassName.CustomButton.TabIndex = 1;
            this.txtMClassName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMClassName.CustomButton.UseSelectable = true;
            this.txtMClassName.CustomButton.Visible = false;
            this.txtMClassName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMClassName.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtMClassName.Lines = new string[0];
            this.txtMClassName.Location = new System.Drawing.Point(3, 39);
            this.txtMClassName.MaxLength = 32767;
            this.txtMClassName.Name = "txtMClassName";
            this.txtMClassName.PasswordChar = '\0';
            this.txtMClassName.PromptText = "Class Name";
            this.txtMClassName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMClassName.SelectedText = "";
            this.txtMClassName.SelectionLength = 0;
            this.txtMClassName.SelectionStart = 0;
            this.txtMClassName.ShortcutsEnabled = true;
            this.txtMClassName.Size = new System.Drawing.Size(307, 30);
            this.txtMClassName.TabIndex = 4;
            this.txtMClassName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMClassName.UseSelectable = true;
            this.txtMClassName.WaterMark = "Class Name";
            this.txtMClassName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMClassName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMClassName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMClassNameKeyDown);
            this.txtMClassName.Leave += new System.EventHandler(this.TxtMClassNameLeave);
            // 
            // ClassEditClassButtonEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 161);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassEditClassButtonEdit";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ClassEditClassButtonEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClassEditClassButtonEditFormClosing);
            this.Load += new System.EventHandler(this.ClassEditClassButtonEditLoad);
            this.Shown += new System.EventHandler(this.ClassEditClassButtonEditShown);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroButton btnMOK;
        private MetroFramework.Controls.MetroButton btnMCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MetroFramework.Controls.MetroTile tilMColor;
        private MetroFramework.Controls.MetroTextBox txtMClassName;
    }
}