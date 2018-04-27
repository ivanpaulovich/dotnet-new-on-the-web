namespace Runner.Application.Outputs
{
    using System;

    public class GenerateOutput
    {
        public Guid TemplateId { get; private set; }
        public string CommandLines { get; protected set; }
        public DateTime OrderUtcDate { get; protected set; }

        public GenerateOutput()
        {

        }

        public GenerateOutput(
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
