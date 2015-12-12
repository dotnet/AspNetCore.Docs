

CSharpCodeWritingScope Struct
=============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public struct CSharpCodeWritingScope : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/CodeGenerators/CSharpCodeWritingScope.cs>`_





.. dn:structure:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWritingScope

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWritingScope
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWritingScope.CSharpCodeWritingScope(Microsoft.AspNet.Razor.CodeGenerators.CodeWriter)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
           public CSharpCodeWritingScope(CodeWriter writer)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWritingScope.CSharpCodeWritingScope(Microsoft.AspNet.Razor.CodeGenerators.CodeWriter, System.Boolean)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
        
        
        :type autoSpace: System.Boolean
    
        
        .. code-block:: csharp
    
           public CSharpCodeWritingScope(CodeWriter writer, bool autoSpace)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWritingScope.CSharpCodeWritingScope(Microsoft.AspNet.Razor.CodeGenerators.CodeWriter, System.Int32)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
        
        
        :type tabSize: System.Int32
    
        
        .. code-block:: csharp
    
           public CSharpCodeWritingScope(CodeWriter writer, int tabSize)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWritingScope.CSharpCodeWritingScope(Microsoft.AspNet.Razor.CodeGenerators.CodeWriter, System.Int32, System.Boolean)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
        
        
        :type tabSize: System.Int32
        
        
        :type autoSpace: System.Boolean
    
        
        .. code-block:: csharp
    
           public CSharpCodeWritingScope(CodeWriter writer, int tabSize, bool autoSpace)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWritingScope
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWritingScope.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    

Fields
------

.. dn:structure:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWritingScope
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWritingScope.OnClose
    
        
    
        
        .. code-block:: csharp
    
           public Action OnClose
    

