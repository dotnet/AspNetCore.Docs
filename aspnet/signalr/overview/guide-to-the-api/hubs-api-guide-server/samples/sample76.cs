public class LoggingPipelineModule : HubPipelineModule 
{ 
    protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context) 
    { 
        Debug.WriteLine("=> Invoking " + context.MethodDescriptor.Name + " on hub " + context.MethodDescriptor.Hub.Name); 
        return base.OnBeforeIncoming(context); 
    }   
    protected override bool OnBeforeOutgoing(IHubOutgoingInvokerContext context) 
    { 
        Debug.WriteLine("<= Invoking " + context.Invocation.Method + " on client hub " + context.Invocation.Hub); 
        return base.OnBeforeOutgoing(context); 
    } 
}