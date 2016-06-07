

TagHelperConventions Class
==========================






Default convention for determining if a type is a tag helper.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperConventions`








Syntax
------

.. code-block:: csharp

    public class TagHelperConventions








.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperConventions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperConventions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperConventions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperConventions.IsTagHelper(System.Reflection.TypeInfo)
    
        
    
        
        Indicates whether or not the :any:`System.Reflection.TypeInfo` is a tag helper.
    
        
    
        
        :param typeInfo: The :any:`System.Reflection.TypeInfo`\.
        
        :type typeInfo: System.Reflection.TypeInfo
        :rtype: System.Boolean
        :return: true if <em>typeInfo</em> is a tag helper; false otherwise.
    
        
        .. code-block:: csharp
    
            public static bool IsTagHelper(TypeInfo typeInfo)
    

