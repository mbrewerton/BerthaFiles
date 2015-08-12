using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace API.Services.Storage
{
	public class AzureStorageService
	{
		private readonly CloudStorageAccount _cloudStorageAccount = CloudStorageAccount.Parse("AzureConnectionString");
		public void CreatePublicContainer(string containerName)
		{
			CloudBlobClient blobClient = _cloudStorageAccount.CreateCloudBlobClient();
			CloudBlobContainer container = blobClient.GetContainerReference(containerName.ToLower());

			container.CreateIfNotExists();
		}

		public void SaveFile(HttpPostedFileBase file, string containerName)
		{
			CloudBlobClient blobClient = _cloudStorageAccount.CreateCloudBlobClient();
			CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName.ToLower());

			string filename = string.Format("{0}.{1}", Guid.NewGuid(), Path.GetExtension(file.FileName));

			CloudBlockBlob block = blobContainer.GetBlockBlobReference(filename);
			block.Properties.ContentType = file.ContentType;
			block.UploadFromStream(file.InputStream);
		}
	}
}
