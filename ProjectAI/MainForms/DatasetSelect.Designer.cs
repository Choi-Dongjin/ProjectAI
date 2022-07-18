namespace ProjectAI.MainForms
{
    partial class DatasetSelect
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
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tilMTrainValidation = new MetroFramework.Controls.MetroTile();
            this.tilMTest = new MetroFramework.Controls.MetroTile();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMOK = new MetroFramework.Controls.MetroButton();
            this.btnMCancel = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tilMTrainValidation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tilMTest, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(408, 137);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tilMTrainValidation
            // 
            this.tilMTrainValidation.ActiveControl = null;
            this.tilMTrainValidation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilMTrainValidation.Location = new System.Drawing.Point(3, 3);
            this.tilMTrainValidation.Name = "tilMTrainValidation";
            this.tilMTrainValidation.Size = new System.Drawing.Size(198, 96);
            this.tilMTrainValidation.TabIndex = 0;
            this.tilMTrainValidation.Text = "Train";
            this.tilMTrainValidation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tilMTrainValidation.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tilMTrainValidation.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.tilMTrainValidation.UseMnemonic = false;
            this.tilMTrainValidation.UseSelectable = true;
            this.tilMTrainValidation.Click += new System.EventHandler(this.TilMTrainValidationClick);
            // 
            // tilMTest
            // 
            this.tilMTest.ActiveControl = null;
            this.tilMTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilMTest.Location = new System.Drawing.Point(207, 3);
            this.tilMTest.Name = "tilMTest";
            this.tilMTest.Size = new System.Drawing.Size(198, 96);
            this.tilMTest.TabIndex = 1;
            this.tilMTest.Text = "Test";
            this.tilMTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tilMTest.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tilMTest.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.tilMTest.UseSelectable = true;
            this.tilMTest.Click += new System.EventHandler(this.TilMTestClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel2.Controls.Add(this.btnMOK, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnMCancel, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(408, 35);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnMOK
            // 
            this.btnMOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMOK.Location = new System.Drawing.Point(207, 3);
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
            this.btnMCancel.Location = new System.Drawing.Point(309, 3);
            this.btnMCancel.Name = "btnMCancel";
            this.btnMCancel.Size = new System.Drawing.Size(96, 29);
            this.btnMCancel.TabIndex = 8;
            this.btnMCancel.Text = "Cancel (&C)";
            this.btnMCancel.UseSelectable = true;
            this.btnMCancel.Click += new System.EventHandler(this.BtnMCancelClick);
            // 
            // DatasetSelect
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(448, 217);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatasetSelect";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dataset Select";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroTile tilMTrainValidation;
        private MetroFramework.Controls.MetroTile tilMTest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroButton btnMOK;
        private MetroFramework.Controls.MetroButton btnMCancel;
    }
}