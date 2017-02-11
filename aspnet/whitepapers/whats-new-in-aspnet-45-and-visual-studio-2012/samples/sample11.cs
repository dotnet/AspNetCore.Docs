// Receive a string message from the server.
socket.onmessage = function(msg)
{
	document.getElementById("serverData").innerHTML = msg.data; 
};
// Send a string message from the browser.
socket.send(document.getElementById("msgText"));