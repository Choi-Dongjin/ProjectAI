using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace ProjectAI
{
    public static class CustomIOMainger
    {
        /// <summary>
        /// 이미지 검색 확장자 필터 설정
        /// </summary>
        private static readonly string[] imageExts = new[] { ".jpg", ".bmp", ".png" }; // 검색할 확장자 필터

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

        public static string FormatBytesGB(double bytes)
        {
            const int scale = 1024;
            for (int i = 0; i < 3; i++)
            {
                bytes /= scale;
            }

            return String.Format("{0:0.0000}", bytes);
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
        /// <param name="folderName"> 확인학 폴더 이름</param>
        /// <returns></returns>
        public static bool DirChackCreateName(string folderName)
        {
            char[] ignoreCharArray = { ',', '\\', '/', ':', '*', '?', '"', '<', '>', '|', '_', '[', ']' };
            foreach (char ignoreCha in ignoreCharArray)
            {
                if (folderName.Count(f => f == ignoreCha) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 폴더내 파일 검색
        /// </summary>
        /// <param name="dirPath"> 대상 경로 </param>
        /// <param name="getFileNameMode"> "Full", "Name" </param>
        /// <returns></returns>
        public static List<string> DirFileSerch(string dirPath, string getFileNameMode)
        {
            List<string> fileList = new List<string>();
            bool fileNameModeBool;

            if (getFileNameMode == "Full")
            {
                fileNameModeBool = true;
            }
            else if (getFileNameMode == "Name")
            {
                fileNameModeBool = false;
            }
            else
            {
                fileNameModeBool = false;
            }

            DirectoryInfo di = new DirectoryInfo(dirPath);
            if (di.Exists)
            {
                if (fileNameModeBool)
                {
                    foreach (FileInfo fileInfo in di.GetFiles())
                    {
                        fileList.Add(fileInfo.FullName);
                    }
                }
                else
                {
                    foreach (FileInfo fileInfo in di.GetFiles())
                    {
                        fileList.Add(fileInfo.Name);
                    }
                }
            }
            return fileList;
        }

        /// <summary>
        /// 폴더 사이즈 계산
        /// </summary>
        /// <param name="forderName"> 확인 경로 </param>
        /// <returns></returns>
        public static long DirSize(string forderName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(forderName);
            long size = 0;
            // Add file sizes.
            if (directoryInfo.Exists)
            {
                FileInfo[] fis = directoryInfo.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
                // Add subdirectory sizes.
                DirectoryInfo[] dis = directoryInfo.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += DirSize(di.FullName);
                }
            }
            return size;
        }

        /// <summary>
        /// 폴더 삭제 서브 폴더까지
        /// </summary>
        /// <param name="DeleteDirPath"></param>
        /// <returns></returns>
        public static bool DirDelete(string DeleteDirPath)
        {
            // Directory 파일 삭제
            try
            {
                DirectoryInfo directory = new DirectoryInfo(DeleteDirPath);
                foreach (FileInfo file in directory.EnumerateFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo subDirectory in directory.EnumerateDirectories())
                {
                    subDirectory.Delete(true);
                }
                directory.Delete();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 파일 삭제 성공시 true, 실패시 false
        /// </summary>
        /// <param name="fileNanmePath"> 삭제할 파일 경로</param>
        /// <returns></returns>
        public static bool FileRemove(string fileNanmePath)
        {
            try
            {
                if (File.Exists(fileNanmePath))
                {
                    File.Delete(fileNanmePath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// UI 정지하지 않고 딜레이 주기
        /// </summary>
        /// <param name="ms"></param>
        public static void FileIODelay(int ms)
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow.Add(duration);
            while (dateTimeAdd >= dateTimeNow)
            {
                System.Windows.Forms.Application.DoEvents();
                dateTimeNow = DateTime.Now;
            }
            return;
        }

        /// <summary>
        /// 임의의 파일 이름 만들기 기본 10 자리 이름
        /// </summary>
        /// <param name="number"> 자릿수 </param>
        /// <returns> 랜덤 이름 </returns>
        public static string RandomFileName(int number = 10)
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[number];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            Console.WriteLine(resultString);
            return resultString;
        }

        /// <summary>
        /// 기존 이름들과 비교해서 새로운 이름 만들기
        /// </summary>
        /// <param name="names"> 기존 이름 array </param>
        /// <param name="number"> 자릿수 </param>
        /// <returns></returns>
        public static string RandomFileName(string[] names, int number = 10)
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[number];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            Console.WriteLine(resultString);

            foreach (string name in names)
            {
                if (name == resultString)
                {
                    resultString = RandomFileName(names, number);
                }
            }

            return resultString;
        }

        /// <summary>
        /// 기존 이름들과 비교해서 새로운 이름 만들기
        /// </summary>
        /// <param name="names"> 기존 이름 array </param>
        /// <param name="number"> 자릿수 </param>
        /// <returns></returns>
        public static string RandomFileName(List<string> names, int number = 10)
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[number];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            Console.WriteLine(resultString);

            foreach (string name in names)
            {
                if (name == resultString)
                {
                    resultString = RandomFileName(names, number);
                }
            }

            return resultString;
        }

        /// <summary>
        /// 이미지 파일 검색
        /// </summary>
        /// <param name="path"> 폴더 경로 </param>
        /// <param name="getFileFullPath"> 파일 전체 경로 출력 여부, true: 전체 경로 출력 - false: 파일 이름 출력</param>
        /// <returns></returns>
        public static List<string> ImageFileFileSearch(string path, bool getFileFullPath)
        {
            List<string> filesList = new List<string>();
            string[] files;
            try
            {
                string[] exts = imageExts; // 검색할 확장자 필터

                string[] dirs = Directory.GetDirectories(path);
                files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Where(s => exts.Contains(Path.GetExtension(s), StringComparer.OrdinalIgnoreCase)).ToArray();

                if (getFileFullPath)
                    foreach (string fullFileName in files)
                        filesList.Add(fullFileName);
                else
                    foreach (string fullFileName in files)
                        filesList.Add(Path.GetFileName(fullFileName));
            }
            catch (Exception ex)
            {
                files = null;
                Console.WriteLine(ex);
            }
            return filesList;
        }

        /// <summary>
        /// 이미지 파일 검색
        /// </summary>
        /// <param name="path"> 폴더 경로</param>
        /// <param name="getFileFullPath"> 파일 전체 경로 출력 여부</param>
        /// <param name="subfoldersSearch"> 하위 폴더 검색 여부</param>
        /// <returns></returns>
        public static List<string> ImageFileFileSearch(string path, bool getFileFullPath, bool subfoldersSearch)
        {
            List<string> filesList = new List<string>();
            try
            {
                string[] exts = imageExts; // 검색할 확장자 필터

                string[] dirs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Where(s => exts.Contains(Path.GetExtension(s), StringComparer.OrdinalIgnoreCase)).ToArray();

                foreach (string FullFileName in files)
                {
                    // 이 곳에 해당 파일을 찾아서 처리할 코드를 삽입하면 된다.
                    // Console.WriteLine($"[{count++}] path - {FullFileName}");

                    // Delete a file by using File class static method...
                    if (System.IO.File.Exists(FullFileName))
                    {
                        // Use a try block to catch IOExceptions, to
                        // handle the case of the file already being
                        // opened by another process.
                        if (getFileFullPath)
                            foreach (string fullFileName in files)
                                filesList.Add(fullFileName);
                        else
                            foreach (string fullFileName in files)
                                filesList.Add(Path.GetFileName(fullFileName));
                    }
                }

                //하위 폴더가지 확인 재귀 함수를 이용한 구현
                if (dirs.Length > 0 && subfoldersSearch)
                {
                    foreach (string dir in dirs)
                    {
                        filesList.AddRange(ImageFileFileSearch(dir, true));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return filesList;
        }

        /// <summary>
        /// 이미지 읽어올시 파일을 안잡고 읽어오기
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Bitmap LoadBitmap(string path)
        {
            if (imageExts.Contains(Path.GetExtension(path)))
            {
                if (File.Exists(path))
                {
                    // open file in read only mode
                    using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        // get a binary reader for the file stream
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            // copy the content of the file into a memory stream
                            var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                            // make a new Bitmap object the owner of the MemoryStream
                            return new Bitmap(memoryStream);
                        }
                    }
                }
                else
                {
                    // MessageBox.Show("Error Loading File.", "Error!", MessageBoxButtons.OK);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static JObject BitmapToJObject(Bitmap bitmap)
        {
            return null;
        }

        public static void CDoubleBuffered(this System.Windows.Forms.DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}