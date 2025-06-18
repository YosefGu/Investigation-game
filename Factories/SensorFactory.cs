using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investigation_game.Enums;
using Investigation_game.Sensor;

namespace Investigation_game.Factories
{
    using Sensor;

    public class SensorFactory
    {
        private static Dictionary<Sensors, Func<Sensor>> sensorMap = new Dictionary<Sensors, Func<Sensor>>()
        {
            { Sensors.AudioSensor, () => new AudioSensor() },
            { Sensors.ThermalSensor, () => new ThermalSensor() },
            { Sensors.PulseSensor, () => new PulseSensor() },
            { Sensors.MotionSensor, () => new MotionSensor() }
        };

        public static Sensor Create(Sensors sensorType)
        {
            if (sensorMap.ContainsKey(sensorType))
                return sensorMap[sensorType]();
            throw new ArgumentException("Unknown sensor type");
        }
    }
}
