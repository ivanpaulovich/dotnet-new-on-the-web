using System.Collections.Generic;

namespace Runner.Application.ServiceBus
{
    public interface ISubscriber
    {
        IEnumerable<string> Listen();
        void Stop();
    }
}
