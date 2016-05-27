

CorsPolicy Class
================






Defines the policy for Cross-Origin requests based on the CORS specifications.


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
* :dn:cls:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy`








Syntax
------

.. code-block:: csharp

    public class CorsPolicy








.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy.AllowAnyHeader
    
        
    
        
        Gets a value indicating if all headers are allowed.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool AllowAnyHeader
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy.AllowAnyMethod
    
        
    
        
        Gets a value indicating if all methods are allowed.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool AllowAnyMethod
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy.AllowAnyOrigin
    
        
    
        
        Gets a value indicating if all origins are allowed.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool AllowAnyOrigin
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy.ExposedHeaders
    
        
    
        
        Gets the headers that the resource might use and can be exposed.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> ExposedHeaders
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy.Headers
    
        
    
        
        Gets the headers that are supported by the resource.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> Headers
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy.Methods
    
        
    
        
        Gets the methods that are supported by the resource.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> Methods
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy.Origins
    
        
    
        
        Gets the origins that are allowed to access the resource.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> Origins
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy.PreflightMaxAge
    
        
    
        
        Gets or sets the :any:`System.TimeSpan` for which the results of a preflight request can be cached.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.TimeSpan<System.TimeSpan>}
    
        
        .. code-block:: csharp
    
            public TimeSpan? PreflightMaxAge
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy.SupportsCredentials
    
        
    
        
        Gets or sets a value indicating whether the resource supports user credentials in the request.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool SupportsCredentials
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy.ToString()
    
        
    
        
        Returns a :any:`System.String` that represents this instance.
    
        
        :rtype: System.String
        :return: 
            A :any:`System.String` that represents this instance.
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

