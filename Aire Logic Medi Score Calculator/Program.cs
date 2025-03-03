using Aire_Logic_Medi_Score_Calculator;

static int MediScoreCalculator(PatientStatus status)
{
    //Initialises the default score as 0
    int score = 0;

    //Checks whether the breathing state entered matches the int value of the AirOrOxygen enum value Oxygen
    //If it does the score is increased by two
    //If the breathing state doesn't match int int value of either AirOrOxygen enum values then an error message is displayed and the calculation is cancelled
    if(status.BreathingState != ((int)AirOrOxygen.Air) && status.BreathingState != ((int)AirOrOxygen.Oxygen))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nWarning: The patient has not been given a valid breathing state\nPlease enter 0 if they're breathing air or 2 if they're breathing supplemental oxygen\n");
        Console.ForegroundColor = ConsoleColor.White;
        return score;
    }
    if (status.BreathingState == ((int)AirOrOxygen.Oxygen))
    {
        score += 2;
    }

    //Checks whether the consciousness entered matches the int value of the Consciousness enum value Alert
    //If it doesn't then the patient is considered CVPU and the score is increased by three
    if (status.Consciousness != (int)Consciousness.Alert)
    {
        score += 3;
    }

    //The following if and else if statements check the respiration range of the patient and increase the score accordingly
    if (status.RespirationRange >= 9 && status.RespirationRange <= 11)
    {
        score += 1;
    }

    else if (status.RespirationRange >= 21 &&  status.RespirationRange <= 24)
    {
        score += 2;
    }

    else if (status.RespirationRange <= 8 || status.RespirationRange >= 25)
    {
        score += 3;
    }

    //The following if and else if statements check the SpO2 of the patient and increase the score accordingly
    if
    (
        status.SpO2 == 86 || status.SpO2 == 87 ||
        status.SpO2 == 93 && status.BreathingState == (int)AirOrOxygen.Oxygen ||
        status.SpO2 == 94 && status.BreathingState == (int)AirOrOxygen.Oxygen
    )
    {
        score += 1;
    }

    else if
    (
        status.SpO2 == 84 || status.SpO2 == 85 ||
        status.SpO2 == 95 && status.BreathingState == (int)AirOrOxygen.Oxygen ||
        status.SpO2 == 96 && status.BreathingState == (int)AirOrOxygen.Oxygen
    )
    {
        score += 2;
    }

    else if (status.SpO2 <= 83 || status.SpO2 >= 97 && status.BreathingState == (int)AirOrOxygen.Oxygen)
    {
        score += 3;
    }

    //The following if and else if statements check the temperature of the patient and increase the score accordingly
    if (status.Temperature > 35 && status.Temperature <= 36 || status.Temperature > 38 && status.Temperature <= 39)
    {
        score += 1;
    }
    else if (status.Temperature > 39)
    {
        score += 2;
    }
    else if (status.Temperature <= 35)
    {
        score += 3;
    }

    //The following if and else if statement check whether the patient is fasting and their CBG
    //Based on whether the patient is fasting or not the CBG is used to calculate the wellness of the patient and their medi score is increased accordingly
    if
        (
            status.IsFasting && status.CBG >= 3.5 && status.CBG <= 3.9 ||
            status.IsFasting && status.CBG >= 5.5 && status.CBG <= 5.9 ||
            !status.IsFasting && status.CBG >= 4.5 && status.CBG <= 5.8 ||
            !status.IsFasting && status.CBG >= 7.9 && status.CBG <= 8.9 
        )
    {
        score += 2;
    }

    else if 
        (
            status.IsFasting && status.CBG <= 3.4 || status.IsFasting && status.CBG >= 6 ||
            !status.IsFasting && status.CBG <= 4.5 || !status.IsFasting && status.CBG >= 9
        )
    {
        score += 3;
    }


    //The following if statement checks whether the patient's medi score has increased by more than two within the last 24 hours
    //If it has then a warning is displayed to the user entering the patient's status
    if (score > status.LastScore + 2 && status.DateOfLastScore > DateTime.Now.AddHours(-24) && status.DateOfLastScore <= DateTime.Now)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nWarning: The following patient's medi score has increased by more than two points within the last 24 hours\nUrgent care is required");
        Console.ForegroundColor = ConsoleColor.White;
    }

    status.LastScore = score;
    status.DateOfLastScore = DateTime.Now;

    //Returns the score as however much it has increased by at the end of the calculation
    return score;
}

/*
 * Initialisation of the patient objects
 * One with the lowest medi score of 0
 * One with a median medi score of 9
 * And one with the highest medi score possible of 17
*/
PatientStatus patient1 = new PatientStatus(0, 0, 15, 90, 37.2f, false, 6.25f);
PatientStatus patient2 = new PatientStatus(2, 3, 12, 86, 38.53f, false, 4.6f);
PatientStatus patient3 = new PatientStatus(2, 9, 26, 98, 32.347f, true, 6.3249f);

Console.WriteLine("Patient 1's final Medi score is " + MediScoreCalculator(patient1));
Console.WriteLine("Patient 2's final Medi score is " + MediScoreCalculator(patient2));
Console.WriteLine("Patient 3's final Medi score is " + MediScoreCalculator(patient3));

//Showing that if the score of a patient changes by more than two points within 24 hours that a warning message is dispalyed
patient2.RespirationRange = 7;
Console.WriteLine("Patient 2's final Medi score is " + MediScoreCalculator(patient2));
