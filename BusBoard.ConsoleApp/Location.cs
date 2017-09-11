using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{


    public class Location
    {
        public string longitude;
        public string latitude;

        public static Location GetPostcodeLocation(string postCode)
        {
            IRestResponse response = URLManager.GetAPIResponse(@"http://api.postcodes.io", @"postcodes/" + postCode);
            var apiResponse = JsonConvert.DeserializeObject<APIwrapper>(response.Content);
            return apiResponse.result;

        }
    }
}
