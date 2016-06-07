

LanguageViewLocationExpander Class
==================================






A :any:`Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander` that adds the language as an extension prefix to view names. Language
that is getting added as extension prefix comes from :any:`Microsoft.AspNetCore.Http.HttpContext`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpander`








Syntax
------

.. code-block:: csharp

    public class LanguageViewLocationExpander : IViewLocationExpander








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpander
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpander

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpander
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpander.LanguageViewLocationExpander()
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpander` instance.
    
        
    
        
        .. code-block:: csharp
    
            public LanguageViewLocationExpander()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpander.LanguageViewLocationExpander(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperActivator` instance.
    
        
    
        
        :param format: The :any:`Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat`\.
        
        :type format: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat
    
        
        .. code-block:: csharp
    
            public LanguageViewLocationExpander(LanguageViewLocationExpanderFormat format)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpander
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpander.ExpandViewLocations(Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext
    
        
        :type viewLocations: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpander.PopulateValues(Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext
    
        
        .. code-block:: csharp
    
            public void PopulateValues(ViewLocationExpanderContext context)
    

