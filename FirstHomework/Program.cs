using System;


namespace FirstHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter a mathematical expression (like 1 + 2) or type exit to quit: ");
                    string expression = Console.ReadLine();
                    if (expression.ToLower() == "exit")
                        break;

                    Calculator(expression);
                    Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                static void Clear()
                {
                    Console.WriteLine();
                    Console.WriteLine("If you want to exit write 1");
                    Console.WriteLine("If you want to continue write 2");
                    Console.Write("Please choose what you would like to do: ");
                    string number = Console.ReadLine();
                    int option = 0;
                    while (!int.TryParse(number, out option))
                    {
                        Console.Write("Your input is empty. Try again: ");
                        number = Console.ReadLine();

                    }

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Bye!");
                            Environment.Exit(0);
                            break;

                        case 2:
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Incorrect output. Try again.");
                            break;

                    }
                }


            }


        }
        static void Addition(double x, double y)
        {
            Console.WriteLine($"Your result is: {x + y} ");
        }

        static void Substraction(double x, double y)
        {
            Console.WriteLine($"Your result is: {x - y} ");
        }

        static void Multipication(double x, double y)
        {
            Console.WriteLine($"Your result is: {x * y} ");
        }

        static double Division(double x, double y)
        {
            if (y == 0)
            {
                Console.WriteLine("You cannot divide by zero! ");
                return double.NaN;
            }
            else
                return x / y; 
        }

        static void Exponentiation(double x, double y)
        {

            double result = Math.Pow(x, y);

            Console.WriteLine($"Your result is: {result}");

        }

        static void Factorial(ulong x)
        {

            if (x == 0)
            {
                Console.WriteLine("Your result is: 1");
            }

            else
            {
                ulong resultx = 1;


                for (ulong i = x; i > 1; i--)
                {
                    resultx *= i;
                }

                Console.WriteLine($"Your result is: {resultx} ");
            }

        }

        static void Calculator(string expression)
        {
            expression = expression.Replace(" ", "");

            if (string.IsNullOrWhiteSpace(expression))
                throw new Exception("Your input is empty.");


            string operation = "";
            string firstChar = "";
            double firstNumber = 0;
            double secondNumber = 0;
            char[] signs = ['!', '+', '/', '*', '^', '-'];

            //removing char from signs before mathematical expression
            for (int i = 0; i < signs.Length; i++)
            {
                if (expression[0] == signs[i])
                {
                    firstChar = expression[0].ToString();
                    expression = expression.Remove(0, 1);
                    break;
                }

            }

            for (int i = 0; i < signs.Length; i++)
            {

                string[] parts = expression.Split(signs[i]);

                if (parts[0] != expression)
                {
                    if (firstChar == "-")
                        parts[0] = "-" + parts[0];

                    operation = signs[i].ToString();
                    firstNumber = Convert.ToDouble(parts[0]);

                    if (signs[i] != '!')
                    {
                        if (parts.GetLength(0) > 2)
                            parts[1] = operation + parts[2];
                        secondNumber = Convert.ToDouble(parts[1]);
                    }

                    break;
                }

            }


            switch (operation)
            {

                case "+":
                    Addition(firstNumber, secondNumber);
                    break;

                case "-":
                    Substraction(firstNumber, secondNumber);
                    break;

                case "*":
                    Multipication(firstNumber, secondNumber);
                    break;

                case "/":
                    Console.WriteLine($"Your result is: {Division(firstNumber, secondNumber)}");
                    break;

                case "^":
                    Exponentiation(firstNumber, secondNumber);
                    break;

                case "!":
                    if (firstNumber < 0)
                    {
                        Console.WriteLine("Factorial is not possible for negative numbers ");

                    }
                    else if (firstNumber > 20)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Second number is to high. I can only count to number 20. Please try again.");
                    }
                    else
                        Factorial((ulong)firstNumber);
                    break;

                default:
                    Console.WriteLine("Incorrect output. Try again.");
                    Console.WriteLine();
                    break;

            }

        }
    }
}
