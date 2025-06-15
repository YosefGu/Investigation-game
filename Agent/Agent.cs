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
        public string Rank { get; protected set; }
        public bool Exposed { get; set; }
        public Sensor[] Weaknesses { get; protected set; }
        public Sensor[] AttachedSensors { get; set; }

        public Agent(string name) 
        {
            this.Name = name;
        }
    }
}
