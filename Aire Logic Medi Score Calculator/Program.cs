using Aire_Logic_Medi_Score_Calculator;

static int MediScoreCalculator(PatientStatus status)
{
    int score = 0;
    if ((int)status.BreathingState == 2)
    {
        score += 2;
    }

    if ((int)status.GetConsciousness != 0)
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
        status.getSpO2 == 93 && status.BreathingState == AirOrOxygen.Oxygen ||
        status.getSpO2 == 94 && status.BreathingState == AirOrOxygen.Oxygen
    )
    {
        score += 1;
    }

    else if
    (
        status.getSpO2 == 84 || status.getSpO2 == 85 ||
        status.getSpO2 == 95 && status.BreathingState == AirOrOxygen.Oxygen ||
        status.getSpO2 == 96 && status.BreathingState == AirOrOxygen.Oxygen
    )
    {
        score += 2;
    }

    else if (status.getSpO2 <= 83 || status.getSpO2 >= 97 && status.BreathingState == AirOrOxygen.Oxygen)
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

    if
        (
            status.GetIsFasting && status.GetCBG >= 3.5 && status.GetCBG <= 3.9 ||
            status.GetIsFasting && status.GetCBG >= 5.5 && status.GetCBG <= 5.9 ||
            !status.GetIsFasting && status.GetCBG >= 4.5 && status.GetCBG <= 5.8 ||
            !status.GetIsFasting && status.GetCBG >= 7.9 && status.GetCBG <= 8.9 
        )
    {
        score += 2;
    }

    else if 
        (
            status.GetIsFasting && status.GetCBG <= 3.4 || status.GetIsFasting && status.GetCBG >= 6 ||
            !status.GetIsFasting && status.GetCBG <= 4.5 || !status.GetIsFasting && status.GetCBG >= 9
        )
    {
        score += 3;
    }

    return score;
}

PatientStatus patient1 = new PatientStatus(AirOrOxygen.Air, Consciousness.Alert, 15, 90, 37.2f, false, 6.25f);
PatientStatus patient2 = new PatientStatus(AirOrOxygen.Oxygen, Consciousness.CVPU, 10, 86, 38.53f, false, 4.6f);
PatientStatus patient3 = new PatientStatus(AirOrOxygen.Oxygen, Consciousness.CVPU, 26, 98, 32.347f, true, 6.3249f);

Console.WriteLine("Patient 1's final Medi score is " + MediScoreCalculator(patient1));
Console.WriteLine("Patient 2's final Medi score is " + MediScoreCalculator(patient2));
Console.WriteLine("Patient 3's final Medi score is " + MediScoreCalculator(patient3));
