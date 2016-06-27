

TagHelperContext Class
======================






Contains information related to the execution of :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext`








Syntax
------

.. code-block:: csharp

    public class TagHelperContext








.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext.TagHelperContext(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList, System.Collections.Generic.IDictionary<System.Object, System.Object>, System.String)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext`\.
    
        
    
        
        :param allAttributes: Every attribute associated with the current HTML element.
        
        :type allAttributes: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList
    
        
        :param items: Collection of items used to communicate with other :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s.
        
        :type items: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        :param uniqueId: The unique identifier for the source element this :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext`
            applies to.
        
        :type uniqueId: System.String
    
        
        .. code-block:: csharp
    
            public TagHelperContext(TagHelperAttributeList allAttributes, IDictionary<object, object> items, string uniqueId)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext.AllAttributes
    
        
    
        
        Every attribute associated with the current HTML element.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList
    
        
        .. code-block:: csharp
    
            public ReadOnlyTagHelperAttributeList AllAttributes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext.Items
    
        
    
        
        Gets the collection of items used to communicate with other :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<object, object> Items { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext.UniqueId
    
        
    
        
        An identifier unique to the HTML element this context is for.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string UniqueId { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext.Reinitialize(System.Collections.Generic.IDictionary<System.Object, System.Object>, System.String)
    
        
    
        
        Clears the :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext` and updates its state with the provided values.
    
        
    
        
        :param items: The :any:`System.Collections.Generic.IDictionary\`2` to use.
        
        :type items: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        :param uniqueId: The unique id to use.
        
        :type uniqueId: System.String
    
        
        .. code-block:: csharp
    
            public void Reinitialize(IDictionary<object, object> items, string uniqueId)
    

