using System;
using System.Collections.Generic;
using System.Linq;

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

        delegate int myDelgate(int a, int b);

        void Main(string[] args)
        {
            int x = Multiply(); // return 6
            Func<int, int, int> myFunc = (a, b) => a + b;
            myDelgate my = new myDelgate(myFunc);

            int y = Multiply(myFunc); // return 6
            System.Console.WriteLine($"x : {x}, y : {y}");
        }
              
    }
}
