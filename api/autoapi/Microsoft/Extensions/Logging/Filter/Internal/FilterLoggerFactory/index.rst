

FilterLoggerFactory Class
=========================





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
* :dn:cls:`Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerFactory`








Syntax
------

.. code-block:: csharp

    public class FilterLoggerFactory : ILoggerFactory, IDisposable








.. dn:class:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerFactory
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerFactory

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerFactory.FilterLoggerFactory(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Logging.IFilterLoggerSettings)
    
        
    
        
        :type innerLoggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type settings: Microsoft.Extensions.Logging.IFilterLoggerSettings
    
        
        .. code-block:: csharp
    
            public FilterLoggerFactory(ILoggerFactory innerLoggerFactory, IFilterLoggerSettings settings)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerFactory.AddProvider(Microsoft.Extensions.Logging.ILoggerProvider)
    
        
    
        
        :type provider: Microsoft.Extensions.Logging.ILoggerProvider
    
        
        .. code-block:: csharp
    
            public void AddProvider(ILoggerProvider provider)
    
    .. dn:method:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerFactory.CreateLogger(System.String)
    
        
    
        
        :type categoryName: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public ILogger CreateLogger(string categoryName)
    
    .. dn:method:: Microsoft.Extensions.Logging.Filter.Internal.FilterLoggerFactory.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    

