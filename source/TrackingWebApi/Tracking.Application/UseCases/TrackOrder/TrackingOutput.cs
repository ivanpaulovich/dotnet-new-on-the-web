namespace Tracking.Application.UseCases.TrackOrder
{
    using System;

    public class TrackingOutput
    {
        public Guid OrderId { get; set; }
        public string CommandLines { get; set; }
        public DateTime OrderReceivedUtcDate { get; set; }
        public DateTime DotNetNewStartedUtcDate { get; set; }
        public DateTime DotNetNewFinishedUtcDate { get; set; }
        public string DotNetNewOutput { get; set; }
        public DateTime UploadFinished { get; set; }
        public string DownloadUrl { get; set; }
    }
}
