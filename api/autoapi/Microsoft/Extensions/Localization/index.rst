

Microsoft.Extensions.Localization Namespace
===========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/Extensions/Localization/IResourceNamesCache/index
   
   
   
   /autoapi/Microsoft/Extensions/Localization/IStringLocalizer/index
   
   
   
   /autoapi/Microsoft/Extensions/Localization/IStringLocalizerFactory/index
   
   
   
   /autoapi/Microsoft/Extensions/Localization/IStringLocalizer-T/index
   
   
   
   /autoapi/Microsoft/Extensions/Localization/LocalizationOptions/index
   
   
   
   /autoapi/Microsoft/Extensions/Localization/LocalizedString/index
   
   
   
   /autoapi/Microsoft/Extensions/Localization/ResourceManagerStringLocalizer/index
   
   
   
   /autoapi/Microsoft/Extensions/Localization/ResourceManagerStringLocalizerFactory/index
   
   
   
   /autoapi/Microsoft/Extensions/Localization/ResourceManagerWithCultureStringLocalizer/index
   
   
   
   /autoapi/Microsoft/Extensions/Localization/ResourceNamesCache/index
   
   
   
   /autoapi/Microsoft/Extensions/Localization/StringLocalizerExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Localization/StringLocalizer-TResourceSource/index
   
   











.. dn:namespace:: Microsoft.Extensions.Localization


    .. rubric:: Classes


    class :dn:cls:`Microsoft.Extensions.Localization.LocalizationOptions`
        Provides programmatic configuration for localization.


    class :dn:cls:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer`
        An :any:`Microsoft.Extensions.Localization.IStringLocalizer` that uses the :any:`System.Resources.ResourceManager` and 
        :any:`System.Resources.ResourceReader` to provide localized strings.


    class :dn:cls:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizerFactory`
        An :any:`Microsoft.Extensions.Localization.IStringLocalizerFactory` that creates instances of :any:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer`\.


    class :dn:cls:`Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer`
        An :any:`Microsoft.Extensions.Localization.IStringLocalizer` that uses the :any:`System.Resources.ResourceManager` and 
        :any:`System.Resources.ResourceReader` to provide localized strings for a specific :any:`System.Globalization.CultureInfo`\.


    class :dn:cls:`Microsoft.Extensions.Localization.ResourceNamesCache`
        An implementation of :any:`Microsoft.Extensions.Localization.IResourceNamesCache` backed by a :any:`System.Collections.Concurrent.ConcurrentDictionary\`2`\.


    class :dn:cls:`Microsoft.Extensions.Localization.StringLocalizerExtensions`
        


    class :dn:cls:`Microsoft.Extensions.Localization.StringLocalizer\<TResourceSource>`
        Provides strings for TResourceSource\.


    .. rubric:: Structures


    struct :dn:struct:`Microsoft.Extensions.Localization.LocalizedString`
        A locale specific string.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.Extensions.Localization.IResourceNamesCache`
        Represents a cache of string names in resources.


    interface :dn:iface:`Microsoft.Extensions.Localization.IStringLocalizer`
        Represents a service that provides localized strings.


    interface :dn:iface:`Microsoft.Extensions.Localization.IStringLocalizerFactory`
        Represents a factory that creates :any:`Microsoft.Extensions.Localization.IStringLocalizer` instances.


    interface :dn:iface:`Microsoft.Extensions.Localization.IStringLocalizer\<T>`
        Represents an :any:`Microsoft.Extensions.Localization.IStringLocalizer` that provides strings for T\.


