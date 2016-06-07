

DefaultViewComponentHelper Class
================================






Default implementation for :any:`Microsoft.AspNetCore.Mvc.IViewComponentHelper`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewComponents`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentHelper`








Syntax
------

.. code-block:: csharp

    public class DefaultViewComponentHelper : IViewComponentHelper, IViewContextAware








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentHelper

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentHelper.DefaultViewComponentHelper(Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider, System.Text.Encodings.Web.HtmlEncoder, Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentSelector, Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvokerFactory, Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentHelper`\.
    
        
    
        
        :param descriptorProvider: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider`
            used to locate view components.
        
        :type descriptorProvider: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider
    
        
        :param htmlEncoder: The :any:`System.Text.Encodings.Web.HtmlEncoder`\.
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        :param selector: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentSelector`\.
        
        :type selector: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentSelector
    
        
        :param invokerFactory: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvokerFactory`\.
        
        :type invokerFactory: Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentInvokerFactory
    
        
        :param viewBufferScope: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope` that manages the lifetime of 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer` instances.
        
        :type viewBufferScope: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope
    
        
        .. code-block:: csharp
    
            public DefaultViewComponentHelper(IViewComponentDescriptorCollectionProvider descriptorProvider, HtmlEncoder htmlEncoder, IViewComponentSelector selector, IViewComponentInvokerFactory invokerFactory, IViewBufferScope viewBufferScope)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentHelper.Contextualize(Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            public void Contextualize(ViewContext viewContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentHelper.InvokeAsync(System.String, System.Object)
    
        
    
        
        :type name: System.String
    
        
        :type arguments: System.Object
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
    
        
        .. code-block:: csharp
    
            public Task<IHtmlContent> InvokeAsync(string name, object arguments)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentHelper.InvokeAsync(System.Type, System.Object)
    
        
    
        
        :type componentType: System.Type
    
        
        :type arguments: System.Object
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
    
        
        .. code-block:: csharp
    
            public Task<IHtmlContent> InvokeAsync(Type componentType, object arguments)
    

