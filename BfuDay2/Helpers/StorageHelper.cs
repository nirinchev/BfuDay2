using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BfuDay2.Helpers
{
    public static class StorageHelper
    {
        public const string ContainerName = "bfu-files";
        public const string StorageEndpoint = "DefaultEndpointsProtocol=https;AccountName=bfufiles;AccountKey=KhfHXx5odepjlzlrlS0ihWefIUgZhBdomPtQgOydS5VaBtwD4sxgHX223jipiqov7qicQFvIef0Nc5eRCTV/Wg==";

        public static async Task<string> SaveFile(byte[] file, string name)
        {
            var blob = await GetBlob(name);
            await blob.UploadFromByteArrayAsync(file, 0, file.Length);

            var extension = Path.GetExtension(name);
            string contentType = null;
            switch (extension)
            {
                case ".jpg":
                    contentType = "image/jpeg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".pdf":
                    contentType = "application/pdf";
                    break;
            }
            if (contentType != null)
            {
                blob.Properties.ContentType = contentType;
                await blob.SetPropertiesAsync();
            }

            return blob.Uri.AbsoluteUri;
        }

        private static async Task<CloudBlockBlob> GetBlob(string id)
        {
            var client = CloudStorageAccount.Parse(StorageEndpoint).CreateCloudBlobClient();

            var container = client.GetContainerReference(ContainerName);
            await container.CreateIfNotExistsAsync();
            await container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Container
            });

            return container.GetBlockBlobReference(id);
        }
    }
}