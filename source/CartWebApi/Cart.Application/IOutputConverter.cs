namespace Cart.Application
{
    public interface IOutputConverter
    {
        T Map<T>(object source);
    }
}
