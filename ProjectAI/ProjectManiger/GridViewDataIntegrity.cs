using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAI.ProjectManiger
{
    public class GridViewDataIntegrity
    {
        private int numValue;
        private String filesNameValue;
        private String setValue;
        private String labeledValue;
        private String predictionValue;
        private double probabilityValue;

        public GridViewDataIntegrity()
        {
            // Leave fields empty.
        }

        public GridViewDataIntegrity(int num, String filesName, String set, String labeled, String prediction, double probability)
        {
            numValue = num;
            filesNameValue = filesName;
            setValue = set;
            labeledValue = labeled;
            predictionValue = prediction;
            probabilityValue = probability;
        }

        public int Num
        {
            get
            {
                return numValue;
            }
            set
            {
                numValue = value;
            }
        }

        public String FilesName
        {
            get
            {
                return filesNameValue;
            }
            set
            {
                filesNameValue = value;
            }
        }

        public String Set
        {
            get
            {
                return setValue;
            }
            set
            {
                setValue = value;
            }
        }

        public String Labeled
        {
            get
            {
                return labeledValue;
            }
            set
            {
                labeledValue = value;
            }
        }

        public String Prediction
        {
            get
            {
                return predictionValue;
            }
            set
            {
                predictionValue = value;
            }
        }

        public double Probability
        {
            get
            {
                return probabilityValue;
            }
            set
            {
                probabilityValue = value;
            }
        }
    }
}
