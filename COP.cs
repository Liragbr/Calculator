using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Advanced Programmer Calculator");

        while (true)
        {
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Bitwise AND");
            Console.WriteLine("6. Bitwise OR");
            Console.WriteLine("7. Bitwise XOR");
            Console.WriteLine("8. Left Shift");
            Console.WriteLine("9. Right Shift");
            Console.WriteLine("10. Number System Conversion");
            Console.WriteLine("0. Exit");

            Console.Write("Option: ");
            string option = Console.ReadLine();

            if (option == "0")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            List<double> numbers = new List<double>();

            while (true)
            {
                Console.WriteLine("Leave blank to end input");
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
                }
            }

            try
            {
                double result = 0;

                switch (option)
                {
                    case "1":
                        result = Addition(numbers);
                        break;
                    case "2":
                        result = Subtraction(numbers);
                        break;
                    case "3":
                        result = Multiplication(numbers);
                        break;
                    case "4":
                        result = Division(numbers);
                        break;
                    case "5":
                        result = BitwiseAND(numbers);
                        break;
                    case "6":
                        result = BitwiseOR(numbers);
                        break;
                    case "7":
                        result = BitwiseXOR(numbers);
                        break;
                    case "8":
                        Console.Write("Enter the number of positions to shift left: ");
                        int leftShift = Convert.ToInt32(Console.ReadLine());
                        result = LeftShift(numbers[0], leftShift);
                        break;
                    case "9":
                        Console.Write("Enter the number of positions to shift right: ");
                        int rightShift = Convert.ToInt32(Console.ReadLine());
                        result = RightShift(numbers[0], rightShift);
                        break;
                    case "10":
                        Console.WriteLine("Choose the destination number system:");
                        Console.WriteLine("1. Binary");
                        Console.WriteLine("2. Octal");
                        Console.WriteLine("3. Hexadecimal");
                        Console.Write("choose the desired option: ");
                        int baseDestination = Convert.ToInt32(Console.ReadLine());

                        string resultConverted = ConvertNumberSystem(result, baseDestination);
                        Console.WriteLine($"Result: {resultConverted}");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("------------------------------");
        }
    }

    static double Addition(List<double> numbers)
    {
        return numbers.Sum();
    }

    static double Subtraction(List<double> numbers)
    {
        double result = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            result -= numbers[i];
        }
        return result;
    }

    static double Multiplication(List<double> numbers)
    {
        double result = 1;
        foreach (double num in numbers)
        {
            result *= num;
        }
        return result;
    }

    static double Division(List<double> numbers)
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

    static double BitwiseAND(List<double> numbers)
    {
        long result = (long)numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            result &= (long)numbers[i];
        }
        return result;
    }

    static double BitwiseOR(List<double> numbers)
    {
        long result = (long)numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            result |= (long)numbers[i];
        }
        return result;
    }

    static double BitwiseXOR(List<double> numbers)
    {
        long result = (long)numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            result ^= (long)numbers[i];
        }
        return result;
    }

    static double LeftShift(double number, int shift)
    {
        return (long)number << shift;
    }

    static double RightShift(double number, int shift)
    {
        return (long)number >> shift;
    }

    static string ConvertNumberSystem(double number, int baseDestination)
    {
        if (baseDestination < 2 || baseDestination > 16)
            throw new ArgumentException("Invalid base destination. It must be between 2 and 16.");

        if (baseDestination == 10)
            return number.ToString();

        long integerPart = (long)number;
        double fractionalPart = number - integerPart;

        string integerPartStr = Convert.ToString(integerPart, baseDestination).ToUpper();
        string fractionalPartStr = ConvertFractionalPartToBase(fractionalPart, baseDestination);

        if (fractionalPartStr == "")
            return integerPartStr;
        else
            return $"{integerPartStr}.{fractionalPartStr}";
    }

    static string ConvertFractionalPartToBase(double fractionalPart, int baseDestination)
    {
        const int MaxFractionalPartLength = 20; // Maximum length for the fractional part

        List<char> result = new List<char>();
        int count = 0;

        while (fractionalPart > 0 && count < MaxFractionalPartLength)
        {
            fractionalPart *= baseDestination;
            int digit = (int)fractionalPart;
            result.Add(GetCharFromDigit(digit));
            fractionalPart -= digit;
            count++;
        }

        return new string(result.ToArray());
    }

    static char GetCharFromDigit(int digit)
    {
        if (digit < 10)
            return (char)('0' + digit);
        else
            return (char)('A' + digit - 10);
    }
}
