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

    // TODO: Bind this method to a UI event that is triggered when the user is logging in
    // For example, if you add UI with a username/password box and a login button, this
    // method should be triggered when the login button is clicked.
    public async connect(evt: Event) {
        try {
            evt.preventDefault();

            // TODO: Use the user input to acquire a JWT token from your authentication provider.
            // Or, trigger an OIDC/OAuth login flow to acquire a token.
            throw new Error("TODO: Add code to acquire the token.")

            this.loginToken = "BOGUS TOKEN. Replace this with the real token.";

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

    // Update the state of DOM elements based on the view model
    public render() {
        errorDiv.textContent = this.error;

        // Renders the errorDiv if there's an error
        showIf(this.error, errorDiv);

        // Renders the chatDiv if we're "authenticated" and now connecting.
        showIf(this.loginToken, chatDiv);

        // Renders the "connecting..." message if we're still connecting, or the
        // full chat UI if we've connected.
        showIf(this.connectionStarted, connectedDiv, connectingDiv);
    }

    static run() {
        const model = new ViewModel();

        // Bind events
        messageForm.addEventListener("submit", (e) => model.messageFormSubmitted(e));
        directMessageForm.addEventListener("submit", (e) => model.directMessageFormSubmitted(e));
    }
}

ViewModel.run();
