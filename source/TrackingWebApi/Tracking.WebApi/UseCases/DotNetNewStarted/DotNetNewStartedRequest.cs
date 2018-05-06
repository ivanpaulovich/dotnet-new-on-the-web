namespace Tracking.WebApi.UseCases.DotNetNewStarted
{
    using System;
    
    public class DotNetNewStartedRequest
    {
        public Guid OrderId { get; private set; }

        public DotNetNewStartedRequest(Guid orderId)
        {
            this.OrderId = orderId;
        }
    }
}
