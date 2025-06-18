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

        public override void Attack() 
        {
            if (this.AttachedSensor.Count > 0)
            {
                int num = Rand.Next(this.AttachedSensor.Count);
                this.AttachedSensor.RemoveAt(num);
            }
            Console.WriteLine("Agent attacking!");
        }
    }
}
