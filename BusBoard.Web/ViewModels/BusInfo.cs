using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    public BusInfo(List<StopPoints> stopPoints )
    {
            StopPoints = stopPoints;
    }

    public List<StopPoints> StopPoints { get; set; }

  }
}