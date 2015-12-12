

IEnableCorsAttribute Interface
==============================



.. contents:: 
   :local:



Summary
-------

An interface which can be used to identify a type which provides metadata needed for enabling CORS support.











Syntax
------

.. code-block:: csharp

   public interface IEnableCorsAttribute





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/cors/src/Microsoft.AspNet.Cors/IEnableCorsAttribute.cs>`_





.. dn:interface:: Microsoft.AspNet.Cors.Infrastructure.IEnableCorsAttribute

Properties
----------

.. dn:interface:: Microsoft.AspNet.Cors.Infrastructure.IEnableCorsAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Cors.Infrastructure.IEnableCorsAttribute.PolicyName
    
        
    
        The name of the policy which needs to be applied.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string PolicyName { get; set; }
    

