var chat = $.connection.chatHub;
chat.client.broadcastMessage = function (name, message) {...};
    $.connection.hub.start().done(function () {
        ...
    });