using System;

namespace InterfaceFriends
{
    public interface IStandard{void Run();}

    public abstract class KS
    {
        public abstract void Back();
        public void Left() => System.Console.WriteLine("좌회전");

    }
    public partial class MyCar : KS
    {
        public override void Back() => System.Console.WriteLine("후진");
    }
    public partial class MyCar : KS
    {
        public void Right() => System.Console.WriteLine("우회전");
    }

    public sealed class Car : MyCar, IStandard
    {
        public void Run() => System.Console.WriteLine("전진");
    }

    class InterfaceFriends
    {
        void Main_test()
        {
            Car cla = new Car();
            cla.Run();
            cla.Left();
            cla.Right();
            cla.Back();
        }
    }
}