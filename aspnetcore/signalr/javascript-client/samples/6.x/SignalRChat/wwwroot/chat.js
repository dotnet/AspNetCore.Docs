document.addEventListener("DOMContentLoaded", () => {
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
        document.getElementById("messageList").appendChild(li);
    });
    // </snippet_ReceiveMessage>

    document.getElementById("send").addEventListener("click", async () => {
        const user = document.getElementById("userInput").value;
        const message = document.getElementById("messageInput").value;

        // <snippet_Invoke>
        try {
            await connection.invoke("SendMessage", user, message);
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

    connection.onclose(async () => {
        await start();
    });

    // Start the connection.
    start();
});
