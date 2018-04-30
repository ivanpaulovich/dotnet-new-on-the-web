namespace TaskRunnerApp.Application.UseCases.Runners
{
    using System;

    public interface ICajuService
    {
        void Run(CleanTemplate.Input input);
        void Run(EventSourcingTemplate.Input input);
        void Run(HexagonalTemplate.Input input);
        void IsRunning(Guid orderId);
        void IsProcessed(Guid orderId);
        void IsUploading(Guid orderId);
        void IsCompleted(Guid orderId);
    }
}
