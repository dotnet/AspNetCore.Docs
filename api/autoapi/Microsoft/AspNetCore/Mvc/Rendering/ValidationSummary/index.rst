

ValidationSummary Enum
======================






Acceptable validation summary rendering modes.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Rendering`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum ValidationSummary








.. dn:enumeration:: Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All
    
        
    
        
        Validation summary with all errors.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary
    
        
        .. code-block:: csharp
    
            All = 2
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly
    
        
    
        
        Validation summary with model-level errors only (excludes all property errors).
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary
    
        
        .. code-block:: csharp
    
            ModelOnly = 1
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.None
    
        
    
        
        No validation summary.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary
    
        
        .. code-block:: csharp
    
            None = 0
    

