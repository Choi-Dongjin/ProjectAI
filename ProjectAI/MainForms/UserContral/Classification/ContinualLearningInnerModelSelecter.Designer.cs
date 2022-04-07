namespace ProjectAI.MainForms.UserContral.Classification
{
    partial class ContinualLearningInnerModelSelecter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea23 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend23 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series89 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series90 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series91 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series92 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea24 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend24 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series93 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series94 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series95 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series96 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.chartLoss = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAccuracy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvMContinualLearningInnerModelSelecter = new MetroFramework.Controls.MetroGrid();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAccuracy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMContinualLearningInnerModelSelecter)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartLoss
            // 
            chartArea23.AxisX.Title = "Epoch";
            chartArea23.Name = "ChartArea1";
            this.chartLoss.ChartAreas.Add(chartArea23);
            this.chartLoss.Dock = System.Windows.Forms.DockStyle.Top;
            legend23.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend23.MaximumAutoSize = 10F;
            legend23.Name = "Legend1";
            this.chartLoss.Legends.Add(legend23);
            this.chartLoss.Location = new System.Drawing.Point(0, 25);
            this.chartLoss.Margin = new System.Windows.Forms.Padding(0);
            this.chartLoss.Name = "chartLoss";
            series89.ChartArea = "ChartArea1";
            series89.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series89.Legend = "Legend1";
            series89.LegendText = "Train & Validation";
            series89.Name = "Train & Validation";
            series90.ChartArea = "ChartArea1";
            series90.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series90.Legend = "Legend1";
            series90.LegendText = "Test";
            series90.Name = "Test";
            series91.ChartArea = "ChartArea1";
            series91.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series91.IsVisibleInLegend = false;
            series91.Legend = "Legend1";
            series91.Name = "selectModelDataTrain";
            series92.ChartArea = "ChartArea1";
            series92.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series92.IsVisibleInLegend = false;
            series92.Legend = "Legend1";
            series92.Name = "selectModelDataTest";
            series92.YValuesPerPoint = 2;
            this.chartLoss.Series.Add(series89);
            this.chartLoss.Series.Add(series90);
            this.chartLoss.Series.Add(series91);
            this.chartLoss.Series.Add(series92);
            this.chartLoss.Size = new System.Drawing.Size(524, 171);
            this.chartLoss.SuppressExceptions = true;
            this.chartLoss.TabIndex = 25;
            this.chartLoss.Text = "chartLoss";
            // 
            // chartAccuracy
            // 
            chartArea24.AxisX.Title = "Epoch";
            chartArea24.Name = "ChartArea1";
            this.chartAccuracy.ChartAreas.Add(chartArea24);
            this.chartAccuracy.Dock = System.Windows.Forms.DockStyle.Top;
            legend24.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend24.MaximumAutoSize = 10F;
            legend24.Name = "Legend1";
            this.chartAccuracy.Legends.Add(legend24);
            this.chartAccuracy.Location = new System.Drawing.Point(0, 25);
            this.chartAccuracy.Margin = new System.Windows.Forms.Padding(0);
            this.chartAccuracy.Name = "chartAccuracy";
            series93.ChartArea = "ChartArea1";
            series93.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series93.Legend = "Legend1";
            series93.LegendText = "Train & Validation";
            series93.Name = "Train & Validation";
            series94.ChartArea = "ChartArea1";
            series94.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series94.Legend = "Legend1";
            series94.LegendText = "Test";
            series94.Name = "Test";
            series95.ChartArea = "ChartArea1";
            series95.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series95.IsVisibleInLegend = false;
            series95.Legend = "Legend1";
            series95.Name = "selectModelDataTrain";
            series96.ChartArea = "ChartArea1";
            series96.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series96.IsVisibleInLegend = false;
            series96.Legend = "Legend1";
            series96.Name = "selectModelDataTest";
            series96.YValuesPerPoint = 2;
            this.chartAccuracy.Series.Add(series93);
            this.chartAccuracy.Series.Add(series94);
            this.chartAccuracy.Series.Add(series95);
            this.chartAccuracy.Series.Add(series96);
            this.chartAccuracy.Size = new System.Drawing.Size(524, 171);
            this.chartAccuracy.SuppressExceptions = true;
            this.chartAccuracy.TabIndex = 27;
            this.chartAccuracy.Text = "chart1";
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.dgvMContinualLearningInnerModelSelecter, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1310, 400);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvMContinualLearningInnerModelSelecter
            // 
            this.dgvMContinualLearningInnerModelSelecter.AllowUserToAddRows = false;
            this.dgvMContinualLearningInnerModelSelecter.AllowUserToDeleteRows = false;
            this.dgvMContinualLearningInnerModelSelecter.AllowUserToResizeRows = false;
            this.dgvMContinualLearningInnerModelSelecter.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMContinualLearningInnerModelSelecter.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvMContinualLearningInnerModelSelecter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMContinualLearningInnerModelSelecter.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMContinualLearningInnerModelSelecter.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMContinualLearningInnerModelSelecter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMContinualLearningInnerModelSelecter.DefaultCellStyle = dataGridViewCellStyle35;
            this.dgvMContinualLearningInnerModelSelecter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMContinualLearningInnerModelSelecter.EnableHeadersVisualStyles = false;
            this.dgvMContinualLearningInnerModelSelecter.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvMContinualLearningInnerModelSelecter.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvMContinualLearningInnerModelSelecter.Location = new System.Drawing.Point(0, 0);
            this.dgvMContinualLearningInnerModelSelecter.Margin = new System.Windows.Forms.Padding(0);
            this.dgvMContinualLearningInnerModelSelecter.MultiSelect = false;
            this.dgvMContinualLearningInnerModelSelecter.Name = "dgvMContinualLearningInnerModelSelecter";
            this.dgvMContinualLearningInnerModelSelecter.ReadOnly = true;
            this.dgvMContinualLearningInnerModelSelecter.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMContinualLearningInnerModelSelecter.RowHeadersDefaultCellStyle = dataGridViewCellStyle36;
            this.dgvMContinualLearningInnerModelSelecter.RowHeadersVisible = false;
            this.dgvMContinualLearningInnerModelSelecter.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tableLayoutPanel1.SetRowSpan(this.dgvMContinualLearningInnerModelSelecter, 2);
            this.dgvMContinualLearningInnerModelSelecter.RowTemplate.Height = 23;
            this.dgvMContinualLearningInnerModelSelecter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMContinualLearningInnerModelSelecter.Size = new System.Drawing.Size(786, 400);
            this.dgvMContinualLearningInnerModelSelecter.Style = MetroFramework.MetroColorStyle.Silver;
            this.dgvMContinualLearningInnerModelSelecter.TabIndex = 4;
            this.dgvMContinualLearningInnerModelSelecter.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dgvMContinualLearningInnerModelSelecter.UseStyleColors = true;
            this.dgvMContinualLearningInnerModelSelecter.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMContinualLearningInnerModelSelecterCellMouseClick);
            this.dgvMContinualLearningInnerModelSelecter.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMContinualLearningInnerModelSelecterCellMouseDoubleClick);
            this.dgvMContinualLearningInnerModelSelecter.SelectionChanged += new System.EventHandler(this.DgvMContinualLearningInnerModelSelecterSelectionChanged);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.chartLoss);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(786, 0);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(524, 200);
            this.metroPanel1.TabIndex = 5;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(0, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(47, 25);
            this.metroLabel2.TabIndex = 24;
            this.metroLabel2.Text = "Loss";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.chartAccuracy);
            this.metroPanel2.Controls.Add(this.metroLabel3);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(786, 200);
            this.metroPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(524, 200);
            this.metroPanel2.TabIndex = 6;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(0, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(82, 25);
            this.metroLabel3.TabIndex = 26;
            this.metroLabel3.Text = "Accuracy";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ContinualLearningInnerModelSelecter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContinualLearningInnerModelSelecter";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ContinualLearningInnerModelSelecter";
            this.Load += new System.EventHandler(this.ContinualLearningInnerModelSelecterLoad);
            this.Shown += new System.EventHandler(this.ContinualLearningInnerModelSelecterShown);
            ((System.ComponentModel.ISupportInitialize)(this.chartLoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAccuracy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMContinualLearningInnerModelSelecter)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroGrid dgvMContinualLearningInnerModelSelecter;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLoss;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAccuracy;
    }
}