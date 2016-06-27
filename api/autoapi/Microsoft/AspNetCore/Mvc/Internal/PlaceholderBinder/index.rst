

PlaceholderBinder Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.PlaceholderBinder`








Syntax
------

.. code-block:: csharp

    public class PlaceholderBinder : IModelBinder








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.PlaceholderBinder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.PlaceholderBinder

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.PlaceholderBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.PlaceholderBinder.BindModelAsync(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        
        :type bindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task BindModelAsync(ModelBindingContext bindingContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.PlaceholderBinder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.PlaceholderBinder.Inner
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
    
        
        .. code-block:: csharp
    
            public IModelBinder Inner { get; set; }
    

