### `dotnet user-jwts` supports file-based apps

The `dotnet user-jwts` tool creates signed development JWTs so you can call an app's authenticated endpoints without setting up a real identity provider. The `create` command generates a token, stores its signing key in the app's user secrets, and prints the token to use as a bearer token. It now works with file-based apps (a single `app.cs` with no project file) through the new `--file` option:

```bash
dotnet user-jwts create --file app.cs
```
