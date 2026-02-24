import "./css/main.css";
import * as signalR from "@microsoft/signalr";

const divMessages: HTMLDivElement = document.querySelector("#divMessages");
const tbMessage: HTMLInputElement = document.querySelector("#tbMessage");
const btnSend: HTMLButtonElement = document.querySelector("#btnSend");
const username = new Date().getTime();

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .build();

connection.on("messageReceived", (username: string, message: string) => {
    let messages = document.createElement("div");

    const author = document.createElement("div");
    author.className = "message-author";
    author.textContent = username;

    const content = document.createElement("div");
    content.textContent = message;

    messages.append(author, content);

    divMessages.appendChild(messages);
    divMessages.scrollTop = divMessages.scrollHeight;
});

connection.start().catch(err => document.write(err));

tbMessage.addEventListener("keyup", (e: KeyboardEvent) => {
    if (e.key === "Enter") {
        send();
    }
});

btnSend.addEventListener("click", send);

function send() {
    connection.send("newMessage", username, tbMessage.value)
        .then(() => tbMessage.value = "");
}
