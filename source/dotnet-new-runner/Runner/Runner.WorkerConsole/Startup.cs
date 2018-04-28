namespace Runner.WorkerConsole
{
    using Microsoft.Extensions.Configuration;
    using Runner.Application.ServiceBus;
    using Runner.WorkerConsole.UseCases.GenerateClean;
    using System;

    public class Startup : IStartup
    {
        private readonly IConfiguration configuration;
        private readonly ISubscriber subscriber;

        private readonly CleanController cleanController;

        public Startup(IConfiguration configuration, ISubscriber subscriber,
            CleanController cleanController)
        {
            this.configuration = configuration;
            this.subscriber = subscriber;
            this.cleanController = cleanController;
        }
        
        public void Run()
        {
            Console.CancelKeyPress += (_, e) =>
            {
                subscriber.Stop();
            };

            int i = 0;

            foreach (string task in subscriber.Listen())
            {
                Console.WriteLine(i++ + "::::" + task);
                CleanRequest request = new CleanRequest("myName", "full", "webapi", "entityframework", "true", "true");
                cleanController.Run(request);
            }
        }
    }
}
