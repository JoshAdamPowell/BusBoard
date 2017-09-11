using System.Net;
using BusBoard.Api;

namespace BusBoard.ConsoleApp
{
    class BusBoard
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var postCode = ConsoleManager.GetPostCode();
            Location location = Location.GetPostcodeLocation(postCode);
            
            ConsoleManager.Print5BusStops(StopPoints.GetStopPointList(location.longitude, location.latitude));
           
        }

    }
}
