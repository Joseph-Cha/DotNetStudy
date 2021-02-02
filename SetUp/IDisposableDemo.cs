using System;

class IDiposalbleDemo
{
    static void Main_IDispose()
    {
        System.Console.WriteLine("[1] 열기");
        using (var r = new Toilet())
        {
            System.Console.WriteLine("[2] 사용");
        }
    }

    public class Toilet : IDisposable
    {
        public void Dispose()
        {
            System.Console.WriteLine("[3] 닫기");
        }
    }
}