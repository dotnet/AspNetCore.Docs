

ITagHelperInitializer<TTagHelper> Interface
===========================================






Initializes an :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` before it's executed.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ITagHelperInitializer<TTagHelper>
        where TTagHelper : ITagHelper








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.ITagHelperInitializer`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.ITagHelperInitializer<TTagHelper>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.ITagHelperInitializer<TTagHelper>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.ITagHelperInitializer<TTagHelper>.Initialize(TTagHelper, Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        Initializes the <em>TTagHelper</em>.
    
        
    
        
        :param helper: The <em>TTagHelper</em> to initialize.
        
        :type helper: TTagHelper
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` for the executing view.
        
        :type context: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            void Initialize(TTagHelper helper, ViewContext context)
    

