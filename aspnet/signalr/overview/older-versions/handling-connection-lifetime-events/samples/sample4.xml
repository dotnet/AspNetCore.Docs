var tryingToReconnect = false;

$.connection.hub.reconnecting(function() {
    tryingToReconnect = true;
});

$.connection.hub.reconnected(function() {
    tryingToReconnect = false;
});

$.connection.hub.disconnected(function() {
    if(tryingToReconnect) {
        notifyUserOfDisconnect(); // Your function to notify user.
    }
});