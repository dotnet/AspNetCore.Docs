

RazorFileInfoCollectionGenerator Class
======================================



.. contents:: 
   :local:



Summary
-------

Utility type to code generate :any:`Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfoCollection` types.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Internal.RazorFileInfoCollectionGenerator`








Syntax
------

.. code-block:: csharp

   public class RazorFileInfoCollectionGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/Internal/RazorFileInfoCollectionGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Internal.RazorFileInfoCollectionGenerator

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Internal.RazorFileInfoCollectionGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Internal.RazorFileInfoCollectionGenerator.GenerateCode(Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfoCollection)
    
        
    
        Generates CSharp code for the specified ``fileInfoCollection``.
    
        
        
        
        :param fileInfoCollection: The .
        
        :type fileInfoCollection: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfoCollection
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GenerateCode(RazorFileInfoCollection fileInfoCollection)
    

