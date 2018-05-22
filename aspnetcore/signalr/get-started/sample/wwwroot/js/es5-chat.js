// To use the following code sample:
// In Pages\Index.cshtml,
// comment line #26: "<script src="~/js/chat.js"></script>"
// uncomment line #27: "<script src="~/js/es5-chat.js"></script>"

"use strict";

var connection = new signalR.HubConnection("/chathub", { logger: signalR.LogLevel.Information });

connection.on("ReceiveMessage", function (user, message) {
    var encodedMsg = user + " says " + message;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error;
    });
    event.preventDefault();
});

connection.start().catch(function (err) {
    return console.error;
});