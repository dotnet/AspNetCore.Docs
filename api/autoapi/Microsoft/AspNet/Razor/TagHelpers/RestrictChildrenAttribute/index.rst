

RestrictChildrenAttribute Class
===============================



.. contents:: 
   :local:



Summary
-------

Restricts children of the :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\'s element.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.RestrictChildrenAttribute`








Syntax
------

.. code-block:: csharp

   public class RestrictChildrenAttribute : Attribute, _Attribute





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/RestrictChildrenAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.RestrictChildrenAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.RestrictChildrenAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.RestrictChildrenAttribute.RestrictChildrenAttribute(System.String, System.String[])
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Razor.TagHelpers.RestrictChildrenAttribute` class.
    
        
        
        
        :param childTag: The tag name of an element allowed as a child.
        
        :type childTag: System.String
        
        
        :param childTags: Additional names of elements allowed as children.
        
        :type childTags: System.String[]
    
        
        .. code-block:: csharp
    
           public RestrictChildrenAttribute(string childTag, params string[] childTags)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.RestrictChildrenAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.RestrictChildrenAttribute.ChildTags
    
        
    
        Get the names of elements allowed as children.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> ChildTags { get; }
    

