namespace ProjectAI.MainForms
{
    partial class ImageCountLabel
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblimageCountName = new System.Windows.Forms.Label();
            this.lblimageCount = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblimageCountName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblimageCount, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(65, 75);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblimageCountName
            // 
            this.lblimageCountName.AutoSize = true;
            this.lblimageCountName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblimageCountName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblimageCountName.Location = new System.Drawing.Point(3, 56);
            this.lblimageCountName.Name = "lblimageCountName";
            this.lblimageCountName.Size = new System.Drawing.Size(59, 19);
            this.lblimageCountName.TabIndex = 0;
            this.lblimageCountName.Text = "name";
            this.lblimageCountName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblimageCount
            // 
            this.lblimageCount.AutoSize = true;
            this.lblimageCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblimageCount.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblimageCount.Location = new System.Drawing.Point(0, 0);
            this.lblimageCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblimageCount.Name = "lblimageCount";
            this.lblimageCount.Size = new System.Drawing.Size(65, 56);
            this.lblimageCount.TabIndex = 1;
            this.lblimageCount.Text = "1234567";
            this.lblimageCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImageCountLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ImageCountLabel";
            this.Size = new System.Drawing.Size(65, 75);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblimageCountName;
        private System.Windows.Forms.Label lblimageCount;
    }
}
