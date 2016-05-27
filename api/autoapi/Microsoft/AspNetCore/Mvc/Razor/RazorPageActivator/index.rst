

RazorPageActivator Class
========================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.RazorPageActivator`








Syntax
------

.. code-block:: csharp

    public class RazorPageActivator : IRazorPageActivator








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorPageActivator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorPageActivator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorPageActivator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.RazorPageActivator.RazorPageActivator(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPageActivator` class.
    
        
    
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
            public RazorPageActivator(IModelMetadataProvider metadataProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorPageActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorPageActivator.Activate(Microsoft.AspNetCore.Mvc.Razor.IRazorPage, Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        :type page: Microsoft.AspNetCore.Mvc.Razor.IRazorPage
    
        
        :type context: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            public void Activate(IRazorPage page, ViewContext context)
    

