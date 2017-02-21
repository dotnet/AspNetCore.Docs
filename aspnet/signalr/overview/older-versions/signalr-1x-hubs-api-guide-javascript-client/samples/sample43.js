contosoChatHubProxy.invoke('NewContosoChatMessage', userName, message).done(function () {
        console.log ('Invocation of NewContosoChatMessage succeeded');
    }).fail(function (error) {
        console.log('Invocation of NewContosoChatMessage failed. Error: ' + error);
    });