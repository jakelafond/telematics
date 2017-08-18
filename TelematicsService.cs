using System;
using System.Collections.Generic;
using System.IO;

namespace Telematics
{
    public class TelematicsService
    {
       public void Report(VehicleInfo vehicleInfo)
       {
            using (var writer = new StreamWriter(File.Open($"{vehicleInfo.VIN}.json", FileMode.OpenOrCreate)))
            {
                writer.WriteLine(vehicleInfo.VIN);
                writer.WriteLine(vehicleInfo.Odometer);
                writer.WriteLine(vehicleInfo.Consumption);
                writer.WriteLine(vehicleInfo.OdometerLastOilChange);
                writer.WriteLine(vehicleInfo.EngineSize);
            }
       }
    }
    
}