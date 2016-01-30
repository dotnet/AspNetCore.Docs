

System.Web.Http Namespace
=========================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/System/Web/Http/ApiController/index
   
   
   
   /autoapi/System/Web/Http/BadRequestErrorMessageResult/index
   
   
   
   /autoapi/System/Web/Http/ConflictResult/index
   
   
   
   /autoapi/System/Web/Http/ExceptionResult/index
   
   
   
   /autoapi/System/Web/Http/FromUriAttribute/index
   
   
   
   /autoapi/System/Web/Http/HttpError/index
   
   
   
   /autoapi/System/Web/Http/HttpErrorKeys/index
   
   
   
   /autoapi/System/Web/Http/HttpResponseException/index
   
   
   
   /autoapi/System/Web/Http/InternalServerErrorResult/index
   
   
   
   /autoapi/System/Web/Http/InvalidModelStateResult/index
   
   
   
   /autoapi/System/Web/Http/NegotiatedContentResult-T/index
   
   
   
   /autoapi/System/Web/Http/ResponseMessageResult/index
   
   











.. dn:namespace:: System.Web.Http


    .. rubric:: Classes


    class :dn:cls:`System.Web.Http.ApiController`
        


    class :dn:cls:`System.Web.Http.BadRequestErrorMessageResult`
        An action result that returns a :dn:field:`Microsoft.AspNet.Http.StatusCodes.Status400BadRequest` response and performs
        content negotiation on an :any:`System.Web.Http.HttpError` with a :dn:prop:`System.Web.Http.HttpError.Message`\.


    class :dn:cls:`System.Web.Http.ConflictResult`
        An action result that returns an empty :dn:field:`Microsoft.AspNet.Http.StatusCodes.Status409Conflict` response.


    class :dn:cls:`System.Web.Http.ExceptionResult`
        An action result that returns a :dn:field:`Microsoft.AspNet.Http.StatusCodes.Status500InternalServerError` response and
        performs content negotiation on an :any:`System.Web.Http.HttpError` based on an :dn:prop:`System.Web.Http.ExceptionResult.Exception`\.


    class :dn:cls:`System.Web.Http.FromUriAttribute`
        An attribute that specifies that the value can be bound from the query string or route data.


    class :dn:cls:`System.Web.Http.HttpError`
        Defines a serializable container for storing error information. This information is stored
        as key/value pairs. The dictionary keys to look up standard error information are available
        on the :any:`System.Web.Http.HttpErrorKeys` type.


    class :dn:cls:`System.Web.Http.HttpErrorKeys`
        Provides keys to look up error information stored in the :any:`System.Web.Http.HttpError` dictionary.


    class :dn:cls:`System.Web.Http.HttpResponseException`
        


    class :dn:cls:`System.Web.Http.InternalServerErrorResult`
        An action result that returns an empty :dn:field:`Microsoft.AspNet.Http.StatusCodes.Status500InternalServerError` response.


    class :dn:cls:`System.Web.Http.InvalidModelStateResult`
        An action result that returns a :dn:field:`Microsoft.AspNet.Http.StatusCodes.Status400BadRequest` response and performs
        content negotiation on an :any:`System.Web.Http.HttpError` based on a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`\.


    class :dn:cls:`System.Web.Http.NegotiatedContentResult\<T>`
        An action result that performs content negotiation.


    class :dn:cls:`System.Web.Http.ResponseMessageResult`
        An action result that returns a specified response message.


