namespace ProjectAI.MainForms.UserContral.ProjectSelect
{
    partial class Classification
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Classification));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTitle = new MetroFramework.Controls.MetroTextBox();
            this.lblClassificationINFO = new System.Windows.Forms.Label();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.lblInputDataType = new System.Windows.Forms.Label();
            this.metroStyleManagerClassification = new MetroFramework.Components.MetroStyleManager(this.components);
            this.btnNoneImage = new ProjectAI.MainForms.UserContral.ProjectSelect.ImputDataTypeButton();
            this.btnMultiImage = new ProjectAI.MainForms.UserContral.ProjectSelect.ImputDataTypeButton();
            this.btnSingleImage = new ProjectAI.MainForms.UserContral.ProjectSelect.ImputDataTypeButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManagerClassification)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 560F));
            this.tableLayoutPanel1.Controls.Add(this.txtTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblClassificationINFO, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.metroPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.metroPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblInputDataType, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(845, 260);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // txtTitle
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtTitle, 2);
            // 
            // 
            // 
            this.txtTitle.CustomButton.Image = null;
            this.txtTitle.CustomButton.Location = new System.Drawing.Point(813, 2);
            this.txtTitle.CustomButton.Name = "";
            this.txtTitle.CustomButton.Size = new System.Drawing.Size(29, 29);
            this.txtTitle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTitle.CustomButton.TabIndex = 1;
            this.txtTitle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTitle.CustomButton.UseSelectable = true;
            this.txtTitle.CustomButton.Visible = false;
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtTitle.Lines = new string[0];
            this.txtTitle.Location = new System.Drawing.Point(0, 3);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.txtTitle.MaxLength = 32767;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PasswordChar = '\0';
            this.txtTitle.PromptText = "Classification";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTitle.SelectedText = "";
            this.txtTitle.SelectionLength = 0;
            this.txtTitle.SelectionStart = 0;
            this.txtTitle.ShortcutsEnabled = true;
            this.txtTitle.Size = new System.Drawing.Size(845, 34);
            this.txtTitle.TabIndex = 5;
            this.txtTitle.UseSelectable = true;
            this.txtTitle.WaterMark = "Classification";
            this.txtTitle.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTitle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblClassificationINFO
            // 
            this.lblClassificationINFO.AutoSize = true;
            this.lblClassificationINFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassificationINFO.Location = new System.Drawing.Point(3, 43);
            this.lblClassificationINFO.Margin = new System.Windows.Forms.Padding(3);
            this.lblClassificationINFO.Name = "lblClassificationINFO";
            this.lblClassificationINFO.Size = new System.Drawing.Size(144, 19);
            this.lblClassificationINFO.TabIndex = 3;
            this.lblClassificationINFO.Text = "Classification INFO";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroTextBox1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 65);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(285, 190);
            this.metroPanel1.TabIndex = 7;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(97, 2);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(185, 185);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBox1.Lines = new string[] {
        resources.GetString("metroTextBox1.Lines")};
            this.metroTextBox1.Location = new System.Drawing.Point(0, 0);
            this.metroTextBox1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Multiline = true;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(285, 190);
            this.metroTextBox1.TabIndex = 6;
            this.metroTextBox1.Text = resources.GetString("metroTextBox1.Text");
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.btnNoneImage);
            this.metroPanel2.Controls.Add(this.btnMultiImage);
            this.metroPanel2.Controls.Add(this.btnSingleImage);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(285, 65);
            this.metroPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(560, 190);
            this.metroPanel2.TabIndex = 8;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // lblInputDataType
            // 
            this.lblInputDataType.AutoSize = true;
            this.lblInputDataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputDataType.Location = new System.Drawing.Point(288, 43);
            this.lblInputDataType.Margin = new System.Windows.Forms.Padding(3);
            this.lblInputDataType.Name = "lblInputDataType";
            this.lblInputDataType.Size = new System.Drawing.Size(123, 19);
            this.lblInputDataType.TabIndex = 2;
            this.lblInputDataType.Text = "Input Data Type";
            // 
            // metroStyleManagerClassification
            // 
            this.metroStyleManagerClassification.Owner = this;
            // 
            // btnNoneImage
            // 
            this.btnNoneImage.BackColor = System.Drawing.Color.Transparent;
            this.btnNoneImage.ButtonClickRetrun = "CADImage";
            this.btnNoneImage.CustomButtonName = "CAD Image";
            this.btnNoneImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNoneImage.InputLabelText = "CAD Image 설명";
            this.btnNoneImage.Location = new System.Drawing.Point(320, 0);
            this.btnNoneImage.MBBackgroundImage = global::ProjectAI.Properties.Resources.pcb_board_origin; this.btnNoneImage.Name = "btnNoneImage";
            this.btnNoneImage.Size = new System.Drawing.Size(160, 190);
            this.btnNoneImage.TabIndex = 102;
            this.btnNoneImage.Title = "CAD Image";
            // 
            // btnMultiImage
            // 
            this.btnMultiImage.BackColor = System.Drawing.Color.Transparent;
            this.btnMultiImage.ButtonClickRetrun = "MultiImage";
            this.btnMultiImage.CustomButtonName = "Multi Image";
            this.btnMultiImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMultiImage.InputLabelText = "Multi Image 설명";
            this.btnMultiImage.Location = new System.Drawing.Point(160, 0);
            this.btnMultiImage.MBBackgroundImage = global::ProjectAI.Properties.Resources.segmentation150;
            this.btnMultiImage.Name = "btnMultiImage";
            this.btnMultiImage.Size = new System.Drawing.Size(160, 190);
            this.btnMultiImage.TabIndex = 101;
            this.btnMultiImage.Title = "Multi Image";
            // 
            // btnSingleImage
            // 
            this.btnSingleImage.BackColor = System.Drawing.Color.Transparent;
            this.btnSingleImage.ButtonClickRetrun = "SingleImage";
            this.btnSingleImage.CustomButtonName = "Single Image";
            this.btnSingleImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSingleImage.InputLabelText = "Single Image 설명";
            this.btnSingleImage.Location = new System.Drawing.Point(0, 0);
            this.btnSingleImage.MBBackgroundImage = global::ProjectAI.Properties.Resources.segmentation150;
            this.btnSingleImage.Name = "btnSingleImage";
            this.btnSingleImage.Size = new System.Drawing.Size(160, 190);
            this.btnSingleImage.TabIndex = 100;
            this.btnSingleImage.Title = "Single Image";
            // 
            // Classification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Classification";
            this.Size = new System.Drawing.Size(845, 260);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManagerClassification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblClassificationINFO;
        private System.Windows.Forms.Label lblInputDataType;
        private MetroFramework.Controls.MetroTextBox txtTitle;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Components.MetroStyleManager metroStyleManagerClassification;
        public ImputDataTypeButton btnNoneImage;
        public ImputDataTypeButton btnMultiImage;
        public ImputDataTypeButton btnSingleImage;
        private MetroFramework.Controls.MetroPanel metroPanel2;
    }
}
