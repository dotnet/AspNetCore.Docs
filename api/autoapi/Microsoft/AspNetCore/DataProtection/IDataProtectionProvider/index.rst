

IDataProtectionProvider Interface
=================================






An interface that can be used to create :any:`Microsoft.AspNetCore.DataProtection.IDataProtector` instances.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection`
Assemblies
    * Microsoft.AspNetCore.DataProtection.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IDataProtectionProvider








.. dn:interface:: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider.CreateProtector(System.String)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.DataProtection.IDataProtector` given a purpose.
    
        
    
        
        :param purpose: 
            The purpose to be assigned to the newly-created :any:`Microsoft.AspNetCore.DataProtection.IDataProtector`\.
        
        :type purpose: System.String
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtector
        :return: An IDataProtector tied to the provided purpose.
    
        
        .. code-block:: csharp
    
            IDataProtector CreateProtector(string purpose)
    

