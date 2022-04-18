using MetroFramework.Components;
using OpenCvSharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

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
            else if (exCase.Equals("gaussiannoise"))
            {
                this.UISetUpGaussianNoise();
                this.activeConverter += this.ConvertGaussianNoise;
            }
            else if (exCase.Equals("sharpen"))
            {
                this.UISetUpSharpen();
                this.activeConverter += this.ConvertSharpen;
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
            FormsManiger formsManiger = FormsManiger.GetInstance();
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
        /// <summary>
        /// 이미지 읽어오기 => 이미지 사이즈 조정
        /// </summary>
        /// <param name="imageDataPath"></param>
        private void ImageRead(string imageDataPath)
        {
            //try
            //{
            //    Bitmap bitmap = CustomIOMainger.LoadBitmap(imageDataPath);
            //    this.orignalImage = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    this.orignalImage = OpenCvSharp.Cv2.ImRead(imageDataPath, ImreadModes.AnyDepth | ImreadModes.AnyColor);
            //}

            this.orignalImage = OpenCvSharp.Cv2.ImRead(imageDataPath, ImreadModes.AnyDepth | ImreadModes.AnyColor);

            //double resizeR = (double)1024 / Math.Sqrt((double)(this.orignalImage.Width * this.orignalImage.Height)); // 262144 -> (512 * 512)
            //if (resizeR <= 1)
            //    OpenCvSharp.Cv2.Resize(this.orignalImage, this.orignalImage, new OpenCvSharp.Size(0, 0), resizeR, resizeR);

            //Cv2.ImShow("Image",this.orignalImage);
            //Console.WriteLine(this.orignalImage.Size());
        }

        /// <summary>
        /// 이미지 적용 => 초기 이미지
        /// </summary>
        public void ActiveExample()
        {
            Bitmap bitmap1 = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(this.orignalImage);
            this.pictureBox1.Image = bitmap1;
            this.pictureBox2.Image = bitmap1;
        }

        /// <summary>
        /// 최솟 값 스크롤 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        ///  최댓 값 스크롤 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 리뷰 이미지 스크롤 값 변경 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrbMappliedValueChanged(object sender, EventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                GC.Collect();
            }
        }

        #region Converter 설정

        #region Blur 설정

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

        #endregion

        #region Brightness

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
            if (double.TryParse(valueString, out double value))
            {
                if (value > 0)
                {
                    Scalar a = new Scalar(value, value, value);
                    Mat val = new Mat(orignalImage.Size(), MatType.CV_8UC3, a);
                    //Console.WriteLine(value);
                    //Console.WriteLine(val.At<Vec3d>(256, 256)[0]);
                    //Console.WriteLine(val.At<Vec3d>(256, 256)[1]);
                    //Console.WriteLine(val.At<Vec3d>(256, 256)[2]);
                    Cv2.Add(orignalImage, val, convertImage);
                    val.Dispose();
                }
                else
                {
                    value = value * -1;
                    Scalar a = new Scalar(value, value, value);

                    Mat val = new Mat(orignalImage.Size(), MatType.CV_8UC3, a);
                    Cv2.Subtract(orignalImage, val, convertImage);
                    val.Dispose();
                }
            }
            return convertImage;
        }

        #endregion

        #region Center

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

        #endregion

        #region Contrast

        /// <summary>
        /// Contrast 설정에서 UI 설정
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
                //int divideValue = (int)(1 / this.outputRate);
                //Mat val1 = new Mat(orignalImage.Size(), MatType.CV_8UC3, new Scalar(divideValue, divideValue, divideValue));
                //Mat val2 = new Mat(orignalImage.Size(), MatType.CV_8UC3, new Scalar(value, value, value));

                //Cv2.Divide(orignalImage, val1, converImage);
                //Cv2.Multiply(converImage, val2, converImage);

                Console.WriteLine(value);

                //double brightness = value - 50;
                double brightness = value / 10;
                double contrast = value - 10;

                double alpha, beta;
                if (contrast > 1)
                {
                    double delta = 127f * contrast / 100f;
                    alpha = 255f / (255f - delta * 2);
                    beta = alpha * (brightness - delta);
                }
                else
                {
                    double delta = -128f * contrast / 100f;
                    alpha = (256f - delta * 2) / 255f;
                    beta = alpha * brightness + delta;
                }
                orignalImage.ConvertTo(converImage, MatType.CV_8UC3, alpha, beta);
            }
            return converImage;
        }

        #endregion

        #region GaussianNoise

        /// <summary>
        /// GaussianNoise 설정에서 UI 설정
        /// </summary>
        public void UISetUpGaussianNoise()
        {
            this.outputRate = 1;

            this.trbMminimum.Enabled = true;
            this.trbMminimum.Minimum = 0;
            this.trbMminimum.Maximum = 100;
            this.trbMminimum.Value = 0;
            this.trbMminimum.SmallChange = 1;
            this.trbMminimum.LargeChange = 5;
            this.trbMminimum.MouseWheelBarPartitions = 100;
            this.lblMminimum.Text = (this.trbMminimum.Value * this.outputRate).ToString();

            this.trbMmaximum.Enabled = true;
            this.trbMmaximum.Minimum = 0;
            this.trbMmaximum.Maximum = 100;
            this.trbMmaximum.Value = 0;
            this.trbMmaximum.SmallChange = 1;
            this.trbMmaximum.LargeChange = 5;
            this.trbMmaximum.MouseWheelBarPartitions = 100;
            this.lblMmaximum.Text = (this.trbMmaximum.Value * this.outputRate).ToString();

            this.trbMapplied.Minimum = 0;
            this.trbMapplied.Maximum = 100;

            this.trbMapplied.Value = 0;
            this.trbMapplied.SmallChange = 1;
            this.trbMapplied.LargeChange = 5;
            this.trbMapplied.MouseWheelBarPartitions = 100;
            this.lblMapplied.Text = (this.trbMapplied.Value * this.outputRate).ToString();
        }

        /// <summary>
        /// GaussianNoise 설정
        /// </summary>
        /// <param name="orignalImage"></param>
        /// <param name="valueString"></param>
        /// <returns></returns>
        public Mat ConvertGaussianNoise(Mat orignalImage, string valueString)
        {
            Mat converImage = new Mat(orignalImage.Size(), MatType.CV_8UC3);
            if (double.TryParse(valueString, out double value))
            {
                double mean = 0;
                double stddev = value;
                Cv2.Randn(converImage, Scalar.All(mean), Scalar.All(stddev));
                Cv2.AddWeighted(orignalImage, 1, converImage, 1, 0, converImage);
            }
            return converImage;
        }

        #endregion

        #region GaussianNoise

        /// <summary>
        /// GaussianNoise 설정에서 UI 설정
        /// </summary>
        public void UISetUpSharpen()
        {
            this.outputRate = 1;

            this.trbMminimum.Enabled = false;
            this.trbMminimum.Minimum = -1;
            this.trbMminimum.Maximum = 0;
            this.trbMminimum.Value = -1;
            this.trbMminimum.SmallChange = 1;
            this.trbMminimum.LargeChange = 5;
            this.trbMminimum.MouseWheelBarPartitions = 1;
            this.lblMminimum.Text = (this.trbMminimum.Value * this.outputRate).ToString();

            this.trbMmaximum.Enabled = true;
            this.trbMmaximum.Minimum = 1;
            this.trbMmaximum.Maximum = 10;
            this.trbMmaximum.Value = 1;
            this.trbMmaximum.SmallChange = 1;
            this.trbMmaximum.LargeChange = 5;
            this.trbMmaximum.MouseWheelBarPartitions = 10;
            this.lblMmaximum.Text = (this.trbMmaximum.Value * this.outputRate).ToString();

            this.trbMapplied.Minimum = 0;
            this.trbMapplied.Maximum = 1;

            this.trbMapplied.Value = 1;
            this.trbMapplied.SmallChange = 1;
            this.trbMapplied.LargeChange = 5;
            this.trbMapplied.MouseWheelBarPartitions = 10;
            this.lblMapplied.Text = (this.trbMapplied.Value * this.outputRate).ToString();
        }

        /// <summary>
        /// GaussianNoise 설정
        /// </summary>
        /// <param name="orignalImage"></param>
        /// <param name="valueString"></param>
        /// <returns></returns>
        public Mat ConvertSharpen(Mat orignalImage, string valueString)
        {
            //Mat converImage = new Mat(orignalImage.Size(), MatType.CV_8UC3);
            Mat converImage = new Mat();
            if (double.TryParse(valueString, out double value))
            {
                /*
                 *   0, -1, 0
                 *  -1, 5, -1
                 *   0, -1, 0
                 */
                //float fValue = (float)(value * this.outputRate);
                //float bValue = (float)(-1);
                //float[] data = new float[] { 0, -1, 0, -1, 5, -1, 0, -1, 0 };
                //Mat kernel = new Mat(3, 3, MatType.CV_32F, data);
                //Cv2.Filter2D(orignalImage, converImage, orignalImage.Type(), kernel, new OpenCvSharp.Point(0, 0));

                int iValue = (2 * (int)value + 1);

                float fValue = (float)(value * this.outputRate);
                //float bValue = (float)(-1);

                List<float> kernelList = new List<float>();

                for (int i = 0; i < iValue; i++)
                {
                    for (int ii = 0; ii < iValue; ii++)
                    {
                        kernelList.Add(-1);
                    }
                }
                int listIndex = (iValue * (int)value + (int)value);

                kernelList[listIndex] = kernelList.Count;

                float[] kernelArray = kernelList.ToArray();

                Console.WriteLine($"listIndex: {listIndex}");
                Console.WriteLine($"iValue: {iValue}");
                Console.WriteLine($"kernelList: {kernelArray}");
                Console.WriteLine($"kernelList GetType: {kernelArray.GetType()}");

                foreach (float a in kernelArray)
                    Console.WriteLine(a);

                Mat kernel = new Mat(iValue, iValue, MatType.CV_32F, kernelArray);
                Cv2.Filter2D(orignalImage, converImage, orignalImage.Type(), kernel, new OpenCvSharp.Point(0, 0));
            }
            return converImage;
        }

        #endregion

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