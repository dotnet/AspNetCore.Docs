var chat = $.connection.chatHub;
$.connection.hub.start().done(function () {
    chat.client.broadcastMessage = function (name, message) {...};
});