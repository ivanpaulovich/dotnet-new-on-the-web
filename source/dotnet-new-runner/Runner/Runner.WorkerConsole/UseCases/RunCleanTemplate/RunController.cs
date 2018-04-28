namespace Runner.WorkerConsole.UseCases.RunCleanTemplate
{
    using Runner.Application;
    using Runner.Application.UseCases.Runners.CleanTemplate;
    using Runner.WorkerConsole.ViewModels;

    public class RunController
    {
        private readonly IInputBoundary<Input> boundary;
        private readonly Presenter presenter;

        public RunController(
            IInputBoundary<Input> boundary,
            Presenter presenter)
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
