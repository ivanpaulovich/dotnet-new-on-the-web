namespace Tracking.Application.UseCases.OrderReceived
{
    using Tracking.Domain.ValueObjects;
    using System;

    public class Input
    {
        public Guid OrderId { get; private set; }
        public Name Name { get; private set; }
        public string CommandLines { get; private set; }

        public Input(Guid orderId, Name name, string commandLines)
        {
            this.OrderId = orderId;
            this.Name = name;
            this.CommandLines = commandLines;
        }
    }
}
