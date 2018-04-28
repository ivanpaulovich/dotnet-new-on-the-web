namespace Runner.Infrastructure.Services
{
    using System.Diagnostics;
    using System.IO;
    using Runner.Domain.Templates;
    using System.IO.Compression;
    using Runner.Application.UseCases.Runners;
    using Runner.Application.UseCases.Runners.CleanTemplate;

    public class CajuService : ICajuService
    {
        private readonly string outputPath;
        private readonly string zipDeliveryPath;

        public CajuService(string outputPath, string zipDeliveryPath)
        {
            this.outputPath = outputPath;
            this.zipDeliveryPath = zipDeliveryPath;
        }

        public void Run(Input input)
        {
            string arguments = $"new clean --use-cases {input.UseCases} --user-interface {input.UserInterface} --data-access {input.DataAccess} --tips {input.Tips} --skip-restore {input.SkipRestore}";

            string orderedBasePath = Path.Combine(outputPath, input.OrderId.ToString());
            string zipDeliveryBasePath = Path.Combine(zipDeliveryPath, input.OrderId.ToString());

            string templatePath = Path.Combine(orderedBasePath, input.Name.ToString());
            string orderedPath = Path.Combine(zipDeliveryBasePath, input.Name.ToString()) + ".zip";

            if (!Directory.Exists(orderedBasePath))
                Directory.CreateDirectory(orderedBasePath);

            if (!Directory.Exists(zipDeliveryBasePath))
                Directory.CreateDirectory(zipDeliveryBasePath);

            if (!Directory.Exists(templatePath))
                Directory.CreateDirectory(templatePath);

            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = arguments,
                    UseShellExecute = true,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    CreateNoWindow = true,
                    WorkingDirectory = templatePath
                }
            };

            process.Start();
            process.WaitForExit();

            ZipFile.CreateFromDirectory(templatePath, orderedPath);

            Directory.Delete(templatePath, true);
        }

        public void Run(HexagonalTemplate template)
        {
            throw new System.NotImplementedException();
        }

        public void Run(EventSourcingTemplate template)
        {
            throw new System.NotImplementedException();
        }
    }
}
