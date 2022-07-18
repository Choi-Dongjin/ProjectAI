namespace ProjectAI.MainForms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.styleManagerMainForm = new MetroFramework.Components.MetroStyleManager(this.components);
            this.styleExtenderMainForm = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.tableLayoutMainForm = new System.Windows.Forms.TableLayoutPanel();
            this.panelWorkSpaseIconOUT = new MetroFramework.Controls.MetroPanel();
            this.panelMWorkSpaceString2 = new MetroFramework.Controls.MetroPanel();
            this.btnMWorkSpaseOpen = new MetroFramework.Controls.MetroButton();
            this.panelProjectMain = new System.Windows.Forms.Panel();
            this.splitContainerImageAndImageList = new System.Windows.Forms.SplitContainer();
            this.tableLayoutDataReview = new System.Windows.Forms.TableLayoutPanel();
            this.iclTest = new ProjectAI.MainForms.ImageCountLabel();
            this.iclTrain = new ProjectAI.MainForms.ImageCountLabel();
            this.iclLabeled = new ProjectAI.MainForms.ImageCountLabel();
            this.iclTotal = new ProjectAI.MainForms.ImageCountLabel();
            this.panelDataReview = new System.Windows.Forms.Panel();
            this.panelTrainOptions = new System.Windows.Forms.Panel();
            this.panelMTrainOptions = new MetroFramework.Controls.MetroPanel();
            this.panelMTrainParameterString = new MetroFramework.Controls.MetroPanel();
            this.btnMTrainOptionsOpen = new MetroFramework.Controls.MetroButton();
            this.panelMDataReviewIcon = new MetroFramework.Controls.MetroPanel();
            this.panelMDataBaseInfoString = new MetroFramework.Controls.MetroPanel();
            this.btnMDataReviewOpen = new MetroFramework.Controls.MetroButton();
            this.panelProjectInfo = new MetroFramework.Controls.MetroPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmWorSpace = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProjectWorkSpaceNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmProjectAllWorkSpaceSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProjectWorkSpaceSave = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteWorkSpaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProjectDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmProjectWorSpaceProgramExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmProjectWorSpaceTestButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeStyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hiddenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelWorkSpaseIconIN = new System.Windows.Forms.Panel();
            this.panelMWorkSpaceString1 = new MetroFramework.Controls.MetroPanel();
            this.btnMWorkSpaseClose = new MetroFramework.Controls.MetroButton();
            this.panelWorkSpaseButtonIcon = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMDeleteWorkSpace = new MetroFramework.Controls.MetroButton();
            this.btnMnewWorkSpace = new MetroFramework.Controls.MetroButton();
            this.panelstatus = new System.Windows.Forms.Panel();
            this.lblMworkInFileName = new MetroFramework.Controls.MetroLabel();
            this.lblMIOStatus = new MetroFramework.Controls.MetroLabel();
            this.lblMtotalNumber = new MetroFramework.Controls.MetroLabel();
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.lblMwaorkInNumber = new MetroFramework.Controls.MetroLabel();
            this.pgbMfileIOstatus = new MetroFramework.Controls.MetroProgressBar();
            this.panelMWorkSpase = new MetroFramework.Controls.MetroPanel();
            this.panelWorkSpaseButton = new System.Windows.Forms.Panel();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMtryIcon = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.styleManagerMainForm)).BeginInit();
            this.tableLayoutMainForm.SuspendLayout();
            this.panelWorkSpaseIconOUT.SuspendLayout();
            this.panelProjectMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerImageAndImageList)).BeginInit();
            this.splitContainerImageAndImageList.SuspendLayout();
            this.tableLayoutDataReview.SuspendLayout();
            this.panelMTrainOptions.SuspendLayout();
            this.panelMDataReviewIcon.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelWorkSpaseIconIN.SuspendLayout();
            this.panelWorkSpaseButtonIcon.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelstatus.SuspendLayout();
            this.panelMWorkSpase.SuspendLayout();
            this.cmsMtryIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManagerMainForm
            // 
            this.styleManagerMainForm.Owner = this;
            // 
            // tableLayoutMainForm
            // 
            this.styleExtenderMainForm.SetApplyMetroTheme(this.tableLayoutMainForm, true);
            this.tableLayoutMainForm.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutMainForm.ColumnCount = 2;
            this.tableLayoutMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMainForm.Controls.Add(this.panelWorkSpaseIconOUT, 0, 0);
            this.tableLayoutMainForm.Controls.Add(this.panelProjectMain, 1, 1);
            this.tableLayoutMainForm.Controls.Add(this.panelProjectInfo, 1, 0);
            this.tableLayoutMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMainForm.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutMainForm.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutMainForm.Name = "tableLayoutMainForm";
            this.tableLayoutMainForm.RowCount = 2;
            this.tableLayoutMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMainForm.Size = new System.Drawing.Size(984, 807);
            this.tableLayoutMainForm.TabIndex = 3;
            // 
            // panelWorkSpaseIconOUT
            // 
            this.panelWorkSpaseIconOUT.Controls.Add(this.panelMWorkSpaceString2);
            this.panelWorkSpaseIconOUT.Controls.Add(this.btnMWorkSpaseOpen);
            this.panelWorkSpaseIconOUT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkSpaseIconOUT.HorizontalScrollbarBarColor = true;
            this.panelWorkSpaseIconOUT.HorizontalScrollbarHighlightOnWheel = false;
            this.panelWorkSpaseIconOUT.HorizontalScrollbarSize = 10;
            this.panelWorkSpaseIconOUT.Location = new System.Drawing.Point(0, 0);
            this.panelWorkSpaseIconOUT.Margin = new System.Windows.Forms.Padding(0);
            this.panelWorkSpaseIconOUT.Name = "panelWorkSpaseIconOUT";
            this.tableLayoutMainForm.SetRowSpan(this.panelWorkSpaseIconOUT, 2);
            this.panelWorkSpaseIconOUT.Size = new System.Drawing.Size(27, 807);
            this.panelWorkSpaseIconOUT.TabIndex = 4;
            this.panelWorkSpaseIconOUT.VerticalScrollbarBarColor = true;
            this.panelWorkSpaseIconOUT.VerticalScrollbarHighlightOnWheel = false;
            this.panelWorkSpaseIconOUT.VerticalScrollbarSize = 10;
            // 
            // panelMWorkSpaceString2
            // 
            this.panelMWorkSpaceString2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMWorkSpaceString2.BackgroundImage")));
            this.panelMWorkSpaceString2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMWorkSpaceString2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMWorkSpaceString2.HorizontalScrollbarBarColor = true;
            this.panelMWorkSpaceString2.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMWorkSpaceString2.HorizontalScrollbarSize = 10;
            this.panelMWorkSpaceString2.Location = new System.Drawing.Point(0, 21);
            this.panelMWorkSpaceString2.Margin = new System.Windows.Forms.Padding(0);
            this.panelMWorkSpaceString2.Name = "panelMWorkSpaceString2";
            this.panelMWorkSpaceString2.Size = new System.Drawing.Size(27, 87);
            this.panelMWorkSpaceString2.TabIndex = 8;
            this.panelMWorkSpaceString2.VerticalScrollbarBarColor = true;
            this.panelMWorkSpaceString2.VerticalScrollbarHighlightOnWheel = false;
            this.panelMWorkSpaceString2.VerticalScrollbarSize = 10;
            // 
            // btnMWorkSpaseOpen
            // 
            this.btnMWorkSpaseOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMWorkSpaseOpen.BackgroundImage")));
            this.btnMWorkSpaseOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMWorkSpaseOpen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMWorkSpaseOpen.Location = new System.Drawing.Point(0, 0);
            this.btnMWorkSpaseOpen.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnMWorkSpaseOpen.Name = "btnMWorkSpaseOpen";
            this.btnMWorkSpaseOpen.Size = new System.Drawing.Size(27, 21);
            this.btnMWorkSpaseOpen.TabIndex = 5;
            this.btnMWorkSpaseOpen.UseSelectable = true;
            this.btnMWorkSpaseOpen.Click += new System.EventHandler(this.BtnMWorkSpaseOpenClick);
            // 
            // panelProjectMain
            // 
            this.styleExtenderMainForm.SetApplyMetroTheme(this.panelProjectMain, true);
            this.panelProjectMain.Controls.Add(this.splitContainerImageAndImageList);
            this.panelProjectMain.Controls.Add(this.tableLayoutDataReview);
            this.panelProjectMain.Controls.Add(this.panelTrainOptions);
            this.panelProjectMain.Controls.Add(this.panelMTrainOptions);
            this.panelProjectMain.Controls.Add(this.panelMDataReviewIcon);
            this.panelProjectMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProjectMain.Location = new System.Drawing.Point(27, 106);
            this.panelProjectMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelProjectMain.Name = "panelProjectMain";
            this.panelProjectMain.Size = new System.Drawing.Size(957, 701);
            this.panelProjectMain.TabIndex = 5;
            // 
            // splitContainerImageAndImageList
            // 
            this.splitContainerImageAndImageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerImageAndImageList.Location = new System.Drawing.Point(502, 0);
            this.splitContainerImageAndImageList.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerImageAndImageList.Name = "splitContainerImageAndImageList";
            // 
            // splitContainerImageAndImageList.Panel1
            // 
            this.splitContainerImageAndImageList.Panel1.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Brightness;
            this.splitContainerImageAndImageList.Size = new System.Drawing.Size(128, 701);
            this.splitContainerImageAndImageList.SplitterDistance = 52;
            this.splitContainerImageAndImageList.TabIndex = 10;
            // 
            // tableLayoutDataReview
            // 
            this.tableLayoutDataReview.ColumnCount = 4;
            this.tableLayoutDataReview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutDataReview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutDataReview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutDataReview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutDataReview.Controls.Add(this.iclTest, 3, 0);
            this.tableLayoutDataReview.Controls.Add(this.iclTrain, 2, 0);
            this.tableLayoutDataReview.Controls.Add(this.iclLabeled, 1, 0);
            this.tableLayoutDataReview.Controls.Add(this.iclTotal, 0, 0);
            this.tableLayoutDataReview.Controls.Add(this.panelDataReview, 0, 1);
            this.tableLayoutDataReview.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutDataReview.Location = new System.Drawing.Point(630, 0);
            this.tableLayoutDataReview.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutDataReview.Name = "tableLayoutDataReview";
            this.tableLayoutDataReview.RowCount = 2;
            this.tableLayoutDataReview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutDataReview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutDataReview.Size = new System.Drawing.Size(300, 701);
            this.tableLayoutDataReview.TabIndex = 9;
            // 
            // iclTest
            // 
            this.iclTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iclTest.ImageCount = "0";
            this.iclTest.ImageCountName = "Test";
            this.iclTest.Location = new System.Drawing.Point(225, 0);
            this.iclTest.Margin = new System.Windows.Forms.Padding(0);
            this.iclTest.Name = "iclTest";
            this.iclTest.Size = new System.Drawing.Size(75, 75);
            this.iclTest.TabIndex = 14;
            // 
            // iclTrain
            // 
            this.iclTrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iclTrain.ImageCount = "0";
            this.iclTrain.ImageCountName = "Train";
            this.iclTrain.Location = new System.Drawing.Point(150, 0);
            this.iclTrain.Margin = new System.Windows.Forms.Padding(0);
            this.iclTrain.Name = "iclTrain";
            this.iclTrain.Size = new System.Drawing.Size(75, 75);
            this.iclTrain.TabIndex = 13;
            // 
            // iclLabeled
            // 
            this.iclLabeled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iclLabeled.ImageCount = "0";
            this.iclLabeled.ImageCountName = "Labeled";
            this.iclLabeled.Location = new System.Drawing.Point(75, 0);
            this.iclLabeled.Margin = new System.Windows.Forms.Padding(0);
            this.iclLabeled.Name = "iclLabeled";
            this.iclLabeled.Size = new System.Drawing.Size(75, 75);
            this.iclLabeled.TabIndex = 12;
            // 
            // iclTotal
            // 
            this.iclTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iclTotal.ImageCount = "0";
            this.iclTotal.ImageCountName = "Total";
            this.iclTotal.Location = new System.Drawing.Point(0, 0);
            this.iclTotal.Margin = new System.Windows.Forms.Padding(0);
            this.iclTotal.Name = "iclTotal";
            this.iclTotal.Size = new System.Drawing.Size(75, 75);
            this.iclTotal.TabIndex = 11;
            // 
            // panelDataReview
            // 
            this.tableLayoutDataReview.SetColumnSpan(this.panelDataReview, 4);
            this.panelDataReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDataReview.Location = new System.Drawing.Point(0, 75);
            this.panelDataReview.Margin = new System.Windows.Forms.Padding(0);
            this.panelDataReview.Name = "panelDataReview";
            this.panelDataReview.Size = new System.Drawing.Size(300, 626);
            this.panelDataReview.TabIndex = 10;
            // 
            // panelTrainOptions
            // 
            this.styleExtenderMainForm.SetApplyMetroTheme(this.panelTrainOptions, true);
            this.panelTrainOptions.BackColor = System.Drawing.Color.White;
            this.panelTrainOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTrainOptions.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTrainOptions.Location = new System.Drawing.Point(27, 0);
            this.panelTrainOptions.Margin = new System.Windows.Forms.Padding(0);
            this.panelTrainOptions.Name = "panelTrainOptions";
            this.panelTrainOptions.Size = new System.Drawing.Size(475, 701);
            this.panelTrainOptions.TabIndex = 7;
            // 
            // panelMTrainOptions
            // 
            this.panelMTrainOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMTrainOptions.Controls.Add(this.panelMTrainParameterString);
            this.panelMTrainOptions.Controls.Add(this.btnMTrainOptionsOpen);
            this.panelMTrainOptions.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMTrainOptions.HorizontalScrollbarBarColor = true;
            this.panelMTrainOptions.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMTrainOptions.HorizontalScrollbarSize = 10;
            this.panelMTrainOptions.Location = new System.Drawing.Point(0, 0);
            this.panelMTrainOptions.Margin = new System.Windows.Forms.Padding(0);
            this.panelMTrainOptions.Name = "panelMTrainOptions";
            this.panelMTrainOptions.Size = new System.Drawing.Size(27, 701);
            this.panelMTrainOptions.TabIndex = 3;
            this.panelMTrainOptions.VerticalScrollbarBarColor = true;
            this.panelMTrainOptions.VerticalScrollbarHighlightOnWheel = false;
            this.panelMTrainOptions.VerticalScrollbarSize = 10;
            // 
            // panelMTrainParameterString
            // 
            this.panelMTrainParameterString.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMTrainParameterString.BackgroundImage")));
            this.panelMTrainParameterString.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMTrainParameterString.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMTrainParameterString.HorizontalScrollbarBarColor = true;
            this.panelMTrainParameterString.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMTrainParameterString.HorizontalScrollbarSize = 10;
            this.panelMTrainParameterString.Location = new System.Drawing.Point(0, 21);
            this.panelMTrainParameterString.Margin = new System.Windows.Forms.Padding(0);
            this.panelMTrainParameterString.Name = "panelMTrainParameterString";
            this.panelMTrainParameterString.Size = new System.Drawing.Size(25, 121);
            this.panelMTrainParameterString.TabIndex = 7;
            this.panelMTrainParameterString.VerticalScrollbarBarColor = true;
            this.panelMTrainParameterString.VerticalScrollbarHighlightOnWheel = false;
            this.panelMTrainParameterString.VerticalScrollbarSize = 10;
            // 
            // btnMTrainOptionsOpen
            // 
            this.btnMTrainOptionsOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMTrainOptionsOpen.BackgroundImage")));
            this.btnMTrainOptionsOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMTrainOptionsOpen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMTrainOptionsOpen.Location = new System.Drawing.Point(0, 0);
            this.btnMTrainOptionsOpen.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnMTrainOptionsOpen.Name = "btnMTrainOptionsOpen";
            this.btnMTrainOptionsOpen.Size = new System.Drawing.Size(25, 21);
            this.btnMTrainOptionsOpen.TabIndex = 6;
            this.btnMTrainOptionsOpen.UseSelectable = true;
            this.btnMTrainOptionsOpen.Click += new System.EventHandler(this.BtnMTrainOptionsOpenClick);
            // 
            // panelMDataReviewIcon
            // 
            this.panelMDataReviewIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMDataReviewIcon.Controls.Add(this.panelMDataBaseInfoString);
            this.panelMDataReviewIcon.Controls.Add(this.btnMDataReviewOpen);
            this.panelMDataReviewIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMDataReviewIcon.HorizontalScrollbarBarColor = true;
            this.panelMDataReviewIcon.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMDataReviewIcon.HorizontalScrollbarSize = 10;
            this.panelMDataReviewIcon.Location = new System.Drawing.Point(930, 0);
            this.panelMDataReviewIcon.Margin = new System.Windows.Forms.Padding(0);
            this.panelMDataReviewIcon.Name = "panelMDataReviewIcon";
            this.panelMDataReviewIcon.Size = new System.Drawing.Size(27, 701);
            this.panelMDataReviewIcon.TabIndex = 2;
            this.panelMDataReviewIcon.VerticalScrollbarBarColor = true;
            this.panelMDataReviewIcon.VerticalScrollbarHighlightOnWheel = false;
            this.panelMDataReviewIcon.VerticalScrollbarSize = 10;
            // 
            // panelMDataBaseInfoString
            // 
            this.panelMDataBaseInfoString.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMDataBaseInfoString.BackgroundImage")));
            this.panelMDataBaseInfoString.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMDataBaseInfoString.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMDataBaseInfoString.HorizontalScrollbarBarColor = true;
            this.panelMDataBaseInfoString.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMDataBaseInfoString.HorizontalScrollbarSize = 10;
            this.panelMDataBaseInfoString.Location = new System.Drawing.Point(0, 21);
            this.panelMDataBaseInfoString.Margin = new System.Windows.Forms.Padding(0);
            this.panelMDataBaseInfoString.Name = "panelMDataBaseInfoString";
            this.panelMDataBaseInfoString.Size = new System.Drawing.Size(25, 106);
            this.panelMDataBaseInfoString.TabIndex = 8;
            this.panelMDataBaseInfoString.VerticalScrollbarBarColor = true;
            this.panelMDataBaseInfoString.VerticalScrollbarHighlightOnWheel = false;
            this.panelMDataBaseInfoString.VerticalScrollbarSize = 10;
            // 
            // btnMDataReviewOpen
            // 
            this.btnMDataReviewOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMDataReviewOpen.BackgroundImage")));
            this.btnMDataReviewOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMDataReviewOpen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMDataReviewOpen.Location = new System.Drawing.Point(0, 0);
            this.btnMDataReviewOpen.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnMDataReviewOpen.Name = "btnMDataReviewOpen";
            this.btnMDataReviewOpen.Size = new System.Drawing.Size(25, 21);
            this.btnMDataReviewOpen.TabIndex = 6;
            this.btnMDataReviewOpen.UseSelectable = true;
            this.btnMDataReviewOpen.Click += new System.EventHandler(this.BtnMDataReviewOpenClick);
            // 
            // panelProjectInfo
            // 
            this.panelProjectInfo.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2GR;
            this.panelProjectInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProjectInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProjectInfo.HorizontalScrollbarBarColor = true;
            this.panelProjectInfo.HorizontalScrollbarHighlightOnWheel = false;
            this.panelProjectInfo.HorizontalScrollbarSize = 10;
            this.panelProjectInfo.Location = new System.Drawing.Point(27, 0);
            this.panelProjectInfo.Margin = new System.Windows.Forms.Padding(0);
            this.panelProjectInfo.Name = "panelProjectInfo";
            this.panelProjectInfo.Padding = new System.Windows.Forms.Padding(10);
            this.panelProjectInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelProjectInfo.Size = new System.Drawing.Size(957, 106);
            this.panelProjectInfo.TabIndex = 6;
            this.panelProjectInfo.VerticalScrollbarBarColor = true;
            this.panelProjectInfo.VerticalScrollbarHighlightOnWheel = false;
            this.panelProjectInfo.VerticalScrollbarSize = 10;
            // 
            // menuStrip1
            // 
            this.styleExtenderMainForm.SetApplyMetroTheme(this.menuStrip1, true);
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmWorSpace,
            this.viewToolStripMenuItem,
            this.toolToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "SynapseNet Learning Studio";
            // 
            // tsmWorSpace
            // 
            this.tsmWorSpace.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmProjectWorkSpaceNewProject,
            this.toolStripSeparator1,
            this.tsmProjectAllWorkSpaceSave,
            this.tsmProjectWorkSpaceSave,
            this.deleteWorkSpaceToolStripMenuItem,
            this.tsmProjectDelete,
            this.toolStripSeparator2,
            this.tsmProjectWorSpaceProgramExit,
            this.toolStripSeparator13,
            this.tsmProjectWorSpaceTestButton,
            this.toolStripMenuItem1});
            this.tsmWorSpace.Name = "tsmWorSpace";
            this.tsmWorSpace.Size = new System.Drawing.Size(78, 20);
            this.tsmWorSpace.Text = "WorkSpace";
            // 
            // tsmProjectWorkSpaceNewProject
            // 
            this.tsmProjectWorkSpaceNewProject.Image = global::ProjectAI.Properties.Resources.project_management;
            this.tsmProjectWorkSpaceNewProject.Name = "tsmProjectWorkSpaceNewProject";
            this.tsmProjectWorkSpaceNewProject.Size = new System.Drawing.Size(191, 30);
            this.tsmProjectWorkSpaceNewProject.Text = "New Project";
            this.tsmProjectWorkSpaceNewProject.Click += new System.EventHandler(this.TsmProjectWorkSpaceNewProjectClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // tsmProjectAllWorkSpaceSave
            // 
            this.tsmProjectAllWorkSpaceSave.Enabled = false;
            this.tsmProjectAllWorkSpaceSave.Image = global::ProjectAI.Properties.Resources.save_1_all;
            this.tsmProjectAllWorkSpaceSave.Name = "tsmProjectAllWorkSpaceSave";
            this.tsmProjectAllWorkSpaceSave.Size = new System.Drawing.Size(191, 30);
            this.tsmProjectAllWorkSpaceSave.Text = "Save All Project";
            this.tsmProjectAllWorkSpaceSave.Click += new System.EventHandler(this.TsmProjectAllWorkSpaceSaveClick);
            // 
            // tsmProjectWorkSpaceSave
            // 
            this.tsmProjectWorkSpaceSave.Enabled = false;
            this.tsmProjectWorkSpaceSave.Image = global::ProjectAI.Properties.Resources.save_1;
            this.tsmProjectWorkSpaceSave.Name = "tsmProjectWorkSpaceSave";
            this.tsmProjectWorkSpaceSave.Size = new System.Drawing.Size(191, 30);
            this.tsmProjectWorkSpaceSave.Text = "Save Project";
            this.tsmProjectWorkSpaceSave.Click += new System.EventHandler(this.TsmProjectWorSpaceSaveProjectClick);
            // 
            // deleteWorkSpaceToolStripMenuItem
            // 
            this.deleteWorkSpaceToolStripMenuItem.Image = global::ProjectAI.Properties.Resources.project_management_del;
            this.deleteWorkSpaceToolStripMenuItem.Name = "deleteWorkSpaceToolStripMenuItem";
            this.deleteWorkSpaceToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.deleteWorkSpaceToolStripMenuItem.Text = "Delete WorkSpace";
            this.deleteWorkSpaceToolStripMenuItem.Click += new System.EventHandler(this.TsmDeleteWorkSpaceClick);
            // 
            // tsmProjectDelete
            // 
            this.tsmProjectDelete.Image = global::ProjectAI.Properties.Resources.delete;
            this.tsmProjectDelete.Name = "tsmProjectDelete";
            this.tsmProjectDelete.Size = new System.Drawing.Size(191, 30);
            this.tsmProjectDelete.Text = "Delete Project";
            this.tsmProjectDelete.Click += new System.EventHandler(this.TsmProjectDeleteClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // tsmProjectWorSpaceProgramExit
            // 
            this.tsmProjectWorSpaceProgramExit.Image = global::ProjectAI.Properties.Resources.shutdown;
            this.tsmProjectWorSpaceProgramExit.Name = "tsmProjectWorSpaceProgramExit";
            this.tsmProjectWorSpaceProgramExit.Size = new System.Drawing.Size(191, 30);
            this.tsmProjectWorSpaceProgramExit.Text = "Program Exit";
            this.tsmProjectWorSpaceProgramExit.Click += new System.EventHandler(this.TsmProjectWorSpaceProgramExitClick);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(188, 6);
            // 
            // tsmProjectWorSpaceTestButton
            // 
            this.tsmProjectWorSpaceTestButton.Name = "tsmProjectWorSpaceTestButton";
            this.tsmProjectWorSpaceTestButton.Size = new System.Drawing.Size(191, 30);
            this.tsmProjectWorSpaceTestButton.Text = "Test Button";
            this.tsmProjectWorSpaceTestButton.Click += new System.EventHandler(this.TsmProjectWorkSpaceTestButtonClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 30);
            this.toolStripMenuItem1.Text = "Test Set Inner Project";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classToolStripMenuItem,
            this.trainToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // classToolStripMenuItem
            // 
            this.classToolStripMenuItem.Image = global::ProjectAI.Properties.Resources.product_development2;
            this.classToolStripMenuItem.Name = "classToolStripMenuItem";
            this.classToolStripMenuItem.Size = new System.Drawing.Size(109, 30);
            this.classToolStripMenuItem.Text = "Class";
            this.classToolStripMenuItem.Click += new System.EventHandler(this.ClassToolStripMenuItemClick);
            // 
            // trainToolStripMenuItem1
            // 
            this.trainToolStripMenuItem1.Image = global::ProjectAI.Properties.Resources.deeplearning_view;
            this.trainToolStripMenuItem1.Name = "trainToolStripMenuItem1";
            this.trainToolStripMenuItem1.Size = new System.Drawing.Size(109, 30);
            this.trainToolStripMenuItem1.Text = "Train";
            this.trainToolStripMenuItem1.Click += new System.EventHandler(this.TrainToolStripMenuItem1Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainToolStripMenuItem,
            this.changeStyleToolStripMenuItem,
            this.hiddenToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.toolToolStripMenuItem.Text = "Tool";
            // 
            // trainToolStripMenuItem
            // 
            this.trainToolStripMenuItem.Image = global::ProjectAI.Properties.Resources.deep_learning;
            this.trainToolStripMenuItem.Name = "trainToolStripMenuItem";
            this.trainToolStripMenuItem.Size = new System.Drawing.Size(148, 30);
            this.trainToolStripMenuItem.Text = "Train";
            this.trainToolStripMenuItem.Click += new System.EventHandler(this.TrainToolStripMenuItemClick);
            // 
            // changeStyleToolStripMenuItem
            // 
            this.changeStyleToolStripMenuItem.Image = global::ProjectAI.Properties.Resources.memphis_style;
            this.changeStyleToolStripMenuItem.Name = "changeStyleToolStripMenuItem";
            this.changeStyleToolStripMenuItem.Size = new System.Drawing.Size(148, 30);
            this.changeStyleToolStripMenuItem.Text = "ChangeStyle";
            this.changeStyleToolStripMenuItem.Click += new System.EventHandler(this.ChangeStyleToolStripMenuItemClick);
            // 
            // hiddenToolStripMenuItem
            // 
            this.hiddenToolStripMenuItem.Name = "hiddenToolStripMenuItem";
            this.hiddenToolStripMenuItem.Size = new System.Drawing.Size(148, 30);
            this.hiddenToolStripMenuItem.Text = "Hidden";
            this.hiddenToolStripMenuItem.Click += new System.EventHandler(this.HiddenToolStripMenuItemClick);
            // 
            // panelWorkSpaseIconIN
            // 
            this.styleExtenderMainForm.SetApplyMetroTheme(this.panelWorkSpaseIconIN, true);
            this.panelWorkSpaseIconIN.BackColor = System.Drawing.Color.Transparent;
            this.panelWorkSpaseIconIN.Controls.Add(this.panelMWorkSpaceString1);
            this.panelWorkSpaseIconIN.Controls.Add(this.btnMWorkSpaseClose);
            this.panelWorkSpaseIconIN.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelWorkSpaseIconIN.Location = new System.Drawing.Point(-17, 0);
            this.panelWorkSpaseIconIN.Margin = new System.Windows.Forms.Padding(0);
            this.panelWorkSpaseIconIN.Name = "panelWorkSpaseIconIN";
            this.panelWorkSpaseIconIN.Size = new System.Drawing.Size(27, 788);
            this.panelWorkSpaseIconIN.TabIndex = 2;
            // 
            // panelMWorkSpaceString1
            // 
            this.panelMWorkSpaceString1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMWorkSpaceString1.BackgroundImage")));
            this.panelMWorkSpaceString1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMWorkSpaceString1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMWorkSpaceString1.HorizontalScrollbarBarColor = true;
            this.panelMWorkSpaceString1.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMWorkSpaceString1.HorizontalScrollbarSize = 10;
            this.panelMWorkSpaceString1.Location = new System.Drawing.Point(0, 21);
            this.panelMWorkSpaceString1.Margin = new System.Windows.Forms.Padding(0);
            this.panelMWorkSpaceString1.Name = "panelMWorkSpaceString1";
            this.panelMWorkSpaceString1.Size = new System.Drawing.Size(27, 87);
            this.panelMWorkSpaceString1.TabIndex = 8;
            this.panelMWorkSpaceString1.VerticalScrollbarBarColor = true;
            this.panelMWorkSpaceString1.VerticalScrollbarHighlightOnWheel = false;
            this.panelMWorkSpaceString1.VerticalScrollbarSize = 10;
            // 
            // btnMWorkSpaseClose
            // 
            this.btnMWorkSpaseClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMWorkSpaseClose.BackgroundImage")));
            this.btnMWorkSpaseClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMWorkSpaseClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMWorkSpaseClose.Location = new System.Drawing.Point(0, 0);
            this.btnMWorkSpaseClose.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnMWorkSpaseClose.Name = "btnMWorkSpaseClose";
            this.btnMWorkSpaseClose.Size = new System.Drawing.Size(27, 21);
            this.btnMWorkSpaseClose.TabIndex = 7;
            this.btnMWorkSpaseClose.UseSelectable = true;
            this.btnMWorkSpaseClose.Click += new System.EventHandler(this.BtnMWorkSpaseCloseClick);
            // 
            // panelWorkSpaseButtonIcon
            // 
            this.styleExtenderMainForm.SetApplyMetroTheme(this.panelWorkSpaseButtonIcon, true);
            this.panelWorkSpaseButtonIcon.BackColor = System.Drawing.Color.Transparent;
            this.panelWorkSpaseButtonIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelWorkSpaseButtonIcon.Controls.Add(this.tableLayoutPanel1);
            this.panelWorkSpaseButtonIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWorkSpaseButtonIcon.Location = new System.Drawing.Point(0, 0);
            this.panelWorkSpaseButtonIcon.Margin = new System.Windows.Forms.Padding(0);
            this.panelWorkSpaseButtonIcon.Name = "panelWorkSpaseButtonIcon";
            this.panelWorkSpaseButtonIcon.Size = new System.Drawing.Size(0, 32);
            this.panelWorkSpaseButtonIcon.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Controls.Add(this.btnMDeleteWorkSpace, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMnewWorkSpace, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 32);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnMDeleteWorkSpace
            // 
            this.btnMDeleteWorkSpace.BackgroundImage = global::ProjectAI.Properties.Resources.minus;
            this.btnMDeleteWorkSpace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMDeleteWorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMDeleteWorkSpace.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.btnMDeleteWorkSpace.Location = new System.Drawing.Point(-60, 3);
            this.btnMDeleteWorkSpace.Name = "btnMDeleteWorkSpace";
            this.btnMDeleteWorkSpace.Size = new System.Drawing.Size(26, 26);
            this.btnMDeleteWorkSpace.TabIndex = 1;
            this.btnMDeleteWorkSpace.UseSelectable = true;
            this.btnMDeleteWorkSpace.Click += new System.EventHandler(this.BtnMDeleteWorkSpaceClick);
            // 
            // btnMnewWorkSpace
            // 
            this.btnMnewWorkSpace.BackgroundImage = global::ProjectAI.Properties.Resources.plus;
            this.btnMnewWorkSpace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMnewWorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMnewWorkSpace.Location = new System.Drawing.Point(-28, 3);
            this.btnMnewWorkSpace.Name = "btnMnewWorkSpace";
            this.btnMnewWorkSpace.Size = new System.Drawing.Size(26, 26);
            this.btnMnewWorkSpace.TabIndex = 0;
            this.btnMnewWorkSpace.UseSelectable = true;
            this.btnMnewWorkSpace.Click += new System.EventHandler(this.BtnMnewWorkSpaceClick);
            // 
            // panelstatus
            // 
            this.panelstatus.Controls.Add(this.lblMworkInFileName);
            this.panelstatus.Controls.Add(this.lblMIOStatus);
            this.panelstatus.Controls.Add(this.lblMtotalNumber);
            this.panelstatus.Controls.Add(this.lblStatus);
            this.panelstatus.Controls.Add(this.lblMwaorkInNumber);
            this.panelstatus.Controls.Add(this.pgbMfileIOstatus);
            this.panelstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelstatus.Location = new System.Drawing.Point(0, 812);
            this.panelstatus.Margin = new System.Windows.Forms.Padding(0);
            this.panelstatus.Name = "panelstatus";
            this.panelstatus.Padding = new System.Windows.Forms.Padding(1);
            this.panelstatus.Size = new System.Drawing.Size(984, 19);
            this.panelstatus.TabIndex = 4;
            // 
            // lblMworkInFileName
            // 
            this.lblMworkInFileName.AutoSize = true;
            this.lblMworkInFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblMworkInFileName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMworkInFileName.Location = new System.Drawing.Point(664, 1);
            this.lblMworkInFileName.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lblMworkInFileName.Name = "lblMworkInFileName";
            this.lblMworkInFileName.Size = new System.Drawing.Size(97, 19);
            this.lblMworkInFileName.TabIndex = 11;
            this.lblMworkInFileName.Text = "처리중인 파일";
            this.lblMworkInFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMIOStatus
            // 
            this.lblMIOStatus.AutoSize = true;
            this.lblMIOStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblMIOStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMIOStatus.Location = new System.Drawing.Point(595, 1);
            this.lblMIOStatus.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lblMIOStatus.Name = "lblMIOStatus";
            this.lblMIOStatus.Size = new System.Drawing.Size(69, 19);
            this.lblMIOStatus.TabIndex = 10;
            this.lblMIOStatus.Text = "동작 상태";
            this.lblMIOStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMtotalNumber
            // 
            this.lblMtotalNumber.AutoSize = true;
            this.lblMtotalNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblMtotalNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMtotalNumber.Location = new System.Drawing.Point(430, 1);
            this.lblMtotalNumber.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lblMtotalNumber.Name = "lblMtotalNumber";
            this.lblMtotalNumber.Size = new System.Drawing.Size(165, 19);
            this.lblMtotalNumber.TabIndex = 9;
            this.lblMtotalNumber.Text = "총 처리해야 하는 파일 수";
            this.lblMtotalNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStatus.Location = new System.Drawing.Point(416, 1);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(14, 19);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "/";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMwaorkInNumber
            // 
            this.lblMwaorkInNumber.AutoSize = true;
            this.lblMwaorkInNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblMwaorkInNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMwaorkInNumber.Location = new System.Drawing.Point(301, 1);
            this.lblMwaorkInNumber.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lblMwaorkInNumber.Name = "lblMwaorkInNumber";
            this.lblMwaorkInNumber.Size = new System.Drawing.Size(115, 19);
            this.lblMwaorkInNumber.TabIndex = 1;
            this.lblMwaorkInNumber.Text = "처리중인 파일 수";
            this.lblMwaorkInNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgbMfileIOstatus
            // 
            this.pgbMfileIOstatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.pgbMfileIOstatus.Location = new System.Drawing.Point(1, 1);
            this.pgbMfileIOstatus.Margin = new System.Windows.Forms.Padding(1);
            this.pgbMfileIOstatus.Name = "pgbMfileIOstatus";
            this.pgbMfileIOstatus.Size = new System.Drawing.Size(300, 17);
            this.pgbMfileIOstatus.TabIndex = 0;
            this.pgbMfileIOstatus.Value = 50;
            // 
            // panelMWorkSpase
            // 
            this.panelMWorkSpase.Controls.Add(this.panelWorkSpaseButton);
            this.panelMWorkSpase.Controls.Add(this.panelWorkSpaseButtonIcon);
            this.panelMWorkSpase.Controls.Add(this.panelWorkSpaseIconIN);
            this.panelMWorkSpase.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMWorkSpase.HorizontalScrollbarBarColor = true;
            this.panelMWorkSpase.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMWorkSpase.HorizontalScrollbarSize = 10;
            this.panelMWorkSpase.Location = new System.Drawing.Point(0, 24);
            this.panelMWorkSpase.Margin = new System.Windows.Forms.Padding(0);
            this.panelMWorkSpase.Name = "panelMWorkSpase";
            this.panelMWorkSpase.Size = new System.Drawing.Size(10, 788);
            this.panelMWorkSpase.TabIndex = 6;
            this.panelMWorkSpase.VerticalScrollbarBarColor = true;
            this.panelMWorkSpase.VerticalScrollbarHighlightOnWheel = false;
            this.panelMWorkSpase.VerticalScrollbarSize = 10;
            // 
            // panelWorkSpaseButton
            // 
            this.panelWorkSpaseButton.BackColor = System.Drawing.Color.Transparent;
            this.panelWorkSpaseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkSpaseButton.Location = new System.Drawing.Point(0, 32);
            this.panelWorkSpaseButton.Margin = new System.Windows.Forms.Padding(0);
            this.panelWorkSpaseButton.Name = "panelWorkSpaseButton";
            this.panelWorkSpaseButton.Padding = new System.Windows.Forms.Padding(2);
            this.panelWorkSpaseButton.Size = new System.Drawing.Size(0, 756);
            this.panelWorkSpaseButton.TabIndex = 4;
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.cmsMtryIcon;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "SynapseNet Learning Studio";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.ShowToolStripMenuItemClick);
            // 
            // cmsMtryIcon
            // 
            this.cmsMtryIcon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsMtryIcon.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsMtryIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.cmsMtryIcon.Name = "cmsMtryIcon";
            this.cmsMtryIcon.Size = new System.Drawing.Size(112, 64);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Image = global::ProjectAI.Properties.Resources.synapseimaging;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(111, 30);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::ProjectAI.Properties.Resources.shutdown;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(984, 831);
            this.Controls.Add(this.panelMWorkSpase);
            this.Controls.Add(this.panelstatus);
            this.Controls.Add(this.tableLayoutMainForm);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SynapseNet Deep Learning Studio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.Shown += new System.EventHandler(this.MainFormShown);
            ((System.ComponentModel.ISupportInitialize)(this.styleManagerMainForm)).EndInit();
            this.tableLayoutMainForm.ResumeLayout(false);
            this.panelWorkSpaseIconOUT.ResumeLayout(false);
            this.panelProjectMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerImageAndImageList)).EndInit();
            this.splitContainerImageAndImageList.ResumeLayout(false);
            this.tableLayoutDataReview.ResumeLayout(false);
            this.panelMTrainOptions.ResumeLayout(false);
            this.panelMDataReviewIcon.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelWorkSpaseIconIN.ResumeLayout(false);
            this.panelWorkSpaseButtonIcon.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelstatus.ResumeLayout(false);
            this.panelstatus.PerformLayout();
            this.panelMWorkSpase.ResumeLayout(false);
            this.cmsMtryIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager styleManagerMainForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMainForm;
        private MetroFramework.Controls.MetroPanel panelMDataReviewIcon;
        private MetroFramework.Controls.MetroPanel panelMWorkSpase;
        private MetroFramework.Controls.MetroButton btnMDataReviewOpen;
        private MetroFramework.Controls.MetroPanel panelWorkSpaseIconOUT;
        private MetroFramework.Controls.MetroButton btnMWorkSpaseOpen;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmWorSpace;
        private System.Windows.Forms.ToolStripMenuItem tsmProjectWorkSpaceNewProject;
        private System.Windows.Forms.Panel panelWorkSpaseIconIN;
        private System.Windows.Forms.Panel panelWorkSpaseButtonIcon;
        private MetroFramework.Controls.MetroButton btnMnewWorkSpace;
        private System.Windows.Forms.Panel panelProjectMain;
        private MetroFramework.Controls.MetroPanel panelMTrainOptions;
        private MetroFramework.Controls.MetroButton btnMTrainOptionsOpen;
        private System.Windows.Forms.Panel panelWorkSpaseButton;
        private System.Windows.Forms.ToolStripMenuItem tsmProjectDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmProjectWorSpaceProgramExit;
        private System.Windows.Forms.ToolStripMenuItem tsmProjectWorSpaceTestButton;
        public MetroFramework.Components.MetroStyleExtender styleExtenderMainForm;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public MetroFramework.Controls.MetroPanel panelProjectInfo;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainToolStripMenuItem;
        public System.Windows.Forms.Panel panelstatus;
        public MetroFramework.Controls.MetroProgressBar pgbMfileIOstatus;
        public MetroFramework.Controls.MetroLabel lblMwaorkInNumber;
        public MetroFramework.Controls.MetroLabel lblMworkInFileName;
        public MetroFramework.Controls.MetroLabel lblMIOStatus;
        public MetroFramework.Controls.MetroLabel lblMtotalNumber;
        public MetroFramework.Controls.MetroLabel lblStatus;
        private MetroFramework.Controls.MetroPanel panelMWorkSpaceString1;
        private MetroFramework.Controls.MetroPanel panelMWorkSpaceString2;
        private MetroFramework.Controls.MetroPanel panelMTrainParameterString;
        private MetroFramework.Controls.MetroPanel panelMDataBaseInfoString;
        private MetroFramework.Controls.MetroButton btnMWorkSpaseClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        public System.Windows.Forms.ToolStripMenuItem tsmProjectWorkSpaceSave;
        public System.Windows.Forms.ToolStripMenuItem tsmProjectAllWorkSpaceSave;
        private System.Windows.Forms.ToolStripMenuItem deleteWorkSpaceToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton btnMDeleteWorkSpace;
        private System.Windows.Forms.TableLayoutPanel tableLayoutDataReview;
        public ProjectAI.MainForms.ImageCountLabel iclTest;
        public ProjectAI.MainForms.ImageCountLabel iclTrain;
        public ProjectAI.MainForms.ImageCountLabel iclLabeled;
        public ProjectAI.MainForms.ImageCountLabel iclTotal;
        public System.Windows.Forms.Panel panelDataReview;
        private System.Windows.Forms.ToolStripMenuItem trainToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem changeStyleToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private MetroFramework.Controls.MetroContextMenu cmsMtryIcon;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hiddenToolStripMenuItem;
        public System.Windows.Forms.SplitContainer splitContainerImageAndImageList;
    }
}