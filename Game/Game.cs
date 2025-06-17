using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investigation_game.Agent;

namespace Investigation_game.Game
{
    internal class Game
    {
        public List<Agent.Agent> ArrestedAgents { get; set; } = new List<Agent.Agent>();

        public enum Ranks
        {
            FootSoldier = 1,
            SquadLeader = 2
        }
        public static void StartGame()
        {
            Game game = new Game();
            bool exit = false;
            Console.WriteLine("Welcome to: Investigation game!");
            while (!exit)
            {
                game.PrintMenu();
                string response = Console.ReadLine();
                int intResponse;
                if (int.TryParse(response, out intResponse))
                {
                    switch (intResponse)
                    {
                        case 1:
                            game.AddArrestedAgent();
                            break;
                        case 2:
                            game.Investigation();
                            break;
                        case 3:
                            exit = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incurrect input.\nPlease enter a number between 1 - 3");
                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add agent");
            Console.WriteLine("2. Start investigation");
            Console.WriteLine("3. Exit");
        }
        private void AddArrestedAgent()
        {
            Agent.Agent agent = CreateAgent();
            ArrestedAgents.Add(agent);
            Console.WriteLine($"Agent {agent.Name} with rank {agent.Rank} was added.");
        }
        private Agent.Agent CreateAgent()
        {
            Console.Write("Please enter agent name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Choose rank:");
            foreach (var val in Enum.GetValues(typeof(Ranks)))
            {
                Console.WriteLine($"{(int)val}. {val}");
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choic) &&
                        Enum.IsDefined(typeof(Ranks), choic))
                {
                    Ranks rank = (Ranks)choic;

                    switch (rank)
                    {
                        case Ranks.FootSoldier:
                            return new FootSoldier(name);
                        case Ranks.SquadLeader:
                            return new SquadLeader(name);
                        default:
                            throw new InvalidOperationException("Unknow rank.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again:");
                }
            }
        }

        private void Investigation()
        {
            if (ArrestedAgents.Count > 0)
            {
                foreach (Agent.Agent agent in ArrestedAgents)
                {
                    if (!agent.Exposed)
                    {
                        Console.WriteLine("The agent's investigation begins.");
                        Console.WriteLine($"Agent {agent.Name} with rank {agent.Rank}");

                    } else
                        Console.WriteLine($"Exposed: {agent.Exposed}");
                }
                
            }
            else
            {
                Console.WriteLine("No agents in custody.");
            }
            return;

        }
    }


}