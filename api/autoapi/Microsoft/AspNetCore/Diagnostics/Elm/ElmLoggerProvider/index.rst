

ElmLoggerProvider Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.Elm`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.Elm

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Elm.ElmLoggerProvider`








Syntax
------

.. code-block:: csharp

    public class ElmLoggerProvider : ILoggerProvider, IDisposable








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLoggerProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLoggerProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLoggerProvider.ElmLoggerProvider(Microsoft.AspNetCore.Diagnostics.Elm.ElmStore, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions>)
    
        
    
        
        :type store: Microsoft.AspNetCore.Diagnostics.Elm.ElmStore
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions<Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions>}
    
        
        .. code-block:: csharp
    
            public ElmLoggerProvider(ElmStore store, IOptions<ElmOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLoggerProvider.CreateLogger(System.String)
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public ILogger CreateLogger(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLoggerProvider.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    

