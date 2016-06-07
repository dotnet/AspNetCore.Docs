

KeyManagementOptions Class
==========================






Options that control how an :any:`Microsoft.AspNetCore.DataProtection.KeyManagement.IKeyManager` should behave.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.KeyManagement`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.KeyManagement.KeyManagementOptions`








Syntax
------

.. code-block:: csharp

    public class KeyManagementOptions








.. dn:class:: Microsoft.AspNetCore.DataProtection.KeyManagement.KeyManagementOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.KeyManagement.KeyManagementOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.KeyManagement.KeyManagementOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.KeyManagement.KeyManagementOptions.AutoGenerateKeys
    
        
    
        
        Specifies whether the data protection system should auto-generate keys.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool AutoGenerateKeys
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.KeyManagement.KeyManagementOptions.NewKeyLifetime
    
        
    
        
        Controls the lifetime (number of days before expiration)
        for newly-generated keys.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public TimeSpan NewKeyLifetime
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.KeyManagement.KeyManagementOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.KeyManagement.KeyManagementOptions.KeyManagementOptions()
    
        
    
        
        .. code-block:: csharp
    
            public KeyManagementOptions()
    

