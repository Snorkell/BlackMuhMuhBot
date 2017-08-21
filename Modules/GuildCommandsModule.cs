using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using BotDiscordMultifunction.Cfg;
using System.Web.Script.Serialization;
using BotDiscordMultifunction.DeserializedDataObject;

namespace BotDiscordMultifunction.Modules
{
    public class GuildCommandsModule : ModuleBase<ICommandContext>
    {
        [Command("gpo", RunMode = RunMode.Async)]
        private async Task GetPoFromGuild()
        {
            var data = APIsModules.GW2DataQuery.GetDataFromUrl($"https://api.guildwars2.com/v2/guild/{Settings.GuildId}/stash?access_token={Settings.ApiKey}", ',');
            int TotalCurrency = DataObject.GW2GuildInfo.Gw2CurrencyStatus(data);
            int Po = TotalCurrency / 10000;
            int Pa = TotalCurrency / 100 % 100;
            int Pc = TotalCurrency % 100;
            var eb = new EmbedBuilder();
            eb.Title = "Guild currency status";
            eb.AddInlineField("Po: ", Po.ToString());
            eb.AddInlineField("Pa: ", Pa.ToString());
            eb.AddInlineField("Pc: ", Pc.ToString());
            eb.ThumbnailUrl ="http://gallery.yopriceville.com/var/albums/Free-Clipart-Pictures/Money.PNG/Gold_Coins_Treasure_Chest_PNG_Clipart_Picture.png?m=1399672800";
            await Context.Channel.SendMessageAsync("", false, eb);
        }
        [Command("rank", RunMode = RunMode.Async)]
        private async Task GetRole()
        {
            var data = APIsModules.GW2DataQuery.GetDataFromUrl($"https://api.guildwars2.com/v2/guild/{Settings.GuildId}/ranks?access_token={Settings.ApiKey}", '}');
            string roles = DataObject.GW2GuildInfo.Gw2AvaibleRank(data);
            var eb = new EmbedBuilder();
            eb.Title = "Rang de la guilde :";
            eb.Description = roles;
            await Context.Channel.SendMessageAsync("", false, eb);
        }
        [Command("rank", RunMode = RunMode.Async)]
        private async Task GetRole([Remainder]string specifiedRole)
        {
            int Index = 0;
            string roleTitle = null;
            var data = APIsModules.GW2DataQuery.GetDataFromUrl($"https://api.guildwars2.com/v2/guild/{Settings.GuildId}/ranks?access_token={Settings.ApiKey}", '}');
            string roles = DataObject.GW2GuildInfo.Gw2GetInfoFromSpecifiedRank(data,specifiedRole);
            var eb = new EmbedBuilder();
            eb.Description = roles.Replace('[', ' ').Replace("\n", "").Replace("   ", " ").Replace("  ],", "").Replace("\"icon\"", "").Replace(" ", "\n");
            eb.Title = ("Permission du rang");
            await Context.Channel.SendMessageAsync("", false ,eb);
        }
        [Command("GMembers", RunMode = RunMode.Async)]
        private async Task ShowMembersInfo()
        {
            var data = APIsModules.JsonQuery.GetDataFromUrl($"https://api.guildwars2.com/v2/guild/{Settings.GuildId}/members?access_token={Settings.ApiKey}");
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<GuildMembers> listMemebers = (List<GuildMembers>)javaScriptSerializer.Deserialize(data, typeof(List<GuildMembers>));
            var eb = new EmbedBuilder();
            eb.AddInlineField("Name :", "Rank:");
            foreach(GuildMembers Members in listMemebers)
            {
                eb.AddInlineField(Members.Name, Members.Rank);
            }
            eb.Title = "Membres de Black Muh Muh";
            await Context.Channel.SendMessageAsync("", false, eb);
        }
        [Command("GUpgrades", RunMode = RunMode.Async)]
        private async Task ShowUnlockedUpgrades()
        {
            //Call Desarializer
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            //Get two Json string, one with the unlocked upgrade and one with the upgrade info by id(so I need a loop)
            var AvaibleUpgradeById = APIsModules.JsonQuery.GetDataFromUrl($"https://api.guildwars2.com/v2/guild/upgrades/");
            var UnlockedUpgrade = APIsModules.JsonQuery.GetDataFromUrl($"https://api.guildwars2.com/v2/guild/{Settings.GuildId}/upgrades?access_token={Settings.ApiKey}");
            string[] UpgradeId = UnlockedUpgrade.Replace("[", null).Replace("]", "").Replace("\n","").Replace("  ", "").Split(',');
            //await Context.Channel.SendMessageAsync($"https://api.guildwars2.com/v2/guild/upgrades/{UpgradeId[0]}");
            string JsonStringFromAvaibleUpgradeById= null;
            foreach(string id in UpgradeId)
            {
                JsonStringFromAvaibleUpgradeById = JsonStringFromAvaibleUpgradeById + APIsModules.JsonQuery.GetDataFromUrl($"https://api.guildwars2.com/v2/guild/upgrades/{id}?lang=fr")+",\n";
            }
            JsonStringFromAvaibleUpgradeById = "[\n\t" + JsonStringFromAvaibleUpgradeById.Remove(JsonStringFromAvaibleUpgradeById.Length-2) + "\n]";
            byte[] bytes = Encoding.Default.GetBytes(JsonStringFromAvaibleUpgradeById);
            JsonStringFromAvaibleUpgradeById = Encoding.UTF8.GetString(bytes);
            List<GuildUpgrades> listunlock = (List<GuildUpgrades>)javaScriptSerializer.Deserialize(JsonStringFromAvaibleUpgradeById, typeof(List<GuildUpgrades>));
            var eb = new EmbedBuilder();
            eb.Title = "Upgrades de guilde débloquées: ";
            string listOfUpgrade = null;
           foreach(GuildUpgrades upgrade in listunlock)
            {
                listOfUpgrade = listOfUpgrade + upgrade.name + "\n";
            }
            eb.Description = listOfUpgrade;
            await Context.Channel.SendMessageAsync("", false, eb);

        } 
    }
}
