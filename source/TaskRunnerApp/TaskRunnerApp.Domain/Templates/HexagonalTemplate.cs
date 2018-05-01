namespace TaskRunnerApp.Domain.Templates
{
    using TaskRunnerApp.Domain.ValueObjects;
    using System;

    public class HexagonalTemplate
    {
        public virtual Guid Id { get; set; }
        public virtual Name Name { get; set; }
        public virtual UseCases UseCases { get; set; }
        public virtual UserInterface UserInterface { get; set; }
        public virtual DataAccess DataAccess { get; set; }
        public virtual Tips Tips { get; set; }
        public virtual SkipRestore SkipRestore { get; set; }
        public virtual DateTime OrderUtcDate { get; set; }
    }
}
