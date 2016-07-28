using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace DDD.Infrastructure.CrossCutting.Helpers
{
    public static class AzureStorageTableHelper
    {
        public static async Task<IEnumerable<T>> SelectManyAsync<T>(CloudStorageAccount cloudStorageAccount,
            string tableName, string filter) where T : class, ITableEntity, new()
        {
            var result = new List<T>();
            try
            {
                CloudTableClient tableClient = cloudStorageAccount.CreateCloudTableClient();

                CloudTable table = tableClient.GetTableReference(tableName);
                TableQuery<T> query = new TableQuery<T>();
                if (!string.IsNullOrEmpty(filter))
                {
                    query = query.Where(filter);
                }

                TableContinuationToken token = null;
                do
                {
                    var seg = await table.ExecuteQuerySegmentedAsync(query, token);
                    token = seg.ContinuationToken;
                    result.AddRange(seg);
                } while (token != null);
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public static async Task InsertAsync<T>(CloudStorageAccount cloudStorageAccount,
            string tableName, T input) where T : class, ITableEntity, new()
        {
            try
            {
                CloudTableClient tableClient = cloudStorageAccount.CreateCloudTableClient();
                CloudTable table = tableClient.GetTableReference(tableName);
                table.CreateIfNotExists();

                TableOperation insertOperation = TableOperation.Insert(input);

                await table.ExecuteAsync(insertOperation);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task InsertManyAsync<T>(CloudStorageAccount cloudStorageAccount,
            string tableName, IEnumerable<T> inputCollection) where T : class, ITableEntity, new()
        {
            try
            {
                CloudTableClient tableClient = cloudStorageAccount.CreateCloudTableClient();
                CloudTable table = tableClient.GetTableReference(tableName);
                table.CreateIfNotExists();

                TableBatchOperation batchOperation = new TableBatchOperation();

                foreach (var input in inputCollection)
                {
                    batchOperation.InsertOrMerge(input);
                }

                await table.ExecuteBatchAsync(batchOperation);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
