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
        /// 선택한 ClassName, ColorTranslator.ToHtml, ColorTranslator.ToHtml, ColorTranslator.FromHtml
        /// </summary>
        public string selectClassColor;

        /// <summary>
        /// 결과 가져오기
        /// </summary>
        public DialogResult selectDialogResult = DialogResult.None;

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
                    if (WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName] != null)
                    {
                        // 활성화된 내부 프로젝트 Class List 정보가 있는지 확인
                        if (WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName]["string_array_classList"] != null)
                        {
                            try
                            {
                                foreach (string className in WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName]["string_array_classList"])
                                {
                                    if (className != "" || className != null)
                                    {
                                        string classColor = WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName][className]["string_classColor"].ToString();
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
        /// 초기 데이터 생성
        /// </summary>
        /// <returns></returns>
        private object ClassInfoObjectInit()
        {
            object data = new
            {
                string_classColor = this.m_color,
                int_classImageTotalNumber = 0,
                int_classImageTrainNumber = 0,
                int_classImageTestNumber = 0,
                int_classImageValidationNumber = 0
            };
            return data;
        }
        /// <summary>
        /// Class 정보 초기화
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        private JObject ClassInfoReset(string className)
        {
            JObject calssInfoJObject = JObject.FromObject(this.ClassInfoObjectInit());

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
                        if (WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName] != null)
                        {

                            // 활성화된 내부 프로젝트 Class List 정보가 있는지 확인
                            if (WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName]["string_array_classList"] != null)
                            {
                                foreach (string classname in WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName]["string_array_classList"])
                                {
                                    if (this.txtMClassName.Text == classname)
                                    {
                                        MetroMessageBox.Show(this, "동일한 Class 이름이 있습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }

                                JArray classList = (JArray)WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName]["string_array_classList"];
                                classList.Add(this.txtMClassName.Text);

                                JObject calssInfoJObject = JObject.FromObject(this.ClassInfoObjectInit());

                                JObject classData = (JObject)WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName];
                                
                                classData[this.txtMClassName.Text] = calssInfoJObject; // 생성된 값 적용

                                this.jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectCalssInfo, WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject); // 파일 저장
                                this.ClassButtonSetting(this.m_color, ColorTranslator.ToHtml(Color.Wheat), this.txtMClassName.Text); // Class Button 생성
                            }
                            else
                            {
                                WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName] = ClassInfoReset(this.txtMClassName.Text); // 초기 데이터 적용
                                this.jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectCalssInfo, WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject); // 파일 저장
                                this.ClassButtonSetting(this.m_color, ColorTranslator.ToHtml(Color.Wheat), this.txtMClassName.Text); // Class Button 생성
                            }
                        }
                        // 활성화된 내부 프로젝트 Class 정보 없음
                        else
                        {
                            WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName] = ClassInfoReset(this.txtMClassName.Text); // 초기 데이터 적용
                            this.jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectCalssInfo, WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject); // 파일 저장
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

            //Console.WriteLine(classButton.Name);

            ProjectAI.MainForms.ClassEditClassButtonEdit classEditClassButtonEdit = new ClassEditClassButtonEdit((ProjectAI.MainForms.UserContral.ClassEdit.ClassButton)classButton);
            DialogResult dialogResult = classEditClassButtonEdit.ShowDialog();

            /* class Info 수정했을떼 값 변경하고 Json 파일 저장 */

            if (dialogResult == DialogResult.OK)
            {
                /*
                 * #4
                 * 1. 수정한 Class 값 가져오기 
                 * 2. 이전 Class 데이터 가져오기
                 * 3. 이전 Class 적용된 이미지 데이터 스켄하기
                 * 4. 이전 Clsdd 적용된 이미지 데이터 변경된 데이터로 수정 하기
                 * 5. 수정된 Class 값 이전 Class 값 적용하기
                 * 6. 수정된 값 이용하여 UI에 적용 - 이미지 Class List 정보, Class UI 정보
                 * 7. 수정된 데이터 파일 저장하기
                 */

                // 수정한 Class 값 가져오기
                // string modifyClassName = 수정된 Class 이름
                // string modifyClassColor = 수정된 Class Color
                #region 1. 수정한 class 값 가져오기
                UserContral.ClassEdit.ClassButton activateClassButton = this.classButtons[classButton.Name];
                string modifyClassName = activateClassButton.TileText;
                string modifyClassColor = ColorTranslator.ToHtml(activateClassButton.TileBackColor);
                #endregion 1. 수정한 class 값 가져오기

                // 이전 Class 데이터 가져오기
                // string previousClassName 이전 Class 이름
                // JObject previousCalssInfoJObject 이전 Class JObject 정보
                #region 2. 이전 Class 데이터 가져오기
                int i = Array.IndexOf(this.classButtons.Keys.ToArray(), classButton.Name); // 수정할 Class 번호 가져오기
                string previousClassName = WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["string_array_classList"][i].ToString(); // ClassList 에서 Class 이름 수정
                JObject previousCalssInfoJObject = (JObject)WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]; // activeProjectCalssInfoJObject JObject 가져오기
                //previousCalssInfoJObject.Remove(classButton.Name); // activeProjectCalssInfoJObject classButton.Name 삭제 하기
                #endregion 2. 이전 Class 데이터 가져오기





                this.jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectCalssInfo, WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject); // 파일 저장


                //WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName];


                //object newInnerProjectInfo = new
                //{
                //    string_classColor = number,
                //    int_classImageTotal = 0,
                //    int_classImagetrain = 0,
                //};

                //WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName][mkInnerProjectName] = JObject.FromObject(newInnerProjectInfo);


                //JObject jObject

                //WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName]

                //this.selectClassName = this.classButtons[classButton.Name].TileText;

                this.jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectCalssInfo, WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject); // 파일 저장
            }
            else if (dialogResult == DialogResult.Cancel)
            {

            }
        }
        /// <summary>
        /// Class Button 클릭 이벤트 - delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCdeleteClick(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroButton controls = (MetroFramework.Controls.MetroButton)sender;
            var classButton = controls.Parent;
            classButton = (ProjectAI.MainForms.UserContral.ClassEdit.ClassButton)classButton.Parent;
            //Console.WriteLine(classButton.Name); // 이름

            string activeInnerProjectName = WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName;

            #region Class 정보 Json 파일 삭제
            int i = Array.IndexOf(this.classButtons.Keys.ToArray(), classButton.Name); // 삭제할 Class 번호 가져오기
            WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName]["string_array_classList"][i].Remove(); // classList 삭제 하기
            JObject activeProjectCalssInfoJObject = (JObject)WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[activeInnerProjectName]; // activeProjectCalssInfoJObject JObject 가져오기
            activeProjectCalssInfoJObject.Remove(classButton.Name); // activeProjectCalssInfoJObject classButton.Name 삭제 하기
            #endregion Class 정보 Json 파일 삭제

            this.jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectCalssInfo, WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject); // 파일 저장

            this.panelMClassButton.Controls.Remove(classButton); // 컨트롤 삭제
            this.classButtons.Remove(classButton.Name); // 버튼 Class 삭제
        }
        /// <summary>
        /// Class Button 클릭 이벤트 - tile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCtileClick(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTile controls = (MetroFramework.Controls.MetroTile)sender;
            var classButton = controls.Parent;
            classButton = (ProjectAI.MainForms.UserContral.ClassEdit.ClassButton)classButton.Parent;

            this.selectClassName = this.classButtons[classButton.Name].TileText;
            this.selectClassColor = ColorTranslator.ToHtml(this.classButtons[classButton.Name].TileBackColor);

            //Console.WriteLine($"classButton.Name: {classButton.Name}, selectClassName: {this.selectClassName}, selectClassColor: {this.selectClassColor}");
        }

        private void BtnMOKClick(object sender, EventArgs e)
        {
            /*
             * this.selectClassName, this.selectClassColor 가져가서 선택된 데이터에 쓰기
             */
            this.DialogResult = DialogResult.OK;
            this.selectDialogResult = DialogResult.OK;

            this.Close();
        }

        private void BtnMCancelClick(object sender, EventArgs e)
        {
            this.selectClassName = null;
            this.selectClassColor = null;
            this.DialogResult = DialogResult.Cancel;
            this.selectDialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}
