

TagHelperContext Class
======================



.. contents:: 
   :local:



Summary
-------

Contains information related to the execution of :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelperContext`








Syntax
------

.. code-block:: csharp

   public class TagHelperContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/TagHelperContext.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext.TagHelperContext(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute>, System.Collections.Generic.IDictionary<System.Object, System.Object>, System.String)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperContext`\.
    
        
        
        
        :param allAttributes: Every attribute associated with the current HTML element.
        
        :type allAttributes: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute}
        
        
        :param items: Collection of items used to communicate with other s.
        
        :type items: System.Collections.Generic.IDictionary{System.Object,System.Object}
        
        
        :param uniqueId: The unique identifier for the source element this
            applies to.
        
        :type uniqueId: System.String
    
        
        .. code-block:: csharp
    
           public TagHelperContext(IEnumerable<IReadOnlyTagHelperAttribute> allAttributes, IDictionary<object, object> items, string uniqueId)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext.AllAttributes
    
        
    
        Every attribute associated with the current HTML element.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList{Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute}
    
        
        .. code-block:: csharp
    
           public ReadOnlyTagHelperAttributeList<IReadOnlyTagHelperAttribute> AllAttributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext.Items
    
        
    
        Gets the collection of items used to communicate with other :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\s.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<object, object> Items { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext.UniqueId
    
        
    
        An identifier unique to the HTML element this context is for.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string UniqueId { get; }
    

