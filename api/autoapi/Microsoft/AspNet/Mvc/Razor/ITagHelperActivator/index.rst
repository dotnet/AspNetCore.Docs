

ITagHelperActivator Interface
=============================



.. contents:: 
   :local:



Summary
-------

Provides methods to activate properties on a :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` instance.











Syntax
------

.. code-block:: csharp

   public interface ITagHelperActivator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/ITagHelperActivator.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.ITagHelperActivator

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.ITagHelperActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.ITagHelperActivator.Activate<TTagHelper>(TTagHelper, Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
    
        When implemented in a type, activates an instantiated :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\.
    
        
        
        
        :param tagHelper: The  to activate.
        
        :type tagHelper: {TTagHelper}
        
        
        :param context: The  for the executing view.
        
        :type context: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           void Activate<TTagHelper>(TTagHelper tagHelper, ViewContext context)where TTagHelper : ITagHelper
    

