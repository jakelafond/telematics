using System;
using System.Collections.Generic;
using System.IO;

namespace Telematics
{
    public class VehicleInfo
    {
        public int VIN { get; set; }
        public double Odometer { get; set; }
        public double Consumption { get; set; }
        public double OdometerLastOilChange { get; set; }
        public double EngineSize { get; set; }    

        public VehicleInfo(int vin, double odometer, double consumption, double odometerLastOilChange, double engineSize)
        {
            VIN = vin;
            Odometer = odometer;
            Consumption = consumption;
            OdometerLastOilChange = odometerLastOilChange;
            EngineSize = engineSize;
        } 

        public override string ToString()
        {
            return $"VIN:{VIN}, Odometer:{Odometer}, Consumption:{Consumption},Last Oil Change Odometer Reading:{OdometerLastOilChange}, Engine Size:{EngineSize}";
        }
    }
    
}