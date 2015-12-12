

HttpRequestMessageExtensions Class
==================================



.. contents:: 
   :local:



Summary
-------

Provides extension methods for the :any:`System.Net.Http.HttpRequestMessage` class.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Net.Http.HttpRequestMessageExtensions`








Syntax
------

.. code-block:: csharp

   public class HttpRequestMessageExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.WebApiCompatShim/HttpRequestMessage/HttpRequestMessageExtensions.cs>`_





.. dn:class:: System.Net.Http.HttpRequestMessageExtensions

Methods
-------

.. dn:class:: System.Net.Http.HttpRequestMessageExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateErrorResponse(System.Net.Http.HttpRequestMessage, System.Net.Http.InvalidByteRangeException)
    
        
    
        Helper method for creating an :any:`System.Net.Http.HttpResponseMessage` message with a "416 (Requested Range Not
        Satisfiable)" status code. This response can be used in combination with the 
        :any:`System.Net.Http.ByteRangeStreamContent` to indicate that the requested range or
        ranges do not overlap with the current resource. The response contains a "Content-Range" header indicating
        the valid upper and lower bounds for requested ranges.
    
        
        
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :param invalidByteRangeException: An  instance, typically
            thrown by a  instance.
        
        :type invalidByteRangeException: System.Net.Http.InvalidByteRangeException
        :rtype: System.Net.Http.HttpResponseMessage
        :return: An 416 (Requested Range Not Satisfiable) error response with a Content-Range header indicating the valid
            range.
    
        
        .. code-block:: csharp
    
           public static HttpResponseMessage CreateErrorResponse(HttpRequestMessage request, InvalidByteRangeException invalidByteRangeException)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateErrorResponse(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage`
        representing an error with an instance of :any:`System.Net.Http.ObjectContent\`1` wrapping an 
        :any:`System.Web.Http.HttpError` for model state ``modelState``. If no formatter is found, this
        method returns a response with status 406 NotAcceptable.
    
        
        
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
        
        
        :param modelState: The model state.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        :rtype: System.Net.Http.HttpResponseMessage
        :return: An error response for <paramref name="modelState" /> with status code <paramref name="statusCode" />.
    
        
        .. code-block:: csharp
    
           public static HttpResponseMessage CreateErrorResponse(HttpRequestMessage request, HttpStatusCode statusCode, ModelStateDictionary modelState)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateErrorResponse(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, System.Exception)
    
        
    
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage`
        representing an error with an instance of :any:`System.Net.Http.ObjectContent\`1` wrapping an 
        :any:`System.Web.Http.HttpError` for exception ``exception``. If no formatter is found, this method
        returns a response with status 406 NotAcceptable.
    
        
        
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
        
        
        :param exception: The exception.
        
        :type exception: System.Exception
        :rtype: System.Net.Http.HttpResponseMessage
        :return: An error response for <paramref name="exception" /> with status code <paramref name="statusCode" />.
    
        
        .. code-block:: csharp
    
           public static HttpResponseMessage CreateErrorResponse(HttpRequestMessage request, HttpStatusCode statusCode, Exception exception)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateErrorResponse(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, System.String)
    
        
    
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage`
        representing an error with an instance of :any:`System.Net.Http.ObjectContent\`1` wrapping an 
        :any:`System.Web.Http.HttpError` with message ``message``. If no formatter is found, this method
        returns a response with status 406 NotAcceptable.
    
        
        
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
        
        
        :param message: The error message.
        
        :type message: System.String
        :rtype: System.Net.Http.HttpResponseMessage
        :return: An error response with error message <paramref name="message" /> and status code
            <paramref name="statusCode" />.
    
        
        .. code-block:: csharp
    
           public static HttpResponseMessage CreateErrorResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateErrorResponse(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, System.String, System.Exception)
    
        
    
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage`
        representing an error with an instance of :any:`System.Net.Http.ObjectContent\`1` wrapping an 
        :any:`System.Web.Http.HttpError` with error message ``message`` for exception
        ``exception``. If no formatter is found, this method returns a response with status 406
        NotAcceptable.
    
        
        
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
        
        
        :param message: The error message.
        
        :type message: System.String
        
        
        :param exception: The exception.
        
        :type exception: System.Exception
        :rtype: System.Net.Http.HttpResponseMessage
        :return: An error response for <paramref name="exception" /> with error message <paramref name="message" />
            and status code <paramref name="statusCode" />.
    
        
        .. code-block:: csharp
    
           public static HttpResponseMessage CreateErrorResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message, Exception exception)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateErrorResponse(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, System.Web.Http.HttpError)
    
        
    
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage`
        representing an error with an instance of :any:`System.Net.Http.ObjectContent\`1` wrapping ``error``
        as the content. If no formatter is found, this method returns a response with status 406 NotAcceptable.
    
        
        
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
        
        
        :param error: The error to wrap.
        
        :type error: System.Web.Http.HttpError
        :rtype: System.Net.Http.HttpResponseMessage
        :return: An error response wrapping <paramref name="error" /> with status code <paramref name="statusCode" />.
    
        
        .. code-block:: csharp
    
           public static HttpResponseMessage CreateErrorResponse(HttpRequestMessage request, HttpStatusCode statusCode, HttpError error)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, T)
    
        
    
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage` with an
        instance of :any:`System.Net.Http.ObjectContent\`1` as the content if a formatter can be found. If no formatter is
        found, this method returns a response with status 406 NotAcceptable.
        configuration.
    
        
        
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
        
        
        :param value: The value to wrap. Can be null.
        
        :type value: {T}
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <paramref name="value" /> with <paramref name="statusCode" />.
    
        
        .. code-block:: csharp
    
           public static HttpResponseMessage CreateResponse<T>(HttpRequestMessage request, HttpStatusCode statusCode, T value)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, T, System.Collections.Generic.IEnumerable<System.Net.Http.Formatting.MediaTypeFormatter>)
    
        
    
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage` with an
        instance of :any:`System.Net.Http.ObjectContent\`1` as the content if a formatter can be found. If no formatter is
        found, this method returns a response with status 406 NotAcceptable.
    
        
        
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
        
        
        :param value: The value to wrap. Can be null.
        
        :type value: {T}
        
        
        :param formatters: The set of  objects from which to choose.
        
        :type formatters: System.Collections.Generic.IEnumerable{System.Net.Http.Formatting.MediaTypeFormatter}
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <paramref name="value" /> with <paramref name="statusCode" />.
    
        
        .. code-block:: csharp
    
           public static HttpResponseMessage CreateResponse<T>(HttpRequestMessage request, HttpStatusCode statusCode, T value, IEnumerable<MediaTypeFormatter> formatters)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, T, System.Net.Http.Formatting.MediaTypeFormatter)
    
        
    
        Helper method that creates a :any:`System.Net.Http.HttpResponseMessage` with an :any:`System.Net.Http.ObjectContent\`1`
        instance containing the provided ``value`` and the given ``formatter``.
    
        
        
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
        
        
        :param value: The value to wrap. Can be null.
        
        :type value: {T}
        
        
        :param formatter: The formatter to use.
        
        :type formatter: System.Net.Http.Formatting.MediaTypeFormatter
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <paramref name="value" /> with <paramref name="statusCode" />.
    
        
        .. code-block:: csharp
    
           public static HttpResponseMessage CreateResponse<T>(HttpRequestMessage request, HttpStatusCode statusCode, T value, MediaTypeFormatter formatter)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, T, System.Net.Http.Formatting.MediaTypeFormatter, System.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        Helper method that creates a :any:`System.Net.Http.HttpResponseMessage` with an :any:`System.Net.Http.ObjectContent\`1`
        instance containing the provided ``value`` and the given ``formatter``.
    
        
        
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
        
        
        :param value: The value to wrap. Can be null.
        
        :type value: {T}
        
        
        :param formatter: The formatter to use.
        
        :type formatter: System.Net.Http.Formatting.MediaTypeFormatter
        
        
        :param mediaType: The media type override to set on the response's content. Can be null.
        
        :type mediaType: System.Net.Http.Headers.MediaTypeHeaderValue
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <paramref name="value" /> with <paramref name="statusCode" />.
    
        
        .. code-block:: csharp
    
           public static HttpResponseMessage CreateResponse<T>(HttpRequestMessage request, HttpStatusCode statusCode, T value, MediaTypeFormatter formatter, MediaTypeHeaderValue mediaType)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, T, System.Net.Http.Formatting.MediaTypeFormatter, System.String)
    
        
    
        Helper method that creates a :any:`System.Net.Http.HttpResponseMessage` with an :any:`System.Net.Http.ObjectContent\`1`
        instance containing the provided ``value`` and the given ``formatter``.
    
        
        
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
        
        
        :param value: The value to wrap. Can be null.
        
        :type value: {T}
        
        
        :param formatter: The formatter to use.
        
        :type formatter: System.Net.Http.Formatting.MediaTypeFormatter
        
        
        :param mediaType: The media type override to set on the response's content. Can be null.
        
        :type mediaType: System.String
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <paramref name="value" /> with <paramref name="statusCode" />.
    
        
        .. code-block:: csharp
    
           public static HttpResponseMessage CreateResponse<T>(HttpRequestMessage request, HttpStatusCode statusCode, T value, MediaTypeFormatter formatter, string mediaType)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, T, System.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        Helper method that creates a :any:`System.Net.Http.HttpResponseMessage` with an :any:`System.Net.Http.ObjectContent\`1`
        instance containing the provided ``value``. The given ``mediaType`` is used
        to find an instance of :any:`System.Net.Http.Formatting.MediaTypeFormatter`\.
    
        
        
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
        
        
        :param value: The value to wrap. Can be null.
        
        :type value: {T}
        
        
        :param mediaType: The media type used to look up an instance of .
        
        :type mediaType: System.Net.Http.Headers.MediaTypeHeaderValue
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <paramref name="value" /> with <paramref name="statusCode" />.
    
        
        .. code-block:: csharp
    
           public static HttpResponseMessage CreateResponse<T>(HttpRequestMessage request, HttpStatusCode statusCode, T value, MediaTypeHeaderValue mediaType)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, T, System.String)
    
        
    
        Helper method that creates a :any:`System.Net.Http.HttpResponseMessage` with an :any:`System.Net.Http.ObjectContent\`1`
        instance containing the provided ``value``. The given ``mediaType`` is used
        to find an instance of :any:`System.Net.Http.Formatting.MediaTypeFormatter`\.
    
        
        
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
        
        
        :param value: The value to wrap. Can be null.
        
        :type value: {T}
        
        
        :param mediaType: The media type used to look up an instance of .
        
        :type mediaType: System.String
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <paramref name="value" /> with <paramref name="statusCode" />.
    
        
        .. code-block:: csharp
    
           public static HttpResponseMessage CreateResponse<T>(HttpRequestMessage request, HttpStatusCode statusCode, T value, string mediaType)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, T)
    
        
    
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage` with an
        instance of :any:`System.Net.Http.ObjectContent\`1` as the content and :dn:field:`System.Net.HttpStatusCode.OK`
        as the status code if a formatter can be found. If no formatter is found, this method returns a response
        with status 406 NotAcceptable.
    
        
        
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :param value: The value to wrap. Can be null.
        
        :type value: {T}
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <paramref name="value" /> with <see cref="F:System.Net.HttpStatusCode.OK" /> status code.
    
        
        .. code-block:: csharp
    
           public static HttpResponseMessage CreateResponse<T>(HttpRequestMessage request, T value)
    

