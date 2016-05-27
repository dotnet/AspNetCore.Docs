

ViewHierarchyUtility Class
==========================






Contains methods to locate <code>_ViewStart.cshtml</code> and <code>_ViewImports.cshtml</code>


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor.Host

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.ViewHierarchyUtility`








Syntax
------

.. code-block:: csharp

    public class ViewHierarchyUtility








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.ViewHierarchyUtility
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.ViewHierarchyUtility

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.ViewHierarchyUtility
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.ViewHierarchyUtility.GetViewImportsLocations(System.String)
    
        
    
        
        Gets the locations for <code>_ViewImports</code>s that are applicable to the specified path.
    
        
    
        
        :param applicationRelativePath: The application relative path of the file to locate
            <code>_ViewImports</code>s for.
        
        :type applicationRelativePath: System.String
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :return: A sequence of paths that represent potential <code>_ViewImports</code> locations.
    
        
        .. code-block:: csharp
    
            public static IEnumerable<string> GetViewImportsLocations(string applicationRelativePath)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.ViewHierarchyUtility.GetViewStartLocations(System.String)
    
        
    
        
        Gets the view start locations that are applicable to the specified path.
    
        
    
        
        :param applicationRelativePath: The application relative path of the file to locate
            <code>_ViewStart</code>s for.
        
        :type applicationRelativePath: System.String
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :return: A sequence of paths that represent potential view start locations.
    
        
        .. code-block:: csharp
    
            public static IEnumerable<string> GetViewStartLocations(string applicationRelativePath)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.ViewHierarchyUtility
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Razor.ViewHierarchyUtility.ViewImportsFileName
    
        
    
        
        File name of <code>_ViewImports.cshtml</code> file
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string ViewImportsFileName
    

