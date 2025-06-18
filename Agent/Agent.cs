using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investigation_game.Sensor;

namespace Investigation_game.Agent
{
    using Factories;

    public abstract class Agent
    {
        protected static Random Rand { get; } = new Random();
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

        public virtual void Attack() { }

        protected void GenerateWeaknessesSensor()
        {
            int weaknesses = 2 * (Rank + 1);
            Array values = Enum.GetValues(typeof(Enums.Sensors));
            for (int i = 0; i < weaknesses; i++)
            {
                Enums.Sensors randomType = (Enums.Sensors)values.GetValue(Rand.Next(values.Length));

                Sensor.Sensor sensor = SensorFactory.Create(randomType);
                WeaknessesSensor.Add(sensor);
            }
        }
        public void SetWeaknesseAndAtteched()
        {
            AttachedSensor.Clear();
            WeaknessesSensor.Clear();
            GenerateWeaknessesSensor();
        }

        public bool SensorIsMatch(Sensor.Sensor sensor)
        {
            int weaknessCount = WeaknessesSensor.Count(s => s.Name == sensor.Name);
            if (weaknessCount > 0)
            {
                int attechedCount = AttachedSensor.Count(s => s.Name == sensor.Name);
                if (attechedCount < weaknessCount)
                {
                    AttachedSensor.Add(sensor);
                    return true;
                }
            }
            return false;
        }

        public void RevealsSensor()
        {
            while (true)
            {
                int index = Rand.Next(WeaknessesSensor.Count);
                Sensor.Sensor selected = WeaknessesSensor[index];

                int weaknessesCount = WeaknessesSensor.Count(s => s.Name == selected.Name);
                int attachedCount = AttachedSensor.Count(s => s.Name == selected.Name);

                if (attachedCount < weaknessesCount)
                {
                    AttachedSensor.Add(selected);
                    Console.WriteLine($"{selected.Name} added to attached sensor!");
                    return;
                }
            }
        }
        public override string ToString()
        {
            return $"Agent: {Name}, Rank: {Rank}, Exposed: {Exposed}\nWeaknesses sensors: [{string.Join(", ", WeaknessesSensor.Select(s => s.ToString()))}]\nAttached sensors: [{string.Join(", ", AttachedSensor.Select(s => s.ToString()))}]";
        }
    }
}
