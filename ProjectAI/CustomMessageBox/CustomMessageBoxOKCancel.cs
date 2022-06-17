using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace ProjectAI.CustomMessageBox
{
    public partial class CustomMessageBoxOKCancel : MetroForm
    {
        public CustomMessageBoxOKCancel(MessageBoxIcon messageBoxIcon, string text)
        {
            InitializeComponent();
            this.StyleManager = this.metroStyleManager1;
            this.SetButton(messageBoxIcon);
            this.SetText(text);
            //this.ActiveControl = this.btnMOK;
        }

        public void StyleChange(MetroColorStyle metroColorStyle, MetroThemeStyle metroThemeStyle)
        {
            this.metroStyleManager1.Style = metroColorStyle;
            this.metroStyleManager1.Theme = metroThemeStyle;
        }

        public void SetButton(MessageBoxIcon messageBoxIcon)
        {
            FormsManiger formsManiger = FormsManiger.GetInstance();
            MetroThemeStyle metroThemeStyle = formsManiger.m_StyleManager.Theme;

            if (messageBoxIcon.Equals(MessageBoxIcon.Warning))
            {
                this.Text = "Warning";
                this.pictureBox1.Image = global::ProjectAI.Properties.Resources.Warning1Test;

                MetroColorStyle metroColorStyle = MetroColorStyle.Orange;
                this.StyleChange(metroColorStyle, metroThemeStyle);
            }
            else if (messageBoxIcon.Equals(MessageBoxIcon.Error))
            {
                this.Text = "Error";
                this.pictureBox1.Image = global::ProjectAI.Properties.Resources.Error2TestW;

                MetroColorStyle metroColorStyle = MetroColorStyle.Red;
                this.StyleChange(metroColorStyle, metroThemeStyle);
            }
            else if (messageBoxIcon.Equals(MessageBoxIcon.Stop))
            {
                this.Text = "Stop";
                this.pictureBox1.Image = global::ProjectAI.Properties.Resources.Stop1Test;

                MetroColorStyle metroColorStyle = MetroColorStyle.Purple;
                this.StyleChange(metroColorStyle, metroThemeStyle);
            }
            else if (messageBoxIcon.Equals(MessageBoxIcon.Question))
            {
                this.Text = "Question";
                this.pictureBox1.Image = global::ProjectAI.Properties.Resources.Question1Test;

                MetroColorStyle metroColorStyle = MetroColorStyle.Blue;
                this.StyleChange(metroColorStyle, metroThemeStyle);
            }
            else
            {
                MetroColorStyle metroColorStyle = formsManiger.m_StyleManager.Style;
                this.StyleChange(metroColorStyle, metroThemeStyle);
            }
        }

        public void SetText(string text)
        {
            this.lblMtextBox.Text = text;
        }

        private void BtnMOKClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}