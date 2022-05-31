using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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

        public string GetSelectImagePath()
        {
            string imagePath = null;
            try
            {
                DataGridViewRow row = gridImageList.SelectedRows[0]; //선택된 Row 값 가져옴.
                string data = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[0]) = name

                if (data != null)
                {
                    return Path.Combine(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectImage, data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

            }
            return imagePath;
        }

        public string GetSelectImageName()
        {
            string imageName = null;
            try
            {
                DataGridViewRow row = gridImageList.SelectedRows[0]; //선택된 Row 값 가져옴.
                imageName = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[0]) = name
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

            }
            return imageName;
        }

        public void ImageTotalNumberUpdate()
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
            {
                this.lblImageListpageTotal.Text = WorkSpaceData.m_activeProjectMainger.m_activeProjectImageListJObject["int_ImageListnumber"].ToString(); 
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
                this.lblImageListpage.Text = WorkSpaceData.m_activeProjectMainger.ImageListPageNext(this.gridImageList, this.ckbMdataGridViewAutoSize).ToString();
        }

        private void BtnimagePageReverseClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                this.lblImageListpage.Text = WorkSpaceData.m_activeProjectMainger.ImageListPageReverse(this.gridImageList, this.ckbMdataGridViewAutoSize).ToString();
        }

        private void LblImageListpageClick(object sender, EventArgs e)
        {
            MainFormsImageListPage mainFormsImageListPage = new MainFormsImageListPage();
            if (mainFormsImageListPage.ShowDialog() == DialogResult.OK)
            {
                if (WorkSpaceData.m_activeProjectMainger != null)
                    this.lblImageListpage.Text = WorkSpaceData.m_activeProjectMainger.ImageListPageManual(mainFormsImageListPage.GetPage(), this.gridImageList, this.ckbMdataGridViewAutoSize).ToString();
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

        private void GridImageListSelectionChanged(object sender, EventArgs e)
        {
            if (this.gridImageList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.gridImageList.SelectedRows[0]; //선택된 Row 값 가져옴.
                string data = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[0]) = name
                WorkSpaceData.m_activeProjectMainger.PrintImage(data);
            }
        }

        private void ImageFilesAddToolStripMenuItem1Click(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                WorkSpaceData.m_activeProjectMainger.ImageFilesAdding(this.gridImageList, this.ckbMdataGridViewAutoSize);
        }


        private void ImageFilesAddWizardToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                    WorkSpaceData.m_activeProjectMainger.ImageFilesAddingWizard(this.gridImageList, this.ckbMdataGridViewAutoSize);
        }

        private void ImageFolderAddWizardToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                    WorkSpaceData.m_activeProjectMainger.ImageFolderAddingWizard(this.gridImageList, this.ckbMdataGridViewAutoSize);
        }

        private void ImageLabelingToolStripMenuItem1Click(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    WorkSpaceData.m_activeProjectMainger.ImageLabeling(this.gridImageList);
                }
        }

        private void ImageSetTrainToolStripMenuItem1Click(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    WorkSpaceData.m_activeProjectMainger.ImageTrainSet(this.gridImageList);
                }
        }

        private void ImageSetTestToolStripMenuItem1Click(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    WorkSpaceData.m_activeProjectMainger.ImageTestSet(this.gridImageList);
                }
        }

        private void ImageDeleteToolStripMenuItem1Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to delete the image?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (WorkSpaceData.m_activeProjectMainger != null)
                    WorkSpaceData.m_activeProjectMainger.ImageDel(this.gridImageList, this.ckbMdataGridViewAutoSize);
            }
        }

        private void ImageLabelInfoResetToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    WorkSpaceData.m_activeProjectMainger.ImageLabelInfoReset(this.gridImageList);
                }
        }

        private void ImageSetInfoResetToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    WorkSpaceData.m_activeProjectMainger.ImageDataSetInfoReset(this.gridImageList);
                }
        }

        //CAD 이미지를 새로 넣을 경우 CADImageForm
        private void CADImageSelectToolStripMenuItemInitImageClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                    WorkSpaceData.m_activeProjectMainger.CADInitImageForm(this.gridImageList, this.ckbMdataGridViewAutoSize);
        }

        //CAD 이미지가 들어가 있는 경우 CADImageForm
        private void CADImageSelectToolStripMenuItemCADImageClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    DataGridViewRow row = this.gridImageList.SelectedRows[0]; //선택된 Row 값 가져옴.
                    string data = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[0]) = name
                    WorkSpaceData.m_activeProjectMainger.CADImageForm(this.gridImageList, this.ckbMdataGridViewAutoSize, data);
                }
        }
        private void CADImageMultiSelectToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                    WorkSpaceData.m_activeProjectMainger.CADImageMultiSelect(this.gridImageList, this.ckbMdataGridViewAutoSize);
        }

        private void CkbMdataGridViewAutoSizeCheckedChanged(object sender, EventArgs e)
        {
            int size = 0;
            for (int i = 0; i < this.gridImageList.Columns.Count; i++)
            {
                size += this.gridImageList.Columns[i].Width;
            }
            // Data Grid View Size 조정
            if (ckbMdataGridViewAutoSize.Checked)
            {
                try
                {
                    MainForm mainForm = MainForm.GetInstance();
                    if (mainForm.splitContainerImageAndImageList.Width - size > 0)
                        mainForm.splitContainerImageAndImageList.SplitterDistance = mainForm.splitContainerImageAndImageList.Width - size;
                }
                catch
                {

                }
            }
        }

        
    }
}
