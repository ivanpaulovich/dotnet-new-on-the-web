namespace Tracking.Application
{
    public interface IInputBoundary<T>
    {
        void Process(T input);
    }
}
