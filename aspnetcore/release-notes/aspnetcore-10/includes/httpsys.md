### Configure Custom Security Descriptors for HTTP.sys Request Queues
<!--PR: https://github.com/dotnet/aspnetcore/pull/61325-->

You can now specify a custom security descriptor for HTTP.sys request queues using the new `RequestQueueSecurityDescriptor` property on `HttpSysOptions`. This feature enables more granular control over access rights for the request queue, helping you tailor security to your application's needs.

# Why this matters

By customizing the security descriptor, you can allow or deny specific users or groups access to the request queue. This is particularly useful in scenarios where you want to restrict or delegate HTTP.sys request handling at the operating system level.

# How to use

Set the `RequestQueueSecurityDescriptor` property to a `GenericSecurityDescriptor` instance when configuring your HTTP.sys server. For example, to allow all users but deny guests:

```csharp
using System.Security.AccessControl;
using System.Security.Principal;
using Microsoft.AspNetCore.Server.HttpSys;

// Create a new security descriptor
var securityDescriptor = new CommonSecurityDescriptor(isContainer: false, isDS: false, sddlForm: string.Empty);

// Create a discretionary access control list (DACL)
var dacl = new DiscretionaryAcl(isContainer: false, isDS: false, capacity: 2);
dacl.AddAccess(
    AccessControlType.Allow,
    new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null),
    -1,
    InheritanceFlags.None,
    PropagationFlags.None
);
dacl.AddAccess(
    AccessControlType.Deny,
    new SecurityIdentifier(WellKnownSidType.BuiltinGuestsSid, null),
    -1,
    InheritanceFlags.None,
    PropagationFlags.None
);

// Assign the DACL to the security descriptor
securityDescriptor.DiscretionaryAcl = dacl;

// Configure HTTP.sys options
var builder = WebApplication.CreateBuilder();
builder.WebHost.UseHttpSys(options =>
{
    options.RequestQueueSecurityDescriptor = securityDescriptor;
});
```

# Additional Notes

The `RequestQueueSecurityDescriptor` applies only when creating a new request queue.
This property does not affect existing request queues.
See the official documentation for more information about Windows security descriptors and their usage.