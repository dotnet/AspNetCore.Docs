

Microsoft.AspNetCore.Mvc.ApiExplorer Namespace
==============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/ApiDescription/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/ApiDescriptionExtensions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/ApiDescriptionGroup/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/ApiDescriptionGroupCollection/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/ApiDescriptionGroupCollectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/ApiDescriptionProviderContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/ApiParameterDescription/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/ApiParameterRouteInfo/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/ApiRequestFormat/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/ApiResponseFormat/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/ApiResponseType/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/DefaultApiDescriptionProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/IApiDescriptionGroupCollectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/IApiDescriptionGroupNameProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/IApiDescriptionProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/IApiDescriptionVisibilityProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/IApiRequestFormatMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/IApiRequestMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/IApiResponseMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ApiExplorer/IApiResponseTypeMetadataProvider/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.ApiExplorer


    .. rubric:: Classes


    class :dn:cls:`ApiDescription`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription

        
        Represents an API exposed by this application.


    class :dn:cls:`ApiDescriptionExtensions`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionExtensions

        
        Extension methods for :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription`\.


    class :dn:cls:`ApiDescriptionGroup`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup

        
        Represents a group of related apis.


    class :dn:cls:`ApiDescriptionGroupCollection`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollection

        
        A cached collection of :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup`\.


    class :dn:cls:`ApiDescriptionGroupCollectionProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider

        


    class :dn:cls:`ApiDescriptionProviderContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext

        
        A context object for :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription` providers.


    class :dn:cls:`ApiParameterDescription`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription

        
        A metadata description of an input to an API.


    class :dn:cls:`ApiParameterRouteInfo`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterRouteInfo

        
        A metadata description of routing information for an :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription`\.


    class :dn:cls:`ApiRequestFormat`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApiExplorer.ApiRequestFormat

        
        A possible format for the body of a request.


    class :dn:cls:`ApiResponseFormat`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseFormat

        
        Possible format for an :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType`\.


    class :dn:cls:`ApiResponseType`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType

        
        Possible type of the response body which is formatted by :dn:prop:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType.ApiResponseFormats`\.


    class :dn:cls:`DefaultApiDescriptionProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ApiExplorer.DefaultApiDescriptionProvider

        
        Implements a provider of :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription` for actions represented
        by :any:`Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor`\.


    .. rubric:: Interfaces


    interface :dn:iface:`IApiDescriptionGroupCollectionProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionGroupCollectionProvider

        
        Provides access to a collection of :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroup`\.


    interface :dn:iface:`IApiDescriptionGroupNameProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionGroupNameProvider

        
        Represents group name metadata for an <code>ApiDescription</code>.


    interface :dn:iface:`IApiDescriptionProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionProvider

        


    interface :dn:iface:`IApiDescriptionVisibilityProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionVisibilityProvider

        
        Represents visibility metadata for an <code>ApiDescription</code>.


    interface :dn:iface:`IApiRequestFormatMetadataProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ApiExplorer.IApiRequestFormatMetadataProvider

        
        Provides metadata information about the request format to an <code>IApiDescriptionProvider</code>.


    interface :dn:iface:`IApiRequestMetadataProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ApiExplorer.IApiRequestMetadataProvider

        
        Provides a a set of possible content types than can be consumed by the action.


    interface :dn:iface:`IApiResponseMetadataProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ApiExplorer.IApiResponseMetadataProvider

        
        Provides a return type, status code and a set of possible content types returned by a
        successful execution of the action.


    interface :dn:iface:`IApiResponseTypeMetadataProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ApiExplorer.IApiResponseTypeMetadataProvider

        
        Provides metadata information about the response format to an <code>IApiDescriptionProvider</code>.


