namespace Aire_Logic_Medi_Score_Calculator
{
    //The enum used to track whether the patient is breathing air or is using supplemental oxygen
    //If the user enters 0 for this property the patient will be recorded as breathing air
    //The patient's medi score will not increase

    //If the user enters 2 then the patient will be recorded as breathing supplemental oxygen
    //As a result the patients medi score will increase by two and the SpO2 calculation will take this into account
    internal enum AirOrOxygen
    {
        Air = 0,
        Oxygen = 2
    }
}
