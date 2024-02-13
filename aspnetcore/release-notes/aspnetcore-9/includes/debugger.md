### Dictionary debugging improvements

The debugging display of dictionaries and other key-value collections has an improved layout. The key is displayed in the debugger's key column instead of being concatenated with the value. The following images show the old and new display of a dictionary in the debugger.

Before:

:::image type="content" source="~/release-notes/aspnetcore-9/_static/debugger-before.png" alt-text="The previous debugger experience":::

After:

:::image type="content" source="~/release-notes/aspnetcore-9/_static/debugger-after.png" alt-text="The new debugger experience":::

ASP.NET Core has many key-value collections. This improved debugging experience applies to:

- HTTP headers
- Query strings
- Forms
- Cookies
- View data
- Route data
- Features
