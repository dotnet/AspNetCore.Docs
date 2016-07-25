

FileStreamResult Class
======================






Represents an :any:`Microsoft.AspNetCore.Mvc.ActionResult` that when executed will
write a file from a stream to the response.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNetCore.Mvc.FileResult`
* :dn:cls:`Microsoft.AspNetCore.Mvc.FileStreamResult`








Syntax
------

.. code-block:: csharp

    public class FileStreamResult : FileResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.FileStreamResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.FileStreamResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.FileStreamResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.FileStreamResult.FileStreamResult(System.IO.Stream, Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.FileStreamResult` instance with
        the provided <em>fileStream</em> and the
        provided <em>contentType</em>.
    
        
    
        
        :param fileStream: The stream with the file.
        
        :type fileStream: System.IO.Stream
    
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
            public FileStreamResult(Stream fileStream, MediaTypeHeaderValue contentType)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.FileStreamResult.FileStreamResult(System.IO.Stream, System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.FileStreamResult` instance with
        the provided <em>fileStream</em> and the
        provided <em>contentType</em>.
    
        
    
        
        :param fileStream: The stream with the file.
        
        :type fileStream: System.IO.Stream
    
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: System.String
    
        
        .. code-block:: csharp
    
            public FileStreamResult(Stream fileStream, string contentType)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.FileStreamResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.FileStreamResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.FileStreamResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FileStreamResult.FileStream
    
        
    
        
        Gets or sets the stream with the file that will be sent back as the response.
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream FileStream { get; set; }
    

