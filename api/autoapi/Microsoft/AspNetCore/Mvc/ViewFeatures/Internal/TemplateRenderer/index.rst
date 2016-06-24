

TemplateRenderer Class
======================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateRenderer`








Syntax
------

.. code-block:: csharp

    public class TemplateRenderer








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateRenderer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateRenderer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateRenderer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateRenderer.TemplateRenderer(Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine, Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope, Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary, System.String, System.Boolean)
    
        
    
        
        :type viewEngine: Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine
    
        
        :type bufferScope: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        :type templateName: System.String
    
        
        :type readOnly: System.Boolean
    
        
        .. code-block:: csharp
    
            public TemplateRenderer(IViewEngine viewEngine, IViewBufferScope bufferScope, ViewContext viewContext, ViewDataDictionary viewData, string templateName, bool readOnly)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateRenderer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateRenderer.GetTypeNames(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.Type)
    
        
    
        
        :type modelMetadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :type fieldType: System.Type
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public static IEnumerable<string> GetTypeNames(ModelMetadata modelMetadata, Type fieldType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateRenderer.Render()
    
        
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public IHtmlContent Render()
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateRenderer
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TemplateRenderer.IEnumerableOfIFormFileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string IEnumerableOfIFormFileName = "IEnumerable`IFormFile"
    

