namespace ProjectAI.CustomComponent.MainForms.Idle
{
    partial class IdelTrainOptions
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.txtMworkSpaceName = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.AutoScroll = true;
            this.metroPanel1.AutoScrollMinSize = new System.Drawing.Size(460, 810);
            this.metroPanel1.Controls.Add(this.txtMworkSpaceName);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbar = true;
            this.metroPanel1.HorizontalScrollbarBarColor = false;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 20);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.metroPanel1.Size = new System.Drawing.Size(470, 810);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.VerticalScrollbar = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // txtMworkSpaceName
            // 
            // 
            // 
            // 
            this.txtMworkSpaceName.CustomButton.Image = null;
            this.txtMworkSpaceName.CustomButton.Location = new System.Drawing.Point(-348, 2);
            this.txtMworkSpaceName.CustomButton.Name = "";
            this.txtMworkSpaceName.CustomButton.Size = new System.Drawing.Size(805, 805);
            this.txtMworkSpaceName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMworkSpaceName.CustomButton.TabIndex = 1;
            this.txtMworkSpaceName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMworkSpaceName.CustomButton.UseSelectable = true;
            this.txtMworkSpaceName.CustomButton.Visible = false;
            this.txtMworkSpaceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMworkSpaceName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtMworkSpaceName.Lines = new string[0];
            this.txtMworkSpaceName.Location = new System.Drawing.Point(0, 0);
            this.txtMworkSpaceName.MaxLength = 32767;
            this.txtMworkSpaceName.Multiline = true;
            this.txtMworkSpaceName.Name = "txtMworkSpaceName";
            this.txtMworkSpaceName.PasswordChar = '\0';
            this.txtMworkSpaceName.PromptText = "Check Project";
            this.txtMworkSpaceName.ReadOnly = true;
            this.txtMworkSpaceName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMworkSpaceName.SelectedText = "";
            this.txtMworkSpaceName.SelectionLength = 0;
            this.txtMworkSpaceName.SelectionStart = 0;
            this.txtMworkSpaceName.ShortcutsEnabled = true;
            this.txtMworkSpaceName.Size = new System.Drawing.Size(460, 810);
            this.txtMworkSpaceName.TabIndex = 2;
            this.txtMworkSpaceName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMworkSpaceName.UseSelectable = true;
            this.txtMworkSpaceName.WaterMark = "Check Project";
            this.txtMworkSpaceName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMworkSpaceName.WaterMarkFont = new System.Drawing.Font("Segoe UI Semibold", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // IdelTrainOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "IdelTrainOptions";
            this.Padding = new System.Windows.Forms.Padding(20, 20, 10, 20);
            this.Size = new System.Drawing.Size(500, 850);
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox txtMworkSpaceName;
    }
}
