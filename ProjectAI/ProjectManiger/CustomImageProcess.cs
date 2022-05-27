using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ProjectAI.ProjectManiger
{
    public static class CustomImageProcess
    {
        /// <summary>
        /// ssim의 계산 값
        /// </summary>
        /// <param name="OverlayImage"></param>
        /// <param name="OriginOverlayImage"></param>
        /// <returns></returns>
        public static Scalar Getssim(Mat OverlayImage, Mat OriginOverlayImage)
        {
            const double C1 = 6.5025, C2 = 58.5225;
            MatType d = MatType.CV_32F;

            Mat image1 = new Mat(), image2 = new Mat();
            OverlayImage.ConvertTo(image1, d);
            OriginOverlayImage.ConvertTo(image2, d);


            Mat image1_2 = image1.Mul(image1); // image1^2
            Mat image2_2 = image2.Mul(image2); // image2^2
            Mat image1Mulimage2 = image1.Mul(image2); // image1 * image2

            Mat mul1 = new Mat(), mul2 = new Mat();
            Cv2.GaussianBlur(image1, mul1, new OpenCvSharp.Size(11, 11), 1.5);
            Cv2.GaussianBlur(image2, mul2, new OpenCvSharp.Size(11, 11), 1.5);

            Mat mul1_2 = mul1.Mul(mul1);
            Mat mul2_2 = mul2.Mul(mul2);
            Mat mul1Mulmul2 = mul1.Mul(mul2);

            Mat sigma1_2 = new Mat(), sigma2_2 = new Mat(), sigma12 = new Mat();
            Cv2.GaussianBlur(image1_2, sigma1_2, new OpenCvSharp.Size(11, 11), 1.5);
            sigma1_2 -= mul1_2;

            Cv2.GaussianBlur(image2_2, sigma2_2, new OpenCvSharp.Size(11, 11), 1.5);
            sigma2_2 -= mul2_2;

            Cv2.GaussianBlur(image1Mulimage2, sigma12, new OpenCvSharp.Size(11, 11), 1.5);
            sigma12 -= mul1Mulmul2;

            //식
            Mat t1, t2, t3;

            t1 = 2 * mul1Mulmul2 + C1;
            t2 = 2 * sigma12 + C2;
            t3 = t1.Mul(t2);

            t1 = mul1_2 + mul2_2 + C1;
            t2 = sigma1_2 + sigma2_2 + C2;
            t1 = t1.Mul(t2);

            Mat ssim_map = new Mat();
            Cv2.Divide(t3, t1, ssim_map); // ssim_map = t3/t1

            Scalar mssim = Cv2.Mean(ssim_map);
            Console.Write("ssim");
            Console.WriteLine(mssim);
            return mssim;
        }

        /// <summary>
        /// PSNR
        /// </summary>
        /// <param name="OverlayImage"></param>
        /// <param name="OriginOverlayImage"></param>
        public static double OverlayImageCompare(Mat OverlayImage, Mat OriginOverlayImage)
        {

            double psnr = Cv2.PSNR(OverlayImage, OriginOverlayImage);
            return psnr;
        }

        /// <summary>
        /// Bitmap 이미지 오버레이
        /// </summary>
        /// <param name="orignaBitmapImagel"> 원본 이미지 </param>
        /// <param name="cadBitmapImage"> 겹칠 이미지 </param>
        /// <param name="ratio"> 오버레이 이미지 원본 비율  </param>
        /// <returns></returns>
        public unsafe static Bitmap BitmapImageOverlay24bppRgb(Bitmap orignaBitmapImagel, Bitmap cadBitmapImage, double ratio)
        {
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

            int iHeight = orignaBitmapImagel.Height;
            int iWidth = orignaBitmapImagel.Width * 3;

            for (int h = 0; h < iHeight; h++)
            {
                for (int w = 0; w < iWidth; w += 3)
                {
                    byte orignalBlue = *(ptr0 + (h * iorignalStride) + w);
                    byte orignalGreen = *(ptr0 + (h * iorignalStride) + 1 + w);
                    byte orignalRed = *(ptr0 + (h * iorignalStride) + 2 + w);

                    byte cadBlue = *(ptr1 + (h * icadStride) + w);
                    byte cadGreen = *(ptr1 + (h * icadStride) + 1 + w);
                    byte cadRed = *(ptr1 + (h * icadStride) + 2 + w);

                    *(ptr2 + (h * ioverlayStride) + w) = (Byte)(orignalBlue * ratio + cadBlue * (1 - ratio));
                    *(ptr2 + (h * ioverlayStride) + 1 + w) = (Byte)(orignalGreen * ratio + cadGreen * (1 - ratio));
                    *(ptr2 + (h * ioverlayStride) + 2 + w) = (Byte)(orignalRed * ratio + cadRed * (1 - ratio));
                }
            }
            orignaBitmapImagel.UnlockBits(pBitmapOrigmnalData);
            cadBitmapImage.UnlockBits(pBitmapCadImageData);
            overlayData.UnlockBits(pBitmapOverlayImageData);

            return overlayData;
        }

        /// <summary>
        /// overlay 비율 확인
        /// </summary>
        /// <param name="makedBitmapImage"> 만들어진 이미지 </param>
        /// <param name="targetBitmapImage"> 대상 이미지 </param>
        public unsafe static double[,,] BitmapImageGetOverlayRatio(Bitmap makedBitmapImage, Bitmap targetBitmapImage)
        {
            BitmapData makedBitmapData = makedBitmapImage.LockBits(new Rectangle(0, 0, makedBitmapImage.Width, makedBitmapImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData targetBitmapData = targetBitmapImage.LockBits(new Rectangle(0, 0, targetBitmapImage.Width, targetBitmapImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            double[,,] ratioArray = new double[3, makedBitmapImage.Width, makedBitmapImage.Height];

            byte* pMakedBitmapData = (byte*)makedBitmapData.Scan0;
            byte* pTargetBitmapData = (byte*)targetBitmapData.Scan0;

            int imakedStride = makedBitmapData.Stride;
            int itargetStride = targetBitmapData.Stride;

            int iHeight = makedBitmapData.Height;
            int iWidth = makedBitmapData.Width * 3;

            for (int h = 0; h < iHeight; h++)
            {
                for (int w = 0; w < iWidth; w += 3)
                {
                    byte makedBlue = *(pMakedBitmapData + (h * imakedStride) + w);
                    byte makedGreen = *(pMakedBitmapData + (h * imakedStride) + 1 + w);
                    byte makedRed = *(pMakedBitmapData + (h * imakedStride) + 2 + w);

                    byte targetBlue = *(pTargetBitmapData + (h * itargetStride) + w);
                    byte targetGreen = *(pTargetBitmapData + (h * itargetStride) + 1 + w);
                    byte targetRed = *(pTargetBitmapData + (h * itargetStride) + 2 + w);

                    Console.WriteLine("");
                    Console.WriteLine($"targetBlue / makedBlue: {(double)targetBlue / (double)makedBlue}");
                    Console.WriteLine($"targetGreen / makedGreen: {(double)targetGreen / (double)makedGreen}");
                    Console.WriteLine($"targetRed / makedRed: {(double)targetRed / (double)makedRed}");

                    ratioArray[2, h, (int)w / 3] = (double)targetBlue / (double)makedBlue;
                    ratioArray[1, h, (int)w / 3] = (double)targetGreen / (double)makedGreen;
                    ratioArray[0, h, (int)w / 3] = (double)targetRed / (double)makedRed;
                }
            }

            makedBitmapImage.UnlockBits(makedBitmapData);
            targetBitmapImage.UnlockBits(targetBitmapData);

            return ratioArray;
        }

        /// <summary>
        /// RGB to XYZ
        /// </summary>
        /// <param name="rgbArray"> RGB 배열 (R, G, B) </param>
        /// <returns> XTY 배열 (X, Y, Z) </returns>
        public static double[] RGBtoXYZ(double[] rgbArray)
        {
            double[] xyzArray = new double[rgbArray.GetLength(0)];

            double r = rgbArray[0];
            double g = rgbArray[1];
            double b = rgbArray[2];

            r = r / 255.0f;
            g = g / 255.0f;
            b = b / 255.0f;

            r = (r > 0.04045f) ? Math.Pow(((r + 0.055f) / 1.055f), 2.4f) : r / 12.92f;
            g = (g > 0.04045f) ? Math.Pow(((g + 0.055f) / 1.055f), 2.4f) : g / 12.92f;
            b = (b > 0.04045f) ? Math.Pow(((b + 0.055f) / 1.055f), 2.4f) : b / 12.92f;

            r = r * 100f;
            g = g * 100f;
            b = b * 100f;

            xyzArray[0] = ((r * 0.4124f) + (g * 0.3576f) + (b * 0.1805f));
            xyzArray[1] = ((r * 0.2126f) + (g * 0.7152f) + (b * 0.0722f));
            xyzArray[2] = ((r * 0.0193f) + (g * 0.1192f) + (b * 0.9505f));

            return xyzArray;
        }

        /// <summary>
        /// RGB to XYZ
        /// </summary>
        /// <param name="bitmap"> 변환할 Bitmap Image RGB </param>
        /// <returns> XTY 배열 (이미지 채널, 이미지 Height, 이미지 Width) </returns>
        public unsafe static double[,,] RGBtoXYZ(Bitmap bitmap)
        {
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            double[,,] xyzArray = new double[3, bitmap.Height, bitmap.Width];

            byte* pBitmapData = (byte*)bitmapData.Scan0;

            int imakedStride = bitmapData.Stride;

            int iHeight = bitmap.Height;
            int iWidth = bitmap.Width * 3;

            for (int h = 0; h < iHeight; h++)
            {
                for (int w = 0; w < iWidth; w += 3)
                {
                    double b = (double)(*(pBitmapData + (h * imakedStride) + w));
                    double g = (double)(*(pBitmapData + (h * imakedStride) + 1 + w));
                    double r = (double)(*(pBitmapData + (h * imakedStride) + 2 + w));

                    r = r / 255.0f;
                    g = g / 255.0f;
                    b = b / 255.0f;

                    r = (r > 0.04045f) ? Math.Pow(((r + 0.055f) / 1.055f), 2.4f) : r / 12.92f;
                    g = (g > 0.04045f) ? Math.Pow(((g + 0.055f) / 1.055f), 2.4f) : g / 12.92f;
                    b = (b > 0.04045f) ? Math.Pow(((b + 0.055f) / 1.055f), 2.4f) : b / 12.92f;

                    r = r * 100f;
                    g = g * 100f;
                    b = b * 100f;

                    xyzArray[0, h, (int)w / 3] = ((r * .4124f) + (g * .3576f) + (b * .1805f));
                    xyzArray[1, h, (int)w / 3] = ((r * .2126f) + (g * .7152f) + (b * .0722f));
                    xyzArray[2, h, (int)w / 3] = ((r * .0193f) + (g * .1192f) + (b * .9505f));
                }
            }
            bitmap.UnlockBits(bitmapData);

            return xyzArray;
        }

        /// <summary>
        /// XYZ to LAB 
        /// </summary>
        /// <param name="xyzArray"> XTY 배열 (X, Y, Z)  </param>
        /// <returns> LAB 배열 (L, A, B) </returns>
        public static double[] XYZtoLAB(double[] xyzArray)
        {
            double[] labArray = new double[xyzArray.GetLength(0)];

            double x = xyzArray[0];
            double y = xyzArray[1];
            double z = xyzArray[2];

            x = x / 95.047f;
            y = y / 100.0f;
            z = z / 108.883f;

            x = (x > 0.008856f) ? Math.Pow(x, (1.0f / 3.0f)) : (x * 7.787f) + (16.0f / 116.0f);
            y = (y > 0.008856f) ? Math.Pow(y, (1.0f / 3.0f)) : (y * 7.787f) + (16.0f / 116.0f);
            z = (z > 0.008856f) ? Math.Pow(z, (1.0f / 3.0f)) : (z * 7.787f) + (16.0f / 116.0f);

            labArray[0] = (116.0f * y) - 16.0f;
            labArray[1] = 500.0f * (x - y);
            labArray[2] = 200.0f * (y - z);

            return labArray;
        }
        /// <summary>
        /// XYZ to LAB 
        /// </summary>
        /// <param name="xyzArray"> XTY 배열 (이미지 채널, 이미지 Height, 이미지 Width) </param>
        /// <returns> LAB 배열 (이미지 채널, 이미지 Height, 이미지 Width) </returns>
        public static double[,,] XYZtoLAB(double[,,] xyzArray)
        {
            double[,,] labArray = new double[xyzArray.GetLength(0), xyzArray.GetLength(1), xyzArray.GetLength(2)];
            for (int h = 0; h < xyzArray.GetLength(1); h++)
            {
                for (int w = 0; w < xyzArray.GetLength(2); w++)
                {
                    double x = xyzArray[0, h, w];
                    double y = xyzArray[1, h, w];
                    double z = xyzArray[2, h, w];

                    x = x / 95.047f;
                    y = y / 100.0f;
                    z = z / 108.883f;

                    x = (x > 0.008856f) ? Math.Pow(x, (1.0f / 3.0f)) : (x * 7.787f) + (16.0f / 116.0f);
                    y = (y > 0.008856f) ? Math.Pow(y, (1.0f / 3.0f)) : (y * 7.787f) + (16.0f / 116.0f);
                    z = (z > 0.008856f) ? Math.Pow(z, (1.0f / 3.0f)) : (z * 7.787f) + (16.0f / 116.0f);

                    double l = (116.0f * y) - 16.0f;
                    double a = 500.0f * (x - y);
                    double b = 200.0f * (y - z);

                    labArray[0, h, w] = (116.0f * y) - 16.0f;
                    labArray[1, h, w] = 500.0f * (x - y);
                    labArray[2, h, w] = 200.0f * (y - z);
                }
            }
            return labArray;
        }

        /// <summary>
        /// Deg to Rad
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        public static double Deg2Rad(double deg)
        {
            return (deg * (3.141592 / 180.0));
        }

        /// <summary>
        /// Rad to Deg
        /// </summary>
        /// <param name="rad"></param>
        /// <returns></returns>
        public static double Rad2Deg(double rad)
        {
            return ((180.0 / 3.141592) * rad);
        }

        /// <summary>
        /// LAB Class
        /// </summary>
        public class DeltaELAB
        {
            public double L;
            public double a;
            public double b;

            public DeltaELAB(double l, double a, double b)
            {
                this.L = l;
                this.a = a;
                this.b = b;
            }

            public DeltaELAB(double[] doubles)
            {
                if (doubles.GetLength(0) == 3)
                {
                    this.L = doubles[0];
                    this.a = doubles[1];
                    this.b = doubles[2];
                }
            }
        }

        /// <summary>
        /// 델타 E 계산
        /// </summary>
        /// <param name="make"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static double LABtoDeltaE(DeltaELAB make, DeltaELAB target)
        {
            const double KL = 1, KC = 1, KH = 1;
            double deg360InRad = Deg2Rad(360.0);
            double deg180InRad = Deg2Rad(180.0);
            const double pow25To7 = 6103515625.0;

            double BarLPrime = (make.L + target.L) / 2.0;
            double C1 = Math.Sqrt((make.a * make.a) + (make.b * make.b));
            double C2 = Math.Sqrt((target.a * target.a) + (target.b * target.b));
            double BarC = (C1 + C2) / 2.0;
            double G = 0.5 * (1 - Math.Sqrt(Math.Pow(BarC, 7) / (Math.Pow(BarC, 7) + pow25To7)));
            double a1Prime = make.a * (1.0 + G);
            double a2Prime = target.a * (1.0 + G);
            double C1Prime = Math.Sqrt((a1Prime * a1Prime) + (make.b * make.b));
            double C2Prime = Math.Sqrt((a2Prime * a2Prime) + (target.b * target.b));
            double BarCPrime = (C1Prime + C2Prime) / 2.0;

            //h1'
            double h1Prime;
            if (make.b == 0 && a1Prime == 0)
                h1Prime = 0.0;
            else
            {
                h1Prime = Math.Atan2(make.b, a1Prime);
                if (h1Prime < 0)
                    h1Prime += deg360InRad;
            }

            //h2'
            double h2Prime;
            if (target.b == 0 && a1Prime == 0)
                h2Prime = 0.0;
            else
            {
                h2Prime = Math.Atan2(target.b, a2Prime);
                if (h2Prime < 0)
                    h2Prime += deg360InRad;
            }

            double BarHPrime, hPrimeSum = h1Prime + h2Prime;
            double CPrimeProduct = C1Prime * C2Prime;
            if (CPrimeProduct == 0)
                BarHPrime = hPrimeSum;
            else
            {
                if (Math.Abs(h1Prime - h2Prime) <= deg180InRad)
                    BarHPrime = hPrimeSum / 2.0;
                else
                {
                    if (hPrimeSum < deg360InRad)
                        BarHPrime = (hPrimeSum + deg360InRad) / 2.0;
                    else
                        BarHPrime = (hPrimeSum - deg360InRad) / 2.0;
                }
            }

            double T = 1.0 -
                0.17 * Math.Cos(BarHPrime - Deg2Rad(30.0)) +
                0.24 * Math.Cos(2.0 * BarHPrime) +
                0.32 * Math.Cos(3.0 * BarHPrime + Deg2Rad(6.0)) -
                0.20 * Math.Cos(4.0 * BarHPrime - Deg2Rad(63.0));

            //△h'
            double DeltahPrime;
            if (CPrimeProduct == 0)
                DeltahPrime = 0;
            else
            {
                DeltahPrime = h2Prime - h1Prime;
                if (DeltahPrime < -deg180InRad)
                    DeltahPrime += deg360InRad;
                else if (DeltahPrime > deg180InRad)
                    DeltahPrime -= deg360InRad;
            }

            //△H'
            double DeltaHPrime = 2.0 * Math.Sqrt(CPrimeProduct) * Math.Sin(DeltahPrime / 2.0);

            //△θ
            double DeltaTheta = Deg2Rad(30.0) * Math.Exp(-Math.Pow((BarHPrime - Deg2Rad(275.0)) / Deg2Rad(25), 2.0));


            double DeltaLPrime = target.L - make.L;
            double DeltaCPrime = C2Prime - C1Prime;
            double SL = 1 + (0.015 * Math.Pow(BarLPrime - 50.0, 2.0) / Math.Sqrt(20 + Math.Pow(BarLPrime - 50.0, 2.0)));
            double SC = 1 + 0.045 * BarCPrime;
            double SH = 1 + 0.015 * BarCPrime * T;
            double RC = 2 * Math.Sqrt(Math.Pow(BarC, 7.0) / (Math.Pow(BarC, 7.0) + pow25To7));
            double RT = -RC * Math.Sin(2.0 * DeltaTheta);

            //△E
            double DeltaE = Math.Sqrt(
                    Math.Pow((DeltaLPrime / (KL * SL)), 2.0) +
                    Math.Pow((DeltaCPrime / (KC * SC)), 2.0) +
                    Math.Pow((DeltaHPrime / (KH * SH)), 2.0) +
                    RT * DeltaCPrime * DeltaHPrime / (KC * SC * KH * SH)
                );
            return DeltaE;
        }

        /// <summary>
        /// deltaE Test
        /// </summary>
        public static void CalculateDeltaE1()
        {
            //double[] rgb1 = new double[] { 56, 79, 132 };
            //double[] rgb2 = new double[] { 85, 74, 212 };

            //double[] xyz1 = CustomImageProcess.RGBtoXYZ(rgb1);
            //double[] xyz2 = CustomImageProcess.RGBtoXYZ(rgb2);

            //double[] lab1 = CustomImageProcess.XYZtoLAB(xyz1);
            //double[] lab2 = CustomImageProcess.XYZtoLAB(xyz2);

            //DeltaELAB labClass1 = new DeltaELAB(lab1);
            //DeltaELAB labClass2 = new DeltaELAB(lab2);

            //double deltaE = CustomImageProcess.LABtoDeltaE(labClass1, labClass2);

            List<string> image1 = CustomIOMainger.ImageFileFileSearch(@"C:\ImageData\cadimage\1", true);
            List<string> image2 = CustomIOMainger.ImageFileFileSearch(@"C:\ImageData\cadimage\2", true);

            Console.WriteLine("");
            for (int i = 0; i < image1.Count; i++)
            {
                Bitmap makedBitmapImage = ProjectAI.CustomIOMainger.LoadBitmap(image1[i]);
                Bitmap targetBitmapImage = ProjectAI.CustomIOMainger.LoadBitmap(image2[i]);

                double[,,] makedXYZ = CustomImageProcess.RGBtoXYZ(makedBitmapImage);
                double[,,] targetXYZ = CustomImageProcess.RGBtoXYZ(targetBitmapImage);

                double[,,] makedLAB = CustomImageProcess.XYZtoLAB(makedXYZ);
                double[,,] targetLAB = CustomImageProcess.XYZtoLAB(targetXYZ);

                double[,] deltaE = new double[makedBitmapImage.Height, makedBitmapImage.Width];

                for (int h = 0; h < makedLAB.GetLength(1); h++)
                    for (int w = 0; w < makedLAB.GetLength(2); w++)
                        deltaE[h, w] = CustomImageProcess.LABtoDeltaE(new DeltaELAB(targetLAB[0, h, w], targetLAB[1, h, w], targetLAB[2, h, w]), new DeltaELAB(makedLAB[0, h, w], makedLAB[1, h, w], makedLAB[2, h, w]));

                double dDeltaE = 0;

                for (int h = 0; h < deltaE.GetLength(0); h++)
                {
                    for (int w = 0; w < deltaE.GetLength(1); w++)
                    {
                        dDeltaE += deltaE[h, w];
                    }
                }
                dDeltaE /= (deltaE.GetLength(0)) * (deltaE.GetLength(1));
                Console.WriteLine(dDeltaE);
            }
        }
    }



}
