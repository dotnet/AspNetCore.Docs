

JavaScriptResources Class
=========================



.. contents:: 
   :local:



Summary
-------

Methods for loading JavaScript from assembly embedded resources.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.Internal.JavaScriptResources`








Syntax
------

.. code-block:: csharp

   public class JavaScriptResources





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/Internal/JavaScriptResources.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.JavaScriptResources

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.JavaScriptResources
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.Internal.JavaScriptResources.GetEmbeddedJavaScript(System.String)
    
        
    
        Gets an embedded JavaScript file resource and decodes it for use as a .NET format string.
    
        
        
        
        :type resourceName: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetEmbeddedJavaScript(string resourceName)
    

