### Customizable security descriptors for HTTP.sys
<!--PR: https://github.com/dotnet/aspnetcore/pull/61325-->

You can now specify a custom security descriptor for HTTP.sys request queues. The new [RequestQueueSecurityDescriptor](https://source.dot.net/#Microsoft.AspNetCore.Server.HttpSys/HttpSysOptions.cs,a556950881fd2d87) property on <xref:Microsoft.AspNetCore.Server.HttpSys.HttpSysOptions> enables more granular control over access rights for the request queue. This granular control lets you tailor security to your application's needs.

#### Why use the new property?

A *request queue* in HTTP.sys is a kernel-level structure that temporarily stores incoming HTTP requests until your application is ready to process them. By customizing the security descriptor, you can allow or deny specific users or groups access to the request queue. This is useful in scenarios where you want to restrict or delegate HTTP.sys request handling at the operating system level.

#### How to use the new property

The `RequestQueueSecurityDescriptor` property applies only when creating a new request queue. The property doesn't affect existing request queues. To use this property, set it to a <xref:System.Security.AccessControl.GenericSecurityDescriptor> instance when configuring your HTTP.sys server.

For example, the following code allows all authenticated users but denies guests:

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

For more information, see <xref:fundamentals/servers/httpsys>.
