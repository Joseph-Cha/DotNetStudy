using System;

namespace oop
{
    public class Person
    {
        private string name;
        public void SetName(string n) => name = n;
        public string GetName() => this.name;
    }

    class EncapsulationNote
    {
        void Main()
        {
            Person person = new Person();
            person.SetName("C#");
            System.Console.WriteLine(person.GetName());       

        }
    }
}