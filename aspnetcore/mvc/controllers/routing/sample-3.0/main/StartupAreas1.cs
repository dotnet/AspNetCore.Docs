#if Never
#region snippet_1
app.UseMvc(routes =>
{
    routes.MapAreaRoute("zebra_route", "Zebra",
        "Manage/{controller}/{action}/{ id ?}");
    routes.MapRoute("default_route", "{controller}/{action}/{id?}");
});
#endregion
#endif