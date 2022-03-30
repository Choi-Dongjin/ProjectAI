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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series33 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series34 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series35 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series36 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series37 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series38 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series39 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series40 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.metroStyleExtender1.SetApplyMetroTheme(this.chartLoss, true);
            chartArea9.AxisX.Title = "Epoch";
            chartArea9.Name = "ChartArea1";
            this.chartLoss.ChartAreas.Add(chartArea9);
            this.chartLoss.Dock = System.Windows.Forms.DockStyle.Top;
            legend9.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend9.MaximumAutoSize = 10F;
            legend9.Name = "Legend1";
            this.chartLoss.Legends.Add(legend9);
            this.chartLoss.Location = new System.Drawing.Point(0, 25);
            this.chartLoss.Margin = new System.Windows.Forms.Padding(0);
            this.chartLoss.Name = "chartLoss";
            series33.ChartArea = "ChartArea1";
            series33.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series33.Legend = "Legend1";
            series33.LegendText = "Train & Validation";
            series33.Name = "Train & Validation";
            series34.ChartArea = "ChartArea1";
            series34.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series34.Legend = "Legend1";
            series34.LegendText = "Test";
            series34.Name = "Test";
            series35.ChartArea = "ChartArea1";
            series35.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series35.IsVisibleInLegend = false;
            series35.Legend = "Legend1";
            series35.Name = "selectModelDataTrain";
            series36.ChartArea = "ChartArea1";
            series36.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series36.IsVisibleInLegend = false;
            series36.Legend = "Legend1";
            series36.Name = "selectModelDataTest";
            series36.YValuesPerPoint = 2;
            this.chartLoss.Series.Add(series33);
            this.chartLoss.Series.Add(series34);
            this.chartLoss.Series.Add(series35);
            this.chartLoss.Series.Add(series36);
            this.chartLoss.Size = new System.Drawing.Size(524, 171);
            this.chartLoss.SuppressExceptions = true;
            this.chartLoss.TabIndex = 25;
            this.chartLoss.Text = "chartLoss";
            // 
            // chartAccuracy
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.chartAccuracy, true);
            chartArea10.AxisX.Title = "Epoch";
            chartArea10.Name = "ChartArea1";
            this.chartAccuracy.ChartAreas.Add(chartArea10);
            this.chartAccuracy.Dock = System.Windows.Forms.DockStyle.Top;
            legend10.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend10.MaximumAutoSize = 10F;
            legend10.Name = "Legend1";
            this.chartAccuracy.Legends.Add(legend10);
            this.chartAccuracy.Location = new System.Drawing.Point(0, 25);
            this.chartAccuracy.Margin = new System.Windows.Forms.Padding(0);
            this.chartAccuracy.Name = "chartAccuracy";
            series37.ChartArea = "ChartArea1";
            series37.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series37.Legend = "Legend1";
            series37.LegendText = "Train & Validation";
            series37.Name = "Train & Validation";
            series38.ChartArea = "ChartArea1";
            series38.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series38.Legend = "Legend1";
            series38.LegendText = "Test";
            series38.Name = "Test";
            series39.ChartArea = "ChartArea1";
            series39.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series39.IsVisibleInLegend = false;
            series39.Legend = "Legend1";
            series39.Name = "selectModelDataTrain";
            series40.ChartArea = "ChartArea1";
            series40.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series40.IsVisibleInLegend = false;
            series40.Legend = "Legend1";
            series40.Name = "selectModelDataTest";
            series40.YValuesPerPoint = 2;
            this.chartAccuracy.Series.Add(series37);
            this.chartAccuracy.Series.Add(series38);
            this.chartAccuracy.Series.Add(series39);
            this.chartAccuracy.Series.Add(series40);
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
            this.dgvMContinualLearningInnerModelSelecter.AllowUserToResizeRows = false;
            this.dgvMContinualLearningInnerModelSelecter.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMContinualLearningInnerModelSelecter.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvMContinualLearningInnerModelSelecter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMContinualLearningInnerModelSelecter.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMContinualLearningInnerModelSelecter.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMContinualLearningInnerModelSelecter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMContinualLearningInnerModelSelecter.DefaultCellStyle = dataGridViewCellStyle14;
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
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMContinualLearningInnerModelSelecter.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
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