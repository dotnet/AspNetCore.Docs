// The following sample code uses modern ECMAScript 6 features 
// that aren't supported in Internet Explorer 11.
// To convert the sample for environments that do not support ECMAScript 6, 
// such as Internet Explorer 11, use a transpiler such as 
// Babel at http://babeljs.io/. 
//
// See Es5-chat.js for a Babel transpiled version of the following code:
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
    connection.invoke("SendMessage", user, message).catch(function (err) { return console.error; });
    event.preventDefault();
});
connection.start().catch(function (err) { return console.error; });
