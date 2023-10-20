using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static double Addition(List<double> numbers)
    {
        return numbers.Sum();
    }

    public static double Subtraction(List<double> numbers)
    {
        double result = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            result -= numbers[i];
        }
        return result;
    }

    public static double Multiplication(List<double> numbers)
    {
        double result = 1;
        foreach (double num in numbers)
        {
            result *= num;
        }
        return result;
    }

    public static double Division(List<double> numbers)
    {
        double result = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] == 0)
            {
                throw new ArgumentException("Cannot divide by zero");
            }
            result /= numbers[i];
        }
        return result;
    }

    public static double Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Cannot calculate factorial of a negative number");
        }
        if (number == 0)
        {
            return 1;
        }
        else
        {
            return number * Factorial(number - 1);
        }
    }

    public static double SquareRoot(double number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Cannot calculate square root of a negative number");
        }
        else
        {
            if (number == 0)
            {
                return 0;
            }

            double x = number;
            while (true)
            {
                double nextX = 0.5 * (x + number / x);
                if (Math.Abs(x - nextX) < 1e-9)
                {
                    return nextX;
                }
                x = nextX;
            }
        }
    }

    static void Main(string[] args)
    {
        double result = 0;
        List<double> numbers = new List<double>();

        while (true)
        {
            Console.WriteLine("Scientific Calculator");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Factorial");
            Console.WriteLine("6. Square Root");
            Console.WriteLine("7. Exit");

            Console.Write("\n(1/2/3/4/5/6/7)\nChoose the desired operation: ");
            string choice = Console.ReadLine();

            if (choice == "7")
            {
                Console.WriteLine("Exiting the calculator");
                break;
            }

            if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6")
            {
                Console.WriteLine("\nInvalid operation. Please choose a valid option (1/2/3/4/5/6/7).\n");
                continue;
            }

            if (choice != "5" && choice != "6")
            {
                numbers = new List<double>();
                while (true)
                {
                    Console.WriteLine("leave blank to end input");
                    string numStr = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(numStr))
                    {
                        break;
                    }
                    if (double.TryParse(numStr, out double num))
                    {
                        numbers.Add(num);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please make sure you entered valid numbers.");
                        continue;
                    }
                }
            }

            if (choice == "1")
            {
                result = Addition(numbers);
            }
            else if (choice == "2")
            {
                result = Subtraction(numbers);
            }
            else if (choice == "3")
            {
                result = Multiplication(numbers);
            }
            else if (choice == "4")
            {
                try
                {
                    result = Division(numbers);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            else if (choice == "5")
            {
                Console.Write("Enter a number for factorial: ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    result = Factorial(num);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for factorial.");
                    continue;
                }
            }
            else if (choice == "6")
            {
                Console.Write("Enter a number for square root: ");
                if (double.TryParse(Console.ReadLine(), out double num))
                {
                    try
                    {
                        result = SquareRoot(num);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for square root calculation.");
                    continue;
                }
            }

            Console.WriteLine($"\nResult is: {result}\n");
        }
    }
}
