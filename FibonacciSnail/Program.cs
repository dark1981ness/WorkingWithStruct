using System;
using System.Collections.Generic;

namespace FibonacciSnail
{
    class Program
    {
        protected static int originalTopCursorPos = Console.CursorTop;
        protected static int originalLeftCursorPos = Console.CursorLeft;
        protected static int originalCenterTopCursorPos = Console.WindowHeight / 2;
        protected static int originalCenterLeftCursorPos = Console.WindowLeft / 2;
        protected static string headerMsg = "Fibonacci Snail";

        static void Main(string[] args)
        {
            Console.Clear();
            Console.SetCursorPosition(((Console.WindowWidth - headerMsg.Length) / 2), originalTopCursorPos);
            Console.WriteLine(headerMsg);
            Console.WriteLine();
            DrawSnail(1, 180, 270);
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
       
        private static void DrawSnail(int radius, int startAngleValue, int endAngleValue)
        {
            double posX, posY;
            char drawSimbol = '*';
            Console.SetCursorPosition(originalCenterLeftCursorPos, originalCenterTopCursorPos);
            for (int i = startAngleValue; i < endAngleValue; i++)
            {
                posX = Math.Round(radius * Math.Cos(i), 2, MidpointRounding.AwayFromZero);
                posY = Math.Round(radius * Math.Sin(i), 2, MidpointRounding.AwayFromZero);

                Console.WriteLine($"X - {posX} / Y - {posY}");
               // Console.SetCursorPosition(posX + originalCenterLeftCursorPos, posY + originalCenterTopCursorPos);
                //Console.Write(drawSimbol);
            }

        }
    }
}
