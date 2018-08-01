// DOM Binding
function dom<T extends HTMLElement>(id: string): T {
    const element = document.getElementById(id);
    if (!element) {
        throw new Error(`Unable to bind DOM element: ${id}`);
    }
    return element as T;
}

function showIf(condition: any, ifTrue: HTMLElement, ifFalse?: HTMLElement) {
    ifTrue.style.display = condition ? "inherit" : "none";

    if (ifFalse) {
        ifFalse.style.display = condition ? "none" : "inherit";
    }
}

const loginForm = dom<HTMLFormElement>("loginForm");
const chatDiv = dom<HTMLDivElement>("chatDiv");
const errorDiv = dom<HTMLDivElement>("errorDiv");
const logoutButton = dom<HTMLButtonElement>("logoutButton");
const connectingDiv = dom<HTMLDivElement>("connectingDiv");
const connectedDiv = dom<HTMLDivElement>("connectedDiv");
const messageForm = dom<HTMLFormElement>("messageForm");
const messageInput = dom<HTMLInputElement>("messageInput");
const messageList = dom<HTMLUListElement>("messageList");
const directMessageForm = dom<HTMLFormElement>("directMessageForm");
const directMessageInput = dom<HTMLInputElement>("directMessageInput");
const toUserInput = dom<HTMLInputElement>("toUserInput");

class ViewModel {
    public loginToken: string;
    public error: string;
    public connection: signalR.HubConnection;
    public connectionStarted: boolean;

    public async loginFormSubmitted(evt: Event) {
        try {
            evt.preventDefault();

            // Send the username and password to the server
            const formData = new FormData(loginForm);
            const resp = await fetch("/account/token", { method: "POST", body: formData });

            if (resp.status !== 200) {
                this.error = `HTTP ${resp.status} error from server`;
                return;
            }

            const json = await resp.json();

            if (json["error"]) {
                this.error = `Login error: ${json["error"]}`;
                return;
            } else {
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
            await this.connection.start();
            this.connectionStarted = true;

        } catch (e) {
            this.error = `Error connecting: ${e}`;
        } finally {
            // Update rendering with any final state.
            this.render();
        }
    }

    public async directMessageFormSubmitted(evt: Event) {
        try {
            evt.preventDefault();
            await this.connection.send("SendToUser", toUserInput.value, directMessageInput.value);
            directMessageInput.value = "";
        } catch (e) {
            this.error = `Error sending: ${e.toString()}`;
        } finally {
            this.render();
        }
    }

    public async messageFormSubmitted(evt: Event) {
        try {
            evt.preventDefault();
            await this.connection.invoke("Send", messageInput.value);
            messageInput.value = "";
        } catch (e) {
            this.error = `Error sending: ${e.toString()}`;
        } finally {
            this.render();
        }
    }

    public receiveMessage(message: string, color?: string) {
        const li = document.createElement("li");
        if (color) {
            li.style.color = color;
        }
        li.textContent = message;
        messageList.appendChild(li);
    }

    public async logoutButtonClicked(evt: MouseEvent) {
        evt.preventDefault();

        if (this.connection) {
            await this.connection.stop();
            this.connection = null;
        }

        // Just clear the token and re-render
        this.loginToken = null;
        this.render();
    }

    // Update the state of DOM elements based on the view model
    public render() {
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
