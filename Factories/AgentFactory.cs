using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investigation_game.Enums;
using Investigation_game.Sensor;

namespace Investigation_game.Factories
{
    using Agent;
    internal class AgentFactory
    {
        private static Dictionary<Ranks, Func<string, Agent>> agentMap = new Dictionary<Ranks, Func<string, Agent>>()
        {
            { Ranks.FootSoldier, (string name) => new FootSoldier(name) },
            { Ranks.SquadLeader, (string name) => new SquadLeader(name) }
        };

        public static Agent Create(Ranks agentRank, string name)
        {
            if (agentMap.ContainsKey(agentRank))
                return agentMap[agentRank](name);
            throw new ArgumentException("Unknown sensor type");
        }
    }
}
