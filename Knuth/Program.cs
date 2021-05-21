using System;

namespace Knuth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fibonacci(10));

            

            Console.WriteLine(FibonacciMath(10));
        }

        public static int Fibonacci(int n)
        {
            int a = 0;
            int b = 1;
            int tempValue;

            for (int i = 0; i < n; i++)
            {
                tempValue = a;
                a = b;
                b += tempValue;
            }

            return a;
        }

        public static double FibonacciMath(int n)
        {
            double x = n;
            double ph = (1 + Math.Round(Math.Sqrt(5), 1)) / 2;
            double ph_ = (1 - Math.Round(Math.Sqrt(5), 1)) / 2;

            return (Math.Pow(ph, x) - Math.Pow(ph_, x))/ Math.Round(Math.Sqrt(5), 1);
        }
    }
}
