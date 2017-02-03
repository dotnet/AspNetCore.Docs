public class MyFixItContext : DbContext
{
    public MyFixItContext()
        : base("name=appdb")
    {
    }

    public DbSet<MyFixIt.Persistence.FixItTask> FixItTasks { get; set; }
}