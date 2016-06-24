

BindingBehavior Enum
====================






Enumerates behavior options of the model binding system.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum BindingBehavior








.. dn:enumeration:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehavior
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehavior

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehavior
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehavior.Never
    
        
    
        
        The property should be excluded from model binding.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehavior
    
        
        .. code-block:: csharp
    
            Never = 1
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehavior.Optional
    
        
    
        
        The property should be model bound if a value is available from the value provider.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehavior
    
        
        .. code-block:: csharp
    
            Optional = 0
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehavior.Required
    
        
    
        
        The property is required for model binding.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehavior
    
        
        .. code-block:: csharp
    
            Required = 2
    

