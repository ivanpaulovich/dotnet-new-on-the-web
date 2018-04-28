namespace Runner.WebApi.UseCases
{
    using System;

    public class OrderModel
    {
        public Guid OrderId { get; private set; }
        public string Commandlines { get; private set; }
        public DateTime OrderUtcDate { get; private set; }

        public OrderModel(
            Guid orderId,
            string commandlines,
            DateTime orderUtcDate)
        {
            OrderId = orderId;
            Commandlines = commandlines;
            OrderUtcDate = orderUtcDate;
        }
    }
}
