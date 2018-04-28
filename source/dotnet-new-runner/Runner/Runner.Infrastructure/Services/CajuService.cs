namespace Runner.Infrastructure.Services
{
    using System.Diagnostics;
    using System.IO;
    using Runner.Application.Services;
    using Runner.Domain.Templates;
    using System.IO.Compression;

    public class CajuService : ICajuService
    {
        private readonly string outputPath;
        private readonly string zipDeliveryPath;

        public CajuService(string outputPath, string zipDeliveryPath)
        {
            this.outputPath = outputPath;
            this.zipDeliveryPath = zipDeliveryPath;
        }

        public void Run(CleanTemplateOrder template)
        {
            string arguments = $"new clean --use-cases {template.UseCases} --user-interface {template.UserInterface} --data-access {template.DataAccess} --tips {template.Tips} --skip-restore {template.SkipRestore}";

            string orderedBasePath = Path.Combine(outputPath, template.Id.ToString());

            if (!Directory.Exists(orderedBasePath))
                Directory.CreateDirectory(orderedBasePath);

            string templatePath = Path.Combine(orderedBasePath, template.Name);

            if (!Directory.Exists(templatePath))
                Directory.CreateDirectory(templatePath);

            string zipDeliveryBasePath = Path.Combine(zipDeliveryPath, template.Id.ToString());

            if (!Directory.Exists(zipDeliveryBasePath))
                Directory.CreateDirectory(zipDeliveryBasePath);

            string orderedPath = Path.Combine(zipDeliveryBasePath, template.Name) + ".zip";

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

        public void Run(HexagonalTemplateOrder template)
        {
            throw new System.NotImplementedException();
        }

        public void Run(EventSourcingTemplateOrder template)
        {
            throw new System.NotImplementedException();
        }
    }
}
