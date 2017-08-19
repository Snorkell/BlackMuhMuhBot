using System;
using System.Net;

namespace BotDiscordMultifunction.APIsModules
{
    public class GW2DataQuery
    {
        public static string[] GetDataFromUrl(string url, char splitChar)
        {
            string data;
            try
            {
                using (var wb = new WebClient())
                {
                    var response = wb.DownloadString(url);
                    data = response;
                }
                string[] splitStringOfDatas = data.Split(splitChar);
                return splitStringOfDatas;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
    }
}
