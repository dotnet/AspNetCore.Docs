

RazorPageActivator Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.RazorPageActivator`








Syntax
------

.. code-block:: csharp

   public class RazorPageActivator : IRazorPageActivator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/RazorPageActivator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorPageActivator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorPageActivator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.RazorPageActivator.RazorPageActivator(Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.Razor.RazorPageActivator` class.
    
        
        
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
           public RazorPageActivator(IModelMetadataProvider metadataProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorPageActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorPageActivator.Activate(Microsoft.AspNet.Mvc.Razor.IRazorPage, Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
        
        
        :type page: Microsoft.AspNet.Mvc.Razor.IRazorPage
        
        
        :type context: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public void Activate(IRazorPage page, ViewContext context)
    

