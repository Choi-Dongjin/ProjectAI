using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAI.ProjectManiger
{
    public static class CustomImageProcess
    {
        /// <summary>
        /// Getssim의 결과값
        /// </summary>
        //public class SSIMResult
        //{
        //    public double Score // 두 픽쳐의 전체적인 차이 값으로서 BGR의 세 채널의 차이 값의 평균
        //    {
        //        get { return (mssim.Val0 + mssim.Val1 + mssim.Val2) / 3; }
        //    }
        //    public Scalar mssim;
        //    public Mat diff;
        //}

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
            //SSIMResult result = new SSIMResult();
            //result.diff = ssim_map; // 두 사진의 차이
            //result.mssim = mssim; // BGRA의 4개 채널의 차이값으로 0-1, 1에 가까울수록 가까움
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

        public class Lab
        {
            public double L;
            public double a;
            public double b;
        }

        public static double Deg2Rad(double deg)
        {
	        return (deg * (3.141592 / 180.0));
        }

        public static double Rad2Deg(double rad)
        {
	        return ((180.0 / 3.141592) * rad);
        }

        public static double CalculateDeltaE(Lab Make, Lab Target)
        {
            const double KL = 1, KC = 1, KH = 1;
            double deg360InRad = Deg2Rad(360.0);
            double deg180InRad = Deg2Rad(180.0);
            const double pow25To7 = 6103515625.0;

            double BarLPrime = (Make.L + Target.L) / 2.0;
            double C1 = Math.Sqrt((Make.a * Make.a) + (Make.b * Make.b));
            double C2 = Math.Sqrt((Target.a * Target.a) + (Target.b * Target.b));
            double BarC = (C1 + C2) / 2.0;
            double G = 0.5 * (1 - Math.Sqrt(Math.Pow(BarC, 7) / (Math.Pow(BarC, 7) + pow25To7)));
            double a1Prime = Make.a * (1.0 + G);
            double a2Prime = Target.a * (1.0 + G);
            double C1Prime = Math.Sqrt((a1Prime * a1Prime) + (Make.b * Make.b));
            double C2Prime = Math.Sqrt((a2Prime * a2Prime) + (Target.b * Target.b));
            double BarCPrime = (C1Prime + C2Prime) / 2.0;

            //h1'
            double h1Prime;
            if (Make.b == 0 && a1Prime == 0)
                h1Prime = 0.0;
            else
            {
                h1Prime = Math.Atan2(Make.b, a1Prime);
                if (h1Prime < 0)
                    h1Prime += deg360InRad;
            }

            //h2'
            double h2Prime;
            if (Target.b == 0 && a1Prime == 0)
                h2Prime = 0.0;
            else
            {
                h2Prime = Math.Atan2(Target.b, a2Prime);
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


            double DeltaLPrime = Target.L - Make.L;
            double DeltaCPrime = C2Prime - C1Prime;
            double SL = 1 + (0.015 * Math.Pow(BarLPrime - 50.0, 2.0)/ Math.Sqrt(20 + Math.Pow(BarLPrime - 50.0, 2.0)));
            double SC = 1 + 0.045 * BarCPrime;
            double SH = 1 + 0.015 * BarCPrime * T;
            double RC = 2 * Math.Sqrt(Math.Pow(BarC, 7.0) / (Math.Pow(BarC, 7.0) + pow25To7));
            double RT = -RC * Math.Sin(2.0 * DeltaTheta);

            //△E
            double DeltaE = Math.Sqrt(
                    Math.Pow((DeltaLPrime / (KL*SL)), 2.0) +
                    Math.Pow((DeltaCPrime / (KC*SC)), 2.0) +
                    Math.Pow((DeltaHPrime / (KH*SH)), 2.0) + 
                    RT * DeltaCPrime * DeltaHPrime / (KC*SC*KH*SH)
                );
            return DeltaE;
        }
    }
}
