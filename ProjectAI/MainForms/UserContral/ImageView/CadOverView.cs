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
using OpenCvSharp;
using System.IO;

namespace ProjectAI.MainForms.UserContral.ImageView
{
    public partial class CadOverView : UserControl
    {
        private Mat originImage;
        private Mat CADImage;
        private Mat OverlayImage;
        private double outputRate;
        private string imgName;
        private string CADImgName;
        private string CADImgFolder;
        public CadOverView()
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
            }
            else // Dark로 변경시 진입
            {
                this.pictureBox1.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Black;
            }
            this.metroStyleManager1.Style = m_StyleManager.Style;
            this.metroStyleManager1.Theme = m_StyleManager.Theme;
        }

        public void OverlayImagePrint(string imageName, string CADImageName, string CADImageFolder)
        {
            this.imgName = imageName;
            this.CADImgName = CADImageName;
            this.CADImgFolder = CADImageFolder;
            this.OverlayUISetUp();
            try
            {
                this.originImage = Cv2.ImRead(Path.Combine(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectImage, imageName), ImreadModes.AnyDepth | ImreadModes.AnyColor);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            this.CADImage = new Mat(originImage.Size(), MatType.CV_8UC3);
            this.OverlayImage = new Mat(originImage.Size(), MatType.CV_8UC3);
            if (WorkSpaceData.m_activeProjectMainger.CADImageFileCheck(CADImageName, CADImageFolder))
            {
                CADImage = Cv2.ImRead(WorkSpaceData.m_activeProjectMainger.m_activeProjectDataImageListDataJObject[imageName]["Labeled"][WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["CADImage"].ToString(),
                    ImreadModes.AnyDepth | ImreadModes.AnyColor);
                try
                {
                    Cv2.AddWeighted(originImage, 0.5, CADImage, 0.5, 0, OverlayImage);
                }
                catch (OpenCVException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                this.pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(OverlayImage);
            }
            else
                this.pictureBox1.Image = null;
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
                this.pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(OverlayImage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                GC.Collect();
            }
        }
    }
}
