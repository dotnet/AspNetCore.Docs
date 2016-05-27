

DataProtectionTokenProviderOptions Class
========================================






Contains options for the :any:`Microsoft.AspNetCore.Identity.DataProtectorTokenProvider\`1`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.DataProtectionTokenProviderOptions`








Syntax
------

.. code-block:: csharp

    public class DataProtectionTokenProviderOptions








.. dn:class:: Microsoft.AspNetCore.Identity.DataProtectionTokenProviderOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.DataProtectionTokenProviderOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.DataProtectionTokenProviderOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.DataProtectionTokenProviderOptions.Name
    
        
    
        
        Gets or sets the name of the :any:`Microsoft.AspNetCore.Identity.DataProtectorTokenProvider\`1`\.
    
        
        :rtype: System.String
        :return: 
            The name of the :any:`Microsoft.AspNetCore.Identity.DataProtectorTokenProvider\`1`\.
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.DataProtectionTokenProviderOptions.TokenLifespan
    
        
    
        
        Gets or sets the amount of time a generated token remains valid.
    
        
        :rtype: System.TimeSpan
        :return: 
            The amount of time a generated token remains valid.
    
        
        .. code-block:: csharp
    
            public TimeSpan TokenLifespan
            {
                get;
                set;
            }
    

