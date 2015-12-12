

ClaimsTransformationMiddleware Class
====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.ClaimsTransformationMiddleware`








Syntax
------

.. code-block:: csharp

   public class ClaimsTransformationMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication/ClaimsTransformationMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.ClaimsTransformationMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.ClaimsTransformationMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.ClaimsTransformationMiddleware.ClaimsTransformationMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Authentication.ClaimsTransformationOptions)
    
        
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type options: Microsoft.AspNet.Authentication.ClaimsTransformationOptions
    
        
        .. code-block:: csharp
    
           public ClaimsTransformationMiddleware(RequestDelegate next, ClaimsTransformationOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.ClaimsTransformationMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.ClaimsTransformationMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.ClaimsTransformationMiddleware
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.ClaimsTransformationMiddleware.Options
    
        
        :rtype: Microsoft.AspNet.Authentication.ClaimsTransformationOptions
    
        
        .. code-block:: csharp
    
           public ClaimsTransformationOptions Options { get; set; }
    

