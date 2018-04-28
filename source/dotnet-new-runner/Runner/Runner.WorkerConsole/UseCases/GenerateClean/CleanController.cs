namespace Runner.WorkerConsole.UseCases.GenerateClean
{
    using Runner.Application;
    using Runner.Application.UseCases.GenerateClean;
    using Runner.WorkerConsole.ViewModels;

    public class CleanController
    {
        private readonly IInputBoundary<GenerateCleanInput> depositInputBoundary;
        private readonly Presenter depositPresenter;

        public CleanController(
            IInputBoundary<GenerateCleanInput> depositInputBoundary,
            Presenter depositPresenter)
        {
            this.depositInputBoundary = depositInputBoundary;
            this.depositPresenter = depositPresenter;
        }

        public TemplateDetailsViewModel Run(CleanRequest request)
        {
            GenerateCleanInput input = new GenerateCleanInput(
                request.Name,
                request.UseCases,
                request.UserInterface,
                request.DataAccess,
                request.Tips,
                request.SkipRestore);

            depositInputBoundary.Process(input);

            return depositPresenter.ViewModel;
        }
    }
}
