// EF follows a Code based Configuration model and will look for a class that
// derives from DbConfiguration for executing any Connection Resiliency strategies
public class EFConfiguration : DbConfiguration
{
    public EFConfiguration()
    {
        AddExecutionStrategy(() => new SqlAzureExecutionStrategy());
    }
}