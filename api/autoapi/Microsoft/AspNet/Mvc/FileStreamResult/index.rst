

FileStreamResult Class
======================



.. contents:: 
   :local:



Summary
-------

Represents an :any:`Microsoft.AspNet.Mvc.ActionResult` that when executed will
write a file from a stream to the response.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.FileResult`
* :dn:cls:`Microsoft.AspNet.Mvc.FileStreamResult`








Syntax
------

.. code-block:: csharp

   public class FileStreamResult : FileResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/FileStreamResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.FileStreamResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.FileStreamResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.FileStreamResult.FileStreamResult(System.IO.Stream, Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.FileStreamResult` instance with
        the provided ``fileStream`` and the
        provided ``contentType``.
    
        
        
        
        :param fileStream: The stream with the file.
        
        :type fileStream: System.IO.Stream
        
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public FileStreamResult(Stream fileStream, MediaTypeHeaderValue contentType)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.FileStreamResult.FileStreamResult(System.IO.Stream, System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.FileStreamResult` instance with
        the provided ``fileStream`` and the
        provided ``contentType``.
    
        
        
        
        :param fileStream: The stream with the file.
        
        :type fileStream: System.IO.Stream
        
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: System.String
    
        
        .. code-block:: csharp
    
           public FileStreamResult(Stream fileStream, string contentType)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.FileStreamResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.FileStreamResult.WriteFileAsync(Microsoft.AspNet.Http.HttpResponse)
    
        
        
        
        :type response: Microsoft.AspNet.Http.HttpResponse
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           protected override Task WriteFileAsync(HttpResponse response)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.FileStreamResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.FileStreamResult.FileStream
    
        
    
        Gets or sets the stream with the file that will be sent back as the response.
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public Stream FileStream { get; set; }
    

