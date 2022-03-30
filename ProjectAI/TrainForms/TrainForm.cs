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

        // process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "SaveResult" -> "EndProcessing"
        /// <summary>
        /// WaitingforWork 처리 Task
        /// </summary>
        private Task taskWaitingforWork;
        /// <summary>
        /// Processing 처리 Task
        /// </summary>
        private Task taskProcessing;



        /// <summary>
        /// 프로세스 동작 활성화 여부
        /// </summary>
        bool processingStart = false;

        /// <summary>
        /// Train Forms 처음 동작 확인 dgvMWaitingforWork -> 처음 추가 동작 제어
        /// </summary>
        bool trainFormF1Start = false;


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
        private delegate void SafeCallTrainFormDataGridView(System.Object dataGridViewObject, string processTask, string processType, string processInputDataType, string processStep, string processAccessCode, int processProgress);
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
                        var d = new SafeCallTrainFormDataGridView(SafeTrainFormDataGridViewAdd);
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
                    var d = new SafeCallTrainFormDataGridView(SafeTrainFormDataGridViewAdd);
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

        private delegate void SafeCallDataGridViewProgressColumn(System.Object dataGridViewObject, string processAccessCode, int value);
        public void SafeDataGridViewProgressValue(System.Object dataGridViewObject, string processAccessCode, int value)
        {
            if (dataGridViewObject.GetType() == typeof(MetroFramework.Controls.MetroGrid))
            {
                MetroFramework.Controls.MetroGrid dataGridView = (MetroFramework.Controls.MetroGrid)dataGridViewObject;
                if (dataGridView.InvokeRequired)
                {
                    try
                    {
                        var d = new SafeCallDataGridViewProgressColumn(SafeDataGridViewProgressValue);
                        Invoke(d, new object[] { dataGridView, processAccessCode, value });
                    }
                    catch
                    {
                        //Console.WriteLine("ERROR: SafeDataGridViewProcessStep");
                        //Console.WriteLine($"dataGridViewObject: {dataGridView.Name}");
                        //Console.WriteLine($"dataGridViewObject: {processAccessCode}");
                        //Console.WriteLine($"value: {value}");
                    }
                }
                else
                {
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        try
                        {
                            if (processAccessCode == dataGridView.Rows[i].Cells[4].Value.ToString())
                                dataGridView.Rows[i].Cells[5].Value = value;
                        }
                        catch
                        {
                            //Console.WriteLine("ERROR: SafeDataGridViewProcessStep");
                            //Console.WriteLine($"dataGridViewObject: {dataGridView.Name}");
                            //Console.WriteLine($"dataGridViewObject: {processAccessCode}");
                            //Console.WriteLine($"value: {value}");
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
                    var d = new SafeCallDataGridViewProgressColumn(SafeDataGridViewProgressValue);
                    Invoke(d, new object[] { dataGridView, processAccessCode, value });
                }
                else
                {
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        if (processAccessCode == dataGridView.Rows[i].Cells[4].Value.ToString())
                            dataGridView.Rows[i].Cells[5].Value = value;
                    }
                    // 실행 
                }
            }
        }

        private delegate void SafeCallDataGridViewProcessStep(System.Object dataGridViewObject, string processAccessCode, string processStep);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridViewObject"></param>
        /// <param name="processAccessCode"></param>
        /// <param name="processStep"> process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "SaveResult" -> "EndProcessing" </param>
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
            // process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "SaveResult" -> "EndProcessing"


            if (dataGridViewObject.GetType() == typeof(MetroFramework.Controls.MetroGrid))
            {
                MetroFramework.Controls.MetroGrid dataGridView = (MetroFramework.Controls.MetroGrid)dataGridViewObject;
                if (dataGridView.InvokeRequired)
                {
                    try
                    {
                        var d = new SafeCallDataGridViewProcessStep(SafeDataGridViewProcessStep);
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
                    var d = new SafeCallDataGridViewProcessStep(SafeDataGridViewProcessStep);
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

        private delegate void SafeCallDataGridViewRowDelete(System.Object dataGridViewObject, string processAccessCode);
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
            // process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "SaveResult" -> "EndProcessing"


            if (dataGridViewObject.GetType() == typeof(MetroFramework.Controls.MetroGrid))
            {
                MetroFramework.Controls.MetroGrid dataGridView = (MetroFramework.Controls.MetroGrid)dataGridViewObject;
                if (dataGridView.InvokeRequired)
                {
                    var d = new SafeCallDataGridViewRowDelete(SafeDataGridViewRowDelete);
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
                    var d = new SafeCallDataGridViewRowDelete(SafeDataGridViewRowDelete);
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

            // Process Step = process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "SaveResult" -> "EndProcessing"

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

                if (WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_processStep"].ToString() != "EndProcessing")
                {
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

                    // process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "SaveResult" -> "EndProcessing"
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
                    else if (processStep == "Processing")
                    {
                        this.dgvMWaitingforWork.Rows.Add(processTask, processTrainTest, processImageType, processStep, processName, 0);
                    }
                    else if (processStep == "SaveResult")
                    {
                        this.dgvMWaitingforWork.Rows.Add(processTask, processTrainTest, processImageType, processStep, processName, 0);
                    }
                }
                else
                {
                    if (processStep == "EndProcessing")
                    {
                        processModel = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_processModel"].ToString();
                        processTask = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_processTask"].ToString();
                        processName = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_processName"].ToString();
                        processTrainTest = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_processTrainTest"].ToString();
                        processImageType = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_processImageType"].ToString();
                        processPath = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_processPath"].ToString();
                        porkSpasceName = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_workSpasceName"].ToString();
                        workSpaceInnerPorjectName = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_workSpaceInnerPorjectName"].ToString();
                        processStep = WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode]["string_processStep"].ToString();

                        this.SafeTrainFormDataGridViewAdd(this.dgvMDoneWork, processTask, processTrainTest, processImageType, processStep, processName, 0);
                    }
                }
                // 3. 학습 데이터 관리 Dictionary 데이터 추가하기
            }
        }

        private void TrainFormLoad(object sender, EventArgs e)
        {

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

        private JObject IntegrityCheck(JObject workSpaceEarlyDataSetJObject)
        {
            if (workSpaceEarlyDataSetJObject == null)
            {
                workSpaceEarlyDataSetJObject = this.TrainFormDataReset();
            }
            return workSpaceEarlyDataSetJObject;
        }

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
                CustomIOMainger.FileIODelay(500);
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
            string coreProgramConfigFilePath = System.IO.Path.Combine(corePath, "config", "clasf_dnn.cfg");

            // Train Config 파일 만들기
            // TrainSystem.Json 학습 Task 정보 읽어오기
            string processJsonPath = System.IO.Path.Combine(processInfo["string_processPath"].ToString(), "TrainSystem.Json");
            JObject processJObject = jsonDataManiger.GetJsonObjectShare(processJsonPath);

            // Trian Options list 데이터로 가져오기
            List<string> trainOptions = this.TransferTrainOptionJObjectString(processJObject); // 


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

            double bestTrainLoss = 0;
            double bestTrainAccuracy = 0;
            int bestTrainEscape = 0;
            int bestTrainOverKill = 0;
            double bestTestLoss = 0;
            double bestTestAccuracy = 0;
            int bestTestEscape = 0;
            int bestTestOverKill = 0;

            while (!classificationProcess.HasExited)
            {
                string classificationSystemLog = classificationReader.ReadLine();

                /*
                 * 확인 되야 하는 내용
                 * Ep.
                 * |t:
                 * Save Model Name
                 */
                if (classificationSystemLog.Contains("Ep."))// loss 값 감지
                {
                    int indexLoss = classificationSystemLog.IndexOf("Ls:");
                    int indexAccuracy = classificationSystemLog.IndexOf("Acc:");
                    int indexEscape = classificationSystemLog.IndexOf("esc:");
                    int indexOverKill = classificationSystemLog.IndexOf("ovk:");

                    string stringLoss = classificationSystemLog.Substring(indexLoss, indexAccuracy - indexLoss).Trim();
                    string stringAccuracy = classificationSystemLog.Substring(indexLoss, indexAccuracy - indexLoss).Trim();
                    string stringEscape = classificationSystemLog.Substring(indexEscape, indexOverKill - indexEscape).Trim();
                    string stringOverKill = classificationSystemLog.Substring(indexOverKill).Trim();

                    trainEpochLoss = double.Parse(stringLoss.Split(':')[1]);
                    trainEpochAccuracy = double.Parse(stringAccuracy.Split(':')[1]);
                    trainEscape = int.Parse(stringEscape.Split(':')[1]);
                    trainOverKill = int.Parse(stringOverKill.Split(':')[1].Split('/')[0]);
                }
                else if (classificationSystemLog.Contains("|t:"))
                {
                    int indexLoss = classificationSystemLog.IndexOf("Ls:");
                    int indexAccuracy = classificationSystemLog.IndexOf("Acc:");
                    int indexEscape = classificationSystemLog.IndexOf("esc:");
                    int indexOverKill = classificationSystemLog.IndexOf("ovk:");

                    string stringLoss = classificationSystemLog.Substring(indexLoss, indexAccuracy - indexLoss).Trim();
                    string stringAccuracy = classificationSystemLog.Substring(indexLoss, indexAccuracy - indexLoss).Trim();
                    string stringEscape = classificationSystemLog.Substring(indexEscape, indexOverKill - indexEscape).Trim();
                    string stringOverKill = classificationSystemLog.Substring(indexOverKill).Trim();

                    testEpochLoss = double.Parse(stringLoss.Split(':')[1]);
                    testEpochAccuracy = double.Parse(stringAccuracy.Split(':')[1]);
                    testEscape = int.Parse(stringEscape.Split(':')[1]);
                    testOverKill = int.Parse(stringOverKill.Split(':')[1].Split('/')[0]);
                }
                else if (classificationSystemLog.Contains("Save Model Name"))
                {
                    bestTrainLoss = trainEpochLoss;
                    bestTrainAccuracy = trainEpochAccuracy;
                    bestTrainEscape = trainEscape;
                    bestTrainOverKill = trainEscape;
                    bestTestLoss = testEpochLoss;
                    bestTestAccuracy = testEpochAccuracy;
                    bestTestEscape = testEscape;
                    bestTestOverKill = testOverKill;
                }
            }
        }
        private void ActiveProcessSaveResult(JObject processInfo)
        {
            // 결과 저장 
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
                    trainOptions.Add(PackingString($"dnn_file |{modelLearningInfo["ModelLearningInfo"]["ContinualLearning"]["string_ContinualLearning"].ToString()}|"));
                }
            }
            else
            {
                trainOptions.Add(PackingString($"dnn_file |{"default"}|")); //default ro new
            }
            #endregion 

            #region ClassWeight 가져오기
            string classWeight = null;
            foreach (string className in modelLearningInfo["ModelLearningInfo"]["TrainProcessInfo"]["string_array_classList"])
            {
                if (classWeight == null)
                    classWeight = modelLearningInfo["ModelLearningInfo"]["ClassWeight"][className].ToString();
                else
                    classWeight += ", " + modelLearningInfo["ModelLearningInfo"]["ClassWeight"][className].ToString();
            }
            if (classWeight == null)
                trainOptions.Add(PackingString($"loss_wt |{classWeight}|"));
            else
                trainOptions.Add(PackingString($"loss_wt |auto|")); // auto ro 1
            #endregion 

            #region 데이터 옵션 설정
            string dataPath = System.IO.Path.Combine(modelLearningInfo["ModelLearningInfo"]["TrainProcessInfo"]["string_processPath"].ToString(), "ImageData");
            trainOptions.Add(PackingString($"dts_path |{dataPath}|"));
            trainOptions.Add(PackingString($"dts_pth_lst ||"));
            trainOptions.Add(PackingString($"train_dir |Train|"));
            trainOptions.Add(PackingString($"test_dir |Test|"));
            #endregion 

            #region 이미지 설정
            trainOptions.Add(PackingString($"img_chnl |{modelLearningInfo["ModelLearningInfo"]["ImageOption"]["int_imageChannel"].ToString()}|"));
            trainOptions.Add(PackingString($"img_sz |{modelLearningInfo["ModelLearningInfo"]["ImageOption"]["int_imageSize"].ToString()}|"));
            #endregion

            #region Instant Evaluate => 추가 방법 고민중 학습 스레드에서 처리하는걸로

            #endregion

            #region 시스템 설정 옵션
            trainOptions.Add(PackingString($"tr_wrk |{modelLearningInfo["ModelLearningInfo"]["TrainSystemOption"]["int_dataLoaderNUmberofWorkers"].ToString()}|"));

            trainOptions.Add(PackingString($"eval |n|"));
            trainOptions.Add(PackingString($"heat_map |n|"));
            trainOptions.Add(PackingString($"progress_bar |n|"));
            trainOptions.Add(PackingString($"help ? h ||"));
            #endregion

            return trainOptions;
        }

        private string PackingString(string data)
        {
            return ("{" + data + "}");
        }

        /// <summary>
        /// 
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
             * // process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "SaveResult" -> "EndProcessing"
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
                ["string_processStep"] = "WaitingforWork" // process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "SaveResult" -> "EndProcessing"
        };

            // 2. 학습 옵션 데이터 관리 데이터로 변경 - 문서 파일에 예시 있음. ModelInfo1.Json
            JObject processInfo = new JObject
            {
                // 2-1 빈 JArray "array_string_InnerModelList" 추가 -> 저장되는 Inner Model 파일 List
                ["array_string_innerModelList"] = new JArray(),
                // 2-2 빈 JObject "InnerModelInfo" 추가 -> 저장된 Inner Model Info
                ["InnerModelInfo"] = new JObject(),
                // 2-3 빈 JObject "TrainingProgressData" 추가 -> 학습 진행시 각 Epoch 마다 출력되는 Loss , Accuracy, Escape, OverKill (Train, Test) 정보 저장 
                ["TrainingProcessData"] = new JObject(),
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

        private void DgvMWaitingforWorkRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (this.trainFormF1Start)
            {
                // Process Step = process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "SaveResult" -> "EndProcessing"
                string processName = this.dgvMWaitingforWork.Rows[e.RowIndex].Cells[4].Value.ToString();
                string processSet = this.dgvMWaitingforWork.Rows[e.RowIndex].Cells[3].Value.ToString();

                if (processSet == "WaitingforWork")
                {
                    if (this.taskWaitingforWork != null)
                    {
                        this.taskWaitingforWork.ContinueWith((task) => this.ActiveProcessWaitingforWork((JObject)WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processName]), TaskContinuationOptions.ExecuteSynchronously);
                    }
                    else
                    {
                        this.taskWaitingforWork = Task.Run(() => this.ActiveProcessWaitingforWork((JObject)WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processName]));
                    }
                }
            }
        }

        private void DgvMProcessingRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //// Process Step = process 단계 "WaitingforWork" -> "EndPreprocess" -> "Processing" -> "SaveResult" -> "EndProcessing"
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
                            this.taskProcessing.ContinueWith((task) => this.ActiveProcessClassificationProcessing((JObject)WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode], corePath), TaskContinuationOptions.ExecuteSynchronously);
                        }
                        else
                        {
                            this.taskProcessing = Task.Run(() => this.ActiveProcessClassificationProcessing((JObject)WorkSpaceEarlyData.m_trainFormJobject["processInfo"][processAccesscode], corePath));
                        }
                    }
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
                    }
                }
            }
        }
    }
}
