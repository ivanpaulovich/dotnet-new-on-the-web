namespace Tracking.Domain.Tracking
{
    using System;

    public class Order : Entity, IAggregateRoot
    {
        public virtual string CommandLines { get; protected set; }
        public virtual DateTime OrderReceivedUtcDate { get; protected set; }
        public virtual DateTime DotNetNewStartedUtcDate { get; protected set; }
        public virtual DateTime DotNetNewFinishedUtcDate { get; protected set; }
        public virtual string DotNetNewOutput { get; protected set; }
        public virtual DateTime UploadFinished { get; protected set; }
        public virtual string UploadLink { get; protected set; }

        public Order(
            Guid orderId,
            string commandLines,
            string uploadBaseUrl)
        {
            this.Id = orderId;
            this.CommandLines = commandLines;
            this.OrderReceivedUtcDate = DateTime.UtcNow;
            this.UploadLink = uploadBaseUrl + Id.ToString() + ".zip";
        }

        public void FinishUpload()
        {
            this.UploadFinished = DateTime.UtcNow;
        }

        public void StartDotNetNew()
        {
            this.DotNetNewStartedUtcDate = DateTime.UtcNow;
        }

        public void SetDotNetNewOutPut(string output)
        {
            this.DotNetNewFinishedUtcDate = DateTime.UtcNow;
            this.DotNetNewOutput = output;
        }
    }
}
