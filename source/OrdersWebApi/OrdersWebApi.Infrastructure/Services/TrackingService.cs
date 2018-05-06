namespace OrdersWebApi.Infrastructure.Services
{
    using OrdersWebApi.Application.Services;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class TrackingService : ITrackingService
    {
        private readonly string trackingUrl;

        public TrackingService(string trackingUrl)
        {
            this.trackingUrl = trackingUrl;
        }

        public async Task OrderReceived(Guid orderId, string name, string commandLines)
        {
            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("orderId", orderId.ToString()),
                new KeyValuePair<string, string>("name", name),
                new KeyValuePair<string, string>("commandLines", commandLines)
            };

            var content = new FormUrlEncodedContent(pairs);

            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, trackingUrl)
            {
                Content = content
            };

            HttpResponseMessage response = new HttpResponseMessage();
            var client = new HttpClient { BaseAddress = new Uri(trackingUrl + "/api/Tracking/OrderReceived") };

            await client.SendAsync(request);
        }
    }
}
