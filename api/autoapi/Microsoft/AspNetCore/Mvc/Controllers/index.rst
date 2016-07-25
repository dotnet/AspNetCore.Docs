

Microsoft.AspNetCore.Mvc.Controllers Namespace
==============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Controllers/ControllerActionDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Controllers/ControllerBoundPropertyDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Controllers/ControllerFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Controllers/ControllerFeatureProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Controllers/ControllerParameterDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Controllers/DefaultControllerActivator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Controllers/DefaultControllerFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Controllers/IControllerActivator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Controllers/IControllerFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Controllers/ServiceBasedControllerActivator/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.Controllers


    .. rubric:: Interfaces


    interface :dn:iface:`IControllerActivator`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator

        
        Provides methods to create a controller.


    interface :dn:iface:`IControllerFactory`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Controllers.IControllerFactory

        
        Provides methods for creation and disposal of controllers.


    .. rubric:: Classes


    class :dn:cls:`ControllerActionDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor

        


    class :dn:cls:`ControllerBoundPropertyDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Controllers.ControllerBoundPropertyDescriptor

        
        A descriptor for model bound properties of a controller.


    class :dn:cls:`ControllerFeature`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Controllers.ControllerFeature

        
        The list of controllers types in an MVC application. The :any:`Microsoft.AspNetCore.Mvc.Controllers.ControllerFeature` can be populated
        using the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager` that is available during startup at :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcBuilder.PartManager`
        and :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder.PartManager` or at a later stage by requiring the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager`
        as a dependency in a component.


    class :dn:cls:`ControllerFeatureProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Controllers.ControllerFeatureProvider

        
        Discovers controllers from a list of :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart` instances.


    class :dn:cls:`ControllerParameterDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Controllers.ControllerParameterDescriptor

        
        A descriptor for method parameters of an action method.


    class :dn:cls:`DefaultControllerActivator`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerActivator

        
        :any:`Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator` that uses type activation to create controllers.


    class :dn:cls:`DefaultControllerFactory`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerFactory

        
        Default implementation for :any:`Microsoft.AspNetCore.Mvc.Controllers.IControllerFactory`\.


    class :dn:cls:`ServiceBasedControllerActivator`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Controllers.ServiceBasedControllerActivator

        
        A :any:`Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator` that retrieves controllers as services from the request's 
        :any:`System.IServiceProvider`\.


