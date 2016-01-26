

Microsoft.AspNet.Mvc.ViewComponents Namespace
=============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/ContentViewComponentResult/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/DefaultViewComponentActivator/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/DefaultViewComponentDescriptorCollectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/DefaultViewComponentDescriptorProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/DefaultViewComponentHelper/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/DefaultViewComponentInvoker/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/DefaultViewComponentInvokerFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/DefaultViewComponentSelector/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/IViewComponentActivator/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/IViewComponentDescriptorCollectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/IViewComponentDescriptorProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/IViewComponentInvoker/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/IViewComponentInvokerFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/IViewComponentSelector/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/JsonViewComponentResult/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/ViewComponentContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/ViewComponentContextAttribute/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/ViewComponentConventions/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/ViewComponentDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/ViewComponentDescriptorCollection/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/ViewComponentMethodSelector/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ViewComponents/ViewViewComponentResult/index
   
   











.. dn:namespace:: Microsoft.AspNet.Mvc.ViewComponents


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.ContentViewComponentResult`
        An :any:`Microsoft.AspNet.Mvc.IViewComponentResult` which writes text when executed.


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentActivator`
        A default implementation of :any:`Microsoft.AspNet.Mvc.ViewComponents.IViewComponentActivator`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorCollectionProvider`
        A default implementation of :any:`Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider`


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider`
        Default implementation of :any:`Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorProvider`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvoker`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentInvokerFactory`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentSelector`
        Default implementation of :any:`Microsoft.AspNet.Mvc.ViewComponents.IViewComponentSelector`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult`
        An :any:`Microsoft.AspNet.Mvc.IViewComponentResult` which renders JSON text when executed.


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext`
        A context for View Components.


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContextAttribute`
        Specifies that a controller property should be set with the current 
        :any:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext` when creating the view component. The property must have a public
        set method.


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentConventions`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor`
        A descriptor for a View Component.


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptorCollection`
        A cached collection of :any:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentMethodSelector`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult`
        A :any:`Microsoft.AspNet.Mvc.IViewComponentResult` that renders a partial view when executed.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Mvc.ViewComponents.IViewComponentActivator`
        Provides methods to activate an instantiated ViewComponent


    interface :dn:iface:`Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider`
        Provides the currently cached collection of :any:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor`\.


    interface :dn:iface:`Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorProvider`
        Discovers the View Components in the application.


    interface :dn:iface:`Microsoft.AspNet.Mvc.ViewComponents.IViewComponentInvoker`
        


    interface :dn:iface:`Microsoft.AspNet.Mvc.ViewComponents.IViewComponentInvokerFactory`
        


    interface :dn:iface:`Microsoft.AspNet.Mvc.ViewComponents.IViewComponentSelector`
        Selects a View Component based on a View Component name.


