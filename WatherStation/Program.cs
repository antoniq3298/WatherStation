using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatherStation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            {
                WeatherStation station = new WeatherStation();

                station.ProcessCommand("Input sofia 10.12.2022 5 C 0");
                station.ProcessCommand("get sofia 10.12.2022 C");
                station.ProcessCommand("get sofia 10.12.2022 F");

                Console.ReadLine(); 
            }
        }
    }
    
}
