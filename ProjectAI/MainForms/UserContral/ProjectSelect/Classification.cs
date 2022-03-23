using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAI.MainForms.UserContral.ProjectSelect
{
    public partial class Classification : UserControl
    {
        /// <summary>
        /// 버튼 클릭 이벤트 헨들러 BtnWorkSpaceOpen Click EvnetHandler
        /// </summary>
        [Description("Single Image Button"), Category("Custom Button")]
        public event EventHandler BtnSingleImageClickEvnetHandler;

        /// <summary>
        /// 텍스트 박스 이벤트 헨들러 BtnWorkSpaceOpen Click EvnetHandler
        /// </summary>
        [Description("Single Image Button"), Category("Custom Button")]
        public event EventHandler TxtSingleImageClickEvnetHandler;

        /// <summary>
        /// 버튼 클릭 이벤트 헨들러 BtnWorkSpaceOpen Click EvnetHandler
        /// </summary>
        [Description("Multi Image Button"), Category("Custom Button")]
        public event EventHandler BtnMultiImageClickEvnetHandler;

        /// <summary>
        /// 버튼 클릭 이벤트 헨들러 BtnWorkSpaceOpen Click EvnetHandler
        /// </summary>
        [Description("Multi Image Button"), Category("Custom Button")]
        public event EventHandler TxtMultiImageClickEvnetHandler;

        /// <summary>
        /// 버튼 클릭 이벤트 헨들러 BtnWorkSpaceOpen Click EvnetHandler
        /// </summary>
        [Description("None Button"), Category("Custom Button")]
        public event EventHandler BtnNoneClickEvnetHandler;

        /// <summary>
        /// 버튼 클릭 이벤트 헨들러 BtnWorkSpaceOpen Click EvnetHandler
        /// </summary>
        [Description("Multi Image Button"), Category("Custom Button")]
        public event EventHandler TxtNoneClickEvnetHandler;

        FormsManiger formsManiger = FormsManiger.GetInstance();

        public Classification()
        {
            InitializeComponent();

            // btnSingleImage Click에 이벤트 함수 등록
            this.btnSingleImage.BtnMactiveButtonClickEvnetHandler += BtnSingleImageClickEvent;
            // TxtSingleImage Click에 이벤트 함수 등록
            this.btnSingleImage.TxtMTextBoxClickEvnetHandler += TxtSingleImageClickEvent;

            // btnMultiImage Click에 이벤트 함수 등록
            this.btnMultiImage.BtnMactiveButtonClickEvnetHandler += BtnMultiImageClickEvent;
            // TxtMultiImage Click에 이벤트 함수 등록
            this.btnMultiImage.TxtMTextBoxClickEvnetHandler += TxtMultiImageClickEvent;

            // btnNoneImage Click에 이벤트 함수 등록
            this.btnNoneImage.BtnMactiveButtonClickEvnetHandler += BtnNoneClickEvent;
            // TxtMNoneImage Click에 이벤트 함수 등록
            this.btnNoneImage.TxtMTextBoxClickEvnetHandler += TxtNoneClickEvent;


            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);

            // 초기화
            this.UIReset();
        }

        private void UIReset()
        {
            DisableText();
        }

        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        public void UpdataFormStyleManager(MetroFramework.Components.MetroStyleManager styleManager)
        {
            this.metroStyleManagerClassification.Style = styleManager.Style;
            this.metroStyleManagerClassification.Theme = styleManager.Theme;
        }

        /// <summary>
        /// 클릭한 버튼만 제외 하고 비활성화 하기
        /// </summary>
        /// <param name="btnSender"></param>
        private void DisableButton(object btnSender)
        {
            foreach (Control previousBtn in metroPanel2.Controls)
            {
                if (previousBtn.GetType() == typeof(ProjectAI.MainForms.UserContral.ProjectSelect.ImputDataTypeButton))
                {
                    ImputDataTypeButton passbutton = (ImputDataTypeButton)previousBtn; // ImputDataTypeButton 타이틀
                    MetroFramework.Controls.MetroButton clickButton = (MetroFramework.Controls.MetroButton)btnSender; // 선택된 버튼 MetroButton 이름 비교
                    /*
                     * ImputDataTypeButton 타이틀과 활성화된 MetroButton 이름을 동일하게 셋팅하였음. 
                     * 따라서 ImputDataTypeButton 타이틀과 활성화된 MetroButton 이름 비교하여 
                     * 같으면 비활성화 하지 않고 다르면 모두 비활성화
                    */
                    Console.WriteLine("");
                    Console.WriteLine("=== === === === === === === === === === ===");
                    Console.WriteLine($"passbutton.Title: {passbutton.Title}");
                    Console.WriteLine($"clickButton.Name: {clickButton.Name}");
                    Console.WriteLine("=== === === === === === === === === === ===");
                    Console.WriteLine("");
                    if (passbutton.Title != clickButton.Name)
                    {
                        try
                        {
                            passbutton.ButtonSetting();
                            passbutton.Size = new Size(160, 0);
                        }
                        catch { }
                    }
                    else
                    {

                    }
                }
            }
        }


        private void DisableText(object btnSender = null)
        {
            List<Control> previousBtnList = new List<Control>();
            foreach (Control previousBtn in metroPanel2.Controls)
                if (previousBtn.GetType() == typeof(ProjectAI.MainForms.UserContral.ProjectSelect.ImputDataTypeButton))
                    previousBtnList.Add(previousBtn);

            int width = metroPanel2.Size.Width / previousBtnList.Count;
            foreach (Control previousBtn in previousBtnList)
            {
                ImputDataTypeButton passbutton = (ImputDataTypeButton)previousBtn; // ImputDataTypeButton 타이틀
                passbutton.Size = new Size(width, 0);
            }
        }

        /// <summary>
        /// BtnSingleImage Click EvnetHandler 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnSingleImageClickEvent(object sender, EventArgs e)
        {
            if (this.BtnSingleImageClickEvnetHandler != null)
            {
                this.DisableButton(sender);
                BtnSingleImageClickEvnetHandler(sender, e);
            }
                
        }
        /// <summary>
        /// TxtSingleImage Click EvnetHandler 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TxtSingleImageClickEvent(object sender, EventArgs e)
        {
            if (this.TxtSingleImageClickEvnetHandler != null)
            {
                this.DisableText(sender);
                TxtSingleImageClickEvnetHandler(sender, e);
            }
        }

        /// <summary>
        /// BtnMultiImage Click EvnetHandler 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnMultiImageClickEvent(object sender, EventArgs e)
        {
            if (this.BtnMultiImageClickEvnetHandler != null)
            {
                this.DisableButton(sender);
                BtnMultiImageClickEvnetHandler(sender, e);
            }
        }
        /// <summary>
        /// BtnMultiImage Click EvnetHandler 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TxtMultiImageClickEvent(object sender, EventArgs e)
        {
            if (this.TxtMultiImageClickEvnetHandler != null)
            {
                this.DisableText(sender);
                TxtMultiImageClickEvnetHandler(sender, e);
            }
        }

        /// <summary>
        /// BtnNone Click EvnetHandler 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnNoneClickEvent(object sender, EventArgs e)
        {
            if (this.BtnNoneClickEvnetHandler != null)
            {
                this.DisableButton(sender);
                BtnNoneClickEvnetHandler(sender, e);
            }
        }

        /// <summary>
        /// BtnMultiImage Click EvnetHandler 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TxtNoneClickEvent(object sender, EventArgs e)
        {
            if (this.TxtNoneClickEvnetHandler != null)
            {
                this.DisableText(sender);
                TxtNoneClickEvnetHandler(sender, e);
            }
        }
    }
}
