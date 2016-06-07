

LoggingConnectionFilter Class
=============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Filter`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Filter.LoggingConnectionFilter`








Syntax
------

.. code-block:: csharp

    public class LoggingConnectionFilter : IConnectionFilter








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.LoggingConnectionFilter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.LoggingConnectionFilter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.LoggingConnectionFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Filter.LoggingConnectionFilter.LoggingConnectionFilter(Microsoft.Extensions.Logging.ILogger, Microsoft.AspNetCore.Server.Kestrel.Filter.IConnectionFilter)
    
        
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :type previous: Microsoft.AspNetCore.Server.Kestrel.Filter.IConnectionFilter
    
        
        .. code-block:: csharp
    
            public LoggingConnectionFilter(ILogger logger, IConnectionFilter previous)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.LoggingConnectionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.LoggingConnectionFilter.OnConnectionAsync(Microsoft.AspNetCore.Server.Kestrel.Filter.ConnectionFilterContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.Filter.ConnectionFilterContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task OnConnectionAsync(ConnectionFilterContext context)
    

