

FileContentResult Class
=======================



.. contents:: 
   :local:



Summary
-------

Represents an :any:`Microsoft.AspNet.Mvc.ActionResult` that when executed will
write a binary file to the response.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.FileResult`
* :dn:cls:`Microsoft.AspNet.Mvc.FileContentResult`








Syntax
------

.. code-block:: csharp

   public class FileContentResult : FileResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/FileContentResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.FileContentResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.FileContentResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.FileContentResult.FileContentResult(System.Byte[], Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.FileContentResult` instance with
        the provided ``fileContents`` and the
        provided ``contentType``.
    
        
        
        
        :param fileContents: The bytes that represent the file contents.
        
        :type fileContents: System.Byte[]
        
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public FileContentResult(byte[] fileContents, MediaTypeHeaderValue contentType)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.FileContentResult.FileContentResult(System.Byte[], System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.FileContentResult` instance with
        the provided ``fileContents`` and the
        provided ``contentType``.
    
        
        
        
        :param fileContents: The bytes that represent the file contents.
        
        :type fileContents: System.Byte[]
        
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: System.String
    
        
        .. code-block:: csharp
    
           public FileContentResult(byte[] fileContents, string contentType)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.FileContentResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.FileContentResult.WriteFileAsync(Microsoft.AspNet.Http.HttpResponse)
    
        
        
        
        :type response: Microsoft.AspNet.Http.HttpResponse
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           protected override Task WriteFileAsync(HttpResponse response)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.FileContentResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.FileContentResult.FileContents
    
        
    
        Gets or sets the file contents.
    
        
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           public byte[] FileContents { get; set; }
    

