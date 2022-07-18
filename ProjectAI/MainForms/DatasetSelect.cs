using MetroFramework.Components;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace ProjectAI.MainForms
{
    public partial class DatasetSelect : MetroForm
    {
        public string selectDataset = null;

        /// <summary>
        /// 결과 가져오기
        /// </summary>
        public DialogResult selectDialogResult = DialogResult.None;

        public DatasetSelect()
        {
            InitializeComponent();
            ProjectAI.FormsManiger formsManiger = ProjectAI.FormsManiger.GetInstance();
            this.StyleManager = this.metroStyleManager1;

            this.UpdataFormStyleManager(formsManiger.m_StyleManager);
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

        private void TilMTrainValidationClick(object sender, EventArgs e)
        {
            this.selectDataset = "Train";
            ActivateButton(sender);
        }

        private void TilMTestClick(object sender, EventArgs e)
        {
            this.selectDataset = "Test";
            ActivateButton(sender);
        }

        private void ActivateButton(object btnSender, object panel = null)
        {
            if (btnSender != null)
            {
                if (panel == null)
                {
                    try
                    {
                        Control control = (Control)btnSender;
                        panel = control.Parent;
                    }
                    catch
                    {
                        return;
                    }
                }

                MetroFramework.Controls.MetroTile metroTile = btnSender as MetroFramework.Controls.MetroTile;
                MetroFramework.Controls.MetroButton metroButton = btnSender as MetroFramework.Controls.MetroButton;

                DisableButton(btnSender, panel);

                if (metroTile != null)
                {
                    metroTile.UseStyleColors = true;
                    metroTile.Style = MetroFramework.MetroColorStyle.Orange;
                }
                else if (metroButton != null)
                {
                    metroButton.UseStyleColors = true;
                    metroButton.Style = MetroFramework.MetroColorStyle.Orange;
                }
            }
        }

        private void DisableButton(object btnSender, object panel = null)
        {
            if (btnSender != null)
            {
                MetroFramework.Controls.MetroPanel metroPanel = null;
                Panel windowsPanel = null;
                if (panel == null)
                {
                    try
                    {
                        Control control = (Control)btnSender;
                        metroPanel = control.Parent as MetroFramework.Controls.MetroPanel;
                        windowsPanel = control.Parent as Panel;

                    }
                    catch
                    {
                        return;
                    }
                }

                if (metroPanel != null)
                {
                    foreach (Control previousBtn in metroPanel.Controls)
                    {
                        MetroFramework.Controls.MetroTile metroTile = btnSender as MetroFramework.Controls.MetroTile;
                        MetroFramework.Controls.MetroButton metroButton = btnSender as MetroFramework.Controls.MetroButton;

                        if (metroTile != null)
                        {
                            metroTile.UseStyleColors = true;
                            metroTile.Style = MetroFramework.MetroColorStyle.Orange;
                        }
                        else if (metroButton != null)
                        {
                            metroButton.UseStyleColors = true;
                            metroButton.Style = MetroFramework.MetroColorStyle.Orange;
                        }


                        if (metroButton != null)
                        {
                            FormsManiger formsManiger = FormsManiger.GetInstance();
                            metroButton.Style = formsManiger.m_StyleManager.Style;
                            if (metroButton.UseStyleColors)
                                metroButton.UseStyleColors = false;
                            if (metroButton.UseCustomBackColor)
                                metroButton.UseCustomBackColor = false;
                            previousBtn.Refresh();
                        }
                    }
                }
                else if (windowsPanel != null)
                {
                    foreach (Control previousBtn in windowsPanel.Controls)
                    {
                        MetroFramework.Controls.MetroTile metroTile = btnSender as MetroFramework.Controls.MetroTile;
                        MetroFramework.Controls.MetroButton metroButton = btnSender as MetroFramework.Controls.MetroButton;

                        if (metroTile != null)
                        {
                            metroTile.UseStyleColors = true;
                            metroTile.Style = MetroFramework.MetroColorStyle.Orange;
                        }
                        else if (metroButton != null)
                        {
                            metroButton.UseStyleColors = true;
                            metroButton.Style = MetroFramework.MetroColorStyle.Orange;
                        }


                        if (metroButton != null)
                        {
                            FormsManiger formsManiger = FormsManiger.GetInstance();
                            metroButton.Style = formsManiger.m_StyleManager.Style;
                            if (metroButton.UseStyleColors)
                                metroButton.UseStyleColors = false;
                            if (metroButton.UseCustomBackColor)
                                metroButton.UseCustomBackColor = false;
                            previousBtn.Refresh();
                        }
                    }
                }

            }
        }

        private void BtnMOKClick(object sender, EventArgs e)
        {
            if (this.selectDataset != null)
            {
                this.selectDialogResult = DialogResult.OK;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnMCancelClick(object sender, EventArgs e)
        {
            this.selectDialogResult = DialogResult.Cancel;
            this.DialogResult = DialogResult.Cancel;

            this.selectDialogResult = DialogResult.None;

            this.Close();
        }
    }
}