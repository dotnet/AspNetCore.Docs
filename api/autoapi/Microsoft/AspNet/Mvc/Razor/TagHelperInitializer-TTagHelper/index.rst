

TagHelperInitializer<TTagHelper> Class
======================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.TagHelperInitializer\<TTagHelper>`








Syntax
------

.. code-block:: csharp

   public class TagHelperInitializer<TTagHelper> : ITagHelperInitializer<TTagHelper> where TTagHelper : ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/TagHelperInitializerOfT.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.TagHelperInitializer<TTagHelper>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.TagHelperInitializer<TTagHelper>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.TagHelperInitializer<TTagHelper>.TagHelperInitializer(System.Action<TTagHelper, Microsoft.AspNet.Mvc.Rendering.ViewContext>)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.Razor.TagHelperInitializer\`1`\.
    
        
        
        
        :param action: The initialization delegate.
        
        :type action: System.Action{{TTagHelper},Microsoft.AspNet.Mvc.Rendering.ViewContext}
    
        
        .. code-block:: csharp
    
           public TagHelperInitializer(Action<TTagHelper, ViewContext> action)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.TagHelperInitializer<TTagHelper>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.TagHelperInitializer<TTagHelper>.Initialize(TTagHelper, Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
        
        
        :type helper: {TTagHelper}
        
        
        :type context: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public void Initialize(TTagHelper helper, ViewContext context)
    

