

SymbolsUtility Class
====================



.. contents:: 
   :local:



Summary
-------

Utility type for determining if a platform supports symbol file generation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Internal.SymbolsUtility`








Syntax
------

.. code-block:: csharp

   public class SymbolsUtility





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/Internal/SymbolsUtility.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Internal.SymbolsUtility

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Internal.SymbolsUtility
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Internal.SymbolsUtility.SupportsSymbolsGeneration()
    
        
    
        Determines if the current platform supports symbols (pdb) generation.
    
        
        :rtype: System.Boolean
        :return: <c>true</c> if pdb generation is supported; <c>false</c> otherwise.
    
        
        .. code-block:: csharp
    
           public static bool SupportsSymbolsGeneration()
    

