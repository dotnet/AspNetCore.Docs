public class UsersContext : DbContext
{
    public UsersContext()
        : base("DefaultConnection")
    {
    }

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<ExternalUserInformation> ExternalUsers { get; set; }
}