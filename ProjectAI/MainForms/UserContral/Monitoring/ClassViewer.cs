using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;


namespace ProjectAI.MainForms.UserContral.Monitoring
{
    public partial class ClassViewer : UserControl
    {
        public ClassViewer()
        {
            InitializeComponent();

            this.UISetClassInfoDataGridViewColumnsSetting(); // 컨트롤 셋업 ClassInfoDataGridView
            this.UpdateClassInfo();

            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            FormsManiger formsManiger = FormsManiger.GetInstance(); // 폼 메니저
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);
        }

        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            FormsManiger formsManiger = FormsManiger.GetInstance(); // 폼 메니저
            if (formsManiger.m_isDarkMode) // Light로 변경시 진입
            {

            }
            else // Dark로 변경시 진입
            {

            }

            this.metroStyleManager1.Style = styleManager.Style;
            this.metroStyleManager1.Theme = styleManager.Theme;
        }

        /// <summary>
        /// ClassInfoDataGridView 컨트롤 셋업
        /// </summary>
        private void UISetClassInfoDataGridViewColumnsSetting()
        {
            this.dgvMClassInfo.DataSource = null;
            this.dgvMClassInfo.Columns.Clear();
            this.dgvMClassInfo.Rows.Clear();
            this.dgvMClassInfo.Refresh();

            this.dgvMClassInfo.ColumnCount = 8;
            this.dgvMClassInfo.Columns[0].Name = "Name";
            this.dgvMClassInfo.Columns[1].Name = "Total"; // Total Labeled Image Number
            this.dgvMClassInfo.Columns[2].Name = "Train"; //Train Test
            this.dgvMClassInfo.Columns[3].Name = "Predicted";
            this.dgvMClassInfo.Columns[4].Name = "N/C";
            this.dgvMClassInfo.Columns[5].Name = "Recall";
            this.dgvMClassInfo.Columns[6].Name = "Precision";
            this.dgvMClassInfo.Columns[7].Name = "F-Score";
        }

        public void UpdateClassInfo()
        {
            this.UISetClassInfoInput(this.dgvMClassInfo);
            this.dgvMClassInfo.ClearSelection();
        }

        /// <summary>
        /// Class View에 정보 입력 하기
        /// </summary>
        /// <param name="metroGrid"> 적용된 Class View 관리 컨트롤 </param>
        private void UISetClassInfoInput(MetroFramework.Controls.MetroGrid metroGrid)
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
            {
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    if (WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] != null)
                    {
                        if (WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["string_array_classList"] != null)
                        {
                            metroGrid.Rows.Clear();
                            List<string> classNameList = new List<string>();
                            foreach (string className in WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["string_array_classList"])
                            {
                                classNameList.Add(className);
                            }

                            classNameList.Reverse();

                            for (int i = 0; i < classNameList.Count; i++)
                            {
                                string className = classNameList[i];
                                Color classColor = ColorTranslator.FromHtml(WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][className]["string_classColor"].ToString());
                                int classTotalNumber = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][className]["int_classImageTotalNumber"].ToString());
                                int classTrainNumber = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][className]["int_classImageTrainNumber"].ToString());

                                metroGrid.Rows.Add(className, classTotalNumber, classTrainNumber, 0, 0, 0, 0, 0);
                                metroGrid.Rows[i].Cells[0].Style.BackColor = classColor;
                                metroGrid.Rows[i].Cells[0].Style.ForeColor = Color.White;
                            }
                        }
                    }
                }
            }
        }

        private void DgvMClassInfoCellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvMClassInfo.CurrentCell = null;
            this.dgvMClassInfo.ClearSelection();
        }
    }
}
