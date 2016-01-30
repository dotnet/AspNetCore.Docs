

Microsoft.AspNet.Mvc.Controllers Namespace
==========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/ControllerActionDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/ControllerActionDescriptorBuilder/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/ControllerActionDescriptorProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/ControllerActionExecutor/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/ControllerActionInvoker/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/ControllerActionInvokerProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/ControllerBoundPropertyDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/ControllerParameterDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/DefaultControllerActionArgumentBinder/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/DefaultControllerActivator/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/DefaultControllerFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/DefaultControllerPropertyActivator/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/DefaultControllerTypeProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/FilterActionInvoker/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/IControllerActionArgumentBinder/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/IControllerActivator/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/IControllerFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/IControllerPropertyActivator/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/IControllerTypeProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/ServiceBasedControllerActivator/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Controllers/StaticControllerTypeProvider/index
   
   











.. dn:namespace:: Microsoft.AspNet.Mvc.Controllers


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorBuilder`
        Creates instances of :any:`Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor` from :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptorProvider`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ControllerActionExecutor`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ControllerActionInvoker`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ControllerActionInvokerProvider`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ControllerBoundPropertyDescriptor`
        A descriptor for model bound properties of a controller.


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ControllerParameterDescriptor`
        A descriptor for method parameters of an action method.


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.DefaultControllerActionArgumentBinder`
        Provides a default implementation of :any:`Microsoft.AspNet.Mvc.Controllers.IControllerActionArgumentBinder`\.
        Uses ModelBinding to populate action parameters.


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.DefaultControllerActivator`
        :any:`Microsoft.AspNet.Mvc.Controllers.IControllerActivator` that uses type activation to create controllers.


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.DefaultControllerFactory`
        Default implementation for :any:`Microsoft.AspNet.Mvc.Controllers.IControllerFactory`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.DefaultControllerPropertyActivator`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.DefaultControllerTypeProvider`
        A :any:`Microsoft.AspNet.Mvc.Controllers.IControllerTypeProvider` that identifies controller types from assemblies
        specified by the registered :any:`Microsoft.AspNet.Mvc.Infrastructure.IAssemblyProvider`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.FilterActionInvoker`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ServiceBasedControllerActivator`
        A :any:`Microsoft.AspNet.Mvc.Controllers.IControllerActivator` that retrieves controllers as services from the request's 
        :any:`System.IServiceProvider`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Controllers.StaticControllerTypeProvider`
        A :any:`Microsoft.AspNet.Mvc.Controllers.IControllerTypeProvider` with a fixed set of types that are used as controllers.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Mvc.Controllers.IControllerActionArgumentBinder`
        Provides a dictionary of action arguments.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Controllers.IControllerActivator`
        Provides methods to create a controller.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Controllers.IControllerFactory`
        Provides methods for creation and disposal of controllers.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Controllers.IControllerPropertyActivator`
        


    interface :dn:iface:`Microsoft.AspNet.Mvc.Controllers.IControllerTypeProvider`
        Provides methods for discovery of controller types.


