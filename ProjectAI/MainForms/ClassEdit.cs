using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjectAI.MainForms
{
    public partial class ClassEdit : MetroForm
    {
        /// <summary>
        /// jsonDataManiger
        /// </summary>
        JsonDataManiger jsonDataManiger = JsonDataManiger.GetInstance();

        /// <summary>
        /// 폼 메니저
        /// </summary>
        private FormsManiger formsManiger = FormsManiger.GetInstance();

        /// <summary>
        /// 색상 선택
        /// </summary>
        private ColorDialog m_colorDialog = new ColorDialog();

        /// <summary>
        /// Class 색상 설정
        /// </summary>
        private string m_color = "#FF808080";

        /// <summary>
        /// 선택한 ClassName 
        /// </summary>
        public string selectClassName;

        /// <summary>
        /// 선택한 ClassName 
        /// </summary>
        public string selectClassColor;

        /// <summary>
        /// 생성된 Class Button
        /// </summary>
        private Dictionary<string, ProjectAI.MainForms.UserContral.ClassEdit.ClassButton> classButtons = new Dictionary<string, UserContral.ClassEdit.ClassButton>();


        public ClassEdit()
        {
            InitializeComponent();

            this.StyleManager = this.metroStyleManager1;

            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;

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
        /// <summary>
        /// 종료 방법
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassEditFormClosing(object sender, FormClosingEventArgs e)
        {
            // 초기화
            this.txtMClassName.Clear();
            this.selectClassName = null;
            this.selectClassColor = null;
            this.m_color = "#FF808080";
            this.classButtons = new Dictionary<string, UserContral.ClassEdit.ClassButton>();

            this.panelMClassButton.Controls.Clear(); // 버튼 초기화
            //Hiding the window, because closing it makes the window unaccessible.
            this.Hide();
            this.Parent = null;
            e.Cancel = true; //hides the form, cancels closing event
        }

        private void ClassEditLoad(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 불러올시 초기화 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassEditShown(object sender, EventArgs e)
        {
            // 활성화된 프로젝트 유무 확인
            if (WorkSpaceData.m_activeProjectMainger != null)
            {
                // 활성화된 내부 프로젝트 유무 확인
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    string activeInnerProjectName = WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName; // 활성화된 내부 프로젝트 이름 가져오기

                    // 활성화된 내부 프로젝트 Class 정보 있는지 확인
                    if (WorkSpaceData.m_activeProjectMainger.m_calssInfoJObject[activeInnerProjectName] != null)
                    {
                        // 활성화된 내부 프로젝트 Class List 정보가 있는지 확인
                        if (WorkSpaceData.m_activeProjectMainger.m_calssInfoJObject[activeInnerProjectName]["string_array_classList"] != null)
                        {
                            try
                            {
                                foreach (string className in WorkSpaceData.m_activeProjectMainger.m_calssInfoJObject[activeInnerProjectName]["string_array_classList"])
                                {
                                    if (className != "" || className != null)
                                    {
                                        string classColor = WorkSpaceData.m_activeProjectMainger.m_calssInfoJObject[activeInnerProjectName][className]["string_classColor"].ToString();
                                        if (classColor == null || classColor == "")
                                            classColor = "FF808080";

                                        this.ClassButtonSetting(classColor, ColorTranslator.ToHtml(Color.Wheat), className); // Class Button 생성
                                    }
                                } 
                            }
                            catch
                            {
                                MetroMessageBox.Show(this, "Class 정보 손상", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Class 정보 초기화
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        private JObject ClassInfoReset(string className)
        {
            object data = new
            {
                string_classColor = this.m_color,
                int_classImageTotal = 0,
                int_classImagetrain = 0
            };
            JObject calssInfoJObject = JObject.FromObject(data);

            JArray classList = new JArray() { };
            classList.Add(className);

            JObject jObject = new JObject
            {
                { "string_array_classList", classList},
                { className, calssInfoJObject}
            };
            return jObject;
        }

        /// <summary>
        /// 색상 선택 버큰 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMClassColorClick(object sender, EventArgs e)
        {
            if (m_colorDialog.ShowDialog() == DialogResult.OK)
            {
               this.m_color = ColorTranslator.ToHtml(this.m_colorDialog.Color);
            }
        }
        /// <summary>
        /// Class 추가 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMClassAddClick(object sender, EventArgs e)
        {
            // 활성화된 프로젝트 유무 확인
            if (WorkSpaceData.m_activeProjectMainger != null)
            {
                // 활성화된 내부 프로젝트 유무 확인
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null) 
                {
                    // 데이터 입력 유무
                    if (this.txtMClassName.Text != "")
                    {
                        string activeInnerProjectName = WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName; // 활성화된 내부 프로젝트 이름 가져오기

                        // 활성화된 내부 프로젝트 Class 정보 있는지 확인
                        if (WorkSpaceData.m_activeProjectMainger.m_calssInfoJObject[activeInnerProjectName] != null)
                        {

                            // 활성화된 내부 프로젝트 Class List 정보가 있는지 확인
                            if (WorkSpaceData.m_activeProjectMainger.m_calssInfoJObject[activeInnerProjectName]["string_array_classList"] != null)
                            {
                                foreach (string classname in WorkSpaceData.m_activeProjectMainger.m_calssInfoJObject[activeInnerProjectName]["string_array_classList"])
                                {
                                    if (this.txtMClassName.Text == classname)
                                    {
                                        MetroMessageBox.Show(this, "동일한 Class 이름이 있습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }

                                JArray classList = (JArray)WorkSpaceData.m_activeProjectMainger.m_calssInfoJObject[activeInnerProjectName]["string_array_classList"];
                                classList.Add(this.txtMClassName.Text);
                                
                                object data = new
                                {
                                    string_classColor = this.m_color,
                                    int_classImageTotal = 0,
                                    int_classImagetrain = 0
                                };
                                JObject calssInfoJObject = JObject.FromObject(data);

                                JObject classData = (JObject)WorkSpaceData.m_activeProjectMainger.m_calssInfoJObject[activeInnerProjectName];
                                
                                classData[this.txtMClassName.Text] = calssInfoJObject; // 생성된 값 적용
                                this.jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathCalssInfo, WorkSpaceData.m_activeProjectMainger.m_calssInfoJObject); // 파일 저장
                                this.ClassButtonSetting(this.m_color, ColorTranslator.ToHtml(Color.Wheat), this.txtMClassName.Text); // Class Button 생성
                            }
                            else
                            {
                                WorkSpaceData.m_activeProjectMainger.m_calssInfoJObject[activeInnerProjectName] = ClassInfoReset(this.txtMClassName.Text); // 초기 데이터 적용
                                this.jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathCalssInfo, WorkSpaceData.m_activeProjectMainger.m_calssInfoJObject); // 파일 저장
                                this.ClassButtonSetting(this.m_color, ColorTranslator.ToHtml(Color.Wheat), this.txtMClassName.Text); // Class Button 생성
                            }
                        }
                        // 활성화된 내부 프로젝트 Class 정보 없음
                        else
                        {
                            WorkSpaceData.m_activeProjectMainger.m_calssInfoJObject[activeInnerProjectName] = ClassInfoReset(this.txtMClassName.Text); // 초기 데이터 적용
                            this.jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathCalssInfo, WorkSpaceData.m_activeProjectMainger.m_calssInfoJObject); // 파일 저장
                            this.ClassButtonSetting(this.m_color, ColorTranslator.ToHtml(Color.Wheat), this.txtMClassName.Text); // Class Button 생성
                        }
                    }
                }
            } 
        }
        /// <summary>
        /// Class 버튼 만들기
        /// </summary>
        /// <param name="backColor"> tile 배경 색 </param>
        /// <param name="foreColor"> tile 폰트 색 </param>
        /// <param name="name"> tile, 컴포넌트 이름 </param>
        /// <param metroColorStyle="metroColorStyle"> 버튼 스타일 기본값: Default </param>
        /// <returns></returns>
        private ProjectAI.MainForms.UserContral.ClassEdit.ClassButton ClassButtonSetting(string backColor, string foreColor, string name, MetroColorStyle metroColorStyle = MetroColorStyle.Default)
        {
            ProjectAI.MainForms.UserContral.ClassEdit.ClassButton classButton = new UserContral.ClassEdit.ClassButton();

            classButton.DeleteText = "Delete";
            classButton.EditText = "Edit";
            classButton.Dock = System.Windows.Forms.DockStyle.Top;

            classButton.TileBackColor = ColorTranslator.FromHtml(backColor);
            classButton.ForeColor = ColorTranslator.FromHtml(foreColor);
            classButton.TileText = name;
            classButton.Name = name;

            classButton.Size = new System.Drawing.Size(393, 42);
            classButton.Style = metroColorStyle;

            classButton.BtnMEditClick += this.BtnCeditClick; // Class Button 클릭 이벤트 등록 - edit
            classButton.BtnMDeleteClick += this.BtnCdeleteClick; // Class Button 클릭 이벤트 등록 - delete
            classButton.TileMClassClick += this.BtnCtileClick; // Class Button 클릭 이벤트 등록 - tile
            //classButton.TabIndex = 2;
            this.classButtons.Add(name, classButton); // Class Button 등록
            this.panelMClassButton.Controls.Add(classButton); // Class Button 판넬에 추가
            return classButton;
        }
        /// <summary>
        /// Class Button 클릭 이벤트 - edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCeditClick(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroButton controls = (MetroFramework.Controls.MetroButton)sender;

            var classButton = controls.Parent;
            classButton = (ProjectAI.MainForms.UserContral.ClassEdit.ClassButton)classButton.Parent;

            Console.WriteLine(classButton.Name);

            ProjectAI.MainForms.ClassEditClassButtonEdit classEditClassButtonEdit = new ClassEditClassButtonEdit((ProjectAI.MainForms.UserContral.ClassEdit.ClassButton)classButton);
            classEditClassButtonEdit.ShowDialog();
        }
        /// <summary>
        /// Class Button 클릭 이벤트 - delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCdeleteClick(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Class Button 클릭 이벤트 - tile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCtileClick(object sender, EventArgs e)
        {

        }

        private void BtnMOKClick(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnMCancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
