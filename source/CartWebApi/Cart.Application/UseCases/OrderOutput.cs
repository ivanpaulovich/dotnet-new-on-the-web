namespace Cart.Application.UseCases.Orders
{
    using System;

    public class OrderOutput
    {
        public Guid TemplateId { get; private set; }
        public string CommandLines { get; protected set; }
        public DateTime OrderUtcDate { get; protected set; }

        public OrderOutput()
        {

        }

        public OrderOutput(
            Guid templateId,
            string commandLines,
            DateTime orderUtcDate)
        {
            TemplateId = templateId;
            CommandLines = commandLines;
            OrderUtcDate = orderUtcDate;
        }
    }
}
