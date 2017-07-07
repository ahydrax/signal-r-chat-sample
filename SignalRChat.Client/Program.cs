using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using RestSharp;

namespace SignalRChat.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var hubConnection = new HubConnection("http://localhost:61462/signalr");
            var proxy = hubConnection.CreateHubProxy("Chat");

            proxy.On<string, string>("WriteMessage", WriteMessage);

            hubConnection.Start().Wait();

            var nickname = Console.ReadLine();
            while (true)
            {
                var message = Console.ReadLine();

                if (message == "!count")
                {
                    var client = new RestClient("http://localhost:61462/");
                    var request = new RestRequest("chat/clients/count");
                    request.AddQueryParameter("access_token", "dasdasdasdsadasdsadas");
                    var count = client.Get<int>(request).Data;

                    Console.WriteLine($"{count} users connected");
                }
                else
                {
                    proxy.Invoke("SendMessage", nickname, message).Wait();
                }
            }
        }

        private static void WriteMessage(string nickname, string message)
        {
            Console.WriteLine($"[{nickname}]: {message}");
        }
    }
}
