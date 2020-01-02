#if Never
#region snippet_1
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute("zebra_route", "Zebra",
        "Manage/{controller}/{action}/{ id ?}");
    endpoints.MapControllerRoute("default_route", "{controller}/{action}/{id?}");
});
#endregion
#endif