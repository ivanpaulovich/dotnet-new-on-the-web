using TaskRunnerApp.Domain;
using System.Collections.Generic;

namespace TaskRunnerApp.Application.ServiceBus
{
    public interface ISubscriber
    {
        IEnumerable<IEntity> Listen();
        void Stop();
    }
}
