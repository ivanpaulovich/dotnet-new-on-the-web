namespace TaskRunnerApp.Infrastructure.Services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using TaskRunnerApp.Application.Serializers;
    using TaskRunnerApp.Application.Services;

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

        public async Task DotNetNewFinished(Guid orderId, string output)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var obj = new
                {
                    orderId,
                    output
                };

                string postedData = serializer.Serialize(obj);

                using (var content = new StringContent(postedData, System.Text.Encoding.UTF8, "application/json"))
                using (var request = new HttpRequestMessage(
                    new HttpMethod("PATCH"),
                    new Uri(trackingUrl + "tracking/api/Orders/DotNetNewFinished"))
                {
                    Content = content
                })
                {
                    var resp = await client.SendAsync(request);
                }
            }
        }

        public async Task DotNetNewStarted(Guid orderId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(trackingUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var obj = new
                {
                    orderId
                };

                string postedData = serializer.Serialize(obj);

                using (var content = new StringContent(postedData, System.Text.Encoding.UTF8, "application/json"))
                using (var request = new HttpRequestMessage(
                    new HttpMethod("PATCH"),
                    new Uri(trackingUrl + "tracking/api/Orders/DotNetNewStarted"))
                {
                    Content = content
                })
                {
                    var resp = await client.SendAsync(request);
                }
            }
        }

        public async Task UploadFinished(Guid orderId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(trackingUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var obj = new
                {
                    orderId
                };

                string postedData = serializer.Serialize(obj);

                using (var content = new StringContent(postedData, System.Text.Encoding.UTF8, "application/json"))
                using (var request = new HttpRequestMessage(
                    new HttpMethod("PATCH"),
                    new Uri(trackingUrl + "tracking/api/Orders/UploadFinished"))
                {
                    Content = content
                })
                {
                    var resp = await client.SendAsync(request);
                }
            }
        }
    }
}
