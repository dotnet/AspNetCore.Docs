

IDataProtectionProvider Interface
=================================



.. contents:: 
   :local:



Summary
-------

An interface that can be used to create :any:`Microsoft.AspNet.DataProtection.IDataProtector` instances.











Syntax
------

.. code-block:: csharp

   public interface IDataProtectionProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection.Abstractions/IDataProtectionProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.IDataProtectionProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.IDataProtectionProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.IDataProtectionProvider.CreateProtector(System.String)
    
        
    
        Creates an :any:`Microsoft.AspNet.DataProtection.IDataProtector` given a purpose.
    
        
        
        
        :type purpose: System.String
        :rtype: Microsoft.AspNet.DataProtection.IDataProtector
        :return: An IDataProtector tied to the provided purpose.
    
        
        .. code-block:: csharp
    
           IDataProtector CreateProtector(string purpose)
    

