const connection = new signalR.HubConnection('/chathub');

connection.on('ReceiveMessage', (message) => {
    const encodedMsg = message;
    const listItem = document.createElement('li');
    listItem.innerHTML = encodedMsg;
    document.getElementById('messages').appendChild(listItem);
});

document.getElementById('sendButton').addEventListener('click', event => {
    const msg = document.getElementById('messageList').value;
    connection.send('SendMessageToAll', msg).catch(err => logErr(errorMsg));
    event.preventDefault();
});

function logErr(errorMsg) {
    console.log(errorMsg);
}

connection.start().catch(err => logErr(errorMsg));