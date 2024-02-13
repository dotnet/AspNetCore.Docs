### Dictionary debugging improvements

The debugging display of dictionaries and other key-value collections has an improved layout. The key is displayed in the debugger's key column instead of being concatenated with the value. The following images show the old and new display of a dictionary in the debugger.

Before:

<img width="353" alt="image" src="https://github.com/dotnet/AspNetCore.Docs/assets/3605364/680a5979-42b2-48fc-9ba7-693888912cc0">

after

<img width="368" alt="image" src="https://github.com/dotnet/AspNetCore.Docs/assets/3605364/9b38e416-e820-43c6-ac76-aec90e6a5d5e">

ASP.NET Core has many key-value collections. This improved debugging experience applies to:

- HTTP headers
- Query strings
- Forms
- Cookies
- View data
- Route data
- Features
