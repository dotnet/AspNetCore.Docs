

CodeGeneratorResult Class
=========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.CodeGenerators`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorResult`








Syntax
------

.. code-block:: csharp

    public class CodeGeneratorResult








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorResult.Code
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Code
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorResult.DesignTimeLineMappings
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping<Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping>}
    
        
        .. code-block:: csharp
    
            public IList<LineMapping> DesignTimeLineMappings
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorResult.CodeGeneratorResult(System.String, System.Collections.Generic.IList<Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping>)
    
        
    
        
        :type code: System.String
    
        
        :type designTimeLineMappings: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping<Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping>}
    
        
        .. code-block:: csharp
    
            public CodeGeneratorResult(string code, IList<LineMapping> designTimeLineMappings)
    

