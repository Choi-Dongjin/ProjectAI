using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectAI
{
    static class CustomIOMainger
    {
        /// <summary>
        /// 바이트로 되어있는 것을 KB, MB, GB 형식으로 변환 해주는 것
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string FormatBytes(long bytes)
        {
            const int scale = 1024;
            string[] orders = new string[] { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(scale, orders.Length - 1);

            foreach (string order in orders)
            {
                if (bytes > max)
                    return string.Format("{0:##.##} {1}", decimal.Divide(bytes, max), order);

                max /= scale;
            }
            return "0 Bytes";
        }

        /// <summary>
        /// 폴더 유무 확인 및 생성 기존의 폴더가 있으면 true, 없으면 폴더를 만들고 false 반환
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static bool DirChackExistsAndCreate(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                Console.WriteLine("That path exists already.");
                return true;
            }
            // Try to create the directory.
            Directory.CreateDirectory(dirPath);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(dirPath));
            return false;
        }

        /// <summary>
        /// 폴더 생성시 적용가능한 이름인지 확인 가능하면 True, 불가능하면 False 반환
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool DirChackCreateName(string fileName)
        {
            char[] ignoreCharArray = { ',', '\\', '/', ':', '*', '?', '"','<', '>', '|', '_', '[', ']' };
            foreach (char ignoreCha in ignoreCharArray)
            {
                if (fileName.Count(f => f == ignoreCha) > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
