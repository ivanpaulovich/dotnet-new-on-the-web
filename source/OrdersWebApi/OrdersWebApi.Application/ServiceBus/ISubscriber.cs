using OrdersWebApi.Domain;
using System.Collections.Generic;

namespace OrdersWebApi.Application.ServiceBus
{
    public interface ISubscriber
    {
        IEnumerable<IEntity> Listen();
        void Stop();
    }
}
