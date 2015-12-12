

ElmPageMiddleware Class
=======================



.. contents:: 
   :local:



Summary
-------

Enables viewing logs captured by the :any:`Microsoft.AspNet.Diagnostics.Elm.ElmCaptureMiddleware`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Elm.ElmPageMiddleware`








Syntax
------

.. code-block:: csharp

   public class ElmPageMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Elm/ElmPageMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmPageMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmPageMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Elm.ElmPageMiddleware.ElmPageMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Diagnostics.Elm.ElmOptions>, Microsoft.AspNet.Diagnostics.Elm.ElmStore)
    
        
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type options: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Diagnostics.Elm.ElmOptions}
        
        
        :type store: Microsoft.AspNet.Diagnostics.Elm.ElmStore
    
        
        .. code-block:: csharp
    
           public ElmPageMiddleware(RequestDelegate next, IOptions<ElmOptions> options, ElmStore store)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmPageMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.ElmPageMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

