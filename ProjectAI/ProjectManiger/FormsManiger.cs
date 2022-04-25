using MetroFramework.Components;
using System.Drawing;

namespace ProjectAI
{
    /// <summary>
    /// 이 클레스를 직접 호출하지 마세요. 싱글톤 구조가 적용되어 있음. GetInstance를 호출 하여 Class 획득
    /// </summary>
    public class FormsManiger
    {
        /// <summary>
        /// 싱글톤 패턴 구현을 위한 FormsManiger
        /// </summary>
        private static FormsManiger formsManiger;

        public delegate void FormStyleManagerHandler(MetroStyleManager FormStyleManager); // Form Style 변경시를 관리 옵저버 패턴(변형) 구현을 위한 delegate

        public static FormStyleManagerHandler m_formStyleManagerHandler; // Form Style 관리 Update Handler

        public delegate void FormlanguageManagerHandler(string FormlanguageManager); // Form language 변경시를 관리 옵저버 패턴(변형) 구현을 위한 delegate

        public static FormlanguageManagerHandler m_formlanguageManagerHandler; // Form language 관리 Update Handler

        public delegate void StartFormOptionsManagerHandler(); // StartForm, StartFormOptions 변경시를 관리 옵저버 패턴(변형) 구현을 위한 delegate

        public static StartFormOptionsManagerHandler m_startFormOptionsManagerHandler; // StartForm, StartFormOptions 변경시를 관리 Update Handler

        public delegate void MainFormsUIResetHandler(); // MainForms UI 적용된 부분 모두 비활성화 변경시를 관리 옵저버 패턴(변형) 구현을 위한 delegate

        public static MainFormsUIResetHandler m_mainFormsUIResetHandler; // MainForms UI 적용된 부분 모두 비활성화를 관리 Update Handler

        // forms Dark Mode chacker
        public bool m_isDarkMode = true;

        public MetroStyleManager m_StyleManager = new MetroStyleManager();

        private FormsManiger()
        {
        }

        /// <summary>
        /// Class 호출에 사용
        /// </summary>
        /// <returns></returns>
        public static FormsManiger GetInstance()
        {
            if (FormsManiger.formsManiger == null)
            {
                FormsManiger.formsManiger = new FormsManiger();
            }
            return FormsManiger.formsManiger;
        }
        
        public static void ChartDarkMode(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            try
            {
                // 차트 스타일 변경
                if (chart != null)
                {
                    chart.BackColor = Color.FromArgb(17, 17, 17);
                    chart.Legends[0].BackColor = Color.Transparent;
                    chart.Legends[0].ForeColor = Color.White;
                    chart.ChartAreas[0].BackColor = Color.Transparent;
                    chart.ChartAreas[0].AxisX.LineColor = Color.White;
                    chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
                    chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
                    chart.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.White;
                    chart.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.White;
                    chart.ChartAreas[0].AxisX.MinorTickMark.LineColor = Color.White;
                    chart.ChartAreas[0].AxisX.TitleForeColor = Color.White;
                    chart.ChartAreas[0].AxisY.LineColor = Color.White;
                    chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
                    chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
                    chart.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.White;
                    chart.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.White;
                    chart.ChartAreas[0].AxisY.MinorTickMark.LineColor = Color.White;

                    // 색변경
                    try
                    {
                        chart.Series["Train"].Color = ColorTranslator.FromHtml("#e124f2");
                        chart.Series["Test"].Color = ColorTranslator.FromHtml("#fa484e");
                        chart.Series["selectModelDataTrain"].Color = ColorTranslator.FromHtml("#6373ff");
                        chart.Series["selectModelDataTest"].Color = ColorTranslator.FromHtml("#fcff52");
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }
        public static void ChartWhiteMode(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            try
            {
                // 차트 스타일 변경
                if (chart != null)
                {
                    chart.BackColor = Color.White;
                    chart.Legends[0].BackColor = Color.Transparent;
                    chart.Legends[0].ForeColor = Color.Black;
                    chart.ChartAreas[0].BackColor = Color.Transparent;
                    chart.ChartAreas[0].AxisX.LineColor = Color.Black;
                    chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
                    chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Black;
                    chart.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.Black;
                    chart.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.Black;
                    chart.ChartAreas[0].AxisX.MinorTickMark.LineColor = Color.Black;
                    chart.ChartAreas[0].AxisX.TitleForeColor = Color.Black;
                    chart.ChartAreas[0].AxisY.LineColor = Color.Black;
                    chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
                    chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Black;
                    chart.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.Black;
                    chart.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.Black;
                    chart.ChartAreas[0].AxisY.MinorTickMark.LineColor = Color.Black;

                    // 색변경
                    try
                    {
                        chart.Series["Train"].Color = ColorTranslator.FromHtml("#e124f2");
                        chart.Series["Test"].Color = ColorTranslator.FromHtml("#fa484e");
                        chart.Series["selectModelDataTrain"].Color = ColorTranslator.FromHtml("#001aff"); 
                        chart.Series["selectModelDataTest"].Color = ColorTranslator.FromHtml("#ff6f00");
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 각 Forms Calss formStyleManager Update Handler 등록
        /// </summary>
        public void FormStyleManagerHandlerEnrollment()
        {
        }

        /// <summary>
        /// 각 Forms Calss mformlanguageManagerHandler 등록
        /// </summary>
        public void FormlanguageManagerHandlerEnrollment()
        {
        }

        /// <summary>
        /// StartForm, StartFormOptions 변경시를 관리 Update Handler 등록
        /// </summary>
        public void StartFormOptionsManagerHandlerEnrollment()
        {
            // 각 해당 Class 에서 관리 하도록 수정
            //if (StartForm != null)
            //    FormsManiger.m_startFormOptionsManagerHandler += this.StartForm.IfStartOptionsChange;
            //FormsManiger.m_startFormOptionsManagerHandler += Program.IfProgramEntryPointOptionsChange;
            //FormsManiger.m_startFormOptionsManagerHandler += WorkSpaceEarlyData.ProgramVariablesChange;
        }

        internal System.Drawing.Color GetStyleRGBClor(string colorName)
        {
            Color color = new Color();

            if (colorName == "Lime") { color = Color.FromArgb(142, 188, 0); }
            else if (colorName == "Silver") { color = Color.FromArgb(85, 85, 85); }
            return color;
        }

        internal System.Drawing.Color GetThemeRGBClor(string colorName)
        {
            Color color = new Color();

            if (colorName == "Light") { color = Color.FromArgb(255, 255, 255); }
            else if (colorName == "Dark") { color = Color.FromArgb(17, 17, 17); }
            return color;
        }
    }
}