> [!TIP]
> Use [`git sparse-checkout`](https://git-scm.com/docs/git-sparse-checkout) to only download the sample subfolder and the last commit. For example:
```
git clone --depth 1 --filter=blob:none https://github.com/dotnet/AspNetCore.Docs.git --sparse
cd AspNetCore.Docs
git sparse-checkout init --cone
git sparse-checkout set aspnetcore/security/authorization/secure-data/samples
```

In the preceding example, the `git sparse-checkout set` command specifies the path to the subfolder that you want to download. Replace 
`aspnetcore/security/authorization/secure-data/samples` with the path to the subfolder that you want to download.