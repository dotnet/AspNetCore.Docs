// The following sample code uses TypeScript and must be compiled to JavaScript
// before a browser can execute it.
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();
connection.on("Send", function (message) {
    var li = document.createElement("li");
    li.textContent = message;
    document.getElementById("messagesList").appendChild(li);
});
document.getElementById("groupmsg").addEventListener("click", (event) => __awaiter(this, void 0, void 0, function* () {
    var groupName = document.getElementById("group-name").value;
    var groupMsg = document.getElementById("group-message-text").value;
    try {
        yield connection.invoke("SendMessageToGroup", groupName, groupMsg);
    }
    catch (e) {
        console.error(e.toString());
    }
    event.preventDefault();
}));
document.getElementById("join-group").addEventListener("click", (event) => __awaiter(this, void 0, void 0, function* () {
    var groupName = document.getElementById("group-name").value;
    try {
        yield connection.invoke("AddToGroup", groupName);
    }
    catch (e) {
        console.error(e.toString());
    }
    event.preventDefault();
}));
document.getElementById("leave-group").addEventListener("click", (event) => __awaiter(this, void 0, void 0, function* () {
    var groupName = document.getElementById("group-name").value;
    try {
        yield connection.invoke("RemoveFromGroup", groupName);
    }
    catch (e) {
        console.error(e.toString());
    }
    event.preventDefault();
}));
// We need an async function in order to use await, but we want this code to run immediately,
// so we use an "immediately-executed async function"
(() => __awaiter(this, void 0, void 0, function* () {
    try {
        yield connection.start();
    }
    catch (e) {
        console.error(e.toString());
    }
}))();
