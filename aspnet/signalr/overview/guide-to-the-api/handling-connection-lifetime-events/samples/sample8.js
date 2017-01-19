$.connection.hub.disconnected(function () {
    if ($.connection.hub.lastError) 
        { alert("Disconnected. Reason: " +  $.connection.hub.lastError.message); }
});