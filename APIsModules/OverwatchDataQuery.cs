using System;
using System.Net;
using Discord.Commands;

namespace BotDiscordMultifunction.APIsModules
{
    public class OverwatchDataQuery
    {

        public static string[] GetDataFromUrl(string url)
        {
            string data;
            try
            {
                using (var wb = new WebClient())
                {
                    var response = wb.DownloadString(url);
                    data = response;
                }
                string[] splitStringOfDatas = data.Split(',');
                return splitStringOfDatas;
            }
            catch 
            {
                return null; 
            }
            

        }
    }
}
