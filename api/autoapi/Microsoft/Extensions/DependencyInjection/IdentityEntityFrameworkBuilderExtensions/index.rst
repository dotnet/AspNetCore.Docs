

IdentityEntityFrameworkBuilderExtensions Class
==============================================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity.EntityFramework/IdentityEntityFrameworkBuilderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.IdentityEntityFrameworkBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.IdentityEntityFrameworkBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.IdentityEntityFrameworkBuilderExtensions.AddEntityFrameworkStores<TContext>(Microsoft.AspNet.Identity.IdentityBuilder)
    
        
    
        Adds an Entity Framework implementation of identity information stores.
    
        
        
        
        :param builder: The  instance this method extends.
        
        :type builder: Microsoft.AspNet.Identity.IdentityBuilder
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: The <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> instance this method extends.
    
        
        .. code-block:: csharp
    
           public static IdentityBuilder AddEntityFrameworkStores<TContext>(IdentityBuilder builder)where TContext : DbContext
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.IdentityEntityFrameworkBuilderExtensions.AddEntityFrameworkStores<TContext, TKey>(Microsoft.AspNet.Identity.IdentityBuilder)
    
        
    
        Adds an Entity Framework implementation of identity information stores.
    
        
        
        
        :param builder: The  instance this method extends.
        
        :type builder: Microsoft.AspNet.Identity.IdentityBuilder
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: The <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> instance this method extends.
    
        
        .. code-block:: csharp
    
           public static IdentityBuilder AddEntityFrameworkStores<TContext, TKey>(IdentityBuilder builder)where TContext : DbContext where TKey : IEquatable<TKey>
    

