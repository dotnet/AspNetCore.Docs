

NestedScope Struct
==================






Return value of :dn:meth:`EnterNestedScope`\. Should be disposed
by caller when child binding context state should be popped off of 
the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct NestedScope : IDisposable








.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.NestedScope
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.NestedScope

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.NestedScope
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.NestedScope.NestedScope(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        
        Initializes the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.NestedScope` for a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext`\.
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
    
        
        .. code-block:: csharp
    
            public NestedScope(ModelBindingContext context)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.NestedScope
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.NestedScope.Dispose()
    
        
    
        
        Exits the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.NestedScope` created by calling :dn:meth:`EnterNestedScope`\.
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    

