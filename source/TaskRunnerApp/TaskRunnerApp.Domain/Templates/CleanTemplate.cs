namespace TaskRunnerApp.Domain.Templates
{
    using TaskRunnerApp.Domain.ValueObjects;
    using System;

    public class CleanTemplate
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public UseCases UseCases { get; set; }
        public UserInterface UserInterface { get; set; }
        public DataAccess DataAccess { get; set; }
        public Tips Tips { get; set; }
        public SkipRestore SkipRestore { get; set; }
        public DateTime OrderUtcDate { get; set; }
    }
}
