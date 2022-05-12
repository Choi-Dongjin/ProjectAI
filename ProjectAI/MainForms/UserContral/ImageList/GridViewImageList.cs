using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAI.MainForms.UserContral.ImageList
{
    public partial class GridViewImageList : UserControl
    {
        FormsManiger formsManiger = FormsManiger.GetInstance();

        public GridViewImageList()
        {
            InitializeComponent();

            this.UpdataFormStyleManager(this.formsManiger.m_StyleManager);
        }

        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        public void UpdataFormStyleManager(MetroFramework.Components.MetroStyleManager styleManager)
        {
            this.metroStyleManager1.Style = styleManager.Style;
            this.metroStyleManager1.Theme = styleManager.Theme;

            if (formsManiger.m_isDarkMode) // Light로 변경시 진입
            {

            }
            else // Dark로 변경시 진입
            {

            }
        }

        private int GetContralSize(double number)
        {
            int size = 30;
            int incressValue = 10;

            if (number / 1000000 >= 1)
            {
                size = size + 5 * incressValue;
                //lblimageCount.Font = new Font(lblimageCountName.Font.Name, 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                //Console.WriteLine("8.25F");
            }
            else if (number / 100000 >= 1)
            {
                size = size + 4 * incressValue;
                //lblimageCount.Font = new Font(lblimageCountName.Font.Name, 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                //Console.WriteLine("9.75F");
            }
            else if (number / 10000 >= 1)
            {
                size = size + 3 * incressValue;
                //lblimageCount.Font = new Font(lblimageCountName.Font.Name, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                //Console.WriteLine("12F");
            }
            else if (number / 1000 >= 1)
            {
                size = size + 2 * incressValue;
                //lblimageCount.Font = new Font(lblimageCountName.Font.Name, 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                //Console.WriteLine("15.75F");
            }
            else if (number / 100 >= 1)
            {
                size = size + incressValue;
                //lblimageCount.Font = new Font(lblimageCountName.Font.Name, 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                //Console.WriteLine("17.25F");
            }
            else
            {
                //lblimageCount.Font = new Font(lblimageCountName.Font.Name, 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                //Console.WriteLine("24F");
            }
            return size;
        }

        private void BtnimagePageNextClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                this.lblImageListpage.Text = WorkSpaceData.m_activeProjectMainger.ImageListPageNext().ToString();
        }

        private void BtnimagePageReverseClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                this.lblImageListpage.Text = WorkSpaceData.m_activeProjectMainger.ImageListPageReverse().ToString();
        }

        private void LblImageListpageClick(object sender, EventArgs e)
        {
            MainFormsImageListPage mainFormsImageListPage = new MainFormsImageListPage();
            if (mainFormsImageListPage.ShowDialog() == DialogResult.OK)
            {
                if (WorkSpaceData.m_activeProjectMainger != null)
                    this.lblImageListpage.Text = WorkSpaceData.m_activeProjectMainger.ImageListPageManual(mainFormsImageListPage.GetPage()).ToString();
            }
        }

        private void LblImageListpageTextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(lblImageListpage.Text, out double value))
            {
                int controlSize = this.GetContralSize(value);
                this.tableLayoutImageDataManiger.ColumnStyles[2] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, (float)controlSize);
            }
        }

        private void LblImageListpageTotalTextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(lblImageListpageTotal.Text, out double value))
            {
                int controlSize = this.GetContralSize(value);
                this.tableLayoutImageDataManiger.ColumnStyles[4] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, (float)controlSize);
            }
        }
    }
}
