

Microsoft.AspNet.Mvc.ApiExplorer Namespace
==========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/ApiDescription/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/ApiDescriptionActionData/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/ApiDescriptionExtensions/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/ApiDescriptionGroup/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/ApiDescriptionGroupCollection/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/ApiDescriptionGroupCollectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/ApiDescriptionProviderContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/ApiParameterDescription/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/ApiParameterRouteInfo/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/ApiResponseFormat/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/DefaultApiDescriptionProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/IApiDescriptionGroupCollectionProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/IApiDescriptionGroupNameProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/IApiDescriptionProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/IApiDescriptionVisibilityProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/IApiResponseFormatMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ApiExplorer/IApiResponseMetadataProvider/index
   
   











.. dn:namespace:: Microsoft.AspNet.Mvc.ApiExplorer


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription`
        Represents an API exposed by this application.


    class :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionActionData`
        Represents data used to build an <c>ApiDescription</c>, stored as part of the 
        :dn:prop:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.Properties`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionExtensions`
        Extension methods for :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup`
        Represents a group of related apis.


    class :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollection`
        A cached collection of :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext`
        A context object for :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription` providers.


    class :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterDescription`
        A metadata description of an input to an API.


    class :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterRouteInfo`
        A metadata description of routing information for an :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterDescription`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiResponseFormat`
        Represents a possible format for the body of a response.


    class :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.DefaultApiDescriptionProvider`
        Implements a provider of :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription` for actions represented
        by :any:`Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor`\.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionGroupCollectionProvider`
        Provides access to a collection of :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionGroup`\.


    interface :dn:iface:`Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionGroupNameProvider`
        Represents group name metadata for an <c>ApiDescription</c>.


    interface :dn:iface:`Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionProvider`
        


    interface :dn:iface:`Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionVisibilityProvider`
        Represents visibility metadata for an <c>ApiDescription</c>.


    interface :dn:iface:`Microsoft.AspNet.Mvc.ApiExplorer.IApiResponseFormatMetadataProvider`
        Provides metadata information about the response format to an <c>IApiDescriptionProvider</c>.


    interface :dn:iface:`Microsoft.AspNet.Mvc.ApiExplorer.IApiResponseMetadataProvider`
        Provides a return type and a set of possible content types returned by a successful execution of the action.


