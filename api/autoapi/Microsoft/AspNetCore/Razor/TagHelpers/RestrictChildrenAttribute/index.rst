

RestrictChildrenAttribute Class
===============================






Restricts children of the :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\'s element.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.RestrictChildrenAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class RestrictChildrenAttribute : Attribute, _Attribute








.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.RestrictChildrenAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.RestrictChildrenAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.RestrictChildrenAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.RestrictChildrenAttribute.RestrictChildrenAttribute(System.String, System.String[])
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Razor.TagHelpers.RestrictChildrenAttribute` class.
    
        
    
        
        :param childTag: 
            The tag name of an element allowed as a child.
        
        :type childTag: System.String
    
        
        :param childTags: 
            Additional names of elements allowed as children.
        
        :type childTags: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public RestrictChildrenAttribute(string childTag, params string[] childTags)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.RestrictChildrenAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.RestrictChildrenAttribute.ChildTags
    
        
    
        
        Get the names of elements allowed as children.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> ChildTags { get; }
    

