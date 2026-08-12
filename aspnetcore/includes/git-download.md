> [!TIP]
> Use the [`git sparse-checkout` command](https://git-scm.com/docs/git-sparse-checkout) to download a single folder from the main branch of a GitHub repository.
>
> In the following example, the `security/authorization/BlazorWebAppAuthorization` subfolder is downloaded from the `dotnet/AspNetCore.Docs.Samples` repository. Replace `https://github.com/dotnet/AspNetCore.Docs.Samples.git` with the URL of the repository that you want to clone, and replace the `security/authorization/BlazorWebAppAuthorization` path with the path to the subfolder that you want to download:
>
> ```
> git clone --depth 1 --filter=blob:none https://github.com/dotnet/AspNetCore.Docs.Samples.git --sparse
> cd AspNetCore.Docs.Samples
> git sparse-checkout init --cone
> git sparse-checkout set security/authorization/BlazorWebAppAuthorization
> ```
