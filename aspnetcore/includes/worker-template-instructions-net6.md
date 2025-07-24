# [Visual Studio](#tab/visual-studio)

1. Create a new project.
1. Select **Worker Service**. Select **Next**.
1. Provide a project name in the **Project name** field or accept the default project name. Select **Next**.
1. In the **Additional information** dialog, Choose a **Framework**. Select **Create**.

# [.NET CLI](#tab/net-cli)

Use the Worker Service (`worker`) template with the [dotnet new](/dotnet/core/tools/dotnet-new) command from a command shell. In the following example, a Worker Service app is created named `ContosoWorker`. A folder for the `ContosoWorker` app is created automatically when the command is executed.

```dotnetcli
dotnet new worker -o ContosoWorker
```

---
