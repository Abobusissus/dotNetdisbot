using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;
using System.Security.Cryptography;

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
            var token = "";
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            Console.ReadKey();

        }
        private Task CommandsHandler(SocketMessage msg)
        {
            if (msg.ToString().Split(' ').Contains("!test"))
            {
                msg.Channel.SendMessageAsync("test");
            }
            return Task.CompletedTask;
        }
        private Task Log(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }



    }
}
