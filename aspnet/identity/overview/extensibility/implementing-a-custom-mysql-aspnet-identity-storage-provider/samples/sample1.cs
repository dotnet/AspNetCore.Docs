public class ApplicationDbContext : MySQLDatabase
{
    public ApplicationDbContext(string connectionName)
        : base(connectionName)
    {
    }

    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext("DefaultConnection");
    }
}