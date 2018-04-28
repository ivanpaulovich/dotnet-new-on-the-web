namespace Runner.WorkerConsole
{
    using Microsoft.Extensions.Configuration;
    using Runner.Application.ServiceBus;

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
            subscriber.Listen();
        }
    }
}
