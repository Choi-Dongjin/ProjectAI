namespace ProjectAI.MainForms
{
    partial class DeeplearningProjectSelectForm
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
            this.btnMClassification = new MetroFramework.Controls.MetroTile();
            this.btnMSegmentation = new MetroFramework.Controls.MetroTile();
            this.btnMObjectDetection = new MetroFramework.Controls.MetroTile();
            this.btnMnull = new MetroFramework.Controls.MetroTile();
            this.styleManagerDeeplearningProjectSelectForm = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMCancel = new MetroFramework.Controls.MetroButton();
            this.btnMOK = new MetroFramework.Controls.MetroButton();
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.styleManagerDeeplearningProjectSelectForm)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMClassification
            // 
            this.btnMClassification.ActiveControl = null;
            this.btnMClassification.Location = new System.Drawing.Point(0, 0);
            this.btnMClassification.Margin = new System.Windows.Forms.Padding(0);
            this.btnMClassification.Name = "btnMClassification";
            this.btnMClassification.Size = new System.Drawing.Size(200, 200);
            this.btnMClassification.TabIndex = 3;
            this.btnMClassification.Text = "Classification";
            this.btnMClassification.TileImage = global::ProjectAI.Properties.Resources.classification200;
            this.btnMClassification.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMClassification.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnMClassification.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnMClassification.UseSelectable = true;
            this.btnMClassification.UseTileImage = true;
            this.btnMClassification.Click += new System.EventHandler(this.BtnMClassificationClick);
            // 
            // btnMSegmentation
            // 
            this.btnMSegmentation.ActiveControl = null;
            this.btnMSegmentation.Location = new System.Drawing.Point(215, 0);
            this.btnMSegmentation.Margin = new System.Windows.Forms.Padding(0);
            this.btnMSegmentation.Name = "btnMSegmentation";
            this.btnMSegmentation.Size = new System.Drawing.Size(200, 200);
            this.btnMSegmentation.TabIndex = 4;
            this.btnMSegmentation.Text = "Segmentation";
            this.btnMSegmentation.TileImage = global::ProjectAI.Properties.Resources.segmentation200;
            this.btnMSegmentation.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMSegmentation.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnMSegmentation.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnMSegmentation.UseSelectable = true;
            this.btnMSegmentation.UseTileImage = true;
            this.btnMSegmentation.Click += new System.EventHandler(this.btnMSegmentation_Click);
            // 
            // btnMObjectDetection
            // 
            this.btnMObjectDetection.ActiveControl = null;
            this.btnMObjectDetection.Location = new System.Drawing.Point(430, 0);
            this.btnMObjectDetection.Margin = new System.Windows.Forms.Padding(0);
            this.btnMObjectDetection.Name = "btnMObjectDetection";
            this.btnMObjectDetection.Size = new System.Drawing.Size(200, 200);
            this.btnMObjectDetection.TabIndex = 5;
            this.btnMObjectDetection.Text = "Object Detection";
            this.btnMObjectDetection.TileImage = global::ProjectAI.Properties.Resources.objectdetection200;
            this.btnMObjectDetection.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMObjectDetection.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnMObjectDetection.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnMObjectDetection.UseSelectable = true;
            this.btnMObjectDetection.UseTileImage = true;
            this.btnMObjectDetection.Click += new System.EventHandler(this.btnMObjectDetection_Click);
            // 
            // btnMnull
            // 
            this.btnMnull.ActiveControl = null;
            this.btnMnull.Location = new System.Drawing.Point(645, 0);
            this.btnMnull.Margin = new System.Windows.Forms.Padding(0);
            this.btnMnull.Name = "btnMnull";
            this.btnMnull.Size = new System.Drawing.Size(200, 200);
            this.btnMnull.TabIndex = 6;
            this.btnMnull.TileImage = global::ProjectAI.Properties.Resources.imageBackground2;
            this.btnMnull.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMnull.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnMnull.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnMnull.UseSelectable = true;
            this.btnMnull.UseTileImage = true;
            // 
            // styleManagerDeeplearningProjectSelectForm
            // 
            this.styleManagerDeeplearningProjectSelectForm.Owner = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.btnMClassification, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMnull, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMObjectDetection, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMSegmentation, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(845, 499);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.metroPanel1, 7);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 200);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(845, 260);
            this.metroPanel1.TabIndex = 7;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 7);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnMCancel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnMOK, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 460);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(845, 35);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // btnMCancel
            // 
            this.btnMCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMCancel.Location = new System.Drawing.Point(746, 3);
            this.btnMCancel.Name = "btnMCancel";
            this.btnMCancel.Size = new System.Drawing.Size(96, 29);
            this.btnMCancel.TabIndex = 7;
            this.btnMCancel.Text = "Cancel (&C)";
            this.btnMCancel.UseSelectable = true;
            this.btnMCancel.Click += new System.EventHandler(this.BtnMCancelClick);
            // 
            // btnMOK
            // 
            this.btnMOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMOK.Location = new System.Drawing.Point(644, 3);
            this.btnMOK.Name = "btnMOK";
            this.btnMOK.Size = new System.Drawing.Size(96, 29);
            this.btnMOK.TabIndex = 6;
            this.btnMOK.Text = "OK (&O)";
            this.btnMOK.UseSelectable = true;
            this.btnMOK.Click += new System.EventHandler(this.BtnMOKClick);
            // 
            // DeeplearningProjectSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 549);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DisplayHeader = false;
            this.Name = "DeeplearningProjectSelectForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "DeeplearningProjectSelectForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeeplearningProjectSelectFormFormClosing);
            this.Load += new System.EventHandler(this.DeeplearningProjectSelectFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.styleManagerDeeplearningProjectSelectForm)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTile btnMSegmentation;
        private MetroFramework.Controls.MetroTile btnMObjectDetection;
        private MetroFramework.Controls.MetroTile btnMnull;
        private MetroFramework.Components.MetroStyleManager styleManagerDeeplearningProjectSelectForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroTile btnMClassification;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroButton btnMOK;
        private MetroFramework.Controls.MetroButton btnMCancel;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
    }
}