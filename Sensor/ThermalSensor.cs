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
            this.Name = "Thermal Sensor";
        }

        public override bool Activate(Sensor sensor)
        {
            return sensor is ThermalSensor;
        }
    }
}
