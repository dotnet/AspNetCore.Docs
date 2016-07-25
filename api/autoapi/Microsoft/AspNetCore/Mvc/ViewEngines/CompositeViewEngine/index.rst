

CompositeViewEngine Class
=========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewEngines`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewEngines.CompositeViewEngine`








Syntax
------

.. code-block:: csharp

    public class CompositeViewEngine : ICompositeViewEngine, IViewEngine








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewEngines.CompositeViewEngine
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewEngines.CompositeViewEngine

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewEngines.CompositeViewEngine
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewEngines.CompositeViewEngine.CompositeViewEngine(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.MvcViewOptions>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewEngines.CompositeViewEngine`\.
    
        
    
        
        :param optionsAccessor: The options accessor for :any:`Microsoft.AspNetCore.Mvc.MvcViewOptions`\.
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.MvcViewOptions<Microsoft.AspNetCore.Mvc.MvcViewOptions>}
    
        
        .. code-block:: csharp
    
            public CompositeViewEngine(IOptions<MvcViewOptions> optionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewEngines.CompositeViewEngine
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewEngines.CompositeViewEngine.FindView(Microsoft.AspNetCore.Mvc.ActionContext, System.String, System.Boolean)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type viewName: System.String
    
        
        :type isMainPage: System.Boolean
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult
    
        
        .. code-block:: csharp
    
            public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewEngines.CompositeViewEngine.GetView(System.String, System.String, System.Boolean)
    
        
    
        
        :type executingFilePath: System.String
    
        
        :type viewPath: System.String
    
        
        :type isMainPage: System.Boolean
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult
    
        
        .. code-block:: csharp
    
            public ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewEngines.CompositeViewEngine
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewEngines.CompositeViewEngine.ViewEngines
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine<Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<IViewEngine> ViewEngines { get; }
    

