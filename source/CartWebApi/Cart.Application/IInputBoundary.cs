namespace Cart.Application
{
    public interface IInputBoundary<T>
    {
        void Process(T input);
    }
}
