using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_game.Agent
{
    internal class SeniorCommander : Agent
    {
        public SeniorCommander(string name) : base(name)
        {
            this.Rank = 2;
            GenerateWeaknessesSensor();

        }

        public override void Attack()
        {
            for (int i = 0; i < 2; i++) 
            {
                if (this.AttachedSensor.Count > 0)
                {
                    int num = Rand.Next(this.AttachedSensor.Count);
                    this.AttachedSensor.RemoveAt(num);
                }
               
            }
            
        }
    }
}
