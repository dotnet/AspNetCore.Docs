

VirtualFileResult Class
=======================






A :any:`Microsoft.AspNetCore.Mvc.FileResult` that on execution writes the file specified using a virtual path to the response
using mechanisms provided by the host.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.VirtualFileResult`








Syntax
------

.. code-block:: csharp

    public class VirtualFileResult : FileResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.VirtualFileResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.VirtualFileResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.VirtualFileResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.VirtualFileResult.VirtualFileResult(System.String, Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.VirtualFileResult` instance with
        the provided <em>fileName</em> and the
        provided <em>contentType</em>.
    
        
    
        
        :param fileName: The path to the file. The path must be relative/virtual.
        
        :type fileName: System.String
    
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
            public VirtualFileResult(string fileName, MediaTypeHeaderValue contentType)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.VirtualFileResult.VirtualFileResult(System.String, System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.VirtualFileResult` instance with the provided <em>fileName</em>
        and the provided <em>contentType</em>.
    
        
    
        
        :param fileName: The path to the file. The path must be relative/virtual.
        
        :type fileName: System.String
    
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: System.String
    
        
        .. code-block:: csharp
    
            public VirtualFileResult(string fileName, string contentType)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.VirtualFileResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.VirtualFileResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.VirtualFileResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.VirtualFileResult.FileName
    
        
    
        
        Gets or sets the path to the file that will be sent back as the response.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FileName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.VirtualFileResult.FileProvider
    
        
    
        
        Gets or sets the :any:`Microsoft.Extensions.FileProviders.IFileProvider` used to resolve paths.
    
        
        :rtype: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
            public IFileProvider FileProvider { get; set; }
    

