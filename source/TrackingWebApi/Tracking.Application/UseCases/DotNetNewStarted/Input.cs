namespace Tracking.Application.UseCases.DotNetNewStarted
{
    using System;

    public class Input
    {
        public Guid OrderId { get; private set; }

        public Input(Guid orderId)
        {
            this.OrderId = orderId;
        }
    }
}
