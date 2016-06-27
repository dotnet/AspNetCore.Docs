

IRazorPage Interface
====================






Represents properties and methods that are used by :any:`Microsoft.AspNetCore.Mvc.Razor.RazorView` for execution.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IRazorPage








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IRazorPage
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IRazorPage

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IRazorPage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.IRazorPage.BodyContent
    
        
    
        
        Gets or sets the body content.
    
        
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            IHtmlContent BodyContent { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.IRazorPage.IsLayoutBeingRendered
    
        
    
        
        Gets or sets a flag that determines if the layout of this page is being rendered.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IsLayoutBeingRendered { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.IRazorPage.Layout
    
        
    
        
        Gets or sets the path of a layout page.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Layout { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.IRazorPage.Path
    
        
    
        
        Gets the application base relative path to the page.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Path { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.IRazorPage.PreviousSectionWriters
    
        
    
        
        Gets or sets the sections that can be rendered by this page.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Mvc.Razor.RenderAsyncDelegate<Microsoft.AspNetCore.Mvc.Razor.RenderAsyncDelegate>}
    
        
        .. code-block:: csharp
    
            IDictionary<string, RenderAsyncDelegate> PreviousSectionWriters { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.IRazorPage.SectionWriters
    
        
    
        
        Gets the sections that are defined by this page.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Mvc.Razor.RenderAsyncDelegate<Microsoft.AspNetCore.Mvc.Razor.RenderAsyncDelegate>}
    
        
        .. code-block:: csharp
    
            IDictionary<string, RenderAsyncDelegate> SectionWriters { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.IRazorPage.ViewContext
    
        
    
        
        Gets or sets the view context of the renderign view.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            ViewContext ViewContext { get; set; }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IRazorPage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.IRazorPage.EnsureRenderedBodyOrSections()
    
        
    
        
        Verifies that all sections defined in :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage.PreviousSectionWriters` were rendered, or
        the body was rendered if no sections were defined.
    
        
    
        
        .. code-block:: csharp
    
            void EnsureRenderedBodyOrSections()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.IRazorPage.ExecuteAsync()
    
        
    
        
        Renders the page and writes the output to the :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.Writer`\.
    
        
        :rtype: System.Threading.Tasks.Task
        :return: A task representing the result of executing the page.
    
        
        .. code-block:: csharp
    
            Task ExecuteAsync()
    

