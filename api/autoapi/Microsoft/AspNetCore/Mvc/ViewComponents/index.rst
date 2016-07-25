

Microsoft.AspNetCore.Mvc.ViewComponents Namespace
=================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/ContentViewComponentResult/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/DefaultViewComponentActivator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/DefaultViewComponentDescriptorCollectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/DefaultViewComponentDescriptorProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/DefaultViewComponentFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/DefaultViewComponentHelper/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/DefaultViewComponentInvoker/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/DefaultViewComponentInvokerFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/DefaultViewComponentSelector/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/HtmlContentViewComponentResult/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/IViewComponentActivator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/IViewComponentDescriptorCollectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/IViewComponentDescriptorProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/IViewComponentFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/IViewComponentInvoker/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/IViewComponentInvokerFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/IViewComponentSelector/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/ServiceBasedViewComponentActivator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/ViewComponentContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/ViewComponentContextAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/ViewComponentConventions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/ViewComponentDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/ViewComponentDescriptorCollection/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/ViewComponentFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/ViewComponentFeatureProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ViewComponents/ViewViewComponentResult/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.ViewComponents


    .. rubric:: Interfaces


    interface :dn:iface:`IViewComponentActivator`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentActivator

        
        Provides methods to instantiate and release a ViewComponent.


    interface :dn:iface:`IViewComponentDescriptorCollectionProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider

        
        Provides the currently cached collection of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor`\.


    interface :dn:iface:`IViewComponentDescriptorProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorProvider

        
        Discovers the view components in the application.


    interface :dn:iface:`IViewComponentFactory`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentFactory

        
        Provides methods for creation and disposal of view components.


    interface :dn:iface:`IViewComponentInvoker`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvoker

        
        Specifies the contract for execution of a view component.


    interface :dn:iface:`IViewComponentInvokerFactory`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvokerFactory

        


    interface :dn:iface:`IViewComponentSelector`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentSelector

        
        Selects a view component based on a view component name.


    .. rubric:: Classes


    class :dn:cls:`ContentViewComponentResult`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.ContentViewComponentResult

        
        An :any:`Microsoft.AspNetCore.Mvc.IViewComponentResult` which writes text when executed.


    class :dn:cls:`DefaultViewComponentActivator`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentActivator

        
        A default implementation of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentActivator`\.


    class :dn:cls:`DefaultViewComponentDescriptorCollectionProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider

        
        A default implementation of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider`


    class :dn:cls:`DefaultViewComponentDescriptorProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider

        
        Default implementation of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorProvider`\.


    class :dn:cls:`DefaultViewComponentFactory`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentFactory

        
        Default implementation for :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentFactory`\.


    class :dn:cls:`DefaultViewComponentHelper`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentHelper

        
        Default implementation for :any:`Microsoft.AspNetCore.Mvc.IViewComponentHelper`\.


    class :dn:cls:`DefaultViewComponentInvoker`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvoker

        
        Default implementation for :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvoker`\.


    class :dn:cls:`DefaultViewComponentInvokerFactory`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentInvokerFactory

        


    class :dn:cls:`DefaultViewComponentSelector`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentSelector

        
        Default implementation of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentSelector`\.


    class :dn:cls:`HtmlContentViewComponentResult`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.HtmlContentViewComponentResult

        
        An :any:`Microsoft.AspNetCore.Mvc.IViewComponentResult` which writes an :any:`Microsoft.AspNetCore.Html.IHtmlContent` when executed.


    class :dn:cls:`ServiceBasedViewComponentActivator`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.ServiceBasedViewComponentActivator

        
        A :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentActivator` that retrieves view components as services from the request's 
        :any:`System.IServiceProvider`\.


    class :dn:cls:`ViewComponentContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext

        
        A context for view components.


    class :dn:cls:`ViewComponentContextAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContextAttribute

        
        Specifies that a controller property should be set with the current 
        :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext` when creating the view component. The property must have a public
        set method.


    class :dn:cls:`ViewComponentConventions`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentConventions

        


    class :dn:cls:`ViewComponentDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor

        
        A descriptor for a view component.


    class :dn:cls:`ViewComponentDescriptorCollection`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptorCollection

        
        A cached collection of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor`\.


    class :dn:cls:`ViewComponentFeature`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeature

        
        The list of view component types in an MVC application.The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeature` can be populated
        using the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager` that is available during startup at :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcBuilder.PartManager`
        and :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder.PartManager` or at a later stage by requiring the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager`
        as a dependency in a component.


    class :dn:cls:`ViewComponentFeatureProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeatureProvider

        
        Discovers view components from a list of :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart` instances.


    class :dn:cls:`ViewViewComponentResult`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult

        
        A :any:`Microsoft.AspNetCore.Mvc.IViewComponentResult` that renders a partial view when executed.


