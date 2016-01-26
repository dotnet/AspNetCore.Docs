

CompositeViewEngine Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewEngines.CompositeViewEngine`








Syntax
------

.. code-block:: csharp

   public class CompositeViewEngine : ICompositeViewEngine, IViewEngine





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewEngines/CompositeViewEngine.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewEngines.CompositeViewEngine

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewEngines.CompositeViewEngine
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewEngines.CompositeViewEngine.CompositeViewEngine(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.MvcViewOptions>)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.ViewEngines.CompositeViewEngine`\.
    
        
        
        
        :param optionsAccessor: The options accessor for .
        
        :type optionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.MvcViewOptions}
    
        
        .. code-block:: csharp
    
           public CompositeViewEngine(IOptions<MvcViewOptions> optionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewEngines.CompositeViewEngine
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewEngines.CompositeViewEngine.FindPartialView(Microsoft.AspNet.Mvc.ActionContext, System.String)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type partialViewName: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult
    
        
        .. code-block:: csharp
    
           public ViewEngineResult FindPartialView(ActionContext context, string partialViewName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewEngines.CompositeViewEngine.FindView(Microsoft.AspNet.Mvc.ActionContext, System.String)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type viewName: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult
    
        
        .. code-block:: csharp
    
           public ViewEngineResult FindView(ActionContext context, string viewName)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewEngines.CompositeViewEngine
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewEngines.CompositeViewEngine.ViewEngines
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ViewEngines.IViewEngine}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<IViewEngine> ViewEngines { get; }
    

