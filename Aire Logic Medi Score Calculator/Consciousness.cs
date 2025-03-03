namespace Aire_Logic_Medi_Score_Calculator
{
    //The enum used to measure the consciousness of a patient
    //If the user enters a 0 for this property the patient will be recorded as alert
    //As such the medi score will not increase

    //If the user enters an integer other than 0 the patient will be recorded as CVPU
    //As a result the medi score will increase by 3
    internal enum Consciousness
    {
        Alert = 0,
        CVPU
    }
}