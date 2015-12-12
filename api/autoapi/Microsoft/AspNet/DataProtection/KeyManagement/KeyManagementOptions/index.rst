

KeyManagementOptions Class
==========================



.. contents:: 
   :local:



Summary
-------

Options that control how an :any:`Microsoft.AspNet.DataProtection.KeyManagement.IKeyManager` should behave.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.KeyManagement.KeyManagementOptions`








Syntax
------

.. code-block:: csharp

   public class KeyManagementOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/KeyManagement/KeyManagementOptions.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.KeyManagement.KeyManagementOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.KeyManagement.KeyManagementOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.KeyManagement.KeyManagementOptions.KeyManagementOptions()
    
        
    
        
        .. code-block:: csharp
    
           public KeyManagementOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.DataProtection.KeyManagement.KeyManagementOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.KeyManagement.KeyManagementOptions.AutoGenerateKeys
    
        
    
        Specifies whether the data protection system should auto-generate keys.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool AutoGenerateKeys { get; set; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.KeyManagement.KeyManagementOptions.NewKeyLifetime
    
        
    
        Controls the lifetime (number of days before expiration)
        for newly-generated keys.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
           public TimeSpan NewKeyLifetime { get; set; }
    

