namespace Runner.WebApi.UseCases.OrderCleanTemplate
{
    using System;

    public class Model
    {
        public Guid OrderId { get; }

        public Model(
            Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
