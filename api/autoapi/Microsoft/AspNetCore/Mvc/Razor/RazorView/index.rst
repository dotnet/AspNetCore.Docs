

RazorView Class
===============






Default implementation for :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IView` that executes one or more :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage`
as parts of its execution.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.RazorView`








Syntax
------

.. code-block:: csharp

    public class RazorView : IView








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorView
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorView

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorView
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorView.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Path
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorView.RazorPage
    
        
    
        
        Gets :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` instance that the views executes on.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Razor.IRazorPage
    
        
        .. code-block:: csharp
    
            public IRazorPage RazorPage
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorView.ViewStartPages
    
        
    
        
        Gets the sequence of _ViewStart :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` instances that are executed by this view.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Razor.IRazorPage<Microsoft.AspNetCore.Mvc.Razor.IRazorPage>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<IRazorPage> ViewStartPages
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorView
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.RazorView.RazorView(Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine, Microsoft.AspNetCore.Mvc.Razor.IRazorPageActivator, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.Razor.IRazorPage>, Microsoft.AspNetCore.Mvc.Razor.IRazorPage, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.RazorView`
    
        
    
        
        :param viewEngine: The :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine` used to locate Layout pages.
        
        :type viewEngine: Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine
    
        
        :param pageActivator: The :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPageActivator` used to activate pages.
        
        :type pageActivator: Microsoft.AspNetCore.Mvc.Razor.IRazorPageActivator
    
        
        :param viewStartPages: The sequence of :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` instances executed as _ViewStarts.
            
        
        :type viewStartPages: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Razor.IRazorPage<Microsoft.AspNetCore.Mvc.Razor.IRazorPage>}
    
        
        :param razorPage: The :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` instance to execute.
        
        :type razorPage: Microsoft.AspNetCore.Mvc.Razor.IRazorPage
    
        
        :param htmlEncoder: The HTML encoder.
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public RazorView(IRazorViewEngine viewEngine, IRazorPageActivator pageActivator, IReadOnlyList<IRazorPage> viewStartPages, IRazorPage razorPage, HtmlEncoder htmlEncoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorView
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorView.RenderAsync(Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task RenderAsync(ViewContext context)
    

