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

        public static List<Bus> GetListOfBuses(string busCode)
        {
            
            string resource = @"StopPoint/940GZZLUASL/Arrivals?app_id=731f9517&app_key=54b0b22e2a48aea8cb6e465f09897657&id=" + busCode;
            IRestResponse response  = URLManager.GetAPIResponse(@"https://api.tfl.gov.uk", resource); 
            return JsonConvert.DeserializeObject<List<Bus>>(response.Content);
        }

    }
}
