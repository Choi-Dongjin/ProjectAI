using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAI.MainForms.UserContral.Classification
{
    public partial class ContinualLearningControl : UserControl
    {
        public ContinualLearningControl()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.None;
        }

        private void ContinualLearningControlLoad(object sender, EventArgs e)
        {
            FormsManiger formsManiger = FormsManiger.GetInstance(); // 폼 메니저
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);
        }

        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        public void UpdataFormStyleManager(MetroFramework.Components.MetroStyleManager styleManager)
        {
            this.metroStyleManager1.Style = styleManager.Style;
            this.metroStyleManager1.Theme = styleManager.Theme;
        }
    }
}