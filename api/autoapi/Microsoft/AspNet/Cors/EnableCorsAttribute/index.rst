

EnableCorsAttribute Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Cors.EnableCorsAttribute`








Syntax
------

.. code-block:: csharp

   public class EnableCorsAttribute : Attribute, _Attribute, IEnableCorsAttribute





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/cors/src/Microsoft.AspNet.Cors/EnableCorsAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Cors.EnableCorsAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Cors.EnableCorsAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Cors.EnableCorsAttribute.EnableCorsAttribute(System.String)
    
        
    
        Creates a new instance of the :any:`Microsoft.AspNet.Cors.EnableCorsAttribute`\.
    
        
        
        
        :param policyName: The name of the policy to be applied.
        
        :type policyName: System.String
    
        
        .. code-block:: csharp
    
           public EnableCorsAttribute(string policyName)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Cors.EnableCorsAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Cors.EnableCorsAttribute.PolicyName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string PolicyName { get; set; }
    

