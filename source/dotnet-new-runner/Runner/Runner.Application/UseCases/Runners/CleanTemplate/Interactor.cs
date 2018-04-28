namespace Runner.Application.UseCases.Runners.CleanTemplate
{
    public class Interactor : IInputBoundary<Input>
    {
        private readonly ICajuService cajuService;
        private readonly IOutputBoundary<RunOutput> outputBoundary;
        private readonly IOutputConverter outputConverter;
        
        public Interactor(
            ICajuService cajuService,
            IOutputBoundary<RunOutput> outputBoundary,
            IOutputConverter outputConverter)
        {
            this.cajuService = cajuService;
            this.outputBoundary = outputBoundary;
            this.outputConverter = outputConverter;
        }

        public void Process(Input input)
        {
            cajuService.Run(input);

            RunOutput output = outputConverter.Map<RunOutput>(input);
            outputBoundary.Populate(output);
        }
    }
}
