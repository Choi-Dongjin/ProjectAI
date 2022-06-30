using ProjectAI.ProjectManiger;
using System;
using System.IO;
using System.Windows.Forms;

namespace ProjectAI.MainForms.UserContral.ImageList
{
    public partial class GridViewImageList : UserControl
    {
        private FormsManiger formsManiger = FormsManiger.GetInstance();

        public System.Collections.ArrayList gridViewAddList = new System.Collections.ArrayList();

        private int rowInEdit = -1;
        // Declare a variable to indicate the commit scope.
        // Set this value to false to use cell-level commit scope.
        private bool rowScopeCommit = true;

        public GridViewDataIntegrity customerInEdit;
        public GridViewImageList()
        {
            InitializeComponent();
            DoubleBuffered = true;
            CustomIOMainger.CDoubleBuffered(this.gridImageList, true);
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
                    try
                    {
                        DataGridViewRow row = this.gridImageList.SelectedRows[0]; //선택된 Row 값 가져옴.
                        string data = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[0]) = name
                        WorkSpaceData.m_activeProjectMainger.CADImageForm(this.gridImageList, this.ckbMdataGridViewAutoSize, data);
                    }
                    catch { }
                }
        }

        private void CADImageMultiSelectToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                    WorkSpaceData.m_activeProjectMainger.CADImageMultiSelect(this.gridImageList, this.ckbMdataGridViewAutoSize);
        }

        private void CADImageForderWizardToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                    WorkSpaceData.m_activeProjectMainger.CADImageFolderSelect(this.gridImageList, this.ckbMdataGridViewAutoSize);
        }

        private void CkbMdataGridViewAutoSizeCheckedChanged(object sender, EventArgs e)
        {
            this.GridImageListAutoResize();
        }

        private void GridImageListResize(object sender, EventArgs e)
        {
            //this.GridImageListAutoResize();
        }

        private void GridImageListAutoResize()
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
                        mainForm.splitContainerImageAndImageList.SplitterDistance = mainForm.splitContainerImageAndImageList.Width - size - 5;
                }
                catch
                {
                }
            }
        }

        private void GridViewImageList_Resize(object sender, EventArgs e)
        {
            //this.GridImageListAutoResize();
        }

        public void Test(int num, String filesName, String set, String labeled, String prediction, double probability)
        {
            this.gridViewAddList.Add(new GridViewDataIntegrity(num, filesName, set, labeled, prediction, probability));
            foreach (var item in gridViewAddList)
                Console.WriteLine(item);
        }
  
        /// <summary>
        /// DataGridView 컨트롤의 VirtualMode 속성이 true이고, DataGridView에서 셀을 서식 지정하고 표시하기 위해 셀에 대한 값이 필요할 때 발생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridImageListCellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {

            if (e.RowIndex == this.gridImageList.RowCount - 1) return;

            GridViewDataIntegrity gridViewDataIntegrityTmp = null;

            // Store a reference to the Customer object for the row being painted.
            if (e.RowIndex == rowInEdit)
            {
                gridViewDataIntegrityTmp = this.customerInEdit;
            }
            else
            {
                gridViewDataIntegrityTmp = (GridViewDataIntegrity)this.gridViewAddList[e.RowIndex];
            }

            // Set the cell value to paint using the Customer object retrieved.
            switch (this.gridImageList.Columns[e.ColumnIndex].Name)
            {
                case "Num Name":
                    e.Value = gridViewDataIntegrityTmp.Num;
                    break;

                case "Files Name":
                    e.Value = gridViewDataIntegrityTmp.FilesName;
                    break;

                case "Set":
                    e.Value = gridViewDataIntegrityTmp.Set;
                    break;

                case "Labeled":
                    e.Value = gridViewDataIntegrityTmp.Labeled;
                    break;

                case "Prediction":
                    e.Value = gridViewDataIntegrityTmp.Prediction;
                    break;

                case "Probability":
                    e.Value = gridViewDataIntegrityTmp.Probability;
                    break;
            }
        }

        /// <summary>
        /// DataGridView 컨트롤의 VirtualMode 속성이 true이고 변경된 셀 값에 내부 데이터 원본의 스토리지가 필요할 때 발생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridImageListCellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            GridViewDataIntegrity gridViewDataIntegrityTmp = null;

            // Store a reference to the Customer object for the row being edited.
            if (e.RowIndex < this.gridViewAddList.Count)
            {
                // If the user is editing a new row, create a new Customer object.
                this.customerInEdit = new GridViewDataIntegrity(
                    ((GridViewDataIntegrity)this.gridViewAddList[e.RowIndex]).Num,
                    ((GridViewDataIntegrity)this.gridViewAddList[e.RowIndex]).FilesName,
                    ((GridViewDataIntegrity)this.gridViewAddList[e.RowIndex]).Set,
                    ((GridViewDataIntegrity)this.gridViewAddList[e.RowIndex]).Labeled,
                    ((GridViewDataIntegrity)this.gridViewAddList[e.RowIndex]).Prediction,
                    ((GridViewDataIntegrity)this.gridViewAddList[e.RowIndex]).Probability);
                gridViewDataIntegrityTmp = this.customerInEdit;
                this.rowInEdit = e.RowIndex;
            }
            else
            {
                gridViewDataIntegrityTmp = this.customerInEdit;
            }

            // Set the appropriate Customer property to the cell value entered.
            String newValue = e.Value as String;

            switch (this.gridImageList.Columns[e.ColumnIndex].Name)
            {
                case "Num Name":
                    e.Value = gridViewDataIntegrityTmp.Num;
                    break;

                case "Files Name":
                    e.Value = gridViewDataIntegrityTmp.FilesName;
                    break;

                case "Set":
                    e.Value = gridViewDataIntegrityTmp.Set;
                    break;

                case "Labeled":
                    e.Value = gridViewDataIntegrityTmp.Labeled;
                    break;

                case "Prediction":
                    e.Value = gridViewDataIntegrityTmp.Prediction;
                    break;

                case "Probability":
                    e.Value = gridViewDataIntegrityTmp.Probability;
                    break;
            }
        }

        /// <summary>
        /// VirtualMode의 DataGridView 속성이 true이고 사용자가 DataGridView의 맨 아래에 있는 새 행으로 이동하면 발생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridImageListNewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // Create a new Customer object when the user edits
            // the row for new records.
            this.customerInEdit = new GridViewDataIntegrity();
            this.rowInEdit = this.gridImageList.Rows.Count - 1;
        }

        /// <summary>
        /// 행의 유효성 검사가 완료된 후 발생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridImageListRowValidated(object sender, DataGridViewCellEventArgs e)
        {
            // Save row changes if any were made and release the edited
            // Customer object if there is one.
            if (e.RowIndex >= this.gridViewAddList.Count &&
                e.RowIndex != this.gridImageList.Rows.Count - 1)
            {
                // Add the new Customer object to the data store.
                this.gridViewAddList.Add(this.customerInEdit);
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
            else if (this.customerInEdit != null &&
                e.RowIndex < this.gridViewAddList.Count)
            {
                // Save the modified Customer object in the data store.
                this.gridViewAddList[e.RowIndex] = this.customerInEdit;
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
            else if (this.gridImageList.ContainsFocus)
            {
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
        }

        /// <summary>
        /// VirtualMode 컨트롤의 DataGridView 속성이 true이고 DataGridView가 현재 행에 커밋되지 않은 변경 내용이 있는지 여부를 확인해야 하는 경우 발생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridImageListRowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowScopeCommit)
            {
                // In cell-level commit scope, indicate whether the value
                // of the current cell has been modified.
                e.Response = this.gridImageList.IsCurrentCellDirty;
            }
        }

    }
}