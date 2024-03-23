class UseAuthenticationAndAuthorizationSnippet
{
    void Snippet(WebApplication app)
    {
        #region snippet_UseAuthenticationAndAuthorization
        app.UseAuthentication();
        app.UseAuthenticationEvents();

        app.UseAuthorization();
        app.UseAuthorizationEvents();
        #endregion
    }
}
