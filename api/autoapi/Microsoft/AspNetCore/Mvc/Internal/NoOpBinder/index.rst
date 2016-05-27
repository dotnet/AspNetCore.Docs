

NoOpBinder Class
================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.NoOpBinder`








Syntax
------

.. code-block:: csharp

    public class NoOpBinder : IModelBinder








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.NoOpBinder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.NoOpBinder

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.NoOpBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NoOpBinder.BindModelAsync(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        
        :type bindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task BindModelAsync(ModelBindingContext bindingContext)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.NoOpBinder
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Internal.NoOpBinder.Instance
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
    
        
        .. code-block:: csharp
    
            public static readonly IModelBinder Instance
    

