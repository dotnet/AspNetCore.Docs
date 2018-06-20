const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .build();

connection.on("ReceiveMessage", (user, message) => {
    const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    const encodedMsg = user + " says " + msg;
    log(encodedMsg);
});

connection.start().catch(err => console.error(err.toString()));