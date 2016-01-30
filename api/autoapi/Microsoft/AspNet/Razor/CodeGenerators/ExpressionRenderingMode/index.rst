

ExpressionRenderingMode Enum
============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public enum ExpressionRenderingMode





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/CodeGenerators/ExpressionRenderingMode.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Razor.CodeGenerators.ExpressionRenderingMode

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Razor.CodeGenerators.ExpressionRenderingMode
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Razor.CodeGenerators.ExpressionRenderingMode.InjectCode
    
        
    
        Indicates that expressions should simply be placed as-is in the code, and the context in which
        the code exists will be used to render it
    
        
    
        
        .. code-block:: csharp
    
           InjectCode = 1
    
    .. dn:field:: Microsoft.AspNet.Razor.CodeGenerators.ExpressionRenderingMode.WriteToOutput
    
        
    
        Indicates that expressions should be written to the output stream
    
        
    
        
        .. code-block:: csharp
    
           WriteToOutput = 0
    

