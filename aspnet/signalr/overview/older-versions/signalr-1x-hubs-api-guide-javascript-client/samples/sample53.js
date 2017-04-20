contosoChatHubProxy.newContosoChatMessage(userName, message)
    .fail(function(error) { 
        console.log( 'newContosoChatMessage error: ' + error) 
    });