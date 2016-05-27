

CorsPolicyBuilder Class
=======================






Exposes methods to build a policy.


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
* :dn:cls:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder`








Syntax
------

.. code-block:: csharp

    public class CorsPolicyBuilder








.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.CorsPolicyBuilder(Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy)
    
        
    
        
        Creates a new instance of the :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder`\.
    
        
    
        
        :param policy: The policy which will be used to intialize the builder.
        
        :type policy: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
    
        
        .. code-block:: csharp
    
            public CorsPolicyBuilder(CorsPolicy policy)
    
    .. dn:constructor:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.CorsPolicyBuilder(System.String[])
    
        
    
        
        Creates a new instance of the :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder`\.
    
        
    
        
        :param origins: list of origins which can be added.
        
        :type origins: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public CorsPolicyBuilder(params string[] origins)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.AllowAnyHeader()
    
        
    
        
        Ensures that the policy allows any header.
    
        
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
            public CorsPolicyBuilder AllowAnyHeader()
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.AllowAnyMethod()
    
        
    
        
        Ensures that the policy allows any method.
    
        
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
            public CorsPolicyBuilder AllowAnyMethod()
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.AllowAnyOrigin()
    
        
    
        
        Ensures that the policy allows any origin.
    
        
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
            public CorsPolicyBuilder AllowAnyOrigin()
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.AllowCredentials()
    
        
    
        
        Sets the policy to allow credentials.
    
        
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
            public CorsPolicyBuilder AllowCredentials()
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.Build()
    
        
    
        
        Builds a new :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy` using the entries added.
    
        
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
        :return: The constructed :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy`\.
    
        
        .. code-block:: csharp
    
            public CorsPolicy Build()
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.DisallowCredentials()
    
        
    
        
        Sets the policy to not allow credentials.
    
        
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
            public CorsPolicyBuilder DisallowCredentials()
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.SetPreflightMaxAge(System.TimeSpan)
    
        
    
        
        Sets the preflightMaxAge for the underlying policy.
    
        
    
        
        :param preflightMaxAge: A positive :any:`System.TimeSpan` indicating the time a preflight
            request can be cached.
        
        :type preflightMaxAge: System.TimeSpan
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder
    
        
        .. code-block:: csharp
    
            public CorsPolicyBuilder SetPreflightMaxAge(TimeSpan preflightMaxAge)
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.WithExposedHeaders(System.String[])
    
        
    
        
        Adds the specified <em>exposedHeaders</em> to the policy.
    
        
    
        
        :param exposedHeaders: The headers which need to be exposed to the client.
        
        :type exposedHeaders: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
            public CorsPolicyBuilder WithExposedHeaders(params string[] exposedHeaders)
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.WithHeaders(System.String[])
    
        
    
        
        Adds the specified <em>headers</em> to the policy.
    
        
    
        
        :param headers: The headers which need to be allowed in the request.
        
        :type headers: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
            public CorsPolicyBuilder WithHeaders(params string[] headers)
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.WithMethods(System.String[])
    
        
    
        
        Adds the specified <em>methods</em> to the policy.
    
        
    
        
        :param methods: The methods which need to be added to the policy.
        
        :type methods: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
            public CorsPolicyBuilder WithMethods(params string[] methods)
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.WithOrigins(System.String[])
    
        
    
        
        Adds the specified <em>origins</em> to the policy.
    
        
    
        
        :param origins: The origins that are allowed.
        
        :type origins: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
            public CorsPolicyBuilder WithOrigins(params string[] origins)
    

