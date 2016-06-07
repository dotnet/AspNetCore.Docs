

RetryHelper Class
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Testing`
Assemblies
    * Microsoft.AspNetCore.Server.Testing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.RetryHelper`








Syntax
------

.. code-block:: csharp

    public class RetryHelper








.. dn:class:: Microsoft.AspNetCore.Server.Testing.RetryHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.RetryHelper

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.RetryHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.RetryHelper.RetryRequest(System.Func<System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>, Microsoft.Extensions.Logging.ILogger, System.Threading.CancellationToken, System.Int32)
    
        
    
        
        Retries every 1 sec for 60 times by default.
    
        
    
        
        :type retryBlock: System.Func<System.Func`1>{System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.Http.HttpResponseMessage<System.Net.Http.HttpResponseMessage>}}
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :type cancellationToken: System.Threading.CancellationToken
    
        
        :type retryCount: System.Int32
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.Http.HttpResponseMessage<System.Net.Http.HttpResponseMessage>}
    
        
        .. code-block:: csharp
    
            public static Task<HttpResponseMessage> RetryRequest(Func<Task<HttpResponseMessage>> retryBlock, ILogger logger, CancellationToken cancellationToken = null, int retryCount = 60)
    

