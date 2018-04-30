namespace TaskRunnerApp.Application.UseCases.Runners
{
    using System;
    using System.Threading.Tasks;

    public interface IStorageService
    {
        Task Upload(Guid orderId, string filename);
    }
}
