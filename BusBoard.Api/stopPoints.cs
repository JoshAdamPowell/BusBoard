using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard.Api
{
    public class StopPoints
    {
        public string id;
        public string commonName;
        
        public static List<StopPoints> GetFiveStopPoints(Location location)
        {
            var sp = StopPointFactory.GetStopPointList(location);
            var fiveStopPoints = new List<StopPoints>();
            for (int stopPointNumber = 0; stopPointNumber < sp.Count() && stopPointNumber < 5; stopPointNumber++)
            {
                fiveStopPoints.Add(sp[stopPointNumber]);
            }
            return fiveStopPoints;
        }

       

        public List<Bus> GetNext5Buses()
        {
            var buses = BusFactory.GetListOfBuses(id).OrderBy(x => x.timeToStation).ToList<Bus>();
            var fiveBuses = new List<Bus>();
            for (int busNumber = 0; busNumber < buses.Count() && busNumber < 5; busNumber++)
            {
                fiveBuses.Add(buses[busNumber]);

            }
            return fiveBuses;           
        }

       

    }
}
