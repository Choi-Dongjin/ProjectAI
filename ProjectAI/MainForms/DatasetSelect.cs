using MetroFramework.Components;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace ProjectAI.MainForms
{
    public partial class DatasetSelect : MetroForm
    {
        public string selectDataset = null;

        /// <summary>
        /// 결과 가져오기
        /// </summary>
        public DialogResult selectDialogResult = DialogResult.None;

        public DatasetSelect()
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
        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            this.StyleManager.Style = styleManager.Style;
            this.StyleManager.Theme = styleManager.Theme;
        }

        private void TilMTrainValidationClick(object sender, EventArgs e)
        {
            this.selectDataset = "Train";
        }

        private void TilMTestClick(object sender, EventArgs e)
        {
            this.selectDataset = "Test";
        }

        private void BtnMOKClick(object sender, EventArgs e)
        {
            if (this.selectDataset != null)
            {
                this.selectDialogResult = DialogResult.OK;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnMCancelClick(object sender, EventArgs e)
        {
            this.selectDialogResult = DialogResult.Cancel;
            this.DialogResult = DialogResult.Cancel;

            this.selectDialogResult = DialogResult.None;

            this.Close();
        }
    }
}