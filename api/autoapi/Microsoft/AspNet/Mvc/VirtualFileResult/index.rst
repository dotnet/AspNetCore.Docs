

VirtualFileResult Class
=======================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Mvc.FileResult` that on execution writes the file specified using a virtual path to the response
using mechanisms provided by the host.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.FileResult`
* :dn:cls:`Microsoft.AspNet.Mvc.VirtualFileResult`








Syntax
------

.. code-block:: csharp

   public class VirtualFileResult : FileResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/VirtualFileResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.VirtualFileResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.VirtualFileResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.VirtualFileResult.VirtualFileResult(System.String, Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.VirtualFileResult` instance with
        the provided ``fileName`` and the
        provided ``contentType``.
    
        
        
        
        :param fileName: The path to the file. The path must be relative/virtual.
        
        :type fileName: System.String
        
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public VirtualFileResult(string fileName, MediaTypeHeaderValue contentType)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.VirtualFileResult.VirtualFileResult(System.String, System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.VirtualFileResult` instance with the provided ``fileName``
        and the provided ``contentType``.
    
        
        
        
        :param fileName: The path to the file. The path must be relative/virtual.
        
        :type fileName: System.String
        
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: System.String
    
        
        .. code-block:: csharp
    
           public VirtualFileResult(string fileName, string contentType)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.VirtualFileResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.VirtualFileResult.GetFileStream(Microsoft.AspNet.FileProviders.IFileInfo)
    
        
    
        Returns :any:`System.IO.Stream` for the specified ``fileInfo``.
    
        
        
        
        :param fileInfo: The  for which the stream is needed.
        
        :type fileInfo: Microsoft.AspNet.FileProviders.IFileInfo
        :rtype: System.IO.Stream
        :return: <see cref="T:System.IO.Stream" /> for the specified <paramref name="fileInfo" />.
    
        
        .. code-block:: csharp
    
           protected virtual Stream GetFileStream(IFileInfo fileInfo)
    
    .. dn:method:: Microsoft.AspNet.Mvc.VirtualFileResult.WriteFileAsync(Microsoft.AspNet.Http.HttpResponse)
    
        
        
        
        :type response: Microsoft.AspNet.Http.HttpResponse
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           protected override Task WriteFileAsync(HttpResponse response)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.VirtualFileResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.VirtualFileResult.FileName
    
        
    
        Gets or sets the path to the file that will be sent back as the response.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FileName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.VirtualFileResult.FileProvider
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.FileProviders.IFileProvider` used to resolve paths.
    
        
        :rtype: Microsoft.AspNet.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
           public IFileProvider FileProvider { get; set; }
    

