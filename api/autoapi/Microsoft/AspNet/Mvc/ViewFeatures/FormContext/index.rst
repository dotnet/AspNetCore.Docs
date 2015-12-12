

FormContext Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.FormContext`








Syntax
------

.. code-block:: csharp

   public class FormContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/FormContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.FormContext

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.FormContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.FormContext.RenderedField(System.String)
    
        
        
        
        :type fieldName: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RenderedField(string fieldName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.FormContext.RenderedField(System.String, System.Boolean)
    
        
        
        
        :type fieldName: System.String
        
        
        :type value: System.Boolean
    
        
        .. code-block:: csharp
    
           public void RenderedField(string fieldName, bool value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.FormContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.FormContext.CanRenderAtEndOfForm
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool CanRenderAtEndOfForm { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.FormContext.EndOfFormContent
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Html.Abstractions.IHtmlContent}
    
        
        .. code-block:: csharp
    
           public IList<IHtmlContent> EndOfFormContent { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.FormContext.FormData
    
        
    
        Property bag for any information you wish to associate with a &lt;form/&gt; in an 
        :any:`Microsoft.AspNet.Mvc.Rendering.IHtmlHelper` implementation or extension method.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> FormData { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.FormContext.HasEndOfFormContent
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasEndOfFormContent { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.FormContext.HasFormData
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasFormData { get; }
    

