let connection = new signalR.HubConnectionBuilder()
    .withUrl("/my/hub/url")
    .configureLogging(signalR.LogLevel.Trace)
    .build();