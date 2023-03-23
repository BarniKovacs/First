using System;

namespace Cars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICar bmw = new BMW();
            ICar audi = new Audi();
            ICar mercedes = new Mercedes();

            Console.WriteLine("BMW");
            bmw.TurnOnLights();
            Console.WriteLine("Motor elindult");
            bmw.Accelerate();
            Console.WriteLine("Gyorsitani");
            bmw.Brake();
            Console.WriteLine("Fekezz!");
            bmw.TurnLeft();
            Console.WriteLine("Balra");
            bmw.TurnRight();
            Console.WriteLine("Jobbra");
            bmw.StopEngine();
            Console.WriteLine("Motor leall!");

            Console.WriteLine("Audi");
            audi.TurnOnLights();
            Console.WriteLine("Motor elindult");
            audi.Accelerate();
            Console.WriteLine("Gyorsitani");
            audi.Brake();
            Console.WriteLine("Fekezz!");
            audi.TurnLeft();
            Console.WriteLine("Balra");
            audi.TurnRight();
            Console.WriteLine("Jobbra");
            audi.StopEngine();
            Console.WriteLine("Motor leall!");

            Console.WriteLine("Mercedes");
            mercedes.TurnOnLights();
            Console.WriteLine("Motor elindult");
            mercedes.Accelerate();
            Console.WriteLine("Gyorsitani");
            mercedes.Brake();
            Console.WriteLine("Fekezz!");
            mercedes.TurnLeft();
            Console.WriteLine("Balra");
            mercedes.TurnRight();
            Console.WriteLine("Jobbra");
            mercedes.StopEngine();
            Console.WriteLine("Motor leall!");

            Console.ReadLine();
        }
    }
}
