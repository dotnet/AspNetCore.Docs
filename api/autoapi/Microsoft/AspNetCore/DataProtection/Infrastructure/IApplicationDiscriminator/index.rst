

IApplicationDiscriminator Interface
===================================






Provides information used to discriminate applications.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.DataProtection.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IApplicationDiscriminator








.. dn:interface:: Microsoft.AspNetCore.DataProtection.Infrastructure.IApplicationDiscriminator
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.Infrastructure.IApplicationDiscriminator

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.Infrastructure.IApplicationDiscriminator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.Infrastructure.IApplicationDiscriminator.Discriminator
    
        
    
        
        An identifier that uniquely discriminates this application from all other
        applications on the machine.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Discriminator
            {
                get;
            }
    

