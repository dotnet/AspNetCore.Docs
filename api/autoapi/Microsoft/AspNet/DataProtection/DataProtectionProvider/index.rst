

DataProtectionProvider Class
============================



.. contents:: 
   :local:



Summary
-------

A simple implementation of an :any:`Microsoft.AspNet.DataProtection.IDataProtectionProvider` where keys are stored
at a particular location on the file system.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.DataProtectionProvider`








Syntax
------

.. code-block:: csharp

   public sealed class DataProtectionProvider : IDataProtectionProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection.Extensions/DataProtectionProvider.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.DataProtectionProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.DataProtectionProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.DataProtectionProvider.DataProtectionProvider(System.IO.DirectoryInfo)
    
        
    
        Creates an :any:`Microsoft.AspNet.DataProtection.DataProtectionProvider` given a location at which to store keys.
    
        
        
        
        :param keyDirectory: The  in which keys should be stored. This may
            represent a directory on a local disk or a UNC share.
        
        :type keyDirectory: System.IO.DirectoryInfo
    
        
        .. code-block:: csharp
    
           public DataProtectionProvider(DirectoryInfo keyDirectory)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.DataProtectionProvider.DataProtectionProvider(System.IO.DirectoryInfo, System.Action<Microsoft.AspNet.DataProtection.DataProtectionConfiguration>)
    
        
    
        Creates an :any:`Microsoft.AspNet.DataProtection.DataProtectionProvider` given a location at which to store keys and an
        optional configuration callback.
    
        
        
        
        :param keyDirectory: The  in which keys should be stored. This may
            represent a directory on a local disk or a UNC share.
        
        :type keyDirectory: System.IO.DirectoryInfo
        
        
        :param configure: An optional callback which provides further configuration of the data protection
            system. See  for more information.
        
        :type configure: System.Action{Microsoft.AspNet.DataProtection.DataProtectionConfiguration}
    
        
        .. code-block:: csharp
    
           public DataProtectionProvider(DirectoryInfo keyDirectory, Action<DataProtectionConfiguration> configure)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.DataProtectionProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionProvider.CreateProtector(System.String)
    
        
    
        Implements :dn:meth:`Microsoft.AspNet.DataProtection.IDataProtectionProvider.CreateProtector(System.String)`\.
    
        
        
        
        :type purpose: System.String
        :rtype: Microsoft.AspNet.DataProtection.IDataProtector
    
        
        .. code-block:: csharp
    
           public IDataProtector CreateProtector(string purpose)
    

