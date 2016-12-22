Connection = new HubConnection(ServerURI);
var writer = new TextBlockWriter(SynchronizationContext.Current, StackPanelConsole);
Connection.TraceWriter = writer;
Connection.TraceLevel = TraceLevels.All;