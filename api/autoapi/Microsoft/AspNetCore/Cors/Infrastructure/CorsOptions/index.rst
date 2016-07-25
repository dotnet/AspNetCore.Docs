

CorsOptions Class
=================






Provides programmatic configuration for Cors.


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
* :dn:cls:`Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions`








Syntax
------

.. code-block:: csharp

    public class CorsOptions








.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions.AddPolicy(System.String, Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy)
    
        
    
        
        Adds a new policy.
    
        
    
        
        :param name: The name of the policy.
        
        :type name: System.String
    
        
        :param policy: The :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy` policy to be added.
        
        :type policy: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
    
        
        .. code-block:: csharp
    
            public void AddPolicy(string name, CorsPolicy policy)
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions.AddPolicy(System.String, System.Action<Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder>)
    
        
    
        
        Adds a new policy.
    
        
    
        
        :param name: The name of the policy.
        
        :type name: System.String
    
        
        :param configurePolicy: A delegate which can use a policy builder to build a policy.
        
        :type configurePolicy: System.Action<System.Action`1>{Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder<Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder>}
    
        
        .. code-block:: csharp
    
            public void AddPolicy(string name, Action<CorsPolicyBuilder> configurePolicy)
    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions.GetPolicy(System.String)
    
        
    
        
        Gets the policy based on the <em>name</em>
    
        
    
        
        :param name: The name of the policy to lookup.
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
        :return: The :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy` if the policy was added.<code>null</code> otherwise.
    
        
        .. code-block:: csharp
    
            public CorsPolicy GetPolicy(string name)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions.DefaultPolicyName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string DefaultPolicyName { get; set; }
    

