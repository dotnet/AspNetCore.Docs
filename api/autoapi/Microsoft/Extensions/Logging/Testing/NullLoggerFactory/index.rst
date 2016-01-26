

NullLoggerFactory Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Testing.NullLoggerFactory`








Syntax
------

.. code-block:: csharp

   public class NullLoggerFactory : ILoggerFactory, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/logging/blob/master/src/Microsoft.Extensions.Logging.Testing/NullLoggerFactory.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.Testing.NullLoggerFactory

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Testing.NullLoggerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.NullLoggerFactory.AddProvider(Microsoft.Extensions.Logging.ILoggerProvider)
    
        
        
        
        :type provider: Microsoft.Extensions.Logging.ILoggerProvider
    
        
        .. code-block:: csharp
    
           public void AddProvider(ILoggerProvider provider)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.NullLoggerFactory.CreateLogger(System.String)
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public ILogger CreateLogger(string name)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.NullLoggerFactory.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    

Fields
------

.. dn:class:: Microsoft.Extensions.Logging.Testing.NullLoggerFactory
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.Logging.Testing.NullLoggerFactory.Instance
    
        
    
        
        .. code-block:: csharp
    
           public static readonly NullLoggerFactory Instance
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.Testing.NullLoggerFactory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.NullLoggerFactory.MinimumLevel
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
           public LogLevel MinimumLevel { get; set; }
    

