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

namespace ProjectAI.MainForms
{
    public partial class MainFormsImageListPage : MetroForm
    {
        DialogResult selectDialogResult = DialogResult.None;
        public MainFormsImageListPage()
        {
            InitializeComponent();
            this.StyleManager = this.metroStyleManager1;

            FormsManiger formsManiger = FormsManiger.GetInstance();
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);
        }
        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            this.StyleManager.Style = styleManager.Style;
            this.StyleManager.Theme = styleManager.Theme;
        }

        public int GetPage()
        {
            if (int.TryParse(textBox1.Text, out int page))
            {
                return page;
            }
            return -1;
        }

        private void BtnMOKClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.selectDialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnMCClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.selectDialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
