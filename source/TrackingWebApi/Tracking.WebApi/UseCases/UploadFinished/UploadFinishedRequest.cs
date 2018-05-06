namespace Tracking.WebApi.UseCases.UploadFinished
{
    using System;
    
    public class UploadFinishedRequest
    {
        public Guid OrderId { get; private set; }

        public UploadFinishedRequest(Guid orderId)
        {
            this.OrderId = orderId;
        }
    }
}
