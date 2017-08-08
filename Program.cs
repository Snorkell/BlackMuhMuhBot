using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BotDiscordMultifunction
{
    class Program
    {
        static void Main(string[] args)
        {
            MainBotProgram Bot = new MainBotProgram();
            Bot.connect();
            Console.ReadLine();
            Console.WriteLine("Press any key again to exit .... ");
            Console.ReadLine();
        }
    }
}
