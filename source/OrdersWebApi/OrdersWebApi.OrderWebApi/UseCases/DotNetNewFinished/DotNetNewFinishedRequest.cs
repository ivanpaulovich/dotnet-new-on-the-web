namespace OrdersWebApi.WebApi.UseCases.DotNetNewFinished
{
    using System;
    
    public class DotNetNewFinishedRequest
    {
        public Guid OrderId { get; private set; }
        public string Output { get; private set; }

        public DotNetNewFinishedRequest(Guid orderId, string output)
        {
            this.OrderId = orderId;
            this.Output = output;
        }
    }
}
