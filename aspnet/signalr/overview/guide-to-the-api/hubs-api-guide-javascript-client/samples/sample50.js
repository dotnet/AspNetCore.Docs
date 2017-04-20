var connection = $.hubConnection();
connection.error(function (error) {
    console.log('SignalR error: ' + error)
});