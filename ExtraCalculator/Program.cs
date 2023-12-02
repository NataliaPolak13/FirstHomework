namespace ExtraCalculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
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
                    var option = GetNumber();

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

                try
                {
                    Console.WriteLine("It's a calculator. Please write two numbers: ");
                    Console.Write("Your first number: ");
                    var numberOne = GetNumber();
                    Console.Write("Your second number: ");
                    var numberTwo = GetNumber();
                    Menu();
                    Console.Write("Please select what would you like to do: ");
                    var option = Convert.ToInt32(Console.ReadLine());
                    Calculator(numberOne, numberTwo, option);
                    Clear();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Clear();
                }


            }

        }
        static void Menu()
        {
            Console.WriteLine("1 is addition");
            Console.WriteLine("2 is substraction");
            Console.WriteLine("3 is multipication");
            Console.WriteLine("4 is division");
            Console.WriteLine("5 is exponentiation");
            Console.WriteLine("6 is factorial");
            Console.WriteLine("Press 7 to end program");
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

        static void Factorial(ulong x, ulong y)
        {
            if ((x < 0) || (y < 0))
            {
                Console.WriteLine("Factorial is not possible for negative numbers ");

            }
            else if ((x > 20) || (y > 20))
            {
                if ((x > 20) && (y > 20))
                {
                    Console.WriteLine();
                    Console.WriteLine("Both numbers are to high. I can only count to number 20. Please try again.");
                }
                else if (y > 20)
                {
                    Console.WriteLine();
                    Console.WriteLine("Second number is to high. I can only count to number 20. Please try again.");
                }
                else
                    Console.WriteLine("First number is to high. I can only count to number 20. Please try again.");

            }
            else if ((x == 0) || (y == 0))
            {
                Console.WriteLine("Your result is: 1");
            }
            else
            {
                ulong resultx = 1;
                ulong resulty = 1;

                for (ulong i = y; i > 1; i--)
                {
                    resulty *= i;
                }

                for (ulong i = x; i > 1; i--)
                {
                    resultx *= i;
                }

                Console.WriteLine($"Your result is: {resultx} for x, and {resulty} for y");
            }

        }
        public static void Calculator(double firstNumber, double secondNumber, int selectedOption)
        {

            switch (selectedOption)
            {

                case 1:
                    Addition(firstNumber, secondNumber);
                    break;

                case 2:
                    Substraction(firstNumber, secondNumber);
                    break;

                case 3:
                    Multipication(firstNumber, secondNumber);
                    break;

                case 4:
                    Division(firstNumber, secondNumber);
                    break;

                case 5:
                    Exponentiation(firstNumber, secondNumber);
                    break;

                case 6:
                    Factorial((ulong)firstNumber, (ulong)secondNumber);
                    break;

                case 7:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Incorrect output. Try again.");
                    break;

            }
        }
    }
}
