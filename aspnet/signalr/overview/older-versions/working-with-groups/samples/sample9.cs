using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace GroupsExample
{
    public class UserGroupEntity : TableEntity
    {
        public UserGroupEntity() { }

        public UserGroupEntity(string userName, string groupName)
        {
            this.PartitionKey = userName;
            this.RowKey = groupName;
        }
    }
}