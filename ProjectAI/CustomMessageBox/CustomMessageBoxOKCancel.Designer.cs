namespace ProjectAI.CustomMessageBox
{
    partial class CustomMessageBoxOKCancel
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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMtextBox = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMOK = new MetroFramework.Controls.MetroButton();
            this.btnMCancel = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.lblMtextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMOK, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnMCancel, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(516, 185);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblMtextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lblMtextBox, 2);
            // 
            // 
            // 
            this.lblMtextBox.CustomButton.Image = null;
            this.lblMtextBox.CustomButton.Location = new System.Drawing.Point(214, 2);
            this.lblMtextBox.CustomButton.Name = "";
            this.lblMtextBox.CustomButton.Size = new System.Drawing.Size(139, 139);
            this.lblMtextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblMtextBox.CustomButton.TabIndex = 1;
            this.lblMtextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lblMtextBox.CustomButton.UseSelectable = true;
            this.lblMtextBox.CustomButton.Visible = false;
            this.lblMtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMtextBox.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.lblMtextBox.Lines = new string[0];
            this.lblMtextBox.Location = new System.Drawing.Point(157, 3);
            this.lblMtextBox.MaxLength = 32767;
            this.lblMtextBox.Multiline = true;
            this.lblMtextBox.Name = "lblMtextBox";
            this.lblMtextBox.PasswordChar = '\0';
            this.lblMtextBox.PromptText = "Text";
            this.lblMtextBox.ReadOnly = true;
            this.lblMtextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lblMtextBox.SelectedText = "";
            this.lblMtextBox.SelectionLength = 0;
            this.lblMtextBox.SelectionStart = 0;
            this.lblMtextBox.ShortcutsEnabled = true;
            this.lblMtextBox.Size = new System.Drawing.Size(356, 144);
            this.lblMtextBox.TabIndex = 3;
            this.lblMtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lblMtextBox.UseSelectable = true;
            this.lblMtextBox.WaterMark = "Text";
            this.lblMtextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.lblMtextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ProjectAI.Properties.Resources.synapseimaging;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnMOK
            // 
            this.btnMOK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMOK.Location = new System.Drawing.Point(157, 153);
            this.btnMOK.Name = "btnMOK";
            this.btnMOK.Size = new System.Drawing.Size(174, 29);
            this.btnMOK.TabIndex = 0;
            this.btnMOK.Text = "OK";
            this.btnMOK.UseSelectable = true;
            this.btnMOK.Click += new System.EventHandler(this.BtnMOKClick);
            // 
            // btnMCancel
            // 
            this.btnMCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMCancel.Location = new System.Drawing.Point(337, 153);
            this.btnMCancel.Name = "btnMCancel";
            this.btnMCancel.Size = new System.Drawing.Size(176, 29);
            this.btnMCancel.TabIndex = 0;
            this.btnMCancel.Text = "Cancel";
            this.btnMCancel.UseSelectable = true;
            this.btnMCancel.Click += new System.EventHandler(this.BtnMCancelClick);
            // 
            // CustomMessageBoxOKCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 265);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CustomMessageBoxOKCancel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CustomMessageBoxOKCancel";
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton btnMOK;
        private MetroFramework.Controls.MetroButton btnMCancel;
        private MetroFramework.Controls.MetroTextBox lblMtextBox;
    }
}