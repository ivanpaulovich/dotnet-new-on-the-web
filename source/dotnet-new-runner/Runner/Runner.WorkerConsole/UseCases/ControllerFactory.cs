namespace Runner.WorkerConsole.UseCases
{
    using Runner.Domain;
    using Runner.Domain.Templates;

    public class ControllerFactory
    {
        private readonly RunCleanTemplate.RunController cleanController;

        public ControllerFactory(RunCleanTemplate.RunController cleanController)
        {
            this.cleanController = cleanController;
        }

        public void Run(IEntity entity)
        {
            if (entity is CleanTemplate)
            {
                CleanTemplate cleanTemplate = (CleanTemplate)entity;

                RunCleanTemplate.Request request = new RunCleanTemplate.Request(
                    cleanTemplate.Id,
                    cleanTemplate.Name.Text,
                    cleanTemplate.UseCases.Text,
                    cleanTemplate.UserInterface.Text,
                    cleanTemplate.DataAccess.Text,
                    cleanTemplate.Tips.Text,
                    cleanTemplate.SkipRestore.Text);

                cleanController.Run(request);
            }
        }
    }
}
