

SendFileResponseExtensions Class
================================






Provides extensions for HttpResponse exposing the SendFile extension.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Extensions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.SendFileResponseExtensions`








Syntax
------

.. code-block:: csharp

    public class SendFileResponseExtensions








.. dn:class:: Microsoft.AspNetCore.Http.SendFileResponseExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.SendFileResponseExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.SendFileResponseExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.SendFileResponseExtensions.SendFileAsync(Microsoft.AspNetCore.Http.HttpResponse, Microsoft.Extensions.FileProviders.IFileInfo, System.Int64, System.Nullable<System.Int64>, System.Threading.CancellationToken)
    
        
    
        
        Sends the given file using the SendFile extension.
    
        
    
        
        :type response: Microsoft.AspNetCore.Http.HttpResponse
    
        
        :param file: The file.
        
        :type file: Microsoft.Extensions.FileProviders.IFileInfo
    
        
        :param offset: The offset in the file.
        
        :type offset: System.Int64
    
        
        :param count: The number of bytes to send, or null to send the remainder of the file.
        
        :type count: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public static Task SendFileAsync(HttpResponse response, IFileInfo file, long offset, long ? count, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Http.SendFileResponseExtensions.SendFileAsync(Microsoft.AspNetCore.Http.HttpResponse, Microsoft.Extensions.FileProviders.IFileInfo, System.Threading.CancellationToken)
    
        
    
        
        Sends the given file using the SendFile extension.
    
        
    
        
        :type response: Microsoft.AspNetCore.Http.HttpResponse
    
        
        :param file: The file.
        
        :type file: Microsoft.Extensions.FileProviders.IFileInfo
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken`\.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public static Task SendFileAsync(HttpResponse response, IFileInfo file, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Http.SendFileResponseExtensions.SendFileAsync(Microsoft.AspNetCore.Http.HttpResponse, System.String, System.Int64, System.Nullable<System.Int64>, System.Threading.CancellationToken)
    
        
    
        
        Sends the given file using the SendFile extension.
    
        
    
        
        :type response: Microsoft.AspNetCore.Http.HttpResponse
    
        
        :param fileName: The full path to the file.
        
        :type fileName: System.String
    
        
        :param offset: The offset in the file.
        
        :type offset: System.Int64
    
        
        :param count: The number of bytes to send, or null to send the remainder of the file.
        
        :type count: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public static Task SendFileAsync(HttpResponse response, string fileName, long offset, long ? count, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Http.SendFileResponseExtensions.SendFileAsync(Microsoft.AspNetCore.Http.HttpResponse, System.String, System.Threading.CancellationToken)
    
        
    
        
        Sends the given file using the SendFile extension.
    
        
    
        
        :type response: Microsoft.AspNetCore.Http.HttpResponse
    
        
        :param fileName: The full path to the file.
        
        :type fileName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken`\.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public static Task SendFileAsync(HttpResponse response, string fileName, CancellationToken cancellationToken = null)
    

