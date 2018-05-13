namespace TaskRunnerApp.Infrastructure.Services
{
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;
    using TaskRunnerApp.Application.UseCases.Runners;
    using System;
    using TaskRunnerApp.Application.Services;
    using System.Text;

    public class CajuService : ICajuService
    {
        private readonly string outputPath;
        private readonly string zipDeliveryPath;

        private readonly IStorageService storageService;
        private readonly ITrackingService trackingService;

        public CajuService(string outputPath, string zipDeliveryPath,
            IStorageService storageService,
            ITrackingService trackingService)
        {
            this.outputPath = outputPath;
            this.zipDeliveryPath = zipDeliveryPath;
            this.storageService = storageService;
            this.trackingService = trackingService;
        }

        public void Run(Application.UseCases.Runners.CleanTemplate.Input input)
        {
            string output = Path.Combine(outputPath, input.OrderId.ToString());

            string arguments = $"new clean --use-cases {input.UseCases} --user-interface {input.UserInterface} --data-access {input.DataAccess} --tips {input.Tips} --skip-restore {input.SkipRestore} --name {input.Name.ToString()} --output {output}";

            trackingService.DotNetNewStarted(input.OrderId);

            GenerateTemplate(input.OrderId, arguments);

            trackingService.DotNetNewFinished(input.OrderId, string.Empty);

            Deliver(output, input.OrderId, input.Name.ToString());

            trackingService.UploadFinished(input.OrderId);
        }

        public void Run(Application.UseCases.Runners.HexagonalTemplate.Input input)
        {
            string output = Path.Combine(outputPath, input.OrderId.ToString());

            string arguments = $"new hexagonal --use-cases {input.UseCases} --user-interface {input.UserInterface} --data-access {input.DataAccess} --tips {input.Tips} --skip-restore {input.SkipRestore} --name {input.Name.ToString()} --output {output}";

            GenerateTemplate(input.OrderId, arguments);

            trackingService.DotNetNewFinished(input.OrderId, string.Empty);

            Deliver(output, input.OrderId, input.Name.ToString());

            trackingService.UploadFinished(input.OrderId);
        }

        public void Run(Application.UseCases.Runners.EventSourcingTemplate.Input input)
        {
            string output = Path.Combine(outputPath, input.OrderId.ToString());

            string arguments = $"new eventsourcing --use-cases {input.UseCases} --user-interface {input.UserInterface} --data-access {input.DataAccess} --service-bus {input.ServiceBus} --tips {input.Tips} --skip-restore {input.SkipRestore} --name {input.Name.ToString()} --output {output}";

            GenerateTemplate(input.OrderId, arguments);

            trackingService.DotNetNewFinished(input.OrderId, string.Empty);

            Deliver(output, input.OrderId, input.Name.ToString());

            trackingService.UploadFinished(input.OrderId);
        }

        private void GenerateTemplate(Guid orderId, string arguments)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            };

            process.Start();

            StringBuilder sb = new StringBuilder();

            while (!process.StandardOutput.EndOfStream)
            {
                sb.AppendLine(process.StandardOutput.ReadLine());

                trackingService.DotNetNewFinished(orderId, sb.ToString());
            }
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
