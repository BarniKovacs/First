using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    internal class BMW : ICar
    {
        public void Accelerate()
        {
            Console.WriteLine("BMW Gyorsitas");
        }

        public void Brake()
        {
            Console.WriteLine("BMW Fekezes");
        }

        public void TurnOnLights()
        {
            Console.WriteLine("BMW Fenyszorok");
        }

        public void StopEngine()
        {
            Console.WriteLine("BMW Motor leallitas");
        }

        public void TurnLeft()
        {
            Console.WriteLine("BMW Balra");
        }

        public void TurnRight()
        {
            Console.WriteLine("BMW Jobbra");
        }

        public void StartEngine()
        {
            Console.WriteLine("BMW Motor Elindulva");
        }
    }
}
