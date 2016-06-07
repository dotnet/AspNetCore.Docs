

TemplateBuilder Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateBuilder`








Syntax
------

.. code-block:: csharp

    public class TemplateBuilder








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateBuilder.TemplateBuilder(Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine, Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope, Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, System.String, System.String, System.Boolean, System.Object)
    
        
    
        
        :type viewEngine: Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine
    
        
        :type bufferScope: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :type htmlFieldName: System.String
    
        
        :type templateName: System.String
    
        
        :type readOnly: System.Boolean
    
        
        :type additionalViewData: System.Object
    
        
        .. code-block:: csharp
    
            public TemplateBuilder(IViewEngine viewEngine, IViewBufferScope bufferScope, ViewContext viewContext, ViewDataDictionary viewData, ModelExplorer modelExplorer, string htmlFieldName, string templateName, bool readOnly, object additionalViewData)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateBuilder.Build()
    
        
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent Build()
    

