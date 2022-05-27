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
using System.IO;

namespace ProjectAI.MainForms
{
    public partial class CadImageSelect : MetroForm
    {
        ProjectAI.FormsManiger formsManiger = ProjectAI.FormsManiger.GetInstance();
        public DialogResult selectDialogResult = DialogResult.None;
        int OriginNum = 0;
        int CADNum = 0;
        bool GridViewCheck = false;
        int firstOriginInputdata = -1;
        int firstCADInputdata = -1;
        Image OriginTempImage;
        Image CADTempImage;

        public string imageTempName;
        public CadImageSelect()
        {
            InitializeComponent();
            this.StyleManager = this.metroStyleManager1;
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);

        }
        public CadImageSelect(int i)
        {
            InitializeComponent();
            if (i == 1)
            {
                this.tableLayoutPanel1.ColumnStyles[1].Width = 35;
                SetupDataGridView();
            }
            ProjectAI.FormsManiger formsManiger = ProjectAI.FormsManiger.GetInstance();
            this.StyleManager = this.metroStyleManager1;
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);

        }

        /// <summary>
        /// MainForm에서 CAD image 선택하려고 할 때 또다른 Form을 생성하는데 생성된 Form을 저장하는 변수
        /// </summary>

        public string[] OriginImageName; //원본 이름
        public string[] OriginImagePath; //주소 + 이름

        public string[] CADImageName; //CAD 이름
        public string[] CADImagePath; // 주소 + 이름 

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
            this.Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.selectDialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void PictureBox1Click(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                this.OriginImageFilesSelect();
            if (this.pictureBox1.Image != null && this.pictureBox2.Image != null)
                this.btnOK.Enabled = true;
        }

        private void PictureBox2Click(object sender, EventArgs e)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                this.CADImageFilesSelect();
            if (this.pictureBox1.Image != null && this.pictureBox2.Image != null)
                this.btnOK.Enabled = true;
        }

        /// <summary>
        /// CAD 이미지와 묶일 이미지 선택
        /// </summary>
        public void OriginImageFilesSelect()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"\";
                openFileDialog.Filter = "그림 파일 (*.jpg, *.png, *.bmp) | *.jpg; *.png; *.bmp; | 모든 파일 (*.*) | *.*;";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] files = openFileDialog.SafeFileNames;
                    string[] filesPath = openFileDialog.FileNames;

                    if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                    {
                        if (WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject["string_projectListInfo"][WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["string_selectProject"].ToString() == "Classification")
                        {
                            if (WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject["string_projectListInfo"][WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["string_selectProjectInputDataType"].ToString() == "CADImage")
                            {
                               
                                if (this.pictureBox1.Image != null)
                                {
                                    this.pictureBox1.Image.Dispose();
                                    this.pictureBox1.Image = null;
                                }
                                if (this.OriginImagePath != null)
                                    this.CADImagePath = null;
                                this.OriginImageName = files;
                                this.OriginImagePath = filesPath;
                                this.imageTempName = files[0];
                                if (GridViewCheck)// Wizard
                                {
                                    this.OriginGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                    this.pictureBox1.Image = OriginTempImage;
                                    if (OriginTempImage != null)
                                        OriginTempImage.Dispose();
                                    GridInputData(true, files, filesPath);
                                }
                                else
                                    this.pictureBox1.Image = CustomIOMainger.LoadBitmap(Path.Combine(filesPath[0]));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// CAD 이미지 선택
        /// </summary>
        public void CADImageFilesSelect()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"\";
                openFileDialog.Filter = "그림 파일 (*.jpg, *.png, *.bmp) | *.jpg; *.png; *.bmp; | 모든 파일 (*.*) | *.*;";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] files = openFileDialog.SafeFileNames;
                    string[] filesPath = openFileDialog.FileNames;
                    
                    if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                    {
                        if (WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject["string_projectListInfo"][WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["string_selectProject"].ToString() == "Classification")
                        {
                            if (WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject["string_projectListInfo"][WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["string_selectProjectInputDataType"].ToString() == "CADImage")
                            {
                                if (this.pictureBox2.Image != null)
                                {
                                    this.pictureBox2.Image.Dispose();
                                    this.pictureBox2.Image = null;
                                }
                                if (this.CADImagePath != null)
                                    this.CADImagePath = null;
                                this.CADImageName = files;
                                this.CADImagePath = filesPath;
                                if (GridViewCheck) // Wizard
                                {
                                    this.CADGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                    this.pictureBox2.Image = CADTempImage;
                                    if (CADTempImage != null)
                                        CADTempImage.Dispose();
                                    GridInputData(false, files, filesPath);
                                }
                                else
                                    this.pictureBox2.Image = CustomIOMainger.LoadBitmap(Path.Combine(filesPath[0]));                              
                            }
                        }
                    }
                }
            }
        }

        private void GridInputData(bool gridCheck, string[] files, string[] filesPath)
        {
            if (gridCheck)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    bool check = true;
                    var items = this.OriginGridView.Rows.Cast<DataGridViewRow>()
                        .Where(row => row.Cells[1].Value.ToString() == files[i]);

                    foreach (DataGridViewRow row in items)
                        check = false;
                    if (check)
                    {
                        this.OriginGridView.Rows.Add(OriginNum.ToString(), files[i], Path.GetDirectoryName(filesPath[i]));
                        OriginNum++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < files.Length; i++)
                {
                    bool check = true;
                    var items = this.CADGridView.Rows.Cast<DataGridViewRow>()
                        .Where(row => row.Cells[1].Value.ToString() == files[i]);

                    foreach (DataGridViewRow row in items)
                        check = false;
                    if (check)
                    {
                        this.CADGridView.Rows.Add(CADNum.ToString(), files[i], Path.GetDirectoryName(filesPath[i]));
                        CADNum++;
                    }
                }
            }
        }

        private void SetupDataGridView()
        {
            GridViewCheck = true;
            
            //OriginGridView Setup
            this.OriginGridView.DataSource = null;
            this.OriginGridView.Columns.Clear();
            this.OriginGridView.Rows.Clear();
            this.OriginGridView.Refresh();
            this.OriginGridView.ColumnCount = 3;
            this.OriginGridView.Columns[0].Name = "No";
            this.OriginGridView.Columns[1].Name = "File Name";
            this.OriginGridView.Columns[2].Name = "File Path";
            this.OriginGridView.Columns["No"].HeaderText = "No";
            this.OriginGridView.Columns["File Name"].HeaderText = "File Name";
            this.OriginGridView.Columns["File Path"].HeaderText = "File Path";

            //CADGridView Setup
            this.CADGridView.DataSource = null;
            this.CADGridView.Columns.Clear();
            this.CADGridView.Rows.Clear();
            this.CADGridView.Refresh();
            this.CADGridView.ColumnCount = 3;
            this.CADGridView.Columns[0].Name = "No";
            this.CADGridView.Columns[1].Name = "File Name";
            this.CADGridView.Columns[2].Name = "File Path";
            this.CADGridView.Columns["No"].HeaderText = "No";
            this.CADGridView.Columns["File Name"].HeaderText = "File Name";
            this.CADGridView.Columns["File Path"].HeaderText = "File Path";
        }

        private void OriginGridViewSelectionChanged(object sender, EventArgs e)
        {
            if (this.OriginGridView.SelectedRows.Count > 0)
            {
                string ConvertName;
                DataGridViewRow row = this.OriginGridView.SelectedRows[0]; //선택된 Row 값 가져옴.
                string FileName = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[0]) = FileName
                string FilePath = row.Cells[2].Value.ToString(); // row의 컬럼(Cells[0]) = FilePath
                this.pictureBox1.Image = CustomIOMainger.LoadBitmap(Path.Combine(FilePath, FileName));
                OriginTempImage = CustomIOMainger.LoadBitmap(Path.Combine(FilePath, FileName));
                if (this.pictureBox2.Image != null)
                {
                    firstOriginInputdata++;
                    int CADRowsCount = CADGridView.Rows.Count;
                    for (int i = 0; i < CADRowsCount; i++)
                    {
                        if ((ConvertName = NameParsing(CADGridView.Rows[i].Cells[1].Value.ToString(), FileName)) != "")// 이름_CAD -> 이름_NG or 이름_OK 로 변환
                        {
                            this.pictureBox2.Image = CustomIOMainger.LoadBitmap(Path.Combine(CADGridView.Rows[i].Cells[2].Value.ToString(), ConvertName));
                            CADGridView.FirstDisplayedScrollingRowIndex = i;
                            CADGridView.Refresh();
                            CADGridView.CurrentCell = CADGridView.Rows[i].Cells[0];
                            CADGridView.Rows[i].Cells[1].Selected = true;
                            return;
                        }
                    }
                    if (firstOriginInputdata > 0)
                    {
                        firstOriginInputdata--;
                        MetroMessageBox.Show(this, "일치하는 이미지 이름이 없습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CADGridViewSelectionChanged(object sender, EventArgs e)
        {
            if (this.CADGridView.SelectedRows.Count > 0)
            {
                string ConvertName;
                DataGridViewRow row = this.CADGridView.SelectedRows[0]; //선택된 Row 값 가져옴.
                string FileName = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[0]) = FileName
                string FilePath = row.Cells[2].Value.ToString(); // row의 컬럼(Cells[0]) = FilePath
                this.pictureBox2.Image = CustomIOMainger.LoadBitmap(Path.Combine(FilePath, FileName));
                CADTempImage = CustomIOMainger.LoadBitmap(Path.Combine(FilePath, FileName));
                if (this.pictureBox1.Image != null)
                {
                    firstCADInputdata++;
                    int OriginRowsCount = OriginGridView.Rows.Count;   
                    for (int i = 0; i < OriginRowsCount; i++)
                    {
                        if ((ConvertName = NameParsing(OriginGridView.Rows[i].Cells[1].Value.ToString(), FileName)) != "")// 이름_CAD -> 이름_NG or 이름_OK 로 변환
                        {
                            this.pictureBox1.Image = CustomIOMainger.LoadBitmap(Path.Combine(OriginGridView.Rows[i].Cells[2].Value.ToString(), ConvertName));
                            OriginGridView.FirstDisplayedScrollingRowIndex = i;
                            OriginGridView.Refresh();
                            OriginGridView.CurrentCell = OriginGridView.Rows[i].Cells[0];
                            OriginGridView.Rows[i].Cells[1].Selected = true;
                            return;
                        }
                    }
                    if (firstCADInputdata > 0)
                    {
                        firstCADInputdata--;
                        MetroMessageBox.Show(this, "일치하는 이미지 이름이 없습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        /// <summary>
        /// grid에 있는 이미지이름 변환
        /// </summary>
        /// <param name="NameInGrid"></param> Grid에 있는 이름
        /// <param name="FileName"></param> 다른 Grid에 같은 이름이 있나 찾아보고 싶은 이름
        /// <returns></returns>
        public string NameParsing(string NameInGrid, string FileName)
        {
            //variable
            string result = "";
            string CmpName = "";
   
            string GridClassifyName; 

            //GridName
            string[] GridClassify = NameInGrid.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries); // 이름 | CAD, NG, OK (+ .확장자)
            int GridClassifyCount = GridClassify.Count();
            GridClassifyName = GridClassify[GridClassifyCount - 1];  // CAD, NG, OK (+ .확장자)

            string[] SplitFileName = FileName.Split(new string[] { "_", "." }, StringSplitOptions.RemoveEmptyEntries); //이름 | .jpg
            string[] SplitGridName = NameInGrid.Split(new string[] { "_", "." }, StringSplitOptions.RemoveEmptyEntries); //이름 |.jpg

            int Fcount = SplitFileName.Count();
            for (int i = 0; i < Fcount - 2; i++)                
                result += SplitFileName[i] +"_"; //이름_

            int Gcount = SplitGridName.Count();
            for (int i = 0; i < Gcount - 2; i++)
                CmpName += SplitGridName[i] + "_"; //이름_

            if (string.Compare(result, CmpName) == 0)
                return result + GridClassifyName;
            return "";
        }


        /// <summary>
        /// cell column Sort
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CADGridViewSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "No")
            {
                int a = int.Parse(e.CellValue1.ToString()), b = int.Parse(e.CellValue2.ToString());
                e.SortResult = a.CompareTo(b);
            }
            else if (e.SortResult == 0 && e.Column.Name != "No")
                e.SortResult = string.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());

            e.Handled = true;
        }

        private void OriginGridViewSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "No")
            {
                int a = int.Parse(e.CellValue1.ToString()), b = int.Parse(e.CellValue2.ToString());
                e.SortResult = a.CompareTo(b);
            }
            else if (e.SortResult == 0 && e.Column.Name != "No")
                e.SortResult = string.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());

            e.Handled = true;
        }

        private void CADGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}