namespace Tracking.WebApi.UseCases.OrderReceived
{
    using Tracking.Domain.ValueObjects;
    using System;
    
    public class OrderReceivedRequest
    {
        public Guid OrderId { get; private set; }
        public string Name { get; private set; }
        public string CommandLines { get; private set; }

        public OrderReceivedRequest(
            Guid orderId,
            string name,
            string commandLines)
        {
            this.OrderId = orderId;
            this.Name = name;
            this.CommandLines = commandLines;
        }
    }
}
