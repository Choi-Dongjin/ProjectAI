using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using MetroFramework;
using System.IO;

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectAI.MainForms
{
    public partial class CadImageSelect : MetroForm
    {
        private ProjectAI.MainForms.MainForm mainForm = ProjectAI.MainForms.MainForm.GetInstance();
        private ProjectAI.ProjectManiger.CustomIOManigerFoem customIOManigerFoem = ProjectAI.ProjectManiger.CustomIOManigerFoem.GetInstance();
        private ProjectAI.FormsManiger formsManiger = ProjectAI.FormsManiger.GetInstance();

        public DialogResult selectDialogResult = DialogResult.None;
        private int originNum = 0;
        private int CADNum = 0;
        private bool gridViewCheck = false;
        private int firstOriginInputdata = -1;
        private int firstCADInputdata = -1;
        private bool folder = false;
        public string imageTempName;

        public Task originTask;
        private Task CADTask;
        private CancellationTokenSource originCancel = null;
        private CancellationTokenSource CADCancel = null;

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
            else if (i == 2)
            {
                folder = true;
                this.tableLayoutPanel1.ColumnStyles[1].Width = 35;
                SetupDataGridView();
            }
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

        public List<string> OriginNameGridList = new List<string>(); // OriginImage 이름을 저장해놓은 list
        public List<string> OriginAddressGridList = new List<string>(); // OriginImage 주소를 저장해놓은 list

        public List<string> CADNameGridList = new List<string>(); // CADImage 이름 저장해놓은 list
        public List<string> CADAddressGridList = new List<string>(); // CADImage 주소를 저장해놓은 list

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
            if (originTask != null)
            {
                originCancel.Cancel();
            }
            if (CADTask != null)
            {
                CADCancel.Cancel();
            }
            this.DialogResult = DialogResult.Cancel;
            this.selectDialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PictureBox1Click(object sender, EventArgs e)
        {
            bool noFolder = false;
            if (WorkSpaceData.m_activeProjectMainger != null)
            {
                if (folder)
                    this.OriginImageFolderSelect();
                else
                {
                    this.OriginImageFilesSelect();
                    noFolder = true;
                }
            }
            if ((this.pictureBox1.Image != null && this.pictureBox2.Image != null) && noFolder)
                this.btnOK.Enabled = true;
        }

        private void PictureBox2Click(object sender, EventArgs e)
        {
            bool noFolder = false;
            if (WorkSpaceData.m_activeProjectMainger != null)
            {
                if (folder)
                    this.CADImageFolderSelect();
                else
                {
                    this.CADImageFilesSelect();
                    noFolder = true;
                }
            }
            if ((this.pictureBox1.Image != null && this.pictureBox2.Image != null) && noFolder)
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
                openFileDialog.RestoreDirectory = true;
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
                                if (gridViewCheck)// Wizard
                                {
                                    int index = 0;
                                    this.OriginGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                    this.pictureBox1.Image = CustomIOMainger.LoadBitmap(Path.Combine(filesPath[0]));

                                    #region GridView에 데이터 Add와 최신 데이터파일로 cell 이동

                                    int beforeOriginRowsCount = OriginGridView.Rows.Count;
                                    GridInputData(true, files, filesPath, beforeOriginRowsCount, -1); // GridView에 데이터 Add

                                    #endregion GridView에 데이터 Add와 최신 데이터파일로 cell 이동
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
        /// CAD 이미지와 묶일 이미지가 들어있는 폴더 선택
        /// </summary>
        public void OriginImageFolderSelect()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"\";
                openFileDialog.Filter = "그림 파일 (*.jpg, *.png, *.bmp) | *.jpg; *.png; *.bmp; | 모든 파일 (*.*) | *.*;";
                openFileDialog.ValidateNames = false;
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Multiselect = true; // 파일 다중 선택
                openFileDialog.FileName = "Folder Selection.";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] files = CustomIOMainger.DirFileSerch(System.IO.Path.GetDirectoryName(openFileDialog.FileName), "Name").ToArray();
                    string[] filesPath = CustomIOMainger.DirFileSerch(System.IO.Path.GetDirectoryName(openFileDialog.FileName), "Full").ToArray();

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
                                if (gridViewCheck)// Wizard
                                {
                                    this.OriginGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                    this.pictureBox1.Image = CustomIOMainger.LoadBitmap(Path.Combine(filesPath[0]));

                                    #region GridView에 데이터 Add와 최신 데이터파일로 cell 이동

                                    int beforeOriginRowsCount = OriginGridView.Rows.Count;
                                    GridInputData(true, files, filesPath, beforeOriginRowsCount, -1); // GridView에 데이터 Add

                                    #endregion GridView에 데이터 Add와 최신 데이터파일로 cell 이동
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
                                if (gridViewCheck) // Wizard
                                {
                                    this.CADGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                    this.pictureBox2.Image = CustomIOMainger.LoadBitmap(Path.Combine(filesPath[0]));

                                    #region GridView에 데이터 추가, 최신 데이터파일로 cell 이동

                                    int beforeCADRowsCount = CADGridView.Rows.Count;
                                    GridInputData(false, files, filesPath, -1, beforeCADRowsCount); // GridView에 데이터 추가

                                    #endregion GridView에 데이터 추가, 최신 데이터파일로 cell 이동
                                }
                                else
                                    this.pictureBox2.Image = CustomIOMainger.LoadBitmap(Path.Combine(filesPath[0]));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// CAD 이미지 폴더 선택
        /// </summary>
        public void CADImageFolderSelect()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"\";
                openFileDialog.Filter = "그림 파일 (*.jpg, *.png, *.bmp) | *.jpg; *.png; *.bmp; | 모든 파일 (*.*) | *.*;";
                openFileDialog.ValidateNames = false;
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Multiselect = true; // 파일 다중 선택
                openFileDialog.FileName = "Folder Selection.";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] files = CustomIOMainger.DirFileSerch(System.IO.Path.GetDirectoryName(openFileDialog.FileName), "Name").ToArray();
                    string[] filesPath = CustomIOMainger.DirFileSerch(System.IO.Path.GetDirectoryName(openFileDialog.FileName), "Full").ToArray();

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
                                if (gridViewCheck) // Wizard
                                {
                                    this.CADGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                    this.pictureBox2.Image = CustomIOMainger.LoadBitmap(Path.Combine(filesPath[0]));

                                    #region GridView에 데이터 추가, 최신 데이터파일로 cell 이동

                                    int beforeCADRowsCount = CADGridView.Rows.Count;
                                    GridInputData(false, files, filesPath, -1, beforeCADRowsCount); // GridView에 데이터 추가
                                    //Console.Write("CADTask.IsCompleted");
                                    //Console.WriteLine(CADTask.IsCompleted);

                                    #endregion GridView에 데이터 추가, 최신 데이터파일로 cell 이동
                                }
                                else
                                    this.pictureBox2.Image = CustomIOMainger.LoadBitmap(Path.Combine(filesPath[0]));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// GridView에 데이터 Add
        /// </summary>
        /// <param name="gridCheck"></param> Origin인지 CAD인지 판별
        /// <param name="files"></param> 파일 이름
        /// <param name="filesPath"></param> 파일의 전체경로
        private async void GridInputData(bool gridCheck, string[] files, string[] filesPath, int beforeOriginRowsCount, int beforeCADRowsCount)
        {
            if (gridCheck) //OriginImage
            {
                try
                {
                    originCancel = new CancellationTokenSource();
                    CancellationToken token = originCancel.Token;

                    originTask = Task.Run(() => OriginimageInput(files, filesPath, token), token);
                    await originTask;
                    //OriginPanelstatus.Visible = false;

                    int index = 0;
                    int afterOriginRowsCount = OriginGridView.Rows.Count;
                    if (beforeOriginRowsCount == afterOriginRowsCount)
                        index = beforeOriginRowsCount - 1;
                    else
                        index = beforeOriginRowsCount;
                    OriginGridView.FirstDisplayedScrollingRowIndex = index;
                    OriginGridView.Refresh();
                    OriginGridView.CurrentCell = OriginGridView.Rows[index].Cells[0];
                    OriginGridView.Rows[index].Cells[1].Selected = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else //CADImage
            {
                try
                {
                    CADCancel = new CancellationTokenSource();
                    CancellationToken token = CADCancel.Token;
                    CADTask = Task.Run(() => CADimageInput(files, filesPath, token), token);
                    await CADTask;

                    //CADPanelstatus.Visible = false;

                    int index = 0;
                    int afterCADRowsCount = CADGridView.Rows.Count;
                    if (afterCADRowsCount == beforeCADRowsCount)
                        index = beforeCADRowsCount - 1;
                    else
                        index = beforeCADRowsCount;
                    CADGridView.FirstDisplayedScrollingRowIndex = index;
                    CADGridView.Refresh();
                    CADGridView.CurrentCell = CADGridView.Rows[index].Cells[0];
                    CADGridView.Rows[index].Cells[1].Selected = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void OriginimageInput(string[] files, string[] filesPath, CancellationToken token)
        {
            int totalFileNumber = files.Count();
            int workInNumber = 1;
            for (int i = 0; i < files.Length; i++)
            {
                token.ThrowIfCancellationRequested();
                bool check = true;
                var items = this.OriginGridView.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == files[i]);

                foreach (DataGridViewRow row in items)
                    check = false;
                if (check)
                {
                    this.Invoke(new Action(delegate ()
                    {
                        this.OriginGridView.Rows.Add(originNum.ToString(), files[i], Path.GetDirectoryName(filesPath[i]));
                    }));
                    if (!mainForm.SafeVisiblePanel(this.OriginPanelstatus))
                        mainForm.SafeVisiblePanel(this.OriginPanelstatus, true);
                    mainForm.SafeWriteProgressBar(OriginpgbMfileIOstatus, totalFileNumber, workInNumber);
                    mainForm.SafeWriteLabelText(OriginlblMworkInNumber, workInNumber.ToString());
                    mainForm.SafeWriteLabelText(OriginlblMtotalNumber, totalFileNumber.ToString());
                    mainForm.SafeWriteLabelText(OriginlblMIOStatus, "Input");
                    mainForm.SafeWriteLabelText(OriginlblMworkInFileName, Path.GetFileName(files[i]));
                    OriginNameGridList.Add(files[i]);
                    OriginAddressGridList.Add(filesPath[i]);
                    workInNumber++;
                    originNum++;
                }
            }
            mainForm.SafeWriteLabelText(OriginlblMIOStatus, "Completed");
            mainForm.SafeVisiblePanel(this.OriginPanelstatus, false);
        }

        private void CADimageInput(string[] files, string[] filesPath, CancellationToken token)
        {
            int totalFileNumber = files.Count();
            int workInNumber = 1;

            for (int i = 0; i < files.Length; i++)
            {
                token.ThrowIfCancellationRequested();
                bool check = true;
                var items = this.CADGridView.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[1].Value.ToString() == files[i]);

                foreach (DataGridViewRow row in items)
                    check = false;
                if (check)
                {
                    this.Invoke(new Action(delegate ()
                    {
                        this.CADGridView.Rows.Add(CADNum.ToString(), files[i], Path.GetDirectoryName(filesPath[i]));
                    }));
                    if (!mainForm.SafeVisiblePanel(this.CADPanelstatus))
                        mainForm.SafeVisiblePanel(this.CADPanelstatus, true);
                    mainForm.SafeWriteProgressBar(CADpgbMfileIOstatus, totalFileNumber, workInNumber);
                    mainForm.SafeWriteLabelText(CADlblMworkInNumber, workInNumber.ToString());
                    mainForm.SafeWriteLabelText(CADlblMtotalNumber, totalFileNumber.ToString());
                    mainForm.SafeWriteLabelText(CADlblMIOStatus, "Input");
                    mainForm.SafeWriteLabelText(CADlblMworkInFileName, Path.GetFileName(files[i]));
                    CADNameGridList.Add(files[i]);
                    CADAddressGridList.Add(filesPath[i]);
                    workInNumber++;
                    CADNum++;
                }
            }
            mainForm.SafeWriteLabelText(CADlblMIOStatus, "Completed");
            mainForm.SafeVisiblePanel(this.CADPanelstatus, false);
        }

        private void SetupDataGridView()
        {
            gridViewCheck = true;

            //OriginGridView Setup
            this.OriginGridView.ColumnCount = 3;
            this.OriginGridView.Columns[0].Name = "No";
            this.OriginGridView.Columns[1].Name = "File Name";
            this.OriginGridView.Columns[2].Name = "File Path";
            this.OriginGridView.Columns["No"].HeaderText = "No";
            this.OriginGridView.Columns["File Name"].HeaderText = "File Name";
            this.OriginGridView.Columns["File Path"].HeaderText = "File Path";

            //CADGridView Setup
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
                string FileName = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[1]) = FileName
                string FilePath = row.Cells[2].Value.ToString(); // row의 컬럼(Cells[2]) = FilePath
                this.pictureBox1.Image = CustomIOMainger.LoadBitmap(Path.Combine(FilePath, FileName));
                //OriginTempImage = CustomIOMainger.LoadBitmap(Path.Combine(FilePath, FileName));
                if (this.pictureBox2.Image != null)
                {
                    firstOriginInputdata++;
                    int CADRowsCount = CADGridView.Rows.Count;

                    for (int i = 0; i < CADRowsCount; i++)
                    {
                        if ((ConvertName = NameParsing(CADGridView.Rows[i].Cells[1].Value.ToString(), FileName)) != "")// 이름_CAD -> 이름_NG or 이름_OK 로 변환
                        {
                            this.pictureBox2.Image = CustomIOMainger.LoadBitmap(Path.Combine(CADGridView.Rows[i].Cells[2].Value.ToString(), ConvertName));
                            // 다른 GridView에서 같은 이름인 cell을 찾아 선택
                            CADGridView.Refresh();
                            CADGridView.CurrentCell = CADGridView.Rows[i].Cells[0];
                            CADGridView.Rows[i].Cells[0].Selected = true;
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
                //CADTempImage = CustomIOMainger.LoadBitmap(Path.Combine(FilePath, FileName));
                if (this.pictureBox1.Image != null)
                {
                    firstCADInputdata++;
                    int OriginRowsCount = OriginGridView.Rows.Count;
                    for (int i = 0; i < OriginRowsCount; i++)
                    {
                        if ((ConvertName = NameParsing(OriginGridView.Rows[i].Cells[1].Value.ToString(), FileName)) != "")// 이름_CAD -> 이름_NG or 이름_OK 로 변환
                        {
                            this.pictureBox1.Image = CustomIOMainger.LoadBitmap(Path.Combine(OriginGridView.Rows[i].Cells[2].Value.ToString(), ConvertName));
                            // 다른 GridView에서 같은 이름인 cell을 찾아 선택
                            OriginGridView.Refresh();
                            OriginGridView.CurrentCell = OriginGridView.Rows[i].Cells[0];
                            OriginGridView.Rows[i].Cells[0].Selected = true;
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
                result += SplitFileName[i] + "_"; //이름_

            int Gcount = SplitGridName.Count();
            for (int i = 0; i < Gcount - 2; i++)
                CmpName += SplitGridName[i] + "_"; //이름_

            if (string.Compare(result, CmpName) == 0)
                return result + GridClassifyName;
            return "";
        }

        public string NameUnderbarParsing(string FileName)
        {
            //#34 __일 때 문제 있음
            //variable
            string result = "";
            string[] SplitFileName = FileName.Split(new string[] { "_", "." }, StringSplitOptions.RemoveEmptyEntries); //이름 | .jpg

            int Fcount = SplitFileName.Count();
            for (int i = 0; i < Fcount - 2; i++)
                result += SplitFileName[i] + "_"; //이름_
            return result;
        }

        public int NameParsingCompare(string NameInGrid, string FileName)
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
                result += SplitFileName[i] + "_"; //이름_  Target

            int Gcount = SplitGridName.Count();
            for (int i = 0; i < Gcount - 2; i++)
                CmpName += SplitGridName[i] + "_"; //이름_  circuit

            return (string.Compare(result, CmpName));
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

        private void OriginlblMIOStatusTextChanged(object sender, EventArgs e)
        {
            if ((OriginlblMIOStatus.Text == "Completed") && (CADlblMIOStatus.Text == "Completed"))
                this.btnOK.Enabled = true;
        }

        private void CADlblMIOStatusTextChanged(object sender, EventArgs e)
        {
            if ((OriginlblMIOStatus.Text == "Completed") && (CADlblMIOStatus.Text == "Completed"))
                this.btnOK.Enabled = true;
            if (OriginlblMIOStatus.Text == "AllCompleted")
            {
                this.Close();
            }
        }
    }
}