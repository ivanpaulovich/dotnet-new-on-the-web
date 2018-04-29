namespace Runner.WorkerConsole.UseCases
{
    using Runner.Domain;
    using Runner.Domain.Templates;

    public class ControllerFactory
    {
        private readonly RunCleanTemplate.RunController cleanController;
        private readonly RunHexagonalTemplate.RunController hexagonalController;
        private readonly RunEventSourcingTemplate.RunController eventSourcingController;

        public ControllerFactory(
            RunCleanTemplate.RunController cleanController,
            RunHexagonalTemplate.RunController hexagonalController,
            RunEventSourcingTemplate.RunController eventSourcingController)
        {
            this.cleanController = cleanController;
            this.hexagonalController = hexagonalController;
            this.eventSourcingController = eventSourcingController;
        }

        public void Run(IEntity entity)
        {
            if (entity is CleanTemplate)
            {
                CleanTemplate template = (CleanTemplate)entity;

                RunCleanTemplate.Request request = new RunCleanTemplate.Request(
                    template.Id,
                    template.Name.Text,
                    template.UseCases.Text,
                    template.UserInterface.Text,
                    template.DataAccess.Text,
                    template.Tips.Text,
                    template.SkipRestore.Text);

                cleanController.Run(request);
            }

            if (entity is HexagonalTemplate)
            {
                HexagonalTemplate template = (HexagonalTemplate)entity;

                RunHexagonalTemplate.Request request = new RunHexagonalTemplate.Request(
                    template.Id,
                    template.Name.Text,
                    template.UseCases.Text,
                    template.UserInterface.Text,
                    template.DataAccess.Text,
                    template.Tips.Text,
                    template.SkipRestore.Text);

                hexagonalController.Run(request);
            }

            if (entity is EventSourcingTemplate)
            {
                EventSourcingTemplate template = (EventSourcingTemplate)entity;

                RunEventSourcingTemplate.Request request = new RunEventSourcingTemplate.Request(
                    template.Id,
                    template.Name.Text,
                    template.UseCases.Text,
                    template.UserInterface.Text,
                    template.DataAccess.Text,
                    template.ServiceBus.Text,
                    template.Tips.Text,
                    template.SkipRestore.Text);

                eventSourcingController.Run(request);
            }
        }
    }
}
