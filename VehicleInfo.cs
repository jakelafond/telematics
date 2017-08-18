using System;

namespace Telematics
{
    public class VehicleInfo
    {
        public int VIN { get; set; }
        public double Odometer { get; set; }
        public double Consumption { get; set; }
        public double OdometerLastOilChange { get; set; }
        public double EngineSize { get; set; }        
    }
    
}