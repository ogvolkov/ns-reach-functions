using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace NsReach.Functions.Data
{
    public class CloudTableClientFactory
    {
        public CloudTableClient Create()
        {
            string storageConnectionString = Environment.GetEnvironmentVariable("NSREACH_STORAGE_ACCOUNT");
            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            return tableClient;
        }
    }
}
