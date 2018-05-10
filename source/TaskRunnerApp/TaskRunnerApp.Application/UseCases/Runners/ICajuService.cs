namespace TaskRunnerApp.Application.UseCases.Runners
{
    using System;

    public interface ICajuService
    {
        void Run(CleanTemplate.Input input);
        void Run(EventSourcingTemplate.Input input);
        void Run(HexagonalTemplate.Input input);
    }
}
