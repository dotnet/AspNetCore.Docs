

UriHelper Class
===============



.. contents:: 
   :local:



Summary
-------

A helper class for constructing encoded Uris for use in headers and other Uris.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Extensions.UriHelper`








Syntax
------

.. code-block:: csharp

   public class UriHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Extensions/UriHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Extensions.UriHelper

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Extensions.UriHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Extensions.UriHelper.Encode(Microsoft.AspNet.Http.PathString, Microsoft.AspNet.Http.PathString, Microsoft.AspNet.Http.QueryString, Microsoft.AspNet.Http.FragmentString)
    
        
    
        Combines the given URI components into a string that is properly encoded for use in HTTP headers.
    
        
        
        
        :type pathBase: Microsoft.AspNet.Http.PathString
        
        
        :type path: Microsoft.AspNet.Http.PathString
        
        
        :type query: Microsoft.AspNet.Http.QueryString
        
        
        :type fragment: Microsoft.AspNet.Http.FragmentString
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string Encode(PathString pathBase = null, PathString path = null, QueryString query = null, FragmentString fragment = null)
    
    .. dn:method:: Microsoft.AspNet.Http.Extensions.UriHelper.Encode(System.String, Microsoft.AspNet.Http.HostString, Microsoft.AspNet.Http.PathString, Microsoft.AspNet.Http.PathString, Microsoft.AspNet.Http.QueryString, Microsoft.AspNet.Http.FragmentString)
    
        
    
        Combines the given URI components into a string that is properly encoded for use in HTTP headers.
        Note that unicode in the HostString will be encoded as punycode.
    
        
        
        
        :type scheme: System.String
        
        
        :type host: Microsoft.AspNet.Http.HostString
        
        
        :type pathBase: Microsoft.AspNet.Http.PathString
        
        
        :type path: Microsoft.AspNet.Http.PathString
        
        
        :type query: Microsoft.AspNet.Http.QueryString
        
        
        :type fragment: Microsoft.AspNet.Http.FragmentString
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string Encode(string scheme, HostString host, PathString pathBase = null, PathString path = null, QueryString query = null, FragmentString fragment = null)
    
    .. dn:method:: Microsoft.AspNet.Http.Extensions.UriHelper.Encode(System.Uri)
    
        
    
        Generates a string from the given absolute or relative Uri that is appropriately encoded for use in
        HTTP headers. Note that a unicode host name will be encoded as punycode.
    
        
        
        
        :type uri: System.Uri
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string Encode(Uri uri)
    
    .. dn:method:: Microsoft.AspNet.Http.Extensions.UriHelper.GetDisplayUrl(Microsoft.AspNet.Http.HttpRequest)
    
        
    
        Returns the combined components of the request URL in a fully un-escaped form (except for the QueryString)
        suitable only for display. This format should not be used in HTTP headers or other HTTP operations.
    
        
        
        
        :type request: Microsoft.AspNet.Http.HttpRequest
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetDisplayUrl(HttpRequest request)
    
    .. dn:method:: Microsoft.AspNet.Http.Extensions.UriHelper.GetEncodedUrl(Microsoft.AspNet.Http.HttpRequest)
    
        
    
        Returns the combined components of the request URL in a fully escaped form suitable for use in HTTP headers
        and other HTTP operations.
    
        
        
        
        :type request: Microsoft.AspNet.Http.HttpRequest
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetEncodedUrl(HttpRequest request)
    

