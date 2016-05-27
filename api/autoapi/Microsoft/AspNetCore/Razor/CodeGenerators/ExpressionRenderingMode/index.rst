

ExpressionRenderingMode Enum
============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.CodeGenerators`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum ExpressionRenderingMode








.. dn:enumeration:: Microsoft.AspNetCore.Razor.CodeGenerators.ExpressionRenderingMode
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Razor.CodeGenerators.ExpressionRenderingMode

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Razor.CodeGenerators.ExpressionRenderingMode
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.CodeGenerators.ExpressionRenderingMode.InjectCode
    
        
    
        
        Indicates that expressions should simply be placed as-is in the code, and the context in which
        the code exists will be used to render it
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.ExpressionRenderingMode
    
        
        .. code-block:: csharp
    
            InjectCode = 1
    
    .. dn:field:: Microsoft.AspNetCore.Razor.CodeGenerators.ExpressionRenderingMode.WriteToOutput
    
        
    
        
        Indicates that expressions should be written to the output stream
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.ExpressionRenderingMode
    
        
        .. code-block:: csharp
    
            WriteToOutput = 0
    

