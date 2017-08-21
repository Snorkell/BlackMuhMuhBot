using Discord.Commands;
using Discord.WebSocket;
using System.Reflection;
using System.Threading.Tasks;

namespace BotDiscordMultifunction
{
    public class CommandHandler
    {
        private CommandService Commands { get; set; }
        private DiscordSocketClient Client { get; set; }

        public async Task Install(DiscordSocketClient Client)
        {
            this.Client = Client;
            Commands = new CommandService();

            await Commands.AddModulesAsync(Assembly.GetEntryAssembly());
            Client.MessageReceived += HandleCommand;
        }

        private async Task HandleCommand(SocketMessage Msg)
        {
            var msg = Msg as SocketUserMessage;
            if (msg == null) return;

            int argPos = 0;
            if (!(msg.HasStringPrefix("µ", ref argPos) || msg.HasMentionPrefix(Client.CurrentUser, ref argPos))) return;

            var context = new CommandContext(Client, msg);
            var result = await Commands.ExecuteAsync(context, argPos);

            if (!result.IsSuccess) await context.Channel.SendMessageAsync(result.ErrorReason + "Type µhelp to get all the commands" );
        }
    }
}
