using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using Newtonsoft;
using Newtonsoft.Json;

namespace BusBoard.ConsoleApp
{
    class BusBoard
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient();
            client.BaseUrl = new Uri(@"https://api.tfl.gov.uk");
            var request = new RestRequest();

            GetPostcodeLocation("N195DU");

            request.Resource = @"StopPoint/940GZZLUASL/Arrivals?app_id=731f9517&app_key=54b0b22e2a48aea8cb6e465f09897657&id=" + GetBusCode();
            IRestResponse response = client.Execute(request);


            var buses = JsonConvert.DeserializeObject<List<Bus>>(response.Content);

            buses = buses.OrderBy(x => x.timeToStation).ToList<Bus>();
            PrintAllBuses(buses);



            


        }

        public static Location GetPostcodeLocation(string postCode)
        {
            var postCodeClient = new RestClient();
            postCodeClient.BaseUrl = new Uri(@"http://api.postcodes.io");
            var postCodeRequest = new RestRequest();
            postCodeRequest.Resource = @"postcodes/" + postCode;
            IRestResponse response = postCodeClient.Execute(postCodeRequest);

            var apiResponse = JsonConvert.DeserializeObject<APIwrapper>(response.Content);
            return apiResponse.result;

        }


        private static string GetBusCode()
        {
            Console.WriteLine("Please enter bus stop code");
            return Console.ReadLine();
        }

        private static void PrintAllBuses(List<Bus> buses)
        {

            for (int busNumber = 0; busNumber < buses.Count() && busNumber < 5; busNumber++)
            {
                Console.WriteLine("bus lineId {0} \t Destination {1}, \t Arriving in {2}", buses[busNumber].lineId, buses[busNumber].destinationName, buses[busNumber].timeToStation);
            }
        }

        

        



    }
}
