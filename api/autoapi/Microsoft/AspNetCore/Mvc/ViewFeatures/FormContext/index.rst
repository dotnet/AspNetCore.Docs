

FormContext Class
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext`








Syntax
------

.. code-block:: csharp

    public class FormContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext.CanRenderAtEndOfForm
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool CanRenderAtEndOfForm
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext.EndOfFormContent
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Html.IHtmlContent<Microsoft.AspNetCore.Html.IHtmlContent>}
    
        
        .. code-block:: csharp
    
            public IList<IHtmlContent> EndOfFormContent
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext.FormData
    
        
    
        
        Property bag for any information you wish to associate with a <form/> in an
        :any:`Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` implementation or extension method.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, object> FormData
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext.HasAntiforgeryToken
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasAntiforgeryToken
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext.HasEndOfFormContent
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasEndOfFormContent
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext.HasFormData
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasFormData
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext.RenderedField(System.String)
    
        
    
        
        :type fieldName: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool RenderedField(string fieldName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext.RenderedField(System.String, System.Boolean)
    
        
    
        
        :type fieldName: System.String
    
        
        :type value: System.Boolean
    
        
        .. code-block:: csharp
    
            public void RenderedField(string fieldName, bool value)
    

