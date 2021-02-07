using System;

namespace ConsoleApp1
{
    class Program
    {
        static int AddMethodUsedOneMoreTime(int a, int b)
        {
            return a + b;
        }

        static int Multiply()
        {
            int value = AddMethodUsedOneMoreTime(1, 2);

            return value * 2;
        }


        static int Multiply(Func<int, int, int> AddMethodUsedOneTime)
        {
            return AddMethodUsedOneTime(1,2) * 2;
        }


        static void Main(string[] args)
        {
            int x = Multiply(); // return 6
            int y = Multiply((a, b) => a + b); // return 6
            System.Console.WriteLine($"x : {x}, y : {y}");
        }
    }
}
