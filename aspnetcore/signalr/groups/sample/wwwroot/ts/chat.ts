// The following sample code uses TypeScript and must be compiled to JavaScript
// before a browser can execute it.

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .build();

connection.on("Send", function (message) {
    var li = document.createElement("li");
    li.textContent = message;
    document.getElementById("messagesList").appendChild(li);
});

document.getElementById("groupmsg").addEventListener("click", async (event) => {
    var groupName = (document.getElementById("group-name") as HTMLInputElement).value;
    var groupMsg = (document.getElementById("group-message-text") as HTMLInputElement).value;
    try {
        await connection.invoke("SendMessageToGroup", groupName, groupMsg);
    } catch (e) {
        console.error(e.toString());
    }
    event.preventDefault();
});

document.getElementById("join-group").addEventListener("click", async (event) => {
    var groupName = (document.getElementById("group-name") as HTMLInputElement).value;
    try {
        await connection.invoke("AddToGroup", groupName);
    } catch (e) {
        console.error(e.toString());
    }
    event.preventDefault();
});

document.getElementById("leave-group").addEventListener("click", async (event) => {
    var groupName = (document.getElementById("group-name") as HTMLInputElement).value;
    try {
        await connection.invoke("RemoveFromGroup", groupName);
    } catch (e) {
        console.error(e.toString());
    }
    event.preventDefault();
});

// We need an async function in order to use await, but we want this code to run immediately,
// so we use an "immediately-executed async function"
(async () => {
    try {
        await connection.start();
    } catch (e) {
        console.error(e.toString());
    }
})();

