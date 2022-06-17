using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ProjectAI.ProjectManiger
{
    internal class ImageToolUseingPictureBox
    {
        private Bitmap imgBitmap;

        private Rectangle imgRect;

        private double zoomRatio = 1F;

        private Point mousePoint = new Point(0, 0);
        private Point mousePointLeftMouseDown = new Point(0, 0);
        private Point mousePointLeftMouseDownMove = new Point(0, 0);

        private Point mousePointRightMouseDown = new Point(0, 0);
        private Point mousePointRightMouseDownMove = new Point(0, 0);

        private PictureBox pictureBox;
        private HScrollBar hScrollBar;
        private VScrollBar vScrollBar;

        public ImageToolUseingPictureBox(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;

            this.PictureBoxEvent(pictureBox);
            this.PictureBoxOption(pictureBox);

            //this.imgBitmap = new Bitmap(global::ImageTools.Properties.Resources.OpenCVexImage);

            //this.zoomRatio = this.OutRatio(this.imgBitmap.Width, this.imgBitmap.Height, this.pictureBox.Width, this.pictureBox.Height);

            //this.imgRect = new Rectangle(0, 0, (int)Math.Round(this.imgBitmap.Width * zoomRatio), (int)Math.Round(this.imgBitmap.Height * zoomRatio));

            //this.mousePoint = new Point((int)Math.Round(this.imgBitmap.Width / 2.0F), (int)Math.Round(this.imgBitmap.Height / 2.0F));

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
            if (this.imgBitmap != null)
            {
                if (this.pictureBox.Width > this.imgRect.Width)
                {
                    this.imgRect.X = (this.pictureBox.Width - this.imgRect.Width) / 2;
                }
                else
                {
                }
                if (this.pictureBox.Height > this.imgRect.Height)
                {
                    this.imgRect.Y = (this.pictureBox.Height - this.imgRect.Height) / 2;
                }

                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                e.Graphics.DrawImage(this.imgBitmap, this.imgRect);

                this.pictureBox.Focus();
            }
            else
            {
                this.pictureBox.Focus();
            }
        }

        private void PictureBoxMouseWheel(object sender, MouseEventArgs e)
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

                if (this.hScrollBar != null)
                {
                    this.ScrollBarPrint();
                }

                this.pictureBox.Invalidate();
            }
        }

        public void PictureBoxMouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Console.WriteLine($"X: {-(this.this.imgRect.X / this.zoomRatio) + (e.X / this.zoomRatio)}");
            //Console.WriteLine($"Y: {-(this.this.imgRect.Y / this.zoomRatio) + (e.Y / this.zoomRatio)}");
        }

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            this.mousePoint = e.Location;

            if (e.Button == MouseButtons.Left)
            {
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

                if (this.hScrollBar != null)
                {
                    this.ScrollBarPrint();
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
            }

            if (e.Button == MouseButtons.Right)
            {
                this.mousePointRightMouseDown = e.Location;
                this.mousePointRightMouseDownMove.X = this.imgRect.X;
                this.mousePointRightMouseDownMove.Y = this.imgRect.Y;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
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
                        this.imgBitmap = CustomIOMainger.LoadBitmap(file);
                        if (this.imgBitmap != null)
                        {
                            this.InputBitmapImage(this.imgBitmap);
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
            if (this.imgBitmap != null)
                this.pictureBox.Invalidate();
        }

        private double OutRatio(double orgA, double orgB, double targetA, double targetB)
        {
            if (targetA <= targetB)
            {
                return targetA / orgA;
            }
            else
            {
                return targetB / orgB;
            }
        }

        public void InputBitmapImage(Bitmap bitmap, bool autoResize = true)
        {
            if (bitmap != null)
            {
                if (autoResize)
                {
                    this.imgBitmap = bitmap;
                    this.zoomRatio = this.OutRatio(this.imgBitmap.Width, this.imgBitmap.Height, this.pictureBox.Width, this.pictureBox.Height);
                    this.imgRect = new Rectangle(0, 0, (int)Math.Round(this.imgBitmap.Width * zoomRatio), (int)Math.Round(this.imgBitmap.Height * zoomRatio));
                    this.mousePoint = new Point((int)Math.Round(this.imgBitmap.Width / 2.0F), (int)Math.Round(this.imgBitmap.Height / 2.0F));

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
                    this.imgBitmap = bitmap;
                    this.pictureBox.Invalidate();
                }
            }
            else
            {
                this.imgBitmap = null;
                this.pictureBox.Invalidate();
            }
        }
    }
}