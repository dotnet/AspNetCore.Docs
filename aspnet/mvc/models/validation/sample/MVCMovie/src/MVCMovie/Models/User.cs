using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMovie.Models
{
    public class User
    {
        public int Id { get; set; }

        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }
        public string FullName { get; set; }

    }
}


//// Controller in root area.
//[Remote(action: "IsIdAvailable", controller: "RemoteAttribute_Verify", areaName: null, HttpMethod = "Post")]
//public string UserId2 { get; set; }

//[Remote(
//    action: "IsIdAvailable",
//    controller: "RemoteAttribute_Verify",
//    areaName: "Area1",
//    ErrorMessage = "/Area1/RemoteAttribute_Verify/IsIdAvailable rejects you.")]
//public string UserId3 { get; set; }

//[Remote(
//    action: "IsIdAvailable",
//    controller: "RemoteAttribute_Verify",
//    areaName: "Area2",
//    AdditionalFields = "UserId1, UserId2, UserId3")]
//public string UserId4 { get; set; }