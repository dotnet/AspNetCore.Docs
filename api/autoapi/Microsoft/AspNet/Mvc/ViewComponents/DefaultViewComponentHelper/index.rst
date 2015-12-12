

DefaultViewComponentHelper Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper`








Syntax
------

.. code-block:: csharp

   public class DefaultViewComponentHelper : IViewComponentHelper, ICanHasViewContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/DefaultViewComponentHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper.DefaultViewComponentHelper(Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider, Microsoft.AspNet.Mvc.ViewComponents.IViewComponentSelector, Microsoft.AspNet.Mvc.ViewComponents.IViewComponentInvokerFactory)
    
        
        
        
        :type descriptorProvider: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorCollectionProvider
        
        
        :type selector: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentSelector
        
        
        :type invokerFactory: Microsoft.AspNet.Mvc.ViewComponents.IViewComponentInvokerFactory
    
        
        .. code-block:: csharp
    
           public DefaultViewComponentHelper(IViewComponentDescriptorCollectionProvider descriptorProvider, IViewComponentSelector selector, IViewComponentInvokerFactory invokerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper.Contextualize(Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public void Contextualize(ViewContext viewContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper.Invoke(System.String, System.Object[])
    
        
        
        
        :type name: System.String
        
        
        :type arguments: System.Object[]
        :rtype: Microsoft.AspNet.Mvc.Rendering.HtmlString
    
        
        .. code-block:: csharp
    
           public HtmlString Invoke(string name, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper.Invoke(System.Type, System.Object[])
    
        
        
        
        :type componentType: System.Type
        
        
        :type arguments: System.Object[]
        :rtype: Microsoft.AspNet.Mvc.Rendering.HtmlString
    
        
        .. code-block:: csharp
    
           public HtmlString Invoke(Type componentType, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper.InvokeAsync(System.String, System.Object[])
    
        
        
        
        :type name: System.String
        
        
        :type arguments: System.Object[]
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Rendering.HtmlString}
    
        
        .. code-block:: csharp
    
           public Task<HtmlString> InvokeAsync(string name, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper.InvokeAsync(System.Type, System.Object[])
    
        
        
        
        :type componentType: System.Type
        
        
        :type arguments: System.Object[]
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Rendering.HtmlString}
    
        
        .. code-block:: csharp
    
           public Task<HtmlString> InvokeAsync(Type componentType, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper.RenderInvoke(System.String, System.Object[])
    
        
        
        
        :type name: System.String
        
        
        :type arguments: System.Object[]
    
        
        .. code-block:: csharp
    
           public void RenderInvoke(string name, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper.RenderInvoke(System.Type, System.Object[])
    
        
        
        
        :type componentType: System.Type
        
        
        :type arguments: System.Object[]
    
        
        .. code-block:: csharp
    
           public void RenderInvoke(Type componentType, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper.RenderInvokeAsync(System.String, System.Object[])
    
        
        
        
        :type name: System.String
        
        
        :type arguments: System.Object[]
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task RenderInvokeAsync(string name, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentHelper.RenderInvokeAsync(System.Type, System.Object[])
    
        
        
        
        :type componentType: System.Type
        
        
        :type arguments: System.Object[]
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task RenderInvokeAsync(Type componentType, params object[] arguments)
    

