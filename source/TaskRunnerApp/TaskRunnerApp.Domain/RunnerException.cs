namespace TaskRunnerApp.Domain
{
    using System;

    public class RunnerException : Exception
    {
        internal RunnerException()
        { }

        internal RunnerException(string message)
            : base(message)
        { }

        internal RunnerException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
