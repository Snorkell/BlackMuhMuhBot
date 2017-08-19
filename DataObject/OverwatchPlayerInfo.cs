using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscordMultifunction.DataObject
{
    public class OverwatchPlayerInfo
    {
        
        public static string NameFrom(string[] splitStringOfDatas)
        {
            return splitStringOfDatas[0].Replace("{\"username\":\"", "").Replace("\"","");
        }
        public static string levelFrom(string[] splitStringOfDatas)
        {
            return splitStringOfDatas[1].Replace("\"level\":", "");
        }
        public static string portraitUrlFrom(string[] splitStringOfDatas)
        {
            return splitStringOfDatas[2].Replace("\"portrait\":\"", "").Replace("\"","");
        }
        public static string QPFrom(string[] splitStringOfDatas)
        {
            return splitStringOfDatas[3].Replace("\"games\":{\"quickplay\":{\"won\":", "").Replace("}", "");
        }
        public static string rankedWonFrom(string[] splitStringOfDatas)
        {
            return splitStringOfDatas[4].Replace("\"competitive\":{\"won\":", "");
        }
        public static string rankedLooseFrom(string[] splitStringOfDatas)
        {
            return splitStringOfDatas[5].Replace("\"lost\":", "");
        }
        public static string rankedDrawFrom(string[] splitStringOfDatas)
        {
            return splitStringOfDatas[6].Replace("\"draw\":", "");
        }
        public static string rankedPlayFrom(string[] splitStringOfDatas)
        {
            return splitStringOfDatas[7].Replace("\"played\":", "").Replace("}}", "");
        }
        public static string rankFrom(string[] splitStringOfDatas)
        {
            return splitStringOfDatas[10].Replace("\"competitive\":{\"rank\":", "");
        }
        public static string rankUrlFrom(string[] splitStringOfDatas)
        {
            return splitStringOfDatas[11].Replace("\"rank_img\":\"", "").Replace("\"}", "");
        }
    }
}
