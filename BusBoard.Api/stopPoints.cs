using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace BusBoard.Api
{
    public class StopPoints
    {
        public string id;
        public string commonName;

        public static List<StopPoints> GetStopPointList(string lon, string lat)
        {
            IRestResponse response;
            try
            {
                response = URLManager.GetAPIResponse(@"https://api.tfl.gov.uk", @"/StopPoint?lat=" + lat + "&lon=" + lon + "&stopTypes=NaptanPublicBusCoachTram&radius=500&app_id=731f9517&app_key=54b0b22e2a48aea8cb6e465f09897657");
            }
            catch
            {
                Console.WriteLine("An Error has occured, possibly no bus stops in radius");
                return null;
            }
            var apiWrapperStops = JsonConvert.DeserializeObject<APIWrapperStops>(response.Content);
            return apiWrapperStops.stopPoints;

        }

    }
}
