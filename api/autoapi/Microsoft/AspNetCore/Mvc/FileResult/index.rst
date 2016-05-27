

FileResult Class
================






Represents an :any:`Microsoft.AspNetCore.Mvc.ActionResult` that when executed will
write a file as the response.


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








Syntax
------

.. code-block:: csharp

    public abstract class FileResult : ActionResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.FileResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.FileResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.FileResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FileResult.ContentType
    
        
    
        
        Gets the Content-Type header for the response.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ContentType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FileResult.FileDownloadName
    
        
    
        
        Gets the file name that will be used in the Content-Disposition header of the response.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FileDownloadName
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.FileResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.FileResult.FileResult(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.FileResult` instance with
        the provided <em>contentType</em>.
    
        
    
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: System.String
    
        
        .. code-block:: csharp
    
            protected FileResult(string contentType)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.FileResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.FileResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.FileResult.WriteFileAsync(Microsoft.AspNetCore.Http.HttpResponse)
    
        
    
        
        Writes the file to the specified <em>response</em>.
    
        
    
        
        :param response: The :any:`Microsoft.AspNetCore.Http.HttpResponse`\.
        
        :type response: Microsoft.AspNetCore.Http.HttpResponse
        :rtype: System.Threading.Tasks.Task
        :return: 
            A :any:`System.Threading.Tasks.Task` that will complete when the file has been written to the response.
    
        
        .. code-block:: csharp
    
            protected abstract Task WriteFileAsync(HttpResponse response)
    

