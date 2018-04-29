namespace Runner.Infrastructure.Services
{
    using System.Diagnostics;
    using System.IO;
    using Runner.Domain.Templates;
    using System.IO.Compression;
    using Runner.Application.UseCases.Runners;
    using System;

    public class CajuService : ICajuService
    {
        private readonly string outputPath;
        private readonly string zipDeliveryPath;

        private readonly IStorageService storageService;

        public CajuService(string outputPath, string zipDeliveryPath,
            IStorageService storageService)
        {
            this.outputPath = outputPath;
            this.zipDeliveryPath = zipDeliveryPath;
            this.storageService = storageService;
        }

        public void IsCompleted(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public void IsProcessed(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public void IsRunning(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public void IsUploading(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public void Run(Application.UseCases.Runners.CleanTemplate.Input input)
        {
            string arguments = $"new clean --use-cases {input.UseCases} --user-interface {input.UserInterface} --data-access {input.DataAccess} --tips {input.Tips} --skip-restore {input.SkipRestore}";

            GenerateTemplate(input.OrderId, input.Name.ToString(), arguments);
        }

        public void Run(Application.UseCases.Runners.HexagonalTemplate.Input input)
        {
            string arguments = $"new hexagonal --use-cases {input.UseCases} --user-interface {input.UserInterface} --data-access {input.DataAccess} --tips {input.Tips} --skip-restore {input.SkipRestore}";

            GenerateTemplate(input.OrderId, input.Name.ToString(), arguments);
        }

        public void Run(Application.UseCases.Runners.EventSourcingTemplate.Input input)
        {
            string arguments = $"new eventsourcing --use-cases {input.UseCases} --user-interface {input.UserInterface} --data-access {input.DataAccess} --service-bus {input.ServiceBus} --tips {input.Tips} --skip-restore {input.SkipRestore}";

            GenerateTemplate(input.OrderId, input.Name.ToString(), arguments);
        }

        private void GenerateTemplate(Guid orderId, string name, string arguments)
        {
            string orderedBasePath = Path.Combine(outputPath, orderId.ToString());
            string zipDeliveryBasePath = Path.Combine(zipDeliveryPath, orderId.ToString());

            string templatePath = Path.Combine(orderedBasePath, name);
            string orderedPath = Path.Combine(zipDeliveryBasePath, name) + ".zip";

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

            storageService.Upload(orderId, orderedPath)
                .GetAwaiter()
                .GetResult();

            Directory.Delete(orderedBasePath, true);
            Directory.Delete(zipDeliveryBasePath, true);
        }
    }
}
