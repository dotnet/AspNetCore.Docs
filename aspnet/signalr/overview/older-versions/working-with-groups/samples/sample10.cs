using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure;

namespace GroupsExample
{
    [Authorize]
    public class ChatHub : Hub
    {
        public override Task OnConnected()
        {
            string userName = Context.User.Identity.Name;

            var table = GetRoomTable();
            table.CreateIfNotExists();
            var query = new TableQuery<UserGroupEntity>()
                .Where(TableQuery.GenerateFilterCondition(
                "PartitionKey", QueryComparisons.Equal, userName));
            
            foreach (var entity in table.ExecuteQuery(query))
            {
                Groups.Add(Context.ConnectionId, entity.RowKey);
            }

            return base.OnConnected();
        }

        public Task AddToRoom(string roomName)
        {
            string userName = Context.User.Identity.Name;

            var table = GetRoomTable();

            var insertOperation = TableOperation.InsertOrReplace(
                new UserGroupEntity(userName, roomName));
            table.Execute(insertOperation);

            return Groups.Add(Context.ConnectionId, roomName);
        }

        public Task RemoveFromRoom(string roomName)
        {
            string userName = Context.User.Identity.Name;

            var table = GetRoomTable();

            var retrieveOperation = TableOperation.Retrieve<UserGroupEntity>(
                userName, roomName);
            var retrievedResult = table.Execute(retrieveOperation);

            var deleteEntity = (UserGroupEntity)retrievedResult.Result;

            if (deleteEntity != null)
            {
                var deleteOperation = TableOperation.Delete(deleteEntity);
                table.Execute(deleteOperation);
            }

            return Groups.Remove(Context.ConnectionId, roomName);
        }

       private CloudTable GetRoomTable()
        {
            var storageAccount =
                CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
            var tableClient = storageAccount.CreateCloudTableClient();
            return tableClient.GetTableReference("room");
        }
    }
}