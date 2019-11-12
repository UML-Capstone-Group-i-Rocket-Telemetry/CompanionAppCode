using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TelemetryCompanionApp
{
    public class TelemetryData
    {
        //Array corresponds to time
        public float Time { get; set; }
        //Array corresponds to measurement value
        public float Temperture { get; set; }
        //Latest values for real time display and cursor display
        public float Velocity { get; set; }

        public static List<TelemetryData> ReadFile(string filepath)
        {
            var lines = File.ReadAllLines(filepath);
            var data = from l in lines.Skip(0)
                       let split = l.Split(',')
                       select new TelemetryData
                       {
                           Time = float.Parse(split[0]),
                           Temperture = float.Parse(split[1]),
                           Velocity = float.Parse(split[2])
                       };
            return data.ToList();
        }
    }
}
