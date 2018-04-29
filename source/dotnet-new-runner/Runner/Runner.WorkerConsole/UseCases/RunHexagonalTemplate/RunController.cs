namespace Runner.WorkerConsole.UseCases.RunHexagonalTemplate
{
    using Runner.Application;
    using Runner.Application.UseCases.Runners.HexagonalTemplate;
    using Runner.WorkerConsole.Presenters;
    using Runner.WorkerConsole.ViewModels;

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
