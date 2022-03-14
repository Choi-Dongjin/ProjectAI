using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace ProjectAI.ProjectManiger
{
    public partial class CustomIOManigerFoem : Form
    {
        /// <summary>
        /// 싱글톤 패턴 구현
        /// </summary>
        private static CustomIOManigerFoem customIOManigerFoem;

        /// <summary>
        /// 싱글톤 패턴 Class 호출에 사용
        /// </summary>
        /// <returns></returns>
        public static CustomIOManigerFoem GetInstance()
        {
            if (CustomIOManigerFoem.customIOManigerFoem == null)
            {
                CustomIOManigerFoem.customIOManigerFoem = new CustomIOManigerFoem();
            }
            return CustomIOManigerFoem.customIOManigerFoem;
        }

        /// <summary>
        /// FormsManiger
        /// </summary>
        private FormsManiger formsManiger = FormsManiger.GetInstance(); // Forms 관리 Class

        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            this.metroStyleManager1.Style = styleManager.Style;
            this.metroStyleManager1.Theme = styleManager.Theme;
            this.BackColor = formsManiger.GetThemeRGBClor(styleManager.Theme.ToString());
        }

        /// <summary>
        /// Start
        /// </summary>
        public CustomIOManigerFoem()
        {
            InitializeComponent();

            // UpdataFormStyleManager 등록
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            // Form에 Style 적용
            //this.UpdataFormStyleManager(formsManiger.m_StyleManager);
        }

        /// <summary>
        /// FileCopyList 동작 방법 선택
        /// </summary>
        public sealed class FileCopyListSet
        {
            /// <summary>
            /// 파일 설정퇸 폴터에 복사
            /// "예) 설정된 폴더명이 C:\Data -> C:\Data\파일명"
            /// </summary>
            public static int PathToPath { get { return 1; } }
            /// <summary>
            /// 학습을 위한 데이터 이동
            /// </summary>
            public static int TrainSet { get { return 2; } }
        }

        /// <summary>
        /// Main 으로 모니터링 하는 File IO 를 사용하는 Task
        /// </summary>
        private Task taskFileIO;
        /// <summary>
        /// 파일 List 복사 
        /// </summary>
        /// <param name="files"> 타겟 파일 List </param>
        /// <param name="setPath"> 목표 폴더 </param>
        /// <param name="fileCopyListSet"> 복사 모드 선택 1: Path to Path 일반 모드 2: Train Set 데이터 복사 모드 </param>
        /// <param name="prograssBar"> prograssBar 설정 </param>
        /// <param name="labelWorkInProgressNumber"> label 동작 중인 파일 번호 </param>
        /// <param name="labelTotalProgressNumber"> label 총 파일 겟수 </param>
        /// <param name="workInIOStatus"> label 총 파일 겟수 </param>
        /// <param name="workInProgressName"> label 복사중인 파일 이름 </param>
        private void FileCopyList(List<string> files, string setPath, int fileCopyListSet, object prograssBar = null, object labelWorkInProgressNumber = null, object labelTotalProgressNumber = null, object workInIOStatus = null, object workInProgressName = null)
        {
            bool monitoring = false;
            int totalFileNumber = files.Count;
            int workInNumber = 1;
            ProjectAI.MainForms.MainForm mainForm = ProjectAI.MainForms.MainForm.GetInstance();

            if (prograssBar != null && labelWorkInProgressNumber != null && labelTotalProgressNumber != null && workInIOStatus != null && workInProgressName != null)
            {
                monitoring = true;
                mainForm.SafeVisiblePanel(mainForm.panelstatus, true); // 모니터링 창 출력
            }

            switch (Convert.ToInt32(fileCopyListSet))
            {
                case 1:
                    foreach (string file in files)
                    {
                        if (monitoring)
                        {
                            if (!mainForm.SafeVisiblePanel(mainForm.panelstatus))
                                 mainForm.SafeVisiblePanel(mainForm.panelstatus, true); // 모니터링 창 출력
                            mainForm.SafeWriteProgressBar(prograssBar, totalFileNumber, workInNumber);
                            mainForm.SafeWriteLabelText(labelWorkInProgressNumber, workInNumber.ToString());
                            mainForm.SafeWriteLabelText(labelTotalProgressNumber, totalFileNumber.ToString());
                            mainForm.SafeWriteLabelText(workInIOStatus, "Copy");
                            mainForm.SafeWriteLabelText(workInProgressName, Path.GetFileName(file));
                            //CustomIOMainger.FileIODelay(10);
                            workInNumber++;
                        }

                        string fileName = Path.GetFileName(file);
                        string setFilePath = Path.Combine(setPath, fileName);

                        File.Copy(file, setFilePath, true);

                    }
                    break;
                case 2:
                    break;
            }
            mainForm.SafeVisiblePanel(mainForm.panelstatus, false); // 모니터링 창 출력
        }
        /// <summary>
        /// 파일 List 복사 Task 등록 함수
        /// </summary>
        /// <param name="files"> 타겟 파일 List </param>
        /// <param name="setPath"> 목표 폴더 </param>
        /// <param name="fileCopyListSet"> 복사 모드 선택 1: Path to Path 일반 모드 2: Train Set 데이터 복사 모드 </param>
        /// <param name="prograssBar"> prograssBar 설정 </param>
        /// <param name="labelWorkInProgressNumber"> label 동작 중인 파일 번호 </param>
        /// <param name="labelTotalProgressNumber"> label 총 파일 겟수 </param>
        /// <param name="workInIOStatus"> label 총 파일 겟수 </param>
        /// <param name="workInProgressName"> label 복사중인 파일 이름 </param>
        public void CreateFileCopyList(List<string> files, string setPath, int fileCopyListSet, object prograssBar = null, object labelWorkInProgressNumber = null, object labelTotalProgressNumber = null, object workInIOStatus = null, object WorkInProgressName = null)
        {
            //this.FileCopyList(files, setPath, fileCopyListSet, prograssBar, labelWorkInProgressNumber, labelTotalProgressNumber, workInIOStatus, WorkInProgressName)

            if (taskFileIO != null)
            {
                taskFileIO.ContinueWith((tesk) => this.FileCopyList(files, setPath, fileCopyListSet, prograssBar, labelWorkInProgressNumber, labelTotalProgressNumber, workInIOStatus, WorkInProgressName), TaskContinuationOptions.ExecuteSynchronously);
            }
            else
            {
                taskFileIO = Task.Run(() => this.FileCopyList(files, setPath, fileCopyListSet, prograssBar, labelWorkInProgressNumber, labelTotalProgressNumber, workInIOStatus, WorkInProgressName));
            }
        }
        /// <summary>
        /// 파일 List 삭제
        /// </summary>
        /// <param name="files"> 타겟 파일 List </param>
        /// <param name="prograssBar"> prograssBar 설정 </param>
        /// <param name="labelWorkInProgressNumber"> label 동작 중인 파일 번호 </param>
        /// <param name="labelTotalProgressNumber"> label 총 파일 겟수 </param>
        /// <param name="workInIOStatus"> label 총 파일 겟수 </param>
        /// <param name="workInProgressName"> label 복사중인 파일 이름 </param>
        private void FoleDelList(List<string> files, object prograssBar = null, object labelWorkInProgressNumber = null, object labelTotalProgressNumber = null, object workInIOStatus = null, object workInProgressName = null)
        {
            bool monitoring = false;
            int totalFileNumber = files.Count;
            int workInNumber = 1;
            ProjectAI.MainForms.MainForm mainForm = ProjectAI.MainForms.MainForm.GetInstance();

            if (prograssBar != null && labelWorkInProgressNumber != null && labelTotalProgressNumber != null && workInIOStatus != null && workInProgressName != null)
            {
                monitoring = true;
                mainForm.SafeVisiblePanel(mainForm.panelstatus, true); // 모니터링 창 출력
            }
            foreach (string file in files)
            {
                if (monitoring)
                {
                    if (!mainForm.SafeVisiblePanel(mainForm.panelstatus))
                        mainForm.SafeVisiblePanel(mainForm.panelstatus, true); // 모니터링 창 출력
                    mainForm.SafeWriteProgressBar(prograssBar, totalFileNumber, workInNumber);
                    mainForm.SafeWriteLabelText(labelWorkInProgressNumber, workInNumber.ToString());
                    mainForm.SafeWriteLabelText(labelTotalProgressNumber, totalFileNumber.ToString());
                    mainForm.SafeWriteLabelText(workInIOStatus, "Delete");
                    mainForm.SafeWriteLabelText(workInProgressName, Path.GetFileName(file));
                    //CustomIOMainger.FileIODelay(1000);
                    workInNumber++;
                }
                try
                {
                    File.Delete(file);
                }
                catch
                {
                    Console.WriteLine($"ERROR: File IO Del ERROR");
                }
                
            }
            mainForm.SafeVisiblePanel(mainForm.panelstatus, false); // 모니터링 창 출력
        }
        /// <summary>
        /// 파일 List 삭제 Task 등록 함수
        /// </summary>
        /// <param name="files"> 타겟 파일 List </param>
        /// <param name="prograssBar"> prograssBar 설정 </param>
        /// <param name="labelWorkInProgressNumber"> label 동작 중인 파일 번호 </param>
        /// <param name="labelTotalProgressNumber"> label 총 파일 겟수 </param>
        /// <param name="workInIOStatus"> label 총 파일 겟수 </param>
        /// <param name="workInProgressName"> label 복사중인 파일 이름 </param>
        public void CreateFileDelList(List<string> files, object prograssBar = null, object labelWorkInProgressNumber = null, object labelTotalProgressNumber = null, object workInIOStatus = null, object WorkInProgressName = null)
        {
            if (taskFileIO != null)
            {
                taskFileIO.ContinueWith((tesk) => this.FoleDelList(files, prograssBar, labelWorkInProgressNumber, labelTotalProgressNumber, workInIOStatus, WorkInProgressName), TaskContinuationOptions.ExecuteSynchronously);
            }
            else
            {
                taskFileIO = Task.Run(() => this.FoleDelList(files, prograssBar, labelWorkInProgressNumber, labelTotalProgressNumber, workInIOStatus, WorkInProgressName));
            }
        }
        /// <summary>
        /// 폴더 삭제 Task 등록 함수
        /// </summary>
        /// <param name="Path"></param>
        public void DeleteDictionary(string Path)
        {
            if (this.taskFileIO != null)
            {
                this.taskFileIO.ContinueWith((tesk) => CustomIOMainger.DirDelete(Path), TaskContinuationOptions.ExecuteSynchronously);
            }
            else
            {
                this.taskFileIO = Task.Run(() => CustomIOMainger.DirDelete(Path));
            }
        }
    }
}
