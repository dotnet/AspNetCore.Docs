# Configure connection strings for appdb and ASP.NET member db
$connectionStrings = ( `
    @{Name = $sqlAppDatabaseName; Type = "SQLAzure"; ConnectionString = $sql.AppDatabase.ConnectionString}, `
    @{Name = "DefaultConnection"; Type = "SQLAzure"; ConnectionString = $sql.MemberDatabase.ConnectionString}
)