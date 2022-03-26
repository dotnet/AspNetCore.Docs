---
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
### View the Identity database

# [Visual Studio](#tab/visual-studio) 

* From the **View** menu, select **SQL Server Object Explorer** (SSOX).
* Navigate to **(localdb)MSSQLLocalDB(SQL Server 13)**. Right-click on **dbo.AspNetUsers** > **View Data**:

![Contextual menu on AspNetUsers table in SQL Server Object Explorer](~/security/authentication/accconfirm/_static/ssox.png)

# [.NET Core CLI](#tab/netcore-cli)

There are many third party tools you can download to manage and view a SQLite database, for example [DB Browser for SQLite](https://sqlitebrowser.org/).

---