

ViewContext Class
=================






Context for view execution.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Rendering`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionContext`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext`








Syntax
------

.. code-block:: csharp

    public class ViewContext : ActionContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ViewContext()
    
        
    
        
        Creates an empty :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext`\.
    
        
    
        
        .. code-block:: csharp
    
            public ViewContext()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ViewContext(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.ViewEngines.IView, Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary, Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary, System.IO.TextWriter, Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelperOptions)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext`\.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param view: The :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IView` being rendered.
        
        :type view: Microsoft.AspNetCore.Mvc.ViewEngines.IView
    
        
        :param viewData: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`\.
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        :param tempData: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary`\.
        
        :type tempData: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary
    
        
        :param writer: The :any:`System.IO.TextWriter` to render output to.
        
        :type writer: System.IO.TextWriter
    
        
        :param htmlHelperOptions: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelperOptions` to apply to this instance.
        
        :type htmlHelperOptions: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelperOptions
    
        
        .. code-block:: csharp
    
            public ViewContext(ActionContext actionContext, IView view, ViewDataDictionary viewData, ITempDataDictionary tempData, TextWriter writer, HtmlHelperOptions htmlHelperOptions)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ViewContext(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, Microsoft.AspNetCore.Mvc.ViewEngines.IView, Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary, System.IO.TextWriter)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext`\.
    
        
    
        
        :param viewContext: The :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` to copy values from.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :param view: The :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IView` being rendered.
        
        :type view: Microsoft.AspNetCore.Mvc.ViewEngines.IView
    
        
        :param viewData: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`\.
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        :param writer: The :any:`System.IO.TextWriter` to render output to.
        
        :type writer: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
            public ViewContext(ViewContext viewContext, IView view, ViewDataDictionary viewData, TextWriter writer)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ClientValidationEnabled
    
        
    
        
        Gets or sets a value that indicates whether client-side validation is enabled.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ClientValidationEnabled { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ExecutingFilePath
    
        
    
        
        Gets or sets the path of the view file currently being rendered.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ExecutingFilePath { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.FormContext
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext.FormContext` for the form element being rendered.
        A default context is returned if no form is currently being rendered.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext
    
        
        .. code-block:: csharp
    
            public virtual FormContext FormContext { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.Html5DateRenderingMode
    
        
    
        
        Set this property to :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.Html5DateRenderingMode.Rfc3339` to have templated helpers such as 
        :dn:meth:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.Editor(System.String,System.String,System.String,System.Object)` and :dn:meth:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper\`1.EditorFor\`\`1(System.Linq.Expressions.Expression{System.Func{\`0,\`\`0}},System.String,System.String,System.Object)` render date and time
        values as RFC 3339 compliant strings. By default these helpers render dates and times using the current
        culture.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.Html5DateRenderingMode
    
        
        .. code-block:: csharp
    
            public Html5DateRenderingMode Html5DateRenderingMode { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.TempData
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary` instance.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
            public ITempDataDictionary TempData { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationMessageElement
    
        
    
        
        Element name used to wrap a top-level message generated by :dn:meth:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.ValidationMessage(System.String,System.String,System.Object,System.String)` and
        other overloads.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ValidationMessageElement { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ValidationSummaryMessageElement
    
        
    
        
        Element name used to wrap a top-level message generated by :dn:meth:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.ValidationSummary(System.Boolean,System.String,System.Object,System.String)` and
        other overloads.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ValidationSummaryMessageElement { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.View
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IView` currently being rendered, if any.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.IView
    
        
        .. code-block:: csharp
    
            public IView View { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ViewBag
    
        
    
        
        Gets the dynamic view bag.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public dynamic ViewBag { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.ViewData
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
            public ViewDataDictionary ViewData { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.Writer
    
        
    
        
        Gets or sets the :any:`System.IO.TextWriter` used to write the output.
    
        
        :rtype: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
            public TextWriter Writer { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.ViewContext.GetFormContextForClientValidation()
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext
    
        
        .. code-block:: csharp
    
            public FormContext GetFormContextForClientValidation()
    

