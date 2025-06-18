using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Investigation_game.Enums;
using Investigation_game.Sensor;

namespace Investigation_game.Game
{
    using Factories;
    internal class Investigation
    {
        private static List<Sensor.Sensor> AvailableSensors = new List<Sensor.Sensor>();

        public static void StartInvestigation(Agent.Agent agent)
        {
            SetAvailableSensors();
            bool exit = false;
            int turn = 0;
            Console.WriteLine("The agent's investigation begins.");
            Console.WriteLine($"Attached sensors: {agent.AttachedSensor.Count}/{agent.WeaknessesSensor.Count}");

            while (!exit)
            {
                Console.WriteLine("Please choose sensor to attach:");
                PrintSensors();
                string input = Console.ReadLine();

                if (IsValid(input))
                {
                    turn++;
                    int choice = int.Parse(input);
                    Enums.Sensors selected = (Enums.Sensors)choice;

                    Sensor.Sensor sensor = SelectSensor(selected);

                    if (sensor.IsNotBroken()) 
                    {
                        if (selected == Enums.Sensors.ThermalSensor)
                        {
                            agent.RevealsSensor();
                        }
                        else 
                        {
                            bool tryMatch = agent.SensorIsMatch(sensor);
                            if (tryMatch)
                                Console.WriteLine("Sensor is match!");
                            else
                                Console.WriteLine("Sensor is not match.");
                        }
  
                        if (agent.WeaknessesSensor.Count == agent.AttachedSensor.Count) 
                        {
                            agent.Exposed = true;
                            Console.WriteLine("Agent exposed! well done!");
                            return;   
                        }
                        if (turn % 10 == 0)
                        {
                            Console.WriteLine("Set agent weaknesses and atached sensors.");
                            agent.SetWeaknesseAndAtteched();
                        }
                        else if (turn % 3 == 0)
                        {
                            Console.WriteLine($"Agent {agent.Name} attacking!");
                            agent.Attack();
                        }
                    }
                    else 
                        Console.WriteLine("Sensor is broken.");
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Do you want to continue? (Yes, No)");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "No")
                        exit = false;
                    else
                        exit = true;
                }
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

        private static void SetAvailableSensors()
        {
            foreach (Enums.Sensors sensorType in Enum.GetValues(typeof(Enums.Sensors)))
            {
                Sensor.Sensor sensor = SensorFactory.Create(sensorType);
                AvailableSensors.Add(sensor);
            }
        }

        private static Sensor.Sensor SelectSensor(Enums.Sensors sensorName)
        {
            foreach (Sensor.Sensor sen in AvailableSensors)
            {
                if (sen.Name == sensorName.ToString())
                    return sen;
            }
            return null;
        }
    }
}
