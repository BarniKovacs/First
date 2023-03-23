using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        void TurnOnLights();
        void StopEngine();
        void Accelerate();
        void Brake();
        void TurnLeft();
        void TurnRight();

    }
}
