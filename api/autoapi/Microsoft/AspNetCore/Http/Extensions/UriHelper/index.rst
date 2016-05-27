

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

    
    .. dn:method:: Microsoft.AspNetCore.Http.Extensions.UriHelper.Encode(Microsoft.AspNetCore.Http.PathString, Microsoft.AspNetCore.Http.PathString, Microsoft.AspNetCore.Http.QueryString, Microsoft.AspNetCore.Http.FragmentString)
    
        
    
        
        Combines the given URI components into a string that is properly encoded for use in HTTP headers.
    
        
    
        
        :type pathBase: Microsoft.AspNetCore.Http.PathString
    
        
        :type path: Microsoft.AspNetCore.Http.PathString
    
        
        :type query: Microsoft.AspNetCore.Http.QueryString
    
        
        :type fragment: Microsoft.AspNetCore.Http.FragmentString
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string Encode(PathString pathBase = null, PathString path = null, QueryString query = null, FragmentString fragment = null)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Extensions.UriHelper.Encode(System.String, Microsoft.AspNetCore.Http.HostString, Microsoft.AspNetCore.Http.PathString, Microsoft.AspNetCore.Http.PathString, Microsoft.AspNetCore.Http.QueryString, Microsoft.AspNetCore.Http.FragmentString)
    
        
    
        
        Combines the given URI components into a string that is properly encoded for use in HTTP headers.
        Note that unicode in the HostString will be encoded as punycode.
    
        
    
        
        :type scheme: System.String
    
        
        :type host: Microsoft.AspNetCore.Http.HostString
    
        
        :type pathBase: Microsoft.AspNetCore.Http.PathString
    
        
        :type path: Microsoft.AspNetCore.Http.PathString
    
        
        :type query: Microsoft.AspNetCore.Http.QueryString
    
        
        :type fragment: Microsoft.AspNetCore.Http.FragmentString
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string Encode(string scheme, HostString host, PathString pathBase = null, PathString path = null, QueryString query = null, FragmentString fragment = null)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Extensions.UriHelper.Encode(System.Uri)
    
        
    
        
        Generates a string from the given absolute or relative Uri that is appropriately encoded for use in
        HTTP headers. Note that a unicode host name will be encoded as punycode.
    
        
    
        
        :type uri: System.Uri
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string Encode(Uri uri)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(Microsoft.AspNetCore.Http.HttpRequest)
    
        
    
        
        Returns the combined components of the request URL in a fully un-escaped form (except for the QueryString)
        suitable only for display. This format should not be used in HTTP headers or other HTTP operations.
    
        
    
        
        :type request: Microsoft.AspNetCore.Http.HttpRequest
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetDisplayUrl(HttpRequest request)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(Microsoft.AspNetCore.Http.HttpRequest)
    
        
    
        
        Returns the combined components of the request URL in a fully escaped form suitable for use in HTTP headers
        and other HTTP operations.
    
        
    
        
        :type request: Microsoft.AspNetCore.Http.HttpRequest
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetEncodedUrl(HttpRequest request)
    

