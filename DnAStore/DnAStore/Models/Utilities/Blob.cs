using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DnAStore.Models.Utilities
{
	public class Blob
	{
		public CloudStorageAccount CloudStorage { get; set; }
		public CloudBlobClient CloudBlobClient { get; set; }

		public Blob(IConfiguration configuration)
		{
			CloudStorage = CloudStorageAccount.Parse(configuration["AzureBlobConnectionString"]);
			// Chaining onto value above
			CloudBlobClient = CloudStorage.CreateCloudBlobClient();
		}

		public async Task<CloudBlobContainer> GetContainer(string containerName)
		{
			CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
			await cbc.CreateIfNotExistsAsync();
			await cbc.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

			return cbc;

			// Code to go in controller action

			//Blob blob = new Blob(Configuration);
			//// For getting container
			//await blob.GetContainer("product-image-asset-blob");

			//// For getting blob
			//CloudBlob blobImage = await blob.GetBlob("AristarchusCrater.png", "product-image-asset-blob");

			//var image = blobImage.Uri;
		}

		public async Task<CloudBlob> GetBlob(string imageName, string containerName)
		{
			CloudBlobContainer container = await GetContainer(containerName);
			CloudBlob blob = container.GetBlobReference(imageName);
			return blob;
		}

		public void UploadFile(CloudBlobContainer container, string filename, string filepath)
		{
			CloudBlockBlob blobFile = container.GetBlockBlobReference(filename);
			blobFile.UploadFromFileAsync(filepath);
		}
	}
}
