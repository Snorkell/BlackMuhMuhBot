using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BotDiscordMultifunction.APIsModules
{
    public class JsonQuery 
    {
        public static string GetDataFromUrl(string url)
        {
            try
            {
                using (var wb = new WebClient())
                {
                    var response = wb.DownloadString(url);
                    return response;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
