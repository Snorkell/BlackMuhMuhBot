using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using GW2NET.V1.Guilds;
using System;

namespace BotDiscordMultifunction.Modules
{
    public class PrimeGuildWarsModule : ModuleBase<ICommandContext>
    {
        
        [Command("prime", RunMode = RunMode.Async)]
        private async Task ShowPrimeUrl()
        {
            var emb = new EmbedBuilder();
            emb.Title = "Liste des primes";
            emb.Color = Color.Gold;

            emb.Description = "1. 6 - RUS\n" +
                "2. André \"Sauvage\" Douest\n" +
                "3. Big Mayana\n" +
                "4. Bwikki le rat de bibliothèque\n" +
                "5. Brekkabek\n" +
                "6. Chamane Arderus\n" +
                "7. Croisée Michiele\n" +
                "8. \"Adjointe\" Brooke\n" +
                "9. Komali Micui\n" +
                "10. Poobadoo\n" +
                "11. Prisonnière 1141\n" +
                "12. Félix Colairik\n" +
                "13. Sotzz le voyou\n" +
                "14. Tarban le Diplomate\n" +
                "15. Teesa la Louche\n" +
                "16. Tricksy Trekksa\n" +
                "17. Trillia Mylieu\n" +
                "18. Yanonka la palefrenière de rats\n\n\nEntrez \"µprime n°\" pour obtenir des détails sur la prime";
            await Context.Channel.SendMessageAsync("", false, emb);
        }
        [Command("prime", RunMode = RunMode.Async)]
        private async Task ShowPrimeUrl([Remainder]string primeName)
        {
            primeName = primeName.ToLower();
            string[] split = primeName.Split(' ');
            primeName = split[0];
            var eb = new EmbedBuilder();
            //string AbsoluteLink = "http://guildwars2.fureur.org/dossier/guild-wars-2-guide-gw2-les-missions-de-guilde-chasseur-de-prime";
            switch (primeName)
            {
                case "6-rus" :
                case "1":
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6513/public/Guild_Wars_2/GW2_Articles/gw2-2-mult-guild-bounty.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6514/public/Guild_Wars_2/GW2_Articles/gw2-2-mult-guild-bounty-timberline-falls-pathing-map.jpg";
                    eb.Title = "6-RUS";
                    eb.Color = Color.DarkPurple;
                    eb.Description = "Golem météo prototype défectueux. Rajouté lors du dernier patch. Mécanique de combat: " +
                        "Tous les 25 % 6 - RUS deviens invulnérable, s'arrête et étend son bras et effectue une attaque tourbillon" +
                        " qui fait apparaitre des étincelles, celles-ci infligeant entre 1000 et 1200 points de dommages. Il faut tuer" +
                        " ces étincelles, et parler ensuite avec elles pour les renvoyer vers le robot, afin de détruire son buff d'invulnérabilité.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    //await Context.Channel.SendMessageAsync($"Info de la Prime de 6-RUS: {AbsoluteLink}+#2-MULT");
                    await Context.Message.DeleteAsync();
                    break;
                case "andré":
                case "2":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6516/public/Guild_Wars_2/GW2_Articles/gw2-ander-wildman-westward-guild-bounty-4.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6517/public/Guild_Wars_2/GW2_Articles/gw2-ander-wildman-westward-guild-bounty-5.jpg";
                    eb.Title = "André \"Sauvage\" Douest";
                    eb.Description = "Recherché pour le trafic d'animaux exotiques. Soupçonné de déranger les karkas dans leur habitat insulaire.André " +
                        "\"Sauvage\" est piégé à l'intérieur d'un Karka vétéran, que vous pourrez reconnaître au fait qu'il fait des bruits bizarres.Localier" +
                        " \"Wildman\" n'est pas compliqué, à condition de garder deux choses à l'esprit. La plupart des Karkas vétérans sont dans le petit cercle blanc," +
                        " donc c'est là que vous devriez chercher en priorité. Arrêtez-vous près de chaque karka vétéran et vérifiez s'il fait des bruits étranges" +
                        " ou s'il a une bulle de dialogue. Si vous ne le trouvez pas dans ce cercle, alors il faudra vérifier les autres karkas vétérans de l'île." +
                        " Le reste de l'île étant hors de l'habitat \"naturel\" des karkas, un karka vétéran qui y traînerait aura de fortes chances d'être celui que vous cherchez.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    //await Context.Channel.SendMessageAsync($"Info de la Prime de André “Sauvage” Douest: {AbsoluteLink}+#Ander%20Westward");
                    await Context.Message.DeleteAsync();
                    break;
                case "mayana":
                case "3":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6520/public/Guild_Wars_2/GW2_Articles/gw2-big-mayana-guild-bounty-sparkfly-fen-3.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6521/public/Guild_Wars_2/GW2_Articles/gw2-big-mayana-guild-bounty-sparkfly-fen-map.jpg";
                    eb.Title = "Big Mayana";
                    eb.Description = "Hylek vorace recherché pour interrogatoire après un empoisonnement récent." +
                        "Il faut recherche des arbres suspects dans le marais.Attention, la carte ci - dessous ne reprend pas tous les" +
                        " emplacements possibles.Dans le marais vous pourrez interagir avec tous les arbres spécifiques à la quête de prime," +
                        " mais rien ne se passera tant que la dit quête ne sera pas lancée...Mécanique de combat: Big Mayana va avaler quelqu'un" +
                        " au hasard (beurk), mais si vous êtes assez loin il semblerait que vous ne serez pas concernés. Faites donc principalement" +
                        " de l'attaque à distance.Si par malchance vous vous retrouvez dans son gosier, un bouton spécifique apparaîtra, il faudra le spam !Il est recommandé du fait à plus de 5 joueurs.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    //await Context.Channel.SendMessageAsync($"Info de la Prime de Big Mayana: {AbsoluteLink}+#Big%20Mayana");
                    await Context.Message.DeleteAsync();
                    break;
                case "bwikki":
                case "4":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://dulfy.net/wp-content/uploads/2013/02/gw2-bookworm-bwikki-guild-bounty-2_thumb.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6525/public/Guild_Wars_2/GW2_Articles/gw2-bookworm-bwikki-guild-bounty-pathing-map-resized1.jpg";
                    eb.Title = "Bwikki le rat de bibliothèque";
                    eb.Description = "Recherché pour non-restitution de livres, vandalisme sur ces derniers et non-paiement de diverses amendes de bibliothèques. A dernièrement été aperçu fuyant une bibliothèque dans la neige. N'attaquez pas Bwikki lorsqu'il a son aura de Givre. Il vous infligera un Givre qui durera 20 secondes, et comme il est immunisé à vos dégâts lorsque vous êtes sous Givre, autant éviter ! Arrêtez simplement de l'attaquer lorsque vous voyez l'icône du buff apparaître.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    // await Context.Channel.SendMessageAsync($"Info de la Prime de Bwikki Le rat de bibliothèque: {AbsoluteLink}+#Bookworm%20Bwikki");
                    await Context.Message.DeleteAsync();
                    break;
                case "brekkabek":
                case "5":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6528/public/Guild_Wars_2/GW2_Articles/gw2-brekkabek-guild-bounty-2.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6529/public/Guild_Wars_2/GW2_Articles/gw2-brekkabekguild-bounty.jpg";
                    eb.Title = "Brekkabek";
                    eb.Description = "Recherché pour détention illégale d'un ours comme animal domestique. A été vu pour la dernière fois en train de fuir d'un campement Harathi sous la protection d'autres Skritts.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    // await Context.Channel.SendMessageAsync($"Info de la Prime de Brekkabek: {AbsoluteLink}+#Brekkabek");
                    await Context.Message.DeleteAsync();
                    break;
                case "arderus":
                case "6":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6553/public/Guild_Wars_2/GW2_Articles/shaman_arderus.png";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6554/public/Guild_Wars_2/GW2_Articles/gw2-shaman-arderus-guild-bounty.jpg";
                    eb.Title = "Chamane Arderus";
                    eb.Description = "Le chamans rebel Arderus est recherché pour la valeur des informations qu'il détient. Reporté comme errant dans les plaines près de la forêt brûlante.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    // await Context.Channel.SendMessageAsync($"Info de la Prime de Chamanr Arderus: {AbsoluteLink}+#Shaman%20Arderus");
                    await Context.Message.DeleteAsync();
                    break;
                case "michiele":
                case "7":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6531/public/Guild_Wars_2/GW2_Articles/gw2-crusader-michiele-guild-bounty-2.png";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6532/public/Guild_Wars_2/GW2_Articles/gw2-crusader-michiele-guild-bounty-sparkfly-fen-pathing-map.jpg";
                    eb.Title = "Croisée Michiele";
                    eb.Description = "Recherchée pour désertion, avoir semé la panique et mordu un officier supérieur. Signalée comme errant dans le royaume côtier du dragon mort-vivant Sans-Soleil.Elle suit son chemin dans le sens des aiguilles d'une montre mais il lui arrive de le remonter dans le sens inverse. Voici la carte de son sentier ";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    // await Context.Channel.SendMessageAsync($"Info de la Prime de Croisée Michiele: {AbsoluteLink}+#Crusader%20Michiele");
                    await Context.Message.DeleteAsync();
                    break;
                case "brooke":
                case "8":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6534/public/Guild_Wars_2/GW2_Articles/gw2-deputy-brooke-guild-bounty-2.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6535/public/Guild_Wars_2/GW2_Articles/gw2-deputy-brooke-guild-bounty-snowden-drifts-pathing-map.jpg";
                    eb.Title = "\"Adjointe\" Brooke";
                    eb.Description = "Recherché pour s'être faite passer pour un agent de la Garde du Lion. A été vue pour la dernière fois dans le Détour d'Antreneige en train de harceler des voyageurs.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    // await Context.Channel.SendMessageAsync($"Info de la Prime de \"Adjointe\" Brooke: {AbsoluteLink}+#Deputy%20Brooke");
                    await Context.Message.DeleteAsync();
                    break;
                case "komali":
                case "9":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6543/public/Guild_Wars_2/GW2_Articles/gw2-half-baked-komali-guild-bounty-2.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6545/public/Guild_Wars_2/GW2_Articles/gw2-half-baked-komali-guild-bounty-mount-maelstrom-map-updated.jpg";
                    eb.Title = "Komali Micui";
                    eb.Description = "Recherché pour mise en danger d'autrui et expérimentation géomantique non-autorisée, y compris l'immersion d'un ingénieur de l'Enqueste dans un bassin de lave. Komali dispose d'un bouclier de feu qui le rend extrêmement résistant aux dégâts et gagne un stack de pouvoir à chaque fois que quelqu'un l'attaque. Servez-vous des compétences appropriées afin de supprimez ses buffs de pouvoir et de stabilité, puis une fois la stabilité disparue utilisez des knockbacks pour le faire sortir de son cercle ce qui lui fera perdre son bouclier. Une fois le bouclier supprimé, il tombe rapidement. Il est aussi capable de soigner ses debuffs assez rapidement.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    // await Context.Channel.SendMessageAsync($"Info de la Prime de Komali Micui: {AbsoluteLink}+#Hal%20Baked%20Komali");
                    await Context.Message.DeleteAsync();
                    break;
                case "poobadoo":
                case "10":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6547/public/Guild_Wars_2/GW2_Articles/gw2-poobadoo-guild-bounty-kessex-hills.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6548/public/Guild_Wars_2/GW2_Articles/gw2-poobadoo-guild-bounty-kessex-hills-pathing-map.jpg";
                    eb.Title = "Poobadoo";
                    eb.Description = "Recherché suite à de multiples plaintes pour harcèlement et nuisance publique. A été aperçu pour la dernière fois en train d'ennuyer des marchands Tengu à leur campement.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    // await Context.Channel.SendMessageAsync($"Info de la Prime de Poobadoo: {AbsoluteLink}+#Poobadoo");
                    await Context.Message.DeleteAsync();
                    break;
                case "prisonnier":
                case "11":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6550/public/Guild_Wars_2/GW2_Articles/gw2-prisoner-1141-guild-bounty-2.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6551/public/Guild_Wars_2/GW2_Articles/gw2-prisoner-1141-guild-bounty-pathing-map-3-resized.jpg";
                    eb.Title = "Prisonnière 1141";
                    eb.Description = "Cette fugitive s'est évadée de la prison de Scourgejaw Vault, une carrière-prison de la Légion de Fer. La cible a réussi jusqu'ici à déjouer toutes les tentatives des autorités pour le capturer. Ce PNJ courre à toute vitesse et contrairement aux autres qui se déplacent en marchant.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    // await Context.Channel.SendMessageAsync($"Info de la Prime de Prisonnière 1141: {AbsoluteLink}+#Prisonnier%201141");
                    await Context.Message.DeleteAsync();
                    break;
                case "félix":
                case "12":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6556/public/Guild_Wars_2/GW2_Articles/gw2-short-fuse-felix-guild-bounty-diessa-plateau-2.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6557/public/Guild_Wars_2/GW2_Articles/gw2-short-fuse-felix-guild-bounty-diessa-plateau-map.jpg";
                    eb.Title = "Félix Colairik";
                    eb.Description = "Recherché dans le cadre de plusieurs procès pour dégradation de propriété. A été vue pour la dernière fois se comportant aggressivement à la Fête de la Viande.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    // await Context.Channel.SendMessageAsync($"Info de la Prime de Félix Colairik: {AbsoluteLink}+#Short-Fuse%20Felix");
                    await Context.Message.DeleteAsync();
                    break;
                case "sotzz":
                case "13":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "https://wiki.guildwars2.com/images/thumb/3/38/Sotzz_the_Scallywag.jpg/200px-Sotzz_the_Scallywag.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6559/public/Guild_Wars_2/GW2_Screenshots_Concours/gw2-sotzz-the-scallywag-guild-bounty-map-6.jpg";
                    eb.Title = "Sotzz le voyou";
                    eb.Description = "Recherché pour vol, ivresse sur la voie publique et impolitesse. La cible est connue pour \"s'imprégner\" dans des tonneaux de bière volés dans la région autour de l'Arche du Lion. Note : Il est probablement caché dans un tonneau aux endroits marqués. Vérifiez tous les tonneaux aux endroits en question pour être sûr. Sotzz est immunisé aux dégâts tant que vous ne l'aurez pas éjecté hors du champ alcolisé qu'il créé sous ses pieds.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    // await Context.Channel.SendMessageAsync($"Info de la Prime de Sotzz le voyou: {AbsoluteLink}+#Sotzz");
                    await Context.Message.DeleteAsync();
                    break;
                case "tarban":
                case "14":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6540/public/Guild_Wars_2/GW2_Articles/gw2-diplomat-tarban-guild-bounty.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6541/public/Guild_Wars_2/GW2_Articles/gw2-diplomat-tarban-guild-bounty-2.jpg";
                    eb.Title = "Tarban le Diplomate";
                    eb.Description = "Recherché pour s'être fait passer pour un ambassadeur. Soupçonné de négociations frauduleuses avec le royaume skritt local. Il lui faut 1h30 pour faire la boucle complète, dans le sens des aiguilles d'une montre.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    // await Context.Channel.SendMessageAsync($"Info de la Prime de Diplomat Tarban: {AbsoluteLink}+#Diplomat%20Tarban");
                    await Context.Message.DeleteAsync();
                    break;
                case "teesa":
                case "15":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6537/public/Guild_Wars_2/GW2_Articles/gw2-devious-teesa-guild-bounty-2.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6538/public/Guild_Wars_2/GW2_Articles/gw2-devious-teesa-guild-bounty-3.jpg";
                    eb.Title = "Teesa la Louche";
                    eb.Description = "Recherchée pour vol, tentative de meurtre et informations incorrectes sur le formulaire 12.21-D. A été vue récemment entrant dans une caverne pleins de Draguerre par une patrouille Kodan. Teesa dispose d'un grappin semblable à celui du Lieutenant Kholer avant la modification des Catacombes Ascaloniennes. Il est recommandé d'être au moins 5 ou 6 avant d'engager le combat.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    // await Context.Channel.SendMessageAsync($"Info de la Prime de Devious Teesa: {AbsoluteLink}+#Devious%20Teesa");
                    await Context.Message.DeleteAsync();
                    break;
                case "tricksy":
                case "16":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6561/public/Guild_Wars_2/GW2_Articles/gw2-weird-wind-rider-guild-bounty.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6562/public/Guild_Wars_2/GW2_Articles/gw2-curious-cow-guild-bounty-pathing-map-resized.jpg";
                    eb.Title = "Tricksy Trekksa";
                    eb.Description = "Autoproclamée maîtresse de l'art du déguisement, elle est recherchée pour détention d'information. Des rapports indiquant des créatures postées à des lieux inhabituels pourraient constituer une piste. Notez que Tricksy peut se déguiser en méduse flottante, en vache, en moa ou en cochon !Le sentier suivi sera le même par contre et la forme adoptée sera purement aléatoire. Voici le sentier en question, par Ezmode. N'oubliez pas que Trekksa peut se cacher en méduse, vache, moa ou cochon ! Très important : parfois, Trekksy peut apparaître en dehors de son sentier et se retrouver dans la portion ouest de sa zone, donc n'hésitez pas à envoyer quelqu'un regarder en plus d'inspecter le sentier.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    // await Context.Channel.SendMessageAsync($"Info de la Prime de : {AbsoluteLink}+#Trillia%20Midwell \n (le site étant codé avec le cul le lien ne fonctionne pas pour cette prime, ce lien dirige vers la prime suivante. Il vout suffit de scroller vers le haut");
                    await Context.Message.DeleteAsync();
                    break;
                case "trillia":
                case "17":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6564/public/Guild_Wars_2/GW2_Articles/gw2-trillia-midwell-guild-bounty-2.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6565/public/Guild_Wars_2/GW2_Articles/gw2-trillia-midwell-guild-bounty-fields-of-ruin-map.jpg";
                    eb.Title = "Trillia Mylieu";
                    eb.Description = "Recherchée pour être interrogée sur des attaques contre des marchands charrs participant aux pourparlers de paix à Noirfaucon. Soupçonnée d'être une séparatiste. Son sentier traverse les Champs de Ruine. Il est assez court donc il ne devrait pas être difficile de la localiser. Elle fait le tour dans le sens des aiguilles d'une montre.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    // await Context.Channel.SendMessageAsync($"Info de la Prime de Trillia Mylieu: {AbsoluteLink}+#Trillia%20Midwell");
                    await Context.Message.DeleteAsync();
                    break;
                case "yanonka":
                case "18":
                    eb.Color = Color.DarkPurple;
                    eb.ThumbnailUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6567/public/Guild_Wars_2/GW2_Articles/gw2-yanonka-the-rat-wrangler-fields-of-ruin-map-3.jpg";
                    eb.ImageUrl = "http://guildwars2.fureur.org/sites/default/files/media_crop/6568/public/Guild_Wars_2/GW2_Articles/gw2-yanonka-the-rat-wrangler-fields-of-ruin-map.jpg";
                    eb.Title = "Yanonka la palefrenière de rats";
                    eb.Description = "Cet ogre voyou est recherché pour espionnage et sabotage contre les diverses factions présentes dans le Champs de Ruine. Elle est célèbre pour l'utilisation de rats de compagnie pour réaliser ces méfaits. Recherchez des rats suspects, indiqués sur la carte ci-dessous.Tout les emplacements sont notés. Méthode de combat: Yanonka est donc accompagnée de nombreux rats, qu'il faut éviter de frapper sous peine de vous faire attaquer par eux. Il faut donc uniquement utiliser des attaques à cible unique, et focus le PNJ. Faisable en petit groupe.";
                    await Context.Channel.SendMessageAsync("", false, eb);
                    //  await Context.Channel.SendMessageAsync($"Info de la Prime de Yanonka la palefrenière de rats: {AbsoluteLink}+#Yanonka");
                    await Context.Message.DeleteAsync();
                    break;
                default:
                    await Context.Channel.SendMessageAsync($"Verifiez l'orthogrpahe du nom indiqué, ou entre \"µprime\"pour conntaitre l'index de la prime désirée");
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
