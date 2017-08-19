using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BotDiscordMultifunction.Modules
{
    public class OwPofile : ModuleBase<ICommandContext>
    {
        [Command("owplinks", RunMode = RunMode.Async), Summary("Find the Overbuff/BattleNetArmory profile of a specified player (Warning: Case sensitive)")]
        private async Task OverwatchPlayer([Remainder]string battleTag)
        {
            if (!battleTag.Contains('#'))
            {
                await Context.Channel.SendMessageAsync("Please enter a valid format of BattleTag");
            }
            else
            {
                string Btag = battleTag.Replace('#', '-');
                await Context.Channel.SendMessageAsync($"OverBuff: https://www.overbuff.com/players/pc/{Btag} \n BattleNet Armory: https://playoverwatch.com/fr-fr/career/pc/eu/{Btag}");
                await Context.Message.DeleteAsync();
            }
        }
        [Command("owp", RunMode = RunMode.Async), Summary("Find the Overbuff/BattleNetArmory profile of a specified player (Warning: Case sensitive)")]
        private async Task profileDataFromnameToUrl(string region, string battleTag)
        {
            region = region.ToLower();
            if (!battleTag.Contains('#'))
            {
                await Context.Channel.SendMessageAsync("Please enter a valid format of BattleTag");
            }
            else if (region != "eu" && region != "us" || region == string.Empty)
            {
                await Context.Channel.SendMessageAsync("Please enter region");
            }
            else
            {
                battleTag = battleTag.Replace("#", "-");
                var data = APIsModules.OverwatchDataQuery.GetDataFromUrl("http://ow-api.herokuapp.com/profile/pc/" + region + "/" + battleTag);
                if (data == null)
                {
                    await Context.Channel.SendMessageAsync("Can't find user, please check the BattleTag (Warning: Case sensitive!)");
                }
                else
                {
                    var eb = new EmbedBuilder();
                    eb.Title = DataObject.OverwatchPlayerInfo.NameFrom(data);
                    eb.ThumbnailUrl = DataObject.OverwatchPlayerInfo.portraitUrlFrom(data);
                    eb.AddInlineField("Quickplay:", "Won: " + DataObject.OverwatchPlayerInfo.QPFrom(data));
                    eb.AddField("Ranked", "Stats :", false);
                    eb.AddInlineField("Won :", DataObject.OverwatchPlayerInfo.rankedWonFrom(data));
                    eb.AddInlineField("Loose :", DataObject.OverwatchPlayerInfo.rankedLooseFrom(data));
                    eb.AddInlineField("Draw :", DataObject.OverwatchPlayerInfo.rankedDrawFrom(data));
                    eb.AddInlineField("Played :", DataObject.OverwatchPlayerInfo.rankedPlayFrom(data));
                    eb.AddInlineField("Current SR", DataObject.OverwatchPlayerInfo.rankFrom(data));
                    eb.ImageUrl = DataObject.OverwatchPlayerInfo.rankUrlFrom(data);
                    await Context.Channel.SendMessageAsync("", false, eb);
                } 
            }
        }
    }
}
