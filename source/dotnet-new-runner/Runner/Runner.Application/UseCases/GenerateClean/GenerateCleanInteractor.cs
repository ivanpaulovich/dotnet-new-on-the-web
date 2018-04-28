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

        public void Process(GenerateCleanInput input)
        {
            CleanTemplateOrder template = new CleanTemplateOrder(
                input.Name,
                input.UseCases,
                input.UserInterface,
                input.DataAccess,
                input.Tips,
                input.SkipRestore);

            cajuService.Run(template);

            GenerateOutput generateOutput = outputConverter.Map<GenerateOutput>(template);
            outputBoundary.Populate(generateOutput);
        }
    }
}
