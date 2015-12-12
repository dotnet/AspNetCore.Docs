

DataProtectionTokenProviderOptions Class
========================================



.. contents:: 
   :local:



Summary
-------

Contains options for the :any:`Microsoft.AspNet.Identity.DataProtectorTokenProvider\`1`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.DataProtectionTokenProviderOptions`








Syntax
------

.. code-block:: csharp

   public class DataProtectionTokenProviderOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/DataProtectionTokenProviderOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.DataProtectionTokenProviderOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.DataProtectionTokenProviderOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.DataProtectionTokenProviderOptions.Name
    
        
    
        Gets or sets the name of the :any:`Microsoft.AspNet.Identity.DataProtectorTokenProvider\`1`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.DataProtectionTokenProviderOptions.TokenLifespan
    
        
    
        Gets or sets the amount of time a generated token remains valid.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
           public TimeSpan TokenLifespan { get; set; }
    

