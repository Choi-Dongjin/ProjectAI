using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ProjectAI.ProjectManiger
{
    internal class ImageToolUseingPictureBox
    {
        private Bitmap imgBitmap;

        Rectangle imgRect;

        private double zoomRatio = 1F;

        private Point mousePoint = new Point(0, 0);
        private Point mousePointLeftMouseDown = new Point(0, 0);
        private Point mousePointLeftMouseDownMove = new Point(0, 0);

        private PictureBox pictureBox;

        public ImageToolUseingPictureBox(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;

            this.PictureBoxEvent(pictureBox);

            //this.imgBitmap = new Bitmap(global::ImageTools.Properties.Resources.OpenCVexImage);

            //this.zoomRatio = this.OutRatio(this.imgBitmap.Width, this.imgBitmap.Height, this.pictureBox.Width, this.pictureBox.Height);

            //this.imgRect = new Rectangle(0, 0, (int)Math.Round(this.imgBitmap.Width * zoomRatio), (int)Math.Round(this.imgBitmap.Height * zoomRatio));

            //this.mousePoint = new Point((int)Math.Round(this.imgBitmap.Width / 2.0F), (int)Math.Round(this.imgBitmap.Height / 2.0F));

            pictureBox.Invalidate();
        }

        public void InputBitmapImage(Bitmap bitmap)
        {
            this.imgBitmap = bitmap;

            this.zoomRatio = this.OutRatio(this.imgBitmap.Width, this.imgBitmap.Height, this.pictureBox.Width, this.pictureBox.Height);

            this.imgRect = new Rectangle(0, 0, (int)Math.Round(this.imgBitmap.Width * zoomRatio), (int)Math.Round(this.imgBitmap.Height * zoomRatio));

            this.mousePoint = new Point((int)Math.Round(this.imgBitmap.Width / 2.0F), (int)Math.Round(this.imgBitmap.Height / 2.0F));

            this.pictureBox.Invalidate();
        }

        public void ImputImageNull()
        {
            this.imgBitmap = null;
        }

        private void PictureBoxEvent(PictureBox pictureBox)
        {
            pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            pictureBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
            pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            //pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (this.imgBitmap != null)
            {
                if (this.pictureBox.Width > this.imgRect.Width)
                {
                    this.imgRect.X = (this.pictureBox.Width - this.imgRect.Width) / 2;
                }
                if (this.pictureBox.Height > this.imgRect.Height)
                {
                    this.imgRect.Y = (this.pictureBox.Height - this.imgRect.Height) / 2;
                }

                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                e.Graphics.DrawImage(this.imgBitmap, this.imgRect);
                this.pictureBox.Focus();
            }
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.imgBitmap != null)
            {
                int lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
                PictureBox pb = (PictureBox)sender;

                if (lines > 0)
                {
                    if (zoomRatio * 1.1F < 100.0F)
                    {
                        zoomRatio *= 1.1F;
                        this.imgRect.Width = (int)Math.Round(this.imgBitmap.Width * zoomRatio);
                        this.imgRect.Height = (int)Math.Round(this.imgBitmap.Height * zoomRatio);
                        this.imgRect.X = -(int)Math.Round(1.1F * (mousePoint.X - this.imgRect.X) - mousePoint.X);
                        this.imgRect.Y = -(int)Math.Round(1.1F * (mousePoint.Y - this.imgRect.Y) - mousePoint.Y);
                    }
                }
                else if (lines < 0)
                {
                    if (zoomRatio * 0.9F > 0.001)
                    {
                        zoomRatio *= 0.9F;
                        this.imgRect.Width = (int)Math.Round(this.imgBitmap.Width * zoomRatio);
                        this.imgRect.Height = (int)Math.Round(this.imgBitmap.Height * zoomRatio);
                        this.imgRect.X = -(int)Math.Round(0.9F * (mousePoint.X - this.imgRect.X) - mousePoint.X);
                        this.imgRect.Y = -(int)Math.Round(0.9F * (mousePoint.Y - this.imgRect.Y) - mousePoint.Y);
                    }
                }
                this.pictureBox.Invalidate();
            }
        }

        public void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Console.WriteLine($"X: {-(this.this.imgRect.X / this.zoomRatio) + (e.X / this.zoomRatio)}");
            //Console.WriteLine($"Y: {-(this.this.imgRect.Y / this.zoomRatio) + (e.Y / this.zoomRatio)}");
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.imgBitmap != null)
            {
                this.mousePoint = e.Location;

                if (e.Button == MouseButtons.Left)
                {
                    this.imgRect.X = this.mousePointLeftMouseDownMove.X;
                    this.imgRect.Y = this.mousePointLeftMouseDownMove.Y;

                    this.imgRect.X = this.mousePointLeftMouseDownMove.X + (int)Math.Round((double)(e.X - this.mousePointLeftMouseDown.X) * this.zoomRatio);
                    if (this.imgRect.X >= 0)
                        this.imgRect.X = 0;
                    if (Math.Abs(this.imgRect.X) >= Math.Abs(this.imgRect.Width - this.pictureBox.Width))
                        this.imgRect.X = -(this.imgRect.Width - this.pictureBox.Width);

                    this.imgRect.Y = this.mousePointLeftMouseDownMove.Y + (int)Math.Round((double)(e.Y - this.mousePointLeftMouseDown.Y) * this.zoomRatio);
                    if (this.imgRect.Y >= 0)
                        this.imgRect.Y = 0;
                    if (Math.Abs(this.imgRect.Y) >= Math.Abs(this.imgRect.Height - this.pictureBox.Height))
                        this.imgRect.Y = -(this.imgRect.Height - this.pictureBox.Height);
                }

                this.pictureBox.Invalidate();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mousePointLeftMouseDown = e.Location;
                this.mousePointLeftMouseDownMove.X = this.imgRect.X;
                this.mousePointLeftMouseDownMove.Y = this.imgRect.Y;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private double OutRatio(double orgA, double orgB, double targetA, double targetB)
        {
            if (targetA < targetB)
            {
                return targetA / orgA;
            }
            else
            {
                return targetB / orgB;
            }
        }

    }
}
