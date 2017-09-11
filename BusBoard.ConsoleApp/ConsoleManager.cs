using System;
using System.Collections.Generic;
using System.Linq;
using BusBoard.Api;
namespace BusBoard.ConsoleApp
{
    public class ConsoleManager
    {
        public static void Print5BusStops(List<StopPoints> stopPointsList)
        {

            for (int stopNumber = 0; stopNumber < stopPointsList.Count() && stopNumber < 5; stopNumber++)
            {
                var buses = Bus.GetListOfBuses(stopPointsList[stopNumber].id);
                buses = buses.OrderBy(x => x.timeToStation).ToList<Bus>();
                Console.WriteLine("Bus Stop common name \t {0} \n", stopPointsList[stopNumber].commonName);
                Print5Buses(buses);

            }

        }

        public static void Print5Buses(List<Bus> buses)
        {

            for (int busNumber = 0; busNumber < buses.Count() && busNumber < 5; busNumber++)
            {
                string arrivalTime = SecondsToMinutes(buses[busNumber].timeToStation);
                Console.WriteLine("bus lineId {0} \t Destination {1}, \t Arriving in {2}", buses[busNumber].lineId, buses[busNumber].destinationName, arrivalTime);
            }
        }

        public static string SecondsToMinutes(int seconds)
        {
            int mins = seconds / 60;
            int newSecond = seconds % 60;
            return mins.ToString() + ":" + newSecond.ToString();

        }

        public static string GetPostCode()
        {
            Console.WriteLine("Please enter postCode");
            return Console.ReadLine();
        }

    }
}
