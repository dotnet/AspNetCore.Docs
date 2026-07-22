### MCP Server template ships with the .NET SDK

The [Model Context Protocol (MCP)](https://modelcontextprotocol.io/) is an open standard that AI applications and agents, such as those in Visual Studio, Visual Studio Code, and GitHub Copilot, use to discover and call external tools, data, and services through a consistent interface. An *MCP server* exposes your own functionality, such as custom tools or access to a data source, so an AI host can invoke it on the user's behalf.

Use the `mcpserver` template when you want to build a C# MCP server that integrates your code or services with AI-powered tools. The generated project uses the [official C# SDK for MCP](https://github.com/modelcontextprotocol/csharp-sdk) and includes a working sample tool, so you have a runnable starting point to extend with your own tools.

The `mcpserver` project template, previously available only by installing `Microsoft.McpServer.ProjectTemplates`, now ships as a bundled template in the .NET SDK:

```dotnetcli
dotnet new mcpserver -o MyMcpServer
```

Moving the template into ASP.NET Core makes it discoverable from `dotnet new list` without a separate install step, and aligns its servicing with the rest of the web stack.

For more information, see [Build a Model Context Protocol (MCP) server in C#](/dotnet/ai/quickstarts/build-mcp-server).
