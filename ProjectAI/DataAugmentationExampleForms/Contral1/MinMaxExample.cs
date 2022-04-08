using MetroFramework.Components;
using OpenCvSharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectAI.DataAugmentationExampleForms.Contral1
{
    public partial class MinMaxExample : UserControl
    {
        private Mat orignalImage;
        private Mat convertImage = new Mat();

        private string imageDataPath;
        private string exCase;
        private double outputRate;

        public delegate Mat ActiveExampleDelegate(Mat orignalImage, string valueString);

        public ActiveExampleDelegate activeConverter;

        public MinMaxExample()
        {
            InitializeComponent();
            this.imageDataPath = @"E:\Z2b_이미지\1.webp";
            this.ImageRead(imageDataPath);

            // 이벤트 설정
            this.TrackBarEventSetup();
        }

        public MinMaxExample(string imageDataPath, string exCase)
        {
            InitializeComponent();

            this.imageDataPath = imageDataPath;
            this.exCase = exCase.ToLower();
            exCase = exCase.ToLower();

            FormsManiger formsManiger = FormsManiger.GetInstance();
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);

            this.ImageRead(imageDataPath);

            if (exCase.Equals("blur"))
            {
                this.UISetUpBlur();
                this.activeConverter += this.ConvertGaussianBlur; // 동작할 Convert 함수 설정
            }
            else if (exCase.Equals("brightness"))
            {
                this.UISetUpBrightness();
                this.activeConverter += this.ConvertBrightness;
            }
            else if (exCase.Equals("center"))
            {
                this.UISetUpCenter();
                this.activeConverter += this.ConvertCenter;
            }
            else if (exCase.Equals("contrast"))
            {
                this.UISetUpContrast();
                this.activeConverter += this.ConvertContrast;
            }
            else if (exCase.Equals("GaussianNoise"))
            {
                this.UISetUpGaussianNoise();
                this.activeConverter += this.ConvertGaussianNoise;
            }
            // 이벤트 설정

            this.TrackBarEventSetup();
        }

        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            this.metroStyleManager1.Style = styleManager.Style;
            this.metroStyleManager1.Theme = styleManager.Theme;
        }

        private void TrackBarEventSetup()
        {
            this.trbMmaximum.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TrbMmaximumScroll);
            this.trbMminimum.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TrbMminimunScroll);
            this.trbMapplied.ValueChanged += new System.EventHandler(this.TrbMappliedValueChanged);
        }

        private void ActiveConverterSetup()
        {
        }

        private void ImageRead(string imageDataPath)
        {
            this.orignalImage = OpenCvSharp.Cv2.ImRead(imageDataPath);
            //Console.WriteLine(this.orignalImage.Size());
            double resizeR = (double)512 / Math.Sqrt((double)(this.orignalImage.Width * this.orignalImage.Height)); // 262144 -> (512 * 512)
            OpenCvSharp.Cv2.Resize(this.orignalImage, this.orignalImage, new OpenCvSharp.Size(0, 0), resizeR, resizeR);
            //Console.WriteLine(this.orignalImage.Size());
        }

        public void ActiveExample()
        {
            Bitmap bitmap1 = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(this.orignalImage);
            this.pictureBox1.Image = bitmap1;
            this.pictureBox2.Image = bitmap1;
        }

        private void TrbMminimunScroll(object sender, ScrollEventArgs e)
        {
            this.lblMminimum.Text = (this.trbMminimum.Value * this.outputRate).ToString();
            if (this.trbMminimum.Enabled)
            {
                if (this.trbMminimum.Value < 0)
                {
                    this.trbMapplied.Minimum = this.trbMminimum.Value;
                }
                else if (this.trbMminimum.Value == 0)
                {
                    this.trbMapplied.Minimum = 0;
                }
                else if (this.trbMminimum.Value > 0)
                {
                    if (this.trbMmaximum.Value > this.trbMminimum.Value)
                    {
                        this.trbMapplied.Minimum = this.trbMminimum.Value;
                    }
                    else if (this.trbMmaximum.Value <= this.trbMminimum.Value)
                    {
                        this.lblMmaximum.Text = (this.trbMmaximum.Value * this.outputRate).ToString();

                        this.trbMmaximum.Value = this.trbMminimum.Value;

                        this.trbMapplied.Maximum = this.trbMminimum.Value + 1;
                        this.trbMapplied.Minimum = this.trbMminimum.Value;
                    }
                }
            }
        }

        private void TrbMmaximumScroll(object sender, ScrollEventArgs e)
        {
            this.lblMmaximum.Text = (this.trbMmaximum.Value * this.outputRate).ToString();
            if (this.trbMmaximum.Enabled)
            {
                if (this.trbMmaximum.Value > this.trbMminimum.Value)
                {
                    this.trbMapplied.Maximum = this.trbMmaximum.Value;
                }
                else if (this.trbMmaximum.Value == this.trbMminimum.Value)
                {
                    this.lblMminimum.Text = (this.trbMminimum.Value * this.outputRate).ToString();
                    this.trbMapplied.Maximum = this.trbMmaximum.Value + 1;
                }
                else if (this.trbMmaximum.Value < this.trbMminimum.Value)
                {
                    this.lblMminimum.Text = (this.trbMminimum.Value * this.outputRate).ToString();

                    this.trbMminimum.Value = this.trbMmaximum.Value;

                    this.trbMapplied.Minimum = this.trbMmaximum.Value - 1;
                    this.trbMapplied.Maximum = this.trbMmaximum.Value;
                }
            }
        }

        private void TrbMappliedValueChanged(object sender, EventArgs e)
        {
            if (sender is MetroFramework.Controls.MetroTrackBar metroTrackBar)
            {
                if (metroTrackBar.Value == 0)
                {
                    this.lblMapplied.Text = (metroTrackBar.Value * this.outputRate).ToString();
                    this.pictureBox2.Image = this.pictureBox1.Image;
                }
                else
                {
                    this.lblMapplied.Text = (metroTrackBar.Value * this.outputRate).ToString();
                    this.convertImage = activeConverter?.Invoke(this.orignalImage, (metroTrackBar.Value).ToString());
                    Bitmap bitmap2 = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(this.convertImage);
                    this.pictureBox2.Image = bitmap2;
                }
            }
        }

        #region Converter 설정

        /// <summary>
        /// Blur 설정에서 UI 설정
        /// </summary>
        public void UISetUpBlur()
        {
            this.trbMminimum.Enabled = false;
            this.trbMminimum.Minimum = 0;
            this.trbMminimum.Maximum = 1;
            this.trbMminimum.Value = 0;
            this.trbMminimum.SmallChange = 1;
            this.trbMminimum.LargeChange = 5;
            this.trbMminimum.MouseWheelBarPartitions = 1;
            this.lblMminimum.Text = this.trbMminimum.Value.ToString();

            this.trbMmaximum.Enabled = true;
            this.trbMmaximum.Minimum = 0;
            this.trbMmaximum.Maximum = 255;
            this.trbMmaximum.Value = 0;
            this.trbMmaximum.SmallChange = 1;
            this.trbMmaximum.LargeChange = 5;
            this.trbMmaximum.MouseWheelBarPartitions = 255;
            this.lblMmaximum.Text = this.trbMmaximum.Value.ToString();

            this.trbMapplied.Minimum = this.trbMminimum.Value;
            if (this.trbMmaximum.Value != 0)
                this.trbMapplied.Maximum = this.trbMmaximum.Value;
            else
                this.trbMapplied.Maximum = 1;
            this.trbMapplied.Value = 0;
            this.trbMapplied.SmallChange = 1;
            this.trbMapplied.LargeChange = 5;
            this.trbMapplied.MouseWheelBarPartitions = 10;
            this.lblMapplied.Text = this.trbMapplied.Value.ToString();

            this.outputRate = 1;
        }

        /// <summary>
        /// 블러 설정
        /// </summary>
        /// <param name="orignalImage"> 원본 이미지 </param>
        /// <param name="valueString"> 값 string으로 </param>
        /// <returns></returns>
        public Mat ConvertGaussianBlur(Mat orignalImage, string valueString)
        {
            Mat converImage = new Mat();
            if (double.TryParse(valueString, out double value))
            {
                Cv2.GaussianBlur(orignalImage, converImage, new OpenCvSharp.Size(3, 3), value, value, BorderTypes.Default);
            }
            return converImage;
        }

        /// <summary>
        /// Brightness 설정에서 UI 설정
        /// </summary>
        public void UISetUpBrightness()
        {
            this.trbMminimum.Enabled = true;
            this.trbMminimum.Minimum = -255;
            this.trbMminimum.Maximum = 0;
            this.trbMminimum.Value = 0;
            this.trbMminimum.SmallChange = 1;
            this.trbMminimum.LargeChange = 5;
            this.trbMminimum.MouseWheelBarPartitions = 255;
            this.lblMminimum.Text = this.trbMminimum.Value.ToString();

            this.trbMmaximum.Enabled = true;
            this.trbMmaximum.Minimum = 0;
            this.trbMmaximum.Maximum = 255;
            this.trbMmaximum.Value = 0;
            this.trbMmaximum.SmallChange = 1;
            this.trbMmaximum.LargeChange = 5;
            this.trbMmaximum.MouseWheelBarPartitions = 255;
            this.lblMmaximum.Text = this.trbMmaximum.Value.ToString();

            this.trbMapplied.Minimum = this.trbMminimum.Value;
            if (this.trbMmaximum.Value != 0)
                this.trbMapplied.Maximum = this.trbMmaximum.Value;
            else
                this.trbMapplied.Maximum = 1;

            this.trbMapplied.Value = 0;
            this.trbMapplied.SmallChange = 1;
            this.trbMapplied.LargeChange = 5;
            this.trbMapplied.MouseWheelBarPartitions = 10;
            this.lblMapplied.Text = this.trbMapplied.Value.ToString();

            this.outputRate = 1;
        }

        /// <summary>
        /// Brightness 설정
        /// </summary>
        /// <param name="orignalImage"></param>
        /// <param name="valueString"></param>
        /// <returns></returns>
        public Mat ConvertBrightness(Mat orignalImage, string valueString)
        {
            Mat converImage = new Mat();
            if (double.TryParse(valueString, out double value))
            {
                if (value > 0)
                {
                    Mat val = new Mat(orignalImage.Size(), MatType.CV_8UC3, new Scalar(value, value, value));
                    Console.WriteLine(value);
                    Console.WriteLine(val.At<Vec3d>(256, 256)[0]);
                    Console.WriteLine(val.At<Vec3d>(256, 256)[1]);
                    Console.WriteLine(val.At<Vec3d>(256, 256)[2]);
                    Cv2.Add(orignalImage, val, converImage);
                }
                else
                {
                    value = value * -1;
                    Mat val = new Mat(orignalImage.Size(), MatType.CV_8UC3, new Scalar(value, value, value));
                    Cv2.Subtract(orignalImage, val, converImage);
                }
            }
            return converImage;
        }

        /// <summary>
        /// Center 설정에서 UI 설정
        /// </summary>
        public void UISetUpCenter()
        {
            this.outputRate = 0.01;

            this.trbMminimum.Enabled = false;
            this.trbMminimum.Minimum = 0;
            this.trbMminimum.Maximum = 1;
            this.trbMminimum.Value = 0;
            this.trbMminimum.SmallChange = 1;
            this.trbMminimum.LargeChange = 5;
            this.trbMminimum.MouseWheelBarPartitions = 1;
            this.lblMminimum.Text = (this.trbMminimum.Value * this.outputRate).ToString();

            this.trbMmaximum.Enabled = true;
            this.trbMmaximum.Minimum = 10;
            this.trbMmaximum.Maximum = 100;
            this.trbMmaximum.Value = 100;
            this.trbMmaximum.SmallChange = 1;
            this.trbMmaximum.LargeChange = 5;
            this.trbMmaximum.MouseWheelBarPartitions = 100;
            this.lblMmaximum.Text = (this.trbMmaximum.Value * this.outputRate).ToString();

            this.trbMapplied.Minimum = 9;
            this.trbMapplied.Maximum = 100;

            this.trbMapplied.Value = 100;
            this.trbMapplied.SmallChange = 1;
            this.trbMapplied.LargeChange = 5;
            this.trbMapplied.MouseWheelBarPartitions = 100;
            this.lblMapplied.Text = (this.trbMapplied.Value * this.outputRate).ToString();
        }

        /// <summary>
        /// Center 설정
        /// </summary>
        /// <param name="orignalImage"></param>
        /// <param name="valueString"></param>
        /// <returns></returns>
        public Mat ConvertCenter(Mat orignalImage, string valueString)
        {
            Mat converImage = new Mat();
            if (double.TryParse(valueString, out double value))
            {
                int locationX = (int)(orignalImage.Width / 2);
                int locationY = (int)(orignalImage.Height / 2);
                int locationWidth = (int)(orignalImage.Width * this.outputRate * value / 2);
                int locationHeight = (int)(orignalImage.Height * this.outputRate * value / 2);

                converImage = orignalImage.SubMat(new Rect(locationX - locationWidth, locationY - locationHeight, locationWidth * 2, locationHeight * 2));
                //Console.WriteLine($"X{locationX - locationWidth}, Y{locationY - locationHeight}");
                //Console.WriteLine($"-X{locationX + locationWidth}, -Y{locationY + locationHeight}");
                //Console.WriteLine($"location X{(locationWidth)}, location Y{locationHeight}");
            }
            return converImage;
        }

        /// <summary>
        /// Center 설정에서 UI 설정
        /// </summary>
        public void UISetUpContrast()
        {
            this.outputRate = 0.1;

            this.trbMminimum.Enabled = true;
            this.trbMminimum.Minimum = 0;
            this.trbMminimum.Maximum = 100;
            this.trbMminimum.Value = 10;
            this.trbMminimum.SmallChange = 1;
            this.trbMminimum.LargeChange = 5;
            this.trbMminimum.MouseWheelBarPartitions = 1;
            this.lblMminimum.Text = (this.trbMminimum.Value * this.outputRate).ToString();

            this.trbMmaximum.Enabled = true;
            this.trbMmaximum.Minimum = 0;
            this.trbMmaximum.Maximum = 100;
            this.trbMmaximum.Value = 10;
            this.trbMmaximum.SmallChange = 1;
            this.trbMmaximum.LargeChange = 5;
            this.trbMmaximum.MouseWheelBarPartitions = 100;
            this.lblMmaximum.Text = (this.trbMmaximum.Value * this.outputRate).ToString();

            this.trbMapplied.Minimum = 10;
            this.trbMapplied.Maximum = 11;

            this.trbMapplied.Value = 10;
            this.trbMapplied.SmallChange = 1;
            this.trbMapplied.LargeChange = 5;
            this.trbMapplied.MouseWheelBarPartitions = 100;
            this.lblMapplied.Text = (this.trbMapplied.Value * this.outputRate).ToString();
        }

        /// <summary>
        /// Center 설정
        /// </summary>
        /// <param name="orignalImage"></param>
        /// <param name="valueString"></param>
        /// <returns></returns>
        public Mat ConvertContrast(Mat orignalImage, string valueString)
        {
            Mat converImage = new Mat();
            if (double.TryParse(valueString, out double value))
            {
                int divideValue = (int)(1 / this.outputRate);
                Mat val1 = new Mat(orignalImage.Size(), MatType.CV_8UC3, new Scalar(divideValue, divideValue, divideValue));
                Mat val2 = new Mat(orignalImage.Size(), MatType.CV_8UC3, new Scalar(value, value, value));

                Cv2.Divide(orignalImage, val1, converImage);
                Cv2.Multiply(converImage, val2, converImage);

                //Console.WriteLine(value);
                //Console.WriteLine(1 / this.outputRate);

                //Mat val1 = new Mat(orignalImage.Size(), MatType.CV_8UC3, new Scalar(10, 10, 10));
                //Mat val2 = new Mat(orignalImage.Size(), MatType.CV_8UC3, new Scalar(value, value, value));
                //Mat val3 = new Mat(orignalImage.Size(), MatType.CV_8UC3, new Scalar(12, 12, 12));

                //// Y = (10 + v) * (0.1 * a) - (13 * v)

                //Mat alpa = new Mat();
                //Mat alpa1 = new Mat();
                //Mat alpa2 = new Mat();
                //Mat beta = new Mat();

                //Cv2.Multiply(val3, val2, beta); // 13 * v

                //Cv2.Add(val1, val2, alpa1); // (10 + v)
                //Cv2.Divide(orignalImage, val1, alpa2); // (0.1 * a)
                //Cv2.Multiply(alpa1, alpa2, alpa); // (0.1 * a)

                //Cv2.Subtract(alpa, beta, converImage); // (10 + v) * 0.1 * a - (13 * v)

                //Cv2.Subtract(orignalImage, converImage, converImage); // (10 + v) * 0.1 * a - (13 * v)

                //Console.WriteLine(alpa1.At<Vec3b>(200, 200));
                //Console.WriteLine(alpa2.At<Vec3b>(200, 200));
                //Console.WriteLine(alpa.At<Vec3b>(200, 200));

                //Console.WriteLine(beta.At<Vec3b>(200, 200));
                //Console.WriteLine(converImage.At<Vec3b>(200, 200));
            }
            return converImage;
        }

        /// <summary>
        /// Center 설정에서 UI 설정
        /// </summary>
        public void UISetUpGaussianNoise()
        {
            this.outputRate = 0.1;

            this.trbMminimum.Enabled = true;
            this.trbMminimum.Minimum = 0;
            this.trbMminimum.Maximum = 10;
            this.trbMminimum.Value = 100;
            this.trbMminimum.SmallChange = 1;
            this.trbMminimum.LargeChange = 5;
            this.trbMminimum.MouseWheelBarPartitions = 1;
            this.lblMminimum.Text = (this.trbMminimum.Value * this.outputRate).ToString();

            this.trbMmaximum.Enabled = true;
            this.trbMmaximum.Minimum = 0;
            this.trbMmaximum.Maximum = 100;
            this.trbMmaximum.Value = 10;
            this.trbMmaximum.SmallChange = 1;
            this.trbMmaximum.LargeChange = 5;
            this.trbMmaximum.MouseWheelBarPartitions = 100;
            this.lblMmaximum.Text = (this.trbMmaximum.Value * this.outputRate).ToString();

            this.trbMapplied.Minimum = 99;
            this.trbMapplied.Maximum = 100;

            this.trbMapplied.Value = 10;
            this.trbMapplied.SmallChange = 1;
            this.trbMapplied.LargeChange = 5;
            this.trbMapplied.MouseWheelBarPartitions = 100;
            this.lblMapplied.Text = (this.trbMapplied.Value * this.outputRate).ToString();
        }

        /// <summary>
        /// Center 설정
        /// </summary>
        /// <param name="orignalImage"></param>
        /// <param name="valueString"></param>
        /// <returns></returns>
        public Mat ConvertGaussianNoise(Mat orignalImage, string valueString)
        {
            Mat converImage = new Mat();
            if (double.TryParse(valueString, out double value))
            {
                Console.WriteLine(value);

                Mat val1 = new Mat(orignalImage.Size(), MatType.CV_8UC3, new Scalar(100, 100, 100));
                Mat val2 = new Mat(orignalImage.Size(), MatType.CV_8UC3, new Scalar(value, value, value));

                Cv2.Divide(orignalImage, val1, converImage);
                Cv2.Multiply(orignalImage, val2, converImage);
                //Cv2.Multiply(orignalImage, val1, converImage);
            }
            return converImage;
        }

        #endregion Converter 설정

        public string GetMaximumValue()
        {
            return lblMmaximum.Text;
        }

        public string GetMinimumValue()
        {
            return lblMminimum.Text;
        }
    }
}