

BaseContext Class
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`








Syntax
------

.. code-block:: csharp

    public abstract class BaseContext








.. dn:class:: Microsoft.AspNetCore.Authentication.BaseContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.BaseContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.BaseContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.BaseContext.BaseContext(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            protected BaseContext(HttpContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.BaseContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.BaseContext.HttpContext
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.BaseContext.Request
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpRequest
    
        
        .. code-block:: csharp
    
            public HttpRequest Request { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.BaseContext.Response
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpResponse
    
        
        .. code-block:: csharp
    
            public HttpResponse Response { get; }
    

