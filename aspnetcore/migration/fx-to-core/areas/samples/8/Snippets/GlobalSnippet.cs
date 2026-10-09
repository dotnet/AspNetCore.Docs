class GlobalSnippet
{
    void Snippet(WebApplicationBuilder builder)
    {
// <snippet_AddGlobal>
        builder.Services.AddSystemWebAdapters()
            .AddHttpApplication<Global>();
// </snippet_AddGlobal>
    }
}

class Global { }
