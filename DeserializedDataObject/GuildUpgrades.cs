using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscordMultifunction.DeserializedDataObject
{
    public class GuildUpgrades
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int build_time { get; set; }
        public string icon { get; set; }
        public string type { get; set; }
        public int required_level { get; set; }
        public int experience { get; set; }
        public object[] prerequisites { get; set; }
        public GuildUpgradeCosts[] costs { get; set; }
    }

    public class GuildUpgradeCosts
    {
        public string type { get; set; }
        public int count { get; set; }
        public string name { get; set; }
        public int item_id { get; set; }
    }

}
