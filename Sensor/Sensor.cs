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

        public abstract bool Activate(Sensor sensor);
    }
}
