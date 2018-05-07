namespace Cart.Infrastructure.Services
{
    using Cart.Application.Serializers;
    using Cart.Application.Services;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class TrackingService : ITrackingService
    {
        private readonly string trackingUrl;
        private readonly ISerializer serializer;

        public TrackingService(
            string trackingUrl,
            ISerializer serializer)
        {
            this.trackingUrl = trackingUrl;
            this.serializer = serializer;
        }

        public async Task OrderReceived(Guid orderId, string name, string commandLines)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(trackingUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var obj = new
                {
                    orderId,
                    name,
                    commandLines
                };

                string postedData = serializer.Serialize(obj);

                StringContent queryString = new StringContent(postedData, System.Text.Encoding.UTF8, "application/json");

                await client.PostAsync("/api/Orders", queryString);
            }
        }
    }
}
