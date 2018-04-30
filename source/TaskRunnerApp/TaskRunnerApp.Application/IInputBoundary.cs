namespace TaskRunnerApp.Application
{
    public interface IInputBoundary<T>
    {
        void Process(T input);
    }
}
