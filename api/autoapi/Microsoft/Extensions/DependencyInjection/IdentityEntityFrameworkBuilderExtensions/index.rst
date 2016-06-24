

IdentityEntityFrameworkBuilderExtensions Class
==============================================





Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Identity.EntityFrameworkCore

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.IdentityEntityFrameworkBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class IdentityEntityFrameworkBuilderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.IdentityEntityFrameworkBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.IdentityEntityFrameworkBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.IdentityEntityFrameworkBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.IdentityEntityFrameworkBuilderExtensions.AddEntityFrameworkStores<TContext>(Microsoft.AspNetCore.Identity.IdentityBuilder)
    
        
    
        
        Adds an Entity Framework implementation of identity information stores.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance this method extends.
        
        :type builder: Microsoft.AspNetCore.Identity.IdentityBuilder
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: The :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance this method extends.
    
        
        .. code-block:: csharp
    
            public static IdentityBuilder AddEntityFrameworkStores<TContext>(this IdentityBuilder builder)where TContext : DbContext
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.IdentityEntityFrameworkBuilderExtensions.AddEntityFrameworkStores<TContext, TKey>(Microsoft.AspNetCore.Identity.IdentityBuilder)
    
        
    
        
        Adds an Entity Framework implementation of identity information stores.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance this method extends.
        
        :type builder: Microsoft.AspNetCore.Identity.IdentityBuilder
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: The :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance this method extends.
    
        
        .. code-block:: csharp
    
            public static IdentityBuilder AddEntityFrameworkStores<TContext, TKey>(this IdentityBuilder builder)where TContext : DbContext where TKey : IEquatable<TKey>
    

