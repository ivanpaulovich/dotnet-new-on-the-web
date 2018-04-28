namespace Runner.WebApi.UseCases.GetCleanTemplateOrder
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
