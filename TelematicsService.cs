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
            }
        }
        public void GenerateHTMLReport(VehicleInfo vehicleInfo)
        {
            string[] files = System.IO.Directory.GetFiles("/Users/jacoblafond/dotnet/telematics", "*.json");
            ///add stuff to a list here
            List<object> vehicleList = new List<object>();
            var totalOdometer = 0d;
            var itemTemplate = $@"<table align='center' border='1'>
          <tr>
              <th>VIN</th><th>Odometer (miles)</th><th>Consumption (gallons)</th><th>Last Oil Change</th><th>Engine Size (liters)</th>
          </tr>
          <tr>
              <td align='center'>{0}</td><td align='center'>{1}</td><td align='center'>{2}</td><td align='center'>{3}</td><td align='center'>{4}</td>
          </tr>
      </table>";
      var tableHtml = string.Empty;

            foreach (var item in files)
            {
                using (StreamReader file = File.OpenText(item))
                {
                    var vehicleInfo2 = JsonConvert.DeserializeObject<VehicleInfo>(file.ReadToEnd());
                    vehicleList.Add(vehicleInfo2);
                    totalOdometer += vehicleInfo2.Odometer;
                    tableHtml += string.Format($"{itemTemplate}",vehicleInfo2.VIN,vehicleInfo2.Odometer,vehicleInfo2.Consumption,vehicleInfo2.OdometerLastOilChange,vehicleInfo2.EngineSize);
                }
            }
            var odometerAverage = totalOdometer/vehicleList.Count;
            string html = $@"<html>
    <title>Vehicle Telematics Dashboard</title>
    <body>
      <h1 align='center'>Averages for # vehicles</h1>
      <table align='center'>
          <tr>
              <th>Odometer (miles) |</th><th>Consumption (gallons) |</th><th>Last Oil Change |</th><th>Engine Size (liters)</th>
          </tr>
          <tr>
              <td align='center'>{odometerAverage}</td><td align='center'>2</td><td align='center'>3</td align='center'><td align='center'>4</td>
          </tr>
      </table>
      <h1 align='center'>History</h1>
      {tableHtml}
    </body>
  </html>";
  using (var writer = new StreamWriter(File.Open($"Dashboard.html", FileMode.OpenOrCreate)))
            {

                writer.WriteLine(html);
            }
        }
    }

}