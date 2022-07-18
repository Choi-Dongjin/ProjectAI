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

namespace ProjectAI.MainForms.UserContral.ProjectSelect
{
    public partial class ImputDataTypeButton : UserControl
    {
        private MetroFramework.Controls.MetroButton metroButton = new MetroFramework.Controls.MetroButton();
        private MetroFramework.Controls.MetroTextBox metroTextBox = new MetroFramework.Controls.MetroTextBox();

        private string saveSettingText;

        private string savetitleText;
        private System.Drawing.Image saveSttingImage;

        private string saveButtonClickRetrun;

        /// <summary>
        /// 폼 메니저
        /// </summary>
        private FormsManiger formsManiger = FormsManiger.GetInstance();

        /// <summary>
        /// 버튼 클릭 이벤트 헨들러 BtnMactiveButton Click EvnetHandler
        /// </summary>
        [Description("Click Evnet"), Category("Custom Button")]
        public event EventHandler BtnMactiveButtonClickEvnetHandler;

        [Description("Enter Button"), Category("Custom Button")]
        public event EventHandler BtnMactiveButtonEnterEvnetHandler;

        [Description("Leave Button"), Category("Custom Button")]
        public event EventHandler BtnMactiveButtonLeaveEvnetHandler;

        /// <summary>
        /// 버튼 클릭 이벤트 헨들러 BtnMactiveButton Click EvnetHandler
        /// </summary>
        [Description("TextBox Button"), Category("Custom Button")]
        public event EventHandler TxtMTextBoxClickEvnetHandler;

        public ImputDataTypeButton()
        {
            InitializeComponent();
            this.ButtonSetting(); // 초기 버튼 셋팅
            this.LabelSetting();
            this.metroPanel1.Controls.Add(this.metroButton);
        }

        private void ControlReset()
        {
            ButtonSetting();
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
        }

        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            this.metroStyleManager1.Style = styleManager.Style;
            this.metroStyleManager1.Theme = styleManager.Theme;
        }

        /// <summary>
        /// BtnSingleImage Click EvnetHandler 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnMactiveButtonClickEvent(object sender, EventArgs e)
        {
            if (this.BtnMactiveButtonClickEvnetHandler != null)
                BtnMactiveButtonClickEvnetHandler(sender, e);
        }

        public void BtnMmouseEnter(object sender, EventArgs e)
        {
            if (this.BtnMactiveButtonEnterEvnetHandler != null)
                BtnMactiveButtonEnterEvnetHandler(sender, e);
        }

        public void BtnMmouseLeave(object sender, EventArgs e)
        {
            if (this.BtnMactiveButtonLeaveEvnetHandler != null)
                BtnMactiveButtonLeaveEvnetHandler(sender, e);
        }

        /// <summary>
        /// TxtSingleImage Click EvnetHandler 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TxtMactiveButtonClickEvent(object sender, EventArgs e)
        {
            if (this.TxtMTextBoxClickEvnetHandler != null)
                TxtMTextBoxClickEvnetHandler(sender, e);
        }

        /// <summary>
        /// 버튼 실행 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>\
        private void BtnMactiveButtonClick(object sender, EventArgs e)
        {
            this.metroPanel1.Controls.Clear();
            //this.Size = new System.Drawing.Size(240, 160);
            this.metroPanel1.Controls.Add(this.metroTextBox);
            //LabelSetting();
        }

        /// <summary>
        /// 라벨 선택시 실행.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroTextBoxClick(object sender, EventArgs e)
        {
            this.metroPanel1.Controls.Clear();
            //this.Size = new System.Drawing.Size(160, 184);
            this.metroPanel1.Controls.Add(this.metroButton);
        }

        public void ButtonActive()
        {
            this.metroPanel1.Controls.Clear();
            this.metroPanel1.Controls.Add(this.metroButton);
        }

        public void TextBoxActive()
        {
            this.metroPanel1.Controls.Clear();
            this.metroPanel1.Controls.Add(this.metroTextBox);
        }

        /// <summary>
        /// 버튼 셋팅
        /// </summary>
        public void ButtonSetting()
        {
            this.metroButton = new MetroFramework.Controls.MetroButton();

            //
            // btnMactiveButton
            //
            this.metroButton.BackgroundImage = null;
            this.metroButton.BackgroundImage = this.saveSttingImage;
            this.metroButton.Highlight = true;
            this.metroButton.Style = formsManiger.m_StyleManager.Style;
            this.metroButton.Theme = formsManiger.m_StyleManager.Theme;
            this.metroButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroButton.Location = new System.Drawing.Point(0, 24);
            this.metroButton.Margin = new System.Windows.Forms.Padding(0);
            this.metroButton.Name = this.savetitleText;
            this.metroButton.Size = new System.Drawing.Size(160, 160);
            //this.metroButton.TabIndex = 1;
            this.metroButton.UseSelectable = true;
            this.metroButton.Click += new System.EventHandler(this.BtnMactiveButtonClick);
            // btnMactiveButton Click에 이벤트 등록
            this.metroButton.Click += BtnMactiveButtonClickEvent;

            // 마우스 진입 확인
            this.metroButton.MouseEnter += this.BtnMmouseEnter;
            // 마우스 나가기 확인
            this.metroButton.MouseLeave += this.BtnMmouseLeave;
        }

        /// <summary>
        /// 라벨 셋팅
        /// </summary>
        private void LabelSetting()
        {
            //
            // metroTextBox1
            //
            this.metroTextBox.Style = formsManiger.m_StyleManager.Style;
            this.metroTextBox.Theme = formsManiger.m_StyleManager.Theme;
            this.metroTextBox.CustomButton.Image = null;
            this.metroTextBox.CustomButton.Location = new System.Drawing.Point(191, 2);
            this.metroTextBox.CustomButton.Name = "";
            this.metroTextBox.CustomButton.Size = new System.Drawing.Size(155, 155);
            this.metroTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox.CustomButton.TabIndex = 1;
            this.metroTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox.CustomButton.UseSelectable = true;
            this.metroTextBox.CustomButton.Visible = false;
            this.metroTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            //this.metroTextBox.Lines = new string[] {"metrotextbox1"};
            this.metroTextBox.Location = new System.Drawing.Point(0, 24);
            this.metroTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.metroTextBox.MaxLength = 32767;
            this.metroTextBox.Multiline = true;
            this.metroTextBox.Name = "metroTextBox";
            this.metroTextBox.PasswordChar = '\0';
            this.metroTextBox.ReadOnly = true;
            this.metroTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox.SelectedText = "";
            this.metroTextBox.SelectionLength = 0;
            this.metroTextBox.SelectionStart = 0;
            this.metroTextBox.ShortcutsEnabled = true;
            this.metroTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.metroTextBox.Size = new System.Drawing.Size(240, 160);
            this.metroTextBox.TabIndex = 2;
            this.metroTextBox.Text = saveSettingText;
            this.metroTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBox.UseSelectable = false;
            this.metroTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);

            this.metroTextBox.Click += new System.EventHandler(this.MetroTextBoxClick);
            // TxtMactiveButton Click에 이벤트 등록
            this.metroTextBox.Click += TxtMactiveButtonClickEvent;
        }

        #region WorkSpace 속성 추가

        [Category("Custom Button"), Description("Title")]
        public string Title
        {
            get
            {
                return this.savetitleText;
            }
            set
            {
                this.savetitleText = value;
                this.lblMtitle.Text = value;
            }
        }

        [Category("Custom Button"), Description("Background Image")]
        public System.Drawing.Image MBBackgroundImage
        {
            get
            {
                return this.metroButton.BackgroundImage;
            }
            set
            {
                this.saveSttingImage = value;
                this.metroButton.BackgroundImage = value;
            }
        }

        [Category("Custom Button"), Description("Title과 같게 설정 CustomButtonName 초기값 넣어주는 것 Title과 다르면 오류나 한번에 동작하지 않음.  ")]
        public string CustomButtonName
        {
            get
            {
                return this.metroButton.Name;
            }
            set
            {
                this.metroButton.Name = value;
            }
        }

        [Category("Custom Button"), Description("Label Text")]
        public string InputLabelText
        {
            get
            {
                return this.metroTextBox.Text;
            }
            set
            {
                this.saveSettingText = value;
                this.metroTextBox.Text = value;
            }
        }

        [Category("Custom Button"), Description("버튼 활성화시 반환해줄 값 Input Data Type 과 같게 만들기, 띄어쓰기 없이")]
        public string ButtonClickRetrun
        {
            get
            {
                return this.saveButtonClickRetrun;
            }
            set
            {
                this.saveButtonClickRetrun = value;
            }
        }

        #endregion WorkSpace 속성 추가
    }
}