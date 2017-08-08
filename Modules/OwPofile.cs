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
        [Command("owp", RunMode = RunMode.Async), Summary("Find the Overbuff/BattleNetArmory profile of a specified player (Warning: Case sensitive)")]
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
    }
}
