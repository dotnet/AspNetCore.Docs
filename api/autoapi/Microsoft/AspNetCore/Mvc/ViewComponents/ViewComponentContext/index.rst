

ViewComponentContext Class
==========================






A context for view components.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext`








Syntax
------

.. code-block:: csharp

    public class ViewComponentContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext.Arguments
    
        
    
        
        Gets or sets the view component arguments.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, object> Arguments
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext.HtmlEncoder
    
        
    
        
        Gets or sets the :any:`System.Text.Encodings.Web.HtmlEncoder`\.
    
        
        :rtype: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public HtmlEncoder HtmlEncoder
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext.ViewComponentDescriptor
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor` for the view component being invoked.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor
    
        
        .. code-block:: csharp
    
            public ViewComponentDescriptor ViewComponentDescriptor
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext.ViewContext
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            public ViewContext ViewContext
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext.ViewData
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
            public ViewDataDictionary ViewData
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext.Writer
    
        
    
        
        Gets the :any:`System.IO.TextWriter` for output.
    
        
        :rtype: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
            public TextWriter Writer
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext.ViewComponentContext()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext`\.
    
        
    
        
        .. code-block:: csharp
    
            public ViewComponentContext()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext.ViewComponentContext(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Text.Encodings.Web.HtmlEncoder, Microsoft.AspNetCore.Mvc.Rendering.ViewContext, System.IO.TextWriter)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext`\.
    
        
    
        
        :param viewComponentDescriptor: 
            The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext` for the view component being invoked.
        
        :type viewComponentDescriptor: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor
    
        
        :param arguments: The view component arguments.
        
        :type arguments: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        :param htmlEncoder: The :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext.HtmlEncoder` to use.
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        :param viewContext: The :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext.ViewContext`\.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :param writer: The :any:`System.IO.TextWriter` for writing output.
        
        :type writer: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
            public ViewComponentContext(ViewComponentDescriptor viewComponentDescriptor, IDictionary<string, object> arguments, HtmlEncoder htmlEncoder, ViewContext viewContext, TextWriter writer)
    

