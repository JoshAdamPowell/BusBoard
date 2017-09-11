using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.Api
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
