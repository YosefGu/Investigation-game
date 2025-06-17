using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investigation_game.Sensor;

namespace Investigation_game.Agent
{
    public abstract class Agent
    {
        public enum SensorType {
            AudioSensor,
            ThermalSensos
        }
        public string Name { get; protected set; }
        public int Rank { get; protected set; }
        public bool Exposed { get; set; }
        public List<Sensor.Sensor> WeaknessesSensor { get; protected set; } = new List<Sensor.Sensor>();
        public List<Sensor.Sensor> AttachedSensor { get; set; } = new List<Sensor.Sensor>();

        public Agent(string name) 
        {
            this.Name = name;
            this.Exposed = false;
        }

        protected void GenerateWeaknessesSensor()
        {
            int weaknesses = 2 * (Rank + 1);
            Random rand = new Random();  
            Array values = Enum.GetValues(typeof(SensorType));
            for (int i = 0; i < weaknesses; i++) 
            {
                SensorType randomType = (SensorType)values.GetValue(rand.Next(values.Length));

                switch (randomType) 
                {
                    case SensorType.AudioSensor:
                        WeaknessesSensor.Add(new Sensor.AudioSensor());
                        break;
                    case SensorType.ThermalSensos:
                        WeaknessesSensor.Add(new Sensor.ThermalSensor());
                        break;
                }
            
            }

        }
    }
}
