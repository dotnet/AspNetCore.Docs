

CSharpCodeWritingScope Struct
=============================





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

    public struct CSharpCodeWritingScope : IDisposable








.. dn:structure:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope.CSharpCodeWritingScope(Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope(CodeWriter writer)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope.CSharpCodeWritingScope(Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter, System.Boolean)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    
        
        :type autoSpace: System.Boolean
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope(CodeWriter writer, bool autoSpace)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope.CSharpCodeWritingScope(Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter, System.Int32)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    
        
        :type tabSize: System.Int32
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope(CodeWriter writer, int tabSize)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope.CSharpCodeWritingScope(Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter, System.Int32, System.Boolean)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    
        
        :type tabSize: System.Int32
    
        
        :type autoSpace: System.Boolean
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope(CodeWriter writer, int tabSize, bool autoSpace)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    

Fields
------

.. dn:structure:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope.OnClose
    
        
        :rtype: System.Action
    
        
        .. code-block:: csharp
    
            public Action OnClose
    

