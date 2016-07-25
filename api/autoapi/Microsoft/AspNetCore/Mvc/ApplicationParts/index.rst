

Microsoft.AspNetCore.Mvc.ApplicationParts Namespace
===================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApplicationParts/ApplicationPart/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApplicationParts/ApplicationPartManager/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApplicationParts/AssemblyPart/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApplicationParts/IApplicationFeatureProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApplicationParts/IApplicationFeatureProvider-TFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApplicationParts/IApplicationPartTypeProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApplicationParts/ICompilationReferencesProvider/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.ApplicationParts


    .. rubric:: Interfaces


    interface :dn:iface:`IApplicationFeatureProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationFeatureProvider

        
        Marker interface for :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationFeatureProvider`
        implementations.


    interface :dn:iface:`IApplicationFeatureProvider\<TFeature>`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationFeatureProvider\<TFeature>

        
        A provider for a given <em>TFeature</em> feature.


    interface :dn:iface:`IApplicationPartTypeProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationPartTypeProvider

        
        Exposes a set of types from an :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart`\.


    interface :dn:iface:`ICompilationReferencesProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ApplicationParts.ICompilationReferencesProvider

        
        Exposes one or more reference paths from an :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart`\.


    .. rubric:: Classes


    class :dn:cls:`ApplicationPart`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart

        
        A part of an MVC application.


    class :dn:cls:`ApplicationPartManager`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager

        
        Manages the parts and features of an MVC application.


    class :dn:cls:`AssemblyPart`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart

        
        An :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart` backed by an :dn:prop:`Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart.Assembly`\.


