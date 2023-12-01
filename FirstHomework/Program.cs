namespace FirstHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a mathematical expression or type exit to quit: ");
                string expression = Console.ReadLine();

                if (expression.ToLower() == "exit")
                    break;

                try
                {
                    //Console.WriteLine("Your result is: " + Calculator(expression));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
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
            if (y == 0)
            {
                Console.WriteLine("Your result is: 1");
            }

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

        static void Calculator(string expression)
        {
            expression = expression.Replace(" ", "");

            if (string.IsNullOrWhiteSpace(expression))
                Console.WriteLine("Your input is empty.");

            string[] parts = expression.Split('+', '-', '*', '/', '^');

        }
    }
}
