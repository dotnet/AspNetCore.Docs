

RazorFileInfoCollection Class
=============================



.. contents:: 
   :local:



Summary
-------

Specifies metadata about precompiled views.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfoCollection`








Syntax
------

.. code-block:: csharp

   public abstract class RazorFileInfoCollection





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/Precompilation/RazorFileInfoCollection.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfoCollection

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfoCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfoCollection.LoadAssembly(Microsoft.Extensions.PlatformAbstractions.IAssemblyLoadContext)
    
        
    
        Loads the assembly containing precompiled views.
    
        
        
        
        :param loadContext: The .
        
        :type loadContext: Microsoft.Extensions.PlatformAbstractions.IAssemblyLoadContext
        :rtype: System.Reflection.Assembly
        :return: The <see cref="T:System.Reflection.Assembly" /> containing precompiled views.
    
        
        .. code-block:: csharp
    
           public virtual Assembly LoadAssembly(IAssemblyLoadContext loadContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfoCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfoCollection.AssemblyResourceName
    
        
    
        Gets or sets the name of the resource containing the precompiled binary.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AssemblyResourceName { get; protected set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfoCollection.FileInfos
    
        
    
        Gets the :any:`System.Collections.Generic.IReadOnlyList\`1` of :any:`Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfo`\s.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfo}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<RazorFileInfo> FileInfos { get; protected set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfoCollection.SymbolsResourceName
    
        
    
        Gets or sets the name of the resource that contains the symbols (pdb).
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SymbolsResourceName { get; protected set; }
    

