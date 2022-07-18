namespace ProjectAI.MainForms.UserContral.Classification
{
    partial class ClassWeightControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblMNumber = new MetroFramework.Controls.MetroLabel();
            this.lblMClassName = new MetroFramework.Controls.MetroLabel();
            this.btnMWeightSub = new MetroFramework.Controls.MetroButton();
            this.btnMWeightAdd = new MetroFramework.Controls.MetroButton();
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.tableLayoutPanel1, true);
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtWeight, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMNumber, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMClassName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMWeightSub, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMWeightAdd, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(433, 24);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(266, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 1);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(34, 23);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 1);
            this.panel2.TabIndex = 3;
            // 
            // txtWeight
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.txtWeight, true);
            this.txtWeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWeight.Font = new System.Drawing.Font("Noto Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Location = new System.Drawing.Point(266, 0);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(120, 18);
            this.txtWeight.TabIndex = 62;
            this.txtWeight.Text = "100";
            this.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWeight.Leave += new System.EventHandler(this.TxtWeightLeave);
            // 
            // lblMNumber
            // 
            this.lblMNumber.AutoSize = true;
            this.lblMNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMNumber.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMNumber.Location = new System.Drawing.Point(0, 0);
            this.lblMNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblMNumber.Name = "lblMNumber";
            this.lblMNumber.Size = new System.Drawing.Size(32, 21);
            this.lblMNumber.TabIndex = 63;
            this.lblMNumber.Text = "01";
            this.lblMNumber.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblMClassName
            // 
            this.lblMClassName.AutoSize = true;
            this.lblMClassName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMClassName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMClassName.Location = new System.Drawing.Point(35, 0);
            this.lblMClassName.Name = "lblMClassName";
            this.lblMClassName.Size = new System.Drawing.Size(226, 21);
            this.lblMClassName.TabIndex = 64;
            this.lblMClassName.Text = "metroLabel2";
            this.lblMClassName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblMClassName.UseCustomForeColor = true;
            // 
            // btnMWeightSub
            // 
            this.btnMWeightSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMWeightSub.Highlight = true;
            this.btnMWeightSub.Location = new System.Drawing.Point(390, 2);
            this.btnMWeightSub.Margin = new System.Windows.Forms.Padding(2);
            this.btnMWeightSub.Name = "btnMWeightSub";
            this.tableLayoutPanel1.SetRowSpan(this.btnMWeightSub, 2);
            this.btnMWeightSub.Size = new System.Drawing.Size(18, 18);
            this.btnMWeightSub.TabIndex = 66;
            this.btnMWeightSub.UseSelectable = true;
            this.btnMWeightSub.Click += new System.EventHandler(this.BtnMWeightSubClick);
            // 
            // btnMWeightAdd
            // 
            this.btnMWeightAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMWeightAdd.Highlight = true;
            this.btnMWeightAdd.Location = new System.Drawing.Point(412, 2);
            this.btnMWeightAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnMWeightAdd.Name = "btnMWeightAdd";
            this.tableLayoutPanel1.SetRowSpan(this.btnMWeightAdd, 2);
            this.btnMWeightAdd.Size = new System.Drawing.Size(19, 18);
            this.btnMWeightAdd.TabIndex = 65;
            this.btnMWeightAdd.UseSelectable = true;
            this.btnMWeightAdd.Click += new System.EventHandler(this.BtnMWeightAddClick);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // ClassWeightControl
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::ProjectAI.Properties.Resources.border1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ClassWeightControl";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(445, 36);
            this.Load += new System.EventHandler(this.ClassWeightControlLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtWeight;
        private MetroFramework.Controls.MetroLabel lblMNumber;
        private MetroFramework.Controls.MetroLabel lblMClassName;
        private MetroFramework.Controls.MetroButton btnMWeightAdd;
        private MetroFramework.Controls.MetroButton btnMWeightSub;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
    }
}
