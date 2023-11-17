using System;
using System.Collections.Generic;

class Program
{
    static List<UserData> userDataList = new List<UserData>();

    static void Main()
    {
        Console.WriteLine("BMI Calculator");

        while (true)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1 - Calculate BMI");
            Console.WriteLine("2 - Show history");
            Console.WriteLine("3 - Exit");

            int option = GetInteger("Choose an option: ");

            switch (option)
            {
                case 1:
                    CalculateBMI();
                    break;
                case 2:
                    ShowHistory();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CalculateBMI()
    {
        Console.WriteLine("\nEnter your data:");

        string name = GetText("Name: ");
        int age = GetInteger("Age: ");
        double weightInKg = GetDouble("Weight (in kg): ");
        double heightInCm = GetDouble("Height (in cm): ");
        double heightInM = heightInCm / 100.0; // Convert to meters

        double bmi = CalculateBMI(weightInKg, heightInM);
        string classification = ClassifyBMI(bmi);

        UserData userData = new UserData(name, age, weightInKg, heightInM, bmi, classification);
        userDataList.Add(userData);

        Console.WriteLine($"\nResult for {name}, {age} years:");
        Console.WriteLine($"Weight: {weightInKg} kg ({WeightInPounds(weightInKg):F2} lbs)");
        Console.WriteLine($"Height: {heightInCm} cm");
        Console.WriteLine($"BMI: {bmi:F2}");
        Console.WriteLine($"Classification: {classification}");
    }

    static void ShowHistory()
    {
        Console.WriteLine("\nHistory of Results:");

        foreach (var userData in userDataList)
        {
            Console.WriteLine($"\nName: {userData.Name}");
            Console.WriteLine($"Age: {userData.Age} years");
            Console.WriteLine($"Weight: {userData.Weight} kg ({WeightInPounds(userData.Weight):F2} lbs)");
            Console.WriteLine($"Height: {userData.Height * 100} cm");
            Console.WriteLine($"BMI: {userData.BMI:F2}");
            Console.WriteLine($"Classification: {userData.Classification}");
        }
    }

    static double CalculateBMI(double weight, double height)
    {
        return weight / (height * height);
    }

    static string ClassifyBMI(double bmi)
    {
        if (bmi < 18.5)
            return "Underweight";
        else if (bmi < 24.9)
            return "Normal weight";
        else if (bmi < 29.9)
            return "Overweight";
        else if (bmi < 34.9)
            return "Obesity class 1";
        else if (bmi < 39.9)
            return "Obesity class 2";
        else
            return "Obesity class 3";
    }

    static string GetText(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    static int GetInteger(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;
            else
                Console.WriteLine("Please enter a valid integer.");
        }
    }

    static double GetDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double result))
                return result;
            else
                Console.WriteLine("Please enter a valid number.");
        }
    }

    static double WeightInPounds(double weightInKg)
    {
        const double poundsPerKg = 2.20462;
        return weightInKg * poundsPerKg;
    }
}

class UserData
{
    public string Name { get; }
    public int Age { get; }
    public double Weight { get; }
    public double Height { get; }
    public double BMI { get; }
    public string Classification { get; }

    public UserData(string name, int age, double weight, double height, double bmi, string classification)
    {
        Name = name;
        Age = age;
        Weight = weight;
        Height = height;
        BMI = bmi;
        Classification = classification;
    }
}
