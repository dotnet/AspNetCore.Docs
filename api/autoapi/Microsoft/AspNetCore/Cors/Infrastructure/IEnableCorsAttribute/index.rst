

IEnableCorsAttribute Interface
==============================






An interface which can be used to identify a type which provides metadata needed for enabling CORS support.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Cors.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Cors

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IEnableCorsAttribute








.. dn:interface:: Microsoft.AspNetCore.Cors.Infrastructure.IEnableCorsAttribute
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Cors.Infrastructure.IEnableCorsAttribute

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Cors.Infrastructure.IEnableCorsAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Cors.Infrastructure.IEnableCorsAttribute.PolicyName
    
        
    
        
        The name of the policy which needs to be applied.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string PolicyName
            {
                get;
                set;
            }
    

