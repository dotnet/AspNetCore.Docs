$.connection.hub.start().done(function () {
    console.log("Connected, transport = " + $.connection.hub.transport.name);
});