using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatherStation
{
    internal class WeatherData
    {
        public WeatherData() { }
        
            public DateTime Date { get; }
            public double TemperatureC { get; }
            public double PrecipitationMM { get; }

            public WeatherData(DateTime date, double temperature, string tempUnit, double precipitation, string precipUnit)
            {
                Date = date;
                TemperatureC = tempUnit == "F" ? ConvertFahrenheitToCelsius(temperature) : temperature;
                PrecipitationMM = precipUnit == "in" ? ConvertInchesToMM(precipitation) : precipitation;
            }

            private double ConvertFahrenheitToCelsius(double tempF) => (tempF - 32) * 5 / 9;

            private double ConvertInchesToMM(double inches) => inches * 25.4;

            private string GetTemperatureDescription()
            {
                if (TemperatureC < -5)
                return "Extreme Cold";
                if (TemperatureC >= -5 && TemperatureC < 5)
                
                return "Cold";
                if (TemperatureC >= 5 && TemperatureC < 30)
                return "Warm";
                return "Hot";
            }

            public string GetWeatherReport(string tempUnit)
            {
                double temp = tempUnit == "F" ? (TemperatureC * 9 / 5) + 32 : TemperatureC;
                string unit = tempUnit == "F" ? "F" : "C";
                string precipText = PrecipitationMM == 0 ? "no percip" : $"{PrecipitationMM}mm rain";

                string warning = "";
                if (TemperatureC < -5) warning = " Warning cold weather";
                if (TemperatureC > 30) warning = " Warning hot weather";

                return $"{Date.ToString("dd.MM.yyyy")} {GetTemperatureDescription()} {temp}{unit} {precipText}{warning}";
            }
        }

    }

