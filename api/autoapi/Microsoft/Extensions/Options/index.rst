

Microsoft.Extensions.Options Namespace
======================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/Extensions/Options/ConfigureFromConfigurationOptions-TOptions/index
   
   
   
   /autoapi/Microsoft/Extensions/Options/ConfigureOptions-TOptions/index
   
   
   
   /autoapi/Microsoft/Extensions/Options/IConfigureOptions-TOptions/index
   
   
   
   /autoapi/Microsoft/Extensions/Options/IOptionsMonitor-TOptions/index
   
   
   
   /autoapi/Microsoft/Extensions/Options/IOptions-TOptions/index
   
   
   
   /autoapi/Microsoft/Extensions/Options/Options/index
   
   
   
   /autoapi/Microsoft/Extensions/Options/OptionsManager-TOptions/index
   
   
   
   /autoapi/Microsoft/Extensions/Options/OptionsWrapper-TOptions/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.Extensions.Options


    .. rubric:: Interfaces


    interface :dn:iface:`IConfigureOptions\<TOptions>`
        .. object: type=interface name=Microsoft.Extensions.Options.IConfigureOptions\<TOptions>

        
        Represents something that configures the TOptions type.


    interface :dn:iface:`IOptionsMonitor\<TOptions>`
        .. object: type=interface name=Microsoft.Extensions.Options.IOptionsMonitor\<TOptions>

        
        Used for notifications when TOptions instances change.


    interface :dn:iface:`IOptions\<TOptions>`
        .. object: type=interface name=Microsoft.Extensions.Options.IOptions\<TOptions>

        
        Used to retreive configured TOptions instances.


    .. rubric:: Classes


    class :dn:cls:`ConfigureFromConfigurationOptions\<TOptions>`
        .. object: type=class name=Microsoft.Extensions.Options.ConfigureFromConfigurationOptions\<TOptions>

        
        Configures an option instance by using ConfigurationBinder.Bind against an IConfiguration.


    class :dn:cls:`ConfigureOptions\<TOptions>`
        .. object: type=class name=Microsoft.Extensions.Options.ConfigureOptions\<TOptions>

        
        Implementation of IConfigureOptions.


    class :dn:cls:`Options`
        .. object: type=class name=Microsoft.Extensions.Options.Options

        
        Helper class.


    class :dn:cls:`OptionsManager\<TOptions>`
        .. object: type=class name=Microsoft.Extensions.Options.OptionsManager\<TOptions>

        
        Implementation of IOptions.


    class :dn:cls:`OptionsWrapper\<TOptions>`
        .. object: type=class name=Microsoft.Extensions.Options.OptionsWrapper\<TOptions>

        
        IOptions wrapper that returns the options instance.


