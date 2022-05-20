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
using System.Drawing.Imaging;

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

        private void OverlayViewCheckedChanged(object sender, EventArgs e)
        {
            if (OverlayViewCheckBox.Checked)
            {
                if (WorkSpaceData.m_activeProjectMainger.m_imageListDictionary[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] is ProjectAI.MainForms.UserContral.ImageList.GridViewImageList gridViewImageList)
                {
                    string selectImagePath = gridViewImageList.GetSelectImageName();
                    this.CADImageLabel.BackColor = System.Drawing.Color.ForestGreen;
                    this.CADImageLabel.Text = "OverlayImage";
                    this.TrackBar.Visible = true;
                    this.TrackbarNumber.Visible = true;
                    this.tableLayoutPanel1.Visible = true;
                    this.OverlayUISetUp();
                    WorkSpaceData.m_activeProjectMainger.PrintImage(selectImagePath);
                }
            }
            else
            {
                 if (WorkSpaceData.m_activeProjectMainger.m_imageListDictionary[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] is ProjectAI.MainForms.UserContral.ImageList.GridViewImageList gridViewImageList)
                {
                    string selectImagePath = gridViewImageList.GetSelectImageName();
                    this.CADImageLabel.BackColor = System.Drawing.Color.Lime;
                    this.CADImageLabel.Text = "CADImage";
                    this.TrackBar.Visible = false;
                    this.TrackbarNumber.Visible = false;
                    this.tableLayoutPanel1.Visible = false;
                    WorkSpaceData.m_activeProjectMainger.PrintImage(selectImagePath);
                }
            }
        }

        /// <summary>
        /// 원본이미지와 CAD이미지를 Overlay한다.
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="CADImageName"></param>
        /// <param name="CADImageFolder"></param>
        public void OverlayImagePrint(string imageName, string CADImageName, string CADImageFolder)
        {
            this.imgName = imageName;
            this.CADImgName = CADImageName;
            this.CADImgFolder = CADImageFolder;
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
                this.pictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(OverlayImage);
            }
            else
                this.pictureBox2.Image = null;
        }

        public unsafe Bitmap OverlayImagePrint(Bitmap orignaBitmapImagel, Bitmap cadBitmapImage)
        {
            Console.WriteLine(orignaBitmapImagel.PixelFormat.ToString());

            //Console.WriteLine($"Format8bppIndexed: {System.Drawing.Imaging.PixelFormat.Format8bppIndexed.Equals(orignaBitmapImagel.PixelFormat)}");
            //Console.WriteLine($"Format16bppArgb1555 {System.Drawing.Imaging.PixelFormat.Format16bppArgb1555.Equals(orignaBitmapImagel.PixelFormat)}");
            //Console.WriteLine($"Format24bppRgb {System.Drawing.Imaging.PixelFormat.Format24bppRgb.Equals(orignaBitmapImagel.PixelFormat)}");
            //Console.WriteLine($"Format32bppRgb {System.Drawing.Imaging.PixelFormat.Format32bppRgb.Equals(orignaBitmapImagel.PixelFormat)}");
            //Console.WriteLine($"Format64bppArgb {System.Drawing.Imaging.PixelFormat.Format64bppArgb.Equals(orignaBitmapImagel.PixelFormat)}");
            //Console.WriteLine("");
            //Console.WriteLine($"Format8bppIndexed {System.Drawing.Imaging.PixelFormat.Format8bppIndexed.Equals(cadBitmapImage.PixelFormat)}");
            //Console.WriteLine($"Format16bppArgb1555 {System.Drawing.Imaging.PixelFormat.Format16bppArgb1555.Equals(cadBitmapImage.PixelFormat)}");
            //Console.WriteLine($"Format24bppRgb {System.Drawing.Imaging.PixelFormat.Format24bppRgb.Equals(cadBitmapImage.PixelFormat)}");
            //Console.WriteLine($"Format32bppRgb {System.Drawing.Imaging.PixelFormat.Format32bppRgb.Equals(cadBitmapImage.PixelFormat)}");
            //Console.WriteLine($"Format64bppArgb {System.Drawing.Imaging.PixelFormat.Format64bppArgb.Equals(cadBitmapImage.PixelFormat)}");

            Bitmap overlayData = new System.Drawing.Bitmap(orignaBitmapImagel.Width, orignaBitmapImagel.Height);
            BitmapData pBitmapOrigmnalData = orignaBitmapImagel.LockBits(new Rectangle(0, 0, orignaBitmapImagel.Width, orignaBitmapImagel.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData pBitmapCadImageData = cadBitmapImage.LockBits(new Rectangle(0, 0, cadBitmapImage.Width, cadBitmapImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData pBitmapOverlayImageData = overlayData.LockBits(new Rectangle(0, 0, overlayData.Width, overlayData.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            byte* ptr0 = (byte*)pBitmapOrigmnalData.Scan0;
            byte* ptr1 = (byte*)pBitmapCadImageData.Scan0;
            byte* ptr2 = (byte*)pBitmapOverlayImageData.Scan0;
            
            int iorignalStride = pBitmapOrigmnalData.Stride;
            int icadStride = pBitmapCadImageData.Stride;
            int ioverlayStride = pBitmapOverlayImageData.Stride;

            int orignalOffset = iorignalStride - orignaBitmapImagel.Width * Bitmap.GetPixelFormatSize(orignaBitmapImagel.PixelFormat) / 8;
            int cadOffset = icadStride - cadBitmapImage.Width * Bitmap.GetPixelFormatSize(cadBitmapImage.PixelFormat) / 8;
            int overlayOffset = ioverlayStride - overlayData.Width * Bitmap.GetPixelFormatSize(overlayData.PixelFormat) / 8;

            int iHeight = orignaBitmapImagel.Height;
            int iWidth = orignaBitmapImagel.Width * 3;

            for (int h = 0; h < iHeight; h++)
            {
                for (int w = 0; w < iWidth; w += 3)
                {
                    //Console.WriteLine("");
                    //Console.WriteLine($"iHeight: {h}, iWidth: {w}");
                    //Console.WriteLine("");
                    //Console.WriteLine($"orignalBlue: {orignalBlue}, cadBlue: {cadBlue}");
                    //Console.WriteLine($"orignalBlue * 0.8: {orignalBlue * 0.8}, cadBlue * 0.2: {cadBlue * 0.2}");
                    //Console.WriteLine($"(Byte)(orignalBlue * 0.8 + cadBlue * 0.2): {(Byte)(orignalBlue * 0.8 + cadBlue * 0.2)}");
                    //Console.WriteLine("");
                    //Console.WriteLine($"orignalGreen: {orignalGreen}, cadGreen: {cadGreen}");
                    //Console.WriteLine($"orignalGreen * 0.8: {orignalGreen * 0.8}, cadGreen * 0.2: {cadGreen * 0.2}");
                    //Console.WriteLine($"(Byte)(orignalGreen * 0.8 + cadGreen * 0.2): {(Byte)(orignalGreen * 0.8 + cadGreen * 0.2)}");
                    //Console.WriteLine("");
                    //Console.WriteLine($"orignalRed: {orignalRed}, cadRed: {cadRed}");
                    //Console.WriteLine($"orignalRed * 0.8: {orignalRed * 0.8}, cadRed * 0.2: {cadRed * 0.2}");
                    //Console.WriteLine($"(Byte)(orignalRed * 0.8 + cadRed * 0.2): {(Byte)(orignalRed * 0.8 + cadRed * 0.2)}");

                    byte orignalBlue = *(ptr0 + (h * iorignalStride) + w);
                    byte cadBlue = *(ptr1 + (h * icadStride)  + w);
                    *(ptr2 + (h * ioverlayStride) + w) = (Byte)(orignalBlue * 0.8 + cadBlue * 0.2);

                    byte orignalGreen = *(ptr0 + (h * iorignalStride) + 1 + w);
                    byte cadGreen = *(ptr1 + (h * icadStride) + 1 + w);
                    *(ptr2 + (h * ioverlayStride) + 1 + w) = (Byte)(orignalGreen * 0.8 + cadGreen * 0.2);

                    byte orignalRed = *(ptr0 + (h * iorignalStride) + 2 + w);
                    byte cadRed = *(ptr1 + (h * icadStride) + 2 + w);
                    *(ptr2 + (h * ioverlayStride) + 2 + w) = (Byte)(orignalRed * 0.8 + cadRed * 0.2);
                }
                //ptr0 += orignalOffset;
                //ptr1 += cadOffset;
                //ptr2 += overlayOffset;
            }

            orignaBitmapImagel.UnlockBits(pBitmapOrigmnalData);
            cadBitmapImage.UnlockBits(pBitmapCadImageData);
            overlayData.UnlockBits(pBitmapOverlayImageData);

            return overlayData;
        }

        /// <summary>
        /// 
        /// </summary>
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
