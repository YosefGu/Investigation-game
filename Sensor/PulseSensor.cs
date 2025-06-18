using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_game.Sensor
{
    internal class PulseSensor : Sensor
    {
        public PulseSensor()
        {
            this.Name = "PulseSensor";
        }

        public override bool IsNotBroken()
        {
            if (ActivateCount < 3)
            {
                ActivateCount++;
                return true;
            }
            return false;
        }
    }
}
