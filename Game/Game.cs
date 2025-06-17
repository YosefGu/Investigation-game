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
                            game.InvestigationChoose();
                            break;
                        case 3:
                            game.PrintAllAgents();    
                            break;
                        case 4:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Incurrect input.\nPlease enter a number between 1 - 4");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incurrect input.\nPlease enter a number between 1 - 4");
                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add agent");
            Console.WriteLine("2. Start investigation");
            Console.WriteLine("3. Show arrested agents");
            Console.WriteLine("4. Exit");
        }
        private void AddArrestedAgent()
        {
            Agent.Agent agent = CreateAgent();
            ArrestedAgents.Add(agent);
            Console.WriteLine($"Agent {agent.Name} with rank {agent.Rank} was added.\n*** ----- ***");
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
        private void InvestigationChoose()
        {
            if (ArrestedAgents.Count > 0)
            {
                foreach (Agent.Agent agent in ArrestedAgents)
                {
                    if (!agent.Exposed)
                    {
                        Console.WriteLine($"The agent: {agent.Name}, with rank: {agent.Rank}, send to investigation");
                        Investigation.StartInvestigation(agent);
                        bool keepInvastigate = AskKeepInvastigation();
                        if (!keepInvastigate)
                            return;
                    }
                }
                Console.WriteLine("All agents exposed.");
            }
            else
            {
                Console.WriteLine("No agents in custody.");
            }
            return;

        }
        private bool AskKeepInvastigation() 
        {
            Console.WriteLine("Do you want to keep investigate? (Yes / No)");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes") 
                return true;
            return false;
        }

        private void PrintAllAgents()
        {
            if (ArrestedAgents.Count > 0)
            {
                foreach (Agent.Agent agent in ArrestedAgents)
                {
                    Console.WriteLine("----- *** -----");
                    Console.WriteLine($"Name: {agent.Name}, Weaknesses: [{string.Join(", ", agent.WeaknessesSensor.Select(s => s.Name))}], Attached: [{string.Join(", ", agent.AttachedSensor.Select(s => s.Name))}], Exposed: {agent.Exposed}");
                }
            }
            else
                Console.WriteLine("No agents arrested.");            
        }
    }
}