namespace TaskRunnerApp.WorkerConsole.UseCases.RunCleanTemplate
{
    using TaskRunnerApp.Application;
    using TaskRunnerApp.Application.UseCases.Runners.CleanTemplate;
    using TaskRunnerApp.WorkerConsole.Presenters;
    using TaskRunnerApp.WorkerConsole.ViewModels;

    public class RunController
    {
        private readonly IInputBoundary<Input> boundary;
        private readonly OutputPresenter presenter;

        public RunController(
            IInputBoundary<Input> boundary,
            OutputPresenter presenter)
        {
            this.boundary = boundary;
            this.presenter = presenter;
        }

        public TemplateDetailsViewModel Run(Request request)
        {
            Input input = new Input(
                request.OrderId,
                request.Name,
                request.UseCases,
                request.UserInterface,
                request.DataAccess,
                request.Tips,
                request.SkipRestore);

            boundary.Process(input);

            return presenter.ViewModel;
        }
    }
}
