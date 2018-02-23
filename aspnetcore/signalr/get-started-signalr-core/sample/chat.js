var connection = new signalR.HubConnection('chathub');
connection.start().catch(err => appendLine(err, 'red'));

connection.on('Send', (timestamp, user, message) => {
    var listItem = document.createElement('li');
    listItem.innerHTML = timestamp + ' <b>' + user + '</b>: ' + message;
    document.getElementById('messages').appendChild(listItem);

});

document.getElementById('send').addEventListener('click', event => {
    var msg = document.getElementById('message').value;
    var usr = document.getElementById('user').value;

    connection.invoke('Send', usr, msg).catch(err => appendLine(err, 'red'));
    event.preventDefault();
});
