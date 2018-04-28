namespace Runner.WorkerConsole
{
    using Microsoft.Extensions.Configuration;

    public class Startup : IStartup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        public void Run()
        {

        }
    }
}
