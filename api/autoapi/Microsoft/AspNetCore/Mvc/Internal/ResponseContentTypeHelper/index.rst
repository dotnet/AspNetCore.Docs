

ResponseContentTypeHelper Class
===============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ResponseContentTypeHelper`








Syntax
------

.. code-block:: csharp

    public class ResponseContentTypeHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ResponseContentTypeHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ResponseContentTypeHelper

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ResponseContentTypeHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ResponseContentTypeHelper.ResolveContentTypeAndEncoding(System.String, System.String, System.String, out System.String, out System.Text.Encoding)
    
        
    
        
        Gets the content type and encoding that need to be used for the response.
        The priority for selecting the content type is:
        1. ContentType property set on the action result
        2. :dn:prop:`Microsoft.AspNetCore.Http.HttpResponse.ContentType` property set on :any:`Microsoft.AspNetCore.Http.HttpResponse`
        3. Default content type set on the action result
    
        
    
        
        :param actionResultContentType: ContentType set on the action result
        
        :type actionResultContentType: System.String
    
        
        :param httpResponseContentType: :dn:prop:`Microsoft.AspNetCore.Http.HttpResponse.ContentType` property set
                on :any:`Microsoft.AspNetCore.Http.HttpResponse`
        
        :type httpResponseContentType: System.String
    
        
        :param defaultContentType: The default content type of the action result.
        
        :type defaultContentType: System.String
    
        
        :param resolvedContentType: The content type to be used for the response content type header
        
        :type resolvedContentType: System.String
    
        
        :param resolvedContentTypeEncoding: Encoding to be used for writing the response
        
        :type resolvedContentTypeEncoding: System.Text.Encoding
    
        
        .. code-block:: csharp
    
            public static void ResolveContentTypeAndEncoding(string actionResultContentType, string httpResponseContentType, string defaultContentType, out string resolvedContentType, out Encoding resolvedContentTypeEncoding)
    

