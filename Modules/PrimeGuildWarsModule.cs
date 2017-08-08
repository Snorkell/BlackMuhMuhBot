using Discord.Commands;
using System.Threading.Tasks;

namespace BotDiscordMultifunction.Modules
{
    public class PrimeGuildWarsModule : ModuleBase<ICommandContext>
    {
        [Command("prime", RunMode = RunMode.Async)]
        private async Task ShowPrimeUrl([Remainder]string primeName)
        {
            primeName = primeName.ToLower();
            string[] split = primeName.Split(' ');
            primeName = split[0];
            switch (primeName)
            {
                case "6-rus":
                    await Context.Channel.SendMessageAsync("Info de la Prime de 6-RUS: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#2-MULT");
                    await Context.Message.DeleteAsync();
                    break;
                case "andré":
                    await Context.Channel.SendMessageAsync("Info de la Prime de André “Sauvage” Douest: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Ander%20Westward");
                    await Context.Message.DeleteAsync();
                    break;
                case "mayana":
                    await Context.Channel.SendMessageAsync("Info de la Prime de Big Mayana: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Big Mayana");
                    await Context.Message.DeleteAsync();
                    break;
                case "bwikki":
                    await Context.Channel.SendMessageAsync("Info de la Prime de Bwikki Le rat de bibliothèque: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Bookworm%20Bwikki");
                    await Context.Message.DeleteAsync();
                    break;
                case "brekkabek":
                    await Context.Channel.SendMessageAsync("Info de la Prime de Brekkabek: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Brekkabek");
                    await Context.Message.DeleteAsync();
                    break;
                case "arderus":
                    await Context.Channel.SendMessageAsync("Info de la Prime de Chamanr Arderus: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Shaman%20Arderus");
                    await Context.Message.DeleteAsync();
                    break;
                case "michiele":
                    await Context.Channel.SendMessageAsync("Info de la Prime de Croisée Michiele: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Crusader%20Michiele");
                    await Context.Message.DeleteAsync();
                    break;
                case "brooke":
                    await Context.Channel.SendMessageAsync("Info de la Prime de \"Adjointe\" Brooke: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Deputy%20Brooke");
                    await Context.Message.DeleteAsync();
                    break;
                case "komali":
                    await Context.Channel.SendMessageAsync("Info de la Prime de Komali Micui: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Hal%20Baked%20Komali");
                    await Context.Message.DeleteAsync();
                    break;
                case "poobadoo":
                    await Context.Channel.SendMessageAsync("Info de la Prime de Poobadoo: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Poobadoo");
                    await Context.Message.DeleteAsync();
                    break;
                case "prisonnier":
                    await Context.Channel.SendMessageAsync("Info de la Prime de Prisonnière 1141: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Prisonnier%201141");
                    await Context.Message.DeleteAsync();
                    break;
                case "félix":
                    await Context.Channel.SendMessageAsync("Info de la Prime de Félix Colairik: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Short-Fuse%20Felix");
                    await Context.Message.DeleteAsync();
                    break;
                case "sotzz":
                    await Context.Channel.SendMessageAsync("Info de la Prime de Sotzz le voyou: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Sotzz");
                    await Context.Message.DeleteAsync();
                    break;
                case "tarban":
                    await Context.Channel.SendMessageAsync("Info de la Prime de Diplomat Tarban: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Diplomat%20Tarban");
                    await Context.Message.DeleteAsync();
                    break;
                case "teesa":
                    await Context.Channel.SendMessageAsync("Info de la Prime de Devious Teesa: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Devious%20Teesa");
                    await Context.Message.DeleteAsync();
                    break;
                case "tricksy":
                    await Context.Channel.SendMessageAsync("Info de la Prime de : http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Trillia%20Midwell \n (le site étant codé avec le cul le lien ne fonctionne pas pour cette prime, ce lien dirige vers la prime suivante. Il vout suffit de scroller vers le haut");
                    await Context.Message.DeleteAsync();
                    break;
                case "trillia":
                    await Context.Channel.SendMessageAsync("Info de la Prime de Trillia Mylieu: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Trillia%20Midwell");
                    await Context.Message.DeleteAsync();
                    break;
                case "yanonka":
                    await Context.Channel.SendMessageAsync("Info de la Prime de Yanonka la palefrenière de rats: http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime#Yanonka");
                    await Context.Message.DeleteAsync();
                    break;
                default:
                    await Context.Channel.SendMessageAsync("Verifiez l'orthogrpahe du nom indiqué, sinon n'entrez que le prénom de la prime");
                    break;

            }
        }
        [Command("bus", RunMode = RunMode.Async)]
        private async Task DisplayBus()
        {
            await Context.Channel.SendMessageAsync("Bus Vanilla: http://www.lebusmagique.fr/pages/outils-gw2/les-world-boss.html \nBus HoT: http://www.lebusmagique.fr/pages/outils-gw2/timer-wb-et-hot.html");
        }
        [Command("map", RunMode = RunMode.Async)]
        private async Task displayMap()
        {
            await Context.Channel.SendMessageAsync("Map: http://www.lebusmagique.fr/medias/files/map3713.html");
        }
        [Command("wiki", RunMode = RunMode.Async)]
        private async Task wiki([Remainder]string keyWord)
        {

            await Context.Channel.SendMessageAsync($"Wiki: https://wiki-fr.guildwars2.com/index.php?title=Sp%C3%A9cial%3ARecherche&profile=default&fulltext=Search&search={keyWord.Replace(" ", "+")}");
        }
    }
}
