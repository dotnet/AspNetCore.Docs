

FileContentResult Class
=======================






Represents an :any:`Microsoft.AspNetCore.Mvc.ActionResult` that when executed will
write a binary file to the response.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.FileContentResult`








Syntax
------

.. code-block:: csharp

    public class FileContentResult : FileResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.FileContentResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.FileContentResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.FileContentResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.FileContentResult.FileContentResult(System.Byte[], Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.FileContentResult` instance with
        the provided <em>fileContents</em> and the
        provided <em>contentType</em>.
    
        
    
        
        :param fileContents: The bytes that represent the file contents.
        
        :type fileContents: System.Byte<System.Byte>[]
    
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
            public FileContentResult(byte[] fileContents, MediaTypeHeaderValue contentType)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.FileContentResult.FileContentResult(System.Byte[], System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.FileContentResult` instance with
        the provided <em>fileContents</em> and the
        provided <em>contentType</em>.
    
        
    
        
        :param fileContents: The bytes that represent the file contents.
        
        :type fileContents: System.Byte<System.Byte>[]
    
        
        :param contentType: The Content-Type header of the response.
        
        :type contentType: System.String
    
        
        .. code-block:: csharp
    
            public FileContentResult(byte[] fileContents, string contentType)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.FileContentResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.FileContentResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.FileContentResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FileContentResult.FileContents
    
        
    
        
        Gets or sets the file contents.
    
        
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] FileContents { get; set; }
    

