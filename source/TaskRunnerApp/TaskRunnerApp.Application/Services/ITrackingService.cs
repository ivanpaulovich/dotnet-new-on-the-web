namespace TaskRunnerApp.Application.Services
{
    using System;
    using System.Threading.Tasks;

    public interface ITrackingService
    {
        Task DotNetNewStarted(Guid orderId);
        Task DotNetNewFinished(Guid orderId, string output);
        Task UploadFinished(Guid orderId);
    }
}
