namespace Aire_Logic_Medi_Score_Calculator
{
    internal class PatientStatus
    {
        /*
         * The variables used for patient status
         * I originally had breathingState and Conciousness using their enum types but changed them to integers
         * so that users could enter an integer into the object constructor as that looked to be more in line with the design on github
        */
        private int breathingState;
        private int consciousness;
        private int respirationRange;
        private int spO2;
        private float temperature;

        private int lastScore;
        private DateTime dateOfLastScore;

        private bool isFasting;
        private float cbg;

        //The constructor for the class
        //It initialises the class variables and rounds the floats to a single decimal place
        public PatientStatus(int breath, int consc, int resp, int spo2, float temp, bool fasting, float cbg)
        {
            this.breathingState = breath;
            this.consciousness = consc;
            this.respirationRange = resp;   
            this.spO2 = spo2;
            this.temperature = (float)Math.Round(temp, 1);
            this.isFasting = fasting;
            this.cbg = (float)Math.Round(cbg, 1);
        }

        /*
         * Get and set methods for all the class variables
         * Get methods are used in the calculator function
         * Set methods are used outside the calculator function to record any changes to the patients status
         * The class has been structured like this to ensure encapsulation
        */
        public int BreathingState
        {
            get
            {
                return breathingState;
            }
            set
            {
                breathingState = value;
            }
        }

        public int Consciousness
        {
            get
            {
                return consciousness;
            }
            set
            {
                consciousness = value;
            }
        }

        public int RespirationRange
        {
            get
            {
                return respirationRange;
            }
            set
            {
                respirationRange = value;
            }
        }

        public int SpO2
        {
            get
            {
                return spO2;
            }
            set
            {
                spO2 = value;
            }
        }

        public float Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                temperature = value;
            }
        }

        public int LastScore
        {
            get
            {
                return lastScore;
            }
            set
            {
                lastScore = value;
            }
        }

        public DateTime DateOfLastScore
        {
            get
            {
                return dateOfLastScore;
            }
            set
            {
                dateOfLastScore = value;
            }
        }

        public bool IsFasting
        {
            get
            {
                return isFasting;
            }
            set
            {
                isFasting = value;
            }
        }

        public float CBG
        {
            get
            {
                return cbg;
            }
            set
            {
                cbg = value;
            }
        }
    }
}
