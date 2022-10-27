using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedRacer : MonoBehaviour
{
    class Fuel
    {
        public int fuelLevel;

        public Fuel(int amount)
        {
            fuelLevel = amount;
        }
    }

    Fuel carFuel = new Fuel(100);

    public string carMaker;
    public string carModel = "GTR R35";
    public string engineType = "V6, Twin Turbo";
    public int carWeight = 1609;
    public int yearMade = 2009;
    public double maxAcceleration = 0.98;
    public bool isCarTypeSedan = false;
    public bool hasFrontEngine = true;

    int weightThreshold = 1500;
    int yearThreshold = 2009;

    private TextMeshProUGUI carInfo;
    private TextMeshProUGUI fuelInfo;

    private void Awake()
    {
        carInfo = GameObject
            .Find("CarInfo")
            .GetComponent<TextMeshProUGUI>();

        fuelInfo = GameObject
            .Find("FuelInfo")
            .GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateCarInfo($"The car model is {carModel} ({carMaker}) and the engine type is {engineType}.");

        CheckWeight();

        if (yearMade <= yearThreshold)
        {
            UpdateCarInfo($"The car is made in {yearMade}.");

            var carAge = CalculateAge(yearMade);

            UpdateCarInfo($"The car is {carAge} years old.");
        }
        else
        {
            UpdateCarInfo($"The car is made in 2010's");
            UpdateCarInfo($"The car max acceleration is {maxAcceleration}");
        }

        UpdateCarInfo(CheckCharacteristics());
    }

    // Update is called once per frame
    void Update()
    {
        CheckFuelLevel();
    }

    void CheckWeight()
    {
        if (carWeight < weightThreshold)
        {
            UpdateCarInfo($"{carModel} weight is less than {weightThreshold} kg.");
        }
        else
        {
            UpdateCarInfo($"{carModel} weight is more than or equal to {weightThreshold} kg.");
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

    public void ConsumeFuel()
    {
        carFuel.fuelLevel = Math.Max(0, carFuel.fuelLevel - 10);
    }

    void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel)
        {
            case 70:
                UpdateFuelInfo("The fuel level is nearing two-thirds.");
                break;
            case 50:
                UpdateFuelInfo("The fuel level is at half amount.");
                break;
            case 10:
                UpdateFuelInfo("Warning! Fuel level is critically low.");
                break;
            default:
                UpdateFuelInfo($"The fuel level is {carFuel.fuelLevel}.");
                break;
        }
    }

    void UpdateCarInfo(string text)
    {
        if (carInfo.text != "")
        {
            carInfo.text += "\n";
        }

        carInfo.text += text;
    }

    void UpdateFuelInfo(string text)
    {
        fuelInfo.text = text;
    }
}
