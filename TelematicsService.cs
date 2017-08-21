using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Telematics
{
    public class TelematicsService
    {
        JsonSerializer serializer = new JsonSerializer();
        public void Report(VehicleInfo vehicleInfo)
        {
            using (var writer = new StreamWriter(File.Open($"{vehicleInfo.VIN}.json", FileMode.OpenOrCreate)))
            using (var jsonWriter = new JsonTextWriter(writer))
            {

                serializer.Serialize(writer, vehicleInfo);
                // writer.WriteLine(vehicleInfo.VIN);
                // writer.WriteLine(vehicleInfo.Odometer);
                // writer.WriteLine(vehicleInfo.Consumption);
                // writer.WriteLine(vehicleInfo.OdometerLastOilChange);
                // writer.WriteLine(vehicleInfo.EngineSize);
            }
        }
        public void deJson(VehicleInfo vehicleInfo)
        {
            string[] files = System.IO.Directory.GetFiles("/Users/jacoblafond/dotnet/telematics", "*.json");
            ///add stuff to a list here so can print them out in html pages eventually
            foreach (var item in files)
            {
                using (StreamReader file = File.OpenText(item))
                {
                    var vehicleInfo2 = JsonConvert.DeserializeObject<VehicleInfo>(file.ReadToEnd());
                    Console.WriteLine(vehicleInfo2.VIN);
                }
            }
        }
    }

}