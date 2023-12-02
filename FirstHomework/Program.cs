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



                static double GetNumber()
                {
                    if (!double.TryParse(Console.ReadLine(), out double input))
                        throw new Exception("Your input is not a number. Try again. ");

                    return input;
                }

                static void Clear()
                {
                    Console.WriteLine();
                    Console.WriteLine("If you want to exit write 1");
                    Console.WriteLine("If you want to continue write 2");
                    Console.Write("Please choose what you would like to do: ");
                    var Option = GetNumber();

                    switch (Option)
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

        static void Division(double x, double y)
        {
            if (y == 0)
                Console.WriteLine("You cannot divide by zero! ");
            else
                Console.WriteLine($"Your result is: {x / y} ");
        }

        static void Exponentiation(double x, double y)
        {

            double result = Math.Pow(x, y);

            Console.WriteLine($"Your result is: {result}");

        }

        static void Factorial(ulong x)
        {
            if (x < 0)
            {
                Console.WriteLine("Factorial is not possible for negative numbers ");

            }
            
            else if (x == 0) 
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

                Console.WriteLine($"Your result is: {resultx} for x");
            }

        }

        static void Calculator(string expression)
        {
            expression = expression.Replace(" ", "");

            if (string.IsNullOrWhiteSpace(expression))
                throw new Exception("Your input is empty.");


            string operation = "";
            double firstNumber = 0;
            double secondNumber = 0;
            char[] signs = ['!', '-', '+', '/', '*', '^'];

            for(int i = 0; i < signs.Length; i++)
            {
                /*
                 * if before first number is one of signes we need to secure 
                 * operation of splitting string
                 * but tommorrow :)
                 */
                string[] parts = expression.Split(signs[i]);
                if (parts[0] != expression)
                {
                    operation = signs[i].ToString();
                    firstNumber = Convert.ToDouble(parts[0]);

                    if (signs[i] != '!') {
                        if (parts.GetLength(0) > 2)
                            parts[1] = operation + parts[2];
                        var d = parts.GetLength(0);
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
                    Division(firstNumber, secondNumber);
                    break;

                case "^":
                    Exponentiation(firstNumber, secondNumber);
                    break;

                case "!":
                    Factorial((ulong)firstNumber);
                    break;

                default:
                    Console.WriteLine("Incorrect output. Try again.");
                    break;

            }

        }
    }
}
