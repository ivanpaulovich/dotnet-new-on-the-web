using System;

namespace TaskRunnerApp.Application.Services
{
    public interface ITrackingService
    {
        void OrderReceived(Guid orderId, string name, string commandLines);
        void DotNetNewStarted(Guid orderId);
        void DotNetNewFinished(Guid orderId, string output);
        void UploadFinished(Guid orderId);
    }
}
