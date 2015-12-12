

SendFileResponseExtensions Class
================================



.. contents:: 
   :local:



Summary
-------

Provides extensions for HttpResponse exposing the SendFile extension.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.SendFileResponseExtensions`








Syntax
------

.. code-block:: csharp

   public class SendFileResponseExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Extensions/SendFileResponseExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Http.SendFileResponseExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.SendFileResponseExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.SendFileResponseExtensions.SendFileAsync(Microsoft.AspNet.Http.HttpResponse, System.String)
    
        
    
        Sends the given file using the SendFile extension.
    
        
        
        
        :type response: Microsoft.AspNet.Http.HttpResponse
        
        
        :type fileName: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public static Task SendFileAsync(HttpResponse response, string fileName)
    
    .. dn:method:: Microsoft.AspNet.Http.SendFileResponseExtensions.SendFileAsync(Microsoft.AspNet.Http.HttpResponse, System.String, System.Int64, System.Nullable<System.Int64>, System.Threading.CancellationToken)
    
        
    
        Sends the given file using the SendFile extension.
    
        
        
        
        :type response: Microsoft.AspNet.Http.HttpResponse
        
        
        :param fileName: The full or relative path to the file.
        
        :type fileName: System.String
        
        
        :param offset: The offset in the file.
        
        :type offset: System.Int64
        
        
        :param count: The number of types to send, or null to send the remainder of the file.
        
        :type count: System.Nullable{System.Int64}
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public static Task SendFileAsync(HttpResponse response, string fileName, long offset, long ? count, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Http.SendFileResponseExtensions.SupportsSendFile(Microsoft.AspNet.Http.HttpResponse)
    
        
    
        Checks if the SendFile extension is supported.
    
        
        
        
        :type response: Microsoft.AspNet.Http.HttpResponse
        :rtype: System.Boolean
        :return: True if sendfile feature exists in the response.
    
        
        .. code-block:: csharp
    
           public static bool SupportsSendFile(HttpResponse response)
    

