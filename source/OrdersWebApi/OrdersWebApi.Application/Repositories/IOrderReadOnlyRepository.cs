namespace OrdersWebApi.Application.Repositories
{
    using OrdersWebApi.Domain.Tracking;
    using System;
    using System.Threading.Tasks;

    public interface IOrderReadOnlyRepository
    {
        Task<Order> Get(Guid id);
    }
}
