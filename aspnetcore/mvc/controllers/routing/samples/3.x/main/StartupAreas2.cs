#if Never
#region snippet_1
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Zebra_route", "Manage/{controller}/{action}/{id?}",
        defaults: new { area = "Zebra" }, constraints: new { area = "Zebra" });
    endpoints.MapControllerRoute("default_route", "{controller}/{action}/{id?}");
});
#endregion
#endif