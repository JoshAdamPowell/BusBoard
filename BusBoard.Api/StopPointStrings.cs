using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.Api
{
    public class StopPointStrings
    {
        public static List<string> Get5BusStopCommonNames(List<StopPoints> stopPointsList)
        {
            var strings = new List<string>();
            for (int stopNumber = 0; stopNumber < stopPointsList.Count() && stopNumber < 5; stopNumber++)
            {               
                strings.Add("Bus Stop common name \t" + stopPointsList[stopNumber].commonName + "\n" );               
            }
            return strings;
        }

        public static List<string> Get5BusStrings(StopPoints stopPoint)
        {
            var buses = Bus.GetListOfBuses(stopPoint.id);
            buses = buses.OrderBy(x => x.timeToStation).ToList<Bus>();
            return Get5BusStrings(buses);
        }


        public static List<string> Get5BusStrings(List<Bus> buses)
        {
            var strings = new List<string>();
            for (int busNumber = 0; busNumber < buses.Count() && busNumber < 5; busNumber++)
            {
                string arrivalTime = SecondsToMinutes(buses[busNumber].timeToStation);
                
                strings.Add(String.Format("bus lineId {0} \t Destination {1}, \t Arriving in {2}" , buses[busNumber].lineId, buses[busNumber].destinationName, arrivalTime));
            }
            return strings;
        }

        public static List<string> GetAllStrings(List<StopPoints> stopPointsList)
        {
            var strings = new List<string>();
            for (int stopNumber = 0; stopNumber < stopPointsList.Count() && stopNumber < 5; stopNumber++)
            {
                strings.Add("Bus Stop common name \t" + stopPointsList[stopNumber].commonName + "\n");
                var busStrings = Get5BusStrings(stopPointsList[stopNumber]);
                strings.AddRange(busStrings);             
            }
            return strings;
            
        }

        public static string SecondsToMinutes(int seconds)
        {
            int mins = seconds / 60;
            int newSecond = seconds % 60;
            return mins.ToString() + ":" + newSecond.ToString();

        }

      

    }
}
