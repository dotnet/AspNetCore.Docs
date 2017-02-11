$.extend(contosoChatHubProxy.client, {
    addContosoChatMessageToPage: function(userName, message) {
    console.log(userName + ' ' + message);
    };
});