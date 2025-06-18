using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_game.Sensor
{
    internal class ThermalSensor : Sensor
    {
        public ThermalSensor() 
        {
            this.Name = "ThermalSensor";
        }

        public override bool IsNotBroken()
        {
            return true;
        }
    }
}
