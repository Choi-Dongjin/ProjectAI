using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace ProjectAI.TrainForms
{
    public partial class TrainForm : Form
    {
        /// <summary>
        /// 싱글톤 패턴 구현
        /// </summary>
        private static TrainForm trainForm;

        /// <summary>
        /// 싱글톤 패턴 Class 호출에 사용
        /// </summary>
        /// <returns></returns>
        public static TrainForm GetInstance()
        {
            if (TrainForm.trainForm == null)
            {
                TrainForm.trainForm = new TrainForm();
            }
            return TrainForm.trainForm;
        }

        /// <summary>
        /// Forms 관리 Class
        /// </summary>
        private ProjectAI.FormsManiger formsManiger = ProjectAI.FormsManiger.GetInstance(); // Forms 관리 Class

        private ProjectAI.JsonDataManiger jsonDataManiger = JsonDataManiger.GetInstance();

        /// <summary>
        /// Idel Train Options
        /// </summary>
        private ProjectAI.CustomComponent.MainForms.Idle.IdelTrainOptions IdelTrainOptions = new CustomComponent.MainForms.Idle.IdelTrainOptions();

        private ProjectAI.CustomComponent.MainForms.Classification.ClassificationTrainOptions ClassificationTrainOptions = new CustomComponent.MainForms.Classification.ClassificationTrainOptions();

        /// <summary>
        /// 학습 프로세스 ProgressBar 관리 Dictionary: Key -> 실행중인 Processing Number
        /// </summary>
        private Dictionary<string, ProjectAI.CustomComponent.DataGridViewProgressColumn> trainProcessProgressBar = new Dictionary<string, ProjectAI.CustomComponent.DataGridViewProgressColumn>();

        // process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "Processing Results" -> "SaveResult" -> "EndProcessing"
        /// <summary>
        /// WaitingforWork 처리 Task
        /// </summary>
        private Task taskWaitingforWork;

        /// <summary>
        /// Processing 처리 Task
        /// </summary>
        private Task taskProcessing;

        /// <summary>
        /// 프로세스 완료 결과 저장 데이터 저장 처리 Task
        /// </summary>
        private Task taskDone;

        /// <summary>
        /// 이전 프로그램 동작시 학습이 완료 되었던 임시 파일 삭제 처리 Task
        /// </summary>
        private Task taskCleanupfilesbeforeentry;

        /// <summary>
        /// 프로세스 동작 활성화 여부
        /// </summary>
        private bool processingStart = false;

        /// <summary>
        /// Train Forms 처음 동작 확인 dgvMWaitingforWork -> 처음 추가 동작 제어
        /// </summary>
        private bool trainFormF1Start = false;

        public TrainForm()
        {
            InitializeComponent();

            // Forms Calss formStyleManager Update Handler 등록
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);

            this.TrainFormReadData(); // 데이터 읽어오고 Json 데이터에 문제가 있으면 초기화

            this.UISetIdelTrainOptions(); // UI Idel 셋업
            this.UISetClassificationTrainOptions(); // Classification UI 관련 Task 셋업

            this.panelMTrainOption.Controls.Add(this.IdelTrainOptions); // UI Idel Form에 적용

            this.UISetDataGridView();
            this.ReadDataandUpdateDataGridView(); // 데이터 읽고 컨트롤에 추가하기

            this.trainFormF1Start = true; // Train Forms 처음 동작 확인 dgvMWaitingforWork -> 처음 추가 동작 제어
        }

        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            if (this.formsManiger.m_isDarkMode) // Light로 변경시 진입
            {
                // Metro Style, styleManagerMainFormTheme 변경
                this.metroStyleManager1.Style = styleManager.Style;
                this.metroStyleManager1.Theme = styleManager.Theme;
                // 배경 색 변경, Forms에 Metro Forms 적용하지 않은 경우
                this.BackColor = this.formsManiger.GetThemeRGBClor(styleManager.Theme.ToString());
            }
            else // Dark로 변경시 진입
            {
                // Metro Style, Theme 변경
                this.metroStyleManager1.Style = styleManager.Style;
                this.metroStyleManager1.Theme = styleManager.Theme;
                // 배경 색 변경, Forms에 Metro Forms 적용하지 않은 경우
                this.BackColor = this.formsManiger.GetThemeRGBClor(styleManager.Theme.ToString());
            }
        }

        /// <summary>
        /// DataGridView 추가
        /// </summary>
        /// <param name="textBox"> </param>
        /// <param name="text"></param>
        private delegate void SafeCallTrainFormDataGridViewDelegate(System.Object dataGridViewObject, string processTask, string processType, string processInputDataType, string processStep, string processAccessCode, int processProgress);

        /// <summary>
        /// DataGridView 추가
        /// </summary>
        /// <param name="dataGridView"> dataGridView Object </param>
        /// <param name="text"> 출력할 텍스트 </param>
        public void SafeTrainFormDataGridViewAdd(System.Object dataGridViewObject, string processTask, string processType, string processInputDataType, string processStep, string processAccessCode, int processProgress)
        {
            if (dataGridViewObject.GetType() == typeof(MetroFramework.Controls.MetroGrid))
            {
                MetroFramework.Controls.MetroGrid dataGridView = (MetroFramework.Controls.MetroGrid)dataGridViewObject;
                if (dataGridView.InvokeRequired)
                {
                    try
                    {
                        var d = new SafeCallTrainFormDataGridViewDelegate(SafeTrainFormDataGridViewAdd);
                        Invoke(d, new object[] { dataGridView, processTask, processType, processInputDataType, processStep, processAccessCode, processProgress });
                    }
                    catch
                    {
                        Console.WriteLine(processTask);
                        Console.WriteLine(dataGridView.Name);
                    }
                }
                else
                {
                    // 실행
                    try
                    {
                        dataGridView.Rows.Add(processTask, processType, processInputDataType, processStep, processAccessCode, processProgress);
                        dataGridView.ClearSelection(); // 셀 선택 막기
                    }
                    catch
                    {
                        Console.WriteLine(processTask);
                        Console.WriteLine(dataGridView.Name);
                    }
                }
            }
            else if (dataGridViewObject.GetType() == typeof(System.Windows.Forms.DataGridView))
            {
                System.Windows.Forms.DataGridView dataGridView = (System.Windows.Forms.DataGridView)dataGridViewObject;
                if (dataGridView.InvokeRequired)
                {
                    var d = new SafeCallTrainFormDataGridViewDelegate(SafeTrainFormDataGridViewAdd);
                    Invoke(d, new object[] { dataGridView, processTask, processType, processInputDataType, processStep, processAccessCode, processProgress });
                }
                else
                {
                    // 실행
                    dataGridView.Rows.Add(processTask, processType, processInputDataType, processStep, processAccessCode, processProgress);
                    dataGridView.ClearSelection(); // 셀 선택 막기
                }
            }
        }

        private delegate void SafeCallDataGridViewProgressColumnDelegate(System.Object dataGridViewObject, string processAccessCode, int value);

        public void SafeDataGridViewProgressValue(System.Object dataGridViewObject, string processAccessCode, int value)
        {
            if (dataGridViewObject.GetType() == typeof(MetroFramework.Controls.MetroGrid))
            {
                MetroFramework.Controls.MetroGrid dataGridView = (MetroFramework.Controls.MetroGrid)dataGridViewObject;
                if (dataGridView.InvokeRequired)
                {
                    try
                    {
                        var d = new SafeCallDataGridViewProgressColumnDelegate(SafeDataGridViewProgressValue);
                        Invoke(d, new object[] { dataGridView, processAccessCode, value });
                    }
                    catch
                    {
                        Console.WriteLine("ERROR: SafeDataGridViewProcessStep");
                        Console.WriteLine($"dataGridViewObject: {dataGridView.Name}");
                        Console.WriteLine($"dataGridViewObject: {processAccessCode}");
                        Console.WriteLine($"value: {value}");
                    }
                }
                else
                {
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        try
                        {
                            if (processAccessCode.Equals(dataGridView.Rows[i].Cells[4].Value.ToString()))
                            {
                                dataGridView.Rows[i].Cells[5].Value = value;
                                break;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("ERROR: SafeDataGridViewProcessStep");
                            Console.WriteLine($"dataGridViewObject: {dataGridView.Name}");
                            Console.WriteLine($"dataGridViewObject: {processAccessCode}");
                            Console.WriteLine($"value: {value}");
                        }
                    }
                    // 실행
                }
            }
            else if (dataGridViewObject.GetType() == typeof(System.Windows.Forms.DataGridView))
            {
                System.Windows.Forms.DataGridView dataGridView = (System.Windows.Forms.DataGridView)dataGridViewObject;
                if (dataGridView.InvokeRequired)
                {
                    var d = new SafeCallDataGridViewProgressColumnDelegate(SafeDataGridViewProgressValue);
                    Invoke(d, new object[] { dataGridView, processAccessCode, value });
                }
                else
                {
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        if (processAccessCode.Equals(dataGridView.Rows[i].Cells[4].Value.ToString()))
                            dataGridView.Rows[i].Cells[5].Value = value;
                    }
                    // 실행
                }
            }
        }

        private delegate void SafeCallDataGridViewProcessStepDelegate(System.Object dataGridViewObject, string processAccessCode, string processStep);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGridViewObject"></param>
        /// <param name="processAccessCode"></param>
        /// <param name="processStep"> process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "Processing Results" -> "SaveResult" -> "EndProcessing" </param>
        public void SafeDataGridViewProcessStep(System.Object dataGridViewObject, string processAccessCode, string processStep)
        {
            /*
                this.dgvMProcessing.ColumnCount = 5;
                this.dgvMProcessing.Columns[0].Name = "Process Task";
                this.dgvMProcessing.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvMProcessing.Columns[1].Name = "Process Type"; // Total Labeled Image Number
                this.dgvMProcessing.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvMProcessing.Columns[2].Name = "Image Type"; // Total Labeled Image Number
                this.dgvMProcessing.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvMProcessing.Columns[3].Name = "Process Step"; // Total Labeled Image Number
                this.dgvMProcessing.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvMProcessing.Columns[4].Name = "Process Access code";
                this.dgvMProcessing.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             */
            // process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "Processing Results" -> "SaveResult" -> "EndProcessing"

            if (dataGridViewObject.GetType() == typeof(MetroFramework.Controls.MetroGrid))
            {
                MetroFramework.Controls.MetroGrid dataGridView = (MetroFramework.Controls.MetroGrid)dataGridViewObject;
                if (dataGridView.InvokeRequired)
                {
                    try
                    {
                        var d = new SafeCallDataGridViewProcessStepDelegate(SafeDataGridViewProcessStep);
                        Invoke(d, new object[] { dataGridView, processAccessCode, processStep });
                    }
                    catch
                    {
                        Console.WriteLine("ERROR: SafeDataGridViewProcessStep");
                        Console.WriteLine($"dataGridViewObject: {dataGridView.Name}");
                        Console.WriteLine($"dataGridViewObject: {processAccessCode}");
                        Console.WriteLine($"dataGridViewObject: {processStep}");
                    }
                }
                else
                {
                    try
                    {
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            if (processAccessCode == dataGridView.Rows[i].Cells[4].Value.ToString())
                                dataGridView.Rows[i].Cells[3].Value = processStep;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("ERROR: SafeDataGridViewProcessStep");
                        Console.WriteLine($"dataGridViewObject: {dataGridView.Name}");
                        Console.WriteLine($"dataGridViewObject: {processAccessCode}");
                        Console.WriteLine($"dataGridViewObject: {processStep}");
                    }

                    // 실행
                }
            }
            else if (dataGridViewObject.GetType() == typeof(System.Windows.Forms.DataGridView))
            {
                System.Windows.Forms.DataGridView dataGridView = (System.Windows.Forms.DataGridView)dataGridViewObject;
                if (dataGridView.InvokeRequired)
                {
                    var d = new SafeCallDataGridViewProcessStepDelegate(SafeDataGridViewProcessStep);
                    Invoke(d, new object[] { dataGridView, processAccessCode, processStep });
                }
                else
                {
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        if (processAccessCode == dataGridView.Rows[i].Cells[4].Value.ToString())
                            dataGridView.Rows[i].Cells[3].Value = processStep;
                    }
                    // 실행
                }
            }
        }

        private delegate void SafeCallDataGridViewRowDelegate(System.Object dataGridViewObject, string processAccessCode);

        public void SafeDataGridViewRowDelete(System.Object dataGridViewObject, string processAccessCode)
        {
            /*
                this.dgvMProcessing.ColumnCount = 5;
                this.dgvMProcessing.Columns[0].Name = "Process Task";
                this.dgvMProcessing.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvMProcessing.Columns[1].Name = "Process Type"; // Total Labeled Image Number
                this.dgvMProcessing.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvMProcessing.Columns[2].Name = "Image Type"; // Total Labeled Image Number
                this.dgvMProcessing.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvMProcessing.Columns[3].Name = "Process Step"; // Total Labeled Image Number
                this.dgvMProcessing.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvMProcessing.Columns[4].Name = "Process Access code";
                this.dgvMProcessing.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             */
            // process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "Processing Results" -> "SaveResult" -> "EndProcessing"

            if (dataGridViewObject.GetType() == typeof(MetroFramework.Controls.MetroGrid))
            {
                MetroFramework.Controls.MetroGrid dataGridView = (MetroFramework.Controls.MetroGrid)dataGridViewObject;
                if (dataGridView.InvokeRequired)
                {
                    var d = new SafeCallDataGridViewRowDelegate(SafeDataGridViewRowDelete);
                    Invoke(d, new object[] { dataGridView, processAccessCode });
                }
                else
                {
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                        if (processAccessCode == dataGridView.Rows[i].Cells[4].Value.ToString())
                            dataGridView.Rows.Remove(dataGridView.Rows[i]);
                    // 실행
                }
            }
            else if (dataGridViewObject.GetType() == typeof(System.Windows.Forms.DataGridView))
            {
                System.Windows.Forms.DataGridView dataGridView = (System.Windows.Forms.DataGridView)dataGridViewObject;
                if (dataGridView.InvokeRequired)
                {
                    var d = new SafeCallDataGridViewRowDelegate(SafeDataGridViewRowDelete);
                    Invoke(d, new object[] { dataGridView, processAccessCode });
                }
                else
                {
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                        if (processAccessCode == dataGridView.Rows[i].Cells[4].Value.ToString())
                            dataGridView.Rows.Remove(dataGridView.Rows[i]);
                    // 실행
                }
            }
        }

        private delegate void SafeCallRichTextBoxAddTextDelegate(RichTextBox richTextBox, string addText, Color color);

        private void SafeRichTextBoxAddText(RichTextBox richTextBox, string addText, Color color = new Color())
        {
            if (color == new Color())
                color = Color.DarkGoldenrod;
            if (richTextBox.InvokeRequired)
            {
                var d = new SafeCallRichTextBoxAddTextDelegate(SafeRichTextBoxAddText);
                Invoke(d, new object[] { richTextBox, addText, color });
            }
            else
            {
                richTextBox.SelectionColor = color;
                richTextBox.AppendText(addText + "\r\n");
                richTextBox.ScrollToCaret();
            }
        }

        private delegate void SafeCallChartContactSeriesAddPointDelegate(System.Windows.Forms.DataVisualization.Charting.Chart chart, string contactSeriesKey, int setX, double setY);

        public void SafeChartContactSeriesAddPoint(System.Windows.Forms.DataVisualization.Charting.Chart chart, string contactSeriesKey, int setX, double setY)
        {
            if (chart.InvokeRequired)
            {
                var d = new SafeCallChartContactSeriesAddPointDelegate(SafeChartContactSeriesAddPoint);
                Invoke(d, new object[] { chart, contactSeriesKey, setX, setY });
            }
            else
            {
                chart.Series[contactSeriesKey].Points.AddXY(setX, setY);
            }
        }

        private delegate void SafeCallChartClearDelegate(System.Windows.Forms.DataVisualization.Charting.Chart chart);

        public void SafeChartClear(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            if (chart.InvokeRequired)
            {
                var d = new SafeCallChartClearDelegate(SafeChartClear);
                Invoke(d, new object[] { chart });
            }
            else
            {
                chart.Series["Train & Validation"].Points.Clear();
                chart.Series["Test"].Points.Clear();
                chart.Series["selectModelDataTrain"].Points.Clear();
                chart.Series["selectModelDataTest"].Points.Clear();
            }
        }

        private delegate void SafeCallTapPageNumberChangeDelegate(MetroFramework.Controls.MetroTabPage metroTabPage, int value);

        public void SafeTapPageNumberChange(MetroFramework.Controls.MetroTabPage metroTabPage, int value)
        {
            if (metroTabPage.InvokeRequired)
            {
                var d = new SafeCallChartClearDelegate(SafeChartClear);
                Invoke(d, new object[] { metroTabPage, value });
            }
            else
            {
                string[] splitStr = { "(", ")" };
                string[] phoneNumberSplit = metroTabPage.Text.Split(splitStr, StringSplitOptions.RemoveEmptyEntries);

                string stringNumber = phoneNumberSplit[1];
                if (int.TryParse(phoneNumberSplit[1], out int number))
                {
                    metroTabPage.Text = $"{phoneNumberSplit[0]} ( {number + value} )";
                }
            }
        }

        /// <summary>
        /// UISetIdelTrainOptions UI Setup
        /// </summary>
        private void UISetIdelTrainOptions()
        {
            this.metroStyleExtender1.SetApplyMetroTheme(this.IdelTrainOptions, true);
            this.IdelTrainOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IdelTrainOptions.Location = new System.Drawing.Point(0, 0);
            this.IdelTrainOptions.Margin = new System.Windows.Forms.Padding(0);
            this.IdelTrainOptions.Name = "idelTrainOptions";
            this.IdelTrainOptions.Padding = new System.Windows.Forms.Padding(20, 20, 10, 20);
            this.IdelTrainOptions.Size = new System.Drawing.Size(500, 850);
            //this.IdelTrainOptions.TabIndex = 1;
        }

        /// <summary>
        /// UISetClassificationTrainOptions UI Setup
        /// </summary>
        private void UISetClassificationTrainOptions()
        {
            this.metroStyleExtender1.SetApplyMetroTheme(this.ClassificationTrainOptions, true);
            this.ClassificationTrainOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClassificationTrainOptions.Location = new System.Drawing.Point(0, 0);
            this.ClassificationTrainOptions.Margin = new System.Windows.Forms.Padding(0);
            this.ClassificationTrainOptions.Name = "classificationTrainOptions";
            this.ClassificationTrainOptions.Padding = new System.Windows.Forms.Padding(20, 20, 10, 20);
            this.ClassificationTrainOptions.Size = new System.Drawing.Size(500, 850);
            //this.ClassificationTrainOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //this.classificationTrainOptions1.TabIndex = 2;
        }

        /// <summary>
        /// DataGridView UI Seup
        /// </summary>
        private void UISetDataGridView()
        {
            /*
            ["string_processModel"] = processModel, // 프로세스 모델 정보  "Classification", "Segmentation", "ObjectDetection"
            ["string_processTask"] = processTask, // 프로세스 Task 정보 "Classification", "Segmentation", "ObjectDetection"
            ["string_processName"] = processName, // 프로세스 이름 정보
            ["string_processTrainTest"] = processTrainTest, // 프로세스 이름 정보
            ["string_processImageType"] = processInputDataType, // 프로세스 Input Data type
            ["string_processPath"] = ProcessPath,  // 프로세스 경로 정보
            ["string_workSpasceName"] = processWorkSpasceName,  // 등록된 WorkSpace 이름
            ["string_workSpaceInnerPorjectName"] = ProcessWorkSpaceInnerPorjectName  // 등록된 WorkSpaceInnerPorject 이름
            */

            // Process Step = process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "Processing Results" -> "SaveResult" -> "EndProcessing"

            // === dgvMProcessing
            this.dgvMProcessing.DataSource = null;
            this.dgvMProcessing.Columns.Clear();
            this.dgvMProcessing.Rows.Clear();

            this.dgvMProcessing.ColumnCount = 5;
            this.dgvMProcessing.Columns[0].Name = "Process Task";
            this.dgvMProcessing.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvMProcessing.Columns[1].Name = "Process Type"; // Total Labeled Image Number
            this.dgvMProcessing.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvMProcessing.Columns[2].Name = "Image Type"; // Total Labeled Image Number
            this.dgvMProcessing.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvMProcessing.Columns[3].Name = "Process Step"; // Total Labeled Image Number
            this.dgvMProcessing.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvMProcessing.Columns[4].Name = "Process Access code";
            this.dgvMProcessing.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ProjectAI.CustomComponent.DataGridViewProgressColumn processProgressBarDgvMProcessing = new ProjectAI.CustomComponent.DataGridViewProgressColumn();
            this.dgvMProcessing.Columns.Add(processProgressBarDgvMProcessing); //Train Test
            this.dgvMProcessing.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            processProgressBarDgvMProcessing.HeaderText = "Process Progress";
            // === dgvMProcessing

            // === dgvMWaitingforWork
            this.dgvMWaitingforWork.DataSource = null;
            this.dgvMWaitingforWork.Columns.Clear();
            this.dgvMWaitingforWork.Rows.Clear();

            this.dgvMWaitingforWork.ColumnCount = 5;
            this.dgvMWaitingforWork.Columns[0].Name = "Process Task";
            this.dgvMWaitingforWork.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvMWaitingforWork.Columns[1].Name = "Process Type"; // Total Labeled Image Number
            this.dgvMWaitingforWork.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvMWaitingforWork.Columns[2].Name = "Image Type"; // Total Labeled Image Number
            this.dgvMWaitingforWork.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvMWaitingforWork.Columns[3].Name = "Process Step"; // Total Labeled Image Number
            this.dgvMWaitingforWork.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvMWaitingforWork.Columns[4].Name = "Process Access code";
            this.dgvMWaitingforWork.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ProjectAI.CustomComponent.DataGridViewProgressColumn processProgressBardgvMWaitingforWork = new ProjectAI.CustomComponent.DataGridViewProgressColumn();
            this.dgvMWaitingforWork.Columns.Add(processProgressBardgvMWaitingforWork); //Train Test
            this.dgvMWaitingforWork.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            processProgressBardgvMWaitingforWork.HeaderText = "Process Progress";
            // === dgvMWaitingforWork

            // === dgvMDoneWork
            this.dgvMDoneWork.DataSource = null;
            this.dgvMDoneWork.Columns.Clear();
            this.dgvMDoneWork.Rows.Clear();

            this.dgvMDoneWork.ColumnCount = 5;
            this.dgvMDoneWork.Columns[0].Name = "Process Task";
            this.dgvMDoneWork.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvMDoneWork.Columns[1].Name = "Process Type"; // Total Labeled Image Number
            this.dgvMDoneWork.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvMDoneWork.Columns[2].Name = "Image Type"; // Total Labeled Image Number
            this.dgvMDoneWork.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvMDoneWork.Columns[3].Name = "Process Step"; // Total Labeled Image Number
            this.dgvMDoneWork.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvMDoneWork.Columns[4].Name = "Process Access code";
            this.dgvMDoneWork.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ProjectAI.CustomComponent.DataGridViewProgressColumn processProgressBardgvMDoneWork = new ProjectAI.CustomComponent.DataGridViewProgressColumn();
            this.dgvMDoneWork.Columns.Add(processProgressBardgvMDoneWork); //Train Test
            this.dgvMDoneWork.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            processProgressBardgvMDoneWork.HeaderText = "Process Progress";
            // === dgvMDoneWork

            // === dgvMmodelsVersion
            this.dgvMmodelsVersion.DataSource = null;
            this.dgvMmodelsVersion.Columns.Clear();
            this.dgvMmodelsVersion.Rows.Clear();
            this.dgvMmodelsVersion.Refresh();

            this.dgvMmodelsVersion.ColumnCount = 5;
            this.dgvMmodelsVersion.Columns[0].Name = "Version";
            this.dgvMmodelsVersion.Columns[1].Name = "Best Accuracy"; // (double_TrainAcc + double_TestAcc) / 2
            this.dgvMmodelsVersion.Columns[2].Name = "Best Loss";
            this.dgvMmodelsVersion.Columns[3].Name = "Best Escape";
            this.dgvMmodelsVersion.Columns[4].Name = "Best OverKill";
            // === dgvMmodelsVersion

            // === dgvMmodelsEpoch
            this.dgvMmodelsEpoch.DataSource = null;
            this.dgvMmodelsEpoch.Columns.Clear();
            this.dgvMmodelsEpoch.Rows.Clear();
            this.dgvMmodelsEpoch.Refresh();

            this.dgvMmodelsEpoch.ColumnCount = 9;
            this.dgvMmodelsEpoch.Columns[0].Name = "Epoch";
            this.dgvMmodelsEpoch.Columns[1].Name = "Train Loss"; // Total Labeled Image Number
            this.dgvMmodelsEpoch.Columns[2].Name = "Train Accuracy"; //Train Test
            this.dgvMmodelsEpoch.Columns[3].Name = "Train Escape";
            this.dgvMmodelsEpoch.Columns[4].Name = "Train OverKill";
            this.dgvMmodelsEpoch.Columns[5].Name = "Test Loss";
            this.dgvMmodelsEpoch.Columns[6].Name = "Test Accuracy";
            this.dgvMmodelsEpoch.Columns[7].Name = "Test Escape";
            this.dgvMmodelsEpoch.Columns[8].Name = "Test OverKill";
            // === dgvMmodelsEpoch
        }

        private void ReadDataandUpdateDataGridView()
        {
            foreach (string processAccesscode in WorkSpaceEarlyData.m_trainFormJobject["processList"])
            {
                // WorkSpaceEarlyData.m_trainFormJobject 에서는 string_processStep 읽어서 EndProcessing 아니면
                // WorkSpaceEarlyData.m_trainFormJobject 에서는 string_processPath 읽어서 Local Data 읽어오기

                string processModel;
                string processTask;
                string processName;
                string processTrainTest;
                string processImageType;
                string processPath;
                string porkSpasceName;
                string workSpaceInnerPorjectName;
                string processStep = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_processStep"].ToString();

                processPath = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_processPath"].ToString();

                JObject localProcessInfo = jsonDataManiger.GetJsonObject(System.IO.Path.Combine(processPath, "TrainSystem.Json"));

                processModel = localProcessInfo["TrainProcessInfo"]["string_processModel"].ToString();
                processTask = localProcessInfo["TrainProcessInfo"]["string_processTask"].ToString();
                processName = localProcessInfo["TrainProcessInfo"]["string_processName"].ToString();
                processTrainTest = localProcessInfo["TrainProcessInfo"]["string_processTrainTest"].ToString();
                processImageType = localProcessInfo["TrainProcessInfo"]["string_processImageType"].ToString();
                processPath = localProcessInfo["TrainProcessInfo"]["string_processPath"].ToString();
                porkSpasceName = localProcessInfo["TrainProcessInfo"]["string_workSpasceName"].ToString();
                workSpaceInnerPorjectName = localProcessInfo["TrainProcessInfo"]["string_workSpaceInnerPorjectName"].ToString();
                processStep = localProcessInfo["TrainProcessInfo"]["string_processStep"].ToString();

                // 프로세스 단계 Process Step = process 단계 !!"WaitingforWork" -> !!"EndPreprocess" -> "Processing" ->  "!!Processing Results" -> "!!SaveResult" -> "!!EndProcessing"
                if (processStep == "WaitingforWork" )
                {
                    this.SafeTrainFormDataGridViewAdd(this.dgvMWaitingforWork, processTask, processTrainTest, processImageType, processStep, processName, 0);
                    //this.dgvMWaitingforWork.Rows.Add(processTask, processTrainTest, processImageType, processStep, processName, 0);
                }
                else if (processStep == "EndPreprocess")
                {
                    this.SafeTrainFormDataGridViewAdd(this.dgvMWaitingforWork, processTask, processTrainTest, processImageType, processStep, processName, 100);
                    //this.dgvMWaitingforWork.Rows.Add(processTask, processTrainTest, processImageType, processStep, processName, 100);
                }
                else if (processStep == "Processing Results")
                {
                    this.dgvMDoneWork.Rows.Add(processTask, processTrainTest, processImageType, processStep, processName, 0);
                }
                else if (processStep == "SaveResult")
                {
                    //this.dgvMDoneWork.Rows.Add(processTask, processTrainTest, processImageType, processStep, processName, 0);
                }
                else if (processStep == "EndProcessing")
                {
                }
                // 3. 학습 데이터 관리 Dictionary 데이터 추가하기
            }
        }

        private void TrainFormLoad(object sender, EventArgs e)
        {
            // 차트 색 수정
            this.chartProcessingLoss.Series["Train & Validation"].Color = ColorTranslator.FromHtml("#41b6e6");
            this.chartProcessingLoss.Series["Test"].Color = ColorTranslator.FromHtml("#ffb549");
            this.chartProcessingLoss.Series["selectModelDataTrain"].Color = ColorTranslator.FromHtml("#001871");
            this.chartProcessingLoss.Series["selectModelDataTest"].Color = ColorTranslator.FromHtml("#ff585d");

            this.chartProcessingAccuracy.Series["Train & Validation"].Color = ColorTranslator.FromHtml("#41b6e6");
            this.chartProcessingAccuracy.Series["Test"].Color = ColorTranslator.FromHtml("#ffb549");
            this.chartProcessingAccuracy.Series["selectModelDataTrain"].Color = ColorTranslator.FromHtml("#001871");
            this.chartProcessingAccuracy.Series["selectModelDataTest"].Color = ColorTranslator.FromHtml("#ff585d");
        }

        private void TrainFormShown(object sender, EventArgs e)
        {
            //MetroTaskWindow.ShowTaskWindow(this, "Custom MessageBox", new ProjectAI.TrainForms.UserContral.CustomMessageBox(), 10);
        }

        /// <summary>
        /// 데이터 읽어오고 Json 데이터에 문제가 있으면 초기화
        /// </summary>
        private void TrainFormReadData()
        {
            if (CustomIOMainger.DirChackExistsAndCreate(WorkSpaceEarlyData.m_workSpacDataPath)) // 프로그램 폴더 유무 확인 있으면 true, 없으면 폴더를 만들고 false 반환
            {
                if (this.jsonDataManiger.JsonChackFileAndCreate(WorkSpaceEarlyData.m_trainFormPath)) // 프로그램 실행 옵션 설정 Json 파일 유무 확인 있으면 true, 없으면 폴더를 만들고 false 반환
                {
                    WorkSpaceEarlyData.m_trainFormJobject = this.jsonDataManiger.GetJsonObject(WorkSpaceEarlyData.m_trainFormPath, this.IntegrityCheck);
                    if (WorkSpaceEarlyData.m_trainFormJobject["processList"] == null)
                    {
                        WorkSpaceEarlyData.m_trainFormJobject = this.TrainFormDataReset();
                    }
                    if (WorkSpaceEarlyData.m_trainFormJobject["processInfo"] == null)
                    {
                        WorkSpaceEarlyData.m_trainFormJobject = this.TrainFormDataReset();
                    }
                }
                else
                {
                    WorkSpaceEarlyData.m_trainFormJobject = this.TrainFormDataReset();
                }
            }
            else
                WorkSpaceEarlyData.m_trainFormJobject = this.TrainFormDataReset();
        }

        /// <summary>
        ///  Json 파일 검사
        /// </summary>
        /// <param name="workSpaceEarlyDataSetJObject"></param>
        /// <returns></returns>
        private JObject IntegrityCheck(JObject workSpaceEarlyDataSetJObject)
        {
            if (workSpaceEarlyDataSetJObject == null)
            {
                workSpaceEarlyDataSetJObject = this.TrainFormDataReset();
            }
            return workSpaceEarlyDataSetJObject;
        }

        /// <summary>
        /// 데이터 파일 초기화
        /// </summary>
        /// <returns></returns>
        private JObject TrainFormDataReset()
        {
            JObject jObject = new JObject
            {
                ["processList"] = new JArray(),
                ["processInfo"] = new JObject()
            };

            return jObject;
        }

        private void TrainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            //Hiding the window, because closing it makes the window unaccessible.
            this.Hide();
            this.Parent = null;
            e.Cancel = true; //hides the form, cancels closing event
        }

        /// <summary>
        /// 프로젝트 모델 정보 업데이터
        /// </summary>
        public void UpdateModelView()
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
            {
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    if (WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] != null)
                    {
                        int version = 1;
                        this.dgvMmodelsVersion.Rows.Clear();
                        foreach (string modelName in WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["array_string_ModelList"])
                        {
                            double trainLoss = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["double_TrainLoss"]);
                            double trainAcc = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["double_TrainAcc"]);
                            double testLoss = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["double_TestLoss"]);
                            double testAcc = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["double_TestAcc"]);

                            int trainEscape = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["int_TrainEscape"]);
                            int trainOverKill = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["int_TrainOverKill"]);
                            int testEscape = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["int_TestEscape"]);
                            int testOverKill = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["int_TestOverKill"]);

                            this.dgvMmodelsVersion.Rows.Add(version, (trainAcc + testAcc) / 2, (trainLoss + testLoss) / 2, (trainEscape + testEscape) / 2, (trainOverKill + testOverKill) / 2);

                            version++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 모델 선택시 내부 모델 정보 보이기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMmodelsVersionSelectionChanged(object sender, EventArgs e)
        {
            this.ModelInfoReadAndView();
            //MetroFramework.Controls.MetroGrid metroGrid = sender as MetroFramework.Controls.MetroGrid;
            //if (sender != null)
            //{
            //    metroGrid.SelectedRows[0]
            //}
        }

        private void DgvMmodelsVersionCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.ModelInfoReadAndView();
        }

        private void ModelInfoReadAndView()
        {
            try
            {
                //if (this.dgvMmodelsVersion.SelectedRows[0].Index != -1) // 컬럼 해더 눌렀는지 감지 해더를 눌렀으면 통과
                    if (this.dgvMmodelsVersion.SelectedRows[0].Cells[0].Value != null)
                    {
                        List<string> modelList = new List<string>();
                        foreach (string modelName in WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["array_string_ModelList"]) // 모델 이름 List 로 만들기
                            modelList.Add(modelName);

                        int version = Convert.ToInt32(this.dgvMmodelsVersion.SelectedRows[0].Cells[0].Value.ToString()) - 1; // 호출하는 모델 버전 정보 가져오기

                        string selectModelName = modelList[version]; // 선택된 모델 관리 이름
                        this.dgvMmodelsEpoch.Rows.Clear();
                        foreach (string innerModelName in WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["array_string_innerModelList"])
                        {
                            // 내부 모델 정보 읽어오기
                            int locationX = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["int_locationX"]);

                            double trainLoss = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["double_TrainLoss"]);
                            double trainAcc = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["double_TrainAcc"]);
                            int trainEscape = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["int_TrainEscape"]);
                            int trainOverKill = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["int_TrainOverKill"]);

                            double testLoss = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["double_TestLoss"]);
                            double testAcc = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["double_TestAcc"]);
                            int testEscape = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["int_TestEscape"]);
                            int testOverKill = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["int_TestOverKill"]);

                            this.dgvMmodelsEpoch.Rows.Add(locationX, trainLoss, trainAcc, trainEscape, trainOverKill, testLoss, testAcc, testEscape, testOverKill);
                        }

                        // 모델 차트 그리기
                        this.chartViewLoss.Series["Train & Validation"].Points.Clear();
                        this.chartViewLoss.Series["Test"].Points.Clear();
                        this.chartViewAccuracy.Series["Train & Validation"].Points.Clear();
                        this.chartViewAccuracy.Series["Test"].Points.Clear();

                        this.chartViewLoss.Series["selectModelDataTrain"].Points.Clear();
                        this.chartViewLoss.Series["selectModelDataTest"].Points.Clear();
                        this.chartViewAccuracy.Series["selectModelDataTrain"].Points.Clear();
                        this.chartViewAccuracy.Series["selectModelDataTest"].Points.Clear();

                        foreach (JProperty trainingProgressData in WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["TrainingProgressData"])
                        {
                            int locationX = Convert.ToInt32(trainingProgressData.Name);

                            double trainLoss = Convert.ToDouble(trainingProgressData.Value["double_TrainLoss"]);
                            double trainAcc = Convert.ToDouble(trainingProgressData.Value["double_TrainAcc"]);
                            int trainEscape = Convert.ToInt32(trainingProgressData.Value["int_TrainEscape"]);
                            int trainOverKill = Convert.ToInt32(trainingProgressData.Value["int_TrainOverKill"]);

                            double testLoss = Convert.ToDouble(trainingProgressData.Value["double_TestLoss"]);
                            double testAcc = Convert.ToDouble(trainingProgressData.Value["double_TestAcc"]);
                            int testEscape = Convert.ToInt32(trainingProgressData.Value["int_TestEscape"]);
                            int testOverKill = Convert.ToInt32(trainingProgressData.Value["int_TestOverKill"]);

                            this.chartViewLoss.Series["Train & Validation"].Points.AddXY(locationX, trainLoss);
                            this.chartViewLoss.Series["Test"].Points.AddXY(locationX, testLoss);

                            this.chartViewAccuracy.Series["Train & Validation"].Points.AddXY(locationX, trainAcc);
                            this.chartViewAccuracy.Series["Test"].Points.AddXY(locationX, testAcc);
                        }

                        // 모델 학습 정보 가져오기
                        this.DataGridViewCellMouseDoubleClick(this.dgvMmodelsVersion, selectModelName);
                    }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
            }
        }

        /// <summary>
        /// 내부 모델 선택시 정보 보이기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMmodelsEpochSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvMmodelsVersion.SelectedRows[0].Cells[0].Value != null)
                {
                    List<string> modelList = new List<string>();
                    foreach (string modelName in WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["array_string_ModelList"]) // 모델 이름 List 로 만들기
                        modelList.Add(modelName);

                    int version = Convert.ToInt32(this.dgvMmodelsVersion.SelectedRows[0].Cells[0].Value.ToString()) - 1; // 호출하는 모델 버전 정보 가져오기

                    string selectModelName = modelList[version]; // 선택된 모델 관리 이름

                    string innerModelName = WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["array_string_innerModelList"][dgvMmodelsEpoch.SelectedRows[0].Index].ToString();

                    int locationX = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["int_locationX"]);

                    double trainLoss = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["double_TrainLoss"]);
                    double trainAcc = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["double_TrainAcc"]);
                    int trainEscape = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["int_TrainEscape"]);
                    int trainOverKill = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["int_TrainOverKill"]);

                    double testLoss = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["double_TestLoss"]);
                    double testAcc = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["double_TestAcc"]);
                    int testEscape = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["int_TestEscape"]);
                    int testOverKill = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["InnerModelInfo"][innerModelName]["int_TestOverKill"]);

                    this.chartViewLoss.Series["selectModelDataTrain"].Points.Clear();
                    this.chartViewLoss.Series["selectModelDataTrain"].Points.AddXY(locationX, trainLoss);
                    this.chartViewLoss.Series["selectModelDataTrain"].ToolTip = string.Format("Epoch: {0}, Loss: {1:0.00}", locationX, trainLoss);
                    this.chartViewLoss.Series["selectModelDataTest"].Points.Clear();
                    this.chartViewLoss.Series["selectModelDataTest"].Points.AddXY(locationX, testLoss);
                    this.chartViewLoss.Series["selectModelDataTest"].ToolTip = string.Format("Epoch: {0}, Loss: {1:0.00}", locationX, testLoss);

                    this.chartViewAccuracy.Series["selectModelDataTrain"].Points.Clear();
                    this.chartViewAccuracy.Series["selectModelDataTrain"].Points.AddXY(locationX, trainAcc);
                    this.chartViewAccuracy.Series["selectModelDataTrain"].ToolTip = string.Format("Epoch: {0}, Accuracy: {1:0.00}", locationX, trainAcc);
                    this.chartViewAccuracy.Series["selectModelDataTest"].Points.Clear();
                    this.chartViewAccuracy.Series["selectModelDataTest"].Points.AddXY(locationX, testAcc);
                    this.chartViewAccuracy.Series["selectModelDataTest"].ToolTip = string.Format("Epoch: {0}, Accuracy: {1:0.00}", locationX, testAcc);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { }
        }

        private void ActiveProcessWaitingforWork(JObject processInfo)
        {
            // 파일 Copy List 만들기
            /* processInfo
                "string_processModel": "Classification",
                "string_processTask": "Classification",
                "string_processName": "Sc3Qr",
                "string_processTrainTest": "Train",
                "string_processImageType": "SingleImage",
                "string_processPath": "C:\\Users\\USER\\AppData\\Roaming\\SynapseNet\\SynapseNet 0.1\\workspaces\\Test1\\waitingProsecce\\Sc3Qr",
                "string_workSpasceName": "Test1",
                "string_workSpaceInnerPorjectName": "0jbfjVOaHP",
                "string_processStep": "WaitingforWork"
             */

            // TrainSystem.Json 학습 Task 정보 읽어오기
            string processJsonPath = System.IO.Path.Combine(processInfo["string_processPath"].ToString(), "TrainSystem.Json");
            JObject processJObject = jsonDataManiger.GetJsonObjectShare(processJsonPath);

            string processSetImagePath = System.IO.Path.Combine(processInfo["string_processPath"].ToString(), "Image");

            // 학습에 사용되는 이미지 리스트 만들기
            List<string> imagePathList = new List<string>();
            List<string> imageSetPathList = new List<string>();

            // Couunt
            int progressValueMaxNumber = processJObject["ImageListData"].Count();
            int progressValueCountNumber = 0;
            this.SafeDataGridViewProgressValue(this.dgvMWaitingforWork, processJObject["TrainProcessInfo"]["string_processName"].ToString(), 0); // Progress Value 설정
            //
            List<string> classNames = new List<string>();

            foreach (JProperty imageInfo in processJObject["ImageListData"])
            {
                if (processJObject["ImageListData"][imageInfo.Name]["Labeled"]["bool_Train"] != null)
                {
                    if (Boolean.TryParse(processJObject["ImageListData"][imageInfo.Name]["Labeled"]["bool_Train"].ToString(), out bool trainActivate))
                        if (trainActivate)
                            if (processJObject["ImageListData"][imageInfo.Name]["Labeled"]["string_Label"] != null)
                            {
                                // 이미지 Class 가져오기
                                string imageClass = processJObject["ImageListData"][imageInfo.Name]["Labeled"]["string_Label"].ToString();

                                // 이미지 위치 추가
                                imagePathList.Add(processJObject["ImageListData"][imageInfo.Name]["string_ImagePath"].ToString());

                                // Set Image 위치 폴더 있는지 확인
                                if (CustomIOMainger.DirChackCreateName(imageClass))
                                    CustomIOMainger.DirChackExistsAndCreate(System.IO.Path.Combine(processJObject["TrainProcessInfo"]["string_processPath"].ToString(), "ImageData", "Train", imageClass));
                                else
                                    break;
                                //이미지 Set Path 추가
                                imageSetPathList.Add(System.IO.Path.Combine(processJObject["TrainProcessInfo"]["string_processPath"].ToString(), "ImageData", "Train", imageClass,
                                    System.IO.Path.GetFileName(processJObject["ImageListData"][imageInfo.Name]["string_ImagePath"].ToString())));

                                // class 관리 Lisy에 추가
                                classNames.Add(imageClass);
                            }
                }
                else if (processJObject["ImageListData"][imageInfo.Name]["Labeled"]["bool_Test"] != null)
                {
                    if (Boolean.TryParse(processJObject["ImageListData"][imageInfo.Name]["Labeled"]["bool_Test"].ToString(), out bool testActivate))
                        if (testActivate)
                            if (processJObject["ImageListData"][imageInfo.Name]["Labeled"]["string_Label"] != null)
                            {
                                // 이미지 Class 가져오기
                                string imageClass = processJObject["ImageListData"][imageInfo.Name]["Labeled"]["string_Label"].ToString();

                                // 이미지 위치 추가
                                imagePathList.Add(processJObject["ImageListData"][imageInfo.Name]["string_ImagePath"].ToString());

                                // Set Image 위치 폴더 있는지 확인
                                if (CustomIOMainger.DirChackCreateName(imageClass))
                                    CustomIOMainger.DirChackExistsAndCreate(System.IO.Path.Combine(processJObject["TrainProcessInfo"]["string_processPath"].ToString(), "ImageData", "Test", imageClass));
                                else
                                    break;
                                //이미지 Set Path 추가
                                imageSetPathList.Add(System.IO.Path.Combine(processJObject["TrainProcessInfo"]["string_processPath"].ToString(), "ImageData", "Test", imageClass,
                                    System.IO.Path.GetFileName(processJObject["ImageListData"][imageInfo.Name]["string_ImagePath"].ToString())));

                                // class 관리 Lisy에 추가
                                classNames.Add(imageClass);
                            }
                }
                progressValueCountNumber++;
                this.SafeDataGridViewProgressValue(this.dgvMWaitingforWork, processJObject["TrainProcessInfo"]["string_processName"].ToString(), (int)Math.Round((double)progressValueCountNumber / (double)progressValueMaxNumber * 100)); // Progress Value 설정
            }

            // 파일 Copy
            for (int i = 0; i < imagePathList.Count; i++)
            {
                System.IO.File.Copy(imagePathList[i], imageSetPathList[i], true);
                this.SafeDataGridViewProgressValue(this.dgvMWaitingforWork, processJObject["TrainProcessInfo"]["string_processName"].ToString(), (int)Math.Round((double)i / (double)(imagePathList.Count - 1) * 100)); // Progress Value 설정
            }

            // DataGridView WaitingforWork 값 수정
            this.SafeDataGridViewProcessStep(this.dgvMWaitingforWork, processJObject["TrainProcessInfo"]["string_processName"].ToString(), "EndPreprocess");

            // Json Class Info 값 추가
            JArray classList = new JArray();
            var disClassNames = classNames.Distinct();
            classNames = new List<string>();
            foreach (var i in disClassNames)
                classNames.Add(i.ToString());

            classNames.Sort((a, b) => a.CompareTo(b)); // Class 이름 정렬
            classList = JArray.FromObject(classNames);
            JObject trainProcessInfo = (JObject)processJObject["TrainProcessInfo"];
            trainProcessInfo["string_array_classList"] = classList; // Class 이름 넣기

            // Json 파일 저장
            processJObject["TrainProcessInfo"]["string_processStep"] = "EndPreprocess";
            jsonDataManiger.PushJsonObject(processJsonPath, processJObject);
            Thread.Sleep(300);

            /* processInfo
            "string_processModel": "Classification",
            "string_processTask": "Classification",
            "string_processName": "Sc3Qr",
            "string_processTrainTest": "Train",
            "string_processImageType": "SingleImage",
            "string_processPath": "C:\\Users\\USER\\AppData\\Roaming\\SynapseNet\\SynapseNet 0.1\\workspaces\\Test1\\waitingProsecce\\Sc3Qr",
            "string_workSpasceName": "Test1",
            "string_workSpaceInnerPorjectName": "0jbfjVOaHP",
            "string_processStep": "WaitingforWork"
            */
            if (this.processingStart)
            {
                string processTask = processInfo["string_processTask"].ToString();
                string processName = processInfo["string_processName"].ToString();
                string processTrainTest = processInfo["string_processTrainTest"].ToString();
                string processImageType = processInfo["string_processImageType"].ToString();

                this.SafeDataGridViewRowDelete(this.dgvMWaitingforWork, processName);

                this.SafeTapPageNumberChange(this.tclpMProcessActive, 1);

                this.SafeTrainFormDataGridViewAdd(this.dgvMProcessing, processTask, processTrainTest, processImageType, "EndPreprocess", processName, 0);
            }
        }

        private void ActiveProcessEndPreprocess(JObject processInfo)
        {
            // 파일 학습 가능하도록 Copy
        }

        private void ActiveProcessClassificationProcessing(JObject processInfo, string corePath)
        {
            // 학습 진행
            /* processInfo
                "string_processModel": "Classification",
                "string_processTask": "Classification",
                "string_processName": "Sc3Qr",
                "string_processTrainTest": "Train",
                "string_processImageType": "SingleImage",
                "string_processPath": "C:\\Users\\USER\\AppData\\Roaming\\SynapseNet\\SynapseNet 0.1\\workspaces\\Test1\\waitingProsecce\\Sc3Qr",
                "string_workSpasceName": "Test1",
                "string_workSpaceInnerPorjectName": "0jbfjVOaHP",
                "string_processStep": "WaitingforWork"
             */

            // core file path
            string coreProgramPath = System.IO.Path.Combine(corePath, "Classification.exe");

            // 외부 프로그램 실행시 외부 프로그램 실행 위치가 불러온 프로그램 실행위치로 변경됨
            string applicationStartupPath = System.Windows.Forms.Application.StartupPath;

            string coreProgramConfigFilePath = System.IO.Path.Combine(applicationStartupPath, "config", "clasf_dnn.cfg");
            // 설정 파일 위치를 조정해야함.

            // Train Config 파일 만들기
            // TrainSystem.Json 학습 Task 정보 읽어오기
            string processJsonPath = System.IO.Path.Combine(processInfo["string_processPath"].ToString(), "TrainSystem.Json");
            JObject processJObject = jsonDataManiger.GetJsonObjectShare(processJsonPath);

            // Epoch 값 가져오기
            int epochNumber = Convert.ToInt32(processJObject["ModelLearningInfo"]["TrainOptionManual"]["int_EpochNumber"].ToString());
            // TrainRepeat 값 가져오기
            int trainRepeat = Convert.ToInt32(processJObject["ModelLearningInfo"]["TrainOptionManual"]["int_TrainRepeat"].ToString());

            // Trian Options list 데이터로 가져오기
            List<string> trainOptions = this.TransferTrainOptionJObjectString(processJObject); //  Trian Options list 데이터로 가져오기
            // Trian Options "clasf_dnn.cfg" 파일 설정
            System.IO.File.WriteAllLines(coreProgramConfigFilePath, trainOptions);

            ProcessStartInfo classificationProcessStartInfo = new ProcessStartInfo(coreProgramPath)
            {
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Normal, //Classification.exe 출력 콘솔 숨기기
                CreateNoWindow = false,                               // cmd창을 띄우지 안도록 하기
                RedirectStandardOutput = true,        // cmd창에서 데이터를 가져오기
                RedirectStandardInput = true,          // cmd창으로 데이터 보내기
                RedirectStandardError = true          // cmd창에서 오류 내용 가져오기
            };

            Process classificationProcess = Process.Start(classificationProcessStartInfo);
            System.IO.StreamReader classificationReader = classificationProcess.StandardOutput;   // 출력되는 값을 가져오기 위해 StreamReader에 연결

            double trainEpochLoss = 0;
            double trainEpochAccuracy = 0;
            int trainEscape = 0;
            int trainOverKill = 0;

            double testEpochLoss = 0;
            double testEpochAccuracy = 0;
            int testEscape = 0;
            int testOverKill = 0;

            int processTotalEpochNumber = 1;

            bool trainErrorChack = false;

            List<string> processLogs = new List<string>(); // 로그 확인용

            Console.WriteLine("\n\n");
            Console.WriteLine("Train Core Activate");

            // 학습 완료 설정 Process Step = process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" ->  -> "Processing Results" -> "SaveResult" -> "EndProcessing"
            this.SafeDataGridViewProcessStep(this.dgvMProcessing, processInfo["string_processName"].ToString(), "Processing");

            // 차트 초기화
            this.SafeChartClear(this.chartProcessingLoss);
            this.SafeChartClear(this.chartProcessingAccuracy);

            // 학습 시작
            try
            {
                while (true)
                {
                    string classificationSystemLog = classificationReader.ReadLine();
                    processLogs.Add(classificationSystemLog); // 프로세스 로그 확인
                    Console.WriteLine(classificationSystemLog);

                    /*
                     * 확인 되야 하는 내용
                     * Ep.
                     * |t:
                     * Save Model Name
                     */
                    if (classificationSystemLog != null)
                    {
                        if (classificationSystemLog.Contains("CUDA out of memory"))
                        {
                            if (classificationProcess.HasExited)
                            {
                                trainErrorChack = true;
                                break;
                            }
                        }
                        else // "CUDA out of memory"
                        {
                            this.SafeRichTextBoxAddText(this.richTextBox1, classificationSystemLog);
                            if (classificationSystemLog.Contains("Ep."))// train stap 감지
                            {
                                int indexLoss = classificationSystemLog.IndexOf("Ls:");
                                int indexAccuracy = classificationSystemLog.IndexOf("Acc:");
                                int indexEscape = classificationSystemLog.IndexOf("|esc:");
                                int indexOverKill = classificationSystemLog.IndexOf("ovk:");

                                string stringLoss = classificationSystemLog.Substring(indexLoss, indexAccuracy - indexLoss).Trim();
                                string stringAccuracy = classificationSystemLog.Substring(indexAccuracy, indexEscape - indexAccuracy).Trim();
                                string stringEscape = classificationSystemLog.Substring(indexEscape, indexOverKill - indexEscape).Trim();
                                string stringOverKill = classificationSystemLog.Substring(indexOverKill).Trim();

                                trainEpochLoss = double.Parse(stringLoss.Split(':')[1]);
                                trainEpochAccuracy = double.Parse(stringAccuracy.Split(':')[1]);
                                trainEscape = int.Parse(stringEscape.Split(':')[1]);
                                trainOverKill = int.Parse(stringOverKill.Split(':')[1].Split('/')[0]);

                                // Train 차트 그리기
                                this.SafeChartContactSeriesAddPoint(this.chartProcessingAccuracy, "Train & Validation", processTotalEpochNumber, trainEpochAccuracy);
                                this.SafeChartContactSeriesAddPoint(this.chartProcessingLoss, "Train & Validation", processTotalEpochNumber, trainEpochLoss);

                                // Progress Bar 갱신
                                this.SafeDataGridViewProgressValue(this.dgvMProcessing, processInfo["string_processName"].ToString(), (int)Math.Round((double)((processTotalEpochNumber + 0.5) / (double)(epochNumber * trainRepeat)) * 100));
                            }
                            else if (classificationSystemLog.Contains("|t:")) // Test 감지
                            {
                                int indexLoss = classificationSystemLog.IndexOf("Ls:");
                                int indexAccuracy = classificationSystemLog.IndexOf("Acc:");
                                int indexEscape = classificationSystemLog.IndexOf("|esc:");
                                int indexOverKill = classificationSystemLog.IndexOf("ovk:");

                                string stringLoss = classificationSystemLog.Substring(indexLoss, indexAccuracy - indexLoss).Trim();
                                string stringAccuracy = classificationSystemLog.Substring(indexAccuracy, indexEscape - indexAccuracy).Trim();
                                string stringEscape = classificationSystemLog.Substring(indexEscape, indexOverKill - indexEscape).Trim();
                                string stringOverKill = classificationSystemLog.Substring(indexOverKill).Trim();

                                testEpochLoss = double.Parse(stringLoss.Split(':')[1]);
                                testEpochAccuracy = double.Parse(stringAccuracy.Split(':')[1]);
                                testEscape = int.Parse(stringEscape.Split(':')[1]);
                                testOverKill = int.Parse(stringOverKill.Split(':')[1].Split('/')[0]);

                                // 한 epoch 결과 처리
                                JObject jObject = new JObject
                                {
                                    ["int_locationX"] = processTotalEpochNumber,
                                    ["double_TrainLoss"] = trainEpochLoss,
                                    ["double_TrainAcc"] = trainEpochAccuracy,
                                    ["int_TrainEscape"] = trainEscape,
                                    ["int_TrainOverKill"] = trainOverKill,
                                    ["double_TestLoss"] = testEpochLoss,
                                    ["double_TestAcc"] = testEpochAccuracy,
                                    ["int_TestEscape"] = testEscape,
                                    ["int_TestOverKill"] = testOverKill
                                };

                                // TrainingProgressData 갱신
                                processJObject["TrainingProgressData"][processTotalEpochNumber.ToString()] = jObject;

                                // Test 차트 그리기
                                this.SafeChartContactSeriesAddPoint(this.chartProcessingAccuracy, "Test", processTotalEpochNumber, testEpochAccuracy);
                                this.SafeChartContactSeriesAddPoint(this.chartProcessingLoss, "Test", processTotalEpochNumber, testEpochLoss);

                                // Progress Bar 갱신
                                this.SafeDataGridViewProgressValue(this.dgvMProcessing, processInfo["string_processName"].ToString(), (int)Math.Round((double)(processTotalEpochNumber / (double)(epochNumber * trainRepeat)) * 100));

                                processTotalEpochNumber++;
                            }
                            if (classificationSystemLog.Contains("Save Model Name"))
                            {
                                // 모델 이름 가져오기
                                int indexSynapseNet_ = classificationSystemLog.IndexOf("SynapseNet_");
                                int indexSynapsenet = classificationSystemLog.IndexOf(".synapsenet");
                                string modelName = classificationSystemLog.Substring(indexSynapseNet_, indexSynapsenet - indexSynapseNet_).Trim();

                                // 한 epoch 결과 처리
                                JObject jObject = new JObject
                                {
                                    ["int_locationX"] = processTotalEpochNumber - 1,
                                    ["double_TrainLoss"] = trainEpochLoss,
                                    ["double_TrainAcc"] = trainEpochAccuracy,
                                    ["int_TrainEscape"] = trainEscape,
                                    ["int_TrainOverKill"] = trainOverKill,
                                    ["double_TestLoss"] = testEpochLoss,
                                    ["double_TestAcc"] = testEpochAccuracy,
                                    ["int_TestEscape"] = testEscape,
                                    ["int_TestOverKill"] = testOverKill,
                                    ["string_ModelName"] = modelName
                                };

                                // array_string_innerModelList 갱신
                                JArray innerModelList = (JArray)processJObject["array_string_innerModelList"];
                                innerModelList.Add(modelName);

                                // InnerModelInfo 갱신
                                JObject innerModelInfo = (JObject)processJObject["InnerModelInfo"];
                                innerModelInfo[modelName] = jObject;

                                // BestModelInfo 갱신
                                processJObject["BestModelInfo"] = jObject;

                                // Model 차트 그리기
                                this.SafeChartContactSeriesAddPoint(this.chartProcessingLoss, "selectModelDataTrain", processTotalEpochNumber - 1, trainEpochLoss);
                                this.SafeChartContactSeriesAddPoint(this.chartProcessingLoss, "selectModelDataTest", processTotalEpochNumber - 1, testEpochLoss);

                                this.SafeChartContactSeriesAddPoint(this.chartProcessingAccuracy, "selectModelDataTrain", processTotalEpochNumber - 1, trainEpochAccuracy);
                                this.SafeChartContactSeriesAddPoint(this.chartProcessingAccuracy, "selectModelDataTest", processTotalEpochNumber - 1, testEpochAccuracy);
                            }

                            //if (classificationSystemLog.Contains("end_of_Training"))
                            //{
                            //    //if (classificationProcess.HasExited)
                            //    //{
                            //    //    jsonDataManiger.PushJsonObject(processJsonPath, processJObject);
                            //    //    break;
                            //    //}
                            //}
                        }
                    }
                    else
                    {
                        if (classificationProcess.HasExited)
                        {
                            // 학습 완료 설정 Process Step = process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" ->  -> "Processing Results" -> "SaveResult" -> "EndProcessing"
                            this.SafeDataGridViewProcessStep(this.dgvMProcessing, processInfo["string_processName"].ToString(), "Processing Results");
                            jsonDataManiger.PushJsonObject(processJsonPath, processJObject);
                            break;
                        }
                    }
                }
            }
            catch(Exception error)
            {
                #region ERROR 처리

                Console.WriteLine("\n === === === ===");
                Console.ResetColor(); //컬러 Reset 진행
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (string processLog in processLogs)
                {
                    Console.WriteLine(processLog);
                }
                Console.ResetColor(); //컬러 Reset 진행
                Console.WriteLine("=== ERROR CODE ===");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(error);
                Console.ResetColor(); //컬러 Reset 진행
                Console.WriteLine("=== === === === \n ");
                trainErrorChack = true;

                #endregion ERROR 처리
            }

            bool instantEvaluateErrorChack = false;
            // Instant Evaluate 설정 확인
            Console.WriteLine("Instant Evaluate 설정 확인");
            if (Boolean.TryParse(processJObject["ModelLearningInfo"]["InstantEvaluate"]["bool_InstantEvaluateChecked"].ToString(), out bool instantEvaluateChecked))
            {
                if (instantEvaluateChecked)
                {
                    if (processJObject["BestModelInfo"]["string_ModelName"] != null)
                    {
                        // 학습 완료 설정 Process Step = process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" ->  "Processing Results" -> "SaveResult" -> "EndProcessing"
                        this.SafeDataGridViewProcessStep(this.dgvMProcessing, processInfo["string_processName"].ToString(), "Instant Evaluate");
                        // ProgressBar 초기화
                        this.SafeDataGridViewProgressValue(this.dgvMProcessing, processInfo["string_processName"].ToString(), 0);

                        string instantEvaluateDataset = processJObject["ModelLearningInfo"]["InstantEvaluate"]["string_InstantEvaluateDataset"].ToString();

                        List<string> imagePathList = new List<string>();
                        List<string> imageSetPathList = new List<string>();

                        if (instantEvaluateDataset == "All" || instantEvaluateDataset == "Train")
                        {
                            // 검증이 Train 이면 Test의 기존 파일 삭제
                            if (instantEvaluateDataset == "Train")
                            {
                                CustomIOMainger.DirDelete(System.IO.Path.Combine(processInfo["string_processPath"].ToString(), "ImageData", "Test"));
                            }

                            // 이미지 리스트 만들기
                            foreach (JProperty imageInfo in processJObject["ImageListData"])
                            {
                                if (processJObject["ImageListData"][imageInfo.Name]["Labeled"]["bool_Train"] != null)
                                {
                                    if (Boolean.TryParse(processJObject["ImageListData"][imageInfo.Name]["Labeled"]["bool_Train"].ToString(), out bool trainActivate))
                                        if (trainActivate)
                                            if (processJObject["ImageListData"][imageInfo.Name]["Labeled"]["string_Label"] != null)
                                            {
                                                // 이미지 Class 가져오기
                                                string imageClass = processJObject["ImageListData"][imageInfo.Name]["Labeled"]["string_Label"].ToString();

                                                // 이미지 위치 추가
                                                imagePathList.Add(processJObject["ImageListData"][imageInfo.Name]["string_ImagePath"].ToString());

                                                // 이미지 Set Path 추가
                                                imageSetPathList.Add(System.IO.Path.Combine(processJObject["TrainProcessInfo"]["string_processPath"].ToString(), "ImageData", "Test", imageClass,
                                                    System.IO.Path.GetFileName(processJObject["ImageListData"][imageInfo.Name]["string_ImagePath"].ToString())));

                                                // Set Image 위치 폴더 있는지 확인
                                                if (CustomIOMainger.DirChackCreateName(imageClass))
                                                    CustomIOMainger.DirChackExistsAndCreate(System.IO.Path.Combine(processJObject["TrainProcessInfo"]["string_processPath"].ToString(), "ImageData", "Test", imageClass));
                                                else
                                                    break;
                                            }
                                }
                            }

                            // 파일 Copy
                            for (int i = 0; i < imagePathList.Count; i++)
                            {
                                //Thread.Sleep(10);
                                System.IO.File.Copy(imagePathList[i], imageSetPathList[i], true);
                                this.SafeDataGridViewProgressValue(this.dgvMProcessing, processInfo["string_processName"].ToString(), (int)Math.Round((double)i / (double)(imagePathList.Count - 1) * 100)); // Progress Value 설정
                            }
                        }

                        // Instant Evaluate 실행
                        // 검증 모델 가져오기 Instant Evaluate 에서는 Best 모델로 검증함.
                        string bestModelName = processJObject["BestModelInfo"]["string_ModelName"].ToString();
                        string bestModelPath = System.IO.Path.Combine(applicationStartupPath, "results", "Models", bestModelName + ".synapsenet");

                        // Trian Options list 데이터로 가져오기
                        trainOptions = this.TransferEvaluationOptionJObjectString(processJObject, bestModelPath); //  검증용 (list 데이터로 가져오기)
                        System.IO.File.WriteAllLines(coreProgramConfigFilePath, trainOptions);// Trian Options "clasf_dnn.cfg" 파일 설정

                        classificationProcessStartInfo = new ProcessStartInfo(coreProgramPath)
                        {
                            UseShellExecute = false,
                            WindowStyle = ProcessWindowStyle.Normal, //Classification.exe 출력 콘솔 숨기기
                            CreateNoWindow = false,                               // cmd창을 띄우지 안도록 하기
                            RedirectStandardOutput = true,        // cmd창에서 데이터를 가져오기
                            RedirectStandardInput = true,          // cmd창으로 데이터 보내기
                            RedirectStandardError = true          // cmd창에서 오류 내용 가져오기
                        };

                        classificationProcess = Process.Start(classificationProcessStartInfo);
                        classificationReader = classificationProcess.StandardOutput;   // 출력되는 값을 가져오기 위해 StreamReader에 연결

                        // ProgressBar 초기화
                        this.SafeDataGridViewProgressValue(this.dgvMProcessing, processInfo["string_processName"].ToString(), 0);

                        // Log 가져오기
                        int time = 0;
                        while (true)
                        {
                            string classificationSystemLog = classificationReader.ReadLine();
                            Console.WriteLine(classificationSystemLog); //Log 확인

                            if (classificationSystemLog != null)
                            {
                                if (classificationSystemLog.Contains("CUDA out of memory"))
                                {
                                    if (classificationProcess.HasExited)
                                    {
                                        instantEvaluateErrorChack = true;
                                    }
                                }
                                else // "CUDA out of memory"
                                {
                                    this.SafeRichTextBoxAddText(this.richTextBox1, classificationSystemLog);
                                }
                            }
                            else
                            {
                                if (classificationProcess.HasExited)
                                    break;
                            }
                        }

                        // Instant Evaluate 에러 처리
                        if (instantEvaluateErrorChack)
                        {
                            //gggggg
                        }
                    }
                }
            }

            // 에러 없음
            // 학습 완료 설정 Process Step = process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" ->  "Processing Results" -> "SaveResult" -> "EndProcessing"
            this.SafeDataGridViewProcessStep(this.dgvMProcessing, processInfo["string_processName"].ToString(), "Processing Results");
            // ProgressBar 초기화
            this.SafeDataGridViewProgressValue(this.dgvMProcessing, processInfo["string_processName"].ToString(), 100);

            // 결과 처리로 넘기기 Done DataGridView로 정보 옮기기.
            // 에러 확인 Train & Instant Evaluate
            if (!trainErrorChack || !instantEvaluateErrorChack)
            {
                // Json 파일 저장
                processJObject["TrainProcessInfo"]["string_processStep"] = "Processing Results";
                jsonDataManiger.PushJsonObject(processJsonPath, processJObject);
                Thread.Sleep(300);

                // 데이터 읽어오기
                string processTask = processInfo["string_processTask"].ToString();
                string processName = processInfo["string_processName"].ToString();
                string processTrainTest = processInfo["string_processTrainTest"].ToString();
                string processImageType = processInfo["string_processImageType"].ToString();
                // datarow 삭제
                this.SafeDataGridViewRowDelete(this.dgvMProcessing, processName);
                // datarow 추가
                this.SafeTrainFormDataGridViewAdd(this.dgvMDoneWork, processTask, processTrainTest, processImageType, "EndPreprocess", processName, 0);
                // Tap Name Number 수정
                this.SafeTapPageNumberChange(this.tclpMProcessActive, -1);
                this.SafeTapPageNumberChange(this.tclpMProcessDone, 1);
            }
        }

        private void ActiveProcessClassificationSaveResult(JObject processInfo, string corePath, string workSpacDataPath)
        {
            // 결과 저장
            /* processInfo
                "string_processModel": "Classification",
                "string_processTask": "Classification",
                "string_processName": "Sc3Qr",
                "string_processTrainTest": "Train",
                "string_processImageType": "SingleImage",
                "string_processPath": "C:\\Users\\USER\\AppData\\Roaming\\SynapseNet\\SynapseNet 0.1\\workspaces\\Test1\\waitingProsecce\\Sc3Qr",
                "string_workSpasceName": "Test1",
                "string_workSpaceInnerPorjectName": "0jbfjVOaHP",
                "string_processStep": "WaitingforWork"
             */
            // 프로세스 단계 Process Step = process 단계 !!"WaitingforWork" -> !!"EndPreprocess" -> "Processing" ->  "!!Processing Results" -> "!!SaveResult" -> "!!EndProcessing"
            // 진입 Processing Results
            // 외부 프로그램 실행시 외부 프로그램 실행 위치가 불러온 프로그램 실행위치로 변경됨
            string applicationStartupPath = System.Windows.Forms.Application.StartupPath;

            string processAccessCode = processInfo["string_processName"].ToString();

            // TrainSystem.Json 학습 Task 정보 읽어오기
            string processJsonPath = System.IO.Path.Combine(processInfo["string_processPath"].ToString(), "TrainSystem.Json");
            JObject processJObject = jsonDataManiger.GetJsonObjectShare(processJsonPath);

            // 결과 파일 경로
            string resultsFilePath = System.IO.Path.Combine(applicationStartupPath, "results");
            string resultsEvalsFilePath = System.IO.Path.Combine(resultsFilePath, "Evals");
            string resultsHeatmapsFilePath = System.IO.Path.Combine(resultsFilePath, "Heat_maps");
            string resultsModelsFilePath = System.IO.Path.Combine(resultsFilePath, "Models");
            string resultsLogsFilePath = System.IO.Path.Combine(resultsFilePath, "Logs");

            // 모델 관리 파일 경로
            string workSpasceName = processJObject["TrainProcessInfo"]["string_workSpasceName"].ToString();
            string workSpaceInnerPorjectName = processJObject["TrainProcessInfo"]["string_workSpaceInnerPorjectName"].ToString();
            string projectAccessModelName = processJObject["TrainProcessInfo"]["string_projectAccessModelName"].ToString();

            string projectModelManagementPath = System.IO.Path.Combine(workSpacDataPath, workSpasceName, "model", workSpaceInnerPorjectName, projectAccessModelName);
            string projectModelEvalsPath = System.IO.Path.Combine(projectModelManagementPath, "evals");
            string projectModelHeatmapsPath = System.IO.Path.Combine(projectModelManagementPath, "heatmap");
            string projectModelModelsPath = System.IO.Path.Combine(projectModelManagementPath, "models");

            // Data Grid View Step 설정
            processJObject["TrainProcessInfo"]["string_processStep"] = "SaveResult";
            jsonDataManiger.PushJsonObject(processJsonPath, processJObject);

            // 모델 관리 폴더 만들기
            CustomIOMainger.DirChackExistsAndCreate(projectModelManagementPath);
            CustomIOMainger.DirChackExistsAndCreate(projectModelEvalsPath);
            CustomIOMainger.DirChackExistsAndCreate(projectModelHeatmapsPath);
            CustomIOMainger.DirChackExistsAndCreate(projectModelModelsPath);

            // 모델 파일 이동
            JArray innerModelList = (JArray)processJObject["array_string_innerModelList"];
            string[] modelList = innerModelList.Select(jv => (string)jv).ToArray();
            modelList.Reverse();

            int count = modelList.Count();

            try
            {
                System.IO.Directory.Move(System.IO.Path.Combine(resultsHeatmapsFilePath, "Heat_maps_0"), System.IO.Path.Combine(projectModelHeatmapsPath, modelList[0]));
            }
            catch { }

            foreach (string fileName in CustomIOMainger.DirFileSerch(resultsEvalsFilePath, "Full"))
            {
                System.IO.File.Copy(fileName, System.IO.Path.Combine(projectModelEvalsPath, modelList[0]), true);
                break;
            }

            for (int i = 0; i < count; i++)
            {
                System.IO.File.Copy(System.IO.Path.Combine(resultsModelsFilePath, modelList[i] + ".synapsenet"), System.IO.Path.Combine(projectModelModelsPath, modelList[i] + ".synapsenet"), true);

                this.SafeDataGridViewProgressValue(this.dgvMDoneWork, processAccessCode, (int)Math.Round((double)i / (count - 1) * 100));
            }
            this.SafeDataGridViewProgressValue(this.dgvMDoneWork, processAccessCode, 100);

            // 기존 파일 삭제, 폴더 생성
            CustomIOMainger.DirDelete(resultsEvalsFilePath);
            CustomIOMainger.DirDelete(resultsHeatmapsFilePath);
            CustomIOMainger.DirDelete(resultsModelsFilePath);
            CustomIOMainger.DirDelete(resultsLogsFilePath);

            CustomIOMainger.DirChackExistsAndCreate(resultsEvalsFilePath);
            CustomIOMainger.DirChackExistsAndCreate(resultsHeatmapsFilePath);
            CustomIOMainger.DirChackExistsAndCreate(resultsModelsFilePath);
            CustomIOMainger.DirChackExistsAndCreate(resultsLogsFilePath);

            // Data 결과 저장 완료 Data 설정
            // 프로세스 단계 Process Step = process 단계 !!"WaitingforWork" -> !!"EndPreprocess" -> "Processing" ->  "!!Processing Results" -> "!!SaveResult" -> "!!EndProcessing"
            // Data Grid View Step 설정
            processJObject["TrainProcessInfo"]["string_processStep"] = "EndProcessing";
            jsonDataManiger.PushJsonObject(processJsonPath, processJObject);
            // Tap contral number 변경
            this.SafeTapPageNumberChange(this.tclpMProcessDone, -1);
        }

        private void ActiveProcessEndProcessing()
        {
            // 학습 임시파일 식제
        }

        /// <summary>
        /// Train Option List string 으로 가져오기
        /// </summary>
        /// <param name="modelLearningInfo"></param>
        /// <returns></returns>
        private List<string> TransferTrainOptionJObjectString(JObject modelLearningInfo)
        {
            List<string> trainOptions = new List<string>();

            #region Trian Options 가져오기

            // Trian Options 수동
            string networkModel = modelLearningInfo["ModelLearningInfo"]["TrainOptionManual"]["string_NetworkModel"].ToString();
            string epochNumber = modelLearningInfo["ModelLearningInfo"]["TrainOptionManual"]["int_EpochNumber"].ToString();
            string trainRepeat = modelLearningInfo["ModelLearningInfo"]["TrainOptionManual"]["int_TrainRepeat"].ToString();
            string modelMinimumSelectionEpoch = modelLearningInfo["ModelLearningInfo"]["TrainOptionManual"]["int_ModelMinimumSelectionEpoch"].ToString();
            string validationRatio = modelLearningInfo["ModelLearningInfo"]["TrainOptionManual"]["int_ValidationRatio"].ToString();
            string patienceEpochs = modelLearningInfo["ModelLearningInfo"]["TrainOptionManual"]["int_PatienceEpochs"].ToString();

            trainOptions.Add(PackingString($"dnn_type |{networkModel}|"));
            trainOptions.Add(PackingString($"epoch_n |{epochNumber}|"));
            trainOptions.Add(PackingString($"train_repeat |{trainRepeat}|"));
            trainOptions.Add(PackingString($"n_ep_no_save |{modelMinimumSelectionEpoch}|"));
            trainOptions.Add(PackingString($"val_ratio |{validationRatio}|"));
            trainOptions.Add(PackingString($"max_ep_loss_up |{patienceEpochs}|"));

            // Trian Options 자동
            string batchSize = modelLearningInfo["ModelLearningInfo"]["TrainOptionAuto"]["int_BatchSize"].ToString();
            string startLearningrate = modelLearningInfo["ModelLearningInfo"]["TrainOptionAuto"]["double_StartLearningrate"].ToString();
            string lossUpPatienceDeltaRatio = modelLearningInfo["ModelLearningInfo"]["TrainOptionAuto"]["double_LossUpPatienceDeltaRatio"].ToString();
            string learningrate = modelLearningInfo["ModelLearningInfo"]["TrainOptionAuto"]["double_Learningrate"].ToString();
            string minimalLearningRate = modelLearningInfo["ModelLearningInfo"]["TrainOptionAuto"]["double_MinimalLearningRate"].ToString();

            trainOptions.Add(PackingString($"batch_sz |{batchSize}|"));
            trainOptions.Add(PackingString($"lr_0 |{startLearningrate}|"));
            trainOptions.Add(PackingString($"loss_up_delta |{lossUpPatienceDeltaRatio}|"));
            trainOptions.Add(PackingString($"new_lr_ratio |{learningrate}|"));
            trainOptions.Add(PackingString($"lr_min |{minimalLearningRate}|"));

            // Trian Options 사용 안함
            string pretrained = modelLearningInfo["ModelLearningInfo"]["TrainOptionNotDefine"]["double_Pretrained"].ToString();

            trainOptions.Add(PackingString($"pretrained |{pretrained}|"));

            #endregion Trian Options 가져오기

            #region Data Augmentation 데이터 증강 옵션

            // DataAugmentationManual 옵션 설정
            // Blur 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_BlurChecked"].ToString(), out bool blurChecked))
            {
                if (blurChecked)
                    trainOptions.Add(PackingString($"blur |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_Blur"].ToString()}|"));
                else
                    trainOptions.Add(PackingString($"blur |{0}|"));
            }
            else
                trainOptions.Add(PackingString($"blur |{0}|"));
            // brightness 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_BrightnessChecked"].ToString(), out bool brightnessChecked))
            {
                if (brightnessChecked)
                {
                    trainOptions.Add(PackingString($"brightness_min |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_BrightnessMin"].ToString()}|"));
                    trainOptions.Add(PackingString($"brightness_max |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_BrightnessMax"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"brightness_min |{0}|"));
                    trainOptions.Add(PackingString($"brightness_max |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"brightness_min |{0}|"));
                trainOptions.Add(PackingString($"brightness_max |{0}|"));
            }
            // Center 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_CenterChecked"].ToString(), out bool centerChecked))
            {
                if (centerChecked)
                {
                    trainOptions.Add(PackingString($"center |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_Center"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"center |{1}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"center |{1}|"));
            }
            // Contrast 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_ContrastChecked"].ToString(), out bool contrastChecked))
            {
                if (contrastChecked)
                {
                    trainOptions.Add(PackingString($"contrast_min |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_ContrastMin"].ToString()}|"));
                    trainOptions.Add(PackingString($"contrast_max |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_ContrastMax"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"contrast_min |{1}|"));
                    trainOptions.Add(PackingString($"contrast_max |{1}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"contrast_min |{1}|"));
                trainOptions.Add(PackingString($"contrast_max |{1}|"));
            }
            // GaussianNoise 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_GaussianNoiseChecked"].ToString(), out bool gaussianNoiseChecked))
            {
                if (gaussianNoiseChecked)
                {
                    trainOptions.Add(PackingString($"noise |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_GaussianNoise"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"noise |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"noise |{0}|"));
            }
            // Gradation 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_GradationChecked"].ToString(), out bool gradationChecked))
            {
                if (gradationChecked)
                {
                    trainOptions.Add(PackingString($"gradation |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_Gradation"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"gradation |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"gradation |{0}|"));
            }
            // GradationRGB 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_GradationRGBChecked"].ToString(), out bool gradationRGBChecked))
            {
                if (gradationRGBChecked)
                {
                    trainOptions.Add(PackingString($"grad_color |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_GradationRGB"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"grad_color |0 0 255|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"grad_color |0 0 255|"));
            }
            // HorizontalFlip 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_HorizontalFlipChecked"].ToString(), out bool horizontalFlipChecked))
            {
                if (horizontalFlipChecked)
                {
                    trainOptions.Add(PackingString($"horiz_flip |{1}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"horiz_flip |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"horiz_flip |{0}|"));
            }
            // Rotation90 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_Rotation90Checked"].ToString(), out bool rotation90Checked))
            {
                if (rotation90Checked)
                {
                    trainOptions.Add(PackingString($"rot90 |{1}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"rot90 |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"rot90 |{0}|"));
            }
            // Rotation180 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_Rotation180Checked"].ToString(), out bool rotation180Checked))
            {
                if (rotation180Checked)
                {
                    trainOptions.Add(PackingString($"rot180 |{1}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"rot180 |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"rot180 |{0}|"));
            }
            // Rotation270 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_Rotation270Checked"].ToString(), out bool rotation270Checked))
            {
                if (rotation270Checked)
                {
                    trainOptions.Add(PackingString($"rot270 |{1}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"rot270 |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"rot270 |{0}|"));
            }
            // Sharpen 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_SharpenChecked"].ToString(), out bool sharpenChecked))
            {
                if (rotation270Checked)
                {
                    trainOptions.Add(PackingString($"sharpen |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_Sharpen"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"sharpen |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"sharpen |{0}|"));
            }
            // VerticalFlip 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_VerticalFlipChecked"].ToString(), out bool verticalFlipChecked))
            {
                if (verticalFlipChecked)
                {
                    trainOptions.Add(PackingString($"vert_flip |{1}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"vert_flip |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"vert_flip |{0}|"));
            }
            // Zoom 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_ZoomChecked"].ToString(), out bool zoomChecked))
            {
                if (zoomChecked)
                {
                    trainOptions.Add(PackingString($"zoom_min |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_ZoomMin"].ToString()}|"));
                    trainOptions.Add(PackingString($"zoom_max |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_ZoomMax"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"zoom_min |{1}|"));
                    trainOptions.Add(PackingString($"zoom_max |{1}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"zoom_min |{1}|"));
                trainOptions.Add(PackingString($"zoom_max |{1}|"));
            }

            // DataAugmentationNotDefine 옵션 설정
            // HorizontalFlipSave
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationNotDefine"]["bool_HorizontalFlipSave"].ToString(), out bool horizontalFlipSave))
            {
                if (horizontalFlipSave)
                {
                    trainOptions.Add(PackingString($"n_horiz_flip |{0}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"n_horiz_flip |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"n_horiz_flip |{0}|"));
            }
            // VerticalFlipSave
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationNotDefine"]["bool_VerticalFlipSave"].ToString(), out bool verticalFlipSave))
            {
                if (verticalFlipSave)
                {
                    trainOptions.Add(PackingString($"n_vert_flip |{0}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"n_vert_flip |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"n_vert_flip |{0}|"));
            }

            #endregion Data Augmentation 데이터 증강 옵션

            #region ContinualLearning 설정

            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["ContinualLearning"]["bool_ContinualLearningChecked"].ToString(), out bool continualLearningChecked))
            {
                if (continualLearningChecked)
                {
                    trainOptions.Add(PackingString($"dnn_file |{modelLearningInfo["ModelLearningInfo"]["ContinualLearning"]["string_ContinualLearning"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"dnn_file |{"default"}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"dnn_file |{"default"}|")); //default ro new
            }
            #endregion ContinualLearning 설정



            #region ClassWeight 가져오기

            string classWeight = null;
            foreach (string className in modelLearningInfo["TrainProcessInfo"]["string_array_classList"])
            {
                if (classWeight == null)
                    classWeight = modelLearningInfo["ModelLearningInfo"]["ClassWeight"][className].ToString();
                else
                    classWeight += ", " + modelLearningInfo["ModelLearningInfo"]["ClassWeight"][className].ToString();
            }
            if (classWeight != null)
                trainOptions.Add(PackingString($"loss_wt |{classWeight}|"));
            else
                trainOptions.Add(PackingString($"loss_wt |auto|")); // auto ro 1
            #endregion ClassWeight 가져오기



            #region 데이터 옵션 설정

            string dataPath = System.IO.Path.Combine(modelLearningInfo["TrainProcessInfo"]["string_processPath"].ToString(), "ImageData");
            trainOptions.Add(PackingString($"dts_path |{dataPath}|"));
            trainOptions.Add(PackingString($"dts_pth_lst ||"));
            trainOptions.Add(PackingString($"train_dir |Train|"));
            trainOptions.Add(PackingString($"test_dir |Test|"));
            #endregion 데이터 옵션 설정



            #region 이미지 설정

            trainOptions.Add(PackingString($"img_chnl |{modelLearningInfo["ModelLearningInfo"]["ImageOption"]["int_imageChannel"].ToString()}|"));
            trainOptions.Add(PackingString($"img_sz |{modelLearningInfo["ModelLearningInfo"]["ImageOption"]["int_imageSize"].ToString()}|"));

            #endregion 이미지 설정



            #region 시스템 설정 옵션
            trainOptions.Add(PackingString($"tr_wrk |{modelLearningInfo["ModelLearningInfo"]["TrainSystemOption"]["int_dataLoaderNUmberofWorkers"].ToString()}|"));

            trainOptions.Add(PackingString($"eval |n|"));
            trainOptions.Add(PackingString($"heat_map |n|"));
            trainOptions.Add(PackingString($"progress_bar |n|"));
            trainOptions.Add(PackingString($"help ? h ||"));

            #endregion 시스템 설정 옵션

            return trainOptions;
        }

        private List<string> TransferEvaluationOptionJObjectString(JObject modelLearningInfo, string ModelPath)
        {
            List<string> trainOptions = new List<string>();

            #region Trian Options 가져오기

            // Trian Options 수동
            string networkModel = modelLearningInfo["ModelLearningInfo"]["TrainOptionManual"]["string_NetworkModel"].ToString();
            string epochNumber = modelLearningInfo["ModelLearningInfo"]["TrainOptionManual"]["int_EpochNumber"].ToString();
            string trainRepeat = modelLearningInfo["ModelLearningInfo"]["TrainOptionManual"]["int_TrainRepeat"].ToString();
            string modelMinimumSelectionEpoch = modelLearningInfo["ModelLearningInfo"]["TrainOptionManual"]["int_ModelMinimumSelectionEpoch"].ToString();
            string validationRatio = modelLearningInfo["ModelLearningInfo"]["TrainOptionManual"]["int_ValidationRatio"].ToString();
            string patienceEpochs = modelLearningInfo["ModelLearningInfo"]["TrainOptionManual"]["int_PatienceEpochs"].ToString();

            trainOptions.Add(PackingString($"dnn_type |{networkModel}|"));
            trainOptions.Add(PackingString($"epoch_n |{0}|"));
            trainOptions.Add(PackingString($"train_repeat |{1}|"));
            trainOptions.Add(PackingString($"n_ep_no_save |{modelMinimumSelectionEpoch}|"));
            trainOptions.Add(PackingString($"val_ratio |{validationRatio}|"));
            trainOptions.Add(PackingString($"max_ep_loss_up |{patienceEpochs}|"));

            // Trian Options 자동
            string batchSize = modelLearningInfo["ModelLearningInfo"]["TrainOptionAuto"]["int_BatchSize"].ToString();
            string startLearningrate = modelLearningInfo["ModelLearningInfo"]["TrainOptionAuto"]["double_StartLearningrate"].ToString();
            string lossUpPatienceDeltaRatio = modelLearningInfo["ModelLearningInfo"]["TrainOptionAuto"]["double_LossUpPatienceDeltaRatio"].ToString();
            string learningrate = modelLearningInfo["ModelLearningInfo"]["TrainOptionAuto"]["double_Learningrate"].ToString();
            string minimalLearningRate = modelLearningInfo["ModelLearningInfo"]["TrainOptionAuto"]["double_MinimalLearningRate"].ToString();

            trainOptions.Add(PackingString($"batch_sz |{batchSize}|"));
            trainOptions.Add(PackingString($"lr_0 |{startLearningrate}|"));
            trainOptions.Add(PackingString($"loss_up_delta |{lossUpPatienceDeltaRatio}|"));
            trainOptions.Add(PackingString($"new_lr_ratio |{learningrate}|"));
            trainOptions.Add(PackingString($"lr_min |{minimalLearningRate}|"));

            // Trian Options 사용 안함
            string pretrained = modelLearningInfo["ModelLearningInfo"]["TrainOptionNotDefine"]["double_Pretrained"].ToString();

            trainOptions.Add(PackingString($"pretrained |{pretrained}|"));

            #endregion Trian Options 가져오기

            #region Data Augmentation 데이터 증강 옵션

            // DataAugmentationManual 옵션 설정
            // Blur 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_BlurChecked"].ToString(), out bool blurChecked))
            {
                if (blurChecked)
                    trainOptions.Add(PackingString($"blur |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_Blur"].ToString()}|"));
                else
                    trainOptions.Add(PackingString($"blur |{0}|"));
            }
            else
                trainOptions.Add(PackingString($"blur |{0}|"));
            // brightness 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_BrightnessChecked"].ToString(), out bool brightnessChecked))
            {
                if (brightnessChecked)
                {
                    trainOptions.Add(PackingString($"brightness_min |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_BrightnessMin"].ToString()}|"));
                    trainOptions.Add(PackingString($"brightness_max |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_BrightnessMax"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"brightness_min |{0}|"));
                    trainOptions.Add(PackingString($"brightness_max |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"brightness_min |{0}|"));
                trainOptions.Add(PackingString($"brightness_max |{0}|"));
            }
            // Center 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_CenterChecked"].ToString(), out bool centerChecked))
            {
                if (centerChecked)
                {
                    trainOptions.Add(PackingString($"center |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_Center"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"center |{1}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"center |{1}|"));
            }
            // Contrast 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_ContrastChecked"].ToString(), out bool contrastChecked))
            {
                if (contrastChecked)
                {
                    trainOptions.Add(PackingString($"contrast_min |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_ContrastMin"].ToString()}|"));
                    trainOptions.Add(PackingString($"contrast_max |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_ContrastMax"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"contrast_min |{1}|"));
                    trainOptions.Add(PackingString($"contrast_max |{1}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"contrast_min |{1}|"));
                trainOptions.Add(PackingString($"contrast_max |{1}|"));
            }
            // GaussianNoise 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_GaussianNoiseChecked"].ToString(), out bool gaussianNoiseChecked))
            {
                if (gaussianNoiseChecked)
                {
                    trainOptions.Add(PackingString($"noise |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_GaussianNoise"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"noise |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"noise |{0}|"));
            }
            // Gradation 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_GradationChecked"].ToString(), out bool gradationChecked))
            {
                if (gradationChecked)
                {
                    trainOptions.Add(PackingString($"gradation |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_Gradation"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"gradation |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"gradation |{0}|"));
            }
            // GradationRGB 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_GradationRGBChecked"].ToString(), out bool gradationRGBChecked))
            {
                if (gradationRGBChecked)
                {
                    trainOptions.Add(PackingString($"grad_color |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_GradationRGB"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"grad_color |0 0 255|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"grad_color |0 0 255|"));
            }
            // HorizontalFlip 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_HorizontalFlipChecked"].ToString(), out bool horizontalFlipChecked))
            {
                if (horizontalFlipChecked)
                {
                    trainOptions.Add(PackingString($"horiz_flip |{1}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"horiz_flip |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"horiz_flip |{0}|"));
            }
            // Rotation90 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_Rotation90Checked"].ToString(), out bool rotation90Checked))
            {
                if (rotation90Checked)
                {
                    trainOptions.Add(PackingString($"rot90 |{1}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"rot90 |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"rot90 |{0}|"));
            }
            // Rotation180 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_Rotation180Checked"].ToString(), out bool rotation180Checked))
            {
                if (rotation180Checked)
                {
                    trainOptions.Add(PackingString($"rot180 |{1}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"rot180 |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"rot180 |{0}|"));
            }
            // Rotation270 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_Rotation270Checked"].ToString(), out bool rotation270Checked))
            {
                if (rotation270Checked)
                {
                    trainOptions.Add(PackingString($"rot270 |{1}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"rot270 |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"rot270 |{0}|"));
            }
            // Sharpen 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_SharpenChecked"].ToString(), out bool sharpenChecked))
            {
                if (rotation270Checked)
                {
                    trainOptions.Add(PackingString($"sharpen |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_Sharpen"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"sharpen |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"sharpen |{0}|"));
            }
            // VerticalFlip 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_VerticalFlipChecked"].ToString(), out bool verticalFlipChecked))
            {
                if (verticalFlipChecked)
                {
                    trainOptions.Add(PackingString($"vert_flip |{1}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"vert_flip |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"vert_flip |{0}|"));
            }
            // Zoom 설정
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_ZoomChecked"].ToString(), out bool zoomChecked))
            {
                if (zoomChecked)
                {
                    trainOptions.Add(PackingString($"zoom_min |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_ZoomMin"].ToString()}|"));
                    trainOptions.Add(PackingString($"zoom_max |{modelLearningInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_ZoomMax"].ToString()}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"zoom_min |{1}|"));
                    trainOptions.Add(PackingString($"zoom_max |{1}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"zoom_min |{1}|"));
                trainOptions.Add(PackingString($"zoom_max |{1}|"));
            }

            // DataAugmentationNotDefine 옵션 설정
            // HorizontalFlipSave
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationNotDefine"]["bool_HorizontalFlipSave"].ToString(), out bool horizontalFlipSave))
            {
                if (horizontalFlipSave)
                {
                    trainOptions.Add(PackingString($"n_horiz_flip |{0}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"n_horiz_flip |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"n_horiz_flip |{0}|"));
            }
            // VerticalFlipSave
            if (Boolean.TryParse(modelLearningInfo["ModelLearningInfo"]["DataAugmentationNotDefine"]["bool_VerticalFlipSave"].ToString(), out bool verticalFlipSave))
            {
                if (verticalFlipSave)
                {
                    trainOptions.Add(PackingString($"n_vert_flip |{0}|"));
                }
                else
                {
                    trainOptions.Add(PackingString($"n_vert_flip |{0}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"n_vert_flip |{0}|"));
            }

            #endregion Data Augmentation 데이터 증강 옵션

            trainOptions.Add(PackingString($"dnn_file |{ModelPath}|")); //default ro new

            #region ClassWeight 가져오기

            string classWeight = null;
            foreach (string className in modelLearningInfo["TrainProcessInfo"]["string_array_classList"])
            {
                if (classWeight == null)
                    classWeight = modelLearningInfo["ModelLearningInfo"]["ClassWeight"][className].ToString();
                else
                    classWeight += ", " + modelLearningInfo["ModelLearningInfo"]["ClassWeight"][className].ToString();
            }
            if (classWeight != null)
                trainOptions.Add(PackingString($"loss_wt |{classWeight}|"));
            else
                trainOptions.Add(PackingString($"loss_wt |auto|")); // auto ro 1
            #endregion ClassWeight 가져오기



            #region 데이터 옵션 설정

            string dataPath = System.IO.Path.Combine(modelLearningInfo["TrainProcessInfo"]["string_processPath"].ToString(), "ImageData");
            trainOptions.Add(PackingString($"dts_path |{dataPath}|"));
            trainOptions.Add(PackingString($"dts_pth_lst ||"));
            trainOptions.Add(PackingString($"train_dir |Train|"));
            trainOptions.Add(PackingString($"test_dir |Test|"));
            #endregion 데이터 옵션 설정



            #region 이미지 설정

            trainOptions.Add(PackingString($"img_chnl |{modelLearningInfo["ModelLearningInfo"]["ImageOption"]["int_imageChannel"].ToString()}|"));
            trainOptions.Add(PackingString($"img_sz |{modelLearningInfo["ModelLearningInfo"]["ImageOption"]["int_imageSize"].ToString()}|"));

            #endregion 이미지 설정

            #region 시스템 설정 옵션

            trainOptions.Add(PackingString($"tr_wrk |{modelLearningInfo["ModelLearningInfo"]["TrainSystemOption"]["int_dataLoaderNUmberofWorkers"].ToString()}|"));

            trainOptions.Add(PackingString($"eval |y|"));
            trainOptions.Add(PackingString($"heat_map |y|"));
            trainOptions.Add(PackingString($"progress_bar |n|"));
            trainOptions.Add(PackingString($"help ? h ||"));

            #endregion 시스템 설정 옵션

            return trainOptions;
        }

        private string PackingString(string data)
        {
            return ("{" + data + "}");
        }

        /// <summary>
        /// 프로세스 작업 추가
        /// </summary>
        /// <param name="processOption"></param>
        /// <param name="imageListData"></param>
        /// <param name="processTask"> "Classification", "Segmentation", "ObjectDetection" </param>
        /// <param name="processTrainTest"> 프로세스 Train Test 여부 </param>
        /// <param name="processInputDataType"> 프로세스 Input Data Type </param>
        /// <param name="processWorkSpasceName"></param>
        /// <param name="ProcessWorkSpaceInnerPorjectName"></param>
        public void ClassificationPushTrainData(JObject processOption, JObject imageListData,
            string processTask, string processTrainTest, string processInputDataType, string processWorkSpasceName, string ProcessWorkSpaceInnerPorjectName)
        {
            /* Train 대기열에 추가하기
             *
             * 0 등록 시도하는 Process 검증
             * 0-1 생성된 WorkSpace List 가져와서 등록된 WorkSpace와 비교
             * 0-2 등록된 WorkSpace를 활성화된 WorkSpace가 있는지 확인
             * 0-3 활성화 여부에 따라서 조건 설정
             *
             * 1 학습에 필요한 정보 읽고 정보 추가하기 JObject "TrainprocessInfo" 추가
             * 1-1 학습 모델 읽고 프로세스 모델 정보 입력 "processModel" -> "Classification", "Segmentation", "ObjectDetection"
             * 1-2 입력도니 ProcessTask를 통해서 학습, 검증인지 확인후 정보 추가 "ProcessTask" -> "Train". "Test"
             * 1-3 등록되어 있는 Process 이름 검색후 임시 이름 부여하고 "ProcessName", "ProcessPath" 설정 하기
             * 1-4 등록하는 WorkSpace Name 저장, WorkSpace InnerPorject Name 저장
             * 1-5 생성된 정보 JObject 형식으로 만들기
             *
             * 2. 학습 옵션 데이터 관리 데이터로 변경 - 문서 파일에 예시 있음. ModelInfo1.Json
             * 2-1 빈 JArray "array_string_InnerModelList" 추가 -> 저장되는 Inner Model 파일 List
             * 2-2 빈 JObject "InnerModelInfo" 추가 -> 저장된 Inner Model Info
             * 2-3 빈 JObject "TrainingProgressData" 추가 -> 학습 진행시 각 Epoch 마다 출력되는 Loss , Accuracy, Escape, OverKill (Train, Test) 정보 저장
             * 2-4 입력된 JObject trainOption "ModelLearningInfo" 내부에 추가
             * 2-5 빈 JObject "BestModelInfo" 추가 -> 마지막에 저장된 Best Model 저장
             * 2-6 입력된 JObject imageListData "ImageListData" 내부에 추가
             * 2-7 1에서 생성된 JObject "TrainprocessInfo" 추가
             *
             * 3. 학습 데이터 관리 Dictionary 데이터 추가하기
             * 3-1 정리된 데이터 TrainprocessInfo processName을 Key 값으로 하여서 학습 데이터 관리 Dictionary 데이터 추가하기 -> trainProcessData
             * 3-2 정리된 데이터 TrainprocessInfo processName을 Key 값으로 하여서 학습 ProgressBar Dictionary ProgressBar 추가하기 -> trainProcessProgressBar
             *
             * 4. WorkSpaceEarlyData.m_trainFormJobject 데이터 등록하기
             * // process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "Processing Results" -> "SaveResult" -> "EndProcessing"
             *
             * 5. 관리 폴더, 파일 생성
             */

            // 0 등록 시도하는 process 검증
            // 0-1. 생성된 WorkSpace List 가져와서 등록된 WorkSpace와 비교
            bool chackWorkSpace = false;
            foreach (string workSpaceName in WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceNameList"])
            {
                if (workSpaceName == processWorkSpasceName)
                {
                    chackWorkSpace = true;
                    break;
                }
            }

            bool chackActiveWorkSpace = false;
            // 0-2. 등록된 WorkSpace를 활성화된 WorkSpace가 있는지 확인
            foreach (string workSpaceName in WorkSpaceData.m_projectMaingersDictionary.Keys)
            {
                if (workSpaceName == processWorkSpasceName)
                {
                    chackActiveWorkSpace = true;
                    break;
                }
            }
            // 0-3 활성화 여부에 따라서 조건 설정
            if (!chackWorkSpace || !chackActiveWorkSpace)
            {
                Console.WriteLine("=== === === === === === ===");
                Console.WriteLine("False Process Registration"); // 등록 실패
                Console.WriteLine("=== === === === === === ===");
                return;
            }

            // 1 학습에 필요한 정보 읽고 정보 추가하기 JObject "TrainprocessInfo" 추가
            // 1-1 학습 모델 읽고 프로세스 모델 정보 입력 "processModel" -> "Classification", "Segmentation", "ObjectDetection"
            string networkModel = processOption["TrainOptionManual"]["string_NetworkModel"].ToString();
            string processModel;

            if (networkModel.Contains("Classification"))
                processModel = "Classification";
            else if (networkModel.Contains("Segmentation"))
                processModel = "Segmentation";
            else if (networkModel.Contains("ObjectDetection"))
                processModel = "ObjectDetection";
            else
                processModel = "Classification";

            // 1-2 입력된 processTask를 통해서 학습, 검증인지 확인후 정보 추가 "processTask" -> "Train". "Test"
            // === processTask 읽기

            // 1-4 등록하는 WorkSpace Name 저장, WorkSpace InnerPorject Name 저장

            // 1-3 등록되어 있는 process 이름 검색후 임시 이름 부여하고 "processName", "processPath" 설정 하기
            List<string> processNames = new List<string>();
            foreach (string processNAme in WorkSpaceEarlyData.m_trainFormJobject["processList"])
            {
                processNames.Add(processNAme); // 기존 프로세스 이름 가져오기
            }
            string processName = CustomIOMainger.RandomFileName(processNames, 5); // 프로세스 임시 이름 만들기

            // Path 정보 만들기
            string ProcessPath = System.IO.Path.Combine(WorkSpaceData.m_projectMaingersDictionary[processWorkSpasceName].m_pathActiveProjectWaitingProcess, processName);

            //  1-4 생성된 정보 JObject 형식으로 만들기
            JObject trainProcessInfo = new JObject
            {
                ["string_processModel"] = processModel, // 프로세스 모델 정보  "Classification", "Segmentation", "ObjectDetection"
                ["string_processTask"] = processTask, // 프로세스 Task 정보 "Classification", "Segmentation", "ObjectDetection"
                ["string_processName"] = processName, // 프로세스 이름 정보
                ["string_processTrainTest"] = processTrainTest, // 프로세스 이름 정보
                ["string_processImageType"] = processInputDataType, // 프로세스 Input Data type
                ["string_processPath"] = ProcessPath,  // 프로세스 경로 정보
                ["string_workSpasceName"] = processWorkSpasceName,  // 등록된 WorkSpace 이름
                ["string_workSpaceInnerPorjectName"] = ProcessWorkSpaceInnerPorjectName, // 등록된 WorkSpaceInnerPorject 이름
                ["string_processStep"] = "WaitingforWork" // process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "Processing Results" -> "SaveResult" -> "EndProcessing"
        };

            // 2. 학습 옵션 데이터 관리 데이터로 변경 - 문서 파일에 예시 있음. ModelInfo1.Json
            JObject processInfo = new JObject
            {
                // 2-1 빈 JArray "array_string_InnerModelList" 추가 -> 저장되는 Inner Model 파일 List
                ["array_string_innerModelList"] = new JArray(),
                // 2-2 빈 JObject "InnerModelInfo" 추가 -> 저장된 Inner Model Info
                ["InnerModelInfo"] = new JObject(),
                // 2-3 빈 JObject "TrainingProgressData" 추가 -> 학습 진행시 각 Epoch 마다 출력되는 Loss , Accuracy, Escape, OverKill (Train, Test) 정보 저장
                ["TrainingProgressData"] = new JObject(),
                // 2-4 입력된 JObject trainOption "ModelLearningInfo" 내부에 추가
                ["ModelLearningInfo"] = processOption,
                // 2-5 빈 JObject "BestModelInfo" 추가 -> 마지막에 저장된 Best Model 저장
                ["BestModelInfo"] = new JObject(),
                // 2-6 입력된 JObject imageListData "ImageListData" 내부에 추가
                ["ImageListData"] = imageListData,
                // 2-7 1에서 생성된 JObject "TrainprocessInfo" 추가
                ["TrainProcessInfo"] = trainProcessInfo
            }; //  process 정보

            // 3. 학습 데이터 관리 Dictionary 데이터 추가하기

            ProjectAI.JsonDataManiger jsonDataManiger = ProjectAI.JsonDataManiger.GetInstance(); // JsonDataManiger

            // 4.WorkSpaceEarlyData.m_trainFormJobject 데이터 등록하기

            // TrainSystem Json 파일 정보 만들기
            // ProcessList 저장
            JArray trainFormProcessList = (JArray)WorkSpaceEarlyData.m_trainFormJobject["processList"];
            trainFormProcessList.Add(processName); // 프로세스 이름 WorkSpaceEarlyData.m_trainFormJobject - ProcessList에 등록
            // ProcessInfo 저장
            JObject trainFormProcessInfo = (JObject)WorkSpaceEarlyData.m_trainFormJobject["processInfo"];
            trainFormProcessInfo[processName] = trainProcessInfo; // 프로세스 이름 WorkSpaceEarlyData.m_trainFormJobject - ProcessInfo에 등록

            // 5.관리 폴더, 파일 생성, 파일 저장
            if (CustomIOMainger.DirChackExistsAndCreate(System.IO.Path.Combine(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectWaitingProcess, processName)))
            {
                // 기본 폴더가 있으면
                // 기존 폴더 삭제
                CustomIOMainger.DirDelete(System.IO.Path.Combine(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectWaitingProcess, processName));
                CustomIOMainger.DirChackExistsAndCreate(System.IO.Path.Combine(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectWaitingProcess, processName));

                // 파일 저장
                CustomIOMainger.DirChackExistsAndCreate(System.IO.Path.Combine(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectWaitingProcess, processName, "ImageData"));
                jsonDataManiger.PushJsonObject(System.IO.Path.Combine(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectWaitingProcess, processName, "TrainSystem.Json"), processInfo);
            }
            else
            {
                // 기존 폴더가 없으면
                // 파일 저장
                CustomIOMainger.DirChackExistsAndCreate(System.IO.Path.Combine(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectWaitingProcess, processName, "ImageData"));
                jsonDataManiger.PushJsonObject(System.IO.Path.Combine(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectWaitingProcess, processName, "TrainSystem.Json"), processInfo);
            }
            // WorkSpaceEarlyData.m_trainFormPath 저장 -> TrainSystem 데이터 저장
            jsonDataManiger.PushJsonObject(WorkSpaceEarlyData.m_trainFormPath, WorkSpaceEarlyData.m_trainFormJobject);

            // dgvMWaitingforWork 추가
            this.SafeTrainFormDataGridViewAdd(this.dgvMWaitingforWork, processTask, processTrainTest, processInputDataType, "WaitingforWork", processName, 0);
        }

        /// <summary>
        /// 전처리 작업 등록 프로세스
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMWaitingforWorkRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (this.trainFormF1Start)
            {
                // Process Step = process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "Processing Results" -> "SaveResult" -> "EndProcessing"
                string processName = this.dgvMWaitingforWork.Rows[e.RowIndex].Cells[4].Value.ToString();
                string processSet = this.dgvMWaitingforWork.Rows[e.RowIndex].Cells[3].Value.ToString();

                if (processSet == "WaitingforWork")
                {
                    if (this.taskWaitingforWork != null)
                    {
                        this.taskWaitingforWork.ContinueWith((task) => this.ActiveProcessWaitingforWork((JObject)WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processName].DeepClone()), TaskContinuationOptions.ExecuteSynchronously);
                    }
                    else
                    {
                        this.taskWaitingforWork = Task.Run(() => this.ActiveProcessWaitingforWork((JObject)WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processName].DeepClone()));
                    }
                }
            }
        }

        /// <summary>
        /// 학습 프로세스 DataGridView에 작업이 추가되면
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMProcessingRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //// Process Step = process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "Processing Results" -> "SaveResult" -> "EndProcessing"
            //this.dgvMWaitingforWork.Columns[0].Name = "Process Task";
            //this.dgvMWaitingforWork.Columns[1].Name = "Process Type"; // Total Labeled Image Number
            //this.dgvMWaitingforWork.Columns[2].Name = "Image Type"; // Total Labeled Image Number
            //this.dgvMWaitingforWork.Columns[3].Name = "Process Step"; // Total Labeled Image Number
            //this.dgvMWaitingforWork.Columns[4].Name = "Process Access code";
            //processProgressBardgvMWaitingforWork.HeaderText = "Process Progress";
            /*
             * 등록된 프로세스 Task 확인  "Classification", "Segmentation", "ObjectDetection"
             * 등록된 프로세스 Input Image Type 확인 "SingleImage", "MultiImage"
             * 등록된 정보를 이용하여 Core 선택
             *
             * 학습 Task 생성
             */

            string processTask = this.dgvMProcessing.Rows[e.RowIndex].Cells[0].Value.ToString();
            string processType = this.dgvMProcessing.Rows[e.RowIndex].Cells[1].Value.ToString();
            string processImageType = this.dgvMProcessing.Rows[e.RowIndex].Cells[2].Value.ToString();
            string processStep = this.dgvMProcessing.Rows[e.RowIndex].Cells[3].Value.ToString();
            string processAccesscode = this.dgvMProcessing.Rows[e.RowIndex].Cells[4].Value.ToString();

            string corePath = null; // core Path 설정

            if (processTask == "Classification")
            {
                if (processImageType == "SingleImage")
                {
                    corePath = ProgramEntryPointVariables.m_prohramClassificationCorePath;
                }
                else if (processImageType == "MultiImage")
                {
                }
            }

            if (corePath != null) // corePath 가 설정되지 않으면 학습 Task 등록 하지 않음.
                if (this.trainFormF1Start)
                {
                    if (processStep == "EndPreprocess")
                    {
                        if (this.taskProcessing != null)
                        {
                            this.taskProcessing.ContinueWith((task) => this.ActiveProcessClassificationProcessing((JObject)WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode].DeepClone(), corePath), TaskContinuationOptions.ExecuteSynchronously);
                        }
                        else
                        {
                            this.taskProcessing = Task.Run(() => this.ActiveProcessClassificationProcessing((JObject)WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode].DeepClone(), corePath));
                        }
                    }
                }
        }

        /// <summary>
        /// 결과 처리 작업 등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMDoneWorkRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            string processTask = this.dgvMDoneWork.Rows[e.RowIndex].Cells[0].Value.ToString();
            string processType = this.dgvMDoneWork.Rows[e.RowIndex].Cells[1].Value.ToString();
            string processImageType = this.dgvMDoneWork.Rows[e.RowIndex].Cells[2].Value.ToString();
            string processStep = this.dgvMDoneWork.Rows[e.RowIndex].Cells[3].Value.ToString();
            string processAccesscode = this.dgvMDoneWork.Rows[e.RowIndex].Cells[4].Value.ToString();

            string corePath = null; // core Path 설정

            if (processTask == "Classification")
            {
                if (processImageType == "SingleImage")
                {
                    corePath = ProgramEntryPointVariables.m_prohramClassificationCorePath;
                }
                else if (processImageType == "MultiImage")
                {
                }
            }

            // 결과 처리 등록
            // Local Data에 결과 처리 이름이 등록이되었는지 확인하고 없으면 해당 workspace Model Data에 등록

            // TrainSystem.Json 학습 Local Task 정보 읽어오기
            string processJsonPath = System.IO.Path.Combine(WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_processPath"].ToString(), "TrainSystem.Json");
            JObject processJObject = this.jsonDataManiger.GetJsonObjectShare(processJsonPath);

            string processWorkSpasceName = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_workSpasceName"].ToString();
            string processWorkSpaceInnerPorjectName = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_workSpaceInnerPorjectName"].ToString();

            JObject trainProcessInfo = (JObject)processJObject["TrainProcessInfo"];
            if (trainProcessInfo["string_projectAccessModelName"] == null)
            {
                string projectModelInfoPath = System.IO.Path.Combine(WorkSpaceEarlyData.m_workSpacDataPath, processWorkSpasceName, "data", "ModelInfo.Json");
                JObject workspaceModelInfo = this.jsonDataManiger.GetJsonObjectShare(projectModelInfoPath);
                JArray modelListJArray = (JArray)workspaceModelInfo[processWorkSpaceInnerPorjectName]["array_string_ModelList"];
                string[] modelList = modelListJArray.Select(jv => (string)jv).ToArray();

                // model 관리 이름 만들기
                string projectAccessModelName = CustomIOMainger.RandomFileName(modelList, 15);

                // local Data에 데이터 저장
                trainProcessInfo["string_projectAccessModelName"] = projectAccessModelName;

                // workSpace Model 데이터에 데이터 저장
                modelListJArray.Add(projectAccessModelName);
                //  workSpace Model 정보 저장 하기
                JObject projectModelInfo = (JObject)workspaceModelInfo[processWorkSpaceInnerPorjectName];
                projectModelInfo[projectAccessModelName] = processJObject;

                // Json 파일 저장
                // local Data Json 파일 저장
                this.jsonDataManiger.PushJsonObject(processJsonPath, processJObject);
                // workSpace Model Json 파일 저장
                this.jsonDataManiger.PushJsonObject(projectModelInfoPath, workspaceModelInfo);
            }

            if (corePath != null) // corePath 가 설정되지 않으면 학습 Task 등록 하지 않음.
                // Process Step = process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "Processing Results" -> "SaveResult" -> "EndProcessing"
                if (processStep.Equals("Processing Results"))
                {
                }

            if (this.taskProcessing != null)
            {
                this.taskDone.ContinueWith((task) => this.ActiveProcessClassificationSaveResult((JObject)WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode].DeepClone(), corePath, WorkSpaceEarlyData.m_workSpacDataPath), TaskContinuationOptions.ExecuteSynchronously);
            }
            else
            {
                this.taskDone = Task.Run(() => this.ActiveProcessClassificationSaveResult((JObject)WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode].DeepClone(), corePath, WorkSpaceEarlyData.m_workSpacDataPath));
            }
        }

        private void ClassificationPuthTrainProcessAdd(JObject processOption)
        {
        }

        private void BtnMProcessAllStopClick(object sender, EventArgs e)
        {
            this.processingStart = false;
        }

        private void BtnMProcessStopClick(object sender, EventArgs e)
        {
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 학습 프로세스 시작 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMStartProcessingClick(object sender, EventArgs e)
        {
            // this.dgvMProcessing.Columns[1].Name = "Process Type"; // Total Labeled Image Number
            // this.dgvMProcessing.Columns[2].Name = "Image Type"; // Total Labeled Image Number
            // this.dgvMProcessing.Columns[3].Name = "Process Step"; // Total Labeled Image Number
            // this.dgvMProcessing.Columns[4].Name = "Process Access code";

            if (!this.processingStart) // 처음에만 동작 이후 학습 프로세서가 다 끝나서 대기 상황이면 processingStart = flase 로 변경하여 다시 대기 상태로 만들기
            {
                this.processingStart = true; // 동작중

                List<string> processAccesscodes = new List<string>();
                // dgvMWaitingforWork의 Row 값을 직업 삭제하기 때문에 List를 만들어서 따로 Accesscode 관리
                for (int i = 0; i < this.dgvMWaitingforWork.RowCount; i++)
                {
                    string processAccesscode = this.dgvMWaitingforWork.Rows[i].Cells[4].Value.ToString(); // 등록된 작업 이름 가져오기
                    processAccesscodes.Add(processAccesscode); // List로 만들어서 관리
                }

                for (int i = 0; i < processAccesscodes.Count; i++)
                {
                    string processAccesscode = processAccesscodes[i]; // 등록된 작업 이름 가져오기
                    string processPath = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_processPath"].ToString(); // 등록된 작업 이름을 기반으로 프로세스 작업 위치 정보 가져오기
                    string processInfoPath = System.IO.Path.Combine(processPath, "TrainSystem.Json"); // 작업 정보 파일 위치 가져오기
                    JObject processInfoJObject = jsonDataManiger.GetJsonObjectShare(processInfoPath); // 작업 정보 가져오기

                    string processStep = processInfoJObject["TrainProcessInfo"]["string_processStep"].ToString(); // 작업 정보에서 작업 Step 정보 가져오기

                    if (processStep == "EndPreprocess") // 작업 단계가 EndPreprocess 면 학습 DataGridView 로 보내기
                    {
                        string processTask = processInfoJObject["TrainProcessInfo"]["string_processTask"].ToString(); // 작업 정보에서 작업 Step 정보 가져오기
                        string processTrainTest = processInfoJObject["TrainProcessInfo"]["string_processTrainTest"].ToString(); // 작업 정보에서 작업 Step 정보 가져오기
                        string processImageType = processInfoJObject["TrainProcessInfo"]["string_processImageType"].ToString(); // 작업 정보에서 작업 Step 정보 가져오기
                        string processName = processInfoJObject["TrainProcessInfo"]["string_processName"].ToString(); // 작업 정보에서 작업 Step 정보 가져오기

                        this.SafeDataGridViewRowDelete(this.dgvMWaitingforWork, processAccesscode); // 삭제
                        this.SafeTrainFormDataGridViewAdd(this.dgvMProcessing, processTask, processTrainTest, processImageType, processStep, processName, 0); // 학습 작업 창에 추가
                        this.SafeTapPageNumberChange(this.tclpMProcessActive, 1); // tap page number 변경
                    }
                }
            }
        }

        private void DgvMWaitingforWorkCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // 작업 진행중인 모델 선택시 리뷰
            /*
             * 1. 작업 접근 코드 가져오기
             * 2. 작업 접근 코드를 이용해서 작업 정보 읽어오기
             * 3. 작업 Task 정보 읽어오기 Classification, Segmantation, ObjectDetection
             * 4. 알맛은 리뷰 정보 contral 가져와거 붙이기
             * 5. contral에 정보 적용
             * 6. contral readonly 모드로 전환
             */

            this.DataGridViewCellMouseDoubleClick(sender, e);
        }

        private void DgvMProcessingCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*
             * 1. 작업 접근 코드 가져오기
             * 2. 작업 접근 코드를 이용해서 작업 정보 읽어오기
             * 3. 작업 Task 정보 읽어오기 Classification, Segmantation, ObjectDetection
             * 4. 알맛은 리뷰 정보 contral 가져와거 붙이기
             * 5. contral에 정보 적용
             * 6. contral readonly 모드로 전환
             */

            this.DataGridViewCellMouseDoubleClick(sender, e);
        }

        /// <summary>
        /// 학습 정보 읽어와서 뿌려 주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="localReadMode"> 임시 학습 정보에서 데이터를 읽을지 결정 하기 true: local 정보 읽기, false: 실행되고 있는 project에서 데이터 읽기 </param>
        private void DataGridViewCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*
             * 1. 작업 접근 코드 가져오기
             * 2. 작업 접근 코드를 이용해서 작업 정보 읽어오기
             * 3. 작업 Task 정보 읽어오기 "Classification", "Segmentation", "ObjectDetection"
             * 4. 알맛은 리뷰 정보 contral 가져와거 붙이기
             * 5. contral 적용 정보 가져오기
             * 6. contral에 정보 적용
             * 7. contral readonly 모드로 전환
             */

            if (sender is MetroFramework.Controls.MetroGrid metroGrid)
            {
                if (e.RowIndex != -1) // 컬럼 해더 눌렀는지 감지 해더를 눌렀으면 통과
                    if (metroGrid.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        //string processTask = this.dgvMProcessing.Rows[e.RowIndex].Cells[0].Value.ToString();
                        //string processType = this.dgvMProcessing.Rows[e.RowIndex].Cells[1].Value.ToString();
                        //string processImageType = this.dgvMProcessing.Rows[e.RowIndex].Cells[2].Value.ToString();
                        //string processStep = this.dgvMProcessing.Rows[e.RowIndex].Cells[3].Value.ToString();

                        // 1. 작업 접근 코드 가져오기
                        string processAccesscode = metroGrid.Rows[e.RowIndex].Cells[4].Value.ToString();

                        // 2. 작업 정보 가져오기
                        string processPath = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_processPath"].ToString();
                        JObject localProcessInfo = jsonDataManiger.GetJsonObject(System.IO.Path.Combine(processPath, "TrainSystem.Json"));

                        // 3. 작업 Task 정보 읽어오기 Classification, Segmantation, ObjectDetection
                        string processTask = localProcessInfo["TrainProcessInfo"]["string_processTask"].ToString();

                        // 4. 알맞은 리뷰 정보 contral 붙이기
                        if (processTask.Equals("Classification"))
                        {
                            this.UISetClassificationTrainInfo(localProcessInfo);
                        }
                        else if (processTask.Equals("Segmentation"))
                        {
                            return;
                        }
                        else if (processTask.Equals("ObjectDetection"))
                        {
                            return;
                        }
                    }
            }
        }

        private void DataGridViewCellMouseDoubleClick(MetroFramework.Controls.MetroGrid metroGrid, string modelName)
        {
            /*
             * 3. 작업 Task 정보 읽어오기 "Classification", "Segmentation", "ObjectDetection"
             * 4. 알맛은 리뷰 정보 contral 가져와거 붙이기
             * 5. contral 적용 정보 가져오기
             * 6. contral에 정보 적용
             * 7. contral readonly 모드로 전환
             */

            if (metroGrid.SelectedRows[0].Index != -1) // 컬럼 해더 눌렀는지 감지 해더를 눌렀으면 통과
                if (metroGrid.SelectedRows[0].Cells[0].Value != null)
                {
                    //string processTask = this.dgvMProcessing.Rows[e.RowIndex].Cells[0].Value.ToString();
                    //string processType = this.dgvMProcessing.Rows[e.RowIndex].Cells[1].Value.ToString();
                    //string processImageType = this.dgvMProcessing.Rows[e.RowIndex].Cells[2].Value.ToString();
                    //string processStep = this.dgvMProcessing.Rows[e.RowIndex].Cells[3].Value.ToString();

                    JObject modelInfo = (JObject)WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName];

                    // 3. 작업 Task 정보 읽어오기 Classification, Segmantation, ObjectDetection
                    string processTask = modelInfo["TrainProcessInfo"]["string_processTask"].ToString();

                    // 4. 알맞은 리뷰 정보 contral 붙이기
                    if (processTask.Equals("Classification"))
                    {
                        this.UISetClassificationTrainInfo(modelInfo);
                    }
                    else if (processTask.Equals("Segmentation"))
                    {
                        return;
                    }
                    else if (processTask.Equals("ObjectDetection"))
                    {
                        return;
                    }
                }
        }

        private void UISetClassificationTrainInfo(JObject modelInfo)
        {
            this.panelMTrainOption.Controls.Clear(); // 컨트롤 초기화
            this.panelMTrainOption.Controls.Add(this.ClassificationTrainOptions); // 컨트롤 적용
            this.ClassificationTrainOptions.Enabled = false;

            // 5. Contral 정보 가져오기
            // Trian Options 수동
            string networkModel = modelInfo["ModelLearningInfo"]["TrainOptionManual"]["string_NetworkModel"].ToString();
            string epochNumber = modelInfo["ModelLearningInfo"]["TrainOptionManual"]["int_EpochNumber"].ToString();
            string trainRepeat = modelInfo["ModelLearningInfo"]["TrainOptionManual"]["int_TrainRepeat"].ToString();
            string modelMinimumSelectionEpoch = modelInfo["ModelLearningInfo"]["TrainOptionManual"]["int_ModelMinimumSelectionEpoch"].ToString();
            string validationRatio = modelInfo["ModelLearningInfo"]["TrainOptionManual"]["int_ValidationRatio"].ToString();
            string patienceEpochs = modelInfo["ModelLearningInfo"]["TrainOptionManual"]["int_PatienceEpochs"].ToString();

            // Data Augmentation Manual 설정
            Boolean.TryParse(modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_BlurChecked"].ToString(), out bool blurChecked);
            string blur = modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_Blur"].ToString();

            Boolean.TryParse(modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_BrightnessChecked"].ToString(), out bool brightnessChecked);
            string brightnessMin = modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_BrightnessMin"].ToString();
            string brightnessMax = modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_BrightnessMax"].ToString();

            Boolean.TryParse(modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_CenterChecked"].ToString(), out bool centerChecked);
            string center = modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_Center"].ToString();

            Boolean.TryParse(modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_ContrastChecked"].ToString(), out bool contrastChecked);
            string contrastMin = modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_ContrastMin"].ToString();
            string contrastMax = modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_ContrastMax"].ToString();

            Boolean.TryParse(modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_GaussianNoiseChecked"].ToString(), out bool gaussianNoiseChecked);
            string gaussianNoise = modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_GaussianNoise"].ToString();

            Boolean.TryParse(modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_GaussianNoiseChecked"].ToString(), out bool gradationChecked);
            string gradation = modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_Gradation"].ToString();

            Boolean.TryParse(modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_GradationRGBChecked"].ToString(), out bool gradationRGBChecked);
            string gradationRGB = modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["int_GradationRGB"].ToString();

            Boolean.TryParse(modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_HorizontalFlipChecked"].ToString(), out bool horizontalFlipChecked);

            Boolean.TryParse(modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_Rotation90Checked"].ToString(), out bool rotation90Checked);
            Boolean.TryParse(modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_Rotation180Checked"].ToString(), out bool rotation180Checked);
            Boolean.TryParse(modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_Rotation270Checked"].ToString(), out bool rotation270Checked);

            Boolean.TryParse(modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_SharpenChecked"].ToString(), out bool sharpenChecked);
            string sharpen = modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_Sharpen"].ToString();

            Boolean.TryParse(modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["bool_VerticalFlipChecked"].ToString(), out bool verticalFlipChecked);

            Boolean.TryParse(modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_ZoomChecked"].ToString(), out bool zoomChecked);
            string zoomMin = modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_ZoomMin"].ToString();
            string zoomMax = modelInfo["ModelLearningInfo"]["DataAugmentationManual"]["double_ZoomMax"].ToString();

            // ContinualLearning
            Boolean.TryParse(modelInfo["ModelLearningInfo"]["ContinualLearning"]["bool_ContinualLearningChecked"].ToString(), out bool continualLearningChecked);
            string continualLearning = modelInfo["ModelLearningInfo"]["ContinualLearning"]["string_ContinualLearning"].ToString();

            string continualLearningModelName = modelInfo["ModelLearningInfo"]["ContinualLearning"]["string_ContinualLearningModelName"].ToString();
            string continualLearningModelLoss = modelInfo["ModelLearningInfo"]["ContinualLearning"]["string_ContinualLearningModelLoss"].ToString();
            string continualLearningModelAccuracy = modelInfo["ModelLearningInfo"]["ContinualLearning"]["string_ContinualLearningModelAccuracy"].ToString();
            string continualLearningModelEscape = modelInfo["ModelLearningInfo"]["ContinualLearning"]["string_ContinualLearningModelEscape"].ToString();
            string continualLearningModelOverKill = modelInfo["ModelLearningInfo"]["ContinualLearning"]["string_ContinualLearningModelOverKill"].ToString();

            // InstantEvaluate
            Boolean.TryParse(modelInfo["ModelLearningInfo"]["InstantEvaluate"]["bool_InstantEvaluateChecked"].ToString(), out bool instantEvaluateChecked);
            string instantEvaluateDataset = modelInfo["ModelLearningInfo"]["InstantEvaluate"]["string_InstantEvaluateDataset"].ToString();

            // Class Info
            List<string> classNameList = new List<string>();
            foreach (string className in modelInfo["TrainProcessInfo"]["string_array_classList"])
            {
                classNameList.Add(className);
            }

            // 6. Contral 정보 적용
            if (networkModel.Equals("SynapseNet_Classification_18"))
            {
                this.ClassificationTrainOptions.cbbManetworkModel.Text = "Small";
                this.ClassificationTrainOptions.cbbManetworkModel.PromptText = "Small";
            }
            else if (networkModel.Equals("SynapseNet_Classification_34"))
            {
                this.ClassificationTrainOptions.cbbManetworkModel.Text = "Medium";
                this.ClassificationTrainOptions.cbbManetworkModel.PromptText = "Medium";
            }
            else if (networkModel.Equals("SynapseNet_Classification_50"))
            {
                this.ClassificationTrainOptions.cbbManetworkModel.Text = "Large";
                this.ClassificationTrainOptions.cbbManetworkModel.PromptText = "Large";
            }
            else if (networkModel.Equals("SynapseNet_Classification_100"))
            {
                this.ClassificationTrainOptions.cbbManetworkModel.Text = "Extra Large";
                this.ClassificationTrainOptions.cbbManetworkModel.PromptText = "Extra Large";
            }

            // Trian Options 수동
            this.ClassificationTrainOptions.txtEpochNumber.Text = epochNumber;
            this.ClassificationTrainOptions.txtMmodelMinimumSelectionEpoch.Text = modelMinimumSelectionEpoch;
            this.ClassificationTrainOptions.txtPatienceEpochs.Text = patienceEpochs;
            this.ClassificationTrainOptions.txtTrainRepeat.Text = trainRepeat;
            this.ClassificationTrainOptions.txtValidationRatio.Text = validationRatio;
            this.ClassificationTrainOptions.txtTrainDataNumber.Text = "---";

            // Data Augmentation Manual 설정
            this.ClassificationTrainOptions.ckbMBlur.Checked = blurChecked;
            this.ClassificationTrainOptions.txtBlur.Text = blur;

            this.ClassificationTrainOptions.ckbBrightness.Checked = brightnessChecked;
            this.ClassificationTrainOptions.txtBrightnessMin.Text = brightnessMin;
            this.ClassificationTrainOptions.txtBrightnessMax.Text = brightnessMax;

            this.ClassificationTrainOptions.ckbMCenter.Checked = centerChecked;
            this.ClassificationTrainOptions.txtCenter.Text = center;

            this.ClassificationTrainOptions.ckbMContrast.Checked = contrastChecked;
            this.ClassificationTrainOptions.txtContrastMin.Text = contrastMin;
            this.ClassificationTrainOptions.txtContrastMax.Text = contrastMax;

            this.ClassificationTrainOptions.ckbMGaussianNoise.Checked = gaussianNoiseChecked;
            this.ClassificationTrainOptions.txtGaussianNoise.Text = gaussianNoise;

            this.ClassificationTrainOptions.ckbMGradation.Checked = gradationChecked;
            this.ClassificationTrainOptions.txtGradation.Text = gradation;

            this.ClassificationTrainOptions.ckbGradationRGB.Checked = gradationRGBChecked;

            this.ClassificationTrainOptions.ckbMHorizontalFlip.Checked = horizontalFlipChecked;

            this.ClassificationTrainOptions.ckbMRotation90.Checked = rotation90Checked;
            this.ClassificationTrainOptions.ckbMRotation180.Checked = rotation180Checked;
            this.ClassificationTrainOptions.ckbMRotation270.Checked = rotation270Checked;

            this.ClassificationTrainOptions.ckbMSharpen.Checked = sharpenChecked;
            this.ClassificationTrainOptions.txtSharpen.Text = sharpen;

            this.ClassificationTrainOptions.ckbMVerticalFlip.Checked = verticalFlipChecked;

            this.ClassificationTrainOptions.ckbMZoom.Checked = zoomChecked;
            this.ClassificationTrainOptions.txtZoomMin.Text = zoomMin;
            this.ClassificationTrainOptions.txtZoomMax.Text = zoomMax;

            /*
            string continualLearningModelName = modelInfo["ModelLearningInfo"]["ContinualLearning"]["string_ContinualLearningModelName"].ToString();
            string continualLearningModelLoss = modelInfo["ModelLearningInfo"]["ContinualLearning"]["string_ContinualLearningModelLoss"].ToString();
            string continualLearningModelAccuracy = modelInfo["ModelLearningInfo"]["ContinualLearning"]["string_ContinualLearningModelAccuracy"].ToString();
            string continualLearningModelEscape = modelInfo["ModelLearningInfo"]["ContinualLearning"]["string_ContinualLearningModelEscape"].ToString();
            string continualLearningModelOverKill = modelInfo["ModelLearningInfo"]["ContinualLearning"]["string_ContinualLearningModelOverKill"].ToString();
                */

            // ContinualLearning UI 설정
            this.ClassificationTrainOptions.togMContinualLearning.Checked = continualLearningChecked;
            this.ClassificationTrainOptions.dgvMContinualLearning.Rows.Add("Model", continualLearningModelLoss, continualLearningModelAccuracy, continualLearningModelEscape, continualLearningModelOverKill);

            // Class Info
            this.ClassificationTrainOptions.UISetupClassWeighContralResetManual(); // 기존 Class Contral 초기화
            int i = 0;
            foreach (string className in classNameList)
                this.ClassificationTrainOptions.UISetupClassWeighContralAddManual(i++, className, Color.Gray); // Class Contral 추가
        }
    }
}