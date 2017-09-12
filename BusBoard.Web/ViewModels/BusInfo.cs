using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    public BusInfo(List<StopPoints> stopPoints, bool validPostCode )
    {
            StopPoints = stopPoints;
            ValidPostCode = validPostCode;
    }

        public bool ValidPostCode;

    public List<StopPoints> StopPoints { get; set; }

  }
}