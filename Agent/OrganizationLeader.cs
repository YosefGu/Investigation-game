using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_game.Agent
{
    internal class OrganizationLeader : Agent
    {
        public OrganizationLeader(string name) : base(name)
        {
            this.Rank = 3;
            GenerateWeaknessesSensor();

        }

        public override void Attack()
        {
            if (this.AttachedSensor.Count > 0)
            {
                int num = Rand.Next(this.AttachedSensor.Count);
                this.AttachedSensor.RemoveAt(num);
            }
        }
    }
}
