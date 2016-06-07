

CorsResult Class
================






Results returned by :any:`Microsoft.AspNetCore.Cors.Infrastructure.ICorsService`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Cors.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Cors

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Cors.Infrastructure.CorsResult`








Syntax
------

.. code-block:: csharp

    public class CorsResult








.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult.AllowedExposedHeaders
    
        
    
        
        Gets the allowed headers that can be exposed on the response.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> AllowedExposedHeaders
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult.AllowedHeaders
    
        
    
        
        Gets the allowed headers.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> AllowedHeaders
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult.AllowedMethods
    
        
    
        
        Gets the allowed methods.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> AllowedMethods
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult.AllowedOrigin
    
        
    
        
        Gets or sets the allowed origin.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AllowedOrigin
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult.PreflightMaxAge
    
        
    
        
        Gets or sets the :any:`System.TimeSpan` for which the results of a preflight request can be cached.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.TimeSpan<System.TimeSpan>}
    
        
        .. code-block:: csharp
    
            public TimeSpan? PreflightMaxAge
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult.SupportsCredentials
    
        
    
        
        Gets or sets a value indicating whether the resource supports user credentials.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool SupportsCredentials
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult.VaryByOrigin
    
        
    
        
        Gets or sets a value indicating if a 'Vary' header with the value 'Origin' is required.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool VaryByOrigin
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsResult.ToString()
    
        
    
        
        Returns a :any:`System.String` that represents this instance.
    
        
        :rtype: System.String
        :return: 
            A :any:`System.String` that represents this instance.
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

