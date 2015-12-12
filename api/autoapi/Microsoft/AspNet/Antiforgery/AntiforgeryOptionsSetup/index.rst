

AntiforgeryOptionsSetup Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.OptionsModel.ConfigureOptions{Microsoft.AspNet.Antiforgery.AntiforgeryOptions}`
* :dn:cls:`Microsoft.AspNet.Antiforgery.AntiforgeryOptionsSetup`








Syntax
------

.. code-block:: csharp

   public class AntiforgeryOptionsSetup : ConfigureOptions<AntiforgeryOptions>, IConfigureOptions<AntiforgeryOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/antiforgery/blob/master/src/Microsoft.AspNet.Antiforgery/AntiforgeryOptionsSetup.cs>`_





.. dn:class:: Microsoft.AspNet.Antiforgery.AntiforgeryOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNet.Antiforgery.AntiforgeryOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Antiforgery.AntiforgeryOptionsSetup.AntiforgeryOptionsSetup(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.DataProtection.DataProtectionOptions>)
    
        
        
        
        :type dataProtectionOptionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.DataProtection.DataProtectionOptions}
    
        
        .. code-block:: csharp
    
           public AntiforgeryOptionsSetup(IOptions<DataProtectionOptions> dataProtectionOptionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Antiforgery.AntiforgeryOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Antiforgery.AntiforgeryOptionsSetup.ConfigureOptions(Microsoft.AspNet.Antiforgery.AntiforgeryOptions, Microsoft.AspNet.DataProtection.DataProtectionOptions)
    
        
        
        
        :type options: Microsoft.AspNet.Antiforgery.AntiforgeryOptions
        
        
        :type dataProtectionOptions: Microsoft.AspNet.DataProtection.DataProtectionOptions
    
        
        .. code-block:: csharp
    
           public static void ConfigureOptions(AntiforgeryOptions options, DataProtectionOptions dataProtectionOptions)
    

