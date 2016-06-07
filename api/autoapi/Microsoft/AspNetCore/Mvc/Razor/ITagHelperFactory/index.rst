

ITagHelperFactory Interface
===========================






Provides methods to create and initialize tag helpers.


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

    public interface ITagHelperFactory








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.ITagHelperFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.ITagHelperFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.ITagHelperFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.ITagHelperFactory.CreateTagHelper<TTagHelper>(Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        Creates a new tag helper for the specified <em>context</em>.
    
        
    
        
        :param context: :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` for the executing view.
        
        :type context: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
        :rtype: TTagHelper
        :return: The tag helper.
    
        
        .. code-block:: csharp
    
            TTagHelper CreateTagHelper<TTagHelper>(ViewContext context)where TTagHelper : ITagHelper
    

