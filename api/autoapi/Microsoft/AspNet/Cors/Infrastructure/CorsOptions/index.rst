

CorsOptions Class
=================



.. contents:: 
   :local:



Summary
-------

Provides programmatic configuration for Cors.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Cors.Infrastructure.CorsOptions`








Syntax
------

.. code-block:: csharp

   public class CorsOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/cors/src/Microsoft.AspNet.Cors/CorsOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsOptions

Methods
-------

.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsOptions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsOptions.AddPolicy(System.String, Microsoft.AspNet.Cors.Infrastructure.CorsPolicy)
    
        
    
        Adds a new policy.
    
        
        
        
        :param name: The name of the policy.
        
        :type name: System.String
        
        
        :param policy: The  policy to be added.
        
        :type policy: Microsoft.AspNet.Cors.Infrastructure.CorsPolicy
    
        
        .. code-block:: csharp
    
           public void AddPolicy(string name, CorsPolicy policy)
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsOptions.AddPolicy(System.String, System.Action<Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder>)
    
        
    
        Adds a new policy.
    
        
        
        
        :param name: The name of the policy.
        
        :type name: System.String
        
        
        :param configurePolicy: A delegate which can use a policy builder to build a policy.
        
        :type configurePolicy: System.Action{Microsoft.AspNet.Cors.Infrastructure.CorsPolicyBuilder}
    
        
        .. code-block:: csharp
    
           public void AddPolicy(string name, Action<CorsPolicyBuilder> configurePolicy)
    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.CorsOptions.GetPolicy(System.String)
    
        
    
        Gets the policy based on the ``name``
    
        
        
        
        :param name: The name of the policy to lookup.
        
        :type name: System.String
        :rtype: Microsoft.AspNet.Cors.Infrastructure.CorsPolicy
        :return: The <see cref="T:Microsoft.AspNet.Cors.Infrastructure.CorsPolicy" /> if the policy was added.<c>null</c> otherwise.
    
        
        .. code-block:: csharp
    
           public CorsPolicy GetPolicy(string name)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.CorsOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Cors.Infrastructure.CorsOptions.DefaultPolicyName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DefaultPolicyName { get; set; }
    

