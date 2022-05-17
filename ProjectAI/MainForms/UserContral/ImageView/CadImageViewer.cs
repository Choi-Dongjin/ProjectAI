using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using System.IO;

namespace ProjectAI.MainForms.UserContral.ImageView
{
    public partial class CadImageViewer : UserControl
    {
        public CadImageViewer()
        {
            InitializeComponent();
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            FormsManiger formsManiger = FormsManiger.GetInstance(); // 폼 메니저
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);
        }

        private void UpdataFormStyleManager(MetroStyleManager m_StyleManager)
        {
            FormsManiger formsManiger = FormsManiger.GetInstance(); // 폼 메니저
            if (formsManiger.m_isDarkMode) // Light로 변경시 진입
            {
                this.pictureBox1.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Brightness;
                this.pictureBox2.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Brightness;
            }
            else // Dark로 변경시 진입
            {
                this.pictureBox1.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Black;
                this.pictureBox2.BackgroundImage = global::ProjectAI.Properties.Resources.imageBackground2Black;
            }

            this.metroStyleManager1.Style = m_StyleManager.Style;
            this.metroStyleManager1.Theme = m_StyleManager.Theme;
        }

        private void OverlayView_CheckedChanged(object sender, EventArgs e)
        {
            if (OverlayViewCheckBox.Checked)
            {
                cadOverView1.Visible = true;

                if (WorkSpaceData.m_activeProjectMainger.m_imageListDictionary[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] is ProjectAI.MainForms.UserContral.ImageList.GridViewImageList GridViewImageList)
                {
                    DataGridViewRow row = GridViewImageList.gridImageList.SelectedRows[0]; //선택된 Row 값 가져옴.
                    string data = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[0]) = name

                    this.CADImageLabel.BackColor = System.Drawing.Color.ForestGreen;
                    this.CADImageLabel.Text = "OverlayImage";

                    WorkSpaceData.m_activeProjectMainger.PrintImage(data);
                }
            }
            else
            {
                 if (WorkSpaceData.m_activeProjectMainger.m_imageListDictionary[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] is ProjectAI.MainForms.UserContral.ImageList.GridViewImageList GridViewImageList)
                {
                    DataGridViewRow row = GridViewImageList.gridImageList.SelectedRows[0]; //선택된 Row 값 가져옴.
                    string data = row.Cells[1].Value.ToString(); // row의 컬럼(Cells[0]) = name
                    cadOverView1.Visible = false;

                    this.CADImageLabel.BackColor = System.Drawing.Color.Lime;
                    this.CADImageLabel.Text = "CADImage";

                    WorkSpaceData.m_activeProjectMainger.PrintImage(data);
                }
            }
        }
    }
}
