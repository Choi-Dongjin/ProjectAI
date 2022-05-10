using MetroFramework.Components;
using MetroFramework.Forms;
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
namespace ProjectAI.MainForms
{
    public partial class CadImageSelect : MetroForm
    {
        public DialogResult selectDialogResult = DialogResult.None;

        /// <summary>
        /// 싱글톤 패턴 구현
        /// </summary>
        public static CadImageSelect CADForm;

        /// <summary>
        /// 싱글톤 패턴
        /// </summary>
        /// <returns></returns>
        public static CadImageSelect GetInstance()
        {
            if (CadImageSelect.CADForm == null)
            {
                CadImageSelect.CADForm = new CadImageSelect();
            }
            return CadImageSelect.CADForm;
        }

        public CadImageSelect()
        {
            InitializeComponent();
            ProjectAI.FormsManiger formsManiger = ProjectAI.FormsManiger.GetInstance();
            this.StyleManager = this.metroStyleManager1;
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);

        }


        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        private void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            this.StyleManager.Style = styleManager.Style;
            this.StyleManager.Theme = styleManager.Theme;
        }

        private void BtnOKClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.selectDialogResult = DialogResult.OK;
            WorkSpaceData.m_activeProjectMainger.CADImageAdding();
            this.Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.selectDialogResult = DialogResult.Cancel;

            this.Close();
            //this.Dispose();
        }

        private void PictureBox1Click(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                WorkSpaceData.m_activeProjectMainger.OriginImageFilesSelect();
            if (this.pictureBox1.Image != null && this.pictureBox2.Image != null)
                this.btnOK.Enabled = true;
        }

        private void PictureBox2Click(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                WorkSpaceData.m_activeProjectMainger.CADImageFilesSelect();
            if (this.pictureBox1.Image != null && this.pictureBox2.Image != null)
                this.btnOK.Enabled = true;
        }

        private void CadImageSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }
    }
}