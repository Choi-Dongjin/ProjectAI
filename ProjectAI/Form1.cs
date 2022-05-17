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

namespace ProjectAI
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            this.StyleManager = this.metroStyleManager1;

            this.ActiveControl = this.btnMOK;
        }

        public void HderText(string text)
        {
            this.Text = text;
        }

        public void StyleChange(MetroColorStyle metroColorStyle, MetroThemeStyle metroThemeStyle)
        {
            this.metroStyleManager1.Style = metroColorStyle;
            this.metroStyleManager1.Theme = metroThemeStyle;
        }

        public void Textee(string text)
        {
            //this.textBox1.Text = text;
        }

        public void SetMessageBox(MetroColorStyle metroColorStyle, MetroThemeStyle metroThemeStyle, string HderText, string text)
        {
            this.StyleChange(metroColorStyle, metroThemeStyle);
            this.HderText(HderText);
            this.Textee(text);
        }
    }
}
