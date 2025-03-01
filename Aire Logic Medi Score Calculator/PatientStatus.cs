namespace Aire_Logic_Medi_Score_Calculator
{
    internal class PatientStatus
    {
        private AirOrOxygen breathingState;
        private Consciousness consciousness;
        private int respirationRange;
        private int spO2;
        private float temperature;
        private bool isFasting;
        private float CBG;

        public PatientStatus(AirOrOxygen breath, Consciousness consc, int resp, int spo2, float temp, bool fasting, float cbg)
        {
            this.breathingState = breath;
            this.consciousness = consc;
            this.respirationRange = resp;   
            this.spO2 = spo2;
            this.temperature = (float)Math.Round(temp, 1);
            this.isFasting = fasting;
            this.CBG = (float)Math.Round(cbg, 1);
        }

        public AirOrOxygen BreathingState
        {
            get
            {
                return breathingState;
            }
        }

        public Consciousness GetConsciousness
        {
            get
            {
                return consciousness;
            }
        }

        public int GetRespirationRange
        {
            get
            {
                return respirationRange;
            }
        }

        public int getSpO2
        {
            get
            {
                return spO2;
            }
        }

        public float GetTemperature
        {
            get
            {
                return temperature;
            }
        }

        public bool GetIsFasting
        {
            get
            {
                return isFasting;
            }
        }

        public float GetCBG
        {
            get
            {
                return CBG;
            }
        }
    }
}
