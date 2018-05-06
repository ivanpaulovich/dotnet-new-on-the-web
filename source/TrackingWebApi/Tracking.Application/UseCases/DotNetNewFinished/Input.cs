namespace Tracking.Application.UseCases.DotNetNewFinished
{
    using System;

    public class Input
    {
        public Guid OrderId { get; private set; }
        public string Output { get; private set; }

        public Input(Guid orderId, string output)
        {
            this.OrderId = orderId;
            this.Output = output;
        }
    }
}
