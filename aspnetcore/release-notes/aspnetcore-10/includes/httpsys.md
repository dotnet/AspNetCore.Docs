### Customizable security descriptors for HTTP.sys
<!--PR: https://github.com/dotnet/aspnetcore/pull/61325-->

You can now specify a custom security descriptor for HTTP.sys request queues. The new [RequestQueueSecurityDescriptor](https://source.dot.net/#Microsoft.AspNetCore.Server.HttpSys/HttpSysOptions.cs,a556950881fd2d87) property on <xref:Microsoft.AspNetCore.Server.HttpSys.HttpSysOptions> enables more granular control over access rights for the request queue. This granular control lets you tailor security to your application's needs.

#### What you can do with the new property

A *request queue* in HTTP.sys is a kernel-level structure that temporarily stores incoming HTTP requests until your application is ready to process them. By customizing the security descriptor, you can allow or deny specific users or groups access to the request queue. This is useful in scenarios where you want to restrict or delegate HTTP.sys request handling at the operating system level.

#### How to use the new property

The `RequestQueueSecurityDescriptor` property applies only when creating a new request queue. The property doesn't affect existing request queues. To use this property, set it to a <xref:System.Security.AccessControl.GenericSecurityDescriptor> instance when configuring your HTTP.sys server.

For example, the following code allows all authenticated users but denies guests:
[!code-csharp[](~/release-notes/aspnetcore-10/samples/HttpSysConfig/Program.cs)]

For more information, see <xref:fundamentals/servers/httpsys>.
