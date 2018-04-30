namespace OrdersWebApi.Application.UseCases.Tracking
{
    using System;

    public class TrackingOutput
    {
        public Guid OrderId { get; private set; }
        public string DownloadUrl { get; protected set; }
        public DateTime OrderUtcDate { get; protected set; }
        public long QueuePosition { get; protected set; }

        public TrackingOutput()
        {

        }

        public TrackingOutput(
            Guid orderId,
            string downloadUrl,
            DateTime orderUtcDate)
        {
            OrderId = orderId;
            DownloadUrl = downloadUrl;
            OrderUtcDate = orderUtcDate;
        }
    }
}
