

Microsoft.AspNetCore.Mvc.Razor.TagHelpers Namespace
===================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/TagHelpers/FeatureTagHelperTypeResolver/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/TagHelpers/TagHelperFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/TagHelpers/TagHelperFeatureProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/TagHelpers/UrlResolutionTagHelper/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers


    .. rubric:: Classes


    class :dn:cls:`FeatureTagHelperTypeResolver`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.TagHelpers.FeatureTagHelperTypeResolver

        
        Resolves tag helper types from the :dn:prop:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager.ApplicationParts`
        of the application.


    class :dn:cls:`TagHelperFeature`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeature

        
        The list of tag helper types in an MVC application. The :any:`Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeature` can be populated
        using the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager` that is available during startup at :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcBuilder.PartManager`
        and :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder.PartManager` or at a later stage by requiring the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager`
        as a dependency in a component.


    class :dn:cls:`TagHelperFeatureProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeatureProvider

        
        Discovers tag helpers from a list of :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart` instances.


    class :dn:cls:`UrlResolutionTagHelper`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper

        
        :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` implementation targeting elements containing attributes with URL expected values.


