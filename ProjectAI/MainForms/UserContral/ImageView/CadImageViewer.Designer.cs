
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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.metroPanel5 = new MetroFramework.Controls.MetroPanel();
            this.HeatmapImageLabel = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.OverlayImageLabel = new System.Windows.Forms.Label();
            this.TrackbarNumber = new System.Windows.Forms.Label();
            this.TrackBar = new MetroFramework.Controls.MetroTrackBar();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.CADImageLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.OriginImageLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawFillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.metroPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.metroPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.metroPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.tableLayoutPanel1);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.metroPanel5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.metroPanel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.metroPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(826, 648);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // metroPanel5
            // 
            this.metroPanel5.Controls.Add(this.HeatmapImageLabel);
            this.metroPanel5.Controls.Add(this.pictureBox4);
            this.metroPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel5.HorizontalScrollbarBarColor = true;
            this.metroPanel5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel5.HorizontalScrollbarSize = 10;
            this.metroPanel5.Location = new System.Drawing.Point(416, 327);
            this.metroPanel5.Name = "metroPanel5";
            this.metroPanel5.Size = new System.Drawing.Size(407, 318);
            this.metroPanel5.TabIndex = 3;
            this.metroPanel5.VerticalScrollbarBarColor = true;
            this.metroPanel5.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel5.VerticalScrollbarSize = 10;
            // 
            // HeatmapImageLabel
            // 
            this.HeatmapImageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HeatmapImageLabel.AutoSize = true;
            this.HeatmapImageLabel.BackColor = System.Drawing.Color.Coral;
            this.HeatmapImageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HeatmapImageLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeatmapImageLabel.ForeColor = System.Drawing.Color.White;
            this.HeatmapImageLabel.Location = new System.Drawing.Point(0, 298);
            this.HeatmapImageLabel.Name = "HeatmapImageLabel";
            this.HeatmapImageLabel.Size = new System.Drawing.Size(117, 20);
            this.HeatmapImageLabel.TabIndex = 6;
            this.HeatmapImageLabel.Text = "Heatmap Image";
            this.HeatmapImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Brightness;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(407, 318);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // metroPanel4
            // 
            this.metroPanel4.Controls.Add(this.OverlayImageLabel);
            this.metroPanel4.Controls.Add(this.TrackbarNumber);
            this.metroPanel4.Controls.Add(this.TrackBar);
            this.metroPanel4.Controls.Add(this.pictureBox3);
            this.metroPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(3, 327);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(407, 318);
            this.metroPanel4.TabIndex = 2;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // OverlayImageLabel
            // 
            this.OverlayImageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OverlayImageLabel.AutoSize = true;
            this.OverlayImageLabel.BackColor = System.Drawing.Color.ForestGreen;
            this.OverlayImageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OverlayImageLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverlayImageLabel.ForeColor = System.Drawing.Color.White;
            this.OverlayImageLabel.Location = new System.Drawing.Point(0, 275);
            this.OverlayImageLabel.Name = "OverlayImageLabel";
            this.OverlayImageLabel.Size = new System.Drawing.Size(105, 20);
            this.OverlayImageLabel.TabIndex = 5;
            this.OverlayImageLabel.Text = "Overlay Image";
            this.OverlayImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackbarNumber
            // 
            this.TrackbarNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TrackbarNumber.AutoSize = true;
            this.TrackbarNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackbarNumber.Location = new System.Drawing.Point(102, 275);
            this.TrackbarNumber.Name = "TrackbarNumber";
            this.TrackbarNumber.Size = new System.Drawing.Size(40, 21);
            this.TrackbarNumber.TabIndex = 7;
            this.TrackbarNumber.Text = "0.50";
            // 
            // TrackBar
            // 
            this.TrackBar.BackColor = System.Drawing.Color.Transparent;
            this.TrackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TrackBar.Location = new System.Drawing.Point(0, 298);
            this.TrackBar.Name = "TrackBar";
            this.TrackBar.Size = new System.Drawing.Size(407, 20);
            this.TrackBar.TabIndex = 6;
            this.TrackBar.Text = "metroTrackBar1";
            this.TrackBar.ValueChanged += new System.EventHandler(this.TrackBarValueChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Brightness;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(407, 318);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.CADImageLabel);
            this.metroPanel3.Controls.Add(this.pictureBox2);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(416, 3);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(407, 318);
            this.metroPanel3.TabIndex = 1;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // CADImageLabel
            // 
            this.CADImageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CADImageLabel.AutoSize = true;
            this.CADImageLabel.BackColor = System.Drawing.Color.Lime;
            this.CADImageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CADImageLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CADImageLabel.ForeColor = System.Drawing.Color.White;
            this.CADImageLabel.Location = new System.Drawing.Point(0, 298);
            this.CADImageLabel.Name = "CADImageLabel";
            this.CADImageLabel.Size = new System.Drawing.Size(85, 20);
            this.CADImageLabel.TabIndex = 4;
            this.CADImageLabel.Text = "CAD Image";
            this.CADImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Brightness;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(407, 318);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.OriginImageLabel);
            this.metroPanel2.Controls.Add(this.pictureBox1);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(3, 3);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(407, 318);
            this.metroPanel2.TabIndex = 0;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // OriginImageLabel
            // 
            this.OriginImageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OriginImageLabel.AutoSize = true;
            this.OriginImageLabel.BackColor = System.Drawing.Color.Tomato;
            this.OriginImageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OriginImageLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginImageLabel.ForeColor = System.Drawing.Color.White;
            this.OriginImageLabel.Location = new System.Drawing.Point(0, 298);
            this.OriginImageLabel.Name = "OriginImageLabel";
            this.OriginImageLabel.Size = new System.Drawing.Size(96, 20);
            this.OriginImageLabel.TabIndex = 3;
            this.OriginImageLabel.Text = "Origin Image";
            this.OriginImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Brightness;
            this.pictureBox1.ContextMenuStrip = this.metroContextMenu1;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(407, 318);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1MouseDoubleClick);
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroContextMenu1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawToolStripMenuItem,
            this.drawViewerToolStripMenuItem,
            this.drawFillToolStripMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(146, 70);
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.drawToolStripMenuItem.Text = "draw";
            this.drawToolStripMenuItem.Click += new System.EventHandler(this.DrawToolStripMenuItemClick);
            // 
            // drawViewerToolStripMenuItem
            // 
            this.drawViewerToolStripMenuItem.Name = "drawViewerToolStripMenuItem";
            this.drawViewerToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.drawViewerToolStripMenuItem.Text = "drawViewer";
            this.drawViewerToolStripMenuItem.Click += new System.EventHandler(this.DrawViewerToolStripMenuItemClick);
            // 
            // drawFillToolStripMenuItem
            // 
            this.drawFillToolStripMenuItem.Name = "drawFillToolStripMenuItem";
            this.drawFillToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.drawFillToolStripMenuItem.Text = "drawFloodFill";
            this.drawFillToolStripMenuItem.Click += new System.EventHandler(this.DrawFloodFillToolStripMenuItemClick);
            // 
            // CadImageViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.metroPanel1);
            this.Name = "CadImageViewer";
            this.Size = new System.Drawing.Size(826, 648);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.metroPanel5.ResumeLayout(false);
            this.metroPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel5;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.Label OriginImageLabel;
        private System.Windows.Forms.Label CADImageLabel;
        private System.Windows.Forms.Label OverlayImageLabel;
        private System.Windows.Forms.Label HeatmapImageLabel;
        private MetroFramework.Controls.MetroTrackBar TrackBar;
        private System.Windows.Forms.Label TrackbarNumber;

        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawFillToolStripMenuItem;

    }
}
