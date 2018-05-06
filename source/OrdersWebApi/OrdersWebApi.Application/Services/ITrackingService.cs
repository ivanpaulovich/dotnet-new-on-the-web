namespace OrdersWebApi.Application.Services
{
    using System;
    using System.Threading.Tasks;

    public interface ITrackingService
    {
        Task OrderReceived(Guid orderId, string name, string commandLines);
    }
}
