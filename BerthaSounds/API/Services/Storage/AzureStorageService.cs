using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using API.Enums;
using API.Extensions;
using API.Models.Dtos;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace API.Services.Storage
{
	public class AzureStorageService : IAzureStorageService
	{
		private readonly CloudStorageAccount _cloudStorageAccount = CloudStorageAccount.Parse("AzureConnectionString");

		public void GetOrCreatePrivateContainer(AzureContainerEnum containerName = AzureContainerEnum.Sounds)
		{
			CloudBlobClient blobClient = _cloudStorageAccount.CreateCloudBlobClient();
			CloudBlobContainer container = blobClient.GetContainerReference(containerName.ToString().ToLower());

			container.CreateIfNotExists();
		}

		public void CreatePublicContainer(AzureContainerEnum containerName = AzureContainerEnum.Sounds)
		{
			CloudBlobClient blobClient = _cloudStorageAccount.CreateCloudBlobClient();
			CloudBlobContainer container = blobClient.GetContainerReference(containerName.ToString().ToLower());

			container.CreateIfNotExists();
		}

		public void SaveFile(HttpPostedFileBase file, AzureContainerEnum containerName = AzureContainerEnum.Sounds)
		{
			CloudBlobClient blobClient = _cloudStorageAccount.CreateCloudBlobClient();
			CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName.ToString().ToLower());

			string filename = string.Format("{0}.{1}", Guid.NewGuid(), Path.GetExtension(file.FileName));

			CloudBlockBlob block = blobContainer.GetBlockBlobReference(filename);
			block.Properties.ContentType = file.ContentType;
			block.UploadFromStream(file.InputStream);
		}

		public async Task<IEnumerable<object>> UploadFileToBlobContainer(HttpRequestMessage request, AzureContainerEnum containerName = AzureContainerEnum.Sounds)
		{
			CloudBlobClient blobClient = _cloudStorageAccount.CreateCloudBlobClient();
			CloudBlobContainer container = blobClient.GetContainerReference(containerName.ToString().ToLower());

			var provider = new AzureBlobMultipartFormDataStreamProvider(container);

			await request.Content.ReadAsMultipartAsync(provider);

			var files = new List<UploadDto>();

			foreach (var file in provider.FileData)
			{
				var blob = await container.GetBlobReferenceFromServerAsync(file.LocalFileName);
				await blob.FetchAttributesAsync();

				files.Add(new UploadDto
				{
					FileName = blob.Name,
					FileSize = blob.Properties.Length / 1024,
					CreatedOn = blob.Metadata["Created"] == null ? DateTime.Now : DateTime.Parse(blob.Metadata["Created"]),
					Url = blob.Uri.AbsoluteUri
				});
			}

			return files;
		}
	}
}
