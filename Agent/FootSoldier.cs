using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_game.Agent
{
    public class FootSoldier : Agent
    {
        public FootSoldier(string name) : base(name) 
        {
            base.Rank = "FootSoldier";
            this.Weaknesses = new Sensor[2];
            this.AttachedSensors = new Sensor[2];
        }
    }
}
