using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace API.Extensions
{
	public class AzureBlobMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
	{
		private CloudBlobContainer _container;
		public AzureBlobMultipartFormDataStreamProvider(CloudBlobContainer container) : base("azure")
		{
			_container = container;
		}

		public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
		{
			if (parent == null)
				throw new ArgumentNullException("parent");

			if (headers == null)
				throw new ArgumentNullException("headers");

			var fileName = this.GetLocalFileName(headers);

			CloudBlockBlob blob = _container.GetBlockBlobReference(fileName);
			blob.Metadata["Created"] = DateTime.Now.ToString();

			if (headers.ContentType != null)
				blob.Properties.ContentType = headers.ContentType.MediaType;

			FileData.Add(new MultipartFileData(headers, blob.Name));

			return blob.OpenWrite();
		}

		public override string GetLocalFileName(HttpContentHeaders headers)
		{
			var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName)
				? headers.ContentDisposition.FileName
				: "NoName";
			name = name.Trim(new char[]{'"'}).Replace("&", "and");
			name = Path.GetFileName(name);

			return name;
		}
	}
}
