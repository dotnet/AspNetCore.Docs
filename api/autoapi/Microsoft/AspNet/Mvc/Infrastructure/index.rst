

Microsoft.AspNet.Mvc.Infrastructure Namespace
=============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/ActionBindingContextAccessor/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/ActionContextAccessor/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/ActionDescriptorsCollection/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/ActionInvokerFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/AmbiguousActionException/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/DefaultActionDescriptorsCollectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/DefaultActionSelector/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/DefaultAssemblyProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/DefaultTypeActivatorCache/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/IActionBindingContextAccessor/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/IActionContextAccessor/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/IActionDescriptorsCollectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/IActionHttpMethodProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/IActionInvokerFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/IActionSelector/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/IAssemblyProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/IHttpResponseStreamWriterFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/IRouteConstraintProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/IRouteTemplateProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/ITypeActivatorCache/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/MemoryPoolHttpResponseStreamWriterFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/MvcRouteHandler/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/ObjectResultExecutor/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/RouteConstraintAttribute/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Infrastructure/StaticAssemblyProvider/index
   
   











.. dn:namespace:: Microsoft.AspNet.Mvc.Infrastructure


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.ActionBindingContextAccessor`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.ActionContextAccessor`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection`
        A cached collection of :any:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.ActionInvokerFactory`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.AmbiguousActionException`
        An exception which indicates multiple matches in action selection.


    class :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.DefaultActionDescriptorsCollectionProvider`
        Default implementation for ActionDescriptors.
        This implementation caches the results at first call, and is not responsible for updates.


    class :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.DefaultActionSelector`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.DefaultAssemblyProvider`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.DefaultTypeActivatorCache`
        Caches :any:`Microsoft.Extensions.DependencyInjection.ObjectFactory` instances produced by 
        :dn:meth:`Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateFactory(System.Type,System.Type[])`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.MemoryPoolHttpResponseStreamWriterFactory`
        An :any:`Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory` that uses pooled buffers.


    class :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.MvcRouteHandler`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor`
        Executes an :any:`Microsoft.AspNet.Mvc.ObjectResult` to write to the response.


    class :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute`
        An attribute which specifies a required route value for an action or controller.
        
        
        When placed on an action, the route data of a request must match the expectations of the route
        constraint in order for the action to be selected. See :dn:prop:`Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute.RouteKeyHandling` for
        the expectations that must be satisfied by the route data.
        
        
        When placed on a controller, unless overridden by the action, the constraint applies to all
        actions defined by the controller.


    class :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.StaticAssemblyProvider`
        A :any:`Microsoft.AspNet.Mvc.Infrastructure.IAssemblyProvider` with a fixed set of candidate assemblies.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Mvc.Infrastructure.IActionBindingContextAccessor`
        


    interface :dn:iface:`Microsoft.AspNet.Mvc.Infrastructure.IActionContextAccessor`
        


    interface :dn:iface:`Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider`
        Provides the currently cached collection of :any:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor`\.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Infrastructure.IActionHttpMethodProvider`
        


    interface :dn:iface:`Microsoft.AspNet.Mvc.Infrastructure.IActionInvokerFactory`
        


    interface :dn:iface:`Microsoft.AspNet.Mvc.Infrastructure.IActionSelector`
        


    interface :dn:iface:`Microsoft.AspNet.Mvc.Infrastructure.IAssemblyProvider`
        Specifies the contract for discovering assemblies that may contain Mvc specific types such as controllers,
        view components and precompiled views.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory`
        Creates :any:`System.IO.TextWriter` instances for writing to :dn:prop:`Microsoft.AspNet.Http.HttpResponse.Body`\.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Infrastructure.IRouteConstraintProvider`
        An interface for metadata which provides :any:`Microsoft.AspNet.Mvc.Routing.RouteDataActionConstraint` values
        for a controller or action.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Infrastructure.IRouteTemplateProvider`
        Interface for attributes which can supply a route template for attribute routing.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Infrastructure.ITypeActivatorCache`
        Caches :any:`Microsoft.Extensions.DependencyInjection.ObjectFactory` instances produced by 
        :dn:meth:`Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateFactory(System.Type,System.Type[])`\.


