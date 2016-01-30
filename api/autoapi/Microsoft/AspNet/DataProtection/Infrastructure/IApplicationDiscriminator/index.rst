

IApplicationDiscriminator Interface
===================================



.. contents:: 
   :local:



Summary
-------

Provides information used to discriminate applications.











Syntax
------

.. code-block:: csharp

   public interface IApplicationDiscriminator





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection.Abstractions/Infrastructure/IApplicationDiscriminator.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.Infrastructure.IApplicationDiscriminator

Properties
----------

.. dn:interface:: Microsoft.AspNet.DataProtection.Infrastructure.IApplicationDiscriminator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.Infrastructure.IApplicationDiscriminator.Discriminator
    
        
    
        An identifier that uniquely discriminates this application from all other
        applications on the machine.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Discriminator { get; }
    

