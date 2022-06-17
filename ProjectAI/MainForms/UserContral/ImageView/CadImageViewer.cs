using MetroFramework.Components;
using OpenCvSharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectAI.MainForms.UserContral.ImageView
{
    public partial class CadImageViewer : UserControl
    {

        private Bitmap bitmapOriginImage = null;
        private Bitmap bitmapCADImage = null;
        private double outputRate;
        public Rectangle ROI;
        private Bitmap tempPic1;
        private Bitmap tempPic2;

        //pictureBox Zoom
        private ProjectManiger.ImageToolUseingPictureBox imageToolUseingPictureBox1;

        private ProjectManiger.ImageToolUseingPictureBox imageToolUseingPictureBox2;
        private ProjectManiger.ImageToolUseingPictureBox imageToolUseingPictureBox3;
        private ProjectManiger.ImageToolUseingPictureBox imageToolUseingPictureBox4;

        public struct RectanglePaint
        {
            public bool selectingArea;
            public System.Drawing.Point startPoint;
            public System.Drawing.Point endPoint;
            public System.Drawing.Point imageMovePoint;
            public bool leftClick;
            public bool rightClick;
        }

        public RectanglePaint regionSelect1;
        public RectanglePaint regionSelect2;

        public CadImageViewer()
        {
            InitializeComponent();
            this.imageToolUseingPictureBox1 = new ProjectManiger.ImageToolUseingPictureBox(this.pictureBox1);
            this.imageToolUseingPictureBox2 = new ProjectManiger.ImageToolUseingPictureBox(this.pictureBox2);
            this.imageToolUseingPictureBox3 = new ProjectManiger.ImageToolUseingPictureBox(this.pictureBox3);
            this.imageToolUseingPictureBox4 = new ProjectManiger.ImageToolUseingPictureBox(this.pictureBox4);
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            FormsManiger formsManiger = FormsManiger.GetInstance(); // 폼 메니저
            OverlayUISetUp();

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
                this.pictureBox3.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Brightness;
                this.pictureBox4.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Brightness;
            }
            else // Dark로 변경시 진입
            {
                this.pictureBox1.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Black;
                this.pictureBox2.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Black;
                this.pictureBox3.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Black;
                this.pictureBox4.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Black;
            }

            this.metroStyleManager1.Style = m_StyleManager.Style;
            this.metroStyleManager1.Theme = m_StyleManager.Theme;
        }

        public void PrintOrignalImage(Bitmap originImage)
        {
            this.tempPic1 = originImage;
            this.bitmapOriginImage = originImage;
            //this.pictureBox1.Image = originImage;
            this.BitmapImageInput1(originImage);
        }

        public void PrintCADImage(Bitmap cadImage)
        {
            this.tempPic2 = cadImage;
            this.bitmapCADImage = cadImage;
            //this.pictureBox2.Image = cadImage;
            this.BitmapImageInput2(cadImage);
        }

        public void PrintOverlayImage()
        {
            //this.bitmapCADImage = cadImage;
            //this.pictureBox3.Image = ProjectAI.ProjectManiger.CustomImageProcess.BitmapImageOverlay24bppRgb(this.bitmapOriginImage, this.bitmapCADImage, this.TrackBar.Value * this.outputRate);
            this.BitmapImageInput3(ProjectAI.ProjectManiger.CustomImageProcess.BitmapImageOverlay24bppRgb(this.bitmapOriginImage, this.bitmapCADImage, this.TrackBar.Value * this.outputRate));
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
                if (this.bitmapCADImage != null)
                {
                    Console.WriteLine((double)this.TrackBar.Value);
                    double value = this.outputRate * (double)this.TrackBar.Value;
                    //double alpha = 1 - value;
                    //double beta = value;
                    this.TrackbarNumber.Text = ((double)this.TrackBar.Value * this.outputRate).ToString("0.00");
                    //Cv2.AddWeighted(originImage, alpha, CADImage, beta, 0, OverlayImage);
                    //this.pictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(OverlayImage);
                    this.BitmapImageInput3(ProjectAI.ProjectManiger.CustomImageProcess.BitmapImageOverlay24bppRgb(this.bitmapOriginImage, this.bitmapCADImage, value), false);
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

                this.ROI = rectangle;
                //this.image1ZoomInOut.rectangleCenterPoint = GetRectangleCenterPoint(rectangle);
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
            BitmapImageInput1(tempPic1);
        }

        public void BitmapImageInput1(Bitmap bitmap)
        {
            this.imageToolUseingPictureBox1.InputBitmapImage(bitmap);
        }

        public void BitmapImageInput2(Bitmap bitmap)
        {
            this.imageToolUseingPictureBox2.InputBitmapImage(bitmap);
        }
        public void BitmapImageInput3(Bitmap bitmap, bool b1 = true)
        {
            this.imageToolUseingPictureBox3.InputBitmapImage(bitmap, b1);
        }

        public void BitmapImageInput4(Bitmap bitmap)
        {
            this.imageToolUseingPictureBox4.InputBitmapImage(bitmap);
        }
    }
}