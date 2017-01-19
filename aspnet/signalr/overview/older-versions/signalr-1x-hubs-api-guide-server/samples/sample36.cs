public void NewContosoChatMessage(string name, string message)
{
    (Clients.Others.addContosoChatMessageToPage(data) as Task).ContinueWith(antecedent =>
        Clients.Caller.notifyMessageSent());
}