

JavaScriptStringArrayEncoder Class
==================================



.. contents:: 
   :local:



Summary
-------

Methods for encoding :any:`System.Collections.Generic.IEnumerable\`1` for use as a JavaScript array literal.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.Internal.JavaScriptStringArrayEncoder`








Syntax
------

.. code-block:: csharp

   public class JavaScriptStringArrayEncoder





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/Internal/JavaScriptStringArrayEncoder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.JavaScriptStringArrayEncoder

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.JavaScriptStringArrayEncoder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.Internal.JavaScriptStringArrayEncoder.Encode(Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        Encodes a .NET string array for safe use as a JavaScript array literal, including inline in an HTML file.
    
        
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder
        
        
        :type values: System.Collections.Generic.IEnumerable{System.String}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string Encode(IJavaScriptStringEncoder encoder, IEnumerable<string> values)
    

