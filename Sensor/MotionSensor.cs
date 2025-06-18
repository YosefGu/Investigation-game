using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_game.Sensor
{
    internal class MotionSensor : Sensor
    {
        public MotionSensor()
        {
            this.Name = "MotionSensor";
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
