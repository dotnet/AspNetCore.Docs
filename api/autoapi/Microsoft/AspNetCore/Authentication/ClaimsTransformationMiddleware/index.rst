

ClaimsTransformationMiddleware Class
====================================





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
* :dn:cls:`Microsoft.AspNetCore.Authentication.ClaimsTransformationMiddleware`








Syntax
------

.. code-block:: csharp

    public class ClaimsTransformationMiddleware








.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformationMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformationMiddleware

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformationMiddleware
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.ClaimsTransformationMiddleware.Options
    
        
        :rtype: Microsoft.AspNetCore.Builder.ClaimsTransformationOptions
    
        
        .. code-block:: csharp
    
            public ClaimsTransformationOptions Options
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformationMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.ClaimsTransformationMiddleware.ClaimsTransformationMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.ClaimsTransformationOptions>)
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.ClaimsTransformationOptions<Microsoft.AspNetCore.Builder.ClaimsTransformationOptions>}
    
        
        .. code-block:: csharp
    
            public ClaimsTransformationMiddleware(RequestDelegate next, IOptions<ClaimsTransformationOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformationMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.ClaimsTransformationMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

