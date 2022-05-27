
namespace ProjectAI.MainForms.UserContral.ImageView
{
    partial class CadImageViewer
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelMOrignalImage = new MetroFramework.Controls.MetroPanel();
            this.lblMOriginImage = new MetroFramework.Controls.MetroLabel();
            this.OverlayViewCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.OriginImageLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMCADImage = new MetroFramework.Controls.MetroPanel();
            this.lblMCADImage = new MetroFramework.Controls.MetroLabel();
            this.CADImageLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TrackbarNumber = new System.Windows.Forms.Label();
            this.TrackBar = new MetroFramework.Controls.MetroTrackBar();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelMOrignalImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMCADImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.splitContainer1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(826, 648);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.panelMOrignalImage);
            this.splitContainer1.Panel1.Controls.Add(this.OverlayViewCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.OriginImageLabel);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.panelMCADImage);
            this.splitContainer1.Panel2.Controls.Add(this.CADImageLabel);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainer1.Size = new System.Drawing.Size(826, 648);
            this.splitContainer1.SplitterDistance = 403;
            this.splitContainer1.TabIndex = 2;
            // 
            // panelMOrignalImage
            // 
            this.panelMOrignalImage.BackgroundImage = global::ProjectAI.Properties.Resources.border1R;
            this.panelMOrignalImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMOrignalImage.Controls.Add(this.lblMOriginImage);
            this.panelMOrignalImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMOrignalImage.HorizontalScrollbarBarColor = true;
            this.panelMOrignalImage.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMOrignalImage.HorizontalScrollbarSize = 10;
            this.panelMOrignalImage.Location = new System.Drawing.Point(0, 584);
            this.panelMOrignalImage.Margin = new System.Windows.Forms.Padding(0);
            this.panelMOrignalImage.Name = "panelMOrignalImage";
            this.panelMOrignalImage.Size = new System.Drawing.Size(403, 34);
            this.panelMOrignalImage.TabIndex = 6;
            this.panelMOrignalImage.UseCustomBackColor = true;
            this.panelMOrignalImage.VerticalScrollbarBarColor = true;
            this.panelMOrignalImage.VerticalScrollbarHighlightOnWheel = false;
            this.panelMOrignalImage.VerticalScrollbarSize = 10;
            // 
            // lblMOriginImage
            // 
            this.lblMOriginImage.BackColor = System.Drawing.Color.Transparent;
            this.lblMOriginImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMOriginImage.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMOriginImage.Location = new System.Drawing.Point(0, 0);
            this.lblMOriginImage.Name = "lblMOriginImage";
            this.lblMOriginImage.Size = new System.Drawing.Size(403, 34);
            this.lblMOriginImage.TabIndex = 2;
            this.lblMOriginImage.Text = "Origin Image";
            this.lblMOriginImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMOriginImage.UseCustomBackColor = true;
            // 
            // OverlayViewCheckBox
            // 
            this.OverlayViewCheckBox.AutoSize = true;
            this.OverlayViewCheckBox.Location = new System.Drawing.Point(3, 3);
            this.OverlayViewCheckBox.Name = "OverlayViewCheckBox";
            this.OverlayViewCheckBox.Size = new System.Drawing.Size(91, 15);
            this.OverlayViewCheckBox.TabIndex = 2;
            this.OverlayViewCheckBox.Text = "Overlay View";
            this.OverlayViewCheckBox.UseSelectable = true;
            this.OverlayViewCheckBox.CheckedChanged += new System.EventHandler(this.OverlayViewCheckedChanged);
            // 
            // OriginImageLabel
            // 
            this.OriginImageLabel.BackColor = System.Drawing.Color.Tomato;
            this.OriginImageLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OriginImageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OriginImageLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginImageLabel.Location = new System.Drawing.Point(0, 618);
            this.OriginImageLabel.Name = "OriginImageLabel";
            this.OriginImageLabel.Size = new System.Drawing.Size(403, 30);
            this.OriginImageLabel.TabIndex = 1;
            this.OriginImageLabel.Text = "Origin Image";
            this.OriginImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Brightness;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(403, 648);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelMCADImage
            // 
            this.panelMCADImage.BackColor = System.Drawing.Color.Transparent;
            this.panelMCADImage.BackgroundImage = global::ProjectAI.Properties.Resources.border1G;
            this.panelMCADImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMCADImage.Controls.Add(this.lblMCADImage);
            this.panelMCADImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMCADImage.HorizontalScrollbarBarColor = true;
            this.panelMCADImage.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMCADImage.HorizontalScrollbarSize = 10;
            this.panelMCADImage.Location = new System.Drawing.Point(0, 584);
            this.panelMCADImage.Margin = new System.Windows.Forms.Padding(0);
            this.panelMCADImage.Name = "panelMCADImage";
            this.panelMCADImage.Size = new System.Drawing.Size(419, 34);
            this.panelMCADImage.TabIndex = 5;
            this.panelMCADImage.UseCustomBackColor = true;
            this.panelMCADImage.VerticalScrollbarBarColor = true;
            this.panelMCADImage.VerticalScrollbarHighlightOnWheel = false;
            this.panelMCADImage.VerticalScrollbarSize = 10;
            // 
            // lblMCADImage
            // 
            this.lblMCADImage.BackColor = System.Drawing.Color.Transparent;
            this.lblMCADImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMCADImage.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMCADImage.Location = new System.Drawing.Point(0, 0);
            this.lblMCADImage.Name = "lblMCADImage";
            this.lblMCADImage.Size = new System.Drawing.Size(419, 34);
            this.lblMCADImage.TabIndex = 2;
            this.lblMCADImage.Text = "CAD Image";
            this.lblMCADImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMCADImage.UseCustomBackColor = true;
            // 
            // CADImageLabel
            // 
            this.CADImageLabel.BackColor = System.Drawing.Color.Lime;
            this.CADImageLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CADImageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CADImageLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CADImageLabel.Location = new System.Drawing.Point(0, 618);
            this.CADImageLabel.Name = "CADImageLabel";
            this.CADImageLabel.Size = new System.Drawing.Size(419, 30);
            this.CADImageLabel.TabIndex = 1;
            this.CADImageLabel.Text = "CAD Image";
            this.CADImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Brightness;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(419, 648);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.TrackbarNumber, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TrackBar, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 554);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(419, 30);
            this.tableLayoutPanel1.TabIndex = 6;
            this.tableLayoutPanel1.Visible = false;
            // 
            // TrackbarNumber
            // 
            this.TrackbarNumber.AutoSize = true;
            this.TrackbarNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackbarNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackbarNumber.Location = new System.Drawing.Point(3, 0);
            this.TrackbarNumber.Name = "TrackbarNumber";
            this.TrackbarNumber.Size = new System.Drawing.Size(44, 30);
            this.TrackbarNumber.TabIndex = 3;
            this.TrackbarNumber.Text = "0.50";
            this.TrackbarNumber.Visible = false;
            // 
            // TrackBar
            // 
            this.TrackBar.BackColor = System.Drawing.Color.Transparent;
            this.TrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackBar.Location = new System.Drawing.Point(53, 3);
            this.TrackBar.Name = "TrackBar";
            this.TrackBar.Size = new System.Drawing.Size(363, 24);
            this.TrackBar.TabIndex = 2;
            this.TrackBar.Text = "metroTrackBar1";
            this.TrackBar.Visible = false;
            this.TrackBar.ValueChanged += new System.EventHandler(this.TrackBarValueChanged);
            // 
            // CadImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel1);
            this.Name = "CadImageViewer";
            this.Size = new System.Drawing.Size(826, 648);
            this.metroPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelMOrignalImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMCADImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Label OriginImageLabel;
        private System.Windows.Forms.Label CADImageLabel;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public MetroFramework.Controls.MetroCheckBox OverlayViewCheckBox;
        private MetroFramework.Controls.MetroPanel panelMCADImage;
        private MetroFramework.Controls.MetroLabel lblMCADImage;
        private MetroFramework.Controls.MetroPanel panelMOrignalImage;
        private MetroFramework.Controls.MetroLabel lblMOriginImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label TrackbarNumber;
        public MetroFramework.Controls.MetroTrackBar TrackBar;
    }
}
