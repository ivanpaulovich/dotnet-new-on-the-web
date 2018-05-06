namespace OrdersWebApi.WebApi.UseCases.DotNetNewStarted
{
    using System;
    
    public class OrderReceivedRequest
    {
        public Guid OrderId { get; private set; }

        public OrderReceivedRequest(Guid orderId)
        {
            this.OrderId = orderId;
        }
    }
}
