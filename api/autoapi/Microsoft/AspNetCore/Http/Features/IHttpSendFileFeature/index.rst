

IHttpSendFileFeature Interface
==============================






Provides an efficient mechanism for transferring files from disk to the network.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHttpSendFileFeature








.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpSendFileFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpSendFileFeature

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpSendFileFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.IHttpSendFileFeature.SendFileAsync(System.String, System.Int64, System.Nullable<System.Int64>, System.Threading.CancellationToken)
    
        
    
        
        Sends the requested file in the response body. This may bypass the IHttpResponseFeature.Body
        :any:`System.IO.Stream`\. A response may include multiple writes.
    
        
    
        
        :param path: The full disk path to the file.
        
        :type path: System.String
    
        
        :param offset: The offset in the file to start at.
        
        :type offset: System.Int64
    
        
        :param count: The number of bytes to send, or null to send the remainder of the file.
        
        :type count: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        :param cancellation: A :any:`System.Threading.CancellationToken` used to abort the transmission.
        
        :type cancellation: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task SendFileAsync(string path, long offset, long ? count, CancellationToken cancellation)
    

