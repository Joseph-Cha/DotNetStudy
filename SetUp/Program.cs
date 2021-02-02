using System;
using System.Collections;
using System.Collections.Generic;


public class test
{
    static void Main_test()
    {
        string[] names = {"닷넷 코리아", "비주얼 아카데미"};

        foreach (var item in names)
        {
            System.Console.WriteLine(item);
        }

        IEnumerator List = names.GetEnumerator();

        while(List.MoveNext())
        {
            System.Console.WriteLine(List.Current);
            
        }

    }   
}
