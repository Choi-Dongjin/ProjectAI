﻿using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectAI.MainForms.UserContral.Classification
{
    public partial class ContinualLearningInnerModelSelecter : MetroForm
    {
        private string modelName;
        private string selectInnerModelName;
        private string selectInnerModelPath;

        private string selectInnerModelLoss;
        private string selectInnerModelAccuracy;
        private string selectInnerModelEscape;
        private string selectInnerModelOverKill;

        public ContinualLearningInnerModelSelecter(string modelName)
        {
            InitializeComponent();

            this.StyleManager = this.metroStyleManager1;
            // Forms Calss formStyleManagerHandler 등록
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;

            this.modelName = modelName;
        }

        private void ContinualLearningInnerModelSelecterLoad(object sender, EventArgs e)
        {
            // 차트 색 수정
            this.chartLoss.Series["Train & Validation"].Color = ColorTranslator.FromHtml("#41b6e6");
            this.chartLoss.Series["Test"].Color = ColorTranslator.FromHtml("#ffb549");
            this.chartLoss.Series["selectModelDataTrain"].Color = ColorTranslator.FromHtml("#001871");
            this.chartLoss.Series["selectModelDataTest"].Color = ColorTranslator.FromHtml("#ff585d");

            this.chartAccuracy.Series["Train & Validation"].Color = ColorTranslator.FromHtml("#41b6e6");
            this.chartAccuracy.Series["Test"].Color = ColorTranslator.FromHtml("#ffb549");
            this.chartAccuracy.Series["selectModelDataTrain"].Color = ColorTranslator.FromHtml("#001871");
            this.chartAccuracy.Series["selectModelDataTest"].Color = ColorTranslator.FromHtml("#ff585d");
        }

        private void ContinualLearningInnerModelSelecterShown(object sender, EventArgs e)
        {
            FormsManiger formsManiger = FormsManiger.GetInstance();
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);

            //UI Setup
            this.UISetContinualLearningInnerModelSelecter(); // Data Grid View setup
            this.UISetModelUpdater(); // Model Info Updataer - 내부 모델 정보 불러오기
            this.UISetChartSetting(); // 선택된 모델 차트 그리기
        }

        ~ContinualLearningInnerModelSelecter()
        {
            FormsManiger.m_formStyleManagerHandler -= this.UpdataFormStyleManager;
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
                this.StyleManager.Style = styleManager.Style;
                this.StyleManager.Theme = styleManager.Theme;

                // 차트 스타일 변경
                FormsManiger.ChartWhiteMode(this.chartLoss);
                FormsManiger.ChartWhiteMode(this.chartAccuracy);
            }
            else // Dark로 변경시 진입
            {
                this.StyleManager.Style = styleManager.Style;
                this.StyleManager.Theme = styleManager.Theme;

                // 차트 스타일 변경
                FormsManiger.ChartDarkMode(this.chartLoss);
                FormsManiger.ChartDarkMode(this.chartAccuracy);
            }
        }

        /// <summary>
        /// Data Grid View setup
        /// </summary>
        private void UISetContinualLearningInnerModelSelecter()
        {
            this.dgvMContinualLearningInnerModelSelecter.DataSource = null;
            this.dgvMContinualLearningInnerModelSelecter.Columns.Clear();
            this.dgvMContinualLearningInnerModelSelecter.Rows.Clear();
            this.dgvMContinualLearningInnerModelSelecter.Refresh();

            this.dgvMContinualLearningInnerModelSelecter.ColumnCount = 9;
            this.dgvMContinualLearningInnerModelSelecter.Columns[0].Name = "Epoch";
            this.dgvMContinualLearningInnerModelSelecter.Columns[1].Name = "Train Loss"; // Total Labeled Image Number
            this.dgvMContinualLearningInnerModelSelecter.Columns[2].Name = "Train Accuracy"; //Train Test
            this.dgvMContinualLearningInnerModelSelecter.Columns[3].Name = "Train Escape";
            this.dgvMContinualLearningInnerModelSelecter.Columns[4].Name = "Train OverKill";
            this.dgvMContinualLearningInnerModelSelecter.Columns[5].Name = "Test Loss";
            this.dgvMContinualLearningInnerModelSelecter.Columns[6].Name = "Test Accuracy";
            this.dgvMContinualLearningInnerModelSelecter.Columns[7].Name = "Test Escape";
            this.dgvMContinualLearningInnerModelSelecter.Columns[8].Name = "Test OverKill";
        }

        /// <summary>
        /// Model Info Updataer - 내부 모델 정보 불러오기
        /// </summary>
        private void UISetModelUpdater()
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
            {
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    if (WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] != null)
                    {
                        foreach (string innerModelName in WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["array_string_innerModelList"])
                        {
                            // 내부 모델 정보 읽어오기
                            int locationX = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_locationX"]);

                            double trainLoss = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["double_TrainLoss"]);
                            double trainAcc = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["double_TrainAcc"]);
                            int trainEscape = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_TrainEscape"]);
                            int trainOverKill = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_TrainOverKill"]);

                            double testLoss = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["double_TestLoss"]);
                            double testAcc = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["double_TestAcc"]);
                            int testEscape = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_TestEscape"]);
                            int testOverKill = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_TestOverKill"]);

                            this.dgvMContinualLearningInnerModelSelecter.Rows.Add(locationX, trainLoss, trainAcc, trainEscape, trainOverKill, testLoss, testAcc, testEscape, testOverKill);
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Model Data 손상됨", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// 데이터 읽어서 차트 생성하기
        /// </summary>
        private void UISetChartSetting()
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                    if (WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] != null)
                    {
                        foreach (JProperty trainingProgressData in WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["TrainingProgressData"])
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

                            this.chartLoss.Series["Train & Validation"].Points.AddXY(locationX, trainLoss);
                            this.chartLoss.Series["Test"].Points.AddXY(locationX, testLoss);

                            this.chartAccuracy.Series["Train & Validation"].Points.AddXY(locationX, trainAcc);
                            this.chartAccuracy.Series["Test"].Points.AddXY(locationX, testAcc);
                        }
                    }
        }

        /// <summary>
        /// 모델 선택 하기 더블클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMContinualLearningInnerModelSelecterCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //DataGridViewRow row = this.dgvMContinualLearningInnerModelSelecter.SelectedRows[0]; //선택된 Row 값 가져옴.
            //string data = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[0]) = name
            if (e.RowIndex != -1) // 컬럼 해더 눌렀는지 감지 해더를 눌렀으면 통과
                if (this.dgvMContinualLearningInnerModelSelecter.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    //Console.WriteLine(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject.ToString());`
                    string innerModelName = WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["array_string_innerModelList"][e.RowIndex].ToString();

                    string modelPath = System.IO.Path.Combine(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectModel, WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName, this.modelName, "models", innerModelName);

                    this.selectInnerModelName = innerModelName;
                    this.selectInnerModelPath = System.IO.Path.Combine(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectModel, WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName, this.modelName, "models", innerModelName);

                    /*
                        this.dgvMContinualLearningInnerModelSelecter.Columns[0].Name = "Epoch";
                        this.dgvMContinualLearningInnerModelSelecter.Columns[1].Name = "Train Loss"; // Total Labeled Image Number
                        this.dgvMContinualLearningInnerModelSelecter.Columns[2].Name = "Train Accuracy"; //Train Test
                        this.dgvMContinualLearningInnerModelSelecter.Columns[3].Name = "Train Escape";
                        this.dgvMContinualLearningInnerModelSelecter.Columns[4].Name = "Train OverKill";
                        this.dgvMContinualLearningInnerModelSelecter.Columns[5].Name = "Test Loss";
                        this.dgvMContinualLearningInnerModelSelecter.Columns[6].Name = "Test Accuracy";
                        this.dgvMContinualLearningInnerModelSelecter.Columns[7].Name = "Test Escape";
                        this.dgvMContinualLearningInnerModelSelecter.Columns[8].Name = "Test OverKill";
                     */

                    this.selectInnerModelLoss = this.dgvMContinualLearningInnerModelSelecter.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.selectInnerModelAccuracy = this.dgvMContinualLearningInnerModelSelecter.Rows[e.RowIndex].Cells[2].Value.ToString();
                    this.selectInnerModelEscape = this.dgvMContinualLearningInnerModelSelecter.Rows[e.RowIndex].Cells[3].Value.ToString();
                    this.selectInnerModelOverKill = this.dgvMContinualLearningInnerModelSelecter.Rows[e.RowIndex].Cells[4].Value.ToString();

                    this.Close();
                }
        }

        /// <summary>
        /// 모델 리뷰 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMContinualLearningInnerModelSelecterCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex != -1) // 컬럼 해더 눌렀는지 감지 해더를 눌렀으면 통과
            //    if (this.dgvMContinualLearningInnerModelSelecter.Rows[e.RowIndex].Cells[0].Value != null)
            //    {
            //        string innerModelName = WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["array_string_innerModelList"][e.RowIndex].ToString();

            //        int locationX = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_locationX"]);

            //        double trainLoss = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["double_TrainLoss"]);
            //        double trainAcc = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["double_TrainAcc"]);
            //        int trainEscape = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_TrainEscape"]);
            //        int trainOverKill = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_TrainOverKill"]);

            //        double testLoss = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["double_TestLoss"]);
            //        double testAcc = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["double_TestAcc"]);
            //        int testEscape = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_TestEscape"]);
            //        int testOverKill = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_TestOverKill"]);

            //        this.chartLoss.Series["selectModelDataTrain"].Points.Clear();
            //        this.chartLoss.Series["selectModelDataTrain"].Points.AddXY(locationX, trainLoss);
            //        this.chartLoss.Series["selectModelDataTrain"].ToolTip = string.Format("Epoch: {0}, Loss: {1:0.00}", locationX, trainLoss);
            //        this.chartLoss.Series["selectModelDataTest"].Points.Clear();
            //        this.chartLoss.Series["selectModelDataTest"].Points.AddXY(locationX, testLoss);
            //        this.chartLoss.Series["selectModelDataTest"].ToolTip = string.Format("Epoch: {0}, Loss: {1:0.00}", locationX, testLoss);

            //        this.chartAccuracy.Series["selectModelDataTrain"].Points.Clear();
            //        this.chartAccuracy.Series["selectModelDataTrain"].Points.AddXY(locationX, trainAcc);
            //        this.chartAccuracy.Series["selectModelDataTrain"].ToolTip = string.Format("Epoch: {0}, Accuracy: {1:0.00}", locationX, trainAcc);
            //        this.chartAccuracy.Series["selectModelDataTest"].Points.Clear();
            //        this.chartAccuracy.Series["selectModelDataTest"].Points.AddXY(locationX, testAcc);
            //        this.chartAccuracy.Series["selectModelDataTest"].ToolTip = string.Format("Epoch: {0}, Accuracy: {1:0.00}", locationX, testAcc);
            //}
        }

        private void DgvMContinualLearningInnerModelSelecterSelectionChanged(object sender, EventArgs e)
        {
            if (dgvMContinualLearningInnerModelSelecter.SelectedRows[0].Index != -1) // 컬럼 해더 눌렀는지 감지 해더를 눌렀으면 통과
                if (this.dgvMContinualLearningInnerModelSelecter.Rows[dgvMContinualLearningInnerModelSelecter.SelectedRows[0].Index].Cells[0].Value != null)
                {
                    string innerModelName = WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["array_string_innerModelList"][dgvMContinualLearningInnerModelSelecter.SelectedRows[0].Index].ToString();

                    int locationX = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_locationX"]);

                    double trainLoss = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["double_TrainLoss"]);
                    double trainAcc = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["double_TrainAcc"]);
                    int trainEscape = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_TrainEscape"]);
                    int trainOverKill = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_TrainOverKill"]);

                    double testLoss = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["double_TestLoss"]);
                    double testAcc = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["double_TestAcc"]);
                    int testEscape = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_TestEscape"]);
                    int testOverKill = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][this.modelName]["InnerModelInfo"][innerModelName]["int_TestOverKill"]);

                    this.chartLoss.Series["selectModelDataTrain"].Points.Clear();
                    this.chartLoss.Series["selectModelDataTrain"].Points.AddXY(locationX, trainLoss);
                    this.chartLoss.Series["selectModelDataTrain"].ToolTip = string.Format("Epoch: {0}, Loss: {1:0.00}", locationX, trainLoss);
                    this.chartLoss.Series["selectModelDataTest"].Points.Clear();
                    this.chartLoss.Series["selectModelDataTest"].Points.AddXY(locationX, testLoss);
                    this.chartLoss.Series["selectModelDataTest"].ToolTip = string.Format("Epoch: {0}, Loss: {1:0.00}", locationX, testLoss);

                    this.chartAccuracy.Series["selectModelDataTrain"].Points.Clear();
                    this.chartAccuracy.Series["selectModelDataTrain"].Points.AddXY(locationX, trainAcc);
                    this.chartAccuracy.Series["selectModelDataTrain"].ToolTip = string.Format("Epoch: {0}, Accuracy: {1:0.00}", locationX, trainAcc);
                    this.chartAccuracy.Series["selectModelDataTest"].Points.Clear();
                    this.chartAccuracy.Series["selectModelDataTest"].Points.AddXY(locationX, testAcc);
                    this.chartAccuracy.Series["selectModelDataTest"].ToolTip = string.Format("Epoch: {0}, Accuracy: {1:0.00}", locationX, testAcc);
                }
        }

        /// <summary>
        /// 선택된 모델 경로 가져오기
        /// </summary>
        /// <returns></returns>
        public string GetModelPath()
        {
            return this.selectInnerModelPath;
        }

        /// <summary>
        /// 선택된 모델명
        /// </summary>
        /// <returns></returns>
        public string GetModelName()
        {
            return this.selectInnerModelName;
        }

        public string GetModelLoss()
        {
            return this.selectInnerModelLoss;
        }

        public string GetModelAccuracy()
        {
            return this.selectInnerModelAccuracy;
        }

        public string GetModelEscape()
        {
            return this.selectInnerModelEscape;
        }

        public string GetModelOverKill()
        {
            return this.selectInnerModelOverKill;
        }

        /*
this.selectInnerModelLoss = this.dgvMContinualLearningInnerModelSelecter.Rows[e.RowIndex].Cells[1].Value.ToString();
this.selectInnerModelAccuracy = this.dgvMContinualLearningInnerModelSelecter.Rows[e.RowIndex].Cells[2].Value.ToString();
this.selectInnerModelEscape = this.dgvMContinualLearningInnerModelSelecter.Rows[e.RowIndex].Cells[3].Value.ToString();
this.selectInnerModelOverKill = this.dgvMContinualLearningInnerModelSelecter.Rows[e.RowIndex].Cells[4].Value.ToString();
*/
    }
}