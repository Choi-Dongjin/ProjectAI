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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ProjectAI.MainForms.UserContral.ImageView
{
    public partial class CadImageViewer : UserControl
    {
        private Mat originImage;
        private Mat CADImage;
        private Mat OverlayImage;
        private Bitmap BitmapOriginImage = null;
        private Bitmap BitmapCADImage = null;
        private double outputRate;
        private string imgName;
        private string CADImgName;
        private string CADImgFolder;

        private Bitmap tempPic1;
        private Bitmap tempPic2;

        public struct ImageZoomInOut
        {

            public System.Drawing.Point mouseMovePoint;
            public System.Drawing.Point rectangleCenterPoint;
            public Rectangle ROI;
        }

        public struct RectanglePaint
        {
            public bool selectingArea;
            public System.Drawing.Point startPoint;
            public System.Drawing.Point endPoint;
            public System.Drawing.Point imageMovePoint;
            public bool leftClick;
            public bool rightClick;
        }

        public struct RectSize
        {
            public System.Drawing.Point pos;
            public int Width; 
            public int Height;
        }

        public ImageZoomInOut image1ZoomInOut;
        public ImageZoomInOut image2ZoomInOut;

        public RectanglePaint regionSelect1;
        public RectanglePaint regionSelect2;

        public CadImageViewer()
        {
            InitializeComponent();
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            FormsManiger formsManiger = FormsManiger.GetInstance(); // 폼 메니저
            OverlayUISetUp();
            pictureBox1.MouseWheel += new MouseEventHandler(PictureBox1MouseWheel);
            //pictureBox2.MouseWheel += new MouseEventHandler(PictureBox2MouseWheel);
  
            SetRectangle(regionSelect1);
            SetRectangle(regionSelect2);
        }



        private void SetRectangle(RectanglePaint regionSelect)
        {
            regionSelect.selectingArea = false;
            regionSelect.leftClick = false;
            regionSelect.rightClick = false;
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

        public void PrintOrignalImage(Bitmap originImage)
        {
            this.tempPic1 = originImage;
            this.BitmapOriginImage = originImage;
            this.pictureBox1.Image = originImage;
        }

        public void PrintCADImage(Bitmap cadImage)
        {
            this.tempPic2 = cadImage;
            this.BitmapCADImage = cadImage;
            this.pictureBox2.Image = cadImage;
        }

        public void PrintOverlayImage(Bitmap cadImage)
        {
            this.BitmapCADImage = cadImage;
            this.pictureBox3.Image = ProjectAI.ProjectManiger.CustomImageProcess.BitmapImageOverlay24bppRgb(this.BitmapOriginImage, this.BitmapCADImage, this.TrackBar.Value * this.outputRate);
            
        }

        private void PictureBox1MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta * SystemInformation.MouseWheelScrollLines / 120 > 0)
            {

            }
            else
            {
            }
        }

        private void PictureBox2MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta * SystemInformation.MouseWheelScrollLines / 120 > 0)
            {

            }
            else
            {
            }
        }


        /// <summary>
        /// 사각형 구하기
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        private Rectangle GetRectangle(System.Drawing.Point point1, System.Drawing.Point point2)
        {
            int x = Math.Min(point1.X, point2.X);
            int y = Math.Min(point1.Y, point2.Y);

            int width = Math.Abs(point1.X - point2.X);
            int height = Math.Abs(point1.Y - point2.Y);

            return new Rectangle(x, y, width, height);
        }

        private System.Drawing.Point GetRectangleCenterPoint(Rectangle region)
        {
            System.Drawing.Point centerPoint = new System.Drawing.Point((region.X + region.Width / 2), (region.Y + region.Height / 2));
            return centerPoint;
        }


        # region 예전코드
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
                    double value = this.outputRate * (double)this.TrackBar.Value;
                    double alpha = 1 - value;
                    double beta = value;
                    Cv2.AddWeighted(originImage, alpha, CADImage, beta, 0, OverlayImage);
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
        #endregion

        /// <summary>
        /// TrackBar Setting
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
                if (this.BitmapCADImage != null)
                {
                    Console.WriteLine((double)this.TrackBar.Value);
                    double value = this.outputRate * (double)this.TrackBar.Value;
                    //double alpha = 1 - value;
                    //double beta = value;
                    this.TrackbarNumber.Text = ((double)this.TrackBar.Value * this.outputRate).ToString("0.00");
                    //Cv2.AddWeighted(originImage, alpha, CADImage, beta, 0, OverlayImage);
                    //this.pictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(OverlayImage);
                    this.pictureBox3.Image = ProjectAI.ProjectManiger.CustomImageProcess.BitmapImageOverlay24bppRgb(this.BitmapOriginImage, this.BitmapCADImage, value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                GC.Collect();
            }
        }


        /// <summary>
        /// 마우스 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.regionSelect1.selectingArea = true;
                this.regionSelect1.leftClick = true;
                this.regionSelect1.startPoint = e.Location;
                this.regionSelect1.endPoint = e.Location;

                this.pictureBox1.Cursor = Cursors.Cross;
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.regionSelect1.rightClick = true;
                this.pictureBox1.Cursor = Cursors.Hand;
            }
            this.pictureBox1.Refresh();

        }


        /// <summary>
        /// 마우스 이동
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1MouseMove(object sender, MouseEventArgs e)
        {
            this.image1ZoomInOut.mouseMovePoint = e.Location;
            if (this.regionSelect1.leftClick)
                this.regionSelect1.endPoint = e.Location;
            this.pictureBox1.Refresh();

        }

        /// <summary>
        /// 마우스 클릭을 땠을 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.regionSelect1.selectingArea = false;
                this.regionSelect1.leftClick = false;
                
                Rectangle rectangle = GetRectangle(regionSelect1.startPoint, regionSelect1.endPoint);
 
                this.image1ZoomInOut.ROI = rectangle;
                //this.image1ZoomInOut.rectangleCenterPoint = GetRectangleCenterPoint(rectangle);
                //this.pictureBox1.Image = ProjectAI.ProjectManiger.CustomImageProcess.CropImage(this.pictureBox1.Image, image1ZoomInOut.ROI); //Crop버튼을 클릭했을 때 if문으로 활성화
            }
            this.pictureBox1.Cursor = Cursors.Default;
        }

        private void PictureBox1Paint(object sender, PaintEventArgs e)
        {
            if (this.regionSelect1.selectingArea)
            {
                using (Pen pen = new Pen(Color.GreenYellow, 2))
                {
                    e.Graphics.DrawRectangle(pen, GetRectangle(regionSelect1.startPoint, regionSelect1.endPoint));

                    pen.Color = Color.Green;
                    pen.DashPattern = new float[] { 5, 5 };

                    e.Graphics.DrawRectangle(pen, GetRectangle(regionSelect1.startPoint, regionSelect1.endPoint));
                }
            }
        }

        private void PictureBox1MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.pictureBox1.Image = tempPic1;
        }
    }
}
