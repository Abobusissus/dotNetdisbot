using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using System.IO;
using HtmlAgilityPack;
using Microsoft.VisualBasic;
using System.Security.Cryptography;

using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Dsbotest
{
    class Program
    {


        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            DiscordSocketClient client;

            var config = new DiscordSocketConfig()
            {
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
            };

            client = new DiscordSocketClient(config);
            client.MessageReceived += CommandsHandler;
            client.Log += Log;
            client.MessageReceived += Parse;
            var token = "";
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            Console.ReadKey();
            

        }
        private  Task CommandsHandler(SocketMessage msg)
        {
            if (msg.ToString() == "!kega")
            {
                msg.Channel.SendMessageAsync("https://tenor.com/view/dog-gif-22760545");
            }
            if (msg.ToString() == "!info")
            {
                msg.Channel.SendMessageAsync(" N/A bot v 0.1");
            }
            if (msg.ToString() == "!roll")
            {
                var rnd = new Random();
                var rand = rnd.Next(0, 100);
                msg.Channel.SendMessageAsync((msg.Author as SocketGuildUser).Nickname.ToString() + " rolled "  + rand.ToString());
                
            }
            

                return Task.CompletedTask;
            

        }

        private async Task Parse(SocketMessage msg)
        {
            if (msg.ToString() == "!anek")
            {
                msg.Channel.SendMessageAsync("wait pls");
                var rnd = new Random();
                var rand = rnd.Next(1, 1142);
                var client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36");
                var html = await client.GetStringAsync("https://baneks.ru/"+rand.ToString());
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                var anek = doc.DocumentNode.SelectSingleNode("//p").InnerText;
                    
                msg.Channel.SendMessageAsync(anek.ToString());

            }
            
        }
       
        private Task Log(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }



    }
}
