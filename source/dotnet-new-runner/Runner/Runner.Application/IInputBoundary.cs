namespace Runner.Application
{
    public interface IInputBoundary<T>
    {
        void Process(T input);
    }
}
