namespace ProjectAI.MainForms
{
    partial class WorkSpaceButton
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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.panelWorkSpaceStatus = new System.Windows.Forms.Panel();
            this.lblWorkSpaceVersion = new System.Windows.Forms.Label();
            this.lblWorkSpaceSize = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblWorkSpaceName = new MetroFramework.Controls.MetroLabel();
            this.btnWorkSpaceOpen = new System.Windows.Forms.Button();
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            // 
            // panelWorkSpaceStatus
            // 
            this.panelWorkSpaceStatus.BackColor = System.Drawing.Color.Gray;
            this.panelWorkSpaceStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkSpaceStatus.Location = new System.Drawing.Point(3, 3);
            this.panelWorkSpaceStatus.Name = "panelWorkSpaceStatus";
            this.panelWorkSpaceStatus.Size = new System.Drawing.Size(19, 19);
            this.panelWorkSpaceStatus.TabIndex = 5;
            // 
            // lblWorkSpaceVersion
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.lblWorkSpaceVersion, true);
            this.lblWorkSpaceVersion.AutoSize = true;
            this.lblWorkSpaceVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkSpaceVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkSpaceVersion.Location = new System.Drawing.Point(328, 0);
            this.lblWorkSpaceVersion.Name = "lblWorkSpaceVersion";
            this.lblWorkSpaceVersion.Size = new System.Drawing.Size(34, 25);
            this.lblWorkSpaceVersion.TabIndex = 2;
            this.lblWorkSpaceVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWorkSpaceSize
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.lblWorkSpaceSize, true);
            this.lblWorkSpaceSize.AutoSize = true;
            this.lblWorkSpaceSize.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkSpaceSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkSpaceSize.Location = new System.Drawing.Point(228, 0);
            this.lblWorkSpaceSize.Name = "lblWorkSpaceSize";
            this.lblWorkSpaceSize.Size = new System.Drawing.Size(94, 25);
            this.lblWorkSpaceSize.TabIndex = 1;
            this.lblWorkSpaceSize.Text = "100 Bytes";
            this.lblWorkSpaceSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.tableLayoutPanel1, true);
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lblWorkSpaceSize, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblWorkSpaceVersion, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelWorkSpaceStatus, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblWorkSpaceName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnWorkSpaceOpen, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(390, 25);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblWorkSpaceName
            // 
            this.lblWorkSpaceName.AutoSize = true;
            this.lblWorkSpaceName.BackColor = System.Drawing.Color.White;
            this.lblWorkSpaceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkSpaceName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblWorkSpaceName.Location = new System.Drawing.Point(28, 0);
            this.lblWorkSpaceName.Name = "lblWorkSpaceName";
            this.lblWorkSpaceName.Size = new System.Drawing.Size(194, 25);
            this.lblWorkSpaceName.TabIndex = 6;
            this.lblWorkSpaceName.Text = "Name Test";
            this.lblWorkSpaceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnWorkSpaceOpen
            // 
            this.btnWorkSpaceOpen.BackgroundImage = global::ProjectAI.Properties.Resources.arrowRight5;
            this.btnWorkSpaceOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWorkSpaceOpen.FlatAppearance.BorderSize = 0;
            this.btnWorkSpaceOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkSpaceOpen.Location = new System.Drawing.Point(368, 3);
            this.btnWorkSpaceOpen.Name = "btnWorkSpaceOpen";
            this.btnWorkSpaceOpen.Size = new System.Drawing.Size(19, 19);
            this.btnWorkSpaceOpen.TabIndex = 7;
            this.btnWorkSpaceOpen.UseVisualStyleBackColor = true;
            // 
            // WorkSpaceButton
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this, true);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::ProjectAI.Properties.Resources.border1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WorkSpaceButton";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(400, 35);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.Panel panelWorkSpaceStatus;
        private System.Windows.Forms.Label lblWorkSpaceVersion;
        private System.Windows.Forms.Label lblWorkSpaceSize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroLabel lblWorkSpaceName;
        private System.Windows.Forms.Button btnWorkSpaceOpen;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
    }
}
