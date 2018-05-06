namespace Tracking.WebApi.UseCases.TrackOrder
{
    using System;

    public class OrderModel
    {
        public Guid OrderId { get; private set; }
        public string CommandLines { get; private set; }
        public DateTime OrderReceivedUtcDate { get; private set; }
        public DateTime DotNetNewStartedUtcDate { get; private set; }
        public DateTime DotNetNewFinishedUtcDate { get; private set; }
        public string DotNetNewOutput { get; private set; }
        public DateTime UploadFinished { get; private set; }
        public string DownloadUrl { get; private set; }

        public OrderModel(
            Guid orderId,
            string commandlines,
            DateTime orderReceivedUtcDate,
            DateTime dotNetNewStartedUtcDate,
            DateTime dotNetNewFinishedUtcDate,
            string dotNetNewOutput,
            DateTime uploadFinished,
            string downloadUrl)
        {
            OrderId = orderId;
            CommandLines = commandlines;
            OrderReceivedUtcDate = orderReceivedUtcDate;
            DotNetNewStartedUtcDate = dotNetNewStartedUtcDate;
            DotNetNewFinishedUtcDate = dotNetNewFinishedUtcDate;
            DotNetNewOutput = dotNetNewOutput;
            UploadFinished = uploadFinished;
            DownloadUrl = downloadUrl;
        }
    }
}
