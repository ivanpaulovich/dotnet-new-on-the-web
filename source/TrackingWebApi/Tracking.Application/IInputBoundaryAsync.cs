namespace Tracking.Application
{
    using System.Threading.Tasks;

    public interface IInputBoundaryAsync<T>
    {
        Task Process(T input);
    }
}
