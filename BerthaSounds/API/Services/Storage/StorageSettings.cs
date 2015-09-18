using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace API.Services.Storage
{
	public static class StorageSettings
	{
		public static CloudStorageAccount StorageAccount()
		{
			string name = CloudConfigurationManager.GetSetting("AzureAccountName");
			string key = CloudConfigurationManager.GetSetting("AzureAccountKey");
			string connectionString = String.Format("DefaultEndpointsProtocol=http;AccountName={0};AccountKey={1}", name, key);

			return CloudStorageAccount.Parse(connectionString);
		}
	}
}
