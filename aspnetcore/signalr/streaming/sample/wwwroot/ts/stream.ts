// The following sample code uses TypeScript and must be compiled to JavaScript
// before a browser can execute it.

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/streamHub")
    .build();

document.getElementById("streamButton").addEventListener("click", async (event) => {
    try {
        connection.stream("Counter", 10, 500)
            .subscribe({
                next: (item) => {
                    var li = document.createElement("li");
                    li.textContent = item;
                    document.getElementById("messagesList").appendChild(li);
                },
                complete: () => {
                    var li = document.createElement("li");
                    li.textContent = "Stream completed";
                    document.getElementById("messagesList").appendChild(li);
                },
                error: (err) => {
                    var li = document.createElement("li");
                    li.textContent = err;
                    document.getElementById("messagesList").appendChild(li);
                },
            });
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

