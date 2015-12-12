

LanguageViewLocationExpander Class
==================================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Mvc.Razor.IViewLocationExpander` that adds the language as an extension prefix to view names. Language
that is getting added as extension prefix comes from :any:`Microsoft.AspNet.Http.HttpContext`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpander`








Syntax
------

.. code-block:: csharp

   public class LanguageViewLocationExpander : IViewLocationExpander





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/LanguageViewLocationExpander.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpander

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpander
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpander.LanguageViewLocationExpander()
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpander` instance.
    
        
    
        
        .. code-block:: csharp
    
           public LanguageViewLocationExpander()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpander.LanguageViewLocationExpander(Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpanderFormat)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Mvc.Razor.DefaultTagHelperActivator` instance.
    
        
        
        
        :param format: The .
        
        :type format: Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpanderFormat
    
        
        .. code-block:: csharp
    
           public LanguageViewLocationExpander(LanguageViewLocationExpanderFormat format)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpander
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpander.ExpandViewLocations(Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext, System.Collections.Generic.IEnumerable<System.String>)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext
        
        
        :type viewLocations: System.Collections.Generic.IEnumerable{System.String}
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.LanguageViewLocationExpander.PopulateValues(Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext
    
        
        .. code-block:: csharp
    
           public void PopulateValues(ViewLocationExpanderContext context)
    

