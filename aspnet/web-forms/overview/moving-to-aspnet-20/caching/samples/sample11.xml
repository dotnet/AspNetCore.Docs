try {
    SqlCacheDependency SqlDep = new
    SqlCacheDependency("pubs", "authors");
} catch (DatabaseNotEnabledForNotificationException exDBDis) {
    try {
        SqlCacheDependencyAdmin.EnableNotifications("pubs");
    } catch (UnauthorizedAccessException exPerm) {
        Response.Redirect("ErrorPage.htm");
    }
} catch (TableNotEnabledForNotificationException exTabDis) {
    try {
        SqlCacheDependencyAdmin.EnableTableForNotifications("pubs",
        "authors");
    } catch (System.Data.SqlClient.SqlException exc) {
        Response.Redirect("ErrorPage.htm");
    }
} finally {
    Cache.Insert("SqlSource", Source1, SqlDep);
}