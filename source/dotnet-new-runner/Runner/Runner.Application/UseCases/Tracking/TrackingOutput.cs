namespace Runner.Application.UseCases.Tracking
{
    using System;

    public class TrackingOutput
    {
        public Guid TemplateId { get; private set; }
        public string DownloadUrl { get; protected set; }
        public DateTime OrderUtcDate { get; protected set; }
        public long QueuePosition { get; protected set; }

        public TrackingOutput()
        {

        }

        public TrackingOutput(
            Guid templateId,
            string downloadUrl,
            DateTime orderUtcDate)
        {
            TemplateId = templateId;
            DownloadUrl = downloadUrl;
            OrderUtcDate = orderUtcDate;
        }
    }
}
