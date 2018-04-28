using Runner.Domain;
using System.Collections.Generic;

namespace Runner.Application.ServiceBus
{
    public interface ISubscriber
    {
        IEnumerable<IEntity> Listen();
        void Stop();
    }
}
