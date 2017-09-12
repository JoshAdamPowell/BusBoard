using System.Collections.Generic;

namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    public BusInfo(List<string> strings )
    {
      Strings = strings;
    }

    public List<string> Strings { get; set; }

  }
}