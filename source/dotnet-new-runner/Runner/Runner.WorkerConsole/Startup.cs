namespace Runner.WorkerConsole
{
    using Microsoft.Extensions.Configuration;
    using Runner.Application.ServiceBus;
    using System;

    public class Startup : IStartup
    {
        private readonly IConfiguration configuration;
        private readonly ISubscriber subscriber;

        public Startup(IConfiguration configuration, ISubscriber subscriber)
        {
            this.configuration = configuration;
            this.subscriber = subscriber;
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
            }
        }
    }
}
