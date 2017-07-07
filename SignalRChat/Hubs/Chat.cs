using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRChat.Hubs
{
    public class Chat : Hub
    {
        public static int _clientsCount = 0;

        public void SendMessage(string nickname, string message)
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<Chat>();
            hub.Clients.AllExcept(Context.ConnectionId).WriteMessage(nickname, message);
        }

        public int CountClients()
        {
            return _clientsCount;
        }
        
        public override Task OnDisconnected(bool stopCalled)
        {
            _clientsCount--;
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnConnected()
        {
            _clientsCount++;
            return base.OnConnected();
        }
    }
}
