using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.Api
{
    public class BusFactory
    {
        public static List<Bus> GetListOfBuses(string busCode)
        {

            string resource = @"StopPoint/940GZZLUASL/Arrivals?app_id=731f9517&app_key=54b0b22e2a48aea8cb6e465f09897657&id=" + busCode;
            IRestResponse response = URLManager.GetAPIResponse(@"https://api.tfl.gov.uk", resource);
            return JsonConvert.DeserializeObject<List<Bus>>(response.Content); 
            
            
        }

        public static Dictionary<string, string> CreateStatusDictionary(List<StopPoints> stopPoints)
        {
            Dictionary<string, string> lineStatusDict = new Dictionary<string, string>();
            foreach (var stopPoint in stopPoints)
            {
                AppendStatusDictionary(stopPoint.GetNext5Buses(), lineStatusDict);
            }
            return lineStatusDict;

        }


        private static Dictionary<string,string> AppendStatusDictionary(List<Bus> buses, Dictionary<string,string> lineStatusDict)
        {
            
            string ids = "";
            foreach (var bus in buses)
            {
                ids += bus.lineId + ",";
            }
            
            string resource = @"Line/" + ids + "/Status?app_id=731f9517&app_key= 54b0b22e2a48aea8cb6e465f09897657";
            IRestResponse response = URLManager.GetAPIResponse(@"https://api.tfl.gov.uk", resource);
            try
            {
                var apiResponse = JsonConvert.DeserializeObject<List<LinseStatusAPIWrapper>>(response.Content);

                foreach (var apiWrapper in apiResponse)
                {
                    foreach (var lineStatus in apiWrapper.lineStatuses)
                    {
                        if (!lineStatusDict.ContainsKey(apiWrapper.id))
                        {
                            lineStatusDict.Add(apiWrapper.id, lineStatus.statusSeverityDescription);
                        }
                    }
                }
            }
            catch
            {

            }


            return lineStatusDict;

        }

    }
}
