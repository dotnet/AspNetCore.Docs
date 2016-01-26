

ViewComponentContext Class
==========================



.. contents:: 
   :local:



Summary
-------

A context for View Components.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext`








Syntax
------

.. code-block:: csharp

   public class ViewComponentContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/ViewComponentContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext.ViewComponentContext()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext`\.
    
        
    
        
        .. code-block:: csharp
    
           public ViewComponentContext()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext.ViewComponentContext(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor, System.Object[], Microsoft.AspNet.Mvc.Rendering.ViewContext, System.IO.TextWriter)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext`\.
    
        
        
        
        :param viewComponentDescriptor: The  for the View Component being invoked.
        
        :type viewComponentDescriptor: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor
        
        
        :param arguments: The View Component arguments.
        
        :type arguments: System.Object[]
        
        
        :param viewContext: The .
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
        
        
        :param writer: The  for writing output.
        
        :type writer: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public ViewComponentContext(ViewComponentDescriptor viewComponentDescriptor, object[] arguments, ViewContext viewContext, TextWriter writer)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext.Arguments
    
        
    
        Gets or sets the View Component arguments.
    
        
        :rtype: System.Object[]
    
        
        .. code-block:: csharp
    
           public object[] Arguments { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext.ViewComponentDescriptor
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext.ViewComponentDescriptor` for the View Component being invoked.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor
    
        
        .. code-block:: csharp
    
           public ViewComponentDescriptor ViewComponentDescriptor { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext.ViewContext
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext.ViewContext`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public ViewContext ViewContext { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext.ViewData
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary ViewData { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext.Writer
    
        
    
        Gets the :any:`System.IO.TextWriter` for output.
    
        
        :rtype: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public TextWriter Writer { get; }
    

