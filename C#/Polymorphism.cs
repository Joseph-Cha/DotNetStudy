using System;
using System.Collections;

public interface Animal
{
    string Cry();
}

public class Dog : Animal
{
    public string Cry() => "멍멍멍";
}

public class Cat : Animal
{
    public string Cry() => "야옹";
}

public class Trainer
{
    public void DoCry(Animal animal)
    {
        System.Console.WriteLine(animal.Cry());
    }
}

class PolymorphismDemo
{
    static void Main()
    {
        Animal dog = new Dog();
        System.Console.WriteLine(dog.Cry());

        Animal cat = new Cat();
        System.Console.WriteLine(cat.Cry());

        Trainer trainer = new Trainer();
        trainer.DoCry(dog);
        trainer.DoCry(cat);
    }
}
