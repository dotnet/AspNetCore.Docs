app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapHub<ChatHub>("/chatHub");
    endpoints.MapFallbackToClientSideBlazor<Client.Program>("index.html");
});
