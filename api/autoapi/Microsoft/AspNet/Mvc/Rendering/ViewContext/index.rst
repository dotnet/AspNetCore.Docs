

ViewContext Class
=================



.. contents:: 
   :local:



Summary
-------

Context for view execution.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.ViewContext`








Syntax
------

.. code-block:: csharp

   public class ViewContext : ActionContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/ViewContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.ViewContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.ViewContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.ViewContext.ViewContext()
    
        
    
        Creates an empty :any:`Microsoft.AspNet.Mvc.Rendering.ViewContext`\.
    
        
    
        
        .. code-block:: csharp
    
           public ViewContext()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.ViewContext.ViewContext(Microsoft.AspNet.Mvc.ActionContext, Microsoft.AspNet.Mvc.ViewEngines.IView, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary, Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary, System.IO.TextWriter, Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelperOptions)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Rendering.ViewContext`\.
    
        
        
        
        :param actionContext: The .
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param view: The  being rendered.
        
        :type view: Microsoft.AspNet.Mvc.ViewEngines.IView
        
        
        :param viewData: The .
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        
        
        :param tempData: The .
        
        :type tempData: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary
        
        
        :param writer: The  to render output to.
        
        :type writer: System.IO.TextWriter
        
        
        :type htmlHelperOptions: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelperOptions
    
        
        .. code-block:: csharp
    
           public ViewContext(ActionContext actionContext, IView view, ViewDataDictionary viewData, ITempDataDictionary tempData, TextWriter writer, HtmlHelperOptions htmlHelperOptions)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.ViewContext.ViewContext(Microsoft.AspNet.Mvc.Rendering.ViewContext, Microsoft.AspNet.Mvc.ViewEngines.IView, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary, System.IO.TextWriter)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Rendering.ViewContext`\.
    
        
        
        
        :param viewContext: The  to copy values from.
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :param view: The  being rendered.
        
        :type view: Microsoft.AspNet.Mvc.ViewEngines.IView
        
        
        :param viewData: The .
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        
        
        :param writer: The  to render output to.
        
        :type writer: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public ViewContext(ViewContext viewContext, IView view, ViewDataDictionary viewData, TextWriter writer)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.ViewContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.ViewContext.GetFormContextForClientValidation()
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.FormContext
    
        
        .. code-block:: csharp
    
           public FormContext GetFormContextForClientValidation()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.ViewContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ViewContext.ClientValidationEnabled
    
        
    
        Gets or sets a value that indicates whether client-side validation is enabled.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ClientValidationEnabled { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ViewContext.ExecutingFilePath
    
        
    
        Gets or sets the path of the view file currently being rendered.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ExecutingFilePath { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ViewContext.FormContext
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Mvc.Rendering.ViewContext.FormContext` for the form element being rendered.
        A default context is returned if no form is currently being rendered.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.FormContext
    
        
        .. code-block:: csharp
    
           public virtual FormContext FormContext { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ViewContext.Html5DateRenderingMode
    
        
    
        Set this property to :dn:field:`Microsoft.AspNet.Mvc.Rendering.Html5DateRenderingMode.Rfc3339` to have templated helpers such as 
        :dn:meth:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.Editor(System.String,System.String,System.String,System.Object)` and :dn:meth:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper\`1.EditorFor\`\`1(System.Linq.Expressions.Expression{System.Func{\`0,\`\`0}},System.String,System.String,System.Object)` render date and time
        values as RFC 3339 compliant strings. By default these helpers render dates and times using the current
        culture.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.Html5DateRenderingMode
    
        
        .. code-block:: csharp
    
           public Html5DateRenderingMode Html5DateRenderingMode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ViewContext.TempData
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary` instance.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
           public ITempDataDictionary TempData { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ViewContext.ValidationMessageElement
    
        
    
        Element name used to wrap a top-level message generated by :dn:meth:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.ValidationMessage(System.String,System.String,System.Object,System.String)` and
        other overloads.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ValidationMessageElement { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ViewContext.ValidationSummaryMessageElement
    
        
    
        Element name used to wrap a top-level message generated by :dn:meth:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper.ValidationSummary(System.Boolean,System.String,System.Object,System.String)` and
        other overloads.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ValidationSummaryMessageElement { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ViewContext.View
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ViewEngines.IView` currently being rendered, if any.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.IView
    
        
        .. code-block:: csharp
    
           public IView View { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ViewContext.ViewBag
    
        
    
        Gets the dynamic view bag.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public dynamic ViewBag { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ViewContext.ViewData
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary ViewData { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ViewContext.Writer
    
        
    
        Gets or sets the :any:`System.IO.TextWriter` used to write the output.
    
        
        :rtype: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public TextWriter Writer { get; set; }
    

