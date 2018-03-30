const connection = new signalR.HubConnection('/chathub');

connection.on('ReceiveMessage', (timestamp, user, message) => {
    const encodedUser = user;
    const encodedMsg = message;
    const listItem = document.createElement('li');
    listItem.innerHTML = timestamp + ' <b>' + encodedUser + '</b>: ' + encodedMsg;
    document.getElementById('messages').appendChild(listItem);
});

document.getElementById('sendButton').addEventListener('click', event => {
    const msg = document.getElementById('message').value;
    const usr = document.getElementById('user').value;
    connection.send('SendMessageToAll', usr, msg).catch(err => logErr(errorMsg));
    event.preventDefault();
});

function logErr(errorMsg) {
    console.log(errorMsg);
}

connection.start().catch(err => logErr(errorMsg));