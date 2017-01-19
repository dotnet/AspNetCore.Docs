var connectionString = "(your connection string)";
var config = new SqlScaleoutConfiguration(connectionString) { 
TableCount = 3,
MaxQueueLength = 50 };
GlobalHost.DependencyResolver.UseSqlServer(config);