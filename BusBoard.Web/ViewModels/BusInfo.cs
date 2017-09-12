using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    public BusInfo(List<StopPoints> stopPoints, bool validPostCode, Dictionary<string, string> statusDictionary)
    {
            StopPoints = stopPoints;
            ValidPostCode = validPostCode;
            StatusDictionary = statusDictionary;
    }

        public bool ValidPostCode;

    public List<StopPoints> StopPoints { get; set; }

        public Dictionary<string, string> StatusDictionary;

  }
}