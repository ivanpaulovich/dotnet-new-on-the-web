namespace Runner.Application.UseCases.Track
{
    using System;

    public class TrackOutput
    {
        public Guid TemplateId { get; private set; }
        public string DownloadUrl { get; protected set; }
        public DateTime OrderUtcDate { get; protected set; }

        public TrackOutput()
        {

        }

        public TrackOutput(
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
