using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace ProjectAI.CustomMessageBox
{
    public partial class CustomMessageBoxOKCancel : MetroForm
    {
        public CustomMessageBoxOKCancel(MessageBoxIcon messageBoxIcon)
        {
            InitializeComponent();
            this.StyleManager = this.metroStyleManager1;
            this.SetButton(messageBoxIcon);
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
                MetroColorStyle metroColorStyle = MetroColorStyle.Orange;
                this.StyleChange(metroColorStyle, metroThemeStyle);
            }
            else if (messageBoxIcon.Equals(MessageBoxIcon.Error))
            {
                MetroColorStyle metroColorStyle = MetroColorStyle.Red;
                this.StyleChange(metroColorStyle, metroThemeStyle);
            }
            else if (messageBoxIcon.Equals(MessageBoxIcon.Stop))
            {
                MetroColorStyle metroColorStyle = MetroColorStyle.Purple;
                this.StyleChange(metroColorStyle, metroThemeStyle);
            }
            else if (messageBoxIcon.Equals(MessageBoxIcon.Question))
            {
                MetroColorStyle metroColorStyle = MetroColorStyle.Blue;
                this.StyleChange(metroColorStyle, metroThemeStyle);
            }
            else
            {
                MetroColorStyle metroColorStyle = formsManiger.m_StyleManager.Style;
                this.StyleChange(metroColorStyle, metroThemeStyle);
            }
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
