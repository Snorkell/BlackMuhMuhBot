using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscordMultifunction.DataObject
{
    public class GW2GuildInfo
    {
        public static int Gw2CurrencyStatus(string[] data)
        {
            try
            {
                string Currency = data[2].Replace("\"coins\": ", "");
                //Console.WriteLine(Currency);
                return int.Parse(Currency);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }

        }
        public static string Gw2AvaibleRank(string[] data)
        {
            string listOfRoles = null;
            int i = 1;
            foreach (string s in data)
            {

                int startIndex = s.IndexOf("\"id\": \"");
                int endIndex = s.IndexOf("\",");
                if (startIndex <= 0)
                {
                    break;
                }
                string role = s.Substring(startIndex, endIndex - startIndex).Replace("\"id\": \"", "");
                listOfRoles = listOfRoles +i+". "+ role + ", "+"\n";
                i++;
            }
            return listOfRoles; 
        }
        public static string Gw2GetInfoFromSpecifiedRank(string[] data, string RoleNameOrIndex)//Get array fill with row data/role
        {
            int index = 0;
            if (Int32.TryParse(RoleNameOrIndex, out index))
            {
                try
                {
                    string[] permission = data[index - 1].Split(':');
                    return permission[3].Replace(" [ ", "").Replace(" ],\"icon\"", "");
                }
                catch { return null; }
                
            }
            else
            {
                int IndexOfRoleInArray = 0;
                foreach (string s in data)
                {

                    int startIndex = s.IndexOf("\"id\": \"");
                    int endIndex = s.IndexOf("\",");
                    if (startIndex <= 0)
                    {
                        break;
                    }
                    string role = s.Substring(startIndex, endIndex - startIndex).Replace("\"id\": \"", "");
                    if (RoleNameOrIndex == role)
                    {
                        break;
                    }
                    IndexOfRoleInArray++;
                }
                string[] permission = data[IndexOfRoleInArray].Split(':');
                return permission[3];
            }
            
            
        }
    }
}
