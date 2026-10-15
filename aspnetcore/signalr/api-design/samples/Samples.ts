// <CallWithOneParameter>
connection.invoke("GetTotalLength", "value1");
// </CallWithOneParameter>

// <CallWithObject>
connection.invoke("GetTotalLength", { param1: "value1" });
// </CallWithObject>

// <CallWithObjectNew>
connection.invoke("GetTotalLength", { param1: "value1", param2: "value2" });
// </CallWithObjectNew>

// <OnWithObjectOld>
connection.on("ReceiveMessage", (req) => {
    appendMessageToChatWindow(req.message);
});
// </OnWithObjectOld>

// <OnWithObjectNew>
connection.on("ReceiveMessage", (req) => {
    let message = req.message;
    if (req.sender) {
        message = req.sender + ": " + message;
    }
    appendMessageToChatWindow(message);
});
// </OnWithObjectNew>

// <HubMethodName>
connection.invoke("SendMessage", message);
// </HubMethodName>