using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAI.MainForms.UserContral.ClassEdit
{
    public partial class ClassButton : UserControl
    {
        /// <summary>
        /// 버튼 클릭 이벤트 헨들러 = 편집 버튼 클릭
        /// </summary>
        [Description("편집 버튼 클릭"), Category("Custum Component Property")]
        public event EventHandler BtnMEditClick;
        /// <summary>
        /// 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnMEditClickEvnet(object sender, EventArgs e)
        {
            if (this.BtnMEditClick != null)
                BtnMEditClick(sender, e);
        }

        /// <summary>
        /// 버튼 클릭 이벤트 헨들러 = 편집 버튼 클릭
        /// </summary>
        [Description("삭제 버튼 클릭"), Category("Custum Component Property")]
        public event EventHandler BtnMDeleteClick;
        /// <summary>
        /// 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnMDeleteClickEvnet(object sender, EventArgs e)
        {
            if (this.BtnMDeleteClick != null)
                BtnMDeleteClick(sender, e);
        }

        /// <summary>
        /// 버튼 클릭 이벤트 헨들러 = 편집 버튼 클릭
        /// </summary>
        [Description("클레스 버튼 클릭"), Category("Custum Component Property")]
        public event EventHandler TileMClassClick;
        /// <summary>
        /// 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TileMClassClickEvnet(object sender, EventArgs e)
        {
            if (this.TileMClassClick != null)
                TileMClassClick(sender, e);
        }


        private MetroFramework.MetroColorStyle ComponentsStyle = MetroFramework.MetroColorStyle.Default;
        private System.Drawing.Color m_tileBackColor = System.Drawing.Color.Gray;
        private System.Drawing.Color m_tileForeColor = System.Drawing.Color.Wheat;

        public ClassButton()
        {
            //초기화
            InitializeComponent();

            // 버튼 이벤트 등록
            this.btnMEdit.Click += this.BtnMEditClickEvnet;
            this.btnMDelete.Click += this.BtnMDeleteClickEvnet;
            this.tileMClass.Click += this.TileMClassClickEvnet;

            // 초기값 적용
            this.m_tileBackColor = this.tileMClass.BackColor;
            this.m_tileForeColor = this.tileMClass.ForeColor;
            this.ComponentsStyle = this.Style;
        }

        [Category("Custum Component Property"), Description("버튼 색상")]
        public MetroFramework.MetroColorStyle Style
        {
            get
            {
                return this.ComponentsStyle;
            }
            set
            {
                this.btnMEdit.Style = value;
                this.btnMDelete.Style = value;
                this.ComponentsStyle = value;
            }
        }
        [Category("Custum Component Property"), Description("타일 배경 색상")]
        public System.Drawing.Color TileBackColor
        {
            get
            {
                return this.m_tileBackColor;
            }
            set
            {
                this.tileMClass.BackColor = value;
            }
        }
        [Category("Custum Component Property"), Description("타일 폰트 색상")]
        public System.Drawing.Color TileFontColor
        {
            get
            {
                return this.m_tileForeColor;
            }
            set
            {
                this.tileMClass.ForeColor = value;
            }
        }
        [Category("Custum Component Property"), Description("타일 텍스트")]
        public string TileText
        {
            get
            {
                return this.tileMClass.Text;
            }
            set
            {
                this.tileMClass.Text = value;

            }
        }
        [Category("Custum Component Property"), Description("편집 버튼 텍스트")]
        public string EditText
        {
            get
            {
                return this.btnMEdit.Text;
            }
            set
            {
                this.btnMEdit.Text = value;

            }
        }
        [Category("Custum Component Property"), Description("삭제 버튼 텍스트")]
        public string DeleteText
        {
            get
            {
                return this.btnMDelete.Text;
            }
            set
            {
                this.btnMDelete.Text = value;

            }
        }
    }
}
