

RazorView Class
===============



.. contents:: 
   :local:



Summary
-------

Default implementation for :any:`Microsoft.AspNet.Mvc.ViewEngines.IView` that executes one or more :any:`Microsoft.AspNet.Mvc.Razor.IRazorPage`
as parts of its exeuction.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.RazorView`








Syntax
------

.. code-block:: csharp

   public class RazorView : IView





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/RazorView.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorView

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorView
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.RazorView.RazorView(Microsoft.AspNet.Mvc.Razor.IRazorViewEngine, Microsoft.AspNet.Mvc.Razor.IRazorPageActivator, Microsoft.AspNet.Mvc.Razor.IViewStartProvider, Microsoft.AspNet.Mvc.Razor.IRazorPage, Microsoft.Extensions.WebEncoders.IHtmlEncoder, System.Boolean)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.RazorView`
    
        
        
        
        :param viewEngine: The  used to locate Layout pages.
        
        :type viewEngine: Microsoft.AspNet.Mvc.Razor.IRazorViewEngine
        
        
        :param pageActivator: The  used to activate pages.
        
        :type pageActivator: Microsoft.AspNet.Mvc.Razor.IRazorPageActivator
        
        
        :param viewStartProvider: The  used for discovery of _ViewStart
            The  instance to execute.The HTML encoder.Determines if the view is to be executed as a partial.
            pages
        
        :type viewStartProvider: Microsoft.AspNet.Mvc.Razor.IViewStartProvider
        
        
        :type razorPage: Microsoft.AspNet.Mvc.Razor.IRazorPage
        
        
        :type htmlEncoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
        
        
        :type isPartial: System.Boolean
    
        
        .. code-block:: csharp
    
           public RazorView(IRazorViewEngine viewEngine, IRazorPageActivator pageActivator, IViewStartProvider viewStartProvider, IRazorPage razorPage, IHtmlEncoder htmlEncoder, bool isPartial)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorView
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorView.RenderAsync(Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Rendering.ViewContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task RenderAsync(ViewContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorView
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorView.IsPartial
    
        
    
        Gets a value that determines if the view is executed as a partial.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsPartial { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorView.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Path { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorView.RazorPage
    
        
    
        Gets :any:`Microsoft.AspNet.Mvc.Razor.IRazorPage` instance that the views executes on.
    
        
        :rtype: Microsoft.AspNet.Mvc.Razor.IRazorPage
    
        
        .. code-block:: csharp
    
           public IRazorPage RazorPage { get; }
    

