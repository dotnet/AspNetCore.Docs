

Microsoft.AspNetCore.Mvc.WebApiCompatShim Namespace
===================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/FormDataCollectionExtensions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/HttpRequestMessageFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/HttpRequestMessageHttpContextExtensions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/HttpRequestMessageModelBinder/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/HttpRequestMessageModelBinderProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/HttpResponseExceptionActionFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/HttpResponseMessageOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/IHttpRequestMessageFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/IUseWebApiActionConventions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/IUseWebApiOverloading/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/IUseWebApiParameterConventions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/IUseWebApiRoutes/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/OverloadActionConstraint/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/UseWebApiActionConventionsAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/UseWebApiOverloadingAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/UseWebApiParameterConventionsAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/UseWebApiRoutesAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/WebApiActionConventionsApplicationModelConvention/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/WebApiCompatShimOptions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/WebApiCompatShimOptionsSetup/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/WebApiOverloadingApplicationModelConvention/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/WebApiParameterConventionsApplicationModelConvention/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/WebApiCompatShim/WebApiRoutesApplicationModelConvention/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.WebApiCompatShim


    .. rubric:: Interfaces


    interface :dn:iface:`IHttpRequestMessageFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.IHttpRequestMessageFeature

        


    interface :dn:iface:`IUseWebApiActionConventions`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.IUseWebApiActionConventions

        
        Indicates actions without attribute routes in a controller use ASP.NET Web API routing conventions.


    interface :dn:iface:`IUseWebApiOverloading`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.IUseWebApiOverloading

        
        Indicates actions in a controller should be selected only if all non-optional parameters are satisfied. Applies
        the :any:`Microsoft.AspNetCore.Mvc.WebApiCompatShim.OverloadActionConstraint` to all actions in the controller.


    interface :dn:iface:`IUseWebApiParameterConventions`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.IUseWebApiParameterConventions

        
        Indicates the model binding system should use ASP.NET Web API conventions for parameters of a controller's
        actions. For example, bind simple types from the URI.


    interface :dn:iface:`IUseWebApiRoutes`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.IUseWebApiRoutes

        
        Indicates the controller is in the "api" area.


    .. rubric:: Classes


    class :dn:cls:`FormDataCollectionExtensions`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.FormDataCollectionExtensions

        


    class :dn:cls:`HttpRequestMessageFeature`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpRequestMessageFeature

        


    class :dn:cls:`HttpRequestMessageHttpContextExtensions`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpRequestMessageHttpContextExtensions

        


    class :dn:cls:`HttpRequestMessageModelBinder`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpRequestMessageModelBinder

        
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` implementation to bind models of type :any:`System.Net.Http.HttpRequestMessage`\.


    class :dn:cls:`HttpRequestMessageModelBinderProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpRequestMessageModelBinderProvider

        
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider` implementation to bind models of type :any:`System.Net.Http.HttpRequestMessage`\.


    class :dn:cls:`HttpResponseExceptionActionFilter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter

        
        An action filter that sets :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Result` to an :any:`Microsoft.AspNetCore.Mvc.ObjectResult`
        if the exception type is :any:`System.Web.Http.HttpResponseException`\.
        This filter runs immediately after the action.


    class :dn:cls:`HttpResponseMessageOutputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseMessageOutputFormatter

        


    class :dn:cls:`OverloadActionConstraint`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.OverloadActionConstraint

        
        An :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint` limiting candidate actions to those for which the request satisfies all
        non-optional parameters.


    class :dn:cls:`UseWebApiActionConventionsAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.UseWebApiActionConventionsAttribute

        
        Indicates actions without attribute routes in a controller use ASP.NET Web API routing conventions.


    class :dn:cls:`UseWebApiOverloadingAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.UseWebApiOverloadingAttribute

        
        Indicates actions in a controller should be selected only if all non-optional parameters are satisfied. Applies
        the :any:`Microsoft.AspNetCore.Mvc.WebApiCompatShim.OverloadActionConstraint` to all actions in the controller.


    class :dn:cls:`UseWebApiParameterConventionsAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.UseWebApiParameterConventionsAttribute

        
        Indicates the model binding system should use ASP.NET Web API conventions for parameters of a controller's
        actions. For example, bind simple types from the URI.


    class :dn:cls:`UseWebApiRoutesAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.UseWebApiRoutesAttribute

        
        Indicates the controller is in the "api" area.


    class :dn:cls:`WebApiActionConventionsApplicationModelConvention`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiActionConventionsApplicationModelConvention

        


    class :dn:cls:`WebApiCompatShimOptions`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiCompatShimOptions

        


    class :dn:cls:`WebApiCompatShimOptionsSetup`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup

        


    class :dn:cls:`WebApiOverloadingApplicationModelConvention`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiOverloadingApplicationModelConvention

        


    class :dn:cls:`WebApiParameterConventionsApplicationModelConvention`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiParameterConventionsApplicationModelConvention

        


    class :dn:cls:`WebApiRoutesApplicationModelConvention`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiRoutesApplicationModelConvention

        


