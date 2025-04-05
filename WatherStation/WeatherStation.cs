using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatherStation
{
    internal class WeatherStation
    {
        private Dictionary<string, WeatherLocation> locations = new Dictionary<string, WeatherLocation>();

        public void ProcessCommand(string command)
        {
            string[] parts = command.Split(' ');

            if (parts[0] == "Input")
            {
                string location = parts[1];
                DateTime date = DateTime.ParseExact(parts[2], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                double temp = double.Parse(parts[3]);
                string tempUnit = parts[4];
                double precipitation = double.Parse(parts[5]);

                if (!locations.ContainsKey(location))
                {
                    locations[location] = new WeatherLocation(location);
                }

                WeatherData data = new WeatherData(date, temp, tempUnit, precipitation, "mm");
                locations[location].AddWeatherData(data);
            }
            else if (parts[0] == "get")
            {
                string location = parts[1];
                DateTime date = DateTime.ParseExact(parts[2], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string tempUnit = parts[3];

                if (locations.ContainsKey(location))
                {
                    Console.WriteLine(locations[location].GetWeatherData(date, tempUnit));
                }
                else
                {
                    Console.WriteLine("No data found");
                }
            }
        }
    }

    }

