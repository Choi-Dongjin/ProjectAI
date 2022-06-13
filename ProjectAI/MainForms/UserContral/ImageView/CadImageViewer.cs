﻿using System;
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
            public double dInitialScale;
            public double dNewScale;
            public double dScaleRatio;
            public double dCompensationX;
            public double dCompensationY;
            public int iScaleTimes;
            public int iMaxScaleTimes;
            public int iMinScaleTimes;

            public int iOrgW;
            public int iOrgH;
            public System.Drawing.Point mouseMovePoint;
            public System.Drawing.Point ptRButtonDown;
            public System.Drawing.Point rectangleCenterPoint;
            public Rectangle ROI;

            public int iHorzScrollBarPos;
            public int iVertScrollBarPos;
            public int iHorzScrollBarPos_copy;
            public int iVertScrollBarPos_copy;

            public int iHorzScrollBarRange_Min;
            public int iHorzScrollBarRange_Max;
            public int iVertScrollBarRange_Min;
            public int iVertScrollBarRange_Max;
            public RectSize size;


            //3차 회선 보간법
            public double p1;
            double p2;
            double p3;
            double p4;
            double v;

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
            pictureBox1.MouseWheel += new MouseEventHandler(PictureBox1MouseWheel);
            //pictureBox2.MouseWheel += new MouseEventHandler(PictureBox2MouseWheel);
            SetImageZoomInout(ref image1ZoomInOut);
            SetImageZoomInout(ref image2ZoomInOut);
            SetRectangle(regionSelect1);
            SetRectangle(regionSelect2);
        }

        public void SetImageZoomInout(ref ImageZoomInOut imageZoomInOut)
        {
            imageZoomInOut.iScaleTimes = 0;
            imageZoomInOut.iMaxScaleTimes = 10;
            imageZoomInOut.iMinScaleTimes = 0;
            imageZoomInOut.dCompensationX = 0;
            imageZoomInOut.dCompensationY = 0;
            imageZoomInOut.dInitialScale = 1;
            imageZoomInOut.dNewScale = 1;
            imageZoomInOut.dScaleRatio = 1.25;

            imageZoomInOut.iOrgW = 0;
            imageZoomInOut.iOrgH = 0;

            imageZoomInOut.iHorzScrollBarPos = 0;
            imageZoomInOut.iVertScrollBarPos = 0;

            imageZoomInOut.iHorzScrollBarRange_Min = 0;
            imageZoomInOut.iHorzScrollBarRange_Max = 1;
            imageZoomInOut.iVertScrollBarRange_Min = 0;
            imageZoomInOut.iVertScrollBarRange_Max = 1;

            SetInitScale(ref imageZoomInOut, 0.8);

        }

        private void SetRectangle(RectanglePaint regionSelect)
        {
            regionSelect.selectingArea = false;
            regionSelect.leftClick = false;
            regionSelect.rightClick = false;
        }

        public void SetInitScale(ref ImageZoomInOut imageZoomInOut, double dScale)
        {
            if (dScale <= 0)
                return;

            imageZoomInOut.dInitialScale = dScale;
            imageZoomInOut.dNewScale = dScale;
        }

        //public static Bitmap ResizeImage(Image image, ImageZoomInOut imageZoomInOut)
        //{
        //    var destRect = new Rectangle(imageZoomInOut.size.pos.X, imageZoomInOut.size.pos.Y, imageZoomInOut.size.Width, imageZoomInOut.size.Height);
        //    var destImage = new Bitmap(image.Width, image.Height);


        //    destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        //    using (Graphics graphics = Graphics.FromImage(destImage))
        //    {
        //        graphics.CompositingMode = CompositingMode.SourceCopy;
        //        graphics.CompositingQuality = CompositingQuality.HighQuality;
        //        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        graphics.SmoothingMode = SmoothingMode.HighQuality;
        //        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        //        using (var wrapMode = new ImageAttributes())
        //        {
        //            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
        //            graphics.DrawImage(image, destRect, 0, 0, imageZoomInOut.size.Width, imageZoomInOut.size.Height, GraphicsUnit.Pixel, wrapMode);
        //        }
        //    }
        //    return destImage;
        //}

        public  Bitmap ResizeImage(Image image, ImageZoomInOut imageZoomInOut)
        {
            var destRect = imageZoomInOut.ROI;
            var destImage = new Bitmap(image.Width, image.Height);


            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    int pointX = this.pictureBox1.Width / 2 + destRect.Width / 2;
                    int pointY = this.pictureBox1.Height / 2 + destRect.Height / 2;

                    graphics.DrawImage(image, destRect, pointX, pointY, destRect.Width, destRect.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }


        //public static Bitmap Zoompicture(Image image, ImageZoomInOut imageZoomInOut)
        //{
        //    var destRect = new Rectangle(imageZoomInOut.size.pos.X, imageZoomInOut.size.pos.Y, imageZoomInOut.size.Width, imageZoomInOut.size.Height);
        //    Bitmap bm = new Bitmap(image, imageZoomInOut.size.Width, imageZoomInOut.size.Height);
        //    bm.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        //    Graphics gpu = Graphics.FromImage(bm);
        //    gpu.CompositingMode = CompositingMode.SourceCopy;
        //    gpu.CompositingQuality = CompositingQuality.HighQuality;
        //    gpu.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //    gpu.SmoothingMode = SmoothingMode.HighQuality;
        //    gpu.PixelOffsetMode = PixelOffsetMode.HighQuality;
        //    return bm;
        //}




        //private void PictureBox1MouseWheel(object sender, MouseEventArgs e)
        //{
        //    this.pictureBox1.Image = tempPic1;
        //    if ((e.Delta * SystemInformation.MouseWheelScrollLines / 120 > 0) && (image1ZoomInOut.iScaleTimes != image1ZoomInOut.iMaxScaleTimes))
        //        image1ZoomInOut.iScaleTimes++;
        //    else if ((e.Delta * SystemInformation.MouseWheelScrollLines / 120 < 0) && (image1ZoomInOut.iScaleTimes != image1ZoomInOut.iMinScaleTimes))
        //        image1ZoomInOut.iScaleTimes--;

        //    if (image1ZoomInOut.iScaleTimes == 0)
        //        image1ZoomInOut.dCompensationX = image1ZoomInOut.dCompensationY = 0;
        //    Console.Write("image1ZoomInOut.iScaleTimes: ");
        //    Console.WriteLine(image1ZoomInOut.iScaleTimes);
        //    image1ZoomInOut.iOrgW = this.pictureBox1.Width;
        //    image1ZoomInOut.iOrgH = this.pictureBox1.Height;
        //    ProjectAI.ProjectManiger.CustomImageProcess.ImageZoom(ref image1ZoomInOut);
        //    image1ZoomInOut.size.pos = new System.Drawing.Point(image1ZoomInOut.iHorzScrollBarPos, image1ZoomInOut.iVertScrollBarPos);
        //    image1ZoomInOut.size.Width = (int)(this.pictureBox1.Image.Width * image1ZoomInOut.dNewScale);
        //    image1ZoomInOut.size.Height = (int)(this.pictureBox1.Image.Height * image1ZoomInOut.dNewScale);
        //    Console.WriteLine(image1ZoomInOut.size.pos.X);
        //    Console.WriteLine(image1ZoomInOut.size.pos.Y);
        //    if (image1ZoomInOut.iScaleTimes > 0)
        //        this.pictureBox1.Image = Zoompicture(this.pictureBox1.Image, image1ZoomInOut);
        //    else if (image1ZoomInOut.iScaleTimes <= 0)
        //        this.pictureBox1.Image = tempPic1;
        //}

        //private void PictureBox2MouseWheel(object sender, MouseEventArgs e)
        //{
        //    if (e.Delta * SystemInformation.MouseWheelScrollLines / 120 > 0)
        //    {
        //        WorkSpaceData.m_activeProjectMainger.ZoomIn(this.pictureBox2, image2ZoomInOut);

        //    }
        //    else
        //    {
        //        WorkSpaceData.m_activeProjectMainger.ZoomOut(this.pictureBox2, image2ZoomInOut);
        //    }
        //}

        private void PictureBox1MouseWheel(object sender, MouseEventArgs e)
        {
            this.pictureBox1.Image = tempPic1;
            if ((e.Delta * SystemInformation.MouseWheelScrollLines / 120 > 0) && (image1ZoomInOut.iScaleTimes != image1ZoomInOut.iMaxScaleTimes))
                image1ZoomInOut.iScaleTimes++;
            else if ((e.Delta * SystemInformation.MouseWheelScrollLines / 120 < 0) && (image1ZoomInOut.iScaleTimes != image1ZoomInOut.iMinScaleTimes))
                image1ZoomInOut.iScaleTimes--;

            if (image1ZoomInOut.iScaleTimes == 0)
                image1ZoomInOut.dCompensationX = image1ZoomInOut.dCompensationY = 0;
            Console.Write("image1ZoomInOut.iScaleTimes: ");
            Console.WriteLine(image1ZoomInOut.iScaleTimes);
            image1ZoomInOut.iOrgW = this.pictureBox1.Width;
            image1ZoomInOut.iOrgH = this.pictureBox1.Height;
            ProjectAI.ProjectManiger.CustomImageProcess.ImageZoom(ref image1ZoomInOut);
            image1ZoomInOut.size.pos = new System.Drawing.Point(image1ZoomInOut.iHorzScrollBarPos, image1ZoomInOut.iVertScrollBarPos);
            image1ZoomInOut.size.Width = (int)(this.pictureBox1.Image.Width * image1ZoomInOut.dNewScale);
            image1ZoomInOut.size.Height = (int)(this.pictureBox1.Image.Height * image1ZoomInOut.dNewScale);
            Console.WriteLine(image1ZoomInOut.size.pos.X);
            Console.WriteLine(image1ZoomInOut.size.pos.Y);
            if (image1ZoomInOut.iScaleTimes > 0)
                this.pictureBox1.Image = Zoompicture(this.pictureBox1.Image, image1ZoomInOut);
            else if (image1ZoomInOut.iScaleTimes <= 0)
                this.pictureBox1.Image = tempPic1;
        }

        public static Bitmap Zoompicture(Image image, ImageZoomInOut imageZoomInOut)
        {
            var destRect = new Rectangle(imageZoomInOut.size.pos.X, imageZoomInOut.size.pos.Y, imageZoomInOut.size.Width, imageZoomInOut.size.Height);
            Bitmap bm = ProjectAI.ProjectManiger.CustomImageProcess.ResizeCubic(image, imageZoomInOut.size.Width, imageZoomInOut.size.Height);
 
             Graphics gpu = Graphics.FromImage(bm);
            gpu.CompositingMode = CompositingMode.SourceCopy;
            gpu.CompositingQuality = CompositingQuality.HighQuality;
            gpu.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gpu.SmoothingMode = SmoothingMode.HighQuality;
            gpu.PixelOffsetMode = PixelOffsetMode.HighQuality;
            return bm;
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
            this.tempPic2 = cadImage;
            this.BitmapCADImage = cadImage;
            this.pictureBox2.Image = ProjectAI.ProjectManiger.CustomImageProcess.BitmapImageOverlay24bppRgb(this.BitmapOriginImage, this.BitmapCADImage, this.TrackBar.Value * this.outputRate);
            
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
                if (this.BitmapCADImage != null)
                {
                    double value = this.outputRate * (double)this.TrackBar.Value;
                    //double alpha = 1 - value;
                    //double beta = value;
                    this.TrackbarNumber.Text = ((double)this.TrackBar.Value * this.outputRate).ToString("0.00");
                    //Cv2.AddWeighted(originImage, alpha, CADImage, beta, 0, OverlayImage);
                    //this.pictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(OverlayImage);
                    this.pictureBox2.Image = ProjectAI.ProjectManiger.CustomImageProcess.BitmapImageOverlay24bppRgb(this.BitmapOriginImage, this.BitmapCADImage, value);
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
                this.image1ZoomInOut.ptRButtonDown = e.Location;
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
            //Console.Write("X: ");
            //Console.WriteLine(e.X);
            //Console.Write("Y: ");
            //Console.WriteLine(e.Y);
            this.image1ZoomInOut.iHorzScrollBarPos_copy = this.image1ZoomInOut.iHorzScrollBarPos;
            this.image1ZoomInOut.iVertScrollBarPos_copy = this.image1ZoomInOut.iVertScrollBarPos;
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
                Console.Write("X: ");
                Console.WriteLine(rectangle.X);
                Console.Write("Y: ");
                Console.WriteLine(rectangle.Y);
                Console.Write("Width: ");
                Console.WriteLine(rectangle.Width);
                Console.Write("Height: ");
                Console.WriteLine(rectangle.Height);
                this.image1ZoomInOut.ROI = rectangle;
                this.image1ZoomInOut.rectangleCenterPoint = GetRectangleCenterPoint(rectangle);
                this.pictureBox1.Image = ResizeImage(this.pictureBox1.Image, image1ZoomInOut); //ROI를 클릭했을 때 if문으로 바꿔야 함
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
            this.image1ZoomInOut.iScaleTimes = 0;
            this.pictureBox1.Image = tempPic1;
        }
    }
}
