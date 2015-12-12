

CorsResult Class
================



.. contents:: 
   :local:



Summary
-------

Results returned by :any:`Microsoft.AspNet.Cors.Infrastructure.ICorsService`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Cors.Infrastructure.CorsResult`








Syntax
------

.. code-block:: csharp

   public class CorsResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/cors/src/Microsoft.AspNet.Cors/CorsResult.cs>`_





.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsResult

Methods
-------

.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsResult.ToString()
    
        
    
        Returns a :any:`System.String` that represents this instance.
    
        
        :rtype: System.String
        :return: A <see cref="T:System.String" /> that represents this instance.
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Cors.Infrastructure.CorsResult.AllowedExposedHeaders
    
        
    
        Gets the allowed headers that can be exposed on the response.
    
        
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public IList<string> AllowedExposedHeaders { get; }
    
    .. dn:property:: Microsoft.AspNet.Cors.Infrastructure.CorsResult.AllowedHeaders
    
        
    
        Gets the allowed headers.
    
        
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public IList<string> AllowedHeaders { get; }
    
    .. dn:property:: Microsoft.AspNet.Cors.Infrastructure.CorsResult.AllowedMethods
    
        
    
        Gets the allowed methods.
    
        
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public IList<string> AllowedMethods { get; }
    
    .. dn:property:: Microsoft.AspNet.Cors.Infrastructure.CorsResult.AllowedOrigin
    
        
    
        Gets or sets the allowed origin.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AllowedOrigin { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Cors.Infrastructure.CorsResult.PreflightMaxAge
    
        
    
        Gets or sets the :any:`System.TimeSpan` for which the results of a preflight request can be cached.
    
        
        :rtype: System.Nullable{System.TimeSpan}
    
        
        .. code-block:: csharp
    
           public TimeSpan? PreflightMaxAge { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Cors.Infrastructure.CorsResult.SupportsCredentials
    
        
    
        Gets or sets a value indicating whether the resource supports user credentials.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool SupportsCredentials { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Cors.Infrastructure.CorsResult.VaryByOrigin
    
        
    
        Gets or sets a value indicating if a 'Vary' header with the value 'Origin' is required.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool VaryByOrigin { get; set; }
    

