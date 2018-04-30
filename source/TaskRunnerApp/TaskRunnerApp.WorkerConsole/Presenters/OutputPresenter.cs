namespace TaskRunnerApp.WorkerConsole.Presenters
{
    using TaskRunnerApp.Application;
    using TaskRunnerApp.Application.UseCases.Runners;
    using TaskRunnerApp.WorkerConsole.ViewModels;
    using System;

    public class OutputPresenter : IOutputBoundary<RunOutput>
    {
        public RunOutput Output { get; private set; }
        public TemplateDetailsViewModel ViewModel { get; private set; }

        public void Populate(RunOutput output)
        {
            Console.WriteLine($"Template {output.TemplateId} generated on {output.RunUtcDate} UTC");
        }
    }
}
