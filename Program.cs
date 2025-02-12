using System;
class SimpleCalculator
{
    static void Calculator() 
    {
        while (true)
        {
            double num1 = GetValidNumber("Enter the first number (Example: 1): ");
            string operation = GetValidOperator("Enter the operation (Example: +, -, *, /): ");
            double num2 = GetValidNumber("Enter the second number (Example: 2): ");

            double result = 0;
            switch (operation)
            {
                case "+": result = num1 + num2; break;
                case "-": result = num1 - num2; break;
                case "*": result = num1 * num2; break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("❌ Error: Cannot divide by zero.");
                        continue;
                    }
                    result = num1 / num2;
                    break;
            }

            Console.WriteLine($"Result: {num1} {operation} {num2} = {result}\n");

            Console.Write("Do you want to perform another calculation? (yes/no): ");
            string choice = Console.ReadLine()?.ToLower() ??"0";
            if (choice != "yes") break;
        }
    }

    public static void Main() 
    {
        Calculator(); //this works because Calculator() is already defined above
    }

    static double GetValidNumber(string message)
    {
        double number;
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine() ??"0";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
                continue;
            }

            if (double.TryParse(input, out number))
            {
                return number;
            }

            Console.WriteLine("Invalid input! Please enter a valid number. Example: 1 or 2 ");
        }
    }

    static string GetValidOperator(string message)
    {
        string[] validOperators = { "+", "-", "*", "/" };
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? "0";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input! Please enter a valid operator.");
                continue;
            }

            if (Array.Exists(validOperators, op => op == input))
            {
                return input;
            }

            Console.WriteLine("Invalid operation! Please enter a valid operator +, -, *, or /. Example: +");
        }
    }
}
