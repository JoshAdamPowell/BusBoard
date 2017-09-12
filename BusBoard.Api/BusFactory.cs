using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.Api
{
    public class BusFactory
    {
        public static List<Bus> GetListOfBuses(string busCode)
        {

            string resource = @"StopPoint/940GZZLUASL/Arrivals?app_id=731f9517&app_key=54b0b22e2a48aea8cb6e465f09897657&id=" + busCode;
            IRestResponse response = URLManager.GetAPIResponse(@"https://api.tfl.gov.uk", resource);
            return JsonConvert.DeserializeObject<List<Bus>>(response.Content);
        }

        

    }
}
