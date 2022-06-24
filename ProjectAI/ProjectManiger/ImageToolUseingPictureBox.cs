using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ProjectAI.ProjectManiger
{
    internal class ImageToolUseingPictureBox
    {
        private Bitmap imgOutputBitmap;
        private Bitmap imgDrawingBitmap;
        private Bitmap imgInputBitmap;

        private Rectangle imgRect;

        private double zoomRatio = 1F;

        private Point mousePointZoom = new Point(0, 0);
        private Point mousePointLeftMouseDown = new Point(0, 0);
        private Point mousePointLeftMouseDownMove = new Point(0, 0);

        private Point mousePointRightMouseDown = new Point(0, 0);
        private Point mousePointRightMouseDownMove = new Point(0, 0);

        private Point drawLastPoint = new Point(0, 0);

        /// <summary>
        /// 메인 이미지 박스
        /// </summary>
        private PictureBox pictureBox;

        /// <summary>
        /// horizental 스크롤바 기능 추가
        /// </summary>
        private HScrollBar hScrollBar;

        /// <summary>
        /// vertical
        /// </summary>
        private VScrollBar vScrollBar;

        private bool enableDrawing = false;
        private bool enableFloodFill = false;

        private bool viewInputImg = true;
        private bool viewDrawingImg = false;

        #region 이미지 Tools 정보

        private Color drawColor = Color.Red;
        private int drawSize = 1;
        private System.Drawing.Pen drawPen;

        #endregion 이미지 Tools 정보

        public ImageToolUseingPictureBox(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            this.drawPen = new Pen(this.drawColor, this.drawSize);

            this.PictureBoxEvent(pictureBox);
            this.PictureBoxOption(pictureBox);

            pictureBox.Invalidate();
        }

        private void PictureBoxEvent(PictureBox pictureBox)
        {
            pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxImagePaint);
            pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseMove);
            pictureBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseWheel);
            pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseDown);
            //pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseDoubleClick);
            pictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragDrop);
            pictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragEnter);
            pictureBox.Resize += new System.EventHandler(this.pictureBox1_Resize);
        }

        internal void ScrollBarSetup(HScrollBar hScrollBar, VScrollBar vScrollBar)
        {
            this.hScrollBar = hScrollBar;
            this.vScrollBar = vScrollBar;

            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.imgRect.Y = this.vScrollBar.Value * (-1);
            this.pictureBox.Invalidate();
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.imgRect.X = this.hScrollBar.Value * (-1);
            this.pictureBox.Invalidate();
        }

        private void ScrollBarPrint()
        {
            if (this.hScrollBar != null)
            {
                this.hScrollBar.Minimum = 0;
                this.hScrollBar.Maximum = this.imgRect.Width - this.pictureBox.Width;
                if (this.hScrollBar.Minimum >= this.hScrollBar.Maximum)
                {
                    this.hScrollBar.Value = this.hScrollBar.Maximum;
                }
                else
                {
                    if (this.hScrollBar.Maximum > this.imgRect.X * (-1) && this.imgRect.X * (-1) > 0)
                        this.hScrollBar.Value = this.imgRect.X * (-1);
                }

                this.vScrollBar.Minimum = 0;
                this.vScrollBar.Maximum = this.imgRect.Height - this.pictureBox.Height;
                if (this.vScrollBar.Minimum >= this.vScrollBar.Maximum)
                {
                    this.vScrollBar.Value = this.vScrollBar.Maximum;
                }
                else
                {
                    if (this.vScrollBar.Maximum > this.imgRect.Y * (-1) && this.imgRect.Y * (-1) > 0)
                        this.vScrollBar.Value = this.imgRect.Y * (-1);
                }
            }
        }

        private void PictureBoxOption(PictureBox pictureBox)
        {
            pictureBox.AllowDrop = true;
        }

        private void PictureBoxImagePaint(object sender, PaintEventArgs e)
        {
            if (this.imgInputBitmap != null)
            {
                if (this.pictureBox.Width > this.imgRect.Width)
                    this.imgRect.X = (this.pictureBox.Width - this.imgRect.Width) / 2;
                if (this.pictureBox.Height > this.imgRect.Height)
                    this.imgRect.Y = (this.pictureBox.Height - this.imgRect.Height) / 2;

                if (this.viewInputImg && this.viewDrawingImg)
                {
                    // 이미지 같이 그리기
                    if (this.imgDrawingBitmap != null)
                        this.imgOutputBitmap = CustomImageProcess.BitmapImageOverlay24bppRgb(this.imgInputBitmap, this.imgDrawingBitmap, 0.8);
                }
                else if (this.viewInputImg)
                {
                    // 원본 이미지
                    this.imgOutputBitmap = this.imgInputBitmap;
                }
                else if (this.viewDrawingImg)
                {
                    // 그리는 이미지
                    this.imgOutputBitmap = this.imgDrawingBitmap;
                }
                else
                {
                    // 오류
                    // MessageBox.Show("ERROR", "ERROR1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(this.imgOutputBitmap, this.imgRect);
                this.pictureBox.Focus();
            }
            else
            {
                this.pictureBox.Focus();
            }
        }

        private void PictureBoxMouseWheel(object sender, MouseEventArgs e)
        {
            if (this.imgOutputBitmap != null)
            {
                int lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
                PictureBox pb = (PictureBox)sender;

                if (lines > 0)
                {
                    if (zoomRatio * 1.1F < 100.0F)
                    {
                        zoomRatio *= 1.1F;
                        this.imgRect.Width = (int)Math.Round(this.imgOutputBitmap.Width * zoomRatio);
                        this.imgRect.Height = (int)Math.Round(this.imgOutputBitmap.Height * zoomRatio);
                        this.imgRect.X = -(int)Math.Round(1.1F * (mousePointZoom.X - this.imgRect.X) - mousePointZoom.X);
                        this.imgRect.Y = -(int)Math.Round(1.1F * (mousePointZoom.Y - this.imgRect.Y) - mousePointZoom.Y);
                    }
                }
                else if (lines < 0)
                {
                    if (zoomRatio * 0.9F > 0.001)
                    {
                        zoomRatio *= 0.9F;
                        this.imgRect.Width = (int)Math.Round(this.imgOutputBitmap.Width * zoomRatio);
                        this.imgRect.Height = (int)Math.Round(this.imgOutputBitmap.Height * zoomRatio);
                        this.imgRect.X = -(int)Math.Round(0.9F * (mousePointZoom.X - this.imgRect.X) - mousePointZoom.X);
                        this.imgRect.Y = -(int)Math.Round(0.9F * (mousePointZoom.Y - this.imgRect.Y) - mousePointZoom.Y);
                    }
                }

                if (this.hScrollBar != null)
                {
                    this.ScrollBarPrint();
                }

                this.pictureBox.Invalidate();
            }
        }

        public void PictureBoxMouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Console.WriteLine($"X: {-(this.imgRect.X / this.zoomRatio) + (e.X / this.zoomRatio)}");
            //Console.WriteLine($"Y: {-(this.imgRect.Y / this.zoomRatio) + (e.Y / this.zoomRatio)}");
            Console.WriteLine($"Xa: {(-this.imgRect.X + e.X) / this.zoomRatio}");
            Console.WriteLine($"Ya: {(-this.imgRect.Y + e.Y) / this.zoomRatio}");
        }

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            this.mousePointZoom = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                // 이미지 그리기
                if (this.enableDrawing)
                {
                    int pointX = (int)Math.Round((-this.imgRect.X + e.X) / this.zoomRatio);
                    int pointY = (int)Math.Round((-this.imgRect.Y + e.Y) / this.zoomRatio);

                    using (Graphics g = Graphics.FromImage(this.imgDrawingBitmap))
                    {
                        g.DrawLine(this.drawPen, this.drawLastPoint.X, this.drawLastPoint.Y, pointX, pointY);
                        //this.imgDrawingBitmap = bitmap;
                    }

                    this.drawLastPoint.X = pointX;
                    this.drawLastPoint.Y = pointY;
                }
                // 이미지 이동
                else
                {
                    this.imgRect.X = this.mousePointLeftMouseDownMove.X;
                    this.imgRect.Y = this.mousePointLeftMouseDownMove.Y;

                    this.imgRect.X = this.mousePointLeftMouseDownMove.X + (int)Math.Round((double)(e.X - this.mousePointLeftMouseDown.X));
                    if (this.imgRect.X >= 0)
                        this.imgRect.X = 0;
                    if (Math.Abs(this.imgRect.X) >= Math.Abs(this.imgRect.Width - this.pictureBox.Width))
                        this.imgRect.X = -(this.imgRect.Width - this.pictureBox.Width);

                    this.imgRect.Y = this.mousePointLeftMouseDownMove.Y + (int)Math.Round((double)(e.Y - this.mousePointLeftMouseDown.Y));
                    if (this.imgRect.Y >= 0)
                        this.imgRect.Y = 0;
                    if (Math.Abs(this.imgRect.Y) >= Math.Abs(this.imgRect.Height - this.pictureBox.Height))
                        this.imgRect.Y = -(this.imgRect.Height - this.pictureBox.Height);

                    if (this.hScrollBar != null)
                    {
                        this.ScrollBarPrint();
                    }
                }
            }

            this.pictureBox.Invalidate();
        }

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mousePointLeftMouseDown = e.Location;
                this.mousePointLeftMouseDownMove.X = this.imgRect.X;
                this.mousePointLeftMouseDownMove.Y = this.imgRect.Y;
                if (this.enableDrawing)
                {
                    this.drawLastPoint.X = (int)Math.Round((-this.imgRect.X + e.X) / this.zoomRatio);
                    this.drawLastPoint.Y = (int)Math.Round((-this.imgRect.Y + e.Y) / this.zoomRatio);
                }
                if (this.enableFloodFill)
                {
                    int pointX = (int)Math.Round((-this.imgRect.X + e.X) / this.zoomRatio);
                    int pointY = (int)Math.Round((-this.imgRect.Y + e.Y) / this.zoomRatio);
                    Point point = new Point(pointX, pointY);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //this.imgDrawingBitmap.Save("", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null)
                    foreach (string file in files)
                    {
                        Console.WriteLine(file);
                        this.imgOutputBitmap = CustomIOMainger.LoadBitmap(file);
                        if (this.imgOutputBitmap != null)
                        {
                            this.InputBitmapImage(this.imgOutputBitmap);
                        }
                    }
            }
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            if (this.imgOutputBitmap != null)
                this.pictureBox.Invalidate();
        }

        private double OutRatio(double orgA, double orgB, double targetA, double targetB)
        {
            if (orgA * orgB > targetA * targetB)
            {
                double ra = (targetA / orgA) - (targetA / orgA) * 0.1;
                double rb = (targetB / orgB) - (targetB / orgB) * 0.1;

                if (ra > rb)
                    return rb;
                else
                    return ra;
            }
            else
            {
                if (orgA > orgB)
                    return (targetA / orgA) - (targetA / orgA) * 0.1;
                else
                    return targetB / orgB - (targetB / orgB) * 0.1;
            }
        }

        /// <summary>
        /// 이미지 툴, View 설정 리셋
        /// </summary>
        private void ToolsReset()
        {
            this.enableDrawing = false;

            this.viewDrawingImg = true;
            this.viewDrawingImg = false;
        }

        /// <summary>
        /// 이미지 넣기
        /// </summary>
        /// <param name="bitmap"> 리뷰할 bitmap 이미지 </param>
        /// <param name="autoResize"> 이미지 입력중 viewbox 이미지 시이즈 자동으로 fitin 하기 기본 활성화, 기존 설정으로 입력을 넣기 위해서는 flase로 </param>
        public void InputBitmapImage(Bitmap bitmap, bool autoResize = true)
        {
            if (bitmap != null)
            {
                if (autoResize)
                {
                    this.ToolsReset(); // tools, view 설정 리셋
                    this.imgInputBitmap = bitmap;
                    this.imgOutputBitmap = new Bitmap(bitmap.Width, bitmap.Height);
                    this.imgDrawingBitmap = new Bitmap(bitmap.Width, bitmap.Height);

                    this.zoomRatio = this.OutRatio(this.imgInputBitmap.Width, this.imgInputBitmap.Height, this.pictureBox.Width, this.pictureBox.Height);
                    this.imgRect = new Rectangle(0, 0, (int)Math.Round(this.imgInputBitmap.Width * zoomRatio), (int)Math.Round(this.imgInputBitmap.Height * zoomRatio));
                    this.mousePointZoom = new Point((int)Math.Round(this.imgInputBitmap.Width / 2.0F), (int)Math.Round(this.imgInputBitmap.Height / 2.0F));

                    if (this.hScrollBar != null)
                    {
                        this.hScrollBar.Minimum = 0;
                        this.hScrollBar.Maximum = this.imgRect.Width - this.pictureBox.Width;
                        this.vScrollBar.Minimum = 0;
                        this.vScrollBar.Maximum = this.imgRect.Height - this.pictureBox.Height;
                    }

                    this.pictureBox.Invalidate();
                }
                else
                {
                    this.imgInputBitmap = bitmap;
                    this.imgOutputBitmap = new Bitmap(bitmap.Width, bitmap.Height);

                    this.pictureBox.Invalidate();
                }
            }
            else
            {
                this.imgInputBitmap = null;
                this.imgOutputBitmap = null;
                this.imgDrawingBitmap = null;

                this.pictureBox.Invalidate();
            }
            GC.Collect();
        }

        internal void ToggleDrawing()
        {
            this.enableDrawing = !this.enableDrawing;
        }

        internal void ToggleViewInputimg()
        {
            this.viewInputImg = !this.viewInputImg;
            this.pictureBox.Invalidate();
        }

        internal void ToggleViewDrawingImg()
        {
            this.viewDrawingImg = !this.viewDrawingImg;
            this.pictureBox.Invalidate();
        }

        internal void ToggleFloodFill()
        {
            this.enableFloodFill = !this.enableFloodFill;
        }

        internal void DrawPenColorChange(Color color)
        {
            this.drawColor = color;
            this.drawPen = new Pen(color, this.drawSize);
        }

        internal void DrawPenSizeChange(int size)
        {
            this.drawSize = size;
            this.drawPen = new Pen(this.drawColor, size);
        }
    }
}