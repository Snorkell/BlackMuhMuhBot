using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BotDiscordMultifunction.Cfg
{
    public class Settings
    {
        public static string Token { get; set; } = null;
        public static string ApiKey { get; set; } = null;
        public static string GuildId { get; set; } = null;
        public Settings()
        {
            List<string> privateData = new List<string>();
            string line = null;
            using (StreamReader sr = new StreamReader(@"cfg.txt"))
            {
                while((line = sr.ReadLine())!= null)
                {
                    privateData.Add(line.Replace("Token=", null).Replace("ApiKey=", null).Replace("GuildId=", null));
                }
            }
            Token = privateData[0];
            ApiKey = privateData[1];
            GuildId = privateData[2];
        }
    }
}
