using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using System.IO;
using OpenCvSharp;
using ProjectAI.ProjectManiger;

namespace ProjectAI.MainForms.UserContral.ImageView
{
    public partial class CadImageViewer : UserControl
    {
        private Mat originImage;
        private Mat CADImage;
        private Mat OverlayImage;
        private double outputRate;
        private string imgName;
        private string CADImgName;
        private string CADImgFolder;
        public CadImageViewer()
        {
            InitializeComponent();
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            FormsManiger formsManiger = FormsManiger.GetInstance(); // 폼 메니저
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);
        }

        private void UpdataFormStyleManager(MetroStyleManager m_StyleManager)
        {
            FormsManiger formsManiger = FormsManiger.GetInstance(); // 폼 메니저
            if (formsManiger.m_isDarkMode) // Light로 변경시 진입
            {
                this.pictureBox1.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Brightness;
                this.pictureBox2.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Brightness;
            }
            else // Dark로 변경시 진입
            {
                this.pictureBox1.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Black;
                this.pictureBox2.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Black;
            }

            this.metroStyleManager1.Style = m_StyleManager.Style;
            this.metroStyleManager1.Theme = m_StyleManager.Theme;
        }

        private void OverlayView_CheckedChanged(object sender, EventArgs e)
        {
            if (OverlayViewCheckBox.Checked)
            {
                if (WorkSpaceData.m_activeProjectMainger.m_imageListDictionary[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] is ProjectAI.MainForms.UserContral.ImageList.GridViewImageList GridViewImageList)
                {
                    DataGridViewRow row = GridViewImageList.gridImageList.SelectedRows[0]; //선택된 Row 값 가져옴.
                    string data = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[0]) = name

                    this.CADImageLabel.BackColor = System.Drawing.Color.ForestGreen;
                    this.CADImageLabel.Text = "OverlayImage";
                    this.TrackBar.Visible = true;
                    this.TrackbarNumber.Visible = true;
                    this.tableLayoutPanel1.Visible = true;
                    this.OverlayUISetUp();
                    WorkSpaceData.m_activeProjectMainger.PrintImage(data);
                }
            }
            else
            {
                if (WorkSpaceData.m_activeProjectMainger.m_imageListDictionary[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] is ProjectAI.MainForms.UserContral.ImageList.GridViewImageList GridViewImageList)
                {
                    DataGridViewRow row = GridViewImageList.gridImageList.SelectedRows[0]; //선택된 Row 값 가져옴.
                    string data = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[0]) = name

                    this.CADImageLabel.BackColor = System.Drawing.Color.Lime;
                    this.CADImageLabel.Text = "CADImage";
                    this.TrackBar.Visible = false;
                    this.TrackbarNumber.Visible = false;
                    this.tableLayoutPanel1.Visible = false;
                    WorkSpaceData.m_activeProjectMainger.PrintImage(data);
                }
            }
        }

        //원본이미지와 CAD이미지를 Overlay한다.
        public void OverlayImagePrint(string imageName, string CADImageName, string CADImageFolder)
        {
            this.imgName = imageName;
            this.CADImgName = CADImageName;
            this.CADImgFolder = CADImageFolder;

            OpenCvSharp.Size pictureBox1Size = new OpenCvSharp.Size(this.pictureBox1.Size.Width, this.pictureBox1.Size.Height);

            this.originImage = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)this.pictureBox1.Image);
            this.CADImage = new Mat(pictureBox1Size, MatType.CV_8UC1);
            this.OverlayImage = new Mat(pictureBox1Size, MatType.CV_8UC3);
            if (WorkSpaceData.m_activeProjectMainger.CADImageFileCheck(CADImageName, CADImageFolder))
            {
                CADImage = Cv2.ImRead(WorkSpaceData.m_activeProjectMainger.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["CADImage"].ToString(),
                    ImreadModes.AnyDepth  | ImreadModes.Color);
                Console.WriteLine( CADImage.Channels());
                try
                {
                    Cv2.AddWeighted(originImage, 0.5, CADImage, 0.5, 0, OverlayImage);
                }
                catch (OpenCVException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                this.pictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(OverlayImage);

            }
            else
                this.pictureBox2.Image = null;
        }

        public void OverlayUISetUp()
        {
            this.outputRate = 0.01;

            this.TrackBar.Minimum = 0;
            this.TrackBar.Maximum = 100;

            this.TrackBar.Value = 50;
            this.TrackBar.SmallChange = 1;
            this.TrackBar.LargeChange = 5;
            this.TrackBar.MouseWheelBarPartitions = 100;
            this.TrackbarNumber.Text = ((double)this.TrackBar.Value * this.outputRate).ToString("0.00");

        }

        private void TrackBarValueChanged(object sender, EventArgs e)
        {
            try
            {
                double value = this.outputRate * (double)this.TrackBar.Value;
                double alpha = 1 - value;
                double beta = value;
                this.TrackbarNumber.Text = ((double)this.TrackBar.Value * this.outputRate).ToString("0.00");
                Cv2.AddWeighted(originImage, alpha, CADImage, beta, 0, OverlayImage);
                this.pictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(OverlayImage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                GC.Collect();
            }
        }
    }
}
