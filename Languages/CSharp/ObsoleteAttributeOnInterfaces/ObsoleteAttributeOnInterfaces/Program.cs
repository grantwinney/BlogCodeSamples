using System;

namespace ObsoleteAttributeOnInterfaces;

public static class Program
{
    public static void Main()
    {
        IAnimal penguin = new Penguin();
        penguin.Move();

        IAnimal dog = new Dog();
        dog.Move();

        IAnimal fish = new Fish();
        fish.Move();



        IAnimal dinosaur = new Dinosaur();
        dinosaur.Move();

        //Dinosaur dino = new Dinosaur();
        //dino.Move();

    }
}

public interface IAnimal
{
    void Move();
}

public class Penguin : IAnimal
{
    public void Move()
    {
        Console.WriteLine("The penguin waddled.");
    }
}

public class Dog : IAnimal
{
    public void Move()
    {
        Console.WriteLine("The dog walked.");
    }
}

public class Fish : IAnimal
{
    public void Move()
    {
        Console.WriteLine("The fish swam.");
    }
}

public class Dinosaur : IAnimal
{
    [Obsolete("Dinos don't move anymore", true)]
    public void Move()
    {
        Console.WriteLine("The dino, uh... remained still.");
    }
}
