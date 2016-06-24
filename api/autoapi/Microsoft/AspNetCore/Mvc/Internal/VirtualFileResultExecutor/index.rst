

VirtualFileResultExecutor Class
===============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.FileResultExecutorBase`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.VirtualFileResultExecutor`








Syntax
------

.. code-block:: csharp

    public class VirtualFileResultExecutor : FileResultExecutorBase








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.VirtualFileResultExecutor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.VirtualFileResultExecutor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.VirtualFileResultExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.VirtualFileResultExecutor.VirtualFileResultExecutor(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.AspNetCore.Hosting.IHostingEnvironment)
    
        
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type hostingEnvironment: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
            public VirtualFileResultExecutor(ILoggerFactory loggerFactory, IHostingEnvironment hostingEnvironment)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.VirtualFileResultExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.VirtualFileResultExecutor.ExecuteAsync(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.VirtualFileResult)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type result: Microsoft.AspNetCore.Mvc.VirtualFileResult
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task ExecuteAsync(ActionContext context, VirtualFileResult result)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.VirtualFileResultExecutor.GetFileStream(Microsoft.Extensions.FileProviders.IFileInfo)
    
        
    
        
        :type fileInfo: Microsoft.Extensions.FileProviders.IFileInfo
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            protected virtual Stream GetFileStream(IFileInfo fileInfo)
    

