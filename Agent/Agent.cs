using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_game.Agent
{
    public abstract class Agent
    {
        public string Name { get; protected set; }
        public int Rank { get; protected set; }
        public bool Exposed { get; set; }
        public Sensor.Sensor[] WeaknessesSensor { get; protected set; }
        public Sensor.Sensor[] AttachedSensor { get; set; }

        public Agent(string name) 
        {
            this.Name = name;
            this.Exposed = false;
            this.WeaknessesSensor = new Sensor.Sensor[this.NumOfSlots()];
            this.AttachedSensor = new Sensor.Sensor[this.NumOfSlots()];

        }

        protected int NumOfSlots()
        {
            return 2 * (Rank + 1);
        }
    }
}
