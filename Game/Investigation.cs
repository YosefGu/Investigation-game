using System;
using System.Collections.Generic;

namespace Investigation_game.Game
{
    internal class Investigation
    {
        public static void StartInvestigation(Agent.Agent agent)
        {
            bool exit = false;
            Console.WriteLine("The agent's investigation begins.");
            Console.WriteLine($"Attached sensors: {agent.AttachedSensor.Count}/{agent.WeaknessesSensor.Count}");
            
            while (!exit) 
            {
                Console.WriteLine("Please choose sensor to attach:");
                PrintSensors();
                string input = Console.ReadLine();

                if (IsValid(input))
                {
                    int choice = int.Parse(input);
                    SensorType selected = (SensorType)choice;
                    Sensor.Sensor newSensor = CreateSensorByType(selected);

                    for (int i = 0; i < agent.WeaknessesSensor.Count; i++)
                    {
                        if (agent.AttachedSensor.Count < agent.WeaknessesSensor.Count)
                        {

                            bool isMatch = newSensor.Activate(agent.WeaknessesSensor[i]);
                            if (isMatch)
                            {
                                agent.AttachedSensor.Add(newSensor);
                                Console.WriteLine($"Is match!\n{selected} sensor attached. ({agent.AttachedSensor.Count}/{agent.WeaknessesSensor.Count})");
                                if (agent.WeaknessesSensor.Count == agent.AttachedSensor.Count)
                                { 
                                    agent.Exposed = true;
                                    Console.WriteLine("Agent exposed! well done!");
                                    return;
                                }
                                break;
                                
                            }
                            else
                            {
                                Console.WriteLine("The sensor is NOT match.");
                                break;
                            }
                        }
                    }
                     
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Do you want to exit? type exit");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "exit")
                        exit = true;       
                }
            }
        }
        

        public static Sensor.Sensor CreateSensorByType(Enums.Sensors type)
        {
            switch (type)
            {
                case Enums.Sensors.AudioSensor:
                    return new Sensor.AudioSensor();
                case Enums.Sensors.ThermalSensor:
                    return new Sensor.ThermalSensor();
                default:
                    throw new ArgumentException("Unknown sensor type");
            }
        }

        public static bool IsValid(string input)
        {
            if (int.TryParse(input, out int value) &&
                Enum.IsDefined(typeof(Enums.Sensors), value))
            {
                return true;
            }
            return false;
        }

        public static void PrintSensors() 
        {
            foreach (Enums.Sensors sensor in Enum.GetValues(typeof(Enums.Sensors)))
            {
                Console.WriteLine($"{(int)sensor}. {sensor}");
            }
        }
    }
}
