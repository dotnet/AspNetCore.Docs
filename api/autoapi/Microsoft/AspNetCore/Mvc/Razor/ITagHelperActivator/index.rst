

ITagHelperActivator Interface
=============================






Provides methods to create a tag helper.


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

    public interface ITagHelperActivator








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.ITagHelperActivator
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.ITagHelperActivator

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.ITagHelperActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.ITagHelperActivator.Create<TTagHelper>(Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` for the executing view.
        
        :type context: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
        :rtype: TTagHelper
        :return: The tag helper.
    
        
        .. code-block:: csharp
    
            TTagHelper Create<TTagHelper>(ViewContext context)where TTagHelper : ITagHelper
    

