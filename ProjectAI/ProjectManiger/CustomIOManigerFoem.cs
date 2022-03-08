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

namespace ProjectAI.ProjectManiger
{
    public partial class CustomIOManigerFoem : Form
    {
        /// <summary>
        /// FormsManiger
        /// </summary>
        FormsManiger formsManiger = FormsManiger.GetInstance(); // Forms 관리 Class

        /// <summary>
        /// Label TextBox 안전 접근 
        /// </summary>
        /// <param name="textBox"> </param>
        /// <param name="text"></param>
        public delegate void SafeCallLabelText(System.Object textBoxObject, string text);

        /// <summary>
        /// Label TextBox 안전 접근 쓰기 함수
        /// </summary>
        /// <param name="labelObject"> TextBox Object </param>
        /// <param name="text"> 출력할 텍스트 </param>
        public void SafeWriteLabelText(Object labelObject, string text)
        {
            if (labelObject.GetType() == typeof(MetroFramework.Controls.MetroLabel))
            {
                MetroFramework.Controls.MetroLabel label = (MetroFramework.Controls.MetroLabel)labelObject;
                if (label.InvokeRequired)
                {
                    var d = new SafeCallLabelText(SafeWriteLabelText);
                    Invoke(d, new object[] { label, text });
                }
                else
                {
                    label.Text = text;
                }
            }
            else if (labelObject.GetType() == typeof(System.Windows.Forms.Label))
            {
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)labelObject;
                if (label.InvokeRequired)
                {
                    var d = new SafeCallLabelText(SafeWriteLabelText);
                    Invoke(d, new object[] { label, text });
                }
                else
                {
                    label.Text = text;
                }
            }
        }

        /// <summary>
        /// ProgressBar 안전 접근 
        /// </summary>
        /// <param name="progressBarObject"> ProgressBar Object </param>
        /// <param name="maximum"> 최대값 </param>
        /// <param name="value"> 현재값 </param>
        public delegate void SafeCallProgressBar(System.Object progressBarObject, int maximum, int value);

        /// <summary>
        /// ProgressBar 안전 접근 함수
        /// </summary>
        /// <param name="progressBarObject"> ProgressBar Object </param>
        /// <param name="maximum"> 최대값 </param>
        /// <param name="value"> 현재값 </param>
        public void SafeWriteProgressBar(Object progressBarObject, int maximum, int value)
        {
            if (progressBarObject.GetType() == typeof(MetroFramework.Controls.MetroProgressBar))
            {
                MetroFramework.Controls.MetroProgressBar progressBar = (MetroFramework.Controls.MetroProgressBar)progressBarObject;
                if (progressBar.InvokeRequired)
                {
                    var d = new SafeCallLabelText(SafeWriteLabelText);
                    Invoke(d, new object[] { progressBar, maximum, value });
                }
                else
                {
                    progressBar.Maximum = maximum;
                    progressBar.Value = value;
                }
            }
            else if (progressBarObject.GetType() == typeof(System.Windows.Forms.ProgressBar))
            {
                System.Windows.Forms.ProgressBar progressBar = (System.Windows.Forms.ProgressBar)progressBarObject;
                if (progressBar.InvokeRequired)
                {
                    var d = new SafeCallLabelText(SafeWriteLabelText);
                    Invoke(d, new object[] { progressBar, maximum, value });
                }
                else
                {
                    progressBar.Maximum = maximum;
                    progressBar.Value = value;
                }
            }
        }

        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            this.metroStyleManager1.Style = styleManager.Style;
            this.metroStyleManager1.Theme = styleManager.Theme;
            this.BackColor = formsManiger.GetThemeRGBClor(styleManager.Theme.ToString());
        }

        /// <summary>
        /// Start
        /// </summary>
        public CustomIOManigerFoem()
        {
            InitializeComponent();

            // UpdataFormStyleManager 등록
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            // Form에 Style 적용
            //this.UpdataFormStyleManager(formsManiger.m_StyleManager);
        }

        public Task test;

        public void CreateFileCopyList(int number)
        {
            test.ContinueWith((tesk) => CustomIOMainger.Test1(number), TaskContinuationOptions.ExecuteSynchronously);
        }

    }
}
