namespace Aire_Logic_Medi_Score_Calculator
{
    internal class PatientStatus
    {
        private AirOrOxygen breathingState;
        private Consciousness consciousness;
        private int respirationRange;
        private int spO2;
        private float temperature;

        public PatientStatus(AirOrOxygen breath, Consciousness consc, int resp, int spo2, float temp)
        {
            this.breathingState = breath;
            this.consciousness = consc;
            this.respirationRange = resp;   
            this.spO2 = spo2;
            this.temperature = temp;
        }

        public AirOrOxygen GetBreathingState
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
    }
}
