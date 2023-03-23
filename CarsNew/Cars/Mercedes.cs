using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    internal class Mercedes : ICar
    {
        public void Accelerate()
        {
            Console.WriteLine("Mercedes Gyorsitas");
        }

        public void Brake()
        {
            Console.WriteLine("Mercedes Fekezz");
        }

        public void TurnOnLights()
        {
            Console.WriteLine("Mercedes Fenyszorok");
        }

        public void StopEngine()
        {
            Console.WriteLine("Mercedes Motor leallitas");
        }

        public void TurnLeft()
        {
            Console.WriteLine("Mercedes Balra");
        }

        public void TurnRight()
        {
            Console.WriteLine("Mercedes Jobbra");
        }

        public void StartEngine()
        {
            Console.WriteLine("Mercedes Motor Elindulva");
        }
    }
}
