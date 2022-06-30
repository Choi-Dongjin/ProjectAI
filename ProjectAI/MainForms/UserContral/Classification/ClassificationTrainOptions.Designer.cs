namespace ProjectAI.CustomComponent.MainForms.Classification
{
    partial class ClassificationTrainOptions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassificationTrainOptions));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelUnderbar5 = new System.Windows.Forms.Panel();
            this.panelUnderbar3 = new System.Windows.Forms.Panel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.lblMnetworkModel = new MetroFramework.Controls.MetroLabel();
            this.cbbArchitecture = new MetroFramework.Controls.MetroComboBox();
            this.cbbManetworkModel = new MetroFramework.Controls.MetroComboBox();
            this.lblMepochNumber = new MetroFramework.Controls.MetroLabel();
            this.lblMmodelMinimumSelectionEpoch = new MetroFramework.Controls.MetroLabel();
            this.lblMtrainRepeat = new MetroFramework.Controls.MetroLabel();
            this.lblMvalidationRatio = new MetroFramework.Controls.MetroLabel();
            this.lblMpatienceEpochs = new MetroFramework.Controls.MetroLabel();
            this.lblMTrainDataNumber = new MetroFramework.Controls.MetroLabel();
            this.txtMmodelMinimumSelectionEpoch = new System.Windows.Forms.TextBox();
            this.panelUnderbar2 = new System.Windows.Forms.Panel();
            this.txtPatienceEpochs = new System.Windows.Forms.TextBox();
            this.panelUnderbar1 = new System.Windows.Forms.Panel();
            this.panelUnderbar4 = new System.Windows.Forms.Panel();
            this.panelUnderbar6 = new System.Windows.Forms.Panel();
            this.txtEpochNumber = new System.Windows.Forms.TextBox();
            this.txtTrainRepeat = new System.Windows.Forms.TextBox();
            this.txtValidationRatio = new System.Windows.Forms.TextBox();
            this.txtTrainDataNumber = new System.Windows.Forms.TextBox();
            this.btnEpochNumberS = new System.Windows.Forms.Button();
            this.btnEpochNumberP = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btnMmodelMinimumSelectionEpochS = new System.Windows.Forms.Button();
            this.btnPatienceEpochsS = new System.Windows.Forms.Button();
            this.btnMmodelMinimumSelectionEpochP = new System.Windows.Forms.Button();
            this.btnPatienceEpochsP = new System.Windows.Forms.Button();
            this.btnTrainRepeatP = new System.Windows.Forms.Button();
            this.btnValidationRatioP = new System.Windows.Forms.Button();
            this.btnTrainRepeatS = new System.Windows.Forms.Button();
            this.btnValidationRatioS = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelMZoomToolTip = new MetroFramework.Controls.MetroPanel();
            this.panelMVerticalFlipToolTip = new MetroFramework.Controls.MetroPanel();
            this.panelMSharpenToolTip = new MetroFramework.Controls.MetroPanel();
            this.panelMRotation270ToolTip = new MetroFramework.Controls.MetroPanel();
            this.panelMRotation180ToolTip = new MetroFramework.Controls.MetroPanel();
            this.panelMRotation90ToolTip = new MetroFramework.Controls.MetroPanel();
            this.panelMHorizontalFlipToolTip = new MetroFramework.Controls.MetroPanel();
            this.panelMGradationRGBToolTip = new MetroFramework.Controls.MetroPanel();
            this.panelMGradationToolTip = new MetroFramework.Controls.MetroPanel();
            this.panelMContrastToolTip = new MetroFramework.Controls.MetroPanel();
            this.panelMCenterToolTip = new MetroFramework.Controls.MetroPanel();
            this.tilMZoom = new MetroFramework.Controls.MetroTile();
            this.txtBlur = new System.Windows.Forms.TextBox();
            this.tilMBrightness = new MetroFramework.Controls.MetroTile();
            this.ckbMHorizontalFlip = new MetroFramework.Controls.MetroCheckBox();
            this.ckbMBlur = new MetroFramework.Controls.MetroCheckBox();
            this.ckbMContrast = new MetroFramework.Controls.MetroCheckBox();
            this.ckbBrightness = new MetroFramework.Controls.MetroCheckBox();
            this.ckbMCenter = new MetroFramework.Controls.MetroCheckBox();
            this.ckbMGaussianNoise = new MetroFramework.Controls.MetroCheckBox();
            this.ckbMGradation = new MetroFramework.Controls.MetroCheckBox();
            this.ckbGradationRGB = new MetroFramework.Controls.MetroCheckBox();
            this.ckbMRotation90 = new MetroFramework.Controls.MetroCheckBox();
            this.ckbMRotation180 = new MetroFramework.Controls.MetroCheckBox();
            this.ckbMRotation270 = new MetroFramework.Controls.MetroCheckBox();
            this.ckbMSharpen = new MetroFramework.Controls.MetroCheckBox();
            this.ckbMVerticalFlip = new MetroFramework.Controls.MetroCheckBox();
            this.ckbMZoom = new MetroFramework.Controls.MetroCheckBox();
            this.lblMDataAugmentation = new MetroFramework.Controls.MetroLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.txtBrightnessMin = new System.Windows.Forms.TextBox();
            this.txtBrightnessMax = new System.Windows.Forms.TextBox();
            this.txtCenter = new System.Windows.Forms.TextBox();
            this.txtContrastMin = new System.Windows.Forms.TextBox();
            this.txtContrastMax = new System.Windows.Forms.TextBox();
            this.txtGaussianNoise = new System.Windows.Forms.TextBox();
            this.txtGradation = new System.Windows.Forms.TextBox();
            this.txtSharpen = new System.Windows.Forms.TextBox();
            this.txtZoomMin = new System.Windows.Forms.TextBox();
            this.txtZoomMax = new System.Windows.Forms.TextBox();
            this.panelMBlurToolTip = new MetroFramework.Controls.MetroPanel();
            this.tilMBlur = new MetroFramework.Controls.MetroTile();
            this.tilMSharpen = new MetroFramework.Controls.MetroTile();
            this.tilMCenter = new MetroFramework.Controls.MetroTile();
            this.tilMGaussianNoise = new MetroFramework.Controls.MetroTile();
            this.panelMBrightnessToolTip = new MetroFramework.Controls.MetroPanel();
            this.panelMGaussianNoiseToolTip = new MetroFramework.Controls.MetroPanel();
            this.tilMContrast = new MetroFramework.Controls.MetroTile();
            this.tilMGradationRGB = new MetroFramework.Controls.MetroTile();
            this.tilMGradation = new MetroFramework.Controls.MetroTile();
            this.tlpContinualLearning = new System.Windows.Forms.TableLayoutPanel();
            this.lblMContinualLearning = new MetroFramework.Controls.MetroLabel();
            this.togMContinualLearning = new MetroFramework.Controls.MetroToggle();
            this.panelContinualLearning = new System.Windows.Forms.Panel();
            this.dgvMContinualLearning = new MetroFramework.Controls.MetroGrid();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panelMClassWeight = new MetroFramework.Controls.MetroPanel();
            this.classWeightControl1 = new ProjectAI.MainForms.UserContral.Classification.ClassWeightControl();
            this.lblMClassWeight = new MetroFramework.Controls.MetroLabel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMInstantEvaluate = new MetroFramework.Controls.MetroLabel();
            this.togMInstantEvaluate = new MetroFramework.Controls.MetroToggle();
            this.panelInstantEvaluate = new System.Windows.Forms.Panel();
            this.tlpInstantEvaluate = new System.Windows.Forms.TableLayoutPanel();
            this.tilMInstantEvaluateTest = new MetroFramework.Controls.MetroTile();
            this.tilMInstantEvaluateTrain = new MetroFramework.Controls.MetroTile();
            this.tilMInstantEvaluateAll = new MetroFramework.Controls.MetroTile();
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpContinualLearning.SuspendLayout();
            this.panelContinualLearning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMContinualLearning)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.panelMClassWeight.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panelInstantEvaluate.SuspendLayout();
            this.tlpInstantEvaluate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.AutoScroll = true;
            this.metroPanel1.AutoScrollMinSize = new System.Drawing.Size(460, 820);
            this.metroPanel1.Controls.Add(this.flowLayoutPanel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbar = true;
            this.metroPanel1.HorizontalScrollbarBarColor = false;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 20);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.metroPanel1.Size = new System.Drawing.Size(470, 820);
            this.metroPanel1.TabIndex = 6;
            this.metroPanel1.VerticalScrollbar = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Controls.Add(this.tlpContinualLearning);
            this.flowLayoutPanel1.Controls.Add(this.panelContinualLearning);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel5);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel4);
            this.flowLayoutPanel1.Controls.Add(this.panelInstantEvaluate);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(460, 820);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 11;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panelUnderbar5, 8, 6);
            this.tableLayoutPanel2.Controls.Add(this.panelUnderbar3, 2, 8);
            this.tableLayoutPanel2.Controls.Add(this.metroLabel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.metroLabel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblMnetworkModel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbbArchitecture, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbbManetworkModel, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblMepochNumber, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblMmodelMinimumSelectionEpoch, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblMtrainRepeat, 6, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblMvalidationRatio, 6, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblMpatienceEpochs, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.lblMTrainDataNumber, 6, 7);
            this.tableLayoutPanel2.Controls.Add(this.txtMmodelMinimumSelectionEpoch, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.panelUnderbar2, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtPatienceEpochs, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.panelUnderbar1, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.panelUnderbar4, 8, 4);
            this.tableLayoutPanel2.Controls.Add(this.panelUnderbar6, 8, 8);
            this.tableLayoutPanel2.Controls.Add(this.txtEpochNumber, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtTrainRepeat, 8, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtValidationRatio, 8, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtTrainDataNumber, 8, 7);
            this.tableLayoutPanel2.Controls.Add(this.btnEpochNumberS, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnEpochNumberP, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBox5, 9, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnMmodelMinimumSelectionEpochS, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnPatienceEpochsS, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.btnMmodelMinimumSelectionEpochP, 4, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnPatienceEpochsP, 4, 7);
            this.tableLayoutPanel2.Controls.Add(this.btnTrainRepeatP, 10, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnValidationRatioP, 10, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnTrainRepeatS, 7, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnValidationRatioS, 7, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 5);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(460, 166);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // panelUnderbar5
            // 
            this.panelUnderbar5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUnderbar5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel2.SetColumnSpan(this.panelUnderbar5, 2);
            this.panelUnderbar5.Location = new System.Drawing.Point(383, 138);
            this.panelUnderbar5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelUnderbar5.Name = "panelUnderbar5";
            this.panelUnderbar5.Size = new System.Drawing.Size(54, 1);
            this.panelUnderbar5.TabIndex = 27;
            // 
            // panelUnderbar3
            // 
            this.panelUnderbar3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUnderbar3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel2.SetColumnSpan(this.panelUnderbar3, 2);
            this.panelUnderbar3.Location = new System.Drawing.Point(143, 159);
            this.panelUnderbar3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelUnderbar3.Name = "panelUnderbar3";
            this.panelUnderbar3.Size = new System.Drawing.Size(54, 1);
            this.panelUnderbar3.TabIndex = 25;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.metroLabel2, 11);
            this.metroLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(3, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(454, 35);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "Train Options";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel3.Location = new System.Drawing.Point(3, 35);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(114, 31);
            this.metroLabel3.TabIndex = 1;
            this.metroLabel3.Text = "Architecture";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMnetworkModel
            // 
            this.lblMnetworkModel.AutoSize = true;
            this.lblMnetworkModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMnetworkModel.Location = new System.Drawing.Point(3, 66);
            this.lblMnetworkModel.Name = "lblMnetworkModel";
            this.lblMnetworkModel.Size = new System.Drawing.Size(114, 31);
            this.lblMnetworkModel.TabIndex = 2;
            this.lblMnetworkModel.Text = "Network Model";
            this.lblMnetworkModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbbArchitecture
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cbbArchitecture, 4);
            this.cbbArchitecture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbArchitecture.FormattingEnabled = true;
            this.cbbArchitecture.ItemHeight = 23;
            this.cbbArchitecture.Location = new System.Drawing.Point(121, 36);
            this.cbbArchitecture.Margin = new System.Windows.Forms.Padding(1);
            this.cbbArchitecture.Name = "cbbArchitecture";
            this.cbbArchitecture.Size = new System.Drawing.Size(98, 29);
            this.cbbArchitecture.TabIndex = 4;
            this.cbbArchitecture.UseSelectable = true;
            // 
            // cbbManetworkModel
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cbbManetworkModel, 4);
            this.cbbManetworkModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbManetworkModel.FormattingEnabled = true;
            this.cbbManetworkModel.ItemHeight = 23;
            this.cbbManetworkModel.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Large"});
            this.cbbManetworkModel.Location = new System.Drawing.Point(121, 67);
            this.cbbManetworkModel.Margin = new System.Windows.Forms.Padding(1);
            this.cbbManetworkModel.Name = "cbbManetworkModel";
            this.cbbManetworkModel.PromptText = "Medium";
            this.cbbManetworkModel.Size = new System.Drawing.Size(98, 29);
            this.cbbManetworkModel.TabIndex = 5;
            this.cbbManetworkModel.UseSelectable = true;
            this.cbbManetworkModel.SelectedIndexChanged += new System.EventHandler(this.BbbMnetworkModelSelectedIndexChanged);
            // 
            // lblMepochNumber
            // 
            this.lblMepochNumber.AutoSize = true;
            this.lblMepochNumber.Location = new System.Drawing.Point(3, 97);
            this.lblMepochNumber.Name = "lblMepochNumber";
            this.lblMepochNumber.Size = new System.Drawing.Size(98, 19);
            this.lblMepochNumber.TabIndex = 6;
            this.lblMepochNumber.Text = "Epoch Number";
            this.lblMepochNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMmodelMinimumSelectionEpoch
            // 
            this.lblMmodelMinimumSelectionEpoch.AutoSize = true;
            this.lblMmodelMinimumSelectionEpoch.Location = new System.Drawing.Point(3, 118);
            this.lblMmodelMinimumSelectionEpoch.Name = "lblMmodelMinimumSelectionEpoch";
            this.lblMmodelMinimumSelectionEpoch.Size = new System.Drawing.Size(105, 19);
            this.lblMmodelMinimumSelectionEpoch.TabIndex = 7;
            this.lblMmodelMinimumSelectionEpoch.Text = "Epoch Minimum";
            this.lblMmodelMinimumSelectionEpoch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMtrainRepeat
            // 
            this.lblMtrainRepeat.AutoSize = true;
            this.lblMtrainRepeat.Location = new System.Drawing.Point(243, 97);
            this.lblMtrainRepeat.Name = "lblMtrainRepeat";
            this.lblMtrainRepeat.Size = new System.Drawing.Size(81, 19);
            this.lblMtrainRepeat.TabIndex = 8;
            this.lblMtrainRepeat.Text = "Train Repeat";
            this.lblMtrainRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMvalidationRatio
            // 
            this.lblMvalidationRatio.AutoSize = true;
            this.lblMvalidationRatio.Location = new System.Drawing.Point(243, 118);
            this.lblMvalidationRatio.Name = "lblMvalidationRatio";
            this.lblMvalidationRatio.Size = new System.Drawing.Size(99, 19);
            this.lblMvalidationRatio.TabIndex = 9;
            this.lblMvalidationRatio.Text = "Validation Ratio";
            this.lblMvalidationRatio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMpatienceEpochs
            // 
            this.lblMpatienceEpochs.AutoSize = true;
            this.lblMpatienceEpochs.Location = new System.Drawing.Point(3, 139);
            this.lblMpatienceEpochs.Name = "lblMpatienceEpochs";
            this.lblMpatienceEpochs.Size = new System.Drawing.Size(97, 19);
            this.lblMpatienceEpochs.TabIndex = 10;
            this.lblMpatienceEpochs.Text = "Epoch Patience";
            this.lblMpatienceEpochs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMTrainDataNumber
            // 
            this.lblMTrainDataNumber.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblMTrainDataNumber, 2);
            this.lblMTrainDataNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMTrainDataNumber.Location = new System.Drawing.Point(243, 139);
            this.lblMTrainDataNumber.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblMTrainDataNumber.Name = "lblMTrainDataNumber";
            this.lblMTrainDataNumber.Size = new System.Drawing.Size(137, 20);
            this.lblMTrainDataNumber.TabIndex = 11;
            this.lblMTrainDataNumber.Text = "Train Data Number";
            this.lblMTrainDataNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMmodelMinimumSelectionEpoch
            // 
            this.txtMmodelMinimumSelectionEpoch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtMmodelMinimumSelectionEpoch, true);
            this.txtMmodelMinimumSelectionEpoch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel2.SetColumnSpan(this.txtMmodelMinimumSelectionEpoch, 2);
            this.txtMmodelMinimumSelectionEpoch.Location = new System.Drawing.Point(143, 124);
            this.txtMmodelMinimumSelectionEpoch.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtMmodelMinimumSelectionEpoch.Name = "txtMmodelMinimumSelectionEpoch";
            this.txtMmodelMinimumSelectionEpoch.Size = new System.Drawing.Size(54, 14);
            this.txtMmodelMinimumSelectionEpoch.TabIndex = 23;
            this.txtMmodelMinimumSelectionEpoch.Text = "5";
            this.txtMmodelMinimumSelectionEpoch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMmodelMinimumSelectionEpoch.TextChanged += new System.EventHandler(this.TxtMmodelMinimumSelectionEpochTextChanged);
            // 
            // panelUnderbar2
            // 
            this.panelUnderbar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUnderbar2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel2.SetColumnSpan(this.panelUnderbar2, 2);
            this.panelUnderbar2.Location = new System.Drawing.Point(143, 138);
            this.panelUnderbar2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelUnderbar2.Name = "panelUnderbar2";
            this.panelUnderbar2.Size = new System.Drawing.Size(54, 1);
            this.panelUnderbar2.TabIndex = 24;
            // 
            // txtPatienceEpochs
            // 
            this.txtPatienceEpochs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtPatienceEpochs, true);
            this.txtPatienceEpochs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel2.SetColumnSpan(this.txtPatienceEpochs, 2);
            this.txtPatienceEpochs.Location = new System.Drawing.Point(143, 145);
            this.txtPatienceEpochs.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtPatienceEpochs.Name = "txtPatienceEpochs";
            this.txtPatienceEpochs.Size = new System.Drawing.Size(54, 14);
            this.txtPatienceEpochs.TabIndex = 25;
            this.txtPatienceEpochs.Text = "5";
            this.txtPatienceEpochs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPatienceEpochs.TextChanged += new System.EventHandler(this.TxtPatienceEpochsTextChanged);
            // 
            // panelUnderbar1
            // 
            this.panelUnderbar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUnderbar1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel2.SetColumnSpan(this.panelUnderbar1, 2);
            this.panelUnderbar1.Location = new System.Drawing.Point(143, 117);
            this.panelUnderbar1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelUnderbar1.Name = "panelUnderbar1";
            this.panelUnderbar1.Size = new System.Drawing.Size(54, 1);
            this.panelUnderbar1.TabIndex = 26;
            // 
            // panelUnderbar4
            // 
            this.panelUnderbar4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUnderbar4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel2.SetColumnSpan(this.panelUnderbar4, 2);
            this.panelUnderbar4.Location = new System.Drawing.Point(383, 117);
            this.panelUnderbar4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelUnderbar4.Name = "panelUnderbar4";
            this.panelUnderbar4.Size = new System.Drawing.Size(54, 1);
            this.panelUnderbar4.TabIndex = 27;
            // 
            // panelUnderbar6
            // 
            this.panelUnderbar6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUnderbar6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel2.SetColumnSpan(this.panelUnderbar6, 2);
            this.panelUnderbar6.Location = new System.Drawing.Point(383, 159);
            this.panelUnderbar6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelUnderbar6.Name = "panelUnderbar6";
            this.panelUnderbar6.Size = new System.Drawing.Size(54, 1);
            this.panelUnderbar6.TabIndex = 28;
            // 
            // txtEpochNumber
            // 
            this.txtEpochNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtEpochNumber, true);
            this.txtEpochNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel2.SetColumnSpan(this.txtEpochNumber, 2);
            this.txtEpochNumber.Location = new System.Drawing.Point(143, 103);
            this.txtEpochNumber.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtEpochNumber.Name = "txtEpochNumber";
            this.txtEpochNumber.Size = new System.Drawing.Size(54, 14);
            this.txtEpochNumber.TabIndex = 29;
            this.txtEpochNumber.Text = "100";
            this.txtEpochNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEpochNumber.TextChanged += new System.EventHandler(this.TxtEpochNumberTextChanged);
            // 
            // txtTrainRepeat
            // 
            this.txtTrainRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtTrainRepeat, true);
            this.txtTrainRepeat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel2.SetColumnSpan(this.txtTrainRepeat, 2);
            this.txtTrainRepeat.Location = new System.Drawing.Point(383, 103);
            this.txtTrainRepeat.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtTrainRepeat.Name = "txtTrainRepeat";
            this.txtTrainRepeat.Size = new System.Drawing.Size(54, 14);
            this.txtTrainRepeat.TabIndex = 30;
            this.txtTrainRepeat.Text = "3";
            this.txtTrainRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTrainRepeat.TextChanged += new System.EventHandler(this.TxtTrainRepeatTextChanged);
            // 
            // txtValidationRatio
            // 
            this.txtValidationRatio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtValidationRatio, true);
            this.txtValidationRatio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValidationRatio.Location = new System.Drawing.Point(383, 124);
            this.txtValidationRatio.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.txtValidationRatio.Name = "txtValidationRatio";
            this.txtValidationRatio.Size = new System.Drawing.Size(27, 14);
            this.txtValidationRatio.TabIndex = 31;
            this.txtValidationRatio.Text = "0";
            this.txtValidationRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValidationRatio.TextChanged += new System.EventHandler(this.TxtValidationRatioTextChanged);
            // 
            // txtTrainDataNumber
            // 
            this.txtTrainDataNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtTrainDataNumber, true);
            this.txtTrainDataNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel2.SetColumnSpan(this.txtTrainDataNumber, 2);
            this.txtTrainDataNumber.Location = new System.Drawing.Point(383, 145);
            this.txtTrainDataNumber.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtTrainDataNumber.Name = "txtTrainDataNumber";
            this.txtTrainDataNumber.ReadOnly = true;
            this.txtTrainDataNumber.Size = new System.Drawing.Size(54, 14);
            this.txtTrainDataNumber.TabIndex = 32;
            this.txtTrainDataNumber.Text = "100";
            this.txtTrainDataNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEpochNumberS
            // 
            this.btnEpochNumberS.BackgroundImage = global::ProjectAI.Properties.Resources.arrowLeft4;
            this.btnEpochNumberS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEpochNumberS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEpochNumberS.FlatAppearance.BorderSize = 0;
            this.btnEpochNumberS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEpochNumberS.Location = new System.Drawing.Point(120, 97);
            this.btnEpochNumberS.Margin = new System.Windows.Forms.Padding(0);
            this.btnEpochNumberS.Name = "btnEpochNumberS";
            this.btnEpochNumberS.Size = new System.Drawing.Size(20, 20);
            this.btnEpochNumberS.TabIndex = 33;
            this.btnEpochNumberS.UseVisualStyleBackColor = true;
            this.btnEpochNumberS.Click += new System.EventHandler(this.BtnEpochNumberSClick);
            // 
            // btnEpochNumberP
            // 
            this.btnEpochNumberP.BackgroundImage = global::ProjectAI.Properties.Resources.arrowRight4;
            this.btnEpochNumberP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEpochNumberP.FlatAppearance.BorderSize = 0;
            this.btnEpochNumberP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEpochNumberP.Location = new System.Drawing.Point(200, 97);
            this.btnEpochNumberP.Margin = new System.Windows.Forms.Padding(0);
            this.btnEpochNumberP.Name = "btnEpochNumberP";
            this.btnEpochNumberP.Size = new System.Drawing.Size(20, 20);
            this.btnEpochNumberP.TabIndex = 34;
            this.btnEpochNumberP.UseVisualStyleBackColor = true;
            this.btnEpochNumberP.Click += new System.EventHandler(this.BtnEpochNumberPClick);
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.textBox5, true);
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(410, 124);
            this.textBox5.Margin = new System.Windows.Forms.Padding(0);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(27, 14);
            this.textBox5.TabIndex = 35;
            this.textBox5.Text = "%";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMmodelMinimumSelectionEpochS
            // 
            this.btnMmodelMinimumSelectionEpochS.BackgroundImage = global::ProjectAI.Properties.Resources.arrowLeft4;
            this.btnMmodelMinimumSelectionEpochS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMmodelMinimumSelectionEpochS.FlatAppearance.BorderSize = 0;
            this.btnMmodelMinimumSelectionEpochS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMmodelMinimumSelectionEpochS.Location = new System.Drawing.Point(120, 118);
            this.btnMmodelMinimumSelectionEpochS.Margin = new System.Windows.Forms.Padding(0);
            this.btnMmodelMinimumSelectionEpochS.Name = "btnMmodelMinimumSelectionEpochS";
            this.btnMmodelMinimumSelectionEpochS.Size = new System.Drawing.Size(20, 20);
            this.btnMmodelMinimumSelectionEpochS.TabIndex = 36;
            this.btnMmodelMinimumSelectionEpochS.UseVisualStyleBackColor = true;
            this.btnMmodelMinimumSelectionEpochS.Click += new System.EventHandler(this.BtnMmodelMinimumSelectionEpochSClick);
            // 
            // btnPatienceEpochsS
            // 
            this.btnPatienceEpochsS.BackgroundImage = global::ProjectAI.Properties.Resources.arrowLeft4;
            this.btnPatienceEpochsS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPatienceEpochsS.FlatAppearance.BorderSize = 0;
            this.btnPatienceEpochsS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatienceEpochsS.Location = new System.Drawing.Point(120, 139);
            this.btnPatienceEpochsS.Margin = new System.Windows.Forms.Padding(0);
            this.btnPatienceEpochsS.Name = "btnPatienceEpochsS";
            this.btnPatienceEpochsS.Size = new System.Drawing.Size(20, 20);
            this.btnPatienceEpochsS.TabIndex = 37;
            this.btnPatienceEpochsS.UseVisualStyleBackColor = true;
            this.btnPatienceEpochsS.Click += new System.EventHandler(this.BtnPatienceEpochsSClick);
            // 
            // btnMmodelMinimumSelectionEpochP
            // 
            this.btnMmodelMinimumSelectionEpochP.BackgroundImage = global::ProjectAI.Properties.Resources.arrowRight4;
            this.btnMmodelMinimumSelectionEpochP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMmodelMinimumSelectionEpochP.FlatAppearance.BorderSize = 0;
            this.btnMmodelMinimumSelectionEpochP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMmodelMinimumSelectionEpochP.Location = new System.Drawing.Point(200, 118);
            this.btnMmodelMinimumSelectionEpochP.Margin = new System.Windows.Forms.Padding(0);
            this.btnMmodelMinimumSelectionEpochP.Name = "btnMmodelMinimumSelectionEpochP";
            this.btnMmodelMinimumSelectionEpochP.Size = new System.Drawing.Size(20, 20);
            this.btnMmodelMinimumSelectionEpochP.TabIndex = 38;
            this.btnMmodelMinimumSelectionEpochP.UseVisualStyleBackColor = true;
            this.btnMmodelMinimumSelectionEpochP.Click += new System.EventHandler(this.BtnMmodelMinimumSelectionEpochPClick);
            // 
            // btnPatienceEpochsP
            // 
            this.btnPatienceEpochsP.BackgroundImage = global::ProjectAI.Properties.Resources.arrowRight4;
            this.btnPatienceEpochsP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPatienceEpochsP.FlatAppearance.BorderSize = 0;
            this.btnPatienceEpochsP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatienceEpochsP.Location = new System.Drawing.Point(200, 139);
            this.btnPatienceEpochsP.Margin = new System.Windows.Forms.Padding(0);
            this.btnPatienceEpochsP.Name = "btnPatienceEpochsP";
            this.btnPatienceEpochsP.Size = new System.Drawing.Size(20, 20);
            this.btnPatienceEpochsP.TabIndex = 39;
            this.btnPatienceEpochsP.UseVisualStyleBackColor = true;
            this.btnPatienceEpochsP.Click += new System.EventHandler(this.BtnPatienceEpochsPClick);
            // 
            // btnTrainRepeatP
            // 
            this.btnTrainRepeatP.BackgroundImage = global::ProjectAI.Properties.Resources.arrowRight4;
            this.btnTrainRepeatP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTrainRepeatP.FlatAppearance.BorderSize = 0;
            this.btnTrainRepeatP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrainRepeatP.Location = new System.Drawing.Point(440, 97);
            this.btnTrainRepeatP.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrainRepeatP.Name = "btnTrainRepeatP";
            this.btnTrainRepeatP.Size = new System.Drawing.Size(20, 20);
            this.btnTrainRepeatP.TabIndex = 41;
            this.btnTrainRepeatP.UseVisualStyleBackColor = true;
            this.btnTrainRepeatP.Click += new System.EventHandler(this.BtnTrainRepeatPClick);
            // 
            // btnValidationRatioP
            // 
            this.btnValidationRatioP.BackgroundImage = global::ProjectAI.Properties.Resources.arrowRight4;
            this.btnValidationRatioP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnValidationRatioP.FlatAppearance.BorderSize = 0;
            this.btnValidationRatioP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidationRatioP.Location = new System.Drawing.Point(440, 118);
            this.btnValidationRatioP.Margin = new System.Windows.Forms.Padding(0);
            this.btnValidationRatioP.Name = "btnValidationRatioP";
            this.btnValidationRatioP.Size = new System.Drawing.Size(20, 20);
            this.btnValidationRatioP.TabIndex = 40;
            this.btnValidationRatioP.UseVisualStyleBackColor = true;
            this.btnValidationRatioP.Click += new System.EventHandler(this.BtnValidationRatioPClick);
            // 
            // btnTrainRepeatS
            // 
            this.btnTrainRepeatS.BackgroundImage = global::ProjectAI.Properties.Resources.arrowLeft4;
            this.btnTrainRepeatS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTrainRepeatS.FlatAppearance.BorderSize = 0;
            this.btnTrainRepeatS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrainRepeatS.Location = new System.Drawing.Point(360, 97);
            this.btnTrainRepeatS.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrainRepeatS.Name = "btnTrainRepeatS";
            this.btnTrainRepeatS.Size = new System.Drawing.Size(20, 20);
            this.btnTrainRepeatS.TabIndex = 42;
            this.btnTrainRepeatS.UseVisualStyleBackColor = true;
            this.btnTrainRepeatS.Click += new System.EventHandler(this.BtnTrainRepeatSClick);
            // 
            // btnValidationRatioS
            // 
            this.btnValidationRatioS.BackgroundImage = global::ProjectAI.Properties.Resources.arrowLeft4;
            this.btnValidationRatioS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnValidationRatioS.FlatAppearance.BorderSize = 0;
            this.btnValidationRatioS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidationRatioS.Location = new System.Drawing.Point(360, 118);
            this.btnValidationRatioS.Margin = new System.Windows.Forms.Padding(0);
            this.btnValidationRatioS.Name = "btnValidationRatioS";
            this.btnValidationRatioS.Size = new System.Drawing.Size(20, 20);
            this.btnValidationRatioS.TabIndex = 43;
            this.btnValidationRatioS.UseVisualStyleBackColor = true;
            this.btnValidationRatioS.Click += new System.EventHandler(this.BtnValidationRatioSClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 12;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.Controls.Add(this.panelMZoomToolTip, 7, 13);
            this.tableLayoutPanel1.Controls.Add(this.panelMVerticalFlipToolTip, 7, 11);
            this.tableLayoutPanel1.Controls.Add(this.panelMSharpenToolTip, 7, 9);
            this.tableLayoutPanel1.Controls.Add(this.panelMRotation270ToolTip, 7, 7);
            this.tableLayoutPanel1.Controls.Add(this.panelMRotation180ToolTip, 7, 5);
            this.tableLayoutPanel1.Controls.Add(this.panelMRotation90ToolTip, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.panelMHorizontalFlipToolTip, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelMGradationRGBToolTip, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.panelMGradationToolTip, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.panelMContrastToolTip, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.panelMCenterToolTip, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tilMZoom, 10, 13);
            this.tableLayoutPanel1.Controls.Add(this.txtBlur, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tilMBrightness, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.ckbMHorizontalFlip, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.ckbMBlur, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ckbMContrast, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.ckbBrightness, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ckbMCenter, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ckbMGaussianNoise, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.ckbMGradation, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.ckbGradationRGB, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.ckbMRotation90, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.ckbMRotation180, 6, 5);
            this.tableLayoutPanel1.Controls.Add(this.ckbMRotation270, 6, 7);
            this.tableLayoutPanel1.Controls.Add(this.ckbMSharpen, 6, 9);
            this.tableLayoutPanel1.Controls.Add(this.ckbMVerticalFlip, 6, 11);
            this.tableLayoutPanel1.Controls.Add(this.ckbMZoom, 6, 13);
            this.tableLayoutPanel1.Controls.Add(this.lblMDataAugmentation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.panel11, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.panel13, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel15, 8, 10);
            this.tableLayoutPanel1.Controls.Add(this.panel17, 8, 14);
            this.tableLayoutPanel1.Controls.Add(this.panel18, 9, 14);
            this.tableLayoutPanel1.Controls.Add(this.txtBrightnessMin, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtBrightnessMax, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCenter, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtContrastMin, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtContrastMax, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtGaussianNoise, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtGradation, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.txtSharpen, 8, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtZoomMin, 8, 13);
            this.tableLayoutPanel1.Controls.Add(this.txtZoomMax, 9, 13);
            this.tableLayoutPanel1.Controls.Add(this.panelMBlurToolTip, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tilMBlur, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.tilMSharpen, 10, 9);
            this.tableLayoutPanel1.Controls.Add(this.tilMCenter, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.tilMGaussianNoise, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this.panelMBrightnessToolTip, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panelMGaussianNoiseToolTip, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.tilMContrast, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.tilMGradationRGB, 4, 13);
            this.tableLayoutPanel1.Controls.Add(this.tilMGradation, 4, 11);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 181);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 16;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 186);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panelMZoomToolTip
            // 
            this.panelMZoomToolTip.BackgroundImage = global::ProjectAI.Properties.Resources.question1;
            this.panelMZoomToolTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMZoomToolTip.HorizontalScrollbarBarColor = true;
            this.panelMZoomToolTip.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMZoomToolTip.HorizontalScrollbarSize = 10;
            this.panelMZoomToolTip.Location = new System.Drawing.Point(359, 163);
            this.panelMZoomToolTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelMZoomToolTip.Name = "panelMZoomToolTip";
            this.panelMZoomToolTip.Size = new System.Drawing.Size(16, 16);
            this.panelMZoomToolTip.TabIndex = 75;
            this.panelMZoomToolTip.VerticalScrollbarBarColor = true;
            this.panelMZoomToolTip.VerticalScrollbarHighlightOnWheel = false;
            this.panelMZoomToolTip.VerticalScrollbarSize = 10;
            // 
            // panelMVerticalFlipToolTip
            // 
            this.panelMVerticalFlipToolTip.BackgroundImage = global::ProjectAI.Properties.Resources.question1;
            this.panelMVerticalFlipToolTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMVerticalFlipToolTip.HorizontalScrollbarBarColor = true;
            this.panelMVerticalFlipToolTip.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMVerticalFlipToolTip.HorizontalScrollbarSize = 10;
            this.panelMVerticalFlipToolTip.Location = new System.Drawing.Point(359, 142);
            this.panelMVerticalFlipToolTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelMVerticalFlipToolTip.Name = "panelMVerticalFlipToolTip";
            this.panelMVerticalFlipToolTip.Size = new System.Drawing.Size(16, 16);
            this.panelMVerticalFlipToolTip.TabIndex = 75;
            this.panelMVerticalFlipToolTip.VerticalScrollbarBarColor = true;
            this.panelMVerticalFlipToolTip.VerticalScrollbarHighlightOnWheel = false;
            this.panelMVerticalFlipToolTip.VerticalScrollbarSize = 10;
            // 
            // panelMSharpenToolTip
            // 
            this.panelMSharpenToolTip.BackgroundImage = global::ProjectAI.Properties.Resources.question1;
            this.panelMSharpenToolTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMSharpenToolTip.HorizontalScrollbarBarColor = true;
            this.panelMSharpenToolTip.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMSharpenToolTip.HorizontalScrollbarSize = 10;
            this.panelMSharpenToolTip.Location = new System.Drawing.Point(359, 121);
            this.panelMSharpenToolTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelMSharpenToolTip.Name = "panelMSharpenToolTip";
            this.panelMSharpenToolTip.Size = new System.Drawing.Size(16, 16);
            this.panelMSharpenToolTip.TabIndex = 75;
            this.panelMSharpenToolTip.VerticalScrollbarBarColor = true;
            this.panelMSharpenToolTip.VerticalScrollbarHighlightOnWheel = false;
            this.panelMSharpenToolTip.VerticalScrollbarSize = 10;
            // 
            // panelMRotation270ToolTip
            // 
            this.panelMRotation270ToolTip.BackgroundImage = global::ProjectAI.Properties.Resources.question1;
            this.panelMRotation270ToolTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMRotation270ToolTip.HorizontalScrollbarBarColor = true;
            this.panelMRotation270ToolTip.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMRotation270ToolTip.HorizontalScrollbarSize = 10;
            this.panelMRotation270ToolTip.Location = new System.Drawing.Point(359, 100);
            this.panelMRotation270ToolTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelMRotation270ToolTip.Name = "panelMRotation270ToolTip";
            this.panelMRotation270ToolTip.Size = new System.Drawing.Size(16, 16);
            this.panelMRotation270ToolTip.TabIndex = 75;
            this.panelMRotation270ToolTip.VerticalScrollbarBarColor = true;
            this.panelMRotation270ToolTip.VerticalScrollbarHighlightOnWheel = false;
            this.panelMRotation270ToolTip.VerticalScrollbarSize = 10;
            // 
            // panelMRotation180ToolTip
            // 
            this.panelMRotation180ToolTip.BackgroundImage = global::ProjectAI.Properties.Resources.question1;
            this.panelMRotation180ToolTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMRotation180ToolTip.HorizontalScrollbarBarColor = true;
            this.panelMRotation180ToolTip.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMRotation180ToolTip.HorizontalScrollbarSize = 10;
            this.panelMRotation180ToolTip.Location = new System.Drawing.Point(359, 79);
            this.panelMRotation180ToolTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelMRotation180ToolTip.Name = "panelMRotation180ToolTip";
            this.panelMRotation180ToolTip.Size = new System.Drawing.Size(16, 16);
            this.panelMRotation180ToolTip.TabIndex = 75;
            this.panelMRotation180ToolTip.VerticalScrollbarBarColor = true;
            this.panelMRotation180ToolTip.VerticalScrollbarHighlightOnWheel = false;
            this.panelMRotation180ToolTip.VerticalScrollbarSize = 10;
            // 
            // panelMRotation90ToolTip
            // 
            this.panelMRotation90ToolTip.BackgroundImage = global::ProjectAI.Properties.Resources.question1;
            this.panelMRotation90ToolTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMRotation90ToolTip.HorizontalScrollbarBarColor = true;
            this.panelMRotation90ToolTip.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMRotation90ToolTip.HorizontalScrollbarSize = 10;
            this.panelMRotation90ToolTip.Location = new System.Drawing.Point(359, 58);
            this.panelMRotation90ToolTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelMRotation90ToolTip.Name = "panelMRotation90ToolTip";
            this.panelMRotation90ToolTip.Size = new System.Drawing.Size(16, 16);
            this.panelMRotation90ToolTip.TabIndex = 75;
            this.panelMRotation90ToolTip.VerticalScrollbarBarColor = true;
            this.panelMRotation90ToolTip.VerticalScrollbarHighlightOnWheel = false;
            this.panelMRotation90ToolTip.VerticalScrollbarSize = 10;
            // 
            // panelMHorizontalFlipToolTip
            // 
            this.panelMHorizontalFlipToolTip.BackgroundImage = global::ProjectAI.Properties.Resources.question1;
            this.panelMHorizontalFlipToolTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMHorizontalFlipToolTip.HorizontalScrollbarBarColor = true;
            this.panelMHorizontalFlipToolTip.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMHorizontalFlipToolTip.HorizontalScrollbarSize = 10;
            this.panelMHorizontalFlipToolTip.Location = new System.Drawing.Point(359, 37);
            this.panelMHorizontalFlipToolTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelMHorizontalFlipToolTip.Name = "panelMHorizontalFlipToolTip";
            this.panelMHorizontalFlipToolTip.Size = new System.Drawing.Size(16, 16);
            this.panelMHorizontalFlipToolTip.TabIndex = 75;
            this.panelMHorizontalFlipToolTip.VerticalScrollbarBarColor = true;
            this.panelMHorizontalFlipToolTip.VerticalScrollbarHighlightOnWheel = false;
            this.panelMHorizontalFlipToolTip.VerticalScrollbarSize = 10;
            // 
            // panelMGradationRGBToolTip
            // 
            this.panelMGradationRGBToolTip.BackgroundImage = global::ProjectAI.Properties.Resources.question1;
            this.panelMGradationRGBToolTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMGradationRGBToolTip.HorizontalScrollbarBarColor = true;
            this.panelMGradationRGBToolTip.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMGradationRGBToolTip.HorizontalScrollbarSize = 10;
            this.panelMGradationRGBToolTip.Location = new System.Drawing.Point(122, 163);
            this.panelMGradationRGBToolTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelMGradationRGBToolTip.Name = "panelMGradationRGBToolTip";
            this.panelMGradationRGBToolTip.Size = new System.Drawing.Size(16, 16);
            this.panelMGradationRGBToolTip.TabIndex = 75;
            this.panelMGradationRGBToolTip.VerticalScrollbarBarColor = true;
            this.panelMGradationRGBToolTip.VerticalScrollbarHighlightOnWheel = false;
            this.panelMGradationRGBToolTip.VerticalScrollbarSize = 10;
            // 
            // panelMGradationToolTip
            // 
            this.panelMGradationToolTip.BackgroundImage = global::ProjectAI.Properties.Resources.question1;
            this.panelMGradationToolTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMGradationToolTip.HorizontalScrollbarBarColor = true;
            this.panelMGradationToolTip.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMGradationToolTip.HorizontalScrollbarSize = 10;
            this.panelMGradationToolTip.Location = new System.Drawing.Point(122, 142);
            this.panelMGradationToolTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelMGradationToolTip.Name = "panelMGradationToolTip";
            this.panelMGradationToolTip.Size = new System.Drawing.Size(16, 16);
            this.panelMGradationToolTip.TabIndex = 75;
            this.panelMGradationToolTip.VerticalScrollbarBarColor = true;
            this.panelMGradationToolTip.VerticalScrollbarHighlightOnWheel = false;
            this.panelMGradationToolTip.VerticalScrollbarSize = 10;
            // 
            // panelMContrastToolTip
            // 
            this.panelMContrastToolTip.BackgroundImage = global::ProjectAI.Properties.Resources.question1;
            this.panelMContrastToolTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMContrastToolTip.HorizontalScrollbarBarColor = true;
            this.panelMContrastToolTip.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMContrastToolTip.HorizontalScrollbarSize = 10;
            this.panelMContrastToolTip.Location = new System.Drawing.Point(122, 100);
            this.panelMContrastToolTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelMContrastToolTip.Name = "panelMContrastToolTip";
            this.panelMContrastToolTip.Size = new System.Drawing.Size(16, 16);
            this.panelMContrastToolTip.TabIndex = 75;
            this.panelMContrastToolTip.VerticalScrollbarBarColor = true;
            this.panelMContrastToolTip.VerticalScrollbarHighlightOnWheel = false;
            this.panelMContrastToolTip.VerticalScrollbarSize = 10;
            // 
            // panelMCenterToolTip
            // 
            this.panelMCenterToolTip.BackgroundImage = global::ProjectAI.Properties.Resources.question1;
            this.panelMCenterToolTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMCenterToolTip.HorizontalScrollbarBarColor = true;
            this.panelMCenterToolTip.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMCenterToolTip.HorizontalScrollbarSize = 10;
            this.panelMCenterToolTip.Location = new System.Drawing.Point(122, 79);
            this.panelMCenterToolTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelMCenterToolTip.Name = "panelMCenterToolTip";
            this.panelMCenterToolTip.Size = new System.Drawing.Size(16, 16);
            this.panelMCenterToolTip.TabIndex = 75;
            this.panelMCenterToolTip.VerticalScrollbarBarColor = true;
            this.panelMCenterToolTip.VerticalScrollbarHighlightOnWheel = false;
            this.panelMCenterToolTip.VerticalScrollbarSize = 10;
            // 
            // tilMZoom
            // 
            this.tilMZoom.ActiveControl = null;
            this.tilMZoom.Enabled = false;
            this.tilMZoom.Location = new System.Drawing.Point(438, 162);
            this.tilMZoom.Margin = new System.Windows.Forms.Padding(1);
            this.tilMZoom.Name = "tilMZoom";
            this.tilMZoom.Size = new System.Drawing.Size(18, 18);
            this.tilMZoom.TabIndex = 8;
            this.tilMZoom.UseSelectable = true;
            this.tilMZoom.Click += new System.EventHandler(this.TilMZoomClick);
            // 
            // txtBlur
            // 
            this.txtBlur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtBlur, true);
            this.txtBlur.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.txtBlur, 2);
            this.txtBlur.Enabled = false;
            this.txtBlur.Location = new System.Drawing.Point(143, 41);
            this.txtBlur.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtBlur.Name = "txtBlur";
            this.txtBlur.Size = new System.Drawing.Size(54, 14);
            this.txtBlur.TabIndex = 35;
            this.txtBlur.Text = "0";
            this.txtBlur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBlur.TextChanged += new System.EventHandler(this.TxtBlurTextChanged);
            // 
            // tilMBrightness
            // 
            this.tilMBrightness.ActiveControl = null;
            this.tilMBrightness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilMBrightness.Enabled = false;
            this.tilMBrightness.Location = new System.Drawing.Point(201, 57);
            this.tilMBrightness.Margin = new System.Windows.Forms.Padding(1);
            this.tilMBrightness.Name = "tilMBrightness";
            this.tilMBrightness.Size = new System.Drawing.Size(18, 18);
            this.tilMBrightness.TabIndex = 5;
            this.tilMBrightness.UseSelectable = true;
            this.tilMBrightness.Click += new System.EventHandler(this.TilMBrightnessClick);
            // 
            // ckbMHorizontalFlip
            // 
            this.ckbMHorizontalFlip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbMHorizontalFlip.AutoSize = true;
            this.ckbMHorizontalFlip.Location = new System.Drawing.Point(238, 36);
            this.ckbMHorizontalFlip.Margin = new System.Windows.Forms.Padding(1);
            this.ckbMHorizontalFlip.Name = "ckbMHorizontalFlip";
            this.ckbMHorizontalFlip.Size = new System.Drawing.Size(100, 18);
            this.ckbMHorizontalFlip.TabIndex = 3;
            this.ckbMHorizontalFlip.Text = "Horizontal Flip";
            this.ckbMHorizontalFlip.UseSelectable = true;
            // 
            // ckbMBlur
            // 
            this.ckbMBlur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbMBlur.AutoSize = true;
            this.ckbMBlur.Location = new System.Drawing.Point(3, 36);
            this.ckbMBlur.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.ckbMBlur.Name = "ckbMBlur";
            this.ckbMBlur.Size = new System.Drawing.Size(44, 18);
            this.ckbMBlur.TabIndex = 4;
            this.ckbMBlur.Text = "Blur";
            this.ckbMBlur.UseSelectable = true;
            this.ckbMBlur.CheckedChanged += new System.EventHandler(this.CkbMBlurCheckedChanged);
            // 
            // ckbMContrast
            // 
            this.ckbMContrast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbMContrast.AutoSize = true;
            this.ckbMContrast.Location = new System.Drawing.Point(3, 99);
            this.ckbMContrast.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.ckbMContrast.Name = "ckbMContrast";
            this.ckbMContrast.Size = new System.Drawing.Size(68, 18);
            this.ckbMContrast.TabIndex = 6;
            this.ckbMContrast.Text = "Contrast";
            this.ckbMContrast.UseSelectable = true;
            this.ckbMContrast.CheckedChanged += new System.EventHandler(this.CkbMContrastCheckedChanged);
            // 
            // ckbBrightness
            // 
            this.ckbBrightness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbBrightness.AutoSize = true;
            this.ckbBrightness.Location = new System.Drawing.Point(3, 57);
            this.ckbBrightness.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.ckbBrightness.Name = "ckbBrightness";
            this.ckbBrightness.Size = new System.Drawing.Size(78, 18);
            this.ckbBrightness.TabIndex = 6;
            this.ckbBrightness.Text = "Brightness";
            this.ckbBrightness.UseSelectable = true;
            this.ckbBrightness.CheckedChanged += new System.EventHandler(this.CkbBrightnessCheckedChanged);
            // 
            // ckbMCenter
            // 
            this.ckbMCenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbMCenter.AutoSize = true;
            this.ckbMCenter.Location = new System.Drawing.Point(3, 78);
            this.ckbMCenter.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.ckbMCenter.Name = "ckbMCenter";
            this.ckbMCenter.Size = new System.Drawing.Size(58, 18);
            this.ckbMCenter.TabIndex = 6;
            this.ckbMCenter.Text = "Center";
            this.ckbMCenter.UseSelectable = true;
            this.ckbMCenter.CheckedChanged += new System.EventHandler(this.CkbMCenterCheckedChanged);
            // 
            // ckbMGaussianNoise
            // 
            this.ckbMGaussianNoise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbMGaussianNoise.AutoSize = true;
            this.ckbMGaussianNoise.Location = new System.Drawing.Point(3, 120);
            this.ckbMGaussianNoise.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.ckbMGaussianNoise.Name = "ckbMGaussianNoise";
            this.ckbMGaussianNoise.Size = new System.Drawing.Size(103, 18);
            this.ckbMGaussianNoise.TabIndex = 5;
            this.ckbMGaussianNoise.Text = "Gaussian Noise";
            this.ckbMGaussianNoise.UseSelectable = true;
            this.ckbMGaussianNoise.CheckedChanged += new System.EventHandler(this.CkbMGaussianNoiseCheckedChanged);
            // 
            // ckbMGradation
            // 
            this.ckbMGradation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbMGradation.AutoSize = true;
            this.ckbMGradation.Location = new System.Drawing.Point(3, 141);
            this.ckbMGradation.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.ckbMGradation.Name = "ckbMGradation";
            this.ckbMGradation.Size = new System.Drawing.Size(75, 18);
            this.ckbMGradation.TabIndex = 6;
            this.ckbMGradation.Text = "Gradation";
            this.ckbMGradation.UseSelectable = true;
            this.ckbMGradation.CheckedChanged += new System.EventHandler(this.CkbMGradationCheckedChanged);
            // 
            // ckbGradationRGB
            // 
            this.ckbGradationRGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbGradationRGB.AutoSize = true;
            this.ckbGradationRGB.Location = new System.Drawing.Point(3, 162);
            this.ckbGradationRGB.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.ckbGradationRGB.Name = "ckbGradationRGB";
            this.ckbGradationRGB.Size = new System.Drawing.Size(100, 18);
            this.ckbGradationRGB.TabIndex = 6;
            this.ckbGradationRGB.Text = "Gradation RGB";
            this.ckbGradationRGB.UseSelectable = true;
            this.ckbGradationRGB.CheckedChanged += new System.EventHandler(this.CkbGradationRGBCheckedChanged);
            // 
            // ckbMRotation90
            // 
            this.ckbMRotation90.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbMRotation90.AutoSize = true;
            this.ckbMRotation90.Location = new System.Drawing.Point(238, 57);
            this.ckbMRotation90.Margin = new System.Windows.Forms.Padding(1);
            this.ckbMRotation90.Name = "ckbMRotation90";
            this.ckbMRotation90.Size = new System.Drawing.Size(88, 18);
            this.ckbMRotation90.TabIndex = 5;
            this.ckbMRotation90.Text = "Rotation 90°";
            this.ckbMRotation90.UseSelectable = true;
            // 
            // ckbMRotation180
            // 
            this.ckbMRotation180.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbMRotation180.AutoSize = true;
            this.ckbMRotation180.Location = new System.Drawing.Point(238, 78);
            this.ckbMRotation180.Margin = new System.Windows.Forms.Padding(1);
            this.ckbMRotation180.Name = "ckbMRotation180";
            this.ckbMRotation180.Size = new System.Drawing.Size(94, 18);
            this.ckbMRotation180.TabIndex = 6;
            this.ckbMRotation180.Text = "Rotation 180°";
            this.ckbMRotation180.UseSelectable = true;
            // 
            // ckbMRotation270
            // 
            this.ckbMRotation270.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbMRotation270.AutoSize = true;
            this.ckbMRotation270.Location = new System.Drawing.Point(238, 99);
            this.ckbMRotation270.Margin = new System.Windows.Forms.Padding(1);
            this.ckbMRotation270.Name = "ckbMRotation270";
            this.ckbMRotation270.Size = new System.Drawing.Size(94, 18);
            this.ckbMRotation270.TabIndex = 6;
            this.ckbMRotation270.Text = "Rotation 270°";
            this.ckbMRotation270.UseSelectable = true;
            // 
            // ckbMSharpen
            // 
            this.ckbMSharpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbMSharpen.AutoSize = true;
            this.ckbMSharpen.Location = new System.Drawing.Point(238, 120);
            this.ckbMSharpen.Margin = new System.Windows.Forms.Padding(1);
            this.ckbMSharpen.Name = "ckbMSharpen";
            this.ckbMSharpen.Size = new System.Drawing.Size(66, 18);
            this.ckbMSharpen.TabIndex = 6;
            this.ckbMSharpen.Text = "Sharpen";
            this.ckbMSharpen.UseSelectable = true;
            this.ckbMSharpen.CheckedChanged += new System.EventHandler(this.CkbMSharpenCheckedChanged);
            // 
            // ckbMVerticalFlip
            // 
            this.ckbMVerticalFlip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbMVerticalFlip.AutoSize = true;
            this.ckbMVerticalFlip.Location = new System.Drawing.Point(238, 141);
            this.ckbMVerticalFlip.Margin = new System.Windows.Forms.Padding(1);
            this.ckbMVerticalFlip.Name = "ckbMVerticalFlip";
            this.ckbMVerticalFlip.Size = new System.Drawing.Size(83, 18);
            this.ckbMVerticalFlip.TabIndex = 4;
            this.ckbMVerticalFlip.Text = "Vertical Flip";
            this.ckbMVerticalFlip.UseSelectable = true;
            // 
            // ckbMZoom
            // 
            this.ckbMZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbMZoom.AutoSize = true;
            this.ckbMZoom.Location = new System.Drawing.Point(238, 162);
            this.ckbMZoom.Margin = new System.Windows.Forms.Padding(1);
            this.ckbMZoom.Name = "ckbMZoom";
            this.ckbMZoom.Size = new System.Drawing.Size(55, 18);
            this.ckbMZoom.TabIndex = 6;
            this.ckbMZoom.Text = "Zoom";
            this.ckbMZoom.UseSelectable = true;
            this.ckbMZoom.CheckedChanged += new System.EventHandler(this.CkbMZoomCheckedChanged);
            // 
            // lblMDataAugmentation
            // 
            this.lblMDataAugmentation.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblMDataAugmentation, 12);
            this.lblMDataAugmentation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMDataAugmentation.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblMDataAugmentation.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMDataAugmentation.Location = new System.Drawing.Point(3, 0);
            this.lblMDataAugmentation.Name = "lblMDataAugmentation";
            this.lblMDataAugmentation.Size = new System.Drawing.Size(454, 35);
            this.lblMDataAugmentation.TabIndex = 22;
            this.lblMDataAugmentation.Text = "Data Augmentation";
            this.lblMDataAugmentation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(143, 55);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(54, 1);
            this.panel3.TabIndex = 37;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel4.Location = new System.Drawing.Point(143, 76);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(24, 1);
            this.panel4.TabIndex = 44;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel5.Location = new System.Drawing.Point(173, 76);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(24, 1);
            this.panel5.TabIndex = 45;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel1.SetColumnSpan(this.panel6, 2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(143, 97);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(54, 1);
            this.panel6.TabIndex = 46;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel8.Location = new System.Drawing.Point(143, 118);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(24, 1);
            this.panel8.TabIndex = 48;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel10.Location = new System.Drawing.Point(173, 118);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(24, 1);
            this.panel10.TabIndex = 49;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel1.SetColumnSpan(this.panel11, 2);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(143, 139);
            this.panel11.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(54, 1);
            this.panel11.TabIndex = 50;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel1.SetColumnSpan(this.panel13, 2);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(143, 160);
            this.panel13.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(54, 1);
            this.panel13.TabIndex = 52;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel1.SetColumnSpan(this.panel15, 2);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(380, 139);
            this.panel15.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(54, 1);
            this.panel15.TabIndex = 54;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(380, 181);
            this.panel17.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(24, 1);
            this.panel17.TabIndex = 56;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel18.Location = new System.Drawing.Point(410, 181);
            this.panel18.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(24, 1);
            this.panel18.TabIndex = 57;
            // 
            // txtBrightnessMin
            // 
            this.txtBrightnessMin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtBrightnessMin, true);
            this.txtBrightnessMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBrightnessMin.Enabled = false;
            this.txtBrightnessMin.Location = new System.Drawing.Point(143, 62);
            this.txtBrightnessMin.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtBrightnessMin.Name = "txtBrightnessMin";
            this.txtBrightnessMin.Size = new System.Drawing.Size(24, 14);
            this.txtBrightnessMin.TabIndex = 58;
            this.txtBrightnessMin.Text = "0";
            this.txtBrightnessMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBrightnessMin.TextChanged += new System.EventHandler(this.TxtBrightnessMinTextChanged);
            // 
            // txtBrightnessMax
            // 
            this.txtBrightnessMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtBrightnessMax, true);
            this.txtBrightnessMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBrightnessMax.Enabled = false;
            this.txtBrightnessMax.Location = new System.Drawing.Point(173, 62);
            this.txtBrightnessMax.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtBrightnessMax.Name = "txtBrightnessMax";
            this.txtBrightnessMax.Size = new System.Drawing.Size(24, 14);
            this.txtBrightnessMax.TabIndex = 59;
            this.txtBrightnessMax.Text = "0";
            this.txtBrightnessMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBrightnessMax.TextChanged += new System.EventHandler(this.TxtBrightnessMaxTextChanged);
            // 
            // txtCenter
            // 
            this.txtCenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtCenter, true);
            this.txtCenter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.txtCenter, 2);
            this.txtCenter.Enabled = false;
            this.txtCenter.Location = new System.Drawing.Point(143, 83);
            this.txtCenter.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtCenter.Name = "txtCenter";
            this.txtCenter.Size = new System.Drawing.Size(54, 14);
            this.txtCenter.TabIndex = 60;
            this.txtCenter.Text = "1";
            this.txtCenter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtContrastMin
            // 
            this.txtContrastMin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtContrastMin, true);
            this.txtContrastMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContrastMin.Enabled = false;
            this.txtContrastMin.Location = new System.Drawing.Point(143, 104);
            this.txtContrastMin.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtContrastMin.Name = "txtContrastMin";
            this.txtContrastMin.Size = new System.Drawing.Size(24, 14);
            this.txtContrastMin.TabIndex = 62;
            this.txtContrastMin.Text = "1";
            this.txtContrastMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtContrastMax
            // 
            this.txtContrastMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtContrastMax, true);
            this.txtContrastMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContrastMax.Enabled = false;
            this.txtContrastMax.Location = new System.Drawing.Point(173, 104);
            this.txtContrastMax.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtContrastMax.Name = "txtContrastMax";
            this.txtContrastMax.Size = new System.Drawing.Size(24, 14);
            this.txtContrastMax.TabIndex = 63;
            this.txtContrastMax.Text = "1";
            this.txtContrastMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGaussianNoise
            // 
            this.txtGaussianNoise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtGaussianNoise, true);
            this.txtGaussianNoise.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.txtGaussianNoise, 2);
            this.txtGaussianNoise.Enabled = false;
            this.txtGaussianNoise.Location = new System.Drawing.Point(143, 125);
            this.txtGaussianNoise.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtGaussianNoise.Name = "txtGaussianNoise";
            this.txtGaussianNoise.Size = new System.Drawing.Size(54, 14);
            this.txtGaussianNoise.TabIndex = 64;
            this.txtGaussianNoise.Text = "0";
            this.txtGaussianNoise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGradation
            // 
            this.txtGradation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtGradation, true);
            this.txtGradation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.txtGradation, 2);
            this.txtGradation.Enabled = false;
            this.txtGradation.Location = new System.Drawing.Point(143, 146);
            this.txtGradation.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtGradation.Name = "txtGradation";
            this.txtGradation.Size = new System.Drawing.Size(54, 14);
            this.txtGradation.TabIndex = 66;
            this.txtGradation.Text = "0";
            this.txtGradation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSharpen
            // 
            this.txtSharpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtSharpen, true);
            this.txtSharpen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.txtSharpen, 2);
            this.txtSharpen.Enabled = false;
            this.txtSharpen.Location = new System.Drawing.Point(380, 125);
            this.txtSharpen.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtSharpen.Name = "txtSharpen";
            this.txtSharpen.Size = new System.Drawing.Size(54, 14);
            this.txtSharpen.TabIndex = 70;
            this.txtSharpen.Text = "0";
            this.txtSharpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtZoomMin
            // 
            this.txtZoomMin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtZoomMin, true);
            this.txtZoomMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtZoomMin.Enabled = false;
            this.txtZoomMin.Location = new System.Drawing.Point(380, 167);
            this.txtZoomMin.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtZoomMin.Name = "txtZoomMin";
            this.txtZoomMin.Size = new System.Drawing.Size(24, 14);
            this.txtZoomMin.TabIndex = 72;
            this.txtZoomMin.Text = "1";
            this.txtZoomMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtZoomMax
            // 
            this.txtZoomMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtZoomMax, true);
            this.txtZoomMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtZoomMax.Enabled = false;
            this.txtZoomMax.Location = new System.Drawing.Point(410, 167);
            this.txtZoomMax.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtZoomMax.Name = "txtZoomMax";
            this.txtZoomMax.Size = new System.Drawing.Size(24, 14);
            this.txtZoomMax.TabIndex = 73;
            this.txtZoomMax.Text = "1";
            this.txtZoomMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelMBlurToolTip
            // 
            this.panelMBlurToolTip.BackgroundImage = global::ProjectAI.Properties.Resources.question1;
            this.panelMBlurToolTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMBlurToolTip.HorizontalScrollbarBarColor = true;
            this.panelMBlurToolTip.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMBlurToolTip.HorizontalScrollbarSize = 10;
            this.panelMBlurToolTip.Location = new System.Drawing.Point(122, 37);
            this.panelMBlurToolTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelMBlurToolTip.Name = "panelMBlurToolTip";
            this.panelMBlurToolTip.Size = new System.Drawing.Size(16, 16);
            this.panelMBlurToolTip.TabIndex = 74;
            this.panelMBlurToolTip.VerticalScrollbarBarColor = true;
            this.panelMBlurToolTip.VerticalScrollbarHighlightOnWheel = false;
            this.panelMBlurToolTip.VerticalScrollbarSize = 10;
            // 
            // tilMBlur
            // 
            this.tilMBlur.ActiveControl = null;
            this.tilMBlur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilMBlur.Enabled = false;
            this.tilMBlur.Location = new System.Drawing.Point(201, 36);
            this.tilMBlur.Margin = new System.Windows.Forms.Padding(1);
            this.tilMBlur.Name = "tilMBlur";
            this.tilMBlur.Size = new System.Drawing.Size(18, 18);
            this.tilMBlur.TabIndex = 4;
            this.tilMBlur.UseSelectable = true;
            this.tilMBlur.Click += new System.EventHandler(this.TilMBlurClick);
            // 
            // tilMSharpen
            // 
            this.tilMSharpen.ActiveControl = null;
            this.tilMSharpen.Enabled = false;
            this.tilMSharpen.Location = new System.Drawing.Point(438, 120);
            this.tilMSharpen.Margin = new System.Windows.Forms.Padding(1);
            this.tilMSharpen.Name = "tilMSharpen";
            this.tilMSharpen.Size = new System.Drawing.Size(18, 18);
            this.tilMSharpen.TabIndex = 10;
            this.tilMSharpen.UseSelectable = true;
            this.tilMSharpen.Click += new System.EventHandler(this.TilMSharpenClick);
            // 
            // tilMCenter
            // 
            this.tilMCenter.ActiveControl = null;
            this.tilMCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilMCenter.Enabled = false;
            this.tilMCenter.Location = new System.Drawing.Point(201, 78);
            this.tilMCenter.Margin = new System.Windows.Forms.Padding(1);
            this.tilMCenter.Name = "tilMCenter";
            this.tilMCenter.Size = new System.Drawing.Size(18, 18);
            this.tilMCenter.TabIndex = 8;
            this.tilMCenter.UseSelectable = true;
            this.tilMCenter.Click += new System.EventHandler(this.TilMCenterClick);
            // 
            // tilMGaussianNoise
            // 
            this.tilMGaussianNoise.ActiveControl = null;
            this.tilMGaussianNoise.Enabled = false;
            this.tilMGaussianNoise.Location = new System.Drawing.Point(201, 120);
            this.tilMGaussianNoise.Margin = new System.Windows.Forms.Padding(1);
            this.tilMGaussianNoise.Name = "tilMGaussianNoise";
            this.tilMGaussianNoise.Size = new System.Drawing.Size(18, 18);
            this.tilMGaussianNoise.TabIndex = 6;
            this.tilMGaussianNoise.UseSelectable = true;
            this.tilMGaussianNoise.Click += new System.EventHandler(this.TilMGaussianNoiseClick);
            // 
            // panelMBrightnessToolTip
            // 
            this.panelMBrightnessToolTip.BackgroundImage = global::ProjectAI.Properties.Resources.question1;
            this.panelMBrightnessToolTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMBrightnessToolTip.HorizontalScrollbarBarColor = true;
            this.panelMBrightnessToolTip.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMBrightnessToolTip.HorizontalScrollbarSize = 10;
            this.panelMBrightnessToolTip.Location = new System.Drawing.Point(122, 58);
            this.panelMBrightnessToolTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelMBrightnessToolTip.Name = "panelMBrightnessToolTip";
            this.panelMBrightnessToolTip.Size = new System.Drawing.Size(16, 16);
            this.panelMBrightnessToolTip.TabIndex = 75;
            this.panelMBrightnessToolTip.VerticalScrollbarBarColor = true;
            this.panelMBrightnessToolTip.VerticalScrollbarHighlightOnWheel = false;
            this.panelMBrightnessToolTip.VerticalScrollbarSize = 10;
            // 
            // panelMGaussianNoiseToolTip
            // 
            this.panelMGaussianNoiseToolTip.BackgroundImage = global::ProjectAI.Properties.Resources.question1;
            this.panelMGaussianNoiseToolTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMGaussianNoiseToolTip.HorizontalScrollbarBarColor = true;
            this.panelMGaussianNoiseToolTip.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMGaussianNoiseToolTip.HorizontalScrollbarSize = 10;
            this.panelMGaussianNoiseToolTip.Location = new System.Drawing.Point(122, 121);
            this.panelMGaussianNoiseToolTip.Margin = new System.Windows.Forms.Padding(2);
            this.panelMGaussianNoiseToolTip.Name = "panelMGaussianNoiseToolTip";
            this.panelMGaussianNoiseToolTip.Size = new System.Drawing.Size(16, 16);
            this.panelMGaussianNoiseToolTip.TabIndex = 76;
            this.panelMGaussianNoiseToolTip.VerticalScrollbarBarColor = true;
            this.panelMGaussianNoiseToolTip.VerticalScrollbarHighlightOnWheel = false;
            this.panelMGaussianNoiseToolTip.VerticalScrollbarSize = 10;
            // 
            // tilMContrast
            // 
            this.tilMContrast.ActiveControl = null;
            this.tilMContrast.Enabled = false;
            this.tilMContrast.Location = new System.Drawing.Point(201, 99);
            this.tilMContrast.Margin = new System.Windows.Forms.Padding(1);
            this.tilMContrast.Name = "tilMContrast";
            this.tilMContrast.Size = new System.Drawing.Size(18, 18);
            this.tilMContrast.TabIndex = 7;
            this.tilMContrast.UseSelectable = true;
            this.tilMContrast.Click += new System.EventHandler(this.TilMContrastClick);
            // 
            // tilMGradationRGB
            // 
            this.tilMGradationRGB.ActiveControl = null;
            this.tilMGradationRGB.Enabled = false;
            this.tilMGradationRGB.Location = new System.Drawing.Point(201, 162);
            this.tilMGradationRGB.Margin = new System.Windows.Forms.Padding(1);
            this.tilMGradationRGB.Name = "tilMGradationRGB";
            this.tilMGradationRGB.Size = new System.Drawing.Size(18, 18);
            this.tilMGradationRGB.TabIndex = 10;
            this.tilMGradationRGB.UseSelectable = true;
            this.tilMGradationRGB.Click += new System.EventHandler(this.TilMGradationRGBClick);
            // 
            // tilMGradation
            // 
            this.tilMGradation.ActiveControl = null;
            this.tilMGradation.Enabled = false;
            this.tilMGradation.Location = new System.Drawing.Point(201, 141);
            this.tilMGradation.Margin = new System.Windows.Forms.Padding(1);
            this.tilMGradation.Name = "tilMGradation";
            this.tilMGradation.Size = new System.Drawing.Size(18, 18);
            this.tilMGradation.TabIndex = 11;
            this.tilMGradation.UseSelectable = true;
            this.tilMGradation.Click += new System.EventHandler(this.TilMGradationClick);
            // 
            // tlpContinualLearning
            // 
            this.tlpContinualLearning.ColumnCount = 1;
            this.tlpContinualLearning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContinualLearning.Controls.Add(this.lblMContinualLearning, 0, 0);
            this.tlpContinualLearning.Controls.Add(this.togMContinualLearning, 0, 1);
            this.tlpContinualLearning.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpContinualLearning.Location = new System.Drawing.Point(0, 377);
            this.tlpContinualLearning.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tlpContinualLearning.Name = "tlpContinualLearning";
            this.tlpContinualLearning.RowCount = 2;
            this.tlpContinualLearning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpContinualLearning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContinualLearning.Size = new System.Drawing.Size(460, 55);
            this.tlpContinualLearning.TabIndex = 8;
            // 
            // lblMContinualLearning
            // 
            this.lblMContinualLearning.AutoSize = true;
            this.lblMContinualLearning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMContinualLearning.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblMContinualLearning.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMContinualLearning.Location = new System.Drawing.Point(3, 0);
            this.lblMContinualLearning.Name = "lblMContinualLearning";
            this.lblMContinualLearning.Size = new System.Drawing.Size(454, 35);
            this.lblMContinualLearning.TabIndex = 23;
            this.lblMContinualLearning.Text = "Continual Learning";
            this.lblMContinualLearning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // togMContinualLearning
            // 
            this.togMContinualLearning.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.togMContinualLearning.AutoSize = true;
            this.togMContinualLearning.Location = new System.Drawing.Point(3, 38);
            this.togMContinualLearning.Name = "togMContinualLearning";
            this.togMContinualLearning.Size = new System.Drawing.Size(80, 14);
            this.togMContinualLearning.TabIndex = 0;
            this.togMContinualLearning.Text = "Off";
            this.togMContinualLearning.UseSelectable = true;
            this.togMContinualLearning.CheckedChanged += new System.EventHandler(this.TogMContinualLearningCheckedChanged);
            // 
            // panelContinualLearning
            // 
            this.panelContinualLearning.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2;
            this.panelContinualLearning.Controls.Add(this.dgvMContinualLearning);
            this.panelContinualLearning.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContinualLearning.Location = new System.Drawing.Point(0, 432);
            this.panelContinualLearning.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panelContinualLearning.Name = "panelContinualLearning";
            this.panelContinualLearning.Size = new System.Drawing.Size(460, 104);
            this.panelContinualLearning.TabIndex = 9;
            this.panelContinualLearning.Visible = false;
            // 
            // dgvMContinualLearning
            // 
            this.dgvMContinualLearning.AllowUserToAddRows = false;
            this.dgvMContinualLearning.AllowUserToDeleteRows = false;
            this.dgvMContinualLearning.AllowUserToResizeRows = false;
            this.dgvMContinualLearning.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMContinualLearning.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvMContinualLearning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMContinualLearning.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMContinualLearning.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMContinualLearning.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMContinualLearning.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMContinualLearning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMContinualLearning.EnableHeadersVisualStyles = false;
            this.dgvMContinualLearning.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvMContinualLearning.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvMContinualLearning.Location = new System.Drawing.Point(0, 0);
            this.dgvMContinualLearning.Margin = new System.Windows.Forms.Padding(0);
            this.dgvMContinualLearning.Name = "dgvMContinualLearning";
            this.dgvMContinualLearning.ReadOnly = true;
            this.dgvMContinualLearning.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMContinualLearning.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMContinualLearning.RowHeadersVisible = false;
            this.dgvMContinualLearning.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMContinualLearning.RowTemplate.Height = 23;
            this.dgvMContinualLearning.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMContinualLearning.Size = new System.Drawing.Size(460, 104);
            this.dgvMContinualLearning.Style = MetroFramework.MetroColorStyle.Silver;
            this.dgvMContinualLearning.TabIndex = 2;
            this.dgvMContinualLearning.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dgvMContinualLearning.UseStyleColors = true;
            this.dgvMContinualLearning.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMContinualLearningCellMouseDoubleClick);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.panelMClassWeight, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblMClassWeight, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 546);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(460, 155);
            this.tableLayoutPanel5.TabIndex = 13;
            // 
            // panelMClassWeight
            // 
            this.panelMClassWeight.AutoScroll = true;
            this.panelMClassWeight.Controls.Add(this.classWeightControl1);
            this.panelMClassWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMClassWeight.HorizontalScrollbar = true;
            this.panelMClassWeight.HorizontalScrollbarBarColor = true;
            this.panelMClassWeight.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMClassWeight.HorizontalScrollbarSize = 10;
            this.panelMClassWeight.Location = new System.Drawing.Point(0, 35);
            this.panelMClassWeight.Margin = new System.Windows.Forms.Padding(0);
            this.panelMClassWeight.MinimumSize = new System.Drawing.Size(450, 120);
            this.panelMClassWeight.Name = "panelMClassWeight";
            this.panelMClassWeight.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.panelMClassWeight.Size = new System.Drawing.Size(460, 120);
            this.panelMClassWeight.TabIndex = 26;
            this.panelMClassWeight.VerticalScrollbar = true;
            this.panelMClassWeight.VerticalScrollbarBarColor = true;
            this.panelMClassWeight.VerticalScrollbarHighlightOnWheel = false;
            this.panelMClassWeight.VerticalScrollbarSize = 10;
            // 
            // classWeightControl1
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.classWeightControl1, true);
            this.classWeightControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.classWeightControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("classWeightControl1.BackgroundImage")));
            this.classWeightControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.classWeightControl1.ClassName = "metroLabel2";
            this.classWeightControl1.ClassNameColor = System.Drawing.SystemColors.ControlText;
            this.classWeightControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.classWeightControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.classWeightControl1.Location = new System.Drawing.Point(5, 0);
            this.classWeightControl1.Margin = new System.Windows.Forms.Padding(0);
            this.classWeightControl1.Name = "classWeightControl1";
            this.classWeightControl1.Number = 1;
            this.classWeightControl1.Padding = new System.Windows.Forms.Padding(6);
            this.classWeightControl1.Size = new System.Drawing.Size(445, 36);
            this.classWeightControl1.TabIndex = 2;
            this.classWeightControl1.Weight = 100;
            // 
            // lblMClassWeight
            // 
            this.lblMClassWeight.AutoSize = true;
            this.lblMClassWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMClassWeight.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblMClassWeight.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMClassWeight.Location = new System.Drawing.Point(3, 0);
            this.lblMClassWeight.Name = "lblMClassWeight";
            this.lblMClassWeight.Size = new System.Drawing.Size(454, 35);
            this.lblMClassWeight.TabIndex = 23;
            this.lblMClassWeight.Text = "Class Weight";
            this.lblMClassWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.lblMInstantEvaluate, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.togMInstantEvaluate, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 711);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(460, 55);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // lblMInstantEvaluate
            // 
            this.lblMInstantEvaluate.AutoSize = true;
            this.lblMInstantEvaluate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMInstantEvaluate.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblMInstantEvaluate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMInstantEvaluate.Location = new System.Drawing.Point(3, 0);
            this.lblMInstantEvaluate.Name = "lblMInstantEvaluate";
            this.lblMInstantEvaluate.Size = new System.Drawing.Size(454, 35);
            this.lblMInstantEvaluate.TabIndex = 23;
            this.lblMInstantEvaluate.Text = "Instant Evaluate";
            this.lblMInstantEvaluate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // togMInstantEvaluate
            // 
            this.togMInstantEvaluate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.togMInstantEvaluate.AutoSize = true;
            this.togMInstantEvaluate.Location = new System.Drawing.Point(3, 38);
            this.togMInstantEvaluate.Name = "togMInstantEvaluate";
            this.togMInstantEvaluate.Size = new System.Drawing.Size(80, 14);
            this.togMInstantEvaluate.TabIndex = 0;
            this.togMInstantEvaluate.Text = "Off";
            this.togMInstantEvaluate.UseSelectable = true;
            this.togMInstantEvaluate.CheckedChanged += new System.EventHandler(this.TogMInstantEvaluateCheckedChanged);
            // 
            // panelInstantEvaluate
            // 
            this.panelInstantEvaluate.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2;
            this.panelInstantEvaluate.Controls.Add(this.tlpInstantEvaluate);
            this.panelInstantEvaluate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInstantEvaluate.Location = new System.Drawing.Point(0, 766);
            this.panelInstantEvaluate.Margin = new System.Windows.Forms.Padding(0);
            this.panelInstantEvaluate.Name = "panelInstantEvaluate";
            this.panelInstantEvaluate.Size = new System.Drawing.Size(460, 50);
            this.panelInstantEvaluate.TabIndex = 14;
            this.panelInstantEvaluate.Visible = false;
            // 
            // tlpInstantEvaluate
            // 
            this.tlpInstantEvaluate.ColumnCount = 3;
            this.tlpInstantEvaluate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpInstantEvaluate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpInstantEvaluate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpInstantEvaluate.Controls.Add(this.tilMInstantEvaluateTest, 2, 0);
            this.tlpInstantEvaluate.Controls.Add(this.tilMInstantEvaluateTrain, 1, 0);
            this.tlpInstantEvaluate.Controls.Add(this.tilMInstantEvaluateAll, 0, 0);
            this.tlpInstantEvaluate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInstantEvaluate.Location = new System.Drawing.Point(0, 0);
            this.tlpInstantEvaluate.Margin = new System.Windows.Forms.Padding(0);
            this.tlpInstantEvaluate.Name = "tlpInstantEvaluate";
            this.tlpInstantEvaluate.RowCount = 1;
            this.tlpInstantEvaluate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInstantEvaluate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpInstantEvaluate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpInstantEvaluate.Size = new System.Drawing.Size(460, 50);
            this.tlpInstantEvaluate.TabIndex = 0;
            // 
            // tilMInstantEvaluateTest
            // 
            this.tilMInstantEvaluateTest.ActiveControl = null;
            this.tilMInstantEvaluateTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilMInstantEvaluateTest.Location = new System.Drawing.Point(311, 5);
            this.tilMInstantEvaluateTest.Margin = new System.Windows.Forms.Padding(5);
            this.tilMInstantEvaluateTest.Name = "tilMInstantEvaluateTest";
            this.tilMInstantEvaluateTest.Size = new System.Drawing.Size(144, 40);
            this.tilMInstantEvaluateTest.TabIndex = 2;
            this.tilMInstantEvaluateTest.Text = "Test";
            this.tilMInstantEvaluateTest.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tilMInstantEvaluateTest.UseSelectable = true;
            this.tilMInstantEvaluateTest.Click += new System.EventHandler(this.TilMInstantEvaluateTestClick);
            // 
            // tilMInstantEvaluateTrain
            // 
            this.tilMInstantEvaluateTrain.ActiveControl = null;
            this.tilMInstantEvaluateTrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilMInstantEvaluateTrain.Location = new System.Drawing.Point(158, 5);
            this.tilMInstantEvaluateTrain.Margin = new System.Windows.Forms.Padding(5);
            this.tilMInstantEvaluateTrain.Name = "tilMInstantEvaluateTrain";
            this.tilMInstantEvaluateTrain.Size = new System.Drawing.Size(143, 40);
            this.tilMInstantEvaluateTrain.TabIndex = 1;
            this.tilMInstantEvaluateTrain.Text = "Train and Validation";
            this.tilMInstantEvaluateTrain.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tilMInstantEvaluateTrain.UseSelectable = true;
            this.tilMInstantEvaluateTrain.Click += new System.EventHandler(this.TilMInstantEvaluateTrainClick);
            // 
            // tilMInstantEvaluateAll
            // 
            this.tilMInstantEvaluateAll.ActiveControl = null;
            this.tilMInstantEvaluateAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilMInstantEvaluateAll.Location = new System.Drawing.Point(5, 5);
            this.tilMInstantEvaluateAll.Margin = new System.Windows.Forms.Padding(5);
            this.tilMInstantEvaluateAll.Name = "tilMInstantEvaluateAll";
            this.tilMInstantEvaluateAll.Size = new System.Drawing.Size(143, 40);
            this.tilMInstantEvaluateAll.TabIndex = 0;
            this.tilMInstantEvaluateAll.Text = "All";
            this.tilMInstantEvaluateAll.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tilMInstantEvaluateAll.UseSelectable = true;
            this.tilMInstantEvaluateAll.Click += new System.EventHandler(this.TilMInstantEvaluateAllClick);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // ClassificationTrainOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ClassificationTrainOptions";
            this.Padding = new System.Windows.Forms.Padding(20, 20, 10, 20);
            this.Size = new System.Drawing.Size(500, 860);
            this.Load += new System.EventHandler(this.TrainOptionsLoad);
            this.metroPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpContinualLearning.ResumeLayout(false);
            this.tlpContinualLearning.PerformLayout();
            this.panelContinualLearning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMContinualLearning)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.panelMClassWeight.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panelInstantEvaluate.ResumeLayout(false);
            this.tlpInstantEvaluate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel lblMnetworkModel;
        private MetroFramework.Controls.MetroLabel lblMepochNumber;
        private MetroFramework.Controls.MetroLabel lblMmodelMinimumSelectionEpoch;
        private MetroFramework.Controls.MetroLabel lblMtrainRepeat;
        private MetroFramework.Controls.MetroLabel lblMvalidationRatio;
        private MetroFramework.Controls.MetroLabel lblMpatienceEpochs;
        private MetroFramework.Controls.MetroLabel lblMTrainDataNumber;
        private MetroFramework.Controls.MetroTile tilMZoom;
        private MetroFramework.Controls.MetroTile tilMSharpen;
        private MetroFramework.Controls.MetroTile tilMGaussianNoise;
        private MetroFramework.Controls.MetroTile tilMContrast;
        private MetroFramework.Controls.MetroTile tilMGradationRGB;
        private MetroFramework.Controls.MetroTile tilMCenter;
        private MetroFramework.Controls.MetroTile tilMBrightness;
        private MetroFramework.Controls.MetroTile tilMBlur;
        private MetroFramework.Controls.MetroTile tilMGradation;
        private MetroFramework.Controls.MetroLabel lblMDataAugmentation;
        private System.Windows.Forms.TableLayoutPanel tlpContinualLearning;
        private MetroFramework.Controls.MetroLabel lblMContinualLearning;
        private System.Windows.Forms.Panel panelContinualLearning;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private MetroFramework.Controls.MetroLabel lblMClassWeight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private MetroFramework.Controls.MetroLabel lblMInstantEvaluate;
        private System.Windows.Forms.Panel panelInstantEvaluate;
        private System.Windows.Forms.Panel panelUnderbar2;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.Panel panelUnderbar5;
        private System.Windows.Forms.Panel panelUnderbar3;
        private System.Windows.Forms.Panel panelUnderbar1;
        private System.Windows.Forms.Panel panelUnderbar4;
        private System.Windows.Forms.Panel panelUnderbar6;
        private System.Windows.Forms.Button btnEpochNumberS;
        private System.Windows.Forms.Button btnEpochNumberP;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.TextBox textBox5;
        private ProjectAI.MainForms.UserContral.Classification.ClassWeightControl classWeightControl1;
        private System.Windows.Forms.TableLayoutPanel tlpInstantEvaluate;
        private MetroFramework.Controls.MetroPanel panelMBlurToolTip;
        internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal MetroFramework.Controls.MetroToggle togMContinualLearning;
        internal MetroFramework.Controls.MetroToggle togMInstantEvaluate;
        internal System.Windows.Forms.TextBox txtMmodelMinimumSelectionEpoch;
        internal System.Windows.Forms.TextBox txtPatienceEpochs;
        internal System.Windows.Forms.TextBox txtEpochNumber;
        internal System.Windows.Forms.TextBox txtTrainRepeat;
        internal System.Windows.Forms.TextBox txtValidationRatio;
        internal System.Windows.Forms.TextBox txtTrainDataNumber;
        internal System.Windows.Forms.TextBox txtBrightnessMin;
        internal System.Windows.Forms.TextBox txtBrightnessMax;
        internal System.Windows.Forms.TextBox txtCenter;
        internal System.Windows.Forms.TextBox txtContrastMin;
        internal System.Windows.Forms.TextBox txtContrastMax;
        internal System.Windows.Forms.TextBox txtGaussianNoise;
        internal System.Windows.Forms.TextBox txtGradation;
        internal System.Windows.Forms.TextBox txtSharpen;
        internal System.Windows.Forms.TextBox txtZoomMin;
        internal System.Windows.Forms.TextBox txtZoomMax;
        internal System.Windows.Forms.TextBox txtBlur;
        internal MetroFramework.Controls.MetroPanel panelMClassWeight;
        internal MetroFramework.Controls.MetroTile tilMInstantEvaluateTest;
        internal MetroFramework.Controls.MetroTile tilMInstantEvaluateTrain;
        internal MetroFramework.Controls.MetroTile tilMInstantEvaluateAll;
        internal MetroFramework.Controls.MetroGrid dgvMContinualLearning;
        internal MetroFramework.Controls.MetroComboBox cbbManetworkModel;
        internal MetroFramework.Controls.MetroComboBox cbbArchitecture;
        internal MetroFramework.Controls.MetroCheckBox ckbMHorizontalFlip;
        internal MetroFramework.Controls.MetroCheckBox ckbMBlur;
        internal MetroFramework.Controls.MetroCheckBox ckbMContrast;
        internal MetroFramework.Controls.MetroCheckBox ckbBrightness;
        internal MetroFramework.Controls.MetroCheckBox ckbMCenter;
        internal MetroFramework.Controls.MetroCheckBox ckbMGaussianNoise;
        internal MetroFramework.Controls.MetroCheckBox ckbMGradation;
        internal MetroFramework.Controls.MetroCheckBox ckbGradationRGB;
        internal MetroFramework.Controls.MetroCheckBox ckbMRotation90;
        internal MetroFramework.Controls.MetroCheckBox ckbMRotation180;
        internal MetroFramework.Controls.MetroCheckBox ckbMRotation270;
        internal MetroFramework.Controls.MetroCheckBox ckbMSharpen;
        internal MetroFramework.Controls.MetroCheckBox ckbMVerticalFlip;
        internal MetroFramework.Controls.MetroCheckBox ckbMZoom;
        private MetroFramework.Controls.MetroPanel panelMZoomToolTip;
        private MetroFramework.Controls.MetroPanel panelMVerticalFlipToolTip;
        private MetroFramework.Controls.MetroPanel panelMSharpenToolTip;
        private MetroFramework.Controls.MetroPanel panelMRotation270ToolTip;
        private MetroFramework.Controls.MetroPanel panelMRotation180ToolTip;
        private MetroFramework.Controls.MetroPanel panelMRotation90ToolTip;
        private MetroFramework.Controls.MetroPanel panelMHorizontalFlipToolTip;
        private MetroFramework.Controls.MetroPanel panelMGradationRGBToolTip;
        private MetroFramework.Controls.MetroPanel panelMGradationToolTip;
        private MetroFramework.Controls.MetroPanel panelMContrastToolTip;
        private MetroFramework.Controls.MetroPanel panelMCenterToolTip;
        private MetroFramework.Controls.MetroPanel panelMBrightnessToolTip;
        private MetroFramework.Controls.MetroPanel panelMGaussianNoiseToolTip;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private System.Windows.Forms.Button btnMmodelMinimumSelectionEpochS;
        private System.Windows.Forms.Button btnPatienceEpochsS;
        private System.Windows.Forms.Button btnMmodelMinimumSelectionEpochP;
        private System.Windows.Forms.Button btnPatienceEpochsP;
        private System.Windows.Forms.Button btnTrainRepeatP;
        private System.Windows.Forms.Button btnValidationRatioP;
        private System.Windows.Forms.Button btnTrainRepeatS;
        private System.Windows.Forms.Button btnValidationRatioS;
    }
}
