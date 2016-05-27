

FilterLoggerProvider Class
==========================





Namespace
    :dn:ns:`Microsoft.Extensions.Logging.Filter.Internal`
Assemblies
    * Microsoft.Extensions.Logging.Filter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerProvider`








Syntax
------

.. code-block:: csharp

    public class FilterLoggerProvider : ILoggerProvider, IDisposable








.. dn:class:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerProvider.FilterLoggerProvider(Microsoft.Extensions.Logging.ILoggerProvider, Microsoft.Extensions.Logging.IFilterLoggerSettings)
    
        
    
        
        :type innerLoggerProvider: Microsoft.Extensions.Logging.ILoggerProvider
    
        
        :type settings: Microsoft.Extensions.Logging.IFilterLoggerSettings
    
        
        .. code-block:: csharp
    
            public FilterLoggerProvider(ILoggerProvider innerLoggerProvider, IFilterLoggerSettings settings)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerProvider.CreateLogger(System.String)
    
        
    
        
        :type categoryName: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public ILogger CreateLogger(string categoryName)
    
    .. dn:method:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerProvider.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    

