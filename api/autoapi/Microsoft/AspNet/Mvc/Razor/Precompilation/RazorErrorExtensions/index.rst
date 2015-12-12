

RazorErrorExtensions Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Precompilation.RazorErrorExtensions`








Syntax
------

.. code-block:: csharp

   public class RazorErrorExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/Precompilation/RazorErrorExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorErrorExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorErrorExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorErrorExtensions.ToDiagnostics(Microsoft.AspNet.Razor.RazorError, System.String)
    
        
        
        
        :type error: Microsoft.AspNet.Razor.RazorError
        
        
        :type filePath: System.String
        :rtype: Microsoft.CodeAnalysis.Diagnostic
    
        
        .. code-block:: csharp
    
           public static Diagnostic ToDiagnostics(RazorError error, string filePath)
    

