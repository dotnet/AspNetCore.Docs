

GeneratedClassContext Struct
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

    public struct GeneratedClassContext








.. dn:structure:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.AllowSections
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool AllowSections
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.AllowTemplates
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool AllowTemplates
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.BeginContextMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string BeginContextMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.BeginWriteAttributeMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string BeginWriteAttributeMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.BeginWriteAttributeToMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string BeginWriteAttributeToMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.DefineSectionMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string DefineSectionMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.EndContextMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string EndContextMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.EndWriteAttributeMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string EndWriteAttributeMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.EndWriteAttributeToMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string EndWriteAttributeToMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.ExecuteMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ExecuteMethodName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.GeneratedTagHelperContext
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext
    
        
        .. code-block:: csharp
    
            public GeneratedTagHelperContext GeneratedTagHelperContext
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.SupportsInstrumentation
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool SupportsInstrumentation
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.TemplateTypeName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TemplateTypeName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.WriteAttributeValueMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string WriteAttributeValueMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.WriteAttributeValueToMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string WriteAttributeValueToMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.WriteLiteralMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string WriteLiteralMethodName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.WriteLiteralToMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string WriteLiteralToMethodName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.WriteMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string WriteMethodName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.WriteToMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string WriteToMethodName
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.GeneratedClassContext(System.String, System.String, System.String, Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext)
    
        
    
        
        :type executeMethodName: System.String
    
        
        :type writeMethodName: System.String
    
        
        :type writeLiteralMethodName: System.String
    
        
        :type generatedTagHelperContext: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext
    
        
        .. code-block:: csharp
    
            public GeneratedClassContext(string executeMethodName, string writeMethodName, string writeLiteralMethodName, GeneratedTagHelperContext generatedTagHelperContext)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.GeneratedClassContext(System.String, System.String, System.String, System.String, System.String, System.String, Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext)
    
        
    
        
        :type executeMethodName: System.String
    
        
        :type writeMethodName: System.String
    
        
        :type writeLiteralMethodName: System.String
    
        
        :type writeToMethodName: System.String
    
        
        :type writeLiteralToMethodName: System.String
    
        
        :type templateTypeName: System.String
    
        
        :type generatedTagHelperContext: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext
    
        
        .. code-block:: csharp
    
            public GeneratedClassContext(string executeMethodName, string writeMethodName, string writeLiteralMethodName, string writeToMethodName, string writeLiteralToMethodName, string templateTypeName, GeneratedTagHelperContext generatedTagHelperContext)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.GeneratedClassContext(System.String, System.String, System.String, System.String, System.String, System.String, System.String, Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext)
    
        
    
        
        :type executeMethodName: System.String
    
        
        :type writeMethodName: System.String
    
        
        :type writeLiteralMethodName: System.String
    
        
        :type writeToMethodName: System.String
    
        
        :type writeLiteralToMethodName: System.String
    
        
        :type templateTypeName: System.String
    
        
        :type defineSectionMethodName: System.String
    
        
        :type generatedTagHelperContext: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext
    
        
        .. code-block:: csharp
    
            public GeneratedClassContext(string executeMethodName, string writeMethodName, string writeLiteralMethodName, string writeToMethodName, string writeLiteralToMethodName, string templateTypeName, string defineSectionMethodName, GeneratedTagHelperContext generatedTagHelperContext)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.GeneratedClassContext(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String, Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext)
    
        
    
        
        :type executeMethodName: System.String
    
        
        :type writeMethodName: System.String
    
        
        :type writeLiteralMethodName: System.String
    
        
        :type writeToMethodName: System.String
    
        
        :type writeLiteralToMethodName: System.String
    
        
        :type templateTypeName: System.String
    
        
        :type defineSectionMethodName: System.String
    
        
        :type beginContextMethodName: System.String
    
        
        :type endContextMethodName: System.String
    
        
        :type generatedTagHelperContext: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext
    
        
        .. code-block:: csharp
    
            public GeneratedClassContext(string executeMethodName, string writeMethodName, string writeLiteralMethodName, string writeToMethodName, string writeLiteralToMethodName, string templateTypeName, string defineSectionMethodName, string beginContextMethodName, string endContextMethodName, GeneratedTagHelperContext generatedTagHelperContext)
    

Fields
------

.. dn:structure:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.Default
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext
    
        
        .. code-block:: csharp
    
            public static readonly GeneratedClassContext Default
    
    .. dn:field:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.DefaultBeginWriteAttributeMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultBeginWriteAttributeMethodName
    
    .. dn:field:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.DefaultBeginWriteAttributeToMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultBeginWriteAttributeToMethodName
    
    .. dn:field:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.DefaultEndWriteAttributeMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultEndWriteAttributeMethodName
    
    .. dn:field:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.DefaultEndWriteAttributeToMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultEndWriteAttributeToMethodName
    
    .. dn:field:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.DefaultExecuteMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultExecuteMethodName
    
    .. dn:field:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.DefaultWriteAttributeValueMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultWriteAttributeValueMethodName
    
    .. dn:field:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.DefaultWriteAttributeValueToMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultWriteAttributeValueToMethodName
    
    .. dn:field:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.DefaultWriteLiteralMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultWriteLiteralMethodName
    
    .. dn:field:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.DefaultWriteMethodName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultWriteMethodName
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    

