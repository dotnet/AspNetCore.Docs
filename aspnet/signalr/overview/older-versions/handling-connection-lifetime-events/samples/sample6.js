var myHubProxy = $.connection.myHub
myHubProxy.client.stopClient = function() {
    $.connection.hub.stop();
};