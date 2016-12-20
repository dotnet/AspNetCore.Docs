---
title: "Working with Groups in SignalR 1.x | Microsoft Docs"
author: pfletcher
description: "This topic describes how to persist group membership information with the Hub API."
ms.author: riande
manager: wpickett
ms.date: 10/21/2013
ms.topic: article
ms.assetid: 
ms.technology: dotnet-signalr
ms.prod: .net-framework
msc.legacyurl: /signalr/overview/older-versions/working-with-groups
---
Working with Groups in SignalR 1.x
====================
by [Patrick Fletcher](https://github.com/pfletcher), [Tom FitzMacken](https://github.com/tfitzmac)

> This topic describes how to add users to groups and persist group membership information.


## Overview

Groups in SignalR provide a method for broadcasting messages to specified subsets of connected clients. A group can have any number of clients, and a client can be a member of any number of groups. You don't have to explicitly create groups. In effect, a group is automatically created the first time you specify its name in a call to Groups.Add, and it is deleted when you remove the last connection from membership in it. For an introduction to using groups, see [How to manage group membership from the Hub class](index.md) in the Hubs API - Server Guide.

There is no API for getting a group membership list or a list of groups. SignalR sends messages to clients and groups based on a pub/sub model, and the server does not maintain lists of groups or group memberships. This helps maximize scalability, because whenever you add a node to a web farm, any state that SignalR maintains has to be propagated to the new node.

When you add a user to a group using the `Groups.Add` method, the user receives messages directed to that group for the duration of the current connection, but the user's membership in that group is not persisted beyond the current connection. If you want to permanently retain information about groups and group membership, you must store that data in a repository such as a database or Azure table storage. Then, each time a user connects to your application, you retrieve from the repository which groups the user belongs to, and manually add that user to those groups.

When reconnecting after a temporary disruption, the user automatically re-joins the previously-assigned groups. Automatically rejoining a group only applies when reconnecting, not when establishing a new connection. A digitally-signed token is passed from the client that contains the list of previously-assigned groups. If you want to verify whether the user belongs to the requested groups, you can override the default behavior.

This topic includes the following sections:

- [Adding and removing users](#add)
- [Calling members of a group](#call)
- [Storing group membership in a database](#storedatabase)
- [Storing group membership in Azure table storage](#storeazuretable)
- [Verifying group membership when reconnecting](#verify)

<a id="#add"></a>

## Adding and removing users

To add or remove users from a group, you call the [Add](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.igroupmanager.add(v=vs.111).aspx) or [Remove](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.igroupmanager.remove(v=vs.111).aspx) methods, and pass in the user's connection id and group's name as parameters. You do not need to manually remove a user from a group when the connection ends.

The following example shows the `Groups.Add` and `Groups.Remove` methods used in Hub methods.

[!code[Main](working-with-groups/samples/sample1.xml?highlight=5,10)]

The `Groups.Add` and `Groups.Remove` methods execute asynchronously.

If you want to add a client to a group and immediately send a message to the client by using the group, you have to make sure that the Groups.Add method finishes first. The following code examples show how to do that, one by using code that works in .NET 4.5, and one by using code that works in .NET 4.

#### Asynchronous .NET 4.5 Example

[!code[Main](working-with-groups/samples/sample2.xml?highlight=1,3)]

#### Asynchronous .NET 4 Example

[!code[Main](working-with-groups/samples/sample3.xml?highlight=3-4)]

In general, you should not include `await` when calling the `Groups.Remove` method because the connection id that you are trying to remove might no longer be available. In that case, `TaskCanceledException` is thrown after the request times out. If your application must ensure that the user has been removed from the group before sending a message to the group, you can add `await` before Groups.Remove, and then catch the `TaskCanceledException` exception that might be thrown.

<a id="#call"></a>

## Calling members of a group

You can send messages to all of the members of a group or only specified members of the group, as shown in the following examples.

- **All** connected clients in a specified group. 

        Clients.Group(groupName).addChatMessage(name, message);
- All connected clients in a specified group **except the specified clients**, identified by connection ID. 

        Clients.Group(groupName, connectionId1, connectionId2).addChatMessage(name, message);
- All connected clients in a specified group **except the calling client**. 

        Clients.OthersInGroup(groupName).addChatMessage(name, message);

<a id="storedatabase"></a>

## Storing group membership in a database

The following examples show how to retain group and user information in a database. You can use any data access technology; however, the example below shows how to define models using Entity Framework. These entity models correspond to database tables and fields. Your data structure could vary considerably depending on the requirements of your application. This example includes a class named `ConversationRoom` which would be unique to an application that enables users to join conversations about different subjects, such as sports or gardening. This example also includes a class for the connections. The connection class is not absolutely required for tracking group membership but is frequently part of robust solution to tracking users.

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    
    namespace GroupsExample
    {
        public class UserContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Connection> Connections { get; set; }
            public DbSet<ConversationRoom> Rooms { get; set; }
        }
    
        public class User
        {
            [Key]
            public string UserName { get; set; }
            public ICollection<Connection> Connections { get; set; }
            public virtual ICollection<ConversationRoom> Rooms { get; set; } 
        }
    
        public class Connection
        {
            public string ConnectionID { get; set; }
            public string UserAgent { get; set; }
            public bool Connected { get; set; }
        }
    
        public class ConversationRoom
        {
            [Key]
            public string RoomName { get; set; }
            public virtual ICollection<User> Users { get; set; }
        }
    }

Then, in the hub, you can retrieve the group and user information from the database and manually add the user to the appropriate groups. The example does not include code for tracking the user connections. In this example, the `await` keyword is not applied before `Groups.Add` because a message is not immediately sent to members of the group. If you want to send a message to all members of the group immediately after adding the new member, you would want to apply the `await` keyword to make sure the asynchronous operation has completed.

    using Microsoft.AspNet.SignalR;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace GroupsExample
    {
        [Authorize]
        public class ChatHub : Hub
        {
            public override Task OnConnected()
            {
                using (var db = new UserContext())
                {
                    // Retrieve user.
                    var user = db.Users
                        .Include(u => u.Rooms)
                        .SingleOrDefault(u => u.UserName == Context.User.Identity.Name);
    
                    // If user does not exist in database, must add.
                    if (user == null)
                    {
                        user = new User()
                        {
                            UserName = Context.User.Identity.Name
                        };
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    else
                    {
                        // Add to each assigned group.
                        foreach (var item in user.Rooms)
                        {
                            Groups.Add(Context.ConnectionId, item.RoomName);
                        }
                    }
                }
                return base.OnConnected();
            }
    
            public void AddToRoom(string roomName)
            {
                using (var db = new UserContext())
                {
                    // Retrieve room.
                    var room = db.Rooms.Find(roomName);
    
                    if (room != null)
                    {
                        var user = new User() { UserName = Context.User.Identity.Name};
                        db.Users.Attach(user);
    
                        room.Users.Add(user);
                        db.SaveChanges();
                        Groups.Add(Context.ConnectionId, roomName);
                    }
                }
            }
    
            public void RemoveFromRoom(string roomName)
            {
                using (var db = new UserContext())
                {
                    // Retrieve room.
                    var room = db.Rooms.Find(roomName);
                    if (room != null)
                    {
                        var user = new User() { UserName = Context.User.Identity.Name };
                        db.Users.Attach(user);
    
                        room.Users.Remove(user);
                        db.SaveChanges();
                        
                        Groups.Remove(Context.ConnectionId, roomName);
                    }
                }
            }
        }
    }

<a id="storeazuretable"></a>

## Storing group membership in Azure table storage

Using Azure table storage to store group and user information is similar to using a database. The following example shows a table entity that stores the user name and group name.

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

In the hub, you retrieve the assigned groups when the user connects.

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

<a id="verify"></a>

## Verifying group membership when reconnecting

By default, SignalR automatically re-assigns a user to the appropriate groups when reconnecting from a temporary disruption, such as when a connection is dropped and re-established before the connection times out. The user's group information is passed in a token when reconnecting, and that token is verified on the server. For information about the verification process for rejoining users to groups, see [Rejoining groups when reconnecting](index.md).

In general, you should use the default behavior of automatically rejoining groups on reconnect. SignalR groups are not intended as a security mechanism for restricting access to sensitive data. However, if your application must double-check a user's group membership when reconnecting, you can override the default behavior. Changing the default behavior can add a burden to your database because a user's group membership must be retrieved for each reconnection rather than just when the user connects.

If you must verify group membership on reconnect, create a new hub pipeline module that returns a list of assigned groups, as shown below.

    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    
    namespace GroupsExample
    {
        public class RejoingGroupPipelineModule : HubPipelineModule
        {
            public override Func<HubDescriptor, IRequest, IList<string>, IList<string>> 
                BuildRejoiningGroups(Func<HubDescriptor, IRequest, IList<string>, IList<string>> 
                rejoiningGroups)
            {
                rejoiningGroups = (hb, r, l) => 
                {
                    List<string> assignedRooms = new List<string>();
                    using (var db = new UserContext())
                    {
                        var user = db.Users.Include(u => u.Rooms)
                            .Single(u => u.UserName == r.User.Identity.Name);
                        foreach (var item in user.Rooms)
                        {
                            assignedRooms.Add(item.RoomName);
                        }
                    }
                    return assignedRooms;
                };
    
                return rejoiningGroups;
            }
        }
    }

Then, add that module to the hub pipeline, as highlighted below.

[!code[Main](working-with-groups/samples/sample4.xml?highlight=10)]