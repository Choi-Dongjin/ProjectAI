namespace ProjectAI.MainForms.UserContral.ClassEdit
{
    partial class ClassButton
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMDelete = new MetroFramework.Controls.MetroButton();
            this.btnMEdit = new MetroFramework.Controls.MetroButton();
            this.tileMClass = new MetroFramework.Controls.MetroTile();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.Controls.Add(this.btnMDelete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tileMClass, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(387, 42);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnMDelete
            // 
            this.btnMDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMDelete.Location = new System.Drawing.Point(339, 3);
            this.btnMDelete.Name = "btnMDelete";
            this.btnMDelete.Size = new System.Drawing.Size(45, 36);
            this.btnMDelete.TabIndex = 0;
            this.btnMDelete.Text = "Delete";
            this.btnMDelete.UseSelectable = true;
            // 
            // btnMEdit
            // 
            this.btnMEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMEdit.Location = new System.Drawing.Point(288, 3);
            this.btnMEdit.Name = "btnMEdit";
            this.btnMEdit.Size = new System.Drawing.Size(45, 36);
            this.btnMEdit.TabIndex = 1;
            this.btnMEdit.Text = "Edit";
            this.btnMEdit.UseSelectable = true;
            // 
            // tileMClass
            // 
            this.tileMClass.ActiveControl = null;
            this.tileMClass.BackColor = System.Drawing.Color.Gray;
            this.tileMClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileMClass.ForeColor = System.Drawing.Color.White;
            this.tileMClass.Location = new System.Drawing.Point(3, 3);
            this.tileMClass.Name = "tileMClass";
            this.tileMClass.Size = new System.Drawing.Size(279, 36);
            this.tileMClass.TabIndex = 2;
            this.tileMClass.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tileMClass.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tileMClass.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.tileMClass.UseCustomBackColor = true;
            this.tileMClass.UseCustomForeColor = true;
            this.tileMClass.UseSelectable = true;
            this.tileMClass.UseStyleColors = true;
            // 
            // ClassButton
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ClassButton";
            this.Size = new System.Drawing.Size(387, 42);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton btnMDelete;
        private MetroFramework.Controls.MetroButton btnMEdit;
        private MetroFramework.Controls.MetroTile tileMClass;
    }
}
