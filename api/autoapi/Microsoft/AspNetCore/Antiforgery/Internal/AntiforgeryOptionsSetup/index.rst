

AntiforgeryOptionsSetup Class
=============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery.Internal`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Options.ConfigureOptions{Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions}`
* :dn:cls:`Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryOptionsSetup`








Syntax
------

.. code-block:: csharp

    public class AntiforgeryOptionsSetup : ConfigureOptions<AntiforgeryOptions>, IConfigureOptions<AntiforgeryOptions>








.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryOptionsSetup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryOptionsSetup.AntiforgeryOptionsSetup(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.DataProtection.DataProtectionOptions>)
    
        
    
        
        :type dataProtectionOptionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.DataProtection.DataProtectionOptions<Microsoft.AspNetCore.DataProtection.DataProtectionOptions>}
    
        
        .. code-block:: csharp
    
            public AntiforgeryOptionsSetup(IOptions<DataProtectionOptions> dataProtectionOptionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryOptionsSetup.ConfigureOptions(Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions, Microsoft.AspNetCore.DataProtection.DataProtectionOptions)
    
        
    
        
        :type options: Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions
    
        
        :type dataProtectionOptions: Microsoft.AspNetCore.DataProtection.DataProtectionOptions
    
        
        .. code-block:: csharp
    
            public static void ConfigureOptions(AntiforgeryOptions options, DataProtectionOptions dataProtectionOptions)
    

