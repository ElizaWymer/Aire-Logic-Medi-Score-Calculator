# Aire Logic Medi Score Calculator #

The system requires the user to create an object representing a patient containing statistics such as the patient's respiration rate and their temperature to calculate a measure for their health.
The object is then passed through a function that through a series of if and else if statements calculates and returns a score representatitve of their health.
It does this by comparing the objects attributes to the integer values of enums or predetermined numerical boundries and increasing the score accordingly.
The score ranges from 0-17 when taking cellular blood glucose into consideration. Earlier versions of the code had a score that only ranged from 1-14.

I chose to use an object to be passed through the function rather than the raw parameters as it makes the function call look cleaner.
The object itself uses integers and floats to represent the patients status as well as a boolean property to represent whether they're fasting.
I considered using a third enum for fasting but their were no requirements for it to be an enum and it's a binary system so I chose to use a boolean.
The rest of the class is comprised of a constructor as well as get methods used in the calculator and set methods used for updating a patient's status.
