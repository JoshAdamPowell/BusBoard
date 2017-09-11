using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    public static class URLManager
    {

        public static IRestResponse GetAPIResponse(string baseURL, string resource)
        {
            
            var postCodeClient = new RestClient();
            postCodeClient.BaseUrl = new Uri(baseURL);
            var postCodeRequest = new RestRequest();
            postCodeRequest.Resource = resource;
            return postCodeClient.Execute(postCodeRequest);
        }
    }
}
