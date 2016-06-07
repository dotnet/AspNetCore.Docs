

HttpsConnectionFilter Class
===========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Https`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel.Https

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilter`








Syntax
------

.. code-block:: csharp

    public class HttpsConnectionFilter : IConnectionFilter








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilter.HttpsConnectionFilter(Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions, Microsoft.AspNetCore.Server.Kestrel.Filter.IConnectionFilter)
    
        
    
        
        :type options: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions
    
        
        :type previous: Microsoft.AspNetCore.Server.Kestrel.Filter.IConnectionFilter
    
        
        .. code-block:: csharp
    
            public HttpsConnectionFilter(HttpsConnectionFilterOptions options, IConnectionFilter previous)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilter.OnConnectionAsync(Microsoft.AspNetCore.Server.Kestrel.Filter.ConnectionFilterContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.Filter.ConnectionFilterContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task OnConnectionAsync(ConnectionFilterContext context)
    

