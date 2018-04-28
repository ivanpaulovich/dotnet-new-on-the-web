namespace Runner.WorkerConsole
{
    using Microsoft.Extensions.Configuration;
    using Runner.Application.ServiceBus;
    using Runner.Domain;
    using Runner.WorkerConsole.UseCases;
    using System;

    public class Startup : IStartup
    {
        private readonly IConfiguration configuration;
        private readonly ISubscriber subscriber;

        private readonly ControllerFactory controllerFactory;

        public Startup(IConfiguration configuration, ISubscriber subscriber,
            ControllerFactory controllerFactory)
        {
            this.configuration = configuration;
            this.subscriber = subscriber;
            this.controllerFactory = controllerFactory;
        }
        
        public void Run()
        {
            Console.CancelKeyPress += (_, e) =>
            {
                subscriber.Stop();
            };

            foreach (IEntity order in subscriber.Listen())
            {
                controllerFactory.Run(order);
            }
        }
    }
}
