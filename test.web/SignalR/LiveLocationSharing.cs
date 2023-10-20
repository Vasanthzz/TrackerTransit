using Microsoft.AspNetCore.SignalR;

namespace test.web.SignalR
{
    public class LiveLocationSharing : Hub
    {
        public async Task SendLocation(string username, double latitude, double longitude)
        {
            // Broadcast the location update to all clients.
            await Clients.All.SendAsync("ReceiveLocation", username, latitude, longitude);
        }
    }
}
