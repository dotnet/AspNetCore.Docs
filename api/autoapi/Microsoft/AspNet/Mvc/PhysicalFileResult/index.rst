

PhysicalFileResult Class
========================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Mvc.FileResult` on execution will write a file from disk to the response
using mechanisms provided by the host.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.FileResult`
* :dn:cls:`Microsoft.AspNet.Mvc.PhysicalFileResult`








Syntax
------

.. code-block:: csharp

   public class PhysicalFileResult : FileResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/PhysicalFileResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.PhysicalFileResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.PhysicalFileResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.PhysicalFileResult.PhysicalFileResult(System.String, Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.PhysicalFileResult` instance with
        the provided ``fileName`` and the provided ``contentType``.
    
        
        
        
        :param fileName: The path to the file. The path must be an absolute path.
        
        :type fileName: System.String
        
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public PhysicalFileResult(string fileName, MediaTypeHeaderValue contentType)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.PhysicalFileResult.PhysicalFileResult(System.String, System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.PhysicalFileResult` instance with
        the provided ``fileName`` and the provided ``contentType``.
    
        
        
        
        :param fileName: The path to the file. The path must be an absolute path.
        
        :type fileName: System.String
        
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: System.String
    
        
        .. code-block:: csharp
    
           public PhysicalFileResult(string fileName, string contentType)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.PhysicalFileResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.PhysicalFileResult.GetFileStream(System.String)
    
        
    
        Returns :any:`System.IO.Stream` for the specified ``path``.
    
        
        
        
        :param path: The path for which the  is needed.
        
        :type path: System.String
        :rtype: System.IO.Stream
        :return: <see cref="T:System.IO.FileStream" /> for the specified <paramref name="path" />.
    
        
        .. code-block:: csharp
    
           protected virtual Stream GetFileStream(string path)
    
    .. dn:method:: Microsoft.AspNet.Mvc.PhysicalFileResult.WriteFileAsync(Microsoft.AspNet.Http.HttpResponse)
    
        
        
        
        :type response: Microsoft.AspNet.Http.HttpResponse
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           protected override Task WriteFileAsync(HttpResponse response)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.PhysicalFileResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.PhysicalFileResult.FileName
    
        
    
        Gets or sets the path to the file that will be sent back as the response.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FileName { get; set; }
    

