const connection = new signalR.HubConnection('/chathub');

connection.on('ReceiveMessage', (timestamp, user, message) => {
    const encodedUser = user;
    const encodedMsg = message;
    const listItem = document.createElement('li');
    listItem.innerHTML = timestamp + ' <b>' + encodedUser + '</b>: ' + encodedMsg;
    document.getElementById('messages').appendChild(listItem);
});

document.getElementById('send').addEventListener('click', event => {
    const msg = document.getElementById('message').value;
    const usr = document.getElementById('user').value;
    const grp = document.getElementById('group').value;
    if (grp != null) {
        connection.invoke('SendMessageToGroup', usr, msg, grp).catch(err => showErr(err));
    }
    else {
        connection.invoke('SendMessageToAll', usr, msg).catch(err => showErr(err));
    }    
    event.preventDefault();
});

function showErr(msg) {
    const listItem = document.createElement('li');
    listItem.setAttribute("style", "color: red");
    listItem.innerText = msg.toString();
    document.getElementById('messages').appendChild(listItem);
}

connection.start().catch(err => showErr(err));

function getParameterByName(name, url) {
    if (!url) {
        url = window.location.href;
    }
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
};

function receiveMessage(user, message, group, connection) {
    const encodedUser = user;
    const encodedMsg = message; 
    const listItem = document.createElement('li');
    listItem.innerHTML = timestamp + ' <b>' + encodedUser + '</b>: ' + encodedMsg;
    document.getElementById('messages').appendChild(listItem);

}