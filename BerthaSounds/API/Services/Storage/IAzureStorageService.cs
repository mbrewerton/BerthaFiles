using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using API.Enums;

namespace API.Services.Storage
{
	public interface IAzureStorageService
	{
		void GetOrCreatePrivateContainer(AzureContainerEnum containerName = AzureContainerEnum.Sounds);
		void CreatePublicContainer(AzureContainerEnum containerName = AzureContainerEnum.Sounds);
		void SaveFile(HttpPostedFileBase file, AzureContainerEnum containerName = AzureContainerEnum.Sounds);
		Task<IEnumerable<object>> UploadFileToBlobContainer(HttpRequestMessage request, AzureContainerEnum containerName = AzureContainerEnum.Sounds);
	}
}