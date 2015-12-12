

FileResult Class
================



.. contents:: 
   :local:



Summary
-------

Represents an :any:`Microsoft.AspNet.Mvc.ActionResult` that when executed will
write a file as the response.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.FileResult`








Syntax
------

.. code-block:: csharp

   public abstract class FileResult : ActionResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/FileResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.FileResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.FileResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.FileResult.FileResult(Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.FileResult` instance with
        the provided ``contentType``.
    
        
        
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           protected FileResult(MediaTypeHeaderValue contentType)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.FileResult.FileResult(System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.FileResult` instance with
        the provided ``contentType``.
    
        
        
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: System.String
    
        
        .. code-block:: csharp
    
           protected FileResult(string contentType)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.FileResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.FileResult.ExecuteResultAsync(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteResultAsync(ActionContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.FileResult.WriteFileAsync(Microsoft.AspNet.Http.HttpResponse)
    
        
    
        Writes the file to the specified ``response``.
    
        
        
        
        :param response: The .
        
        :type response: Microsoft.AspNet.Http.HttpResponse
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that will complete when the file has been written to the response.
    
        
        .. code-block:: csharp
    
           protected abstract Task WriteFileAsync(HttpResponse response)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.FileResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.FileResult.ContentType
    
        
    
        Gets the :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` representing the Content-Type header of the response.
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public MediaTypeHeaderValue ContentType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.FileResult.FileDownloadName
    
        
    
        Gets the file name that will be used in the Content-Disposition header of the response.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FileDownloadName { get; set; }
    

