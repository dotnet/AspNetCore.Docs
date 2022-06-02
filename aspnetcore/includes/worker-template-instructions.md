# [Visual Studio](#tab/visual-studio)

1. Create a new project.
1. Select **Worker Service**. Select **Next**.
1. Provide a project name in the **Project name** field or accept the default project name. Select **Create**.
1. In the **Create a new Worker service** dialog, select **Create**.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Create a new project.
1. Select **App** under **.NET Core** in the sidebar.
1. Select **Worker** under **ASP.NET Core**. Select **Next**.
1. Select **.NET Core 3.0** or later for the **Target Framework**. Select **Next**.
1. Provide a name in the **Project Name** field. Select **Create**.

# [.NET Core CLI](#tab/netcore-cli)

Use the Worker Service (`worker`) template with the [dotnet new](/dotnet/core/tools/dotnet-new) command from a command shell. In the following example, a Worker Service app is created named `ContosoWorker`. A folder for the `ContosoWorker` app is created automatically when the command is executed.

```dotnetcli
dotnet new worker -o ContosoWorker
```

---
