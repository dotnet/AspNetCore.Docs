const logger = new signalR.ConsoleLogger(signalR.LogLevel.Information);
const connection = new signalR.HubConnection('/chathub', logger: logger });

connection.on('ReceiveMessage', (message) => {
    const encodedMsg = message;
    document.getElementById('messagesParagraph').innerText = encodedMsg;
});

connection.start().catch(err => console.error);

document.getElementById('sendButton').addEventListener('click', event => {
    connection.invoke('SendMessage', message).catch(err => console.error);
    event.preventDefault();
});