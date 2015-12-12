

PrecompilationTagHelperTypeResolver Class
=========================================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperTypeResolver` used during Razor precompilation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperTypeResolver`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.Precompilation.PrecompilationTagHelperTypeResolver`








Syntax
------

.. code-block:: csharp

   public class PrecompilationTagHelperTypeResolver : TagHelperTypeResolver





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime.Precompilation/PrecompilationTagHelperTypeResolver.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Runtime.Precompilation.PrecompilationTagHelperTypeResolver

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.Precompilation.PrecompilationTagHelperTypeResolver
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Runtime.Precompilation.PrecompilationTagHelperTypeResolver.PrecompilationTagHelperTypeResolver(Microsoft.CodeAnalysis.Compilation)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Razor.Runtime.Precompilation.PrecompilationTagHelperTypeResolver`\.
    
        
        
        
        :param compilation: The .
        
        :type compilation: Microsoft.CodeAnalysis.Compilation
    
        
        .. code-block:: csharp
    
           public PrecompilationTagHelperTypeResolver(Compilation compilation)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.Precompilation.PrecompilationTagHelperTypeResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.Precompilation.PrecompilationTagHelperTypeResolver.GetTopLevelExportedTypes(System.Reflection.AssemblyName)
    
        
        
        
        :type assemblyName: System.Reflection.AssemblyName
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo}
    
        
        .. code-block:: csharp
    
           protected override IEnumerable<ITypeInfo> GetTopLevelExportedTypes(AssemblyName assemblyName)
    

