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
            this.Rank = 1;
            GenerateWeaknessesSensor();

        }
    }
}
