using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAI.MainForms
{
    public partial class ImageCountLabel : UserControl
    {
        public ImageCountLabel()
        {
            InitializeComponent();
        }

        #region ProjectImageCount 속성 추가
        [Category("ProjectImageCount"), Description("Image Count Name")]
        public string ImageCountName
        {
            get
            {
                return this.lblimageCountName.Text;
            }
            set
            {
                this.lblimageCountName.Text = value;
            }
        }
        [Category("ProjectImageCount"), Description("Image Count Name")]
        public string ImageCount
        {
            get
            {
                return this.lblimageCount.Text;
            }
            set
            {
                try
                {
                    double number = Convert.ToSingle(value);
                    Console.WriteLine(value);

                    if (number / 1000000 >= 1)
                    {
                        lblimageCount.Font = new Font(lblimageCountName.Font.Name, 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                        //Console.WriteLine("8.25F");
                    }
                    else if (number / 100000 >= 1)
                    {
                        lblimageCount.Font = new Font(lblimageCountName.Font.Name, 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                        //Console.WriteLine("9.75F");
                    }
                    else if (number / 10000 >= 1)
                    {
                        lblimageCount.Font = new Font(lblimageCountName.Font.Name, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                        //Console.WriteLine("12F");
                    }
                    else if (number / 1000 >= 1)
                    {
                        lblimageCount.Font = new Font(lblimageCountName.Font.Name, 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                        //Console.WriteLine("15.75F");
                    }
                    else if (number / 100 >= 1)
                    {
                        lblimageCount.Font = new Font(lblimageCountName.Font.Name, 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                        //Console.WriteLine("17.25F");
                    }
                    else
                    {
                        lblimageCount.Font = new Font(lblimageCountName.Font.Name, 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                        //Console.WriteLine("24F");
                    }

                    this.lblimageCount.Text = value;
                }
                catch
                {
                    this.lblimageCount.Text = "ERROR";
                }
            }
        }
        #endregion
    }
}
