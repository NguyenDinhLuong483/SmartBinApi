
namespace SmartBin.Api.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly MqttBuffer _buffer;

        public NotificationHub(MqttBuffer buffer)
        {
            _buffer = buffer;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("OnConnected", "Connect Successful");
        }
    }
}
