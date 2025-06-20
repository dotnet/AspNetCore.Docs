class UseAuthenticationAndAuthorizationSnippet
{
    void Snippet(WebApplication app)
    {
// <snippet_UseAuthenticationAndAuthorization>
        app.UseAuthentication();
        app.UseAuthenticationEvents();

        app.UseAuthorization();
        app.UseAuthorizationEvents();
// </snippet_UseAuthenticationAndAuthorization>
    }
}
