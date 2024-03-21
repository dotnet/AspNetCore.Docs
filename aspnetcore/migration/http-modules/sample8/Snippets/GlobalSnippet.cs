class GlobalSnippet
{
    void Snippet(WebApplicationBuilder builder)
    {
        #region snippet_AddGlobal
        builder.Services.AddSystemWebAdapters()
            .AddHttpApplication<Global>();
        #endregion
    }
}

class Global { }
