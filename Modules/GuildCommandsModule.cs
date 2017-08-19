using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using BotDiscordMultifunction.Cfg;

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
        [Command("rang", RunMode = RunMode.Async)]
        private async Task GetRole()
        {
            var data = APIsModules.GW2DataQuery.GetDataFromUrl($"https://api.guildwars2.com/v2/guild/{Settings.GuildId}/ranks?access_token={Settings.ApiKey}", '}');
            Console.WriteLine($"https://api.guildwars2.com/v2/guild/{Settings.GuildId}/ranks?access_token={Settings.ApiKey}");
            string roles = DataObject.GW2GuildInfo.Gw2AvaibleRank(data);
            var eb = new EmbedBuilder();
            eb.Title = "Rang de la guilde :";
            eb.Description = roles;
            await Context.Channel.SendMessageAsync("", false, eb);
        }
        [Command("rang", RunMode = RunMode.Async)]
        private async Task GetRole([Remainder]string specifiedRole)
        {
            var data = APIsModules.GW2DataQuery.GetDataFromUrl($"https://api.guildwars2.com/v2/guild/{Settings.GuildId}/ranks?access_token={Settings.ApiKey}", '}');
            string roles = DataObject.GW2GuildInfo.Gw2GetInfoFromSpecifiedRank(data,specifiedRole);
            var eb = new EmbedBuilder();
            eb.Description = roles.Replace('[', ' ').Replace("\n", "").Replace("   ", " ").Replace("  ],", "").Replace("\"icon\"", "").Replace(" ", "\n");
            eb.Title = ("Permission du rôle:");
            await Context.Channel.SendMessageAsync("", false ,eb);
        }
    }
}
