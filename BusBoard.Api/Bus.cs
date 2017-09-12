using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;


namespace BusBoard.Api
{
    public class Bus
    {
        public string stationName;
        public string lineId;
        public string lineName;

        public string destinationName;

        public int timeToStation;
        public string status;
        

        public string GetTheArrivalTime()
        {
            return SecondsToMinutes(timeToStation);
        }

        private string SecondsToMinutes(int seconds)
        {
            return DateTime.Now.AddSeconds(seconds).ToShortTimeString();
        }

    }
}
