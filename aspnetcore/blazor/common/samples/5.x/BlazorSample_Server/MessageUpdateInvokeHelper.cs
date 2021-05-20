using System;
using Microsoft.JSInterop;

public class MessageUpdateInvokeHelper
{
    private Action action;

    public MessageUpdateInvokeHelper(Action action)
    {
        this.action = action;
    }

    [JSInvokable("BlazorSample")]
    public void UpdateMessageCaller3()
    {
        action.Invoke();
    }
}
