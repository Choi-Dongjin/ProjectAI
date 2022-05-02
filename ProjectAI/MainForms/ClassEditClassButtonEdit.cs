using MetroFramework.Components;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace ProjectAI.MainForms
{
    public partial class ClassEditClassButtonEdit : MetroForm
    {
        /// <summary>
        /// jsonDataManiger
        /// </summary>
        private JsonDataManiger jsonDataManiger = JsonDataManiger.GetInstance();

        /// <summary>
        /// 폼 메니저
        /// </summary>
        private FormsManiger formsManiger = FormsManiger.GetInstance();

        /// <summary>
        /// 외부에서 가져온 Button
        /// </summary>
        private ProjectAI.MainForms.UserContral.ClassEdit.ClassButton m_classButton;

        /// <summary>
        /// 진입 전 배경 Color Back Up, 취소시 적용
        /// </summary>
        private System.Drawing.Color m_backupClassButtonBackColor;

        /// <summary>
        /// 진입전 Text
        /// </summary>
        private string m_backupClassButtonText;

        /// <summary>
        ///
        /// </summary>
        /// <param name="classButton"></param>
        public ClassEditClassButtonEdit(ProjectAI.MainForms.UserContral.ClassEdit.ClassButton classButton)
        {
            InitializeComponent();

            this.m_classButton = classButton;

            this.m_backupClassButtonBackColor = this.m_classButton.TileBackColor;
            this.m_backupClassButtonText = this.m_classButton.TileText;

            this.tilMColor.BackColor = this.m_backupClassButtonBackColor;
            this.txtMClassName.Text = this.m_backupClassButtonText;

            this.StyleManager = this.metroStyleManager1;

            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;

            this.UpdataFormStyleManager(formsManiger.m_StyleManager);
        }

        ~ClassEditClassButtonEdit()
        {
            FormsManiger.m_formStyleManagerHandler -= this.UpdataFormStyleManager;
        }

        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            this.StyleManager.Style = styleManager.Style;
            this.StyleManager.Theme = styleManager.Theme;
        }

        /// <summary>
        /// UI가 아직 나타나지 않은 상태에서 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassEditClassButtonEditLoad(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 폼이 화면에 나타난 직후에 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassEditClassButtonEditShown(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 폼 닫을때의 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassEditClassButtonEditFormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void TileMColorClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.m_classButton.TileBackColor = colorDialog.Color;
                this.tilMColor.BackColor = colorDialog.Color;
            }
        }

        /// <summary>
        /// 확인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMOKClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMCancelClick(object sender, EventArgs e)
        {
            this.m_classButton.TileBackColor = this.m_backupClassButtonBackColor;
            this.m_classButton.TileText = this.m_backupClassButtonText;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Enter Key 입력이 있을때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtMClassNameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
                this.m_classButton.TileText = txtMClassName.Text;
        }

        /// <summary>
        /// 텍스트 박스가 포커스를 잃을때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtMClassNameLeave(object sender, EventArgs e)
        {
            this.m_classButton.TileText = txtMClassName.Text;
        }
    }
}