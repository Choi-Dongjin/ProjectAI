namespace ProjectAI.MainForms.UserContral.ImageList
{
    partial class GridViewImageList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridViewImageList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ckbMdataGridViewAutoSize = new MetroFramework.Controls.MetroCheckBox();
            this.tableLayoutImageDataManiger = new System.Windows.Forms.TableLayoutPanel();
            this.lblImageListpageMid = new System.Windows.Forms.Label();
            this.lblImageListpage = new System.Windows.Forms.Label();
            this.btnimagePageReverse = new System.Windows.Forms.Button();
            this.btnimagePageNext = new System.Windows.Forms.Button();
            this.lblImageListpageTotal = new System.Windows.Forms.Label();
            this.gridImageList = new MetroFramework.Controls.MetroGrid();
            this.cmsMImageListToolKit = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.imageFilesAddToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageFolderAddToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imageSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cADImageSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cADImageSelectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.imageFilesAddWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageFolderAddWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.imageLabelingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.imageSetTrainToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSetTestToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.imageDeleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.imageLabelInfoResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSetInfoResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutImageDataManiger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridImageList)).BeginInit();
            this.cmsMImageListToolKit.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.ckbMdataGridViewAutoSize, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(378, 29);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // ckbMdataGridViewAutoSize
            // 
            this.ckbMdataGridViewAutoSize.AutoSize = true;
            this.ckbMdataGridViewAutoSize.Checked = true;
            this.ckbMdataGridViewAutoSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbMdataGridViewAutoSize.Location = new System.Drawing.Point(3, 3);
            this.ckbMdataGridViewAutoSize.Name = "ckbMdataGridViewAutoSize";
            this.ckbMdataGridViewAutoSize.Size = new System.Drawing.Size(129, 14);
            this.ckbMdataGridViewAutoSize.TabIndex = 0;
            this.ckbMdataGridViewAutoSize.Text = "Image List Auto Size";
            this.ckbMdataGridViewAutoSize.UseSelectable = true;
            this.ckbMdataGridViewAutoSize.CheckedChanged += new System.EventHandler(this.CkbMdataGridViewAutoSizeCheckedChanged);
            // 
            // tableLayoutImageDataManiger
            // 
            this.tableLayoutImageDataManiger.ColumnCount = 7;
            this.tableLayoutImageDataManiger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutImageDataManiger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutImageDataManiger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutImageDataManiger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutImageDataManiger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutImageDataManiger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutImageDataManiger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutImageDataManiger.Controls.Add(this.lblImageListpageMid, 3, 0);
            this.tableLayoutImageDataManiger.Controls.Add(this.lblImageListpage, 2, 0);
            this.tableLayoutImageDataManiger.Controls.Add(this.btnimagePageReverse, 1, 0);
            this.tableLayoutImageDataManiger.Controls.Add(this.btnimagePageNext, 5, 0);
            this.tableLayoutImageDataManiger.Controls.Add(this.lblImageListpageTotal, 4, 0);
            this.tableLayoutImageDataManiger.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutImageDataManiger.Location = new System.Drawing.Point(0, 29);
            this.tableLayoutImageDataManiger.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutImageDataManiger.Name = "tableLayoutImageDataManiger";
            this.tableLayoutImageDataManiger.RowCount = 1;
            this.tableLayoutImageDataManiger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutImageDataManiger.Size = new System.Drawing.Size(378, 35);
            this.tableLayoutImageDataManiger.TabIndex = 2;
            // 
            // lblImageListpageMid
            // 
            this.lblImageListpageMid.AutoSize = true;
            this.lblImageListpageMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImageListpageMid.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblImageListpageMid.Location = new System.Drawing.Point(184, 0);
            this.lblImageListpageMid.Margin = new System.Windows.Forms.Padding(0);
            this.lblImageListpageMid.Name = "lblImageListpageMid";
            this.lblImageListpageMid.Size = new System.Drawing.Size(10, 35);
            this.lblImageListpageMid.TabIndex = 11;
            this.lblImageListpageMid.Text = "/";
            this.lblImageListpageMid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblImageListpage
            // 
            this.lblImageListpage.AutoSize = true;
            this.lblImageListpage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblImageListpage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImageListpage.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold);
            this.lblImageListpage.Location = new System.Drawing.Point(164, 0);
            this.lblImageListpage.Margin = new System.Windows.Forms.Padding(0);
            this.lblImageListpage.Name = "lblImageListpage";
            this.lblImageListpage.Size = new System.Drawing.Size(20, 35);
            this.lblImageListpage.TabIndex = 10;
            this.lblImageListpage.Text = "0";
            this.lblImageListpage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblImageListpage.TextChanged += new System.EventHandler(this.LblImageListpageTextChanged);
            this.lblImageListpage.Click += new System.EventHandler(this.LblImageListpageClick);
            // 
            // btnimagePageReverse
            // 
            this.btnimagePageReverse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnimagePageReverse.BackgroundImage")));
            this.btnimagePageReverse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnimagePageReverse.FlatAppearance.BorderSize = 0;
            this.btnimagePageReverse.Location = new System.Drawing.Point(129, 0);
            this.btnimagePageReverse.Margin = new System.Windows.Forms.Padding(0);
            this.btnimagePageReverse.Name = "btnimagePageReverse";
            this.btnimagePageReverse.Size = new System.Drawing.Size(35, 35);
            this.btnimagePageReverse.TabIndex = 2;
            this.btnimagePageReverse.UseVisualStyleBackColor = true;
            this.btnimagePageReverse.Click += new System.EventHandler(this.BtnimagePageReverseClick);
            // 
            // btnimagePageNext
            // 
            this.btnimagePageNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnimagePageNext.BackgroundImage")));
            this.btnimagePageNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnimagePageNext.FlatAppearance.BorderSize = 0;
            this.btnimagePageNext.Location = new System.Drawing.Point(214, 0);
            this.btnimagePageNext.Margin = new System.Windows.Forms.Padding(0);
            this.btnimagePageNext.Name = "btnimagePageNext";
            this.btnimagePageNext.Size = new System.Drawing.Size(35, 35);
            this.btnimagePageNext.TabIndex = 3;
            this.btnimagePageNext.UseVisualStyleBackColor = true;
            this.btnimagePageNext.Click += new System.EventHandler(this.BtnimagePageNextClick);
            // 
            // lblImageListpageTotal
            // 
            this.lblImageListpageTotal.AutoSize = true;
            this.lblImageListpageTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImageListpageTotal.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold);
            this.lblImageListpageTotal.Location = new System.Drawing.Point(194, 0);
            this.lblImageListpageTotal.Margin = new System.Windows.Forms.Padding(0);
            this.lblImageListpageTotal.Name = "lblImageListpageTotal";
            this.lblImageListpageTotal.Size = new System.Drawing.Size(20, 35);
            this.lblImageListpageTotal.TabIndex = 9;
            this.lblImageListpageTotal.Text = "0";
            this.lblImageListpageTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblImageListpageTotal.TextChanged += new System.EventHandler(this.LblImageListpageTotalTextChanged);
            // 
            // gridImageList
            // 
            this.gridImageList.AllowUserToAddRows = false;
            this.gridImageList.AllowUserToResizeRows = false;
            this.gridImageList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridImageList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridImageList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridImageList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridImageList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridImageList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridImageList.ContextMenuStrip = this.cmsMImageListToolKit;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridImageList.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridImageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridImageList.EnableHeadersVisualStyles = false;
            this.gridImageList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridImageList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridImageList.Location = new System.Drawing.Point(0, 64);
            this.gridImageList.Margin = new System.Windows.Forms.Padding(0);
            this.gridImageList.Name = "gridImageList";
            this.gridImageList.ReadOnly = true;
            this.gridImageList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridImageList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridImageList.RowHeadersVisible = false;
            this.gridImageList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridImageList.RowTemplate.Height = 23;
            this.gridImageList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridImageList.Size = new System.Drawing.Size(378, 686);
            this.gridImageList.Style = MetroFramework.MetroColorStyle.Silver;
            this.gridImageList.TabIndex = 3;
            this.gridImageList.Theme = MetroFramework.MetroThemeStyle.Light;
            this.gridImageList.UseStyleColors = true;
            this.gridImageList.SelectionChanged += new System.EventHandler(this.GridImageListSelectionChanged);
            // 
            // cmsMImageListToolKit
            // 
            this.cmsMImageListToolKit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmsMImageListToolKit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmsMImageListToolKit.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsMImageListToolKit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator11,
            this.imageFilesAddToolStripMenuItem1,
            this.imageFolderAddToolStripMenuItem1,
            this.toolStripSeparator1,
            this.imageSelectToolStripMenuItem,
            this.toolStripSeparator14,
            this.imageFilesAddWizardToolStripMenuItem,
            this.imageFolderAddWizardToolStripMenuItem,
            this.toolStripSeparator7,
            this.imageLabelingToolStripMenuItem1,
            this.toolStripSeparator8,
            this.imageSetTrainToolStripMenuItem1,
            this.imageSetTestToolStripMenuItem1,
            this.toolStripSeparator9,
            this.imageDeleteToolStripMenuItem1,
            this.toolStripSeparator10,
            this.imageLabelInfoResetToolStripMenuItem,
            this.imageSetInfoResetToolStripMenuItem,
            this.toolStripSeparator15});
            this.cmsMImageListToolKit.Name = "cmsMImageListToolKit";
            this.cmsMImageListToolKit.Size = new System.Drawing.Size(220, 404);
            this.cmsMImageListToolKit.Style = MetroFramework.MetroColorStyle.Silver;
            this.cmsMImageListToolKit.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(216, 6);
            // 
            // imageFilesAddToolStripMenuItem1
            // 
            this.imageFilesAddToolStripMenuItem1.Image = global::ProjectAI.Properties.Resources.open_source;
            this.imageFilesAddToolStripMenuItem1.Name = "imageFilesAddToolStripMenuItem1";
            this.imageFilesAddToolStripMenuItem1.Size = new System.Drawing.Size(219, 30);
            this.imageFilesAddToolStripMenuItem1.Text = "Image File Add";
            this.imageFilesAddToolStripMenuItem1.Click += new System.EventHandler(this.ImageFilesAddToolStripMenuItem1Click);
            // 
            // imageFolderAddToolStripMenuItem1
            // 
            this.imageFolderAddToolStripMenuItem1.Image = global::ProjectAI.Properties.Resources.open2;
            this.imageFolderAddToolStripMenuItem1.Name = "imageFolderAddToolStripMenuItem1";
            this.imageFolderAddToolStripMenuItem1.Size = new System.Drawing.Size(219, 30);
            this.imageFolderAddToolStripMenuItem1.Text = "Image Folder Add";
            this.imageFolderAddToolStripMenuItem1.Click += new System.EventHandler(this.ImageFolderAddToolStripMenuItem1Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
            // 
            // imageSelectToolStripMenuItem
            // 
            this.imageSelectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cADImageSelectToolStripMenuItem,
            this.cADImageSelectToolStripMenuItem1});
            this.imageSelectToolStripMenuItem.Image = global::ProjectAI.Properties.Resources.open_source;
            this.imageSelectToolStripMenuItem.Name = "imageSelectToolStripMenuItem";
            this.imageSelectToolStripMenuItem.Size = new System.Drawing.Size(219, 30);
            this.imageSelectToolStripMenuItem.Text = "Image CAD Select";
            this.imageSelectToolStripMenuItem.Visible = false;
            // 
            // cADImageSelectToolStripMenuItem
            // 
            this.cADImageSelectToolStripMenuItem.Name = "cADImageSelectToolStripMenuItem";
            this.cADImageSelectToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cADImageSelectToolStripMenuItem.Text = "Init Image Select";
            this.cADImageSelectToolStripMenuItem.Click += new System.EventHandler(this.CADImageSelectToolStripMenuItemInitImageClick);
            // 
            // cADImageSelectToolStripMenuItem1
            // 
            this.cADImageSelectToolStripMenuItem1.Name = "cADImageSelectToolStripMenuItem1";
            this.cADImageSelectToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.cADImageSelectToolStripMenuItem1.Text = "CAD Image Select";
            this.cADImageSelectToolStripMenuItem1.Click += new System.EventHandler(this.CADImageSelectToolStripMenuItemCADImageClick);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(216, 6);
            // 
            // imageFilesAddWizardToolStripMenuItem
            // 
            this.imageFilesAddWizardToolStripMenuItem.Image = global::ProjectAI.Properties.Resources.open_sourceWizard;
            this.imageFilesAddWizardToolStripMenuItem.Name = "imageFilesAddWizardToolStripMenuItem";
            this.imageFilesAddWizardToolStripMenuItem.Size = new System.Drawing.Size(219, 30);
            this.imageFilesAddWizardToolStripMenuItem.Text = "Image Files Add Wizard";
            this.imageFilesAddWizardToolStripMenuItem.Click += new System.EventHandler(this.ImageFilesAddWizardToolStripMenuItemClick);
            // 
            // imageFolderAddWizardToolStripMenuItem
            // 
            this.imageFolderAddWizardToolStripMenuItem.Image = global::ProjectAI.Properties.Resources.open2Wizard;
            this.imageFolderAddWizardToolStripMenuItem.Name = "imageFolderAddWizardToolStripMenuItem";
            this.imageFolderAddWizardToolStripMenuItem.Size = new System.Drawing.Size(219, 30);
            this.imageFolderAddWizardToolStripMenuItem.Text = "Image Folder Add Wizard";
            this.imageFolderAddWizardToolStripMenuItem.Click += new System.EventHandler(this.ImageFolderAddWizardToolStripMenuItemClick);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(216, 6);
            // 
            // imageLabelingToolStripMenuItem1
            // 
            this.imageLabelingToolStripMenuItem1.Image = global::ProjectAI.Properties.Resources.product_development1;
            this.imageLabelingToolStripMenuItem1.Name = "imageLabelingToolStripMenuItem1";
            this.imageLabelingToolStripMenuItem1.Size = new System.Drawing.Size(219, 30);
            this.imageLabelingToolStripMenuItem1.Text = "Image Labeling";
            this.imageLabelingToolStripMenuItem1.Click += new System.EventHandler(this.ImageLabelingToolStripMenuItem1Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(216, 6);
            // 
            // imageSetTrainToolStripMenuItem1
            // 
            this.imageSetTrainToolStripMenuItem1.Image = global::ProjectAI.Properties.Resources.book;
            this.imageSetTrainToolStripMenuItem1.Name = "imageSetTrainToolStripMenuItem1";
            this.imageSetTrainToolStripMenuItem1.Size = new System.Drawing.Size(219, 30);
            this.imageSetTrainToolStripMenuItem1.Text = "Image Set Train";
            this.imageSetTrainToolStripMenuItem1.Click += new System.EventHandler(this.ImageSetTrainToolStripMenuItem1Click);
            // 
            // imageSetTestToolStripMenuItem1
            // 
            this.imageSetTestToolStripMenuItem1.Image = global::ProjectAI.Properties.Resources.completed_task;
            this.imageSetTestToolStripMenuItem1.Name = "imageSetTestToolStripMenuItem1";
            this.imageSetTestToolStripMenuItem1.Size = new System.Drawing.Size(219, 30);
            this.imageSetTestToolStripMenuItem1.Text = "Image Set Test";
            this.imageSetTestToolStripMenuItem1.Click += new System.EventHandler(this.ImageSetTestToolStripMenuItem1Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(216, 6);
            // 
            // imageDeleteToolStripMenuItem1
            // 
            this.imageDeleteToolStripMenuItem1.Image = global::ProjectAI.Properties.Resources.delete;
            this.imageDeleteToolStripMenuItem1.Name = "imageDeleteToolStripMenuItem1";
            this.imageDeleteToolStripMenuItem1.Size = new System.Drawing.Size(219, 30);
            this.imageDeleteToolStripMenuItem1.Text = "Image Delete";
            this.imageDeleteToolStripMenuItem1.Click += new System.EventHandler(this.ImageDeleteToolStripMenuItem1Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(216, 6);
            // 
            // imageLabelInfoResetToolStripMenuItem
            // 
            this.imageLabelInfoResetToolStripMenuItem.Image = global::ProjectAI.Properties.Resources.refresh2;
            this.imageLabelInfoResetToolStripMenuItem.Name = "imageLabelInfoResetToolStripMenuItem";
            this.imageLabelInfoResetToolStripMenuItem.Size = new System.Drawing.Size(219, 30);
            this.imageLabelInfoResetToolStripMenuItem.Text = "Image Label Info Reset";
            this.imageLabelInfoResetToolStripMenuItem.Click += new System.EventHandler(this.ImageLabelInfoResetToolStripMenuItemClick);
            // 
            // imageSetInfoResetToolStripMenuItem
            // 
            this.imageSetInfoResetToolStripMenuItem.Image = global::ProjectAI.Properties.Resources.reset;
            this.imageSetInfoResetToolStripMenuItem.Name = "imageSetInfoResetToolStripMenuItem";
            this.imageSetInfoResetToolStripMenuItem.Size = new System.Drawing.Size(219, 30);
            this.imageSetInfoResetToolStripMenuItem.Text = "Image Set Info Reset";
            this.imageSetInfoResetToolStripMenuItem.Click += new System.EventHandler(this.ImageSetInfoResetToolStripMenuItemClick);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(216, 6);
            // 
            // GridViewImageList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridImageList);
            this.Controls.Add(this.tableLayoutImageDataManiger);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "GridViewImageList";
            this.Size = new System.Drawing.Size(378, 750);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutImageDataManiger.ResumeLayout(false);
            this.tableLayoutImageDataManiger.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridImageList)).EndInit();
            this.cmsMImageListToolKit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public MetroFramework.Controls.MetroCheckBox ckbMdataGridViewAutoSize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutImageDataManiger;
        private System.Windows.Forms.Label lblImageListpageMid;
        public System.Windows.Forms.Label lblImageListpage;
        private System.Windows.Forms.Button btnimagePageReverse;
        private System.Windows.Forms.Button btnimagePageNext;
        public System.Windows.Forms.Label lblImageListpageTotal;
        public MetroFramework.Controls.MetroGrid gridImageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem imageFilesAddToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem imageSelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageFolderAddToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem imageFilesAddWizardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageFolderAddWizardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem imageLabelingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem imageSetTrainToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem imageSetTestToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem imageDeleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem imageLabelInfoResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageSetInfoResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        public MetroFramework.Controls.MetroContextMenu cmsMImageListToolKit;
        private System.Windows.Forms.ToolStripMenuItem cADImageSelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cADImageSelectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
