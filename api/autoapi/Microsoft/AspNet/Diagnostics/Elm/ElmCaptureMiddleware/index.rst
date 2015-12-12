

ElmCaptureMiddleware Class
==========================



.. contents:: 
   :local:



Summary
-------

Enables the Elm logging service.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Elm.ElmCaptureMiddleware`








Syntax
------

.. code-block:: csharp

   public class ElmCaptureMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics.Elm/ElmCaptureMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmCaptureMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmCaptureMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Elm.ElmCaptureMiddleware.ElmCaptureMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Diagnostics.Elm.ElmOptions>)
    
        
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type options: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Diagnostics.Elm.ElmOptions}
    
        
        .. code-block:: csharp
    
           public ElmCaptureMiddleware(RequestDelegate next, ILoggerFactory factory, IOptions<ElmOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmCaptureMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.ElmCaptureMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

