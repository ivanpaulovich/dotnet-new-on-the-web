namespace Runner.Infrastructure.Storage
{
    using Runner.Application.UseCases.Runners;
    using System;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System.IO;
    using System.Threading.Tasks;

    public class StorageService : IStorageService
    {
        private readonly string storageAccountName;
        private readonly string accessKey;
        private readonly CloudStorageAccount storageAccount;
        private readonly CloudBlobClient blobClient;
        private readonly CloudBlobContainer container;

        public StorageService(string storageAccountName, string accessKey)
        {
            this.storageAccountName = storageAccountName;
            this.accessKey = accessKey;

            this.storageAccount = new CloudStorageAccount(
                new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                storageAccountName,
                accessKey), 
                true);

            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference("templates");
        }

        public async Task Upload(Guid orderId, string filename)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(orderId.ToString() + ".zip");
            bool exists = await blockBlob.ExistsAsync();

            if (!exists)
            {
                using (FileStream fileStream = File.OpenRead(filename))
                {
                    await blockBlob.UploadFromStreamAsync(fileStream);
                }
            }
        }
    }
}
