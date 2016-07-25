

HttpRequestMessageExtensions Class
==================================






Provides extension methods for the :any:`System.Net.Http.HttpRequestMessage` class.


Namespace
    :dn:ns:`System.Net.Http`
Assemblies
    * Microsoft.AspNetCore.Mvc.WebApiCompatShim

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Net.Http.HttpRequestMessageExtensions`








Syntax
------

.. code-block:: csharp

    public class HttpRequestMessageExtensions








.. dn:class:: System.Net.Http.HttpRequestMessageExtensions
    :hidden:

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
    
        
        :param invalidByteRangeException: An :any:`System.Net.Http.InvalidByteRangeException` instance, typically
            thrown by a :any:`System.Net.Http.ByteRangeStreamContent` instance.
        
        :type invalidByteRangeException: System.Net.Http.InvalidByteRangeException
        :rtype: System.Net.Http.HttpResponseMessage
        :return: 
            An 416 (Requested Range Not Satisfiable) error response with a Content-Range header indicating the valid
            range.
    
        
        .. code-block:: csharp
    
            public static HttpResponseMessage CreateErrorResponse(this HttpRequestMessage request, InvalidByteRangeException invalidByteRangeException)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateErrorResponse(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage`
        representing an error with an instance of :any:`System.Net.Http.ObjectContent\`1` wrapping an 
        :any:`System.Web.Http.HttpError` for model state <em>modelState</em>. If no formatter is found, this
        method returns a response with status 406 NotAcceptable.
    
        
    
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
    
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
    
        
        :param modelState: The model state.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
        :rtype: System.Net.Http.HttpResponseMessage
        :return: 
            An error response for <em>modelState</em> with status code <em>statusCode</em>.
    
        
        .. code-block:: csharp
    
            public static HttpResponseMessage CreateErrorResponse(this HttpRequestMessage request, HttpStatusCode statusCode, ModelStateDictionary modelState)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateErrorResponse(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, System.Exception)
    
        
    
        
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage`
        representing an error with an instance of :any:`System.Net.Http.ObjectContent\`1` wrapping an 
        :any:`System.Web.Http.HttpError` for exception <em>exception</em>. If no formatter is found, this method
        returns a response with status 406 NotAcceptable.
    
        
    
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
    
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
    
        
        :param exception: The exception.
        
        :type exception: System.Exception
        :rtype: System.Net.Http.HttpResponseMessage
        :return: 
            An error response for <em>exception</em> with status code <em>statusCode</em>.
    
        
        .. code-block:: csharp
    
            public static HttpResponseMessage CreateErrorResponse(this HttpRequestMessage request, HttpStatusCode statusCode, Exception exception)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateErrorResponse(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, System.String)
    
        
    
        
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage`
        representing an error with an instance of :any:`System.Net.Http.ObjectContent\`1` wrapping an 
        :any:`System.Web.Http.HttpError` with message <em>message</em>. If no formatter is found, this method
        returns a response with status 406 NotAcceptable.
    
        
    
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
    
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
    
        
        :param message: The error message.
        
        :type message: System.String
        :rtype: System.Net.Http.HttpResponseMessage
        :return: 
            An error response with error message <em>message</em> and status code
            <em>statusCode</em>.
    
        
        .. code-block:: csharp
    
            public static HttpResponseMessage CreateErrorResponse(this HttpRequestMessage request, HttpStatusCode statusCode, string message)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateErrorResponse(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, System.String, System.Exception)
    
        
    
        
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage`
        representing an error with an instance of :any:`System.Net.Http.ObjectContent\`1` wrapping an 
        :any:`System.Web.Http.HttpError` with error message <em>message</em> for exception
        <em>exception</em>. If no formatter is found, this method returns a response with status 406
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
        :return: An error response for <em>exception</em> with error message <em>message</em>
            and status code <em>statusCode</em>.
    
        
        .. code-block:: csharp
    
            public static HttpResponseMessage CreateErrorResponse(this HttpRequestMessage request, HttpStatusCode statusCode, string message, Exception exception)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateErrorResponse(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, System.Web.Http.HttpError)
    
        
    
        
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage`
        representing an error with an instance of :any:`System.Net.Http.ObjectContent\`1` wrapping <em>error</em>
        as the content. If no formatter is found, this method returns a response with status 406 NotAcceptable.
    
        
    
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
    
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
    
        
        :param error: The error to wrap.
        
        :type error: System.Web.Http.HttpError
        :rtype: System.Net.Http.HttpResponseMessage
        :return: 
            An error response wrapping <em>error</em> with status code <em>statusCode</em>.
    
        
        .. code-block:: csharp
    
            public static HttpResponseMessage CreateErrorResponse(this HttpRequestMessage request, HttpStatusCode statusCode, HttpError error)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, T)
    
        
    
        
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage` with an
        instance of :any:`System.Net.Http.ObjectContent\`1` as the content if a formatter can be found. If no formatter is
        found, this method returns a response with status 406 NotAcceptable.
        configuration.
    
        
    
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
    
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
    
        
        :param value: The value to wrap. Can be <code>null</code>.
        
        :type value: T
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <em>value</em> with <em>statusCode</em>.
    
        
        .. code-block:: csharp
    
            public static HttpResponseMessage CreateResponse<T>(this HttpRequestMessage request, HttpStatusCode statusCode, T value)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, T, System.Collections.Generic.IEnumerable<System.Net.Http.Formatting.MediaTypeFormatter>)
    
        
    
        
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage` with an
        instance of :any:`System.Net.Http.ObjectContent\`1` as the content if a formatter can be found. If no formatter is
        found, this method returns a response with status 406 NotAcceptable.
    
        
    
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
    
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
    
        
        :param value: The value to wrap. Can be <code>null</code>.
        
        :type value: T
    
        
        :param formatters: The set of :any:`System.Net.Http.Formatting.MediaTypeFormatter` objects from which to choose.
        
        :type formatters: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Net.Http.Formatting.MediaTypeFormatter<System.Net.Http.Formatting.MediaTypeFormatter>}
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <em>value</em> with <em>statusCode</em>.
    
        
        .. code-block:: csharp
    
            public static HttpResponseMessage CreateResponse<T>(this HttpRequestMessage request, HttpStatusCode statusCode, T value, IEnumerable<MediaTypeFormatter> formatters)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, T, System.Net.Http.Formatting.MediaTypeFormatter)
    
        
    
        
        Helper method that creates a :any:`System.Net.Http.HttpResponseMessage` with an :any:`System.Net.Http.ObjectContent\`1`
        instance containing the provided <em>value</em> and the given <em>formatter</em>.
    
        
    
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
    
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
    
        
        :param value: The value to wrap. Can be <code>null</code>.
        
        :type value: T
    
        
        :param formatter: The formatter to use.
        
        :type formatter: System.Net.Http.Formatting.MediaTypeFormatter
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <em>value</em> with <em>statusCode</em>.
    
        
        .. code-block:: csharp
    
            public static HttpResponseMessage CreateResponse<T>(this HttpRequestMessage request, HttpStatusCode statusCode, T value, MediaTypeFormatter formatter)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, T, System.Net.Http.Formatting.MediaTypeFormatter, System.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        
        Helper method that creates a :any:`System.Net.Http.HttpResponseMessage` with an :any:`System.Net.Http.ObjectContent\`1`
        instance containing the provided <em>value</em> and the given <em>formatter</em>.
    
        
    
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
    
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
    
        
        :param value: The value to wrap. Can be <code>null</code>.
        
        :type value: T
    
        
        :param formatter: The formatter to use.
        
        :type formatter: System.Net.Http.Formatting.MediaTypeFormatter
    
        
        :param mediaType: 
            The media type override to set on the response's content. Can be <code>null</code>.
        
        :type mediaType: System.Net.Http.Headers.MediaTypeHeaderValue
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <em>value</em> with <em>statusCode</em>.
    
        
        .. code-block:: csharp
    
            public static HttpResponseMessage CreateResponse<T>(this HttpRequestMessage request, HttpStatusCode statusCode, T value, MediaTypeFormatter formatter, MediaTypeHeaderValue mediaType)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, T, System.Net.Http.Formatting.MediaTypeFormatter, System.String)
    
        
    
        
        Helper method that creates a :any:`System.Net.Http.HttpResponseMessage` with an :any:`System.Net.Http.ObjectContent\`1`
        instance containing the provided <em>value</em> and the given <em>formatter</em>.
    
        
    
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
    
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
    
        
        :param value: The value to wrap. Can be <code>null</code>.
        
        :type value: T
    
        
        :param formatter: The formatter to use.
        
        :type formatter: System.Net.Http.Formatting.MediaTypeFormatter
    
        
        :param mediaType: 
            The media type override to set on the response's content. Can be <code>null</code>.
        
        :type mediaType: System.String
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <em>value</em> with <em>statusCode</em>.
    
        
        .. code-block:: csharp
    
            public static HttpResponseMessage CreateResponse<T>(this HttpRequestMessage request, HttpStatusCode statusCode, T value, MediaTypeFormatter formatter, string mediaType)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, T, System.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        
        Helper method that creates a :any:`System.Net.Http.HttpResponseMessage` with an :any:`System.Net.Http.ObjectContent\`1`
        instance containing the provided <em>value</em>. The given <em>mediaType</em> is used
        to find an instance of :any:`System.Net.Http.Formatting.MediaTypeFormatter`\.
    
        
    
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
    
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
    
        
        :param value: The value to wrap. Can be <code>null</code>.
        
        :type value: T
    
        
        :param mediaType: 
            The media type used to look up an instance of :any:`System.Net.Http.Formatting.MediaTypeFormatter`\.
        
        :type mediaType: System.Net.Http.Headers.MediaTypeHeaderValue
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <em>value</em> with <em>statusCode</em>.
    
        
        .. code-block:: csharp
    
            public static HttpResponseMessage CreateResponse<T>(this HttpRequestMessage request, HttpStatusCode statusCode, T value, MediaTypeHeaderValue mediaType)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, System.Net.HttpStatusCode, T, System.String)
    
        
    
        
        Helper method that creates a :any:`System.Net.Http.HttpResponseMessage` with an :any:`System.Net.Http.ObjectContent\`1`
        instance containing the provided <em>value</em>. The given <em>mediaType</em> is used
        to find an instance of :any:`System.Net.Http.Formatting.MediaTypeFormatter`\.
    
        
    
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
    
        
        :param statusCode: The status code of the created response.
        
        :type statusCode: System.Net.HttpStatusCode
    
        
        :param value: The value to wrap. Can be <code>null</code>.
        
        :type value: T
    
        
        :param mediaType: 
            The media type used to look up an instance of :any:`System.Net.Http.Formatting.MediaTypeFormatter`\.
        
        :type mediaType: System.String
        :rtype: System.Net.Http.HttpResponseMessage
        :return: A response wrapping <em>value</em> with <em>statusCode</em>.
    
        
        .. code-block:: csharp
    
            public static HttpResponseMessage CreateResponse<T>(this HttpRequestMessage request, HttpStatusCode statusCode, T value, string mediaType)
    
    .. dn:method:: System.Net.Http.HttpRequestMessageExtensions.CreateResponse<T>(System.Net.Http.HttpRequestMessage, T)
    
        
    
        
        Helper method that performs content negotiation and creates a :any:`System.Net.Http.HttpResponseMessage` with an
        instance of :any:`System.Net.Http.ObjectContent\`1` as the content and :dn:field:`System.Net.HttpStatusCode.OK`
        as the status code if a formatter can be found. If no formatter is found, this method returns a response
        with status 406 NotAcceptable.
    
        
    
        
        :param request: The request.
        
        :type request: System.Net.Http.HttpRequestMessage
    
        
        :param value: The value to wrap. Can be <code>null</code>.
        
        :type value: T
        :rtype: System.Net.Http.HttpResponseMessage
        :return: 
            A response wrapping <em>value</em> with :dn:field:`System.Net.HttpStatusCode.OK` status code.
    
        
        .. code-block:: csharp
    
            public static HttpResponseMessage CreateResponse<T>(this HttpRequestMessage request, T value)
    

