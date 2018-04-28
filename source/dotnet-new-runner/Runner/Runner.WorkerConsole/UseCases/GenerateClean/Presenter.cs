namespace Runner.WorkerConsole.UseCases.GenerateClean
{
    using Runner.Application;
    using Runner.Application.Outputs;
    using Runner.WorkerConsole.ViewModels;
    using System;

    public class Presenter : IOutputBoundary<GenerateOutput>
    {
        public GenerateOutput Output { get; private set; }
        public TemplateDetailsViewModel ViewModel { get; private set; }

        public void Populate(GenerateOutput response)
        {
            Console.WriteLine(
                response.OrderUtcDate + "" +
                response.TemplateId + "" +
                response.CommandLines);
        }
    }
}
