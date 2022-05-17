using MetroFramework.Components;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace ProjectAI.DataAugmentationExampleForms
{
    public partial class DataAugmentationExampleForm : MetroForm
    {
        private string imageDataPath = null;
        private string exCase = null;

        public string maximumValue;
        public string minimumValue;

        public DialogResult DialogResultSelected = DialogResult.None;

        private ProjectAI.DataAugmentationExampleForms.Contral1.MinMaxExample minMaxExample;

        public DataAugmentationExampleForm(string imageDataPath, string exCase)
        {
            InitializeComponent();

            this.imageDataPath = imageDataPath;
            this.exCase = exCase.ToLower().Trim();

            this.StyleManager = this.metroStyleManager1;

            // Forms Calss formStyleManager Update Handler 등록
            //FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            ProjectAI.FormsManiger formsManiger = ProjectAI.FormsManiger.GetInstance(); // Forms 관리 Class
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);

            this.ActiveControl = this.btnMstartOptionsOK;
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

        private void DataAugmentationExampleFormLoad(object sender, EventArgs e)
        {
        }

        private void DataAugmentationExampleFormShown(object sender, EventArgs e)
        {
            if (this.imageDataPath != null || this.exCase != null)
            {
                this.minMaxExample = new Contral1.MinMaxExample(this.imageDataPath, this.exCase)
                {
                    //
                    // blurExample1
                    //
                    Dock = System.Windows.Forms.DockStyle.Fill,
                    Location = new System.Drawing.Point(0, 0),
                    //blurExample.Name = "blurExample1";
                    Size = new System.Drawing.Size(812, 456)
                };
                //blurExample.TabIndex = 0;
                this.metroPanel1.Controls.Add(this.minMaxExample);
                // 활성화
                this.minMaxExample.ActiveExample();

                this.Text = $"DataAugmentation ( {this.exCase[0].ToString().ToUpper() + this.exCase.Substring(1)} )";
            }
        }

        private void BtnMstartOptionsOKClick(object sender, EventArgs e)
        {
            this.maximumValue = this.minMaxExample.GetMaximumValue();
            this.minimumValue = this.minMaxExample.GetMinimumValue();

            this.DialogResultSelected = DialogResult.OK;
            this.DialogResult = DialogResult.OK;
        }

        private void BtnMstartOptionsCancelClick(object sender, EventArgs e)
        {
            this.DialogResultSelected = DialogResult.Cancel;
            this.DialogResult = DialogResult.Cancel;
        }
    }
}