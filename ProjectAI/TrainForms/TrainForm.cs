using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace ProjectAI.TrainForms
{
    public partial class TrainForm : Form
    {
        /// <summary>
        /// 싱글톤 패턴 구현
        /// </summary>
        private static TrainForm trainForm;
        /// <summary>
        /// 싱글톤 패턴 Class 호출에 사용
        /// </summary>
        /// <returns></returns>
        public static TrainForm GetInstance()
        {
            if (TrainForm.trainForm == null)
            {
                TrainForm.trainForm = new TrainForm();
            }
            return TrainForm.trainForm;
        }

        /// <summary>
        /// Forms 관리 Class
        /// </summary>
        private ProjectAI.FormsManiger formsManiger = ProjectAI.FormsManiger.GetInstance(); // Forms 관리 Class

        /// <summary>
        /// Idel Train Options
        /// </summary>
        private ProjectAI.CustomComponent.MainForms.Idle.IdelTrainOptions IdelTrainOptions = new CustomComponent.MainForms.Idle.IdelTrainOptions();
        private ProjectAI.CustomComponent.MainForms.Classification.ClassificationTrainOptions ClassificationTrainOptions = new CustomComponent.MainForms.Classification.ClassificationTrainOptions();




        public TrainForm()
        {
            InitializeComponent();

            // Forms Calss formStyleManager Update Handler 등록
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;

            this.UISetIdelTrainOptions();
            this.UISetClassificationTrainOptions();

            this.panelMTrainOption.Controls.Add(this.IdelTrainOptions);
        }

        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            if (this.formsManiger.m_isDarkMode) // Light로 변경시 진입
            {
                // Metro Style, styleManagerMainFormTheme 변경
                this.metroStyleManager1.Style = styleManager.Style;
                this.metroStyleManager1.Theme = styleManager.Theme;
                // 배경 색 변경, Forms에 Metro Forms 적용하지 않은 경우
                this.BackColor = this.formsManiger.GetThemeRGBClor(styleManager.Theme.ToString());
            }
            else // Dark로 변경시 진입
            {
                // Metro Style, Theme 변경
                this.metroStyleManager1.Style = styleManager.Style;
                this.metroStyleManager1.Theme = styleManager.Theme;
                // 배경 색 변경, Forms에 Metro Forms 적용하지 않은 경우
                this.BackColor = this.formsManiger.GetThemeRGBClor(styleManager.Theme.ToString());
            }
        }

        /// <summary>
        /// UISetIdelTrainOptions UI Setup
        /// </summary>
        private void UISetIdelTrainOptions()
        {
            this.metroStyleExtender1.SetApplyMetroTheme(this.IdelTrainOptions, true);
            this.IdelTrainOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IdelTrainOptions.Location = new System.Drawing.Point(0, 0);
            this.IdelTrainOptions.Margin = new System.Windows.Forms.Padding(0);
            this.IdelTrainOptions.Name = "idelTrainOptions";
            this.IdelTrainOptions.Padding = new System.Windows.Forms.Padding(20, 20, 10, 20);
            this.IdelTrainOptions.Size = new System.Drawing.Size(500, 850);
            //this.IdelTrainOptions.TabIndex = 1;
        }
        /// <summary>
        /// UISetClassificationTrainOptions UI Setup
        /// </summary>
        private void UISetClassificationTrainOptions()
        {
            this.metroStyleExtender1.SetApplyMetroTheme(this.ClassificationTrainOptions, true);
            this.ClassificationTrainOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClassificationTrainOptions.Location = new System.Drawing.Point(0, 0);
            this.ClassificationTrainOptions.Margin = new System.Windows.Forms.Padding(0);
            this.ClassificationTrainOptions.Name = "classificationTrainOptions";
            this.ClassificationTrainOptions.Padding = new System.Windows.Forms.Padding(20, 20, 10, 20);
            this.ClassificationTrainOptions.Size = new System.Drawing.Size(500, 850);
            //this.classificationTrainOptions1.TabIndex = 2;
        }

        private void TrainFormLoad(object sender, EventArgs e)
        {

        }

        private void TrainFormShown(object sender, EventArgs e)
        {

        }

        private void TrainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            //Hiding the window, because closing it makes the window unaccessible.
            this.Hide();
            this.Parent = null;
            e.Cancel = true; //hides the form, cancels closing event
        }


        public void PushTrainData()
        {

        }
    }
}
