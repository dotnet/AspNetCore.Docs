

PhysicalFileResultExecutor Class
================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.PhysicalFileResultExecutor`








Syntax
------

.. code-block:: csharp

    public class PhysicalFileResultExecutor : FileResultExecutorBase








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.PhysicalFileResultExecutor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.PhysicalFileResultExecutor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.PhysicalFileResultExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.PhysicalFileResultExecutor.PhysicalFileResultExecutor(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public PhysicalFileResultExecutor(ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.PhysicalFileResultExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.PhysicalFileResultExecutor.ExecuteAsync(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.PhysicalFileResult)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type result: Microsoft.AspNetCore.Mvc.PhysicalFileResult
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task ExecuteAsync(ActionContext context, PhysicalFileResult result)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.PhysicalFileResultExecutor.GetFileStream(System.String)
    
        
    
        
        :type path: System.String
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            protected virtual Stream GetFileStream(string path)
    

