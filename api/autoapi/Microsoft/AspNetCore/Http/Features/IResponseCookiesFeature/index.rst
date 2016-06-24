

IResponseCookiesFeature Interface
=================================






A helper for creating the response Set-Cookie header.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IResponseCookiesFeature








.. dn:interface:: Microsoft.AspNetCore.Http.Features.IResponseCookiesFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IResponseCookiesFeature

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IResponseCookiesFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IResponseCookiesFeature.Cookies
    
        
    
        
        Gets the wrapper for the response Set-Cookie header.
    
        
        :rtype: Microsoft.AspNetCore.Http.IResponseCookies
    
        
        .. code-block:: csharp
    
            IResponseCookies Cookies { get; }
    

