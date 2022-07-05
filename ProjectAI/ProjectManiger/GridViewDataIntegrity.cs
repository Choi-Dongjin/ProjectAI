using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAI.ProjectManiger
{
    public class GridViewDataIntegrity
    {
        private String numValue;
        private String filesNameValue;
        private String setValue;
        private String labeledValue;
        private String predictionValue;
        private String probabilityValue;
        private String addressValue;

        public GridViewDataIntegrity()
        {
            // Leave fields empty.
        }

        public GridViewDataIntegrity(String num, String filesName, String set, String labeled, String prediction, String probability)
        {
            numValue = num;
            filesNameValue = filesName;
            setValue = set;
            labeledValue = labeled;
            predictionValue = prediction;
            probabilityValue = probability;
        }

        public GridViewDataIntegrity(String num, String filesName, String address)
        {
            numValue = num;
            filesNameValue = filesName;
            addressValue = address;
        }

        public String Num
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

        public String Probability
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

        public String Address
        {
            get
            {
                return addressValue;
            }
            set
            {
                addressValue = value;
            }
        }
    }
}
