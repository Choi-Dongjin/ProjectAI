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
    }
}
