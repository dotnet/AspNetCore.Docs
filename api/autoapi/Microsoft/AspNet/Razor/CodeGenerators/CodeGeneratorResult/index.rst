

CodeGeneratorResult Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorResult`








Syntax
------

.. code-block:: csharp

   public class CodeGeneratorResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/CodeGenerators/CodeGeneratorResult.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorResult.CodeGeneratorResult(System.String, System.Collections.Generic.IList<Microsoft.AspNet.Razor.CodeGenerators.LineMapping>)
    
        
        
        
        :type code: System.String
        
        
        :type designTimeLineMappings: System.Collections.Generic.IList{Microsoft.AspNet.Razor.CodeGenerators.LineMapping}
    
        
        .. code-block:: csharp
    
           public CodeGeneratorResult(string code, IList<LineMapping> designTimeLineMappings)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorResult.Code
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Code { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorResult.DesignTimeLineMappings
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Razor.CodeGenerators.LineMapping}
    
        
        .. code-block:: csharp
    
           public IList<LineMapping> DesignTimeLineMappings { get; }
    

