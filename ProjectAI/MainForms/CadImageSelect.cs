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
        public DialogResult selectDialogResult = DialogResult.None;

        public CadImageSelect()
        {
            InitializeComponent();
            ProjectAI.FormsManiger formsManiger = ProjectAI.FormsManiger.GetInstance();
            this.StyleManager = this.metroStyleManager1;
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);

        }


        /// <summary>
        /// MainForm에서 CAD image 선택하려고 할 때 또다른 Form을 생성하는데 생성된 Form을 저장하는 변수
        /// </summary>

        public string OriginImageName; //원본 이름

        public string CADImageName; //CAD 이름

        public string[] OriginImagePath; //주소 + 이름

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

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] files = openFileDialog.SafeFileNames;
                    string[] filesPath = openFileDialog.FileNames;
                    string imageName = files[0];

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
                                this.OriginImageName = imageName;
                                this.OriginImagePath = filesPath;
                                this.pictureBox1.Image = CustomIOMainger.LoadBitmap(filesPath[0]);
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

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] files = openFileDialog.SafeFileNames;
                    string[] filesPath = openFileDialog.FileNames;
                    string imageName = files[0];

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
                                this.CADImageName = imageName;
                                this.CADImagePath = filesPath;
                                this.pictureBox2.Image = CustomIOMainger.LoadBitmap(filesPath[0]);
                            }
                        }
                    }
                }
            }
        }
    }
}