using Newtonsoft.Json;
using RestSharp;
using System.Text.RegularExpressions;

namespace BusBoard.Api
{


    public class Location
    {
        public string longitude;
        public string latitude;

        public static Location GetPostcodeLocation(string postCode)
        {
            postCode = Regex.Replace(postCode, @"\s", "");
            IRestResponse response = URLManager.GetAPIResponse(@"http://api.postcodes.io", @"postcodes/" + postCode);
            var apiResponse = JsonConvert.DeserializeObject<APIwrapper>(response.Content);
            if(apiResponse.status!="200")
            {
                throw new System.Exception();
            }
            return apiResponse.result;

        }
    }
}
