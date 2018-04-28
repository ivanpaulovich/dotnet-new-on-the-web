namespace Runner.Application.UseCases.Runners
{
    using System;

    public class RunOutput
    {
        public Guid TemplateId { get; private set; }
        public DateTime RunUtcDate { get; protected set; }

        public RunOutput()
        {

        }

        public RunOutput(
            Guid templateId,
            DateTime runUtcDate)
        {
            TemplateId = templateId;
            RunUtcDate = runUtcDate;
        }
    }
}
