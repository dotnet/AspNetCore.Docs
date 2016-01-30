

ITagHelperInitializer<TTagHelper> Interface
===========================================



.. contents:: 
   :local:



Summary
-------

Initializes an :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` before it's executed.











Syntax
------

.. code-block:: csharp

   public interface ITagHelperInitializer<TTagHelper> where TTagHelper : ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/ITagHelperInitializerOfT.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.ITagHelperInitializer<TTagHelper>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.ITagHelperInitializer<TTagHelper>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.ITagHelperInitializer<TTagHelper>.Initialize(TTagHelper, Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
    
        Initializes the ``TTagHelper``.
    
        
        
        
        :param helper: The  to initialize.
        
        :type helper: {TTagHelper}
        
        
        :param context: The  for the executing view.
        
        :type context: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           void Initialize(TTagHelper helper, ViewContext context)
    

