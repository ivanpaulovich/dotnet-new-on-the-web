namespace Tracking.Application.Repositories
{
    using Tracking.Domain.Tracking;
    using System.Threading.Tasks;

    public interface IOrderWriteOnlyRepository
    { 
        Task Add(Order order);
        Task Update(Order order);
    }
}
