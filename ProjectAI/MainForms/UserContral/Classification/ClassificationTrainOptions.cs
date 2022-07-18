using MetroFramework.Components;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace ProjectAI.CustomComponent.MainForms.Classification
{
    public partial class ClassificationTrainOptions : UserControl
    {
        private List<string> previousClassList = new List<string>(); // class Update 가 실행되기전 이전 class List값과 비교하여 변경 사항이 있으면 업데이터 동작하도록 설정
        private MetroFramework.Controls.MetroTile activeMetroButton;
        public ClassificationTrainOptions()
        {
            InitializeComponent();

            FormsManiger.m_formStyleManagerHandler += this.UpdataFormStyleManager;
            FormsManiger formsManiger = FormsManiger.GetInstance(); // 폼 메니저
            this.UpdataFormStyleManager(formsManiger.m_StyleManager);

            this.UISetup();

            this.SetToolTip();

            this.UISetdgvMContinualLearning();

            this.ModelUpdate();
        }

        private void UISetup()
        {
            this.UISetupDataReadClassWeightControlReset();
        }

        public void UpdataFormStyleManager(MetroStyleManager styleManager)
        {
            FormsManiger formsManiger = FormsManiger.GetInstance(); // 폼 메니저
            if (formsManiger.m_isDarkMode) // Light로 변경시 진입
            {
            }
            else // Dark로 변경시 진입
            {
            }

            this.metroStyleManager1.Style = styleManager.Style;
            this.metroStyleManager1.Theme = styleManager.Theme;
        }

        private void TrainOptionsLoad(object sender, EventArgs e)
        {
            this.cbbManetworkModel.Text = this.cbbManetworkModel.PromptText; // 버그인지 this.cbbMnetworkModel.Text 초기설정이 안됨 따라서 this.cbbMnetworkModel.PromptText 를 초기 설정하고 Text에 넣어줌
        }

        /// <summary>
        ///
        /// </summary>
        public Dictionary<string, ProjectAI.MainForms.UserContral.Classification.ClassWeightControl> classWeightControls = new Dictionary<string, ProjectAI.MainForms.UserContral.Classification.ClassWeightControl>();

        /// <summary>
        /// classWeightControl 셋업
        /// </summary>
        /// <param name="number"></param>
        /// <param name="className"></param>
        /// <param name="classColor"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        private ProjectAI.MainForms.UserContral.Classification.ClassWeightControl UISetclassWeightControl(int number, string className, Color classColor, int weight = 1)
        {
            #region Control UI Setup

            /// <summary>
            /// 디자이너 변수입니다.
            /// </summary>
            ProjectAI.MainForms.UserContral.Classification.ClassWeightControl classWeightControl = new ProjectAI.MainForms.UserContral.Classification.ClassWeightControl();
            classWeightControl.BackgroundImage = global::ProjectAI.Properties.Resources.border1;
            classWeightControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //this.metroStyleExtender1.SetApplyMetroTheme(classWeightControl, true);
            classWeightControl.Dock = System.Windows.Forms.DockStyle.Top;
            classWeightControl.Margin = new System.Windows.Forms.Padding(0);
            classWeightControl.Name = className;
            classWeightControl.Padding = new System.Windows.Forms.Padding(6);
            classWeightControl.Size = new System.Drawing.Size(445, 36);
            classWeightControl.TabIndex = number;
            classWeightControl.Weight = 100;

            #endregion Control UI Setup

            #region 값 입력

            classWeightControl.Number = number;
            classWeightControl.ClassName = className;
            classWeightControl.ClassNameColor = classColor;
            classWeightControl.Weight = weight;

            #endregion 값 입력

            return classWeightControl;
        }

        /// <summary>
        /// Class 정보 변경시 업데이터
        /// </summary>
        public void UISetupDataReadClassWeightControlReset()
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                    if (WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] != null)
                    {
                        if (WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["string_array_classList"] != null)
                        {
                            try
                            {
                                List<string> classNameList = new List<string>();
                                foreach (string className in WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["string_array_classList"])
                                {
                                    if (className != null && className != "")
                                    {
                                        classNameList.Add(className);
                                    }
                                }

                                if (this.previousClassList.Count == classNameList.Count) // 이전 List Count가 같으면 업데이트 중단 -> 지금은 삭제, 추가시 업데이터가 동작하기 때문에 문제가 없음, 한번에 수정수 동작하는 경우가 발생하면 문제가 생길수 있음.
                                    return;

                                this.previousClassList = classNameList; // 이전 값에 현제값 적용

                                classNameList.Reverse();
                                this.panelMClassWeight.Controls.Clear(); // 판넬 컨트롤 초기화(비우기)
                                this.classWeightControls = new Dictionary<string, ProjectAI.MainForms.UserContral.Classification.ClassWeightControl>();
                                for (int i = classNameList.Count - 1; i >= 0; i--)
                                {
                                    Color classColor = ColorTranslator.FromHtml(WorkSpaceData.m_activeProjectMainger.m_activeProjectCalssInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][classNameList[i]]["string_classColor"].ToString());
                                    ProjectAI.MainForms.UserContral.Classification.ClassWeightControl classWeightControl = this.UISetclassWeightControl(i, classNameList[i], classColor); // 설정된 ClassWeightControl 가져오기

                                    // 관리 Dictionary에 추가
                                    this.classWeightControls.Add(classNameList[i], classWeightControl);
                                    // panel에 추가
                                    this.panelMClassWeight.Controls.Add(classWeightControl);
                                }
                                this.panelMClassWeight.AutoScroll = true;
                                this.panelMClassWeight.MinimumSize = new Size(450, 120);
                            }
                            catch (Exception error)
                            {
                                Console.WriteLine(error);
                            }
                        }
                        else
                            this.panelMClassWeight.Controls.Clear();
                    }
                    else
                        this.panelMClassWeight.Controls.Clear();
                else
                    this.panelMClassWeight.Controls.Clear();
            else
                this.panelMClassWeight.Controls.Clear();
        }

        public void UISetupClassWeighContralAddManual(int index, string className, Color classColor)
        {
            ProjectAI.MainForms.UserContral.Classification.ClassWeightControl classWeightControl = this.UISetclassWeightControl(index, className, classColor); // 설정된 ClassWeightControl 가져오기
            // panel에 추가
            this.panelMClassWeight.Controls.Add(classWeightControl);
        }

        public void UISetupClassWeighContralResetManual()
        {
            this.panelMClassWeight.Controls.Clear(); // 판넬 컨트롤 초기화(비우기)
        }

        /// <summary>
        /// Train Number 업데이터
        /// </summary>
        public void UISetupTrainNumberUpdataer()
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
            {
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    this.txtTrainDataNumber.Text = WorkSpaceData.m_activeProjectMainger.m_activeProjectInfoJObject["string_projectListInfo"][WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["int_imageTrainNumber"].ToString();
                }
            }
        }

        /// <summary>
        /// String { } 으로 감싸주는 함수
        /// </summary>
        /// <param name="data"> 포장할 string </param>
        /// <returns> "{" + data + "}" </returns>
        private string PackingString(string data)
        {
            return ("{" + data + "}");
        }

        #region Trian Options 설정

        /// <summary>
        /// 모델 설정 변경시 동작 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BbbMnetworkModelSelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(cbbManetworkModel.Text);
        }

        /// <summary>
        /// 설정 가능한 학습 옵션
        /// </summary>
        /// <returns></returns>
        public List<string> BringTrainOptionManual()
        {
            List<string> TrainOptionData = new List<string>(); // Train Option Manual List
            // Network Model 설정
            if (cbbManetworkModel.Text == "Small")
                TrainOptionData.Add("{dnn_type |SynapseNet_Classification_18|}");
            else if (cbbManetworkModel.Text == "Medium")
                TrainOptionData.Add("{dnn_type |SynapseNet_Classification_34|}");
            else if (cbbManetworkModel.Text == "Large")
                TrainOptionData.Add("{dnn_type |SynapseNet_Classification_50|}");
            else if (cbbManetworkModel.Text == "Extra Large")
                TrainOptionData.Add("{dnn_type |SynapseNet_Classification_100|}");

            // Epoch Number 설정
            TrainOptionData.Add(PackingString($"epoch_n |{txtEpochNumber.Text}|"));
            // Train Repeat 설정
            TrainOptionData.Add(PackingString($"train_repeat |{txtTrainRepeat.Text}|"));
            // Mmodel Minimum Selection Epoch (모델 최소 저장 Epoch) 설정
            TrainOptionData.Add(PackingString($"n_ep_no_save |{txtMmodelMinimumSelectionEpoch.Text}|"));
            // Validation Ratio (검증 비율) 설정
            TrainOptionData.Add(PackingString($"val_ratio |{txtValidationRatio.Text}|"));
            // Patience Epochs (Loss 증가, 변화 Epochs 수) 설정
            TrainOptionData.Add(PackingString($"max_ep_loss_up |{txtPatienceEpochs.Text}|"));

            return TrainOptionData;
        }

        /// <summary>
        /// 설정 가능한 학습 옵션 JObject로 정리
        /// </summary>
        /// <param name="TrainOptionData"> 외부에서 JObject </param>
        /// <returns> 속성값이 추가된 TrainOptionData 추가되는 Key 값은 BringTrainOptionManual </returns>
        public JObject BringTrainOptionManual(JObject TrainOptionData)
        {
            // Network Model 설정
            string networkModel = "";
            if (cbbManetworkModel.Text == "Small")
                networkModel = "SynapseNet_Classification_18";
            else if (cbbManetworkModel.Text == "Medium")
                networkModel = "SynapseNet_Classification_34";
            else if (cbbManetworkModel.Text == "Large")
                networkModel = "SynapseNet_Classification_50";
            else if (cbbManetworkModel.Text == "Extra Large")
                networkModel = "SynapseNet_Classification_100";

            if (!float.TryParse(txtValidationRatio.Text, out float validationRatio))
                validationRatio = 0;
            else
                validationRatio /= 100;

            JObject jObject = new JObject
            {
                // Network Model 설정
                ["string_NetworkModel"] = networkModel,
                // Epoch Number 설정
                ["int_EpochNumber"] = txtEpochNumber.Text,
                // Train Repeat 설정
                ["int_TrainRepeat"] = txtTrainRepeat.Text,
                // Mmodel Minimum Selection Epoch (모델 최소 저장 Epoch) 설정
                ["int_ModelMinimumSelectionEpoch"] = txtMmodelMinimumSelectionEpoch.Text,
                // Validation Ratio (검증 비율) 설정
                ["float_ValidationRatio"] = String.Format("{0:0.00#}", validationRatio),
                // Patience Epochs (Loss 증가, 변화 Epochs 수) 설정
                ["int_PatienceEpochs"] = txtPatienceEpochs.Text
            };
            
            // BringTrainOptionManual 옵션 추가
            TrainOptionData["TrainOptionManual"] = jObject;
            return TrainOptionData;
        }

        /// <summary>
        /// 자동으로 설정되는 학습 옵션
        /// </summary>
        /// <returns> TrainOptionData List </returns>
        public List<string> BringTrainOptionAuto()
        {
            // BringTrainOptionAuto 옵션 -> 전문가 옵션 활성화시 수정이 가능하도록 수정 요망 #11

            List<string> TrainOptionData = new List<string>(); // Train Option Auto List
            /* #10
             * Hardware와 InputData 정보를 이용하여 자동으로 선택되는 변수들 설정 해야함.
             * 1. Batch Size
             * 2. Image Size
             */

            double.TryParse(HardwareInformation.systemHardwareInfoJObject["GRAPHIC"]["AdapterRAM"].ToString(), out double gpuRAM);
            int batchSize = this.GetAutoBatchSize(gpuRAM, this.GetImageSize());
            if (!(batchSize > 1))
            {
                string messText = "The set GPU Memory is too small. \n There may be a problem with the program operation.";

                ProjectAI.CustomMessageBox.CustomMessageBoxOKCancel customMessageBoxOKCancel = new CustomMessageBox.CustomMessageBoxOKCancel(MessageBoxIcon.Warning, messText);
                customMessageBoxOKCancel.ShowDialog();
            }

            // Batch Size 설정
            TrainOptionData.Add(PackingString($"batch_sz |{batchSize}|"));
            // Start Learning rate 설정
            TrainOptionData.Add(PackingString($"lr_0 |{1e-3}|"));
            // Loss up Patience delta ratio ( Loss 증가 delta값 비율 설정 )설정
            TrainOptionData.Add(PackingString($"loss_up_delta  |{0.05}|"));
            // Learning rate ( 학습 율 감쇄 비율 설정 ) New LR=Old LR*new LR ratio
            TrainOptionData.Add(PackingString($"new_lr_ratio  |{0.1}|"));
            // Minimal Learning rate ( 설정되는 최소 학습율 )
            TrainOptionData.Add(PackingString($"lr_min  |{1e-10}|"));

            return TrainOptionData;
        }

        /// <summary>
        /// 자동으로 설정되는 학습 옵션
        /// </summary>
        /// <param name="TrainOptionData"> 외부에서 JObject </param>
        /// <returns> 속성값이 추가된 TrainOptionData 추가되는 Key 값은 BringTrainOptionAuto </returns>
        public JObject BringTrainOptionAuto(JObject TrainOptionData)
        {
            double.TryParse(HardwareInformation.systemHardwareInfoJObject["GRAPHIC"]["AdapterRAM"].ToString(), out double gpuRAM);
            int batchSize = this.GetAutoBatchSize(gpuRAM, this.GetImageSize());
            if (!(batchSize > 1))
            {
                string messText = "The set GPU Memory is too small. \n There may be a problem with the program operation.";

                ProjectAI.CustomMessageBox.CustomMessageBoxOKCancel customMessageBoxOKCancel = new CustomMessageBox.CustomMessageBoxOKCancel(MessageBoxIcon.Warning, messText);
                customMessageBoxOKCancel.ShowDialog();
            }

            JObject jObject = new JObject
            {
                // BringTrainOptionAuto 옵션 -> 전문가 옵션 활성화시 수정이 가능하도록 수정 요망 #11
                /* #10
                 * Hardware와 InputData 정보를 이용하여 자동으로 선택되는 변수들 설정 해야함.
                 * 1. Batch Size
                 * 2. Image Size
                 */
                // Batch Size 설정
                ["int_BatchSize"] = batchSize,
                // Start Learning rate 설정
                ["double_StartLearningrate"] = "1e-3",
                // Loss up Patience delta ratio ( Loss 증가 delta값 비율 설정 )설정
                ["double_LossUpPatienceDeltaRatio"] = "0.05",
                // Learning rate ( 학습 율 감쇄 비율 설정 ) New LR=Old LR*new LR ratio
                ["double_Learningrate"] = "0.1",
                // Minimal Learning rate ( 설정되는 최소 학습율 )
                ["double_MinimalLearningRate"] = "1e-10"
            };

            // BringTrainOptionAuto 옵션 추가
            TrainOptionData["TrainOptionAuto"] = jObject;

            return TrainOptionData;
        }

        private int GetAutoBatchSize(double graphicAdapterRAM, int imageSize)
        {
            // #33
            int batchSize = 0;

            double y = graphicAdapterRAM;

            double a = 0;
            double b = 0;

            // Network Model 설정
            if (cbbManetworkModel.Text == "Small")
            {
                a = 2E-09 * Math.Pow(imageSize, 3) + 2E-06 * Math.Pow(imageSize, 2) - 0.0005 * imageSize + 0.121;
                b = -2E-08 * Math.Pow(imageSize, 3) + 3E-05 * Math.Pow(imageSize, 2) - 0.0089 * imageSize + 3.1546;
            }
            else if (cbbManetworkModel.Text == "Medium")
            {
                a = -2E-09 * Math.Pow(imageSize, 3) + 5E-06 * Math.Pow(imageSize, 2) + 0.0006 * imageSize - 0.063;
                b = 1E-08 * Math.Pow(imageSize, 3) - 1E-05 * Math.Pow(imageSize, 2) + 0.003 * imageSize + 2.2645;
            }
            else if (cbbManetworkModel.Text == "Large")
            {
                a = 1E-05 * Math.Pow(imageSize, 2) + 0.0016 * imageSize - 0.1417;
                b = 1E-05 * Math.Pow(imageSize, 2) - 0.0063 * imageSize + 3.3052;
            }
            else if (cbbManetworkModel.Text == "Extra Large")
            {
                a = 4E-05 * Math.Pow(imageSize, 1.9256);
                b = 1.2123 * Math.Pow(imageSize, 0.1447);
            }

            double x = (y - b) / a;
            batchSize = (int)x;

            return batchSize;
        }

        /// <summary>
        /// 일반적인 상황에서는 사용하지 않는 옵션 정의 ->
        /// </summary>
        /// <returns></returns>
        public List<string> BringTrainOptionNotDefine()
        {
            List<string> TrainOptionData = new List<string>(); // Train Option Not Define List
            // Trian Options 사용 안함
            // Pretrained (학습된 데이터 이용하기)
            TrainOptionData.Add(PackingString($"pretrained |{1e-10}|")); // Use pretrained weights for ResNet; EffNet or SEResNet50

            return TrainOptionData;
        }

        public JObject BringTrainOptionNotDefine(JObject TrainOptionData)
        {
            JObject jObject = new JObject
            {
                // Trian Options 사용 안함
                // Pretrained (학습된 데이터 이용하기)
                ["double_Pretrained"] = ""
            };

            // BringTrainOptionNotDefine 옵션 추가
            TrainOptionData["TrainOptionNotDefine"] = jObject;

            return TrainOptionData;
        }

        /// <summary>
        /// 학습 옵션 설정 데이터 가져오기
        /// </summary>
        /// <returns></returns>
        public List<string> BringTrainOption()
        {
            List<string> TrainOptionData = new List<string>(); // Train Option List
            TrainOptionData.AddRange(this.BringTrainOptionManual()); // TrainOptionManual 정보 가져오기, List 합치기
            TrainOptionData.AddRange(this.BringTrainOptionAuto()); // TrainOptionAuto 정보 가져오기, List 합치기
            TrainOptionData.AddRange(this.BringTrainOptionNotDefine()); // TrainOptionNotDefine 정보 가져오기, List 합치기
            return TrainOptionData;
        }

        /// <summary>
        /// 학습 옵션 설정 데이터 가져오기
        /// </summary>
        /// <param name="TrainOptionData"> 외부에서 JObject </param>
        /// <returns> 모든 속성값이 추가된 속성값, TrainOptionManual, TrainOptionAuto, TrainOptionNotDefine </returns>
        public JObject BringTrainOption(JObject TrainOptionData)
        {
            this.BringTrainOptionManual(TrainOptionData); // TrainOptionManual 정보 가져오기
            this.BringTrainOptionAuto(TrainOptionData);// TrainOptionAuto 정보 가져오기
            this.BringTrainOptionNotDefine(TrainOptionData); // TrainOptionNotDefine 정보 가져오기

            return TrainOptionData;
        }

        #endregion Trian Options 설정

        #region Data Augmentation (데이터 증강) 설정

        /// <summary>
        /// Data Augmentation (데이터 증강) Manual 설정값 가져오기
        /// </summary>
        /// <returns></returns>
        public List<string> BringDataAugmentationManual()
        {
            List<string> AugmentationData = new List<string>(); // Data Augmentation Manual List
            // Blur 설정
            if (ckbMBlur.Checked) // 활성화 여부 확인
                AugmentationData.Add(PackingString($"blur |{txtBlur.Text}|"));
            else
                AugmentationData.Add(PackingString($"blur |{0}|"));

            // Brightness 설정
            if (ckbMBlur.Checked) // 활성화 여부 확인
            {
                AugmentationData.Add(PackingString($"brightness_min |{txtBrightnessMin.Text}|")); // min. random brightness (>= -255.)
                AugmentationData.Add(PackingString($"brightness_max |{txtBrightnessMax.Text}|")); // max. random brightness (<= +255.)
            }
            else
            {
                AugmentationData.Add(PackingString($"brightness_min |{0}|"));
                AugmentationData.Add(PackingString($"brightness_max |{0}|"));
            }

            // Center 설정
            if (ckbMCenter.Checked) // 활성화 여부 확인
                AugmentationData.Add(PackingString($"center |{txtCenter.Text}|")); // central part of images to use in Train and Test (>=0.1 && <=1.0)
            else
                AugmentationData.Add(PackingString($"center |{1}|"));

            // Contrast 설정
            if (ckbMContrast.Checked) // 활성화 여부 확인
            {
                AugmentationData.Add(PackingString($"contrast_min |{txtContrastMin.Text}|")); // min. random contrast ratio (>=0.)
                AugmentationData.Add(PackingString($"contrast_max  |{txtContrastMax.Text}|")); // max. random contrast ratio (<=10.)
            }
            else
            {
                AugmentationData.Add(PackingString($"contrast_min |{1}|"));
                AugmentationData.Add(PackingString($"contrast_max  |{1}|"));
            }

            // Gaussian Noise 설정
            if (ckbMGaussianNoise.Checked) // 활성화 여부 확인
                AugmentationData.Add(PackingString($"noise |{txtGaussianNoise.Text}|")); // probability of Gausian noise for training images
            else
                AugmentationData.Add(PackingString($"noise |{0}|"));

            // Gradation 설정
            if (ckbMGradation.Checked) // 활성화 여부 확인
                AugmentationData.Add(PackingString($"gradation |{txtGradation.Text}|")); // probability of images gradation. Direction of gradation is random
            else
                AugmentationData.Add(PackingString($"gradation |{0}|"));

            // Gradation RGB 설정
            if (ckbMContrast.Checked) // 활성화 여부 확인
            {
                // 설정 가능하도록 기능 구현 필요
                AugmentationData.Add(PackingString($"grad_color | 0 0 255{""}|")); // Gradation RGB color. If (0,0,0) than random RGB color.
            }
            else
                AugmentationData.Add(PackingString($"grad_color | 0 0 255 |"));

            // Horizontal Flip 설정
            if (ckbMHorizontalFlip.Checked) // 활성화 여부 확인
                AugmentationData.Add(PackingString($"horiz_flip |{1}|")); // probability of training images horizontal mirror == flip
            else
                AugmentationData.Add(PackingString($"horiz_flip |{0}|"));

            // Rotation 90° 설정
            if (ckbMRotation90.Checked) // 활성화 여부 확인
                AugmentationData.Add(PackingString($"rot90 |{1}|")); // probability of training images 90 grad. rotation
            else
                AugmentationData.Add(PackingString($"rot90 |{0}|"));

            // Rotation 180° 설정
            if (ckbMRotation180.Checked) // 활성화 여부 확인
                AugmentationData.Add(PackingString($"rot180 |{1}|")); // probability of training images 90 grad. rotation
            else
                AugmentationData.Add(PackingString($"rot180 |{0}|"));

            // Rotation 270° 설정
            if (ckbMRotation270.Checked) // 활성화 여부 확인
                AugmentationData.Add(PackingString($"rot270 |{1}|")); // probability of training images 90 grad. rotation
            else
                AugmentationData.Add(PackingString($"rot270 |{0}|"));

            // Sharpen 설정
            if (ckbMSharpen.Checked) // 활성화 여부 확인
                AugmentationData.Add(PackingString($"sharpen |{txtSharpen.Text}|")); // probability of training images sharpen
            else
                AugmentationData.Add(PackingString($"sharpen |{0}|"));

            // Vertical Flip 설정
            if (ckbMVerticalFlip.Checked) // 활성화 여부 확인
                AugmentationData.Add(PackingString($"vert_flip |{1}|")); // probability of training images vertical mirror | flip
            else
                AugmentationData.Add(PackingString($"vert_flip |{0}|"));

            // Zoom 설정
            if (ckbMZoom.Checked) // 활성화 여부 확인
            {
                AugmentationData.Add(PackingString($"zoom_min |{txtZoomMin.Text}|")); // min. random contrast ratio (>=0.)
                AugmentationData.Add(PackingString($"zoom_max |{txtZoomMax.Text}|")); // max. random contrast ratio (<=10.)
            }
            else
            {
                AugmentationData.Add(PackingString($"zoom_min |{1}|"));
                AugmentationData.Add(PackingString($"zoom_max |{1}|"));
            }

            return AugmentationData;
        }

        /// <summary>
        /// Data Augmentation (데이터 증강) Manual 설정값 가져오기
        /// </summary>
        /// <param name="AugmentationData"> AugmentationData JObject </param>
        /// <returns> DataAugmentationManual 속성이 추가된 AugmentationData </returns>
        public JObject BringDataAugmentationManual(JObject AugmentationData)
        {
            JObject jObject = new JObject();

            // Blur 설정
            if (ckbMBlur.Checked) // 활성화 여부 확인
            {
                jObject["bool_BlurChecked"] = ckbMBlur.Checked;
                jObject["int_Blur"] = txtBlur.Text; // probability of training images 3x3 bluring
            }
            else
            {
                jObject["bool_BlurChecked"] = ckbMBlur.Checked;
                jObject["int_Blur"] = "0";
            }

            // Brightness 설정
            if (ckbMBlur.Checked) // 활성화 여부 확인
            {
                jObject["bool_BrightnessChecked"] = ckbMBlur.Checked;
                jObject["int_BrightnessMin"] = txtBrightnessMin.Text; // min. random brightness (>= -255.)
                jObject["int_BrightnessMax"] = txtBrightnessMax.Text; // max. random brightness (<= +255.)
            }
            else
            {
                jObject["bool_BrightnessChecked"] = ckbMBlur.Checked;
                jObject["int_BrightnessMin"] = "0";
                jObject["int_BrightnessMax"] = "0";
            }

            // Center 설정
            if (ckbMCenter.Checked) // 활성화 여부 확인
            {
                jObject["bool_CenterChecked"] = ckbMCenter.Checked;
                jObject["double_Center"] = txtCenter.Text; // central part of images to use in Train and Test (>=0.1 && <=1.0)
            }
            else
            {
                jObject["bool_CenterChecked"] = ckbMCenter.Checked;
                jObject["double_Center"] = "1";
            }

            // Contrast 설정
            if (ckbMContrast.Checked) // 활성화 여부 확인
            {
                jObject["bool_ContrastChecked"] = ckbMContrast.Checked;
                jObject["int_ContrastMin"] = txtContrastMin.Text; // min. random contrast ratio (>=0.)
                jObject["int_ContrastMax"] = txtContrastMax.Text; // max. random contrast ratio (<=10.)
            }
            else
            {
                jObject["bool_ContrastChecked"] = ckbMContrast.Checked;
                jObject["int_ContrastMin"] = "1";
                jObject["int_ContrastMax"] = "1";
            }

            // Gaussian Noise 설정
            if (ckbMGaussianNoise.Checked) // 활성화 여부 확인
            {
                jObject["bool_GaussianNoiseChecked"] = ckbMGaussianNoise.Checked;
                jObject["double_GaussianNoise"] = txtGaussianNoise.Text; // probability of Gausian noise for training images
            }
            else
            {
                jObject["bool_GaussianNoiseChecked"] = ckbMGaussianNoise.Checked;
                jObject["double_GaussianNoise"] = "0";
            }

            // Gradation 설정
            if (ckbMGradation.Checked) // 활성화 여부 확인
            {
                jObject["bool_GradationChecked"] = ckbMGradation.Checked;
                jObject["int_Gradation"] = txtGradation.Text; // probability of images gradation. Direction of gradation is random
            }
            else
            {
                jObject["bool_GradationChecked"] = ckbMGradation.Checked;
                jObject["int_Gradation"] = "0";
            }

            // Gradation RGB 설정
            if (ckbMContrast.Checked) // 활성화 여부 확인
            {
                // 설정 가능하도록 기능 구현 필요
                jObject["bool_GradationRGBChecked"] = ckbMContrast.Checked;
                jObject["int_GradationRGB"] = "0 0 255"; // Gradation RGB color. If (0,0,0) than random RGB color.
            }
            else
            {
                jObject["bool_GradationRGBChecked"] = ckbMContrast.Checked;
                jObject["int_GradationRGB"] = "0 0 255";
            }

            // Horizontal Flip 설정
            if (ckbMHorizontalFlip.Checked) // 활성화 여부 확인
                jObject["bool_HorizontalFlipChecked"] = ckbMHorizontalFlip.Checked; // probability of training images horizontal mirror == flip
            else
                jObject["bool_HorizontalFlipChecked"] = ckbMHorizontalFlip.Checked;

            // Rotation 90° 설정
            if (ckbMRotation90.Checked) // 활성화 여부 확인
                jObject["bool_Rotation90Checked"] = ckbMRotation90.Checked; // probability of training images 90 grad. rotation
            else
                jObject["bool_Rotation90Checked"] = ckbMRotation90.Checked;

            // Rotation 180° 설정
            if (ckbMRotation180.Checked) // 활성화 여부 확인
                jObject["bool_Rotation180Checked"] = ckbMRotation180.Checked; // probability of training images 90 grad. rotation
            else
                jObject["bool_Rotation180Checked"] = ckbMRotation180.Checked;

            // Rotation 270° 설정
            if (ckbMRotation270.Checked) // 활성화 여부 확인
                jObject["bool_Rotation270Checked"] = ckbMRotation270.Checked; // probability of training images 90 grad. rotation
            else
                jObject["bool_Rotation270Checked"] = ckbMRotation270.Checked;

            // Sharpen 설정
            if (ckbMSharpen.Checked) // 활성화 여부 확인
            {
                jObject["bool_SharpenChecked"] = ckbMSharpen.Checked;
                jObject["double_Sharpen"] = txtSharpen.Text;  // probability of training images sharpen
            }
            else
            {
                jObject["bool_SharpenChecked"] = ckbMSharpen.Checked;
                jObject["double_Sharpen"] = "0";
            }

            // Vertical Flip 설정
            if (ckbMVerticalFlip.Checked) // 활성화 여부 확인
                jObject["bool_VerticalFlipChecked"] = ckbMVerticalFlip.Checked; // probability of training images vertical mirror | flip
            else
                jObject["bool_VerticalFlipChecked"] = ckbMVerticalFlip.Checked;

            // Zoom 설정
            if (ckbMZoom.Checked) // 활성화 여부 확인
            {
                jObject["double_ZoomChecked"] = ckbMZoom.Checked;
                jObject["double_ZoomMin"] = txtZoomMin.Text; // min. random contrast ratio (>=0.)
                jObject["double_ZoomMax"] = txtZoomMax.Text; // max. random contrast ratio (<=10.)
            }
            else
            {
                jObject["double_ZoomChecked"] = ckbMZoom.Checked;
                jObject["double_ZoomMin"] = "1";
                jObject["double_ZoomMax"] = "1";
            }
            // BringDataAugmentationManual 옵션 적용
            AugmentationData["DataAugmentationManual"] = jObject;

            return AugmentationData;
        }

        /// <summary>
        /// 일반적인 상황에서는 사용하지 않는 옵션 정의
        /// </summary>
        /// <returns></returns>
        public List<string> BringDataAugmentationNotDefine()
        {
            List<string> AugmentationData = new List<string>(); // Data Augmentation Manual List

            // Horizontal Flip Save 설정 -> 설정해도 동작 안함.
            if (ckbMHorizontalFlip.Checked) // 활성화 여부 확인
            {
                AugmentationData.Add(PackingString($"n_horiz_flip |{0}|")); // 일정 갯수마다 예 이미지 저장 - 동작 안함
            }
            else
            {
                AugmentationData.Add(PackingString($"n_horiz_flip |{0}|"));
            }

            // Vertical Flip Save 설정 -> 설정해도 동작 안함.
            if (ckbMVerticalFlip.Checked) // 활성화 여부 확인
            {
                AugmentationData.Add(PackingString($"n_vert_flip |{0}|")); // 일정 갯수마다 예 이미지 저장 - 동작 안함
            }
            else
            {
                AugmentationData.Add(PackingString($"n_vert_flip |{0}|"));
            }

            return AugmentationData;
        }

        public JObject BringDataAugmentationNotDefine(JObject AugmentationData)
        {
            JObject jObject = new JObject
            {
                // Horizontal Flip Save 설정 -> 설정해도 동작 안함.
                ["bool_HorizontalFlipSave"] = ckbMHorizontalFlip.Checked, // 일정 갯수마다 예 이미지 저장 - 동작 안함

                // Vertical Flip Save 설정 -> 설정해도 동작 안함.
                ["bool_VerticalFlipSave"] = ckbMVerticalFlip.Checked // 일정 갯수마다 예 이미지 저장 - 동작 안함
            };

            AugmentationData["DataAugmentationNotDefine"] = jObject;

            return AugmentationData;
        }

        /// <summary>
        /// Data Augmentation 설정값 가져오기
        /// </summary>
        /// <returns></returns>
        public List<string> BringDataAugmentation()
        {
            List<string> AugmentationData = new List<string>(); // Data Augmentation Manual List
            AugmentationData.AddRange(BringDataAugmentationManual()); // AugmentationManual 정보 가져오기, List 합치기
            AugmentationData.AddRange(BringDataAugmentationNotDefine()); // ugmentationNotDefine 정보 가져오기, List 합치기
            return AugmentationData;
        }

        /// <summary>
        /// Data Augmentation 설정값 가져오기
        /// </summary>
        /// <param name="AugmentationData"> JObject AugmentationData </param>
        /// <returns> 각 데이터 속정이 추가된 AugmentationData, DataAugmentationManual, DataAugmentationNotDefine </returns>
        public JObject BringDataAugmentation(JObject AugmentationData)
        {
            BringDataAugmentationManual(AugmentationData); // AugmentationManual 정보 가져오기, List 합치기
            BringDataAugmentationNotDefine(AugmentationData); // ugmentationNotDefine 정보 가져오기, List 합치기

            return AugmentationData;
        }

        #endregion Data Augmentation (데이터 증강) 설정

        #region Continual Learning (이어 학습하기 옵션) 설정

        private string m_continualLearningPath = "";
        private string m_continualLearningModelName = "";
        private string m_continualLearningModelLoss = "";
        private string m_continualLearningModelAccuracy = "";
        private string m_continualLearningModelEscape = "";
        private string m_continualLearningModelOverKill = "";

        /// <summary>
        /// Data Grid View 설정
        /// </summary>
        private void UISetdgvMContinualLearning()
        {
            this.dgvMContinualLearning.DataSource = null;
            this.dgvMContinualLearning.Columns.Clear();
            this.dgvMContinualLearning.Rows.Clear();
            this.dgvMContinualLearning.Refresh();

            this.dgvMContinualLearning.ColumnCount = 5;
            this.dgvMContinualLearning.Columns[0].Name = "Version";
            this.dgvMContinualLearning.Columns[1].Name = "Best Accuracy"; // (double_TrainAcc + double_TestAcc) / 2
            this.dgvMContinualLearning.Columns[2].Name = "Best Loss";
            this.dgvMContinualLearning.Columns[3].Name = "Best Escape";
            this.dgvMContinualLearning.Columns[4].Name = "Best OverKill";
        }

        /// <summary>
        /// 모델 정보 업데이터
        /// </summary>
        public void ModelUpdate()
        {
            if (WorkSpaceData.m_activeProjectMainger != null)
            {
                if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
                {
                    if (WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] != null)
                    {
                        int version = 1;
                        foreach (string modelName in WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["array_string_ModelList"])
                        {
                            double trainLoss = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["double_TrainLoss"]);
                            double trainAcc = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["double_TrainAcc"]);
                            double testLoss = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["double_TestLoss"]);
                            double testAcc = Convert.ToDouble(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["double_TestAcc"]);

                            int trainEscape = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["int_TrainEscape"]);
                            int trainOverKill = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["int_TrainOverKill"]);
                            int testEscape = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["int_TestEscape"]);
                            int testOverKill = Convert.ToInt32(WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][modelName]["BestModelInfo"]["int_TestOverKill"]);

                            this.dgvMContinualLearning.Rows.Add(version, (trainAcc + testAcc) / 2, (trainLoss + testLoss) / 2, (trainEscape + testEscape) / 2, (trainOverKill + testOverKill) / 2);

                            version++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Continual Learning에서 모델 선택시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMContinualLearningCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1) // 컬럼 해더 눌렀는지 감지 해더를 눌렀으면 통과
                if (this.dgvMContinualLearning.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    List<string> modelList = new List<string>();
                    foreach (string modelName in WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName]["array_string_ModelList"]) // 모델 이름 List 로 만들기
                        modelList.Add(modelName);

                    int version = Convert.ToInt32(this.dgvMContinualLearning.Rows[e.RowIndex].Cells[0].Value.ToString()) - 1; // 호출하는 모델 버전 정보 가져오기

                    string selectModelName = modelList[version]; // 선택된 모델 관리 이름

                    using (ProjectAI.MainForms.UserContral.Classification.ContinualLearningInnerModelSelecter continualLearningInnerModelSelecter = new ProjectAI.MainForms.UserContral.Classification.ContinualLearningInnerModelSelecter(selectModelName)) // 내부 모델 선택 폼 호출
                    {
                        // Using으로 호출해서 사용후 삭제 되도록 호출

                        /* 선택된 모델 정보 가져오기
                         * 1. Inner Model Path 가져오기
                         * 2. Inner Model Name 가져오기
                         * 3. Model Learning Info 데이터 가져오기
                         * 4. lblMnetworkModel에 모델 사이즈 적용하기
                         */
                        continualLearningInnerModelSelecter.ShowDialog(); // Dialog 형태로 호출

                        // 1. Inner Model Path 가져오기
                        this.m_continualLearningPath = continualLearningInnerModelSelecter.GetModelPath(); // Inner Model Path 가져오기
                        // 2. Inner Model Name 가져오기
                        this.m_continualLearningModelName = continualLearningInnerModelSelecter.GetModelName();
                        // 2-1. Inner Model 정보 가져오기
                        this.m_continualLearningModelLoss = continualLearningInnerModelSelecter.GetModelLoss();
                        this.m_continualLearningModelAccuracy = continualLearningInnerModelSelecter.GetModelAccuracy();
                        this.m_continualLearningModelEscape = continualLearningInnerModelSelecter.GetModelEscape();
                        this.m_continualLearningModelOverKill = continualLearningInnerModelSelecter.GetModelOverKill();

                        // 3. Model Learning Info 데이터 가져오기
                        string selectedNetworkModel = WorkSpaceData.m_activeProjectMainger.m_activeProjectModelInfoJObject[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName][selectModelName]["ModelLearningInfo"]["TrainOptionManual"]["string_NetworkModel"].ToString();
                        // 4. lblMnetworkModel에 모델 사이즈 적용하기
                        if (selectedNetworkModel == "SynapseNet_Classification_18")
                        {
                            this.cbbManetworkModel.PromptText = "Small";
                            this.cbbManetworkModel.Text = "Small";
                        }
                        else if (selectedNetworkModel == "SynapseNet_Classification_34")
                        {
                            this.cbbManetworkModel.PromptText = "Medium";
                            this.cbbManetworkModel.Text = "Medium";
                        }
                        else if (selectedNetworkModel == "SynapseNet_Classification_50")
                        {
                            this.cbbManetworkModel.PromptText = "Large";
                            this.cbbManetworkModel.Text = "Large";
                        }
                        else if (selectedNetworkModel == "SynapseNet_Classification_100")
                        {
                            this.cbbManetworkModel.PromptText = "Extra Large";
                            this.cbbManetworkModel.Text = "Extra Large";
                        }
                    }
                }
        }

        /// <summary>
        /// Continual Learning (이어 학습하기 옵션) 설정
        /// </summary>
        /// <returns></returns>
        public List<string> BringContinualLearning()
        {
            List<string> ContinualLearningData = new List<string>(); // Continual Learning List

            // Continual Learning 설정
            if (togMContinualLearning.Checked) // 활성화 여부 확인
            {
                if (m_continualLearningPath != null)
                    ContinualLearningData.Add(PackingString($"dnn_file |{m_continualLearningPath}|")); // DNN file path to Load from and save to ('default'=>autogenaration, 'new'=>file recreation)
            }
            else
            {
                ContinualLearningData.Add(PackingString($"dnn_file |{"default"}|")); // DNN file path to Load from and save to ('default'=>autogenaration, 'new'=>file recreation)
            }
            return ContinualLearningData;
        }

        /// <summary>
        /// Continual Learning (이어 학습하기 옵션) 설정
        /// </summary>
        /// <param name="ContinualLearningData"> JObject </param>
        /// <returns> ContinualLearning 속성이 추가된 ContinualLearningData </returns>
        public JObject BringContinualLearning(JObject ContinualLearningData)
        {
            JObject jObject = new JObject();
            // Continual Learning 설정

            jObject["bool_ContinualLearningChecked"] = togMContinualLearning.Checked;

            if (togMContinualLearning.Checked) // 활성화 여부 확인
            {
                if (this.m_continualLearningPath != null)
                {
                    jObject["string_ContinualLearning"] = "default";
                    if (this.m_continualLearningPath.Length == 0)
                        jObject["string_ContinualLearning"] = this.m_continualLearningPath; // DNN file path to Load from and save to ('default'=>autogenaration, 'new'=>file recreation)
                }
                else
                {
                    jObject["string_ContinualLearning"] = "default";
                }
            }
            else
            {
                this.m_continualLearningPath = null;
                jObject["string_ContinualLearning"] = "default";
            }

            jObject["string_ContinualLearningModelName"] = this.m_continualLearningModelName; //
            jObject["string_ContinualLearningModelLoss"] = this.m_continualLearningModelLoss; //
            jObject["string_ContinualLearningModelAccuracy"] = this.m_continualLearningModelAccuracy; //
            jObject["string_ContinualLearningModelEscape"] = this.m_continualLearningModelEscape; //
            jObject["string_ContinualLearningModelOverKill"] = this.m_continualLearningModelOverKill; //

            ContinualLearningData["ContinualLearning"] = jObject;

            return ContinualLearningData;
        }

        /// <summary>
        /// Continual Learning 활성화 버튼 클릭시 동작 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TogMContinualLearningCheckedChanged(object sender, EventArgs e)
        {
            this.panelContinualLearning.Visible = this.togMContinualLearning.Checked;

            if (this.togMContinualLearning.Checked)
            {
                /* 이어학습 하기가 동작하면 비활성화 되어야 하는 컨트롤 설정
                 * 1. Network Model 선택 불가
                 * 2. Architecture 선택 불가
                 */
                this.cbbManetworkModel.Enabled = false;
                this.cbbManetworkModel.Enabled = false;
            }
            else
            {
                this.cbbManetworkModel.Enabled = true;
                this.cbbManetworkModel.Enabled = true;
            }
        }

        #endregion Continual Learning (이어 학습하기 옵션) 설정

        #region Class Weight 설정

        private JObject BringClassWeight(JObject classWeightData)
        {
            JObject jObject = new JObject();
            // class Weigh 정보 가져오기
            foreach (string className in this.classWeightControls.Keys.ToList())
            {
                jObject[className] = this.classWeightControls[className].Weight;
            }
            classWeightData["ClassWeight"] = jObject;
            return classWeightData;
        }

        #endregion Class Weight 설정

        #region 인스턴스 모델 평가

        private string instantEvaluateDataset = "All";

        private void TogMInstantEvaluateCheckedChanged(object sender, EventArgs e)
        {
            this.panelInstantEvaluate.Visible = this.togMInstantEvaluate.Checked;
            this.instantEvaluateDataset = "All";
        }

        private void TilMInstantEvaluateAllClick(object sender, EventArgs e)
        {
            this.instantEvaluateDataset = "All";
            Control control = (Control)sender;
            this.ActivateButton(sender, control.Parent);
        }

        private void TilMInstantEvaluateTrainClick(object sender, EventArgs e)
        {
            this.instantEvaluateDataset = "Train";
            Control control = (Control)sender;
            this.ActivateButton(sender, control.Parent);
        }

        private void TilMInstantEvaluateTestClick(object sender, EventArgs e)
        {
            this.instantEvaluateDataset = "Test";
            Control control = (Control)sender;
            this.ActivateButton(sender, control.Parent);
        }

        private void ActivateButton(object btnSender, object panel = null)
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
            if (btnSender != null)
            {
                if (this.activeMetroButton != btnSender)
                {
                    this.activeMetroButton = btnSender as MetroTile;
                    if (this.activeMetroButton != null)
                    {
                        DisableButton(btnSender, panel);
                        this.activeMetroButton = (MetroTile)btnSender;
                        this.activeMetroButton.UseStyleColors = true;
                        this.activeMetroButton.Style = MetroFramework.MetroColorStyle.Orange;
                    }
                }
            }
        }

        private void DisableButton(object btnSender, object panel = null)
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
            //System.Windows.Forms.TableLayoutPanel
            foreach (Control previousBtn in this.tlpInstantEvaluate.Controls)
            {
                MetroTile metroButton = previousBtn as MetroTile;
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

        /// <summary>
        /// InstantEvaluate 설정값 가져오기
        /// </summary>
        /// <param name="instantEvaluateData"></param>
        /// <returns></returns>
        private JObject BringInstantEvaluate(JObject instantEvaluateData)
        {
            JObject jObject = new JObject
            {
                ["bool_InstantEvaluateChecked"] = this.togMInstantEvaluate.Checked,
                ["string_InstantEvaluateDataset"] = this.instantEvaluateDataset
            };

            // BringInstantEvaluate 옵션 적용
            instantEvaluateData["InstantEvaluate"] = jObject;

            return instantEvaluateData;
        }

        #endregion 인스턴스 모델 평가

        #region 이미지 설정 옵션

        private JObject BringImageOption(JObject imageOptions)
        {
            int imageSize = 0;
            int imageChannel = 3;

            imageSize = this.GetImageSize();

            if (imageSize == 0)
                imageSize = 256;

            JObject jObject = new JObject
            {
                ["int_imageChannel"] = imageChannel,
                ["int_imageSize"] = imageSize
            };

            // Image Option 정보 가져오기
            imageOptions["ImageOption"] = jObject;
            return imageOptions;
        }

        private int GetImageSize()
        {
            int imageSize = 0;
            foreach (JProperty imageData in (JToken)WorkSpaceData.m_activeProjectMainger.m_activeProjectDataImageListDataJObject)
            {
                // #33
                Bitmap image = CustomIOMainger.LoadBitmap(imageData.Value["string_ImagePath"].ToString());
                if (image.Width.Equals(image.Height))
                {
                    imageSize = image.Width;
                    break;
                }
            }
            return imageSize;
        }

        #endregion 이미지 설정 옵션

        #region 시스템 설정 옵션

        private JObject BringTrainSystemOption(JObject trainSystemOption)
        {
            JObject jObject = new JObject
            {
                ["int_dataLoaderNUmberofWorkers"] = 8
            };

            // Image Option 정보 가져오기
            trainSystemOption["TrainSystemOption"] = jObject;
            return trainSystemOption;
        }

        #endregion 시스템 설정 옵션

        /// <summary>
        /// 학습에 필요한 옵션 가져오기
        /// </summary>j
        /// <param name="trainOptions"></param>
        /// <returns> JObject 정리된 옵션 정보 </returns>
        public JObject GetTrainOptions(JObject trainOptions)
        {
            this.BringTrainOption(trainOptions);
            this.BringDataAugmentation(trainOptions);
            this.BringContinualLearning(trainOptions);
            this.BringClassWeight(trainOptions);
            this.BringInstantEvaluate(trainOptions);
            this.BringImageOption(trainOptions);
            this.BringTrainSystemOption(trainOptions);

            return trainOptions;
        }

        #region ToolTip 설정

        /// <summary>
        /// 데이터 증강 물음표 toolTip 설정
        /// </summary>
        private void SetToolTip()
        {
            MetroFramework.Components.MetroToolTip BlurmetroToolTip = new MetroFramework.Components.MetroToolTip();
            MetroFramework.Components.MetroToolTip BrightnessmetroToolTip = new MetroFramework.Components.MetroToolTip();
            MetroFramework.Components.MetroToolTip CentermetroToolTip = new MetroFramework.Components.MetroToolTip();
            MetroFramework.Components.MetroToolTip ContrastmetroToolTip = new MetroFramework.Components.MetroToolTip();
            MetroFramework.Components.MetroToolTip GaussianNoisemetroToolTip = new MetroFramework.Components.MetroToolTip();
            MetroFramework.Components.MetroToolTip GradationmetroToolTip = new MetroFramework.Components.MetroToolTip();
            MetroFramework.Components.MetroToolTip GradationRGBmetroToolTip = new MetroFramework.Components.MetroToolTip();
            MetroFramework.Components.MetroToolTip HorizontalFlipmetroToolTip = new MetroFramework.Components.MetroToolTip();
            MetroFramework.Components.MetroToolTip Rotation90metroToolTip = new MetroFramework.Components.MetroToolTip();
            MetroFramework.Components.MetroToolTip Rotation180metroToolTip = new MetroFramework.Components.MetroToolTip();
            MetroFramework.Components.MetroToolTip Rotation270metroToolTip = new MetroFramework.Components.MetroToolTip();
            MetroFramework.Components.MetroToolTip SharpenmetroToolTip = new MetroFramework.Components.MetroToolTip();
            MetroFramework.Components.MetroToolTip VerticalFlipmetroToolTip = new MetroFramework.Components.MetroToolTip();
            MetroFramework.Components.MetroToolTip ZoommetroToolTip = new MetroFramework.Components.MetroToolTip();

            //Blur
            BlurmetroToolTip.Popup += BlurToolTipPopup;
            BlurmetroToolTip.Draw += BlurToolTipDraw;
            BlurmetroToolTip.SetToolTip(this.panelMBlurToolTip, " ");

            //Brightness
            BrightnessmetroToolTip.Popup += BrightnessToolTipPopup;
            BrightnessmetroToolTip.Draw += BrightnessToolTipDraw;
            BrightnessmetroToolTip.SetToolTip(this.panelMBrightnessToolTip, " ");

            //Center
            CentermetroToolTip.Popup += CenterToolTipPopup;
            CentermetroToolTip.Draw += CenterToolTipDraw;
            CentermetroToolTip.SetToolTip(this.panelMCenterToolTip, "Center");

            //Contrast
            ContrastmetroToolTip.Popup += ContrastToolTipPopup;
            ContrastmetroToolTip.Draw += ContrastToolTipDraw;
            ContrastmetroToolTip.SetToolTip(this.panelMContrastToolTip, "Contrast");

            //GaussianNoise
            GaussianNoisemetroToolTip.Popup += GaussianNoiseToolTipPopup;
            GaussianNoisemetroToolTip.Draw += GaussianNoiseToolTipDraw;
            GaussianNoisemetroToolTip.SetToolTip(this.panelMGaussianNoiseToolTip, "GaussianNoise");

            //Gradation
            GradationmetroToolTip.Popup += GradationToolTipPopup;
            GradationmetroToolTip.Draw += GradationToolTipDraw;
            GradationmetroToolTip.SetToolTip(this.panelMGradationToolTip, "Gradation");

            //GradationRGB
            GradationRGBmetroToolTip.Popup += GradationRGBToolTipPopup;
            GradationRGBmetroToolTip.Draw += GradationRGBToolTipDraw;
            GradationRGBmetroToolTip.SetToolTip(this.panelMGradationRGBToolTip, "GradationRGB");

            //HorizontalFlip
            HorizontalFlipmetroToolTip.Popup += HorizontalFlipToolTipPopup;
            HorizontalFlipmetroToolTip.Draw += HorizontalFlipToolTipDraw;
            HorizontalFlipmetroToolTip.SetToolTip(this.panelMHorizontalFlipToolTip, "HorizontalFlip");

            //Rotation90
            Rotation90metroToolTip.Popup += Rotation90ToolTipPopup;
            Rotation90metroToolTip.Draw += Rotation90ToolTipDraw;
            Rotation90metroToolTip.SetToolTip(this.panelMRotation90ToolTip, "Rotation90");

            //Rotation180
            Rotation180metroToolTip.Popup += Rotation180ToolTipPopup;
            Rotation180metroToolTip.Draw += Rotation180ToolTipDraw;
            Rotation180metroToolTip.SetToolTip(this.panelMRotation180ToolTip, "Rotation180");

            //Rotation270
            Rotation270metroToolTip.Popup += Rotation270ToolTipPopup;
            Rotation270metroToolTip.Draw += Rotation270ToolTipDraw;
            Rotation270metroToolTip.SetToolTip(this.panelMRotation270ToolTip, "Rotation270");

            //Sharpen
            SharpenmetroToolTip.Popup += SharpenToolTipPopup;
            SharpenmetroToolTip.Draw += SharpenToolTipDraw;
            SharpenmetroToolTip.SetToolTip(this.panelMSharpenToolTip, "Sharpen");

            //VerticalFlip
            VerticalFlipmetroToolTip.Popup += VerticalFlipToolTipPopup;
            VerticalFlipmetroToolTip.Draw += VerticalFlipToolTipDraw;
            VerticalFlipmetroToolTip.SetToolTip(this.panelMVerticalFlipToolTip, "VerticalFlip");

            //Zoom
            ZoommetroToolTip.Popup += ZoomToolTipPopup;
            ZoommetroToolTip.Draw += ZoomToolTipDraw;
            ZoommetroToolTip.SetToolTip(this.panelMZoomToolTip, "Zoom");
        }

        private int MARGIN = 2;

        /// <summary>
        /// 툴팁 팝업 설정 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="toolTipImage"></param>
        /// <param name="margin"></param>
        private void ToolTipPopup(object sender, PopupEventArgs e, Image toolTipImage, int margin)
        {
            int totalImageWidth = 2 * margin + toolTipImage.Width;
            int totalImageHeight = 2 * margin + toolTipImage.Height;
            e.ToolTipSize = new Size(totalImageWidth, totalImageHeight);
        }

        /// <summary>
        /// 툴팁 이미지 그리기 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="toolTipImage"></param>
        /// <param name="margin"></param>
        private void ToolTipDraw(object sender, DrawToolTipEventArgs e, Image toolTipImage, int margin)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawImage(toolTipImage, margin, margin);
            e.Graphics.DrawString(e.ToolTipText, SystemFonts.DefaultFont, Brushes.White, 0, 0);
        }

        #region Blur

        private void BlurToolTipPopup(object sender, PopupEventArgs e)
        {
            this.ToolTipPopup(sender, e, global::ProjectAI.Properties.Resources.appleBlurA72, MARGIN);
        }

        private void BlurToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            this.ToolTipDraw(sender, e, global::ProjectAI.Properties.Resources.appleBlurA72, MARGIN);
        }

        #endregion Blur

        #region Brightness

        private void BrightnessToolTipPopup(object sender, PopupEventArgs e)
        {
            this.ToolTipPopup(sender, e, global::ProjectAI.Properties.Resources.appleBrightnessA72, MARGIN);
        }

        private void BrightnessToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            this.ToolTipDraw(sender, e, global::ProjectAI.Properties.Resources.appleBrightnessA72, MARGIN);
        }

        #endregion Brightness

        #region Center

        private void CenterToolTipPopup(object sender, PopupEventArgs e)
        {
            this.ToolTipPopup(sender, e, global::ProjectAI.Properties.Resources.appleCenterA72, MARGIN);
        }

        private void CenterToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            this.ToolTipDraw(sender, e, global::ProjectAI.Properties.Resources.appleCenterA72, MARGIN);
        }

        #endregion Center

        #region Contrast

        private void ContrastToolTipPopup(object sender, PopupEventArgs e)
        {
            this.ToolTipPopup(sender, e, global::ProjectAI.Properties.Resources.appleContrastA72, MARGIN);
        }

        private void ContrastToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            this.ToolTipDraw(sender, e, global::ProjectAI.Properties.Resources.appleContrastA72, MARGIN);
        }

        #endregion Contrast

        #region GaussianNoise

        private void GaussianNoiseToolTipPopup(object sender, PopupEventArgs e)
        {
            this.ToolTipPopup(sender, e, global::ProjectAI.Properties.Resources.appleContrastA72, MARGIN);
        }

        private void GaussianNoiseToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            this.ToolTipDraw(sender, e, global::ProjectAI.Properties.Resources.appleContrastA72, MARGIN);
        }

        #endregion GaussianNoise

        #region Gradation

        private void GradationToolTipPopup(object sender, PopupEventArgs e)
        {
            this.ToolTipPopup(sender, e, global::ProjectAI.Properties.Resources.appleContrastA72, MARGIN);
        }

        private void GradationToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            this.ToolTipDraw(sender, e, global::ProjectAI.Properties.Resources.appleContrastA72, MARGIN);
        }

        #endregion Gradation

        #region GradationRGB

        private void GradationRGBToolTipPopup(object sender, PopupEventArgs e)
        {
            this.ToolTipPopup(sender, e, global::ProjectAI.Properties.Resources.appleContrastA72, MARGIN);
        }

        private void GradationRGBToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            this.ToolTipDraw(sender, e, global::ProjectAI.Properties.Resources.appleContrastA72, MARGIN);
        }

        #endregion GradationRGB

        #region HorizontalFlip

        private void HorizontalFlipToolTipPopup(object sender, PopupEventArgs e)
        {
            this.ToolTipPopup(sender, e, global::ProjectAI.Properties.Resources.appleHoriaontalA72, MARGIN);
        }

        private void HorizontalFlipToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            this.ToolTipDraw(sender, e, global::ProjectAI.Properties.Resources.appleHoriaontalA72, MARGIN);
        }

        #endregion HorizontalFlip

        #region Rotation90

        private void Rotation90ToolTipPopup(object sender, PopupEventArgs e)
        {
            this.ToolTipPopup(sender, e, global::ProjectAI.Properties.Resources.appleRotation90A72, MARGIN);
        }

        private void Rotation90ToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            this.ToolTipDraw(sender, e, global::ProjectAI.Properties.Resources.appleRotation90A72, MARGIN);
        }

        #endregion Rotation90

        #region Rotation180

        private void Rotation180ToolTipPopup(object sender, PopupEventArgs e)
        {
            this.ToolTipPopup(sender, e, global::ProjectAI.Properties.Resources.appleRotation180A72, MARGIN);
        }

        private void Rotation180ToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            this.ToolTipDraw(sender, e, global::ProjectAI.Properties.Resources.appleRotation180A72, MARGIN);
        }

        #endregion Rotation180

        #region Rotation270

        private void Rotation270ToolTipPopup(object sender, PopupEventArgs e)
        {
            this.ToolTipPopup(sender, e, global::ProjectAI.Properties.Resources.appleRotation270A72, MARGIN);
        }

        private void Rotation270ToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            this.ToolTipDraw(sender, e, global::ProjectAI.Properties.Resources.appleRotation270A72, MARGIN);
        }

        #endregion Rotation270

        #region Sharpen

        private void SharpenToolTipPopup(object sender, PopupEventArgs e)
        {
            this.ToolTipPopup(sender, e, global::ProjectAI.Properties.Resources.appleSharpenA72, MARGIN);
        }

        private void SharpenToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            this.ToolTipDraw(sender, e, global::ProjectAI.Properties.Resources.appleSharpenA72, MARGIN);
        }

        #endregion Sharpen

        #region VerticalFlip

        private void VerticalFlipToolTipPopup(object sender, PopupEventArgs e)
        {
            this.ToolTipPopup(sender, e, global::ProjectAI.Properties.Resources.appleVertical72A, MARGIN);
        }

        private void VerticalFlipToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            this.ToolTipDraw(sender, e, global::ProjectAI.Properties.Resources.appleVertical72A, MARGIN);
        }

        #endregion VerticalFlip

        #region Zoom

        private void ZoomToolTipPopup(object sender, PopupEventArgs e)
        {
            this.ToolTipPopup(sender, e, global::ProjectAI.Properties.Resources.appleCenterA72, MARGIN);
        }

        private void ZoomToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            this.ToolTipDraw(sender, e, global::ProjectAI.Properties.Resources.appleCenterA72, MARGIN);
        }

        #endregion Zoom

        #endregion ToolTip 설정

        #region 세부 옵션 설정

        private void TilMBlurClick(object sender, EventArgs e)
        {
            this.DataAugmentationGetValue("blur", this.txtBlur);
        }

        private void TilMBrightnessClick(object sender, EventArgs e)
        {
            this.DataAugmentationGetValue("Brightness", this.txtBrightnessMin, this.txtBrightnessMax);
        }

        private void TilMCenterClick(object sender, EventArgs e)
        {
            this.DataAugmentationGetValue("Center", this.txtCenter);
        }

        private void TilMContrastClick(object sender, EventArgs e)
        {
            this.DataAugmentationGetValue("Contrast", this.txtContrastMin, this.txtContrastMax);
        }

        private void TilMGaussianNoiseClick(object sender, EventArgs e)
        {
            this.DataAugmentationGetValue("GaussianNoise", this.txtGaussianNoise);
        }

        private void TilMSharpenClick(object sender, EventArgs e)
        {
            this.DataAugmentationGetValue("Sharpen", this.txtSharpen);
        }

        private void TilMGradationClick(object sender, EventArgs e)
        {
            this.DataAugmentationGetValue("Gradation", this.txtGradation);
        }

        private void TilMGradationRGBClick(object sender, EventArgs e)
        {
            this.DataAugmentationGetValue("GradationRGB", this.txtGradation);
        }

        private void TilMZoomClick(object sender, EventArgs e)
        {
            this.DataAugmentationGetValue("Zoom", this.txtZoomMax);
        }

        private void DataAugmentationGetValue(string exCase, MetroFramework.Controls.MetroTextBox maxTextBox)
        {
            ProjectAI.MainForms.MainForm mainForm = ProjectAI.MainForms.MainForm.GetInstance();
            if (WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName != null)
            {
                string imagePath = null;
                try
                {
                    if (WorkSpaceData.m_activeProjectMainger.m_imageListDictionary[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] is ProjectAI.MainForms.UserContral.ImageList.GridViewImageList GridViewImageList)
                    {
                        imagePath = GridViewImageList.GetSelectImagePath();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    imagePath = null;
                }
                finally
                {
                    using (ProjectAI.DataAugmentationExampleForms.DataAugmentationExampleForm dataAugmentationExampleForm = new DataAugmentationExampleForms.DataAugmentationExampleForm(imagePath, exCase))
                    {
                        dataAugmentationExampleForm.ShowDialog();
                        if (dataAugmentationExampleForm.DialogResultSelected == DialogResult.OK)
                        {
                            maxTextBox.Text = dataAugmentationExampleForm.maximumValue;
                        }
                    }
                }
            }
        }

        private void DataAugmentationGetValue(string exCase, TextBox maxTextBox)
        {
            string imagePath = null;
            try
            {
                if (WorkSpaceData.m_activeProjectMainger.m_imageListDictionary[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] is ProjectAI.MainForms.UserContral.ImageList.GridViewImageList GridViewImageList)
                {
                    imagePath = GridViewImageList.GetSelectImagePath();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                imagePath = null;
            }
            finally
            {
                using (ProjectAI.DataAugmentationExampleForms.DataAugmentationExampleForm dataAugmentationExampleForm = new DataAugmentationExampleForms.DataAugmentationExampleForm(imagePath, exCase))
                {
                    dataAugmentationExampleForm.ShowDialog();
                    if (dataAugmentationExampleForm.DialogResultSelected == DialogResult.OK)
                    {
                        maxTextBox.Text = dataAugmentationExampleForm.maximumValue;
                    }
                }
            }
        }

        private void DataAugmentationGetValue(string exCase, MetroFramework.Controls.MetroTextBox minTextBox, MetroFramework.Controls.MetroTextBox maxTextBox)
        {
            string imagePath = null;
            try
            {
                if (WorkSpaceData.m_activeProjectMainger.m_imageListDictionary[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] is ProjectAI.MainForms.UserContral.ImageList.GridViewImageList GridViewImageList)
                {
                    imagePath = GridViewImageList.GetSelectImagePath();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                imagePath = null;
            }
            finally
            {
                using (ProjectAI.DataAugmentationExampleForms.DataAugmentationExampleForm dataAugmentationExampleForm = new DataAugmentationExampleForms.DataAugmentationExampleForm(imagePath, exCase))
                {
                    dataAugmentationExampleForm.ShowDialog();
                    if (dataAugmentationExampleForm.DialogResultSelected == DialogResult.OK)
                    {
                        minTextBox.Text = dataAugmentationExampleForm.minimumValue;
                        maxTextBox.Text = dataAugmentationExampleForm.maximumValue;
                    }
                }
            }
        }

        private void DataAugmentationGetValue(string exCase, TextBox minTextBox, TextBox maxTextBox)
        {
            string imagePath = null;
            try
            {
                if (WorkSpaceData.m_activeProjectMainger.m_imageListDictionary[WorkSpaceData.m_activeProjectMainger.m_activeInnerProjectName] is ProjectAI.MainForms.UserContral.ImageList.GridViewImageList GridViewImageList)
                {
                    imagePath = GridViewImageList.GetSelectImagePath();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                imagePath = null;
            }
            finally
            {
                using (ProjectAI.DataAugmentationExampleForms.DataAugmentationExampleForm dataAugmentationExampleForm = new DataAugmentationExampleForms.DataAugmentationExampleForm(imagePath, exCase))
                {
                    dataAugmentationExampleForm.ShowDialog();
                    if (dataAugmentationExampleForm.DialogResultSelected == DialogResult.OK)
                    {
                        minTextBox.Text = dataAugmentationExampleForm.minimumValue;
                        maxTextBox.Text = dataAugmentationExampleForm.maximumValue;
                    }
                }
            }
        }

        #endregion 세부 옵션 설정

        #region checkBox 변경 함수

        private void CkbMBlurCheckedChanged(object sender, EventArgs e)
        {
            if (sender is MetroFramework.Controls.MetroCheckBox metroCheckBox)
            {
                if (metroCheckBox.Checked)
                {
                    this.txtBlur.Enabled = metroCheckBox.Checked;
                    this.tilMBlur.Enabled = metroCheckBox.Checked;
                }
                else
                {
                    this.txtBlur.Enabled = metroCheckBox.Checked;
                    this.tilMBlur.Enabled = metroCheckBox.Checked;
                }
            }
        }

        private void CkbBrightnessCheckedChanged(object sender, EventArgs e)
        {
            if (sender is MetroFramework.Controls.MetroCheckBox metroCheckBox)
            {
                if (metroCheckBox.Checked)
                {
                    this.txtBrightnessMin.Enabled = metroCheckBox.Checked;
                    this.txtBrightnessMax.Enabled = metroCheckBox.Checked;
                    this.tilMBrightness.Enabled = metroCheckBox.Checked;
                }
                else
                {
                    this.txtBrightnessMin.Enabled = metroCheckBox.Checked;
                    this.txtBrightnessMax.Enabled = metroCheckBox.Checked;
                    this.tilMBrightness.Enabled = metroCheckBox.Checked;
                }
            }
        }

        private void CkbMCenterCheckedChanged(object sender, EventArgs e)
        {
            if (sender is MetroFramework.Controls.MetroCheckBox metroCheckBox)
            {
                if (metroCheckBox.Checked)
                {
                    this.txtCenter.Enabled = metroCheckBox.Checked;
                    this.tilMCenter.Enabled = metroCheckBox.Checked;
                }
                else
                {
                    this.txtCenter.Enabled = metroCheckBox.Checked;
                    this.tilMCenter.Enabled = metroCheckBox.Checked;
                }
            }
        }

        private void CkbMContrastCheckedChanged(object sender, EventArgs e)
        {
            if (sender is MetroFramework.Controls.MetroCheckBox metroCheckBox)
            {
                if (metroCheckBox.Checked)
                {
                    this.txtContrastMin.Enabled = metroCheckBox.Checked;
                    this.txtContrastMax.Enabled = metroCheckBox.Checked;
                    this.tilMContrast.Enabled = metroCheckBox.Checked;
                }
                else
                {
                    this.txtContrastMin.Enabled = metroCheckBox.Checked;
                    this.txtContrastMax.Enabled = metroCheckBox.Checked;
                    this.tilMContrast.Enabled = metroCheckBox.Checked;
                }
            }
        }

        private void CkbMGaussianNoiseCheckedChanged(object sender, EventArgs e)
        {
            if (sender is MetroFramework.Controls.MetroCheckBox metroCheckBox)
            {
                if (metroCheckBox.Checked)
                {
                    this.txtGaussianNoise.Enabled = metroCheckBox.Checked;
                    this.tilMGaussianNoise.Enabled = metroCheckBox.Checked;
                }
                else
                {
                    this.txtGaussianNoise.Enabled = metroCheckBox.Checked;
                    this.tilMGaussianNoise.Enabled = metroCheckBox.Checked;
                }
            }
        }

        private void CkbMGradationCheckedChanged(object sender, EventArgs e)
        {
            if (sender is MetroFramework.Controls.MetroCheckBox metroCheckBox)
            {
                if (metroCheckBox.Checked)
                {
                    this.txtGradation.Enabled = metroCheckBox.Checked;
                    this.tilMGradation.Enabled = metroCheckBox.Checked;
                }
                else
                {
                    this.txtGradation.Enabled = metroCheckBox.Checked;
                    this.tilMGradation.Enabled = metroCheckBox.Checked;
                }
            }
        }

        private void CkbGradationRGBCheckedChanged(object sender, EventArgs e)
        {
            if (sender is MetroFramework.Controls.MetroCheckBox metroCheckBox)
            {
                if (metroCheckBox.Checked)
                {
                    this.tilMGradationRGB.Enabled = metroCheckBox.Checked;
                }
                else
                {
                    this.tilMGradationRGB.Enabled = metroCheckBox.Checked;
                }
            }
        }

        private void CkbMSharpenCheckedChanged(object sender, EventArgs e)
        {
            if (sender is MetroFramework.Controls.MetroCheckBox metroCheckBox)
            {
                if (metroCheckBox.Checked)
                {
                    this.txtSharpen.Enabled = metroCheckBox.Checked;
                    this.tilMSharpen.Enabled = metroCheckBox.Checked;
                }
                else
                {
                    this.txtSharpen.Enabled = metroCheckBox.Checked;
                    this.tilMSharpen.Enabled = metroCheckBox.Checked;
                }
            }
        }

        private void CkbMZoomCheckedChanged(object sender, EventArgs e)
        {
            if (sender is MetroFramework.Controls.MetroCheckBox metroCheckBox)
            {
                if (metroCheckBox.Checked)
                {
                    this.txtZoomMin.Enabled = metroCheckBox.Checked;
                    this.txtZoomMax.Enabled = metroCheckBox.Checked;
                    this.tilMZoom.Enabled = metroCheckBox.Checked;
                }
                else
                {
                    this.txtZoomMin.Enabled = metroCheckBox.Checked;
                    this.txtZoomMax.Enabled = metroCheckBox.Checked;
                    this.tilMZoom.Enabled = metroCheckBox.Checked;
                }
            }
        }

        #endregion checkBox 변경 함수

        #region Train Option 설정

        /// <summary>
        /// 버튼 더하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEpochNumberPClick(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtEpochNumber.Text, out int epochNumber))
            {
                epochNumber++;
                if (epochNumber <= 999)
                    this.txtEpochNumber.Text = epochNumber.ToString();
            }
            else
            {
                this.txtEpochNumber.Text = "100";
            }
        }

        /// <summary>
        /// 버튼 빼기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEpochNumberSClick(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtEpochNumber.Text, out int epochNumber))
            {
                epochNumber--;
                if (epochNumber >= 0)
                    this.txtEpochNumber.Text = epochNumber.ToString();
                else
                    this.txtEpochNumber.Text = "0";
            }
            else
            {
                this.txtEpochNumber.Text = "100";
            }
        }

        /// <summary>
        /// TextBox 값 확인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtEpochNumberTextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtEpochNumber.Text, out int epochNumber))
            {
                if (epochNumber < 0)
                    this.txtEpochNumber.Text = "0";
                else if (epochNumber > 999)
                    this.txtEpochNumber.Text = "999";
            }
            else
            {
                this.txtEpochNumber.Text = "100";
            }
        }

        /// <summary>
        /// 버튼 더하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMmodelMinimumSelectionEpochPClick(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtMmodelMinimumSelectionEpoch.Text, out int value))
            {
                value++;
                if (value < 999)
                    this.txtMmodelMinimumSelectionEpoch.Text = value.ToString();
            }
            else
            {
                this.txtMmodelMinimumSelectionEpoch.Text = "5";
            }
        }

        /// <summary>
        /// 버튼 뺴기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMmodelMinimumSelectionEpochSClick(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtMmodelMinimumSelectionEpoch.Text, out int value))
            {
                value--;
                if (value >= 0)
                    this.txtMmodelMinimumSelectionEpoch.Text = value.ToString();
            }
            else
            {
                this.txtMmodelMinimumSelectionEpoch.Text = "5";
            }
        }

        /// <summary>
        /// TextBox 값 확인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtMmodelMinimumSelectionEpochTextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtMmodelMinimumSelectionEpoch.Text, out int value))
            {
                if (value < 0)
                    this.txtMmodelMinimumSelectionEpoch.Text = "0";
                else if (value > 999)
                    this.txtMmodelMinimumSelectionEpoch.Text = "999";
            }
            else
            {
                this.txtMmodelMinimumSelectionEpoch.Text = "5";
            }
        }

        /// <summary>
        /// 버튼 더하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPatienceEpochsPClick(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtPatienceEpochs.Text, out int value))
            {
                value++;
                if (value <= 999)
                    this.txtPatienceEpochs.Text = value.ToString();
            }
            else
            {
                this.txtPatienceEpochs.Text = "5";
            }
        }

        /// <summary>
        /// 버튼 빼기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPatienceEpochsSClick(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtPatienceEpochs.Text, out int value))
            {
                value--;
                if (value >= 0)
                    this.txtPatienceEpochs.Text = value.ToString();
            }
            else
            {
                this.txtPatienceEpochs.Text = "5";
            }
        }

        /// <summary>
        /// TextBox 값 확인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtPatienceEpochsTextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtPatienceEpochs.Text, out int value))
            {
                if (value < 0)
                    this.txtPatienceEpochs.Text = "0";
                else if (value > 999)
                    this.txtPatienceEpochs.Text = "999";
            }
            else
            {
                this.txtPatienceEpochs.Text = "5";
            }
        }

        /// <summary>
        /// 버튼 더하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTrainRepeatPClick(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtTrainRepeat.Text, out int value))
            {
                value++;
                if (value <= 999)
                    this.txtTrainRepeat.Text = value.ToString();
            }
            else
            {
                this.txtTrainRepeat.Text = "3";
            }
        }

        /// <summary>
        /// 버튼 빼기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTrainRepeatSClick(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtTrainRepeat.Text, out int value))
            {
                value--;
                if (value >= 0)
                    this.txtTrainRepeat.Text = value.ToString();
            }
            else
            {
                this.txtTrainRepeat.Text = "3";
            }
        }

        /// <summary>
        /// TextBox 값 확인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtTrainRepeatTextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtTrainRepeat.Text, out int value))
            {
                if (value < 0)
                    this.txtTrainRepeat.Text = "0";
                else if (value > 999)
                    this.txtTrainRepeat.Text = "999";
            }
            else
            {
                this.txtTrainRepeat.Text = "3";
            }
        }

        /// <summary>
        /// 더하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnValidationRatioPClick(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtValidationRatio.Text, out int value))
            {
                value++;
                if (value <= 100)
                {
                    this.txtValidationRatio.Text = value.ToString();
                }
                else
                {
                }
            }
            else
            {
                this.txtValidationRatio.Text = "3";
            }
        }

        /// <summary>
        /// 빼기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnValidationRatioSClick(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtValidationRatio.Text, out int value))
            {
                value--;
                if (value >= 0)
                    this.txtValidationRatio.Text = value.ToString();
            }
            else
            {
                this.txtValidationRatio.Text = "3";
            }
        }

        /// <summary>
        ///  TextBox 값 확인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtValidationRatioTextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(this.txtValidationRatio.Text, out float value))
            {
                if (value < 0)
                {
                    this.txtValidationRatio.Text = "0";
                }
                else if (value > 0 && value < 1)
                {
                    this.txtValidationRatio.Text = (value*100).ToString();
                }
                else if (value > 100)
                {
                    this.txtValidationRatio.Text = "100";
                }
            }
            else
            {
                this.txtValidationRatio.Text = "TextChanged ERROR";
            }
        }

        #endregion Train Option 설정

        private void TxtBlurTextChanged(object sender, EventArgs e)
        {
        }

        private void TxtBrightnessMinTextChanged(object sender, EventArgs e)
        {
        }

        private void TxtBrightnessMaxTextChanged(object sender, EventArgs e)
        {
        }
    }
}