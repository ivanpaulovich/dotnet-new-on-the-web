namespace OrdersWebApi.Application.Repositories
{
    using OrdersWebApi.Domain.Tracking;
    using System.Threading.Tasks;

    public interface IOrderWriteOnlyRepository
    { 
        Task Add(Order order);
        Task Update(Order order);
    }
}
