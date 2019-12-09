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
        //Arrays corresponds to measurement value
        public float TempC { get; set; }
        public float TempF { get; set; }
        public float AccelerationX { get; set; }
        public float AccelerationY { get; set; }
        public float AccelerationZ { get; set; }
        public float AngMomentX { get; set; }
        public float AngMomentY { get; set; }
        public float AngMomentZ { get; set; }
        public float Pressure { get; set; }
        public float Altitude { get; set; }
        public String Orientation { get; set; }

        public static List<TelemetryData> ReadFile(string filepath)
        {
            var lines = File.ReadAllLines(filepath);
            var data = from l in lines.Skip(0)
                       let split = l.Split(';')
                       select new TelemetryData
                       {
                           Time = float.Parse(split[0]),
                           AccelerationX = float.Parse(split[1]),
                           AccelerationY = float.Parse(split[2]),
                           AccelerationZ = float.Parse(split[3]),
                           Orientation = split[4],
                           TempC = float.Parse(split[5]),
                           TempF = float.Parse(split[6]),
                           Pressure = float.Parse(split[7]),
                           Altitude = float.Parse(split[8]),
                           AngMomentX = float.Parse(split[9]),
                           AngMomentY = float.Parse(split[10]),
                           AngMomentZ = float.Parse(split[11])
                       };
            return data.ToList();
        }
    }
}
