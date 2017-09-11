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

            var postCode = GetPostCode();
            Location location = Location.GetPostcodeLocation(postCode);
            string lat = location.latitude;
            string lon = location.longitude;
            //StopPoint?lat=51.565377780069&lon=-0.138213892462395&stopTypes=NaptanPublicBusCoachTram&radius=200&app_id=731f9517&app_key=54b0b22e2a48aea8cb6e465f09897657
            IRestResponse response;
            try
            {
                response = URLManager.GetAPIResponse(@"https://api.tfl.gov.uk", @"/StopPoint?lat="+lat+"&lon="+lon+"&stopTypes=NaptanPublicBusCoachTram&radius=500&app_id=731f9517&app_key=54b0b22e2a48aea8cb6e465f09897657");
            }
            catch
            {
                Console.WriteLine("An Error has occured, possibly no bus stops in radius");
                return;
            }
            var apiWrapperStops = JsonConvert.DeserializeObject<APIWrapperStops>(response.Content);
            var stopPointsList = apiWrapperStops.stopPoints;

            Print5BuseStops(stopPointsList);
            
           
        }

        
            


        private static string GetPostCode()
        {
            Console.WriteLine("Please enter postCode");
            return Console.ReadLine();
        }

        private static void Print5BuseStops(List<StopPoints> stopPointsList)
        {

            for (int stopNumber = 0; stopNumber < stopPointsList.Count() && stopNumber < 5; stopNumber++)
            {
                var buses = Bus.GetListOfBuses(stopPointsList[stopNumber].id);
                buses = buses.OrderBy(x => x.timeToStation).ToList<Bus>();
                Console.WriteLine("Bus Stop common name \t {0} \n", stopPointsList[stopNumber].commonName);
                Print5Buses(buses);
                
            }
           
        }

        private static void Print5Buses(List<Bus> buses)
        {

            for (int busNumber = 0; busNumber < buses.Count() && busNumber < 5; busNumber++)
            {
                Console.WriteLine("bus lineId {0} \t Destination {1}, \t Arriving in {2}", buses[busNumber].lineId, buses[busNumber].destinationName, buses[busNumber].timeToStation);
            }
        }

        

        



    }
}
