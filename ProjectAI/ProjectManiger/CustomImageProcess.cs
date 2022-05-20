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

        /// <summary>
        /// DeltaE
        /// </summary>
        /// <param name="OverlayImage"></param> 프로그램 안에서 Overlay된 image
        /// <param name="OriginOverlayImage"></param> 외부에서 Overlay된 image
        /// <returns></returns>
        public static int DeltaE(Mat OverlayImage, Mat OriginOverlayImage)
        {
            //Mat zFillMat = Mat.Zeros(OverlayImage.Size(), MatType.CV_8UC1);

            ////OverlayImage의 BGR 나누기
            //Mat[] OverlayBGR = new Mat[3];
            //OverlayBGR = Cv2.Split(OverlayImage);
            //Mat[] OverlayR = { zFillMat, zFillMat, OverlayBGR[2] };
            //Mat[] OverlayG = { zFillMat, OverlayBGR[1], zFillMat };
            //Mat[] OverlayB = { OverlayBGR[0], zFillMat, zFillMat };
            //Cv2.Merge(OverlayR, OverlayBGR[2]);
            //Cv2.Merge(OverlayG, OverlayBGR[1]);
            //Cv2.Merge(OverlayB, OverlayBGR[0]);


            ////OriginOverlayImage의 BGR 나누기
            //Mat[] OriginOverlayBGR = new Mat[3];
            //OriginOverlayBGR = Cv2.Split(OriginOverlayImage);
            //Mat[] OriginOverlayR = { zFillMat, zFillMat, OriginOverlayBGR[2] };
            //Mat[] OriginOverlayG = { zFillMat, OriginOverlayBGR[1], zFillMat };
            //Mat[] OriginOverlayB = { OriginOverlayBGR[0], zFillMat, zFillMat };
            //Cv2.Merge(OriginOverlayR, OriginOverlayBGR[2]);
            //Cv2.Merge(OriginOverlayG, OriginOverlayBGR[1]);
            //Cv2.Merge(OriginOverlayB, OriginOverlayBGR[0]);

            //Cv2.ImShow("Red", OverlayBGR[2]);
            //Cv2.ImShow("Green", OverlayBGR[1]);
            //Cv2.ImShow("Blue", OverlayBGR[0]);

            return 1;
            //return 100 * (int)(
            //    1.0 - ((double)(
            //        Math.Abs(OverlayBGR[2] - OriginOverlayBGR[2]) +
            //        Math.Abs(OverlayBGR[1] - OriginOverlayBGR[1]) +
            //        Math.Abs(OverlayBGR[0] - OriginOverlayBGR[0])
            //    ) / (256.0 * 3))
            //);
        }
    }



}
