using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace ProjectAI.MainForms
{
    public partial class MakeWorkSpaceForm : MetroForm
    {
        private static DateTime start;
        private static TimeSpan time;

        public MakeWorkSpaceForm()
        {
            InitializeComponent();

            this.StyleManager = styleManagerMakeWorkSpaceForm;
            // FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            FormsManiger formsManiger = FormsManiger.GetInstance();
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);
        }

        ~MakeWorkSpaceForm()
        {
            Console.WriteLine("Dispose MakeWorkSpaceForm");
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

        private void BtnMOKClick(object sender, EventArgs e)
        {
            foreach (string workSpaceName in WorkSpaceEarlyData.workSpaceEarlyDataJobject["workSpaceNameList"])
            {
                if (txtMworkSpaceName.Text == workSpaceName)
                {
                    MetroMessageBox.Show(this, "This Workspace already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (CustomIOMainger.DirChackCreateName(txtMworkSpaceName.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                string ignore = "',', '\\', '/', ':', '*', '?', '\"', '<', '>', '|', '_', '[', ']'";
                MetroMessageBox.Show(this, $"This name is not applicable.\n Ignore this word: ({ignore})", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void BtnMCancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public string GetWorkSpaceName()
        {
            return txtMworkSpaceName.Text;
        }
    }
}