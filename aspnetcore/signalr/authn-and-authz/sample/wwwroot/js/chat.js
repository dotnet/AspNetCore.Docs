var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
// DOM Binding
function dom(id) {
    const element = document.getElementById(id);
    if (!element) {
        throw new Error(`Unable to bind DOM element: ${id}`);
    }
    return element;
}
function showIf(condition, ifTrue, ifFalse) {
    ifTrue.style.display = condition ? "inherit" : "none";
    if (ifFalse) {
        ifFalse.style.display = condition ? "none" : "inherit";
    }
}
const loginForm = dom("loginForm");
const chatDiv = dom("chatDiv");
const errorDiv = dom("errorDiv");
const logoutButton = dom("logoutButton");
const connectingDiv = dom("connectingDiv");
const connectedDiv = dom("connectedDiv");
const messageForm = dom("messageForm");
const messageInput = dom("messageInput");
const messageList = dom("messageList");
const directMessageForm = dom("directMessageForm");
const directMessageInput = dom("directMessageInput");
const toUserInput = dom("toUserInput");
class ViewModel {
    loginFormSubmitted(evt) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                evt.preventDefault();
                // Send the username and password to the server
                const formData = new FormData(loginForm);
                const resp = yield fetch("/account/token", { method: "POST", body: formData });
                if (resp.status !== 200) {
                    this.error = `HTTP ${resp.status} error from server`;
                    return;
                }
                const json = yield resp.json();
                if (json["error"]) {
                    this.error = `Login error: ${json["error"]}`;
                    return;
                }
                else {
                    this.loginToken = json["token"];
                }
                // Update rendering while we connect
                this.render();
                // Connect, using the token we got.
                this.connection = new signalR.HubConnectionBuilder()
                    .withUrl("/hubs/chat", { accessTokenFactory: () => this.loginToken })
                    .build();
                this.connection.on("ReceiveSystemMessage", (message) => this.receiveMessage(message, "green"));
                this.connection.on("ReceiveDirectMessage", (message) => this.receiveMessage(message, "blue"));
                this.connection.on("ReceiveChatMessage", (message) => this.receiveMessage(message));
                yield this.connection.start();
                this.connectionStarted = true;
            }
            catch (e) {
                this.error = `Error connecting: ${e}`;
            }
            finally {
                // Update rendering with any final state.
                this.render();
            }
        });
    }
    directMessageFormSubmitted(evt) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                evt.preventDefault();
                yield this.connection.send("SendToUser", toUserInput.value, directMessageInput.value);
                directMessageInput.value = "";
            }
            catch (e) {
                this.error = `Error sending: ${e.toString()}`;
            }
            finally {
                this.render();
            }
        });
    }
    messageFormSubmitted(evt) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                evt.preventDefault();
                yield this.connection.invoke("Send", messageInput.value);
                messageInput.value = "";
            }
            catch (e) {
                this.error = `Error sending: ${e.toString()}`;
            }
            finally {
                this.render();
            }
        });
    }
    receiveMessage(message, color) {
        const li = document.createElement("li");
        if (color) {
            li.style.color = color;
        }
        li.textContent = message;
        messageList.appendChild(li);
    }
    logoutButtonClicked(evt) {
        return __awaiter(this, void 0, void 0, function* () {
            evt.preventDefault();
            if (this.connection) {
                yield this.connection.stop();
                this.connection = null;
            }
            // Just clear the token and re-render
            this.loginToken = null;
            this.render();
        });
    }
    // Update the state of DOM elements based on the view model
    render() {
        errorDiv.textContent = this.error;
        showIf(this.error, errorDiv);
        showIf(this.loginToken, chatDiv, loginForm);
        showIf(this.connectionStarted, connectedDiv, connectingDiv);
    }
    static run() {
        const model = new ViewModel();
        // Bind events
        loginForm.addEventListener("submit", (e) => model.loginFormSubmitted(e));
        logoutButton.addEventListener("click", (e) => model.logoutButtonClicked(e));
        messageForm.addEventListener("submit", (e) => model.messageFormSubmitted(e));
        directMessageForm.addEventListener("submit", (e) => model.directMessageFormSubmitted(e));
    }
}
ViewModel.run();
