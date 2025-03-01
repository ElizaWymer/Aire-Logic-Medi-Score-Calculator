using Aire_Logic_Medi_Score_Calculator;

static int MediScoreCalculator(PatientStatus status)
{
    int score = 0;
    if (status.GetBreathingState == AirOrOxygen.Oxygen)
    {
        score += 2;
    }

    if (status.GetConsciousness != Consciousness.Alert)
    {
        score += 3;
    }

    if (status.GetRespirationRange >= 9 && status.GetRespirationRange <= 11)
    {
        score += 1;
    }

    else if (status.GetRespirationRange >= 21 &&  status.GetRespirationRange <= 24)
    {
        score += 2;
    }

    else if (status.GetRespirationRange <= 8 || status.GetRespirationRange >= 25)
    {
        score += 3;
    }

    if 
    (
        status.getSpO2 == 86 || status.getSpO2 == 87 ||
        status.getSpO2 == 93 && status.GetBreathingState == AirOrOxygen.Oxygen ||
        status.getSpO2 == 94 && status.GetBreathingState == AirOrOxygen.Oxygen
    )
    {
        score += 1;
    }

    else if
    (
        status.getSpO2 == 84 || status.getSpO2 == 85 ||
        status.getSpO2 == 95 && status.GetBreathingState == AirOrOxygen.Oxygen ||
        status.getSpO2 == 96 && status.GetBreathingState == AirOrOxygen.Oxygen
    )
    {
        score += 2;
    }

    else if (status.getSpO2 <= 83 || status.getSpO2 >= 97 && status.GetBreathingState == AirOrOxygen.Oxygen)
    {
        score += 3;
    }

    if (status.GetTemperature > 35 && status.GetTemperature <= 36 || status.GetTemperature > 38 && status.GetTemperature <= 39)
    {
        score += 1;
    }
    else if (status.GetTemperature > 39)
    {
        score += 2;
    }
    else if (status.GetTemperature <= 35)
    {
        score += 3;
    }

    return score;
}

PatientStatus patient1 = new PatientStatus(AirOrOxygen.Air, Consciousness.Alert, 15, 90, 37);

Console.WriteLine("The patient's final Medi score is " + MediScoreCalculator(patient1));
