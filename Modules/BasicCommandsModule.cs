using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;

namespace BotDiscordMultifunction.Modules
{
    public class BasicCommandsModule : ModuleBase<ICommandContext>
    {
        [Command("PissOffEveryone", RunMode = RunMode.Async)]
        private async Task LetsPissOffEveryone()
        {
            if (!MainBotProgram.WantToPissOffEveryone)
            {
                MainBotProgram.WantToPissOffEveryone = true;
                await Context.Channel.SendMessageAsync("Je vais vous casser les couilles !!", true);
            }
            else
            {
                MainBotProgram.WantToPissOffEveryone = false;
                await Context.Channel.SendMessageAsync("C'est bon j'arrête", true);
            }
             
        }
        [Command("help", RunMode = RunMode.Async)]
        private async Task SendHelp()
        {
            try
            {
                var eb = new EmbedBuilder();
                eb.Title = "Liste des commandes";
                eb.AddField("Help Audio", "Liste des commande Audio");
                eb.AddInlineField("1. Join <channelAudio>", "Connecte le bot au salon audio précisé en paramètre, si il n'est pas précisé, le connecte au salon dans lequel vous vous trouvez");
                eb.AddInlineField("2. Leave", "Déconnecte le bot du salon audio");
                eb.AddInlineField("3.Addq <youtubeLink>", "Ajoute un musique provenant de youtube a la liste d'attente");
                eb.AddInlineField("4.Showq", "Affiche le contenu de la liste d'attente");
                eb.AddInlineField("5.Clearq", "Vide le contenu de la liste d'attente");
                eb.AddInlineField("6.Play", "Joue le contenu de la liste d'attente dans le salon audio dans lequel le bot est connecté");
                eb.AddInlineField("7.Playrandom", "Joue aléatoirement toutes les musique présente dans le cache musique du bot");
                eb.AddInlineField("8.Skip", "Passe a la musique suivante");
                eb.AddField("Help Overwatch", "Liste des commande Overwatch");
                eb.AddInlineField("1.Owplinks <BattleTag>", "Envoi les liens du profil OverBuff/OverwatchArmory du joueur spécifié (Attention : Sensible a la casse");
                eb.AddInlineField("2.Owp <Region> <BattleTag>", "Montre les statisiques basiques du profil du joueur spécifié (Attention : Sensible a la casse");
                eb.AddField("Help GuildWars 2", "Liste de commande GuildWars 2");
                eb.AddInlineField("1.Prime <NomOuIndexDeLaPrime>", "Affiche les informations de la prime, si aucune prime n'est spécifiée, affiche la liste des primes");
                eb.AddInlineField("2.Bus", "Envoi le lien du site \"Le bus magique\" affichant les timer des Worlds boss et meta Events");
                eb.AddInlineField("3.Map", "Envoi le lien de la DynMap de la Tyrie");
                eb.AddInlineField("4.Wiki <MotClé>", "Envoi un lien de recherche du mot clé sur le Wiki");
                eb.AddInlineField("5.Gpo", "Affiche la solde de la banque de guilde");
                eb.AddInlineField("6.Rank <NomOuIndexDuRang>", "Affiche les permission de guilde du rang, si aucun rang n'est spécifié, affiche la liste des rangs");
                eb.AddInlineField("7.Gmembers", "Affiche la liste des membres de la guilde et leurs rangs");
                eb.AddInlineField("8.Gupgrades", "Affiche la liste des améliorations débloquées par la guilde");
                eb.Color = Color.DarkGreen;
                eb.ThumbnailUrl = ("http://www.freeiconspng.com/uploads/simple-blue-question-mark-icon-9.png");
                await Context.User.SendMessageAsync("", false, eb);
                await Context.Message.DeleteAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
