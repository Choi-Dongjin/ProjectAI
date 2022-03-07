﻿using System;
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
    public partial class DeeplearningProjectSelectForm : MetroForm
    {
        /// <summary>
        /// Classification 유저 컨트롤
        /// </summary>
        private ProjectAI.MainForms.UserContral.ProjectSelect.Classification classificationUserContral;

        /// <summary>
        /// jsonDataManiger
        /// </summary>
        JsonDataManiger jsonDataManiger = JsonDataManiger.GetInstance();

        /// <summary>
        /// 폼 메니저
        /// </summary>
        private FormsManiger formsManiger = FormsManiger.GetInstance();

        private string selectProject; // 가지는 값 예상 = Classification, Segmentation, ObjectDetection
        private string selectProjectInputDataType; // 가지는 값 = SingleImage, MultiImage

        /// <summary>
        /// 생성자
        /// </summary>
        public DeeplearningProjectSelectForm()
        {
            InitializeComponent();

            this.StyleManager = this.styleManagerDeeplearningProjectSelectForm;
            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);
        }

        /// <summary>
        /// 소멸자
        /// </summary>
        ~DeeplearningProjectSelectForm()
        {
            Console.WriteLine("Dispose MakeWorkSpaceForm");
        }

        /// <summary>
        /// 로드시 초기 셋업
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeeplearningProjectSelectFormLoad(object sender, EventArgs e)
        {
            this.ClassificationUserContralSetting(); // Classification User Contral 셋업
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

        private void DeeplearningProjectSelectFormFormClosing(object sender, FormClosingEventArgs e)
        {
            //Hiding the window, because closing it makes the window unaccessible.
            this.Hide();
            this.Parent = null;
            e.Cancel = true; //hides the form, cancels closing event
        }


        #region Classification Tesk 설정
        /// <summary>
        /// Classification User Contral 셋업
        /// </summary>
        private void ClassificationUserContralSetting()
        {
            this.selectProject = "Classification"; // Classification 진입
            this.selectProjectInputDataType = null; // 입역 데이터 타입 초기화

            this.metroPanel1.Controls.Clear(); // Controls 제거
            this.classificationUserContral = new UserContral.ProjectSelect.Classification(); // Classification 컨트롤 생성
            this.metroPanel1.Controls.Add(this.classificationUserContral); // Classification 컨트롤 추가

            #region Classification 컨트롤 설정

            this.metroStyleExtender1.SetApplyMetroTheme(this.classificationUserContral, true);

            this.classificationUserContral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classificationUserContral.Location = new System.Drawing.Point(0, 0);
            this.classificationUserContral.Margin = new System.Windows.Forms.Padding(0);
            this.classificationUserContral.Name = "classificationContral";
            this.classificationUserContral.Size = new System.Drawing.Size(845, 260);
            this.classificationUserContral.TabIndex = 2;

            // 이벤트 헨들러 설정
            this.classificationUserContral.BtnSingleImageClickEvnetHandler += new System.EventHandler(this.ClassificationSingleImageButtonClick);
            this.classificationUserContral.TxtSingleImageClickEvnetHandler += new System.EventHandler(this.ClassificationSingleImageTextboxClick);

            this.classificationUserContral.BtnMultiImageClickEvnetHandler += new System.EventHandler(this.ClassificationMultiImageButtonClick);
            this.classificationUserContral.TxtMultiImageClickEvnetHandler += new System.EventHandler(this.ClassificationMultiImageTextboxClick);

            #endregion Classification 컨트롤 설정 완료
        }


        /// <summary>
        /// Classification 싱글 이미지 타입 버튼 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassificationSingleImageButtonClick(object sender, EventArgs e)
        {
            this.selectProjectInputDataType = this.classificationUserContral.btnSingleImage.ButtonClickRetrun;
        }
        /// <summary>
        /// Classification 싱글 이미지 타입 텍스트박스 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassificationSingleImageTextboxClick(object sender, EventArgs e)
        {
            this.selectProjectInputDataType = null;
        }
        /// <summary>
        /// Classification 멀티 이미지 타입 버튼 클릭시 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassificationMultiImageButtonClick(object sender, EventArgs e)
        {
            this.selectProjectInputDataType = this.classificationUserContral.btnMultiImage.ButtonClickRetrun;
        }
        /// <summary>
        /// Classification 멀티 이미지 타입 텍스트박스 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassificationMultiImageTextboxClick(object sender, EventArgs e)
        {
            this.selectProjectInputDataType = null;
        }

        /// <summary>
        /// Classification 선택
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMClassificationClick(object sender, EventArgs e)
        {
            this.ClassificationUserContralSetting(); // Classification User Contral 셋업 
        }
        #endregion  Classification Tesk 설정


        private void BtnMOKClick(object sender, EventArgs e)
        {
            if (selectProjectInputDataType != null)
            {
                //WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject["selectProject"] = selectProject;
                //WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject["selectProjectInputDataType"] = selectProjectInputDataType;

                string mkInnerProjectName = CustomIOMainger.RandomFileName(WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject["array_string_projectList"].Select(jv => (string)jv).ToArray(), 10); // 이름 랜덤 생성
                JArray jArray = (JArray)WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject["array_string_projectList"];
                jArray.Add(mkInnerProjectName);

                Int32.TryParse(WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject["int_projectListNumber"].ToString(), out int number);
                number++;
                WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject["int_projectListNumber"] = number;

                object newInnerProjectInfo = new
                {
                    int_X = number,
                    int_Y = 0,
                    string_selectProject = selectProject,
                    string_selectProjectInputDataType = selectProjectInputDataType,
                    int_imageLabeledNumber = 0,
                    int_imageTrainNumber = 0,
                    int_imageTestNumber = 0,
                    bool_traininggorNot = false
                };
                JObject jObject2 = new JObject();
                jObject2[mkInnerProjectName] = JObject.FromObject(newInnerProjectInfo);
                JObject array_string_projectList = (JObject)WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject["string_projectListInfo"];
                array_string_projectList.Merge(jObject2);

                jsonDataManiger.PushJsonObject(WorkSpaceData.m_activeProjectMainger.m_pathActiveProjectInfo, WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject);

                Console.WriteLine($"Select Project: {selectProject}"); // Log
                Console.WriteLine($"Input DataType: {selectProjectInputDataType}"); // Log

                MetroFramework.MetroColorStyle style;
                if (selectProject == "Classification")
                    style = MetroColorStyle.Green;
                else if (selectProject == "Segmentation")
                    style = MetroColorStyle.Red;
                else if (selectProject == "ObjectDetection")
                    style = MetroColorStyle.Blue;
                else
                    style = MetroColorStyle.Yellow;

                WorkSpaceData.m_activeProjectMainger.UISetActiveProjectInnerProjectButton(mkInnerProjectName, selectProject, style); // 버튼 프로젝트에 추가

                this.Close();
            }
            else
            {
                MetroMessageBox.Show(this, "Please Select Input Image Data Type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnMCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMObjectDetection_Click(object sender, EventArgs e)
        {

        }

        private void btnMSegmentation_Click(object sender, EventArgs e)
        {

        }
    }
}
