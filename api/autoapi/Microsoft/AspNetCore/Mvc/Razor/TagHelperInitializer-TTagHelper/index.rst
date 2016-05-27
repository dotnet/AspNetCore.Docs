

TagHelperInitializer<TTagHelper> Class
======================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.TagHelperInitializer\<TTagHelper>`








Syntax
------

.. code-block:: csharp

    public class TagHelperInitializer<TTagHelper> : ITagHelperInitializer<TTagHelper> where TTagHelper : ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelperInitializer`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelperInitializer<TTagHelper>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelperInitializer<TTagHelper>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.TagHelperInitializer<TTagHelper>.TagHelperInitializer(System.Action<TTagHelper, Microsoft.AspNetCore.Mvc.Rendering.ViewContext>)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.Razor.TagHelperInitializer\`1`\.
    
        
    
        
        :param action: The initialization delegate.
        
        :type action: System.Action<System.Action`2>{TTagHelper, Microsoft.AspNetCore.Mvc.Rendering.ViewContext<Microsoft.AspNetCore.Mvc.Rendering.ViewContext>}
    
        
        .. code-block:: csharp
    
            public TagHelperInitializer(Action<TTagHelper, ViewContext> action)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelperInitializer<TTagHelper>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.TagHelperInitializer<TTagHelper>.Initialize(TTagHelper, Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        :type helper: TTagHelper
    
        
        :type context: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            public void Initialize(TTagHelper helper, ViewContext context)
    

