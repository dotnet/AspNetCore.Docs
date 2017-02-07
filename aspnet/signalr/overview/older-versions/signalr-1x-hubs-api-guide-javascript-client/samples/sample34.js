var connection = $.hubConnection();
var contosoChatHubProxy = connection.createHubProxy('contosoChatHub');
chatHubProxy.on('addMessageToPage', function (message) {
    console.log(message.UserName + ' ' + message.Message);
});