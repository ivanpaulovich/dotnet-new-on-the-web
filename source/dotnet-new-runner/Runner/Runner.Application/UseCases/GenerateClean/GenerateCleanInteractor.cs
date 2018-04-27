namespace Runner.Application.UseCases.GenerateClean
{
    using System.Threading.Tasks;
    using Runner.Application.Outputs;
    using Runner.Application.Services;
    using Runner.Domain.Templates;

    public class GenerateCleanInteractor : IInputBoundary<GenerateCleanInput>
    {
        private readonly ICajuService cajuService;
        private readonly IOutputBoundary<GenerateOutput> outputBoundary;
        private readonly IOutputConverter outputConverter;
        
        public GenerateCleanInteractor(
            ICajuService cajuService,
            IOutputBoundary<GenerateOutput> outputBoundary,
            IOutputConverter outputConverter)
        {
            this.cajuService = cajuService;
            this.outputBoundary = outputBoundary;
            this.outputConverter = outputConverter;
        }

        public async Task Process(GenerateCleanInput input)
        {
            CleanTemplate template = new CleanTemplate(
                input.UseCases,
                input.UserInterface,
                input.DataAccess,
                input.Tips,
                input.SkipRestore);

            await cajuService.Run(template);

            GenerateOutput generateOutput = outputConverter.Map<GenerateOutput>(template);
            outputBoundary.Populate(generateOutput);
        }
    }
}
