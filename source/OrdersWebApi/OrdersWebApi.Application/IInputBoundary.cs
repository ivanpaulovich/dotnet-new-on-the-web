namespace OrdersWebApi.Application
{
    public interface IInputBoundary<T>
    {
        void Process(T input);
    }
}
