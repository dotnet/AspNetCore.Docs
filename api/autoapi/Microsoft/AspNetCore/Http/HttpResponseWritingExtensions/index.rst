

HttpResponseWritingExtensions Class
===================================






Convenience methods for writing to the response.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.HttpResponseWritingExtensions`








Syntax
------

.. code-block:: csharp

    public class HttpResponseWritingExtensions








.. dn:class:: Microsoft.AspNetCore.Http.HttpResponseWritingExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.HttpResponseWritingExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.HttpResponseWritingExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.HttpResponseWritingExtensions.WriteAsync(Microsoft.AspNetCore.Http.HttpResponse, System.String, System.Text.Encoding, System.Threading.CancellationToken)
    
        
    
        
        Writes the given text to the response body using the given encoding.
    
        
    
        
        :param response: The :any:`Microsoft.AspNetCore.Http.HttpResponse`\.
        
        :type response: Microsoft.AspNetCore.Http.HttpResponse
    
        
        :param text: The text to write to the response.
        
        :type text: System.String
    
        
        :param encoding: The encoding to use.
        
        :type encoding: System.Text.Encoding
    
        
        :param cancellationToken: Notifies when request operations should be cancelled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the completion of the write operation.
    
        
        .. code-block:: csharp
    
            public static Task WriteAsync(this HttpResponse response, string text, Encoding encoding, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HttpResponseWritingExtensions.WriteAsync(Microsoft.AspNetCore.Http.HttpResponse, System.String, System.Threading.CancellationToken)
    
        
    
        
        Writes the given text to the response body. UTF-8 encoding will be used.
    
        
    
        
        :param response: The :any:`Microsoft.AspNetCore.Http.HttpResponse`\.
        
        :type response: Microsoft.AspNetCore.Http.HttpResponse
    
        
        :param text: The text to write to the response.
        
        :type text: System.String
    
        
        :param cancellationToken: Notifies when request operations should be cancelled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the completion of the write operation.
    
        
        .. code-block:: csharp
    
            public static Task WriteAsync(this HttpResponse response, string text, CancellationToken cancellationToken = null)
    

