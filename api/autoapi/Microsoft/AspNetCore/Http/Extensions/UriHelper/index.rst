

UriHelper Class
===============






A helper class for constructing encoded Uris for use in headers and other Uris.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Extensions`
Assemblies
    * Microsoft.AspNetCore.Http.Extensions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Extensions.UriHelper`








Syntax
------

.. code-block:: csharp

    public class UriHelper








.. dn:class:: Microsoft.AspNetCore.Http.Extensions.UriHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Extensions.UriHelper

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Extensions.UriHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Extensions.UriHelper.BuildAbsolute(System.String, Microsoft.AspNetCore.Http.HostString, Microsoft.AspNetCore.Http.PathString, Microsoft.AspNetCore.Http.PathString, Microsoft.AspNetCore.Http.QueryString, Microsoft.AspNetCore.Http.FragmentString)
    
        
    
        
        Combines the given URI components into a string that is properly encoded for use in HTTP headers.
        Note that unicode in the HostString will be encoded as punycode.
    
        
    
        
        :param scheme: http, https, etc.
        
        :type scheme: System.String
    
        
        :param host: The host portion of the uri normally included in the Host header. This may include the port.
        
        :type host: Microsoft.AspNetCore.Http.HostString
    
        
        :param pathBase: The first portion of the request path associated with application root.
        
        :type pathBase: Microsoft.AspNetCore.Http.PathString
    
        
        :param path: The portion of the request path that identifies the requested resource.
        
        :type path: Microsoft.AspNetCore.Http.PathString
    
        
        :param query: The query, if any.
        
        :type query: Microsoft.AspNetCore.Http.QueryString
    
        
        :param fragment: The fragment, if any.
        
        :type fragment: Microsoft.AspNetCore.Http.FragmentString
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string BuildAbsolute(string scheme, HostString host, PathString pathBase = null, PathString path = null, QueryString query = null, FragmentString fragment = null)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Extensions.UriHelper.BuildRelative(Microsoft.AspNetCore.Http.PathString, Microsoft.AspNetCore.Http.PathString, Microsoft.AspNetCore.Http.QueryString, Microsoft.AspNetCore.Http.FragmentString)
    
        
    
        
        Combines the given URI components into a string that is properly encoded for use in HTTP headers.
    
        
    
        
        :param pathBase: The first portion of the request path associated with application root.
        
        :type pathBase: Microsoft.AspNetCore.Http.PathString
    
        
        :param path: The portion of the request path that identifies the requested resource.
        
        :type path: Microsoft.AspNetCore.Http.PathString
    
        
        :param query: The query, if any.
        
        :type query: Microsoft.AspNetCore.Http.QueryString
    
        
        :param fragment: The fragment, if any.
        
        :type fragment: Microsoft.AspNetCore.Http.FragmentString
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string BuildRelative(PathString pathBase = null, PathString path = null, QueryString query = null, FragmentString fragment = null)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Extensions.UriHelper.Encode(System.Uri)
    
        
    
        
        Generates a string from the given absolute or relative Uri that is appropriately encoded for use in
        HTTP headers. Note that a unicode host name will be encoded as punycode.
    
        
    
        
        :param uri: The Uri to encode.
        
        :type uri: System.Uri
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string Encode(Uri uri)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(Microsoft.AspNetCore.Http.HttpRequest)
    
        
    
        
        Returns the combined components of the request URL in a fully un-escaped form (except for the QueryString)
        suitable only for display. This format should not be used in HTTP headers or other HTTP operations.
    
        
    
        
        :param request: The request to assemble the uri pieces from.
        
        :type request: Microsoft.AspNetCore.Http.HttpRequest
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetDisplayUrl(this HttpRequest request)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(Microsoft.AspNetCore.Http.HttpRequest)
    
        
    
        
        Returns the combined components of the request URL in a fully escaped form suitable for use in HTTP headers
        and other HTTP operations.
    
        
    
        
        :param request: The request to assemble the uri pieces from.
        
        :type request: Microsoft.AspNetCore.Http.HttpRequest
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetEncodedUrl(this HttpRequest request)
    

