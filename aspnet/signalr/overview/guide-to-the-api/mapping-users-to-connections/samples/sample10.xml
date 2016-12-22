using Microsoft.AspNet.SignalR;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MapUsersSample
{
    public class ChatHub : Hub
    {
        public void SendChatMessage(string who, string message)
        {
            var name = Context.User.Identity.Name;
            
            var table = GetConnectionTable();

            var query = new TableQuery<ConnectionEntity>()
                .Where(TableQuery.GenerateFilterCondition(
                "PartitionKey", 
                QueryComparisons.Equal, 
                who));

            var queryResult = table.ExecuteQuery(query).ToList();
            if (queryResult.Count == 0)
            {
                Clients.Caller.showErrorMessage("The user is no longer connected.");
            }
            else
            {
                foreach (var entity in queryResult)
                {
                    Clients.Client(entity.RowKey).addChatMessage(name + ": " + message);
                }
            }
        }

        public override Task OnConnected()
        {
            var name = Context.User.Identity.Name;
            var table = GetConnectionTable();
            table.CreateIfNotExists();

            var entity = new ConnectionEntity(
                name.ToLower(), 
                Context.ConnectionId);
            var insertOperation = TableOperation.InsertOrReplace(entity);
            table.Execute(insertOperation);
            
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var name = Context.User.Identity.Name;
            var table = GetConnectionTable();

            var deleteOperation = TableOperation.Delete(
                new ConnectionEntity(name, Context.ConnectionId) { ETag = "*" });
            table.Execute(deleteOperation);

            return base.OnDisconnected(stopCalled);
        }

        private CloudTable GetConnectionTable()
        {
            var storageAccount =
                CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
            var tableClient = storageAccount.CreateCloudTableClient();
            return tableClient.GetTableReference("connection");
        }
    }
}