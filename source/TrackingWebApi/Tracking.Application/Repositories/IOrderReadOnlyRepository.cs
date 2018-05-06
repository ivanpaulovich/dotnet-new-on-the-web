namespace Tracking.Application.Repositories
{
    using Tracking.Domain.Tracking;
    using System;
    using System.Threading.Tasks;

    public interface IOrderReadOnlyRepository
    {
        Task<Order> Get(Guid id);
    }
}
