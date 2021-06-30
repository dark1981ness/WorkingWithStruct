using System;
using System.Collections.Generic;

namespace FibonacciSnail
{
    class Program
    {
        protected static int originalTopCursorPos;
        protected static int originalLeftCursorPos;
        protected static string headerMsg = "Fibonacci Snail";

        static void Main(string[] args)
        {
            Console.Clear();
            originalTopCursorPos = Console.CursorTop;
            originalLeftCursorPos = Console.CursorLeft;

            Console.SetCursorPosition(((Console.WindowWidth - headerMsg.Length) / 2), originalTopCursorPos);
            Console.WriteLine(headerMsg);
            Console.WriteLine();
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
       
        private static void DrawSnail(List<int> values)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);

        }
    }
}
