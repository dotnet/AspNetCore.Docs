

OperationAuthorizationRequirement Class
=======================================






A helper class to provide a useful :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement` which
contains a name.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authorization.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Authorization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authorization.Infrastructure.OperationAuthorizationRequirement`








Syntax
------

.. code-block:: csharp

    public class OperationAuthorizationRequirement : IAuthorizationRequirement








.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.OperationAuthorizationRequirement
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.OperationAuthorizationRequirement

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.OperationAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.Infrastructure.OperationAuthorizationRequirement.Name
    
        
    
        
        The name of this instance of :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    

