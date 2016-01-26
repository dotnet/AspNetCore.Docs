

CorsPolicyBuilder Class
=======================



.. contents:: 
   :local:



Summary
-------

Exposes methods to build a policy.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder`








Syntax
------

.. code-block:: csharp

   public class CorsPolicyBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/cors/blob/master/src/Microsoft.AspNet.Cors/CorsPolicyBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder.CorsPolicyBuilder(Microsoft.AspNet.Cors.Infrastructure.CorsPolicy)
    
        
    
        Creates a new instance of the :any:`Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder`\.
    
        
        
        
        :param policy: The policy which will be used to intialize the builder.
        
        :type policy: Microsoft.AspNet.Cors.Infrastructure.CorsPolicy
    
        
        .. code-block:: csharp
    
           public CorsPolicyBuilder(CorsPolicy policy)
    
    .. dn:constructor:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder.CorsPolicyBuilder(System.String[])
    
        
    
        Creates a new instance of the :any:`Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder`\.
    
        
        
        
        :param origins: list of origins which can be added.
        
        :type origins: System.String[]
    
        
        .. code-block:: csharp
    
           public CorsPolicyBuilder(params string[] origins)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder.AllowAnyHeader()
    
        
    
        Ensures that the policy allows any header.
    
        
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
           public CorsPolicyBuilder AllowAnyHeader()
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder.AllowAnyMethod()
    
        
    
        Ensures that the policy allows any method.
    
        
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
           public CorsPolicyBuilder AllowAnyMethod()
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder.AllowAnyOrigin()
    
        
    
        Ensures that the policy allows any origin.
    
        
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
           public CorsPolicyBuilder AllowAnyOrigin()
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder.AllowCredentials()
    
        
    
        Sets the policy to allow credentials.
    
        
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
           public CorsPolicyBuilder AllowCredentials()
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder.Build()
    
        
    
        Builds a new :any:`Microsoft.AspNet.Cors.Infrastructure.CorsPolicy` using the entries added.
    
        
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsPolicy
        :return: The constructed <see cref="T:Microsoft.AspNet.Cors.Infrastructure.CorsPolicy" />.
    
        
        .. code-block:: csharp
    
           public CorsPolicy Build()
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder.DisallowCredentials()
    
        
    
        Sets the policy to not allow credentials.
    
        
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
           public CorsPolicyBuilder DisallowCredentials()
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder.SetPreflightMaxAge(System.TimeSpan)
    
        
    
        Sets the preflightMaxAge for the underlying policy.
    
        
        
        
        :param preflightMaxAge: A positive  indicating the time a preflight
            request can be cached.
        
        :type preflightMaxAge: System.TimeSpan
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder
    
        
        .. code-block:: csharp
    
           public CorsPolicyBuilder SetPreflightMaxAge(TimeSpan preflightMaxAge)
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder.WithExposedHeaders(System.String[])
    
        
    
        Adds the specified ``exposedHeaders`` to the policy.
    
        
        
        
        :param exposedHeaders: The headers which need to be exposed to the client.
        
        :type exposedHeaders: System.String[]
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
           public CorsPolicyBuilder WithExposedHeaders(params string[] exposedHeaders)
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder.WithHeaders(System.String[])
    
        
    
        Adds the specified ``headers`` to the policy.
    
        
        
        
        :param headers: The headers which need to be allowed in the request.
        
        :type headers: System.String[]
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
           public CorsPolicyBuilder WithHeaders(params string[] headers)
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder.WithMethods(System.String[])
    
        
    
        Adds the specified ``methods`` to the policy.
    
        
        
        
        :param methods: The methods which need to be added to the policy.
        
        :type methods: System.String[]
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
           public CorsPolicyBuilder WithMethods(params string[] methods)
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder.WithOrigins(System.String[])
    
        
    
        Adds the specified ``origins`` to the policy.
    
        
        
        
        :param origins: The origins that are allowed.
        
        :type origins: System.String[]
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder
        :return: The current policy builder
    
        
        .. code-block:: csharp
    
           public CorsPolicyBuilder WithOrigins(params string[] origins)
    

