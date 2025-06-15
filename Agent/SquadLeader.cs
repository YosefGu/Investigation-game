using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_game.Agent
{
    public class SquadLeader : Agent
    {
        public SquadLeader(string name) : base(name)  
        {
            base.Weaknesses = new Sensor[4];
            this.AttachedSensors = new Sensor[4];

        }
    }
}
