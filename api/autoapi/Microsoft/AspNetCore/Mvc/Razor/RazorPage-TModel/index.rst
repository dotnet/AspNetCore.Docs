

RazorPage<TModel> Class
=======================






Represents the properties and methods that are needed in order to render a view that uses Razor syntax.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.RazorPage`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.RazorPage\<TModel>`








Syntax
------

.. code-block:: csharp

    public abstract class RazorPage<TModel> : RazorPage, IRazorPage








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorPage`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel>.Model
    
        
    
        
        Gets the Model property of the :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.RazorPage\`1.ViewData` property.
    
        
        :rtype: TModel
    
        
        .. code-block:: csharp
    
            public TModel Model { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel>.ViewData
    
        
    
        
        Gets or sets the dictionary for view data.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`1>{TModel}
    
        
        .. code-block:: csharp
    
            public ViewDataDictionary<TModel> ViewData { get; set; }
    

