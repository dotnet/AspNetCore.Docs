

IViewComponentHelper Interface
==============================






Supports the rendering of view components in a view.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IViewComponentHelper








.. dn:interface:: Microsoft.AspNetCore.Mvc.IViewComponentHelper
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.IViewComponentHelper

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.IViewComponentHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.IViewComponentHelper.InvokeAsync(System.String, System.Object)
    
        
    
        
        Invokes a view component with the specified <em>name</em>.
    
        
    
        
        :param name: The name of the view component.
        
        :type name: System.String
    
        
        :param arguments: 
            An :any:`System.Object` with properties representing arguments to be passed to the invoked view component
            method. Alternatively, an :any:`System.Collections.Generic.IDictionary\`2` instance
            containing the invocation arguments.
        
        :type arguments: System.Object
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns the rendered :any:`Microsoft.AspNetCore.Html.IHtmlContent`\.
            
    
        
        .. code-block:: csharp
    
            Task<IHtmlContent> InvokeAsync(string name, object arguments)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.IViewComponentHelper.InvokeAsync(System.Type, System.Object)
    
        
    
        
        Invokes a view component of type <em>componentType</em>.
    
        
    
        
        :param componentType: The view component :any:`System.Type`\.
        
        :type componentType: System.Type
    
        
        :param arguments: 
            An :any:`System.Object` with properties representing arguments to be passed to the invoked view component
            method. Alternatively, an :any:`System.Collections.Generic.IDictionary\`2` instance
            containing the invocation arguments.
        
        :type arguments: System.Object
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns the rendered :any:`Microsoft.AspNetCore.Html.IHtmlContent`\.
            
    
        
        .. code-block:: csharp
    
            Task<IHtmlContent> InvokeAsync(Type componentType, object arguments)
    

