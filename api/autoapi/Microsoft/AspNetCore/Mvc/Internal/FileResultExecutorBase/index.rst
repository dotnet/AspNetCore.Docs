

FileResultExecutorBase Class
============================





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








Syntax
------

.. code-block:: csharp

    public class FileResultExecutorBase








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FileResultExecutorBase
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FileResultExecutorBase

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FileResultExecutorBase
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.FileResultExecutorBase.FileResultExecutorBase(Microsoft.Extensions.Logging.ILogger)
    
        
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public FileResultExecutorBase(ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FileResultExecutorBase
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.FileResultExecutorBase.CreateLogger<T>(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            protected static ILogger CreateLogger<T>(ILoggerFactory factory)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.FileResultExecutorBase.SetHeadersAndLog(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.FileResult)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type result: Microsoft.AspNetCore.Mvc.FileResult
    
        
        .. code-block:: csharp
    
            protected void SetHeadersAndLog(ActionContext context, FileResult result)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FileResultExecutorBase
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.FileResultExecutorBase.Logger
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            protected ILogger Logger { get; }
    

