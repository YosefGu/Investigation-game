using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_game.Sensor
{
    public abstract class Sensor
    {
        public string Name { get; protected set; }

        public int ActivateCount { get; protected set; } = 0;

        public abstract bool IsNotBroken();

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}