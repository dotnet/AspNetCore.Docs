### Dictionary debugging improvements

The debugging display of dictionaries and other key-value collections has an improved layout. The key is displayed in the debugger's key column instead of being concatenated with the value. The following images show the old and new display of a dictionary in the debugger.

Before:

![Prior experience debugging dictionaries.](https://github.com/dotnet/release-notes-drafts/assets/1874516/fac8289b-9e76-4de0-99ce-c043870dd027)

After: 

![New experience debugging dictionaries.](https://github.com/dotnet/release-notes-drafts/assets/1874516/52553a6d-532a-406d-bc13-91e25d1216b8)

ASP.NET Core has many key-value collections. This improved debugging experience applies to:

- HTTP headers
- Query strings
- Forms
- Cookies
- View data
- Route data
- Features
