

EnableCorsAttribute Class
=========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Cors`
Assemblies
    * Microsoft.AspNetCore.Cors

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Cors.EnableCorsAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class EnableCorsAttribute : Attribute, _Attribute, IEnableCorsAttribute








.. dn:class:: Microsoft.AspNetCore.Cors.EnableCorsAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Cors.EnableCorsAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Cors.EnableCorsAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Cors.EnableCorsAttribute.PolicyName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PolicyName
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Cors.EnableCorsAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Cors.EnableCorsAttribute.EnableCorsAttribute(System.String)
    
        
    
        
        Creates a new instance of the :any:`Microsoft.AspNetCore.Cors.EnableCorsAttribute`\.
    
        
    
        
        :param policyName: The name of the policy to be applied.
        
        :type policyName: System.String
    
        
        .. code-block:: csharp
    
            public EnableCorsAttribute(string policyName)
    

