

CodeAnalysisAttributeUtilities Class
====================================



.. contents:: 
   :local:



Summary
-------

Utilities to work with creating :any:`System.Attribute` instances from :any:`Microsoft.CodeAnalysis.AttributeData`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisAttributeUtilities`








Syntax
------

.. code-block:: csharp

   public class CodeAnalysisAttributeUtilities





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime.Precompilation/CodeAnalysisAttributeUtilities.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisAttributeUtilities

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisAttributeUtilities
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisAttributeUtilities.GetCustomAttributes<TAttribute>(Microsoft.CodeAnalysis.ISymbol)
    
        
    
        Gets the sequence of :any:`System.Attribute`\s of type ``TAttribute``
        that are declared on the specified ``symbol``.
    
        
        
        
        :param symbol: The  to find attributes on.
        
        :type symbol: Microsoft.CodeAnalysis.ISymbol
        :rtype: System.Collections.Generic.IEnumerable{{TAttribute}}
    
        
        .. code-block:: csharp
    
           public static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(ISymbol symbol)where TAttribute : Attribute
    

