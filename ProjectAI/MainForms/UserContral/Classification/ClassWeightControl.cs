using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectAI.MainForms.UserContral.Classification
{
    public partial class ClassWeightControl : UserControl
    {
        public ClassWeightControl()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.None;
        }

        private void ClassWeightControlLoad(object sender, EventArgs e)
        {
            FormsManiger formsManiger = FormsManiger.GetInstance(); // 폼 메니저
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
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

        [Category("ClassWeightControl"), Description("Class Number")]
        public int Number
        {
            get
            {
                if (Int32.TryParse(lblMNumber.Text, out int inputNumber))
                {
                    return inputNumber;
                }
                else
                    return -1;
            }
            set
            {
                if (Number >= 0)
                    lblMNumber.Text = value.ToString();
            }
        }

        [Category("ClassWeightControl"), Description("Class Name")]
        public string ClassName
        {
            get
            {
                return lblMClassName.Text;
            }
            set
            {
                lblMClassName.Text = value;
            }
        }

        [Category("ClassWeightControl"), Description("Class Color")]
        public Color ClassNameColor
        {
            get
            {
                return lblMClassName.ForeColor;
            }
            set
            {
                lblMClassName.ForeColor = value;
            }
        }

        /// <summary>
        /// Class Train Weight
        /// </summary>
        [Category("ClassWeightControl"), Description("Class Train Weight")]
        public int Weight
        {
            get
            {
                if (Int32.TryParse(txtWeight.Text, out int inputWeight))
                {
                    return inputWeight;
                }
                else
                    return -1;
            }
            set
            {
                if (Weight > 0)
                    txtWeight.Text = value.ToString();
                else
                    txtWeight.Text = 1.ToString();
            }
        }

        private void BtnMWeightAddClick(object sender, EventArgs e)
        {
            if (Int32.TryParse(txtWeight.Text, out int weight))
            {
                weight++;
                txtWeight.Text = weight.ToString();
            }
        }

        private void BtnMWeightSubClick(object sender, EventArgs e)
        {
            if (Int32.TryParse(txtWeight.Text, out int weight))
            {
                if (weight > 1)
                {
                    weight--;
                    txtWeight.Text = weight.ToString();
                }
                else
                    txtWeight.Text = "1";
            }
        }

        private void TxtWeightLeave(object sender, EventArgs e)
        {
            if (Int32.TryParse(txtWeight.Text, out int weight))
            {
                if (weight < 1)
                {
                    txtWeight.Text = "1";
                }
            }
            else
            {
                txtWeight.Text = "1";
            }
        }
    }
}