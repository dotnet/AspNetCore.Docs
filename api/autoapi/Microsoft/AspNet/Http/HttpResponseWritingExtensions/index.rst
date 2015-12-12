

HttpResponseWritingExtensions Class
===================================



.. contents:: 
   :local:



Summary
-------

Convenience methods for writing to the response.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.HttpResponseWritingExtensions`








Syntax
------

.. code-block:: csharp

   public class HttpResponseWritingExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/Extensions/HttpResponseWritingExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Http.HttpResponseWritingExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.HttpResponseWritingExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.HttpResponseWritingExtensions.WriteAsync(Microsoft.AspNet.Http.HttpResponse, System.String, System.Text.Encoding, System.Threading.CancellationToken)
    
        
    
        Writes the given text to the response body using the given encoding.
    
        
        
        
        :param response: The .
        
        :type response: Microsoft.AspNet.Http.HttpResponse
        
        
        :param text: The text to write to the response.
        
        :type text: System.String
        
        
        :param encoding: The encoding to use.
        
        :type encoding: System.Text.Encoding
        
        
        :param cancellationToken: Notifies when request operations should be cancelled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the completion of the write operation.
    
        
        .. code-block:: csharp
    
           public static Task WriteAsync(HttpResponse response, string text, Encoding encoding, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Http.HttpResponseWritingExtensions.WriteAsync(Microsoft.AspNet.Http.HttpResponse, System.String, System.Threading.CancellationToken)
    
        
    
        Writes the given text to the response body. UTF-8 encoding will be used.
    
        
        
        
        :param response: The .
        
        :type response: Microsoft.AspNet.Http.HttpResponse
        
        
        :param text: The text to write to the response.
        
        :type text: System.String
        
        
        :param cancellationToken: Notifies when request operations should be cancelled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the completion of the write operation.
    
        
        .. code-block:: csharp
    
           public static Task WriteAsync(HttpResponse response, string text, CancellationToken cancellationToken = null)
    

