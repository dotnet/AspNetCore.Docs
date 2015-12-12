

ElmLoggerProvider Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Elm.ElmLoggerProvider`








Syntax
------

.. code-block:: csharp

   public class ElmLoggerProvider : ILoggerProvider, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics.Elm/ElmLoggerProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmLoggerProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Elm.ElmLoggerProvider.ElmLoggerProvider(Microsoft.AspNet.Diagnostics.Elm.ElmStore, Microsoft.AspNet.Diagnostics.Elm.ElmOptions)
    
        
        
        
        :type store: Microsoft.AspNet.Diagnostics.Elm.ElmStore
        
        
        :type options: Microsoft.AspNet.Diagnostics.Elm.ElmOptions
    
        
        .. code-block:: csharp
    
           public ElmLoggerProvider(ElmStore store, ElmOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.ElmLoggerProvider.CreateLogger(System.String)
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public ILogger CreateLogger(string name)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.ElmLoggerProvider.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    

