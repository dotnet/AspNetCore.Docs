

ViewHierarchyUtility Class
==========================



.. contents:: 
   :local:



Summary
-------

Contains methods to locate <c>_ViewStart.cshtml</c> and <c>_ViewImports.cshtml</c>





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.ViewHierarchyUtility`








Syntax
------

.. code-block:: csharp

   public class ViewHierarchyUtility





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor.Host/ViewHierarchyUtility.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.ViewHierarchyUtility

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.ViewHierarchyUtility
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.ViewHierarchyUtility.GetViewImportsLocations(System.String)
    
        
    
        Gets the locations for <c>_ViewImports</c>s that are applicable to the specified path.
    
        
        
        
        :param applicationRelativePath: The application relative path of the file to locate
            _ViewImportss for.
        
        :type applicationRelativePath: System.String
        :rtype: System.Collections.Generic.IEnumerable{System.String}
        :return: A sequence of paths that represent potential <c>_ViewImports</c> locations.
    
        
        .. code-block:: csharp
    
           public static IEnumerable<string> GetViewImportsLocations(string applicationRelativePath)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.ViewHierarchyUtility.GetViewStartLocations(System.String)
    
        
    
        Gets the view start locations that are applicable to the specified path.
    
        
        
        
        :param applicationRelativePath: The application relative path of the file to locate
            _ViewStarts for.
        
        :type applicationRelativePath: System.String
        :rtype: System.Collections.Generic.IEnumerable{System.String}
        :return: A sequence of paths that represent potential view start locations.
    
        
        .. code-block:: csharp
    
           public static IEnumerable<string> GetViewStartLocations(string applicationRelativePath)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.ViewHierarchyUtility
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.Razor.ViewHierarchyUtility.ViewImportsFileName
    
        
    
        File name of <c>_ViewImports.cshtml</c> file
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string ViewImportsFileName
    

