### MCP Server template ships with the .NET SDK

The `mcpserver` project template, previously available only by installing `Microsoft.McpServer.ProjectTemplates`, now ships as a bundled template in the .NET SDK:

```dotnetcli
dotnet new mcpserver -o MyMcpServer
```

Moving the template into ASP.NET Core makes it discoverable from `dotnet new list` without a separate install step, and aligns its servicing with the rest of the web stack.
