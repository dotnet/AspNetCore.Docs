

JavaScriptResources Class
=========================






Methods for loading JavaScript from assembly embedded resources.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal.JavaScriptResources`








Syntax
------

.. code-block:: csharp

    public class JavaScriptResources








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.JavaScriptResources
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.JavaScriptResources

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.JavaScriptResources
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.JavaScriptResources.GetEmbeddedJavaScript(System.String)
    
        
    
        
        Gets an embedded JavaScript file resource and decodes it for use as a .NET format string.
    
        
    
        
        :type resourceName: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetEmbeddedJavaScript(string resourceName)
    

