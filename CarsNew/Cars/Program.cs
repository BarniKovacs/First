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

            //Console.WriteLine("BMW");
            //bmw.TurnOnLights();
            //Console.WriteLine("Motor elindult");
            //bmw.Accelerate();
            //Console.WriteLine("Gyorsitani");
            //bmw.Brake();
            //Console.WriteLine("Fekezz!");
            //bmw.TurnLeft();
            //Console.WriteLine("Balra");
            //bmw.TurnRight();
            //Console.WriteLine("Jobbra");
            //bmw.StopEngine();
            //Console.WriteLine("Motor leall!");

            //Console.WriteLine("Audi");
            //audi.TurnOnLights();
            //Console.WriteLine("Motor elindult");
            //audi.Accelerate();
            //Console.WriteLine("Gyorsitani");
            //audi.Brake();
            //Console.WriteLine("Fekezz!");
            //audi.TurnLeft();
            //Console.WriteLine("Balra");
            //audi.TurnRight();
            //Console.WriteLine("Jobbra");
            //audi.StopEngine();
            //Console.WriteLine("Motor leall!");

            //Console.WriteLine("Mercedes");
            //mercedes.TurnOnLights();
            //Console.WriteLine("Motor elindult");
            //mercedes.Accelerate();
            //Console.WriteLine("Gyorsitani");
            //mercedes.Brake();
            //Console.WriteLine("Fekezz!");
            //mercedes.TurnLeft();
            //Console.WriteLine("Balra");
            //mercedes.TurnRight();
            //Console.WriteLine("Jobbra");
            //mercedes.StopEngine();
            //Console.WriteLine("Motor leall!");

            //Console.ReadLine();


            Console.WriteLine("Valaszon egy autot (BMW, Audi, Mercedes): ");
            string autoneve = Console.ReadLine();

            ICar auto = null;

            switch (autoneve.ToLower())
            {
                case "bmw":
                    auto = new BMW();
                    break;

                case "audi":
                    auto = new Audi();
                    break;

                case "mercedes":
                    auto = new Mercedes();
                    break;

                default:
                    Console.WriteLine("Hiba a valasztasban.");
                    break;

            }
            if (auto != null) 
            {
                Console.WriteLine($"/n{autoneve}:");
                auto.StartEngine();
                Console.WriteLine("Motor elindult!");
                auto.TurnOnLights();
                Console.WriteLine("Lampa felkapcsolva");
                auto.Accelerate();
                Console.WriteLine("Gyorsitas");
                auto.TurnLeft();
                Console.WriteLine("Balra");
                auto.TurnRight();
                Console.WriteLine("Jobbra");
                auto.Brake();
                Console.WriteLine("Fekezz is");
                auto.StopEngine();
                Console.WriteLine("Motor leallitas");
                
            }
            Console.ReadLine();
        }
    }
}
