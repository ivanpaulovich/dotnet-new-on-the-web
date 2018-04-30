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
            string output = Path.Combine(outputPath, input.OrderId.ToString());

            string arguments = $"new clean --use-cases {input.UseCases} --user-interface {input.UserInterface} --data-access {input.DataAccess} --tips {input.Tips} --skip-restore {input.SkipRestore} --name {input.Name.ToString()} --output {output}";

            GenerateTemplate(arguments);

            Deliver(output, input.OrderId, input.Name.ToString());
        }

        public void Run(Application.UseCases.Runners.HexagonalTemplate.Input input)
        {
            string output = Path.Combine(outputPath, input.OrderId.ToString());

            string arguments = $"new hexagonal --use-cases {input.UseCases} --user-interface {input.UserInterface} --data-access {input.DataAccess} --tips {input.Tips} --skip-restore {input.SkipRestore} --name {input.Name.ToString()} --output {output}";

            GenerateTemplate(arguments);

            Deliver(output, input.OrderId, input.Name.ToString());
        }

        public void Run(Application.UseCases.Runners.EventSourcingTemplate.Input input)
        {
            string output = Path.Combine(outputPath, input.OrderId.ToString());

            string arguments = $"new eventsourcing --use-cases {input.UseCases} --user-interface {input.UserInterface} --data-access {input.DataAccess} --service-bus {input.ServiceBus} --tips {input.Tips} --skip-restore {input.SkipRestore} --name {input.Name.ToString()} --output {output}";

            GenerateTemplate(arguments);

            Deliver(output, input.OrderId, input.Name.ToString());
        }

        private void GenerateTemplate(string arguments)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = arguments,
                    UseShellExecute = true,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.WaitForExit();
        }

        private void Deliver(string output, Guid orderId, string name)
        {
            string zipDeliveryBasePath = Path.Combine(zipDeliveryPath, orderId.ToString());
            if (!Directory.Exists(zipDeliveryBasePath))
                Directory.CreateDirectory(zipDeliveryBasePath);

            string orderedPath = Path.Combine(zipDeliveryBasePath, name) + ".zip";

            ZipFile.CreateFromDirectory(output, orderedPath);

            storageService.Upload(orderId, orderedPath)
                .GetAwaiter()
                .GetResult();

            Directory.Delete(output, true);
            Directory.Delete(zipDeliveryBasePath, true);
        }
    }
}
