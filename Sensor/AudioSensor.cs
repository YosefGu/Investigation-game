using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_game.Sensor
{
    internal class AudioSensor : Sensor
    {
        public AudioSensor() 
        {
            this.Name = "Audio Sensor";
        }

        public override bool Activate(Sensor sensor)
        {
            return sensor is AudioSensor;
        }
    }
}
