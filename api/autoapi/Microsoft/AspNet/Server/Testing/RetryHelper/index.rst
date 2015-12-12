

RetryHelper Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Testing.RetryHelper`








Syntax
------

.. code-block:: csharp

   public class RetryHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Server.Testing/Common/RetryHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Testing.RetryHelper

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Testing.RetryHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Testing.RetryHelper.RetryRequest(System.Func<System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>, Microsoft.Extensions.Logging.ILogger, System.Threading.CancellationToken, System.Int32)
    
        
    
        Retries every 1 sec for 60 times by default.
    
        
        
        
        :type retryBlock: System.Func{System.Threading.Tasks.Task{System.Net.Http.HttpResponseMessage}}
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :type cancellationToken: System.Threading.CancellationToken
        
        
        :type retryCount: System.Int32
        :rtype: System.Threading.Tasks.Task{System.Net.Http.HttpResponseMessage}
    
        
        .. code-block:: csharp
    
           public static Task<HttpResponseMessage> RetryRequest(Func<Task<HttpResponseMessage>> retryBlock, ILogger logger, CancellationToken cancellationToken = null, int retryCount = 60)
    

