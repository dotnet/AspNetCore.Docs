document.addEventListener("DOMContentLoaded", () => {
    const userInput = document.getElementById("user");
    const messageInput = document.getElementById("message");
    const chatLogUl = document.getElementById("chatLog");

    // <snippet_Connection>
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/chathub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    // </snippet_Connection>

    // <snippet_ReceiveMessage>
    connection.on("ReceiveMessage", (user, message) => {
        const li = document.createElement("li");
        li.textContent = `${user}: ${message}`;
        chatLogUl.appendChild(li);
    });
    // </snippet_ReceiveMessage>

    document.getElementById("send").addEventListener("click", async () => {
        // <snippet_Invoke>
        try {
            await connection.invoke("SendMessage", userInput.value, messageInput.value);
        } catch (err) {
            console.error(err);
        }
        // </snippet_Invoke>
    });

    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
            setTimeout(start, 5000);
        }
    };

    connection.onclose(start);

    // Start the connection.
    start();
});
