

ValidationSummary Enum
======================



.. contents:: 
   :local:



Summary
-------

Acceptable validation summary rendering modes.











Syntax
------

.. code-block:: csharp

   public enum ValidationSummary





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/Rendering/ValidationSummary.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Mvc.Rendering.ValidationSummary

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Mvc.Rendering.ValidationSummary
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.Rendering.ValidationSummary.All
    
        
    
        Validation summary with all errors.
    
        
    
        
        .. code-block:: csharp
    
           All = 2
    
    .. dn:field:: Microsoft.AspNet.Mvc.Rendering.ValidationSummary.ModelOnly
    
        
    
        Validation summary with model-level errors only (excludes all property errors).
    
        
    
        
        .. code-block:: csharp
    
           ModelOnly = 1
    
    .. dn:field:: Microsoft.AspNet.Mvc.Rendering.ValidationSummary.None
    
        
    
        No validation summary.
    
        
    
        
        .. code-block:: csharp
    
           None = 0
    

