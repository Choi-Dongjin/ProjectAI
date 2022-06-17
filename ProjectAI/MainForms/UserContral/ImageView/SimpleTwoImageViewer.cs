using MetroFramework.Components;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectAI.MainForms.UserContral.ImageView
{
    public partial class SimpleTwoImageViewer : UserControl
    {
        private ProjectManiger.ImageToolUseingPictureBox imageToolUseingPictureBox1;
        private ProjectManiger.ImageToolUseingPictureBox imageToolUseingPictureBox2;

        public SimpleTwoImageViewer()
        {
            InitializeComponent();
            this.imageToolUseingPictureBox1 = new ProjectManiger.ImageToolUseingPictureBox(this.pictureBox1);
            this.imageToolUseingPictureBox2 = new ProjectManiger.ImageToolUseingPictureBox(this.pictureBox2);

            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            FormsManiger formsManiger = FormsManiger.GetInstance(); // 폼 메니저
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);
        }

        public void UpdataFormStyleManager(MetroStyleManager styleManager)
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

            this.metroStyleManager1.Style = styleManager.Style;
            this.metroStyleManager1.Theme = styleManager.Theme;
        }

        public void BitmapImageInput1(Bitmap bitmap)
        {
            this.imageToolUseingPictureBox1.InputBitmapImage(bitmap);
        }

        public void BitmapImageInput2(Bitmap bitmap)
        {
            this.imageToolUseingPictureBox2.InputBitmapImage(bitmap);
        }
    }
}