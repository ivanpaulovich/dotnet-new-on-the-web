using System;

namespace Runner.WorkerConsole.ViewModels
{
    public class TemplateDetailsViewModel
    {
        public Guid TemplateId { get; set; }
        public string CommandLines { get; set; }
        public DateTime OrderUtcDate { get; set; }
    }
}
