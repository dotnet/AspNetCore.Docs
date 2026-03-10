### Infer passkey display name from authenticator

ASP.NET Core Identity now automatically infers friendly display names for passkeys based on their AAGUID (Authenticator Attestation GUID). Built-in mappings are included for the most commonly used passkey authenticators, including Google Password Manager, iCloud Keychain, Windows Hello, 1Password, and Bitwarden ([dotnet/aspnetcore#65343](https://github.com/dotnet/aspnetcore/pull/65343)).

For known authenticators, the name is automatically assigned without prompting the user. For unknown authenticators, the user is redirected to a rename page. Developers can extend the mappings by adding entries to the `PasskeyAuthenticators.cs` dictionary in their project ([dotnet/aspnetcore#63630](https://github.com/dotnet/aspnetcore/issues/63630)).
