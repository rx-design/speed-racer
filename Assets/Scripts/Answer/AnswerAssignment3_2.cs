using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************
 * _______   BASICS OF GAME DEVELOPMENT   _______
 * _______    ANSWER OF ASSIGNMENT 3.2    _______
 * 
 ***********************************************/

public class AnswerAssignment3_2 : MonoBehaviour
{
    // Declare and initialise the car's information
    public string carMaker;
    public string carModel = "GTR R35";
    public string engineType = "V6, Twin Turbo";

    public int carWeight = 1609;
    public int yearMade = 2009;

    public float maxAcceleration = 0.98f;

    public bool isCarTypeSedan = false;
    public bool hasFrontEngine = true;

    // Create a subclass to handle the fuel information
    public class Fuel
    {
        // Make the variable public to be accessible using the dot (.) notation
        public int fuelLevel;

        // Create a custom constructor which takes an integer value (amount)
        public Fuel(int amount)
        {
            // initialize the fuelAmount variable with the value of amount during the creation of the Fuel instance/object
            fuelLevel = amount;
        }
    }

    // Create a variable to hold a new instance of the Fuel class, so we can store information and re-use it
    // Notice how the data type is the same name of the class the variable is going to hold in it
    public Fuel carFuel = new Fuel(100);


    // Start is called before the first frame update
    void Start()
    {
        // Show in Console the car model and engine type. Use the + sign to combine (concatenate) regular text with variable names
        print("The racer model is " + carModel + " by " + carMaker + ". It has a " + engineType + " engine.");

        // Check if the car weighs less than 1500 kg.
        // This is a function call to the function named 'CheckWeight', which is defined further below
        CheckWeight();

        /* If the car is made in the year 2009 or earlier, do what is in the first block of curly braces
         * otherwise, do what is in the second block of braces directly after it (marked by 'else' keyword).
         */
        if (yearMade <= 2009)
        {
            print("It was first introduced in " + yearMade);

            // Call the 'CalculateAge' function, passing the 'yearMade' variable as the argument. Then, store the return result in 'carAge' variable.
            int carAge = CalculateAge(yearMade);

            print("That makes it " + carAge + " years old.");

        }
        else
        {
            print("It was introduced in the 2010's");
            print("And its maximum acceleration is " + maxAcceleration + " m/s2");
        }

        print(CheckCharacteristics());
    }

    // Use the Update function to continuously check for player input
    void Update()
    {
        // If the player presses down the Spacebar button, adjust the car fuel level
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConsumeFuel();
            CheckFuelLevel();
        }
    }

    // Reduce the amount of fuel the car has
    void ConsumeFuel()
    {
        // Subtract 10 from fuelLevel by re-assigning the variable a new value, which is its old value minus 10
        carFuel.fuelLevel = carFuel.fuelLevel - 10;
    }

    // Check the fuel level and report to console at certain fuel levels
    void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel)
        {
            case 70:
                print("Fuel level is nearing two-thirds.");
                break;
            case 50:
                print("Fuel level is at half amount.");
                break;
            case 10:
                print("Warning! Fuel level is critically low.");
                break;
            default:
                print("Nothing to report.");
                break;
        }
    }

    // This function checks if the car weight is less than 1500 kg or not, and prints a console message accordingly
    void CheckWeight()
    {
        /* if the weight is less than 1500, do what is in the first block of curly braces
         * otherwise, do what is in the second block of curly braces (after the 'else' keyword)
         */
        if (carWeight < 1500)
        {
            print("The " + carModel + " weighs less than 1500 kg.");
        }
        else
        {
            print("The " + carModel + " weighs over 1500 kg.");
        }
    }

    // This function calculates, and returns, how old the car is with respect to the year 2021
    int CalculateAge(int yearMade)
    {
        return 2021 - yearMade;
    }

    // Check if the car is a sedan type, or if it has a front engine.
    string CheckCharacteristics()
    {
        /* First check if the car is a sedan. If not, then check if it has a front engine.
         * Notice in the Console window how only one message is shown. Depending on which check is passed, only one block will be triggered.
         */
        if (isCarTypeSedan)
        {
            return "The car is a sedan type.";

        }
        else if (hasFrontEngine)
        {
            return "The car is not a sedan, but has a front engine.";

        }
        else
        {
            return "The car is neither a sedan, nor is its engine a front engine.";
        }
    }
}
