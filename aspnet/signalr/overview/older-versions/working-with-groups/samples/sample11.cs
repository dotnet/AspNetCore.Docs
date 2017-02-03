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