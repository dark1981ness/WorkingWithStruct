using System;
using System.Collections.Generic;

namespace FibonacciSnail
{
    public static class MyExtensions
    {
        public static double ConvertToRadians(this Double value)
        {
            return (Math.PI / 180) * value;
        }

        public static double NextGaussian(this Random r, double mu = 0, double sigma = 1)
        {
            var u1 = r.NextDouble();
            var u2 = r.NextDouble();

            var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2);

            var rand_normal = mu + sigma * rand_std_normal;

            return rand_normal;
        }

    }

    class Program
    {
        protected static int originalTopCursorPos = Console.CursorTop;
        protected static int originalLeftCursorPos = Console.CursorLeft;
        protected static int originalCenterTopCursorPos = Console.WindowHeight / 2;
        protected static int originalCenterLeftCursorPos = Console.WindowWidth / 2;
        protected static string headerMsg = "Fibonacci Snail";

        static void Main(string[] args)
        {
            Console.Clear();
            //Console.SetCursorPosition(((Console.WindowWidth - headerMsg.Length) / 2), originalTopCursorPos);
            //Console.WriteLine(headerMsg);
            //Console.WriteLine();
            //DrawSnail('*', 1, 180, 270);

            Random r = new Random();
            r.NextGaussian();
        }

        private static List<int> FibNumSeq(int n)
        {
            List<int> fibSeq = new List<int>();
            int tempValue;
            int a = 0;
            int b = 1;

            for (int i = 0; i < n; i++)
            {
                tempValue = a;
                a = b;
                b += tempValue;
                fibSeq.Add(a);
            }

            return fibSeq;
        }
       
        private static void DrawSnail(char simbol, int radius, int startAngleValue, int endAngleValue)
        {
            double posX, posY;
            int posXcen = originalCenterLeftCursorPos / 2 + radius;
            int posYcen = originalCenterTopCursorPos / 2;
            for (double i = startAngleValue; i <= endAngleValue; i++)
            {
                double toRadians = i.ConvertToRadians();
                posX = Math.Round(radius * Math.Cos(toRadians) + posXcen, 1, MidpointRounding.AwayFromZero);
                posY = Math.Round(radius * Math.Sin(toRadians) + posYcen, 1, MidpointRounding.AwayFromZero);
                Console.WriteLine($"Point №{i} : X - {posX} / Y - {posY}");
            }

        }
    }
}
