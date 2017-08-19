using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using System.IO;
using System.Collections.Generic;
using BotDiscordMultifunction.Cfg;

namespace BotDiscordMultifunction
{
    
    public class MainBotProgram
    {
        public static bool WantToPissOffEveryone { get; set; } = false;
        static DiscordSocketClient Client;
        static CommandHandler Handler;
        static string Token;
        Settings settings = new Settings();
        public async void connect()
        {
            Token = GetToken();
            Console.WriteLine(Token);
            Console.WriteLine(Settings.ApiKey);
            Console.WriteLine(Settings.GuildId);
            Handler = new CommandHandler();
            Client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Verbose
            });
            await Handler.Install(Client);
            Client.Log += Client_log;
            Client.MessageReceived += Client_MessageRecieved;
            try
            {
                await Client.LoginAsync(TokenType.Bot, Token);
                await Client.StartAsync();
            }
            catch
            {
                Console.WriteLine("Error occured while connecting your bot", "ERROR");
                return;
            }
            await Task.Delay(-1);
        }

        private async Task Client_MessageRecieved(SocketMessage arg)
        {
            if(WantToPissOffEveryone)
            {
                if (arg.Author.Username.ToString() != "BlackMuhMuh_Bot")
                {
                    var message = arg.Content;
                    char[] whitespace = new char[] { ' ', '\t' };
                    string[] messageTab = message.Split(whitespace);
                    List<string> listOfWord = new List<string>();
                    foreach (var s in messageTab)
                    {
                        if (s.Contains("Di") || s.Contains("di") || s.Contains("Dy") || s.Contains("dy") || s.Contains("DI") || s.Contains("dI") || s.Contains("DY") || s.Contains("dY"))
                        {
                            listOfWord.Add(s);
                        }

                    }
                    string cutMessage = null;
                    foreach (var ss in listOfWord)
                    {
                        cutMessage = cutMessage + " " + ss;
                    }
                    cutMessage = cutMessage.ToLower();
                    await arg.Channel.SendMessageAsync(cutMessage.Replace("di", "").Replace("Di", "").Replace("Dy", "").Replace("dy", ""), true);
                }
            } 
        }

        private Task Client_log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return null;
        }

        private string GetToken()
        {
            return Settings.Token; 
        }
    }
}
