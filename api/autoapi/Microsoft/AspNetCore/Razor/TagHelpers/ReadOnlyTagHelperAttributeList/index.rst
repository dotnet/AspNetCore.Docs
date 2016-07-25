

ReadOnlyTagHelperAttributeList Class
====================================






A read-only collection of :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute`\s.


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
* :dn:cls:`System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute}`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList`








Syntax
------

.. code-block:: csharp

    public abstract class ReadOnlyTagHelperAttributeList : ReadOnlyCollection<TagHelperAttribute>, IList<TagHelperAttribute>, ICollection<TagHelperAttribute>, IList, ICollection, IReadOnlyList<TagHelperAttribute>, IReadOnlyCollection<TagHelperAttribute>, IEnumerable<TagHelperAttribute>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList.ReadOnlyTagHelperAttributeList()
    
        
    
        
        Instantiates a new instance of :any:`Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList` with an empty
        collection.
    
        
    
        
        .. code-block:: csharp
    
            protected ReadOnlyTagHelperAttributeList()
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList.ReadOnlyTagHelperAttributeList(System.Collections.Generic.IList<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute>)
    
        
    
        
        Instantiates a new instance of :any:`Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList` with the specified
        <em>attributes</em>.
    
        
    
        
        :param attributes: The collection to wrap.
        
        :type attributes: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute>}
    
        
        .. code-block:: csharp
    
            public ReadOnlyTagHelperAttributeList(IList<TagHelperAttribute> attributes)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList.ContainsName(System.String)
    
        
    
        
        Determines whether a :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` with :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name`
        matching <em>name</em> exists in the collection.
    
        
    
        
        :param name: The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` of the 
            :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` to get.
        
        :type name: System.String
        :rtype: System.Boolean
        :return: 
            <code>true</code> if a :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` with the same 
            :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` exists in the collection; otherwise, <code>false</code>.
    
        
        .. code-block:: csharp
    
            public bool ContainsName(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList.IndexOfName(System.String)
    
        
    
        
        Searches for a :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` who's :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name`
        case-insensitively matches <em>name</em> and returns the zero-based index of the first
        occurrence.
    
        
    
        
        :param name: The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` to locate in the collection.
        
        :type name: System.String
        :rtype: System.Int32
        :return: The zero-based index of the first matching :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` within the collection,
            if found; otherwise, -1.
    
        
        .. code-block:: csharp
    
            public int IndexOfName(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList.NameEquals(System.String, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute)
    
        
    
        
        Determines if the specified <em>attribute</em> has the same name as <em>name</em>.
    
        
    
        
        :param name: The value to compare against <em>attribute</em>s 
            :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name`\.
        
        :type name: System.String
    
        
        :param attribute: The attribute to compare against.
        
        :type attribute: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute
        :rtype: System.Boolean
        :return: <code>true</code> if <em>name</em> case-insensitively matches <em>attribute</em>s 
            :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name`\.
    
        
        .. code-block:: csharp
    
            protected static bool NameEquals(string name, TagHelperAttribute attribute)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList.TryGetAttribute(System.String, out Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute)
    
        
    
        
        Retrieves the first :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` with :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name`
        matching <em>name</em>.
    
        
    
        
        :param name: The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` of the 
            :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` to get.
        
        :type name: System.String
    
        
        :param attribute: When this method returns, the first :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` with 
            :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` matching <em>name</em>, if found; otherwise,
            <code>null</code>.
        
        :type attribute: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute
        :rtype: System.Boolean
        :return: <code>true</code> if a :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` with the same 
            :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` exists in the collection; otherwise, <code>false</code>.
    
        
        .. code-block:: csharp
    
            public bool TryGetAttribute(string name, out TagHelperAttribute attribute)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList.TryGetAttributes(System.String, out System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute>)
    
        
    
        
        Retrieves :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute`\s in the collection with 
        :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` matching <em>name</em>.
    
        
    
        
        :param name: The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` of the 
            :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute`\s to get.
        
        :type name: System.String
    
        
        :param attributes: When this method returns, the :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute`\s with 
            :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` matching <em>name</em>.
        
        :type attributes: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute>}
        :rtype: System.Boolean
        :return: <code>true</code> if at least one :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` with the same 
            :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` exists in the collection; otherwise, <code>false</code>.
    
        
        .. code-block:: csharp
    
            public bool TryGetAttributes(string name, out IReadOnlyList<TagHelperAttribute> attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList.Item[System.String]
    
        
    
        
        Gets the first :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` with :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name`
        matching <em>name</em>.
    
        
    
        
        :param name: 
            The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` of the :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` to get.
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute
        :return: The first :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` with :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name`
            matching <em>name</em>.
    
        
        .. code-block:: csharp
    
            public TagHelperAttribute this[string name] { get; }
    

