

PhysicalFileResult Class
========================






A :any:`Microsoft.AspNetCore.Mvc.FileResult` on execution will write a file from disk to the response
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
* :dn:cls:`Microsoft.AspNetCore.Mvc.PhysicalFileResult`








Syntax
------

.. code-block:: csharp

    public class PhysicalFileResult : FileResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.PhysicalFileResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.PhysicalFileResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.PhysicalFileResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.PhysicalFileResult.PhysicalFileResult(System.String, Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.PhysicalFileResult` instance with
        the provided <em>fileName</em> and the provided <em>contentType</em>.
    
        
    
        
        :param fileName: The path to the file. The path must be an absolute path.
        
        :type fileName: System.String
    
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
            public PhysicalFileResult(string fileName, MediaTypeHeaderValue contentType)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.PhysicalFileResult.PhysicalFileResult(System.String, System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.PhysicalFileResult` instance with
        the provided <em>fileName</em> and the provided <em>contentType</em>.
    
        
    
        
        :param fileName: The path to the file. The path must be an absolute path.
        
        :type fileName: System.String
    
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: System.String
    
        
        .. code-block:: csharp
    
            public PhysicalFileResult(string fileName, string contentType)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.PhysicalFileResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.PhysicalFileResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.PhysicalFileResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.PhysicalFileResult.FileName
    
        
    
        
        Gets or sets the path to the file that will be sent back as the response.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FileName { get; set; }
    

