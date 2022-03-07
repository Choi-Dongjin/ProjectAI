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
    public partial class ClassEditClassButtonEdit : MetroForm
    {
        /// <summary>
        /// jsonDataManiger
        /// </summary>
        JsonDataManiger jsonDataManiger = JsonDataManiger.GetInstance();

        /// <summary>
        /// 폼 메니저
        /// </summary>
        private FormsManiger formsManiger = FormsManiger.GetInstance();

        ProjectAI.MainForms.UserContral.ClassEdit.ClassButton m_classButton;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classButton"></param>
        public ClassEditClassButtonEdit(ProjectAI.MainForms.UserContral.ClassEdit.ClassButton classButton)
        {
            InitializeComponent();

            this.m_classButton = classButton;

            this.StyleManager = this.metroStyleManager1;

            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;

            this.UpdataFormStyleManager(formsManiger.m_StyleManager);
        }

        ~ClassEditClassButtonEdit()
        {
            FormsManiger.m_formStyleManagerHandler -= this.UpdataFormStyleManager;
        }

        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            this.StyleManager.Style = styleManager.Style;
            this.StyleManager.Theme = styleManager.Theme;
        }

        private void ClassEditClassButtonEditLoad(object sender, EventArgs e)
        {

        }

        private void ClassEditClassButtonEditFormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.m_classButton.TileBackColor = colorDialog.Color;
            }
        }
    }
}
