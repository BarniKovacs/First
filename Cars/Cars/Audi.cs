using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    internal class Audi : ICar
    {
        public void Accelerate()
        {
            Console.WriteLine("Audi Gyorsitas");
        }

        public void Brake()
        {
            Console.WriteLine("Audi Fekezz");
        }

        public void TurnOnLights()
        {
            Console.WriteLine("Audi Lampa");
        }

        public void StopEngine()
        {
            Console.WriteLine("Audi Motor Leallitas");
        }

        public void TurnLeft()
        {
            Console.WriteLine("Audi Balra");
        }

        public void TurnRight()
        {
            Console.WriteLine("Audi Jobbra");
        }
    }
}
