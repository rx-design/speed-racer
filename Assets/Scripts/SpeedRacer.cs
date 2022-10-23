using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRacer : MonoBehaviour
{
    string carModel = "GTR R35";
    string engineType = "V6, Twin Turbo";
    int carWeight = 1609;
    int yearMade = 2009;
    double maxAcceleration = 0.98;
    bool isCarTypeSedan = false;
    bool hasFrontEngine = true;

    int weightThreshold = 1500;
    int yearThreshold = 2009;

    // Start is called before the first frame update
    void Start()
    {
        print($"The car model is {carModel} and the engine type is {engineType}.");

        CheckWeight();

        if (yearMade <= yearThreshold)
        {
            print($"The car is made in {yearMade}.");

            var carAge = CalculateAge(yearMade);

            print($"The car is {carAge} years old.");
        }
        else
        {
            print($"The car is made in 2010's");
            print($"The car max acceleration is {maxAcceleration}");
        }

        print(CheckCharacteristics());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void CheckWeight()
    {
        if (carWeight < weightThreshold)
        {
            print($"{carModel} weight is less than {weightThreshold} kg.");
        }
        else
        {
            print($"{carModel} weight is more than or equal to {weightThreshold} kg.");
        }
    }

    int CalculateAge(int year)
    {
        var currentYear = DateTime.Now.Year;

        return currentYear - year;
    }

    string CheckCharacteristics()
    {
        if (isCarTypeSedan)
        {
            return "The car type is sedan.";
        }
        else if (hasFrontEngine)
        {
            return "The car is not a sedan, but it has a front engine.";
        }
        else
        {
            return "The car is neither a sedan or has a front engine.";
        }
    }
}
