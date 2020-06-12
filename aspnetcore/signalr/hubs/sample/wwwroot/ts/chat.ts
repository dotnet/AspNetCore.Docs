// The following sample code uses TypeScript and must be compiled to JavaScript
// before a browser can execute it.

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .build();

connection.on("ReceiveMessage", function (user, message) {
    var encodedMsg = user + " says " + message;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

document.getElementById("sendButton").addEventListener("click", async (event) => {
    var user = (document.getElementById("userInput") as HTMLInputElement).value;
    var message = (document.getElementById("messageInput") as HTMLInputElement).value;
    try {
        await connection.invoke("SendMessage", user, message);
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
