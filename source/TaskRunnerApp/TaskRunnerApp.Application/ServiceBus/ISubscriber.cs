using TaskRunnerApp.Domain;
using System.Collections.Generic;

namespace TaskRunnerApp.Application.ServiceBus
{
    public interface ISubscriber
    {
        IEnumerable<object> Listen();
        void Stop();
    }
}
