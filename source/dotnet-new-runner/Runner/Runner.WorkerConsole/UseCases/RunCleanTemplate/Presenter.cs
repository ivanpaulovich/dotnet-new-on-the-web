﻿namespace Runner.WorkerConsole.UseCases.RunCleanTemplate
{
    using Runner.Application;
    using Runner.Application.UseCases.Runners;
    using Runner.WorkerConsole.ViewModels;
    using System;

    public class Presenter : IOutputBoundary<RunOutput>
    {
        public RunOutput Output { get; private set; }
        public TemplateDetailsViewModel ViewModel { get; private set; }

        public void Populate(RunOutput output)
        {
            Console.WriteLine($"Template {output.TemplateId} generated on {output.RunUtcDate} UTC");
        }
    }
}
