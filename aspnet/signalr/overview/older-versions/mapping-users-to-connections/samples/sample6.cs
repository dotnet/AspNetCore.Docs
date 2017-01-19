using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace MapUsersSample
{
    public class ConnectionEntity : TableEntity
    {
        public ConnectionEntity() { }        

        public ConnectionEntity(string userName, string connectionID)
        {
            this.PartitionKey = userName;
            this.RowKey = connectionID;
        }
    }
}