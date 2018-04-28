namespace Runner.Application
{
    using System.Threading.Tasks;

    public interface IInputBoundary<T>
    {
        void Process(T input);
    }
}
