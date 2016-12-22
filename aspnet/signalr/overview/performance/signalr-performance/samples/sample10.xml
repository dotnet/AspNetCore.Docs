string connectionString = "(your connection string)";
var config = new ServiceBusScaleoutConfiguration(connectionString, "YourAppName") { 
TopicCount = 3,
MaxQueueLength = 50 };
GlobalHost.DependencyResolver.UseServiceBus(config);