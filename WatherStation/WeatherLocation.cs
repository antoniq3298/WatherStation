using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatherStation
{
    internal class WeatherLocation
    {
        public string Location { get; }
        private List<WeatherData> Records { get; } = new List<WeatherData>();

        public WeatherLocation(string location)
        {
            Location = location;
        }

        public void AddWeatherData(WeatherData data)
        {
            Records.Add(data);
            Console.WriteLine($"inserted {Location} {data.Date.ToString("dd.MM.yyyy")}");
        }

        public string GetWeatherData(DateTime date, string tempUnit)
        {
            var record = Records.Find(r => r.Date.Date == date.Date);
            return record != null ? $"{Location} {record.GetWeatherReport(tempUnit)}" : "No data found";
        }
    }
}
    
    
    
       
