const transportType = signalR.TransportType.WebSockets;
const logger = new signalR.ConsoleLogger(signalR.LogLevel.Information);
const connection = new signalR.HubConnection('/chathub', 
                   { transport: transportType, logger: logger });

connection.on('ReceiveMessage', (message) => {
    const encodedMsg = message;
    document.getElementById('messagesParagraph').innerText = encodedMsg;
});

connection.start().catch(err => logError(err));

document.getElementById('sendButton').addEventListener('click', event => {
    connection.invoke('SendMessage', message).catch(err => logError(err));
    event.preventDefault();
});

function logError(err) {
    console.log(err);
}