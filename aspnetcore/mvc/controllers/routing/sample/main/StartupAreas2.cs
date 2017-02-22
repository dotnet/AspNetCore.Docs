#if Never
#region snippet_1
app.UseMvc(routes =>
{
    routes.MapRoute("Zebra_route", "Manage/{controller}/{action}/{id?}",
        defaults: new { area = "Zebra" }, constraints: new { area = "Zebra" });
    routes.MapRoute("default_route", "{controller}/{action}/{id?}");
});
#endregion
#endif