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

namespace ProjectAI.MainForms
{
    public partial class WorkSpaceButton : UserControl
    {
        /// <summary>
        /// 버튼 클릭 이벤트 헨들러 BtnWorkSpaceOpen Click EvnetHandler
        /// </summary>
        [Description("WorkSpaceOpen Click Evnet"), Category("WorkSpace")]
        public event EventHandler BtnWorkSpaceOpenClickEvnetHandler;

        /// <summary>
        /// Forms 관리 Class
        /// </summary>
        FormsManiger formsManiger = FormsManiger.GetInstance();

        public WorkSpaceButton()
        {
            InitializeComponent();
            
            // btnWorkSpaceOpen Click에 이벤트 등록
            this.btnWorkSpaceOpen.Click += BtnWorkSpaceOpenClickEvent;

            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;

            this.UpdataFormStyleManager(this.formsManiger.m_StyleManager);
        }

        /// <summary>
        /// delegate UpdataFormStyleManager
        /// </summary>
        /// <param styleManager="MetroStyleManager"></param>
        public void UpdataFormStyleManager(MetroFramework.Components.MetroStyleManager styleManager)
        {
            this.metroStyleManager1.Style = styleManager.Style;
            this.metroStyleManager1.Theme = styleManager.Theme;
        }

        /// <summary>
        /// BtnWorkSpaceOpen Click EvnetHandler 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnWorkSpaceOpenClickEvent(object sender, EventArgs e)
        {
            if (this.BtnWorkSpaceOpenClickEvnetHandler != null)
                BtnWorkSpaceOpenClickEvnetHandler(sender, e);
        }


        #region WorkSpace 속성 추가
        [Category("WorkSpace"), Description("Work Space Name")]
        public string WorkSpaceName
        {
            get
            {
                return this.lblWorkSpaceName.Text;
            }
            set
            {
                this.lblWorkSpaceName.Text = value;
            }
        }

        [Category("WorkSpace"), Description("Work Space Size")]
        public string WorkSpaceSize
        {
            get
            {
                return this.lblWorkSpaceSize.Text;
            }
            set
            {
                this.lblWorkSpaceSize.Text = value;
            }
        }

        [Category("WorkSpace"), Description("Work Space Version")]
        public string WorkSpaceVersion
        {
            get
            {
                return this.lblWorkSpaceVersion.Text;
            }
            set
            {
                this.lblWorkSpaceVersion.Text = value;
            }
        }

        [Category("WorkSpace"), Description("Work Space Status")]
        public Color WorkSpaceStatus
        {
            get
            {
                return this.panelWorkSpaceStatus.BackColor;
            }
            set
            {
                this.panelWorkSpaceStatus.BackColor = value;
            }
        }

        [Category("WorkSpace"), Description("Work Space Button Index")]
        public int WorkSpaceButtonIndex
        {
            get
            {
                return this.btnWorkSpaceOpen.TabIndex;
            }
            set
            {
                this.btnWorkSpaceOpen.TabIndex = value;
            }
        }
        #endregion

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
