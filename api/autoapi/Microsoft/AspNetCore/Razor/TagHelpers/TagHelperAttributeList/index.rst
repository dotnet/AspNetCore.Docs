

TagHelperAttributeList Class
============================






A collection of :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute`\s.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList`








Syntax
------

.. code-block:: csharp

    public class TagHelperAttributeList : ReadOnlyTagHelperAttributeList, IList, ICollection, IReadOnlyList<TagHelperAttribute>, IReadOnlyCollection<TagHelperAttribute>, IList<TagHelperAttribute>, ICollection<TagHelperAttribute>, IEnumerable<TagHelperAttribute>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList.TagHelperAttributeList()
    
        
    
        
        Instantiates a new instance of :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList` with an empty collection.
    
        
    
        
        .. code-block:: csharp
    
            public TagHelperAttributeList()
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList.TagHelperAttributeList(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute>)
    
        
    
        
        Instantiates a new instance of :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList` with the specified
        <em>attributes</em>.
    
        
    
        
        :param attributes: The collection to wrap.
        
        :type attributes: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute>}
    
        
        .. code-block:: csharp
    
            public TagHelperAttributeList(IEnumerable<TagHelperAttribute> attributes)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList.TagHelperAttributeList(System.Collections.Generic.List<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute>)
    
        
    
        
        Instantiates a new instance of :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList` with the specified
        <em>attributes</em>.
    
        
    
        
        :param attributes: The collection to wrap.
        
        :type attributes: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute>}
    
        
        .. code-block:: csharp
    
            public TagHelperAttributeList(List<TagHelperAttribute> attributes)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList.Add(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute)
    
        
    
        
        :type attribute: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute
    
        
        .. code-block:: csharp
    
            public void Add(TagHelperAttribute attribute)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList.Add(System.String, System.Object)
    
        
    
        
        Adds a :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` to the end of the collection with the specified
        <em>name</em> and <em>value</em>.
    
        
    
        
        :param name: The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` of the attribute to add.
        
        :type name: System.String
    
        
        :param value: The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Value` of the attribute to add.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public void Add(string name, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList.Clear()
    
        
    
        
        .. code-block:: csharp
    
            public void Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList.Insert(System.Int32, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute)
    
        
    
        
        :type index: System.Int32
    
        
        :type attribute: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute
    
        
        .. code-block:: csharp
    
            public void Insert(int index, TagHelperAttribute attribute)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList.Remove(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute)
    
        
    
        
        :type attribute: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Remove(TagHelperAttribute attribute)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList.RemoveAll(System.String)
    
        
    
        
        Removes all :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute`\s with :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` matching
        <em>name</em>.
    
        
    
        
        :param name: 
            The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` of :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute`\s to remove.
        
        :type name: System.String
        :rtype: System.Boolean
        :return: 
            <code>true</code> if at least 1 :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` was removed; otherwise, <code>false</code>.
    
        
        .. code-block:: csharp
    
            public bool RemoveAll(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList.RemoveAt(System.Int32)
    
        
    
        
        :type index: System.Int32
    
        
        .. code-block:: csharp
    
            public void RemoveAt(int index)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList.SetAttribute(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute)
    
        
    
        
        Replaces the first :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` with :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` matching
        <em>attribute</em>'s :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` and removes any additional matching 
        :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute`\s. If a matching :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` is not found, adds the
        specified <em>attribute</em> to the end of the collection.
    
        
    
        
        :param attribute: 
            The :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` to set.
        
        :type attribute: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute
    
        
        .. code-block:: csharp
    
            public void SetAttribute(TagHelperAttribute attribute)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList.SetAttribute(System.String, System.Object)
    
        
    
        
        Replaces the first :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` with :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` matching
        <em>name</em> and removes any additional matching :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute`\s. If a
        matching :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` is not found, adds a :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` with
        <em>name</em> and <em>value</em> to the end of the collection.
    
        
    
        
        :param name: 
            The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` of the :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute` to set.
        
        :type name: System.String
    
        
        :param value: 
            The :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Value` to set.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public void SetAttribute(string name, object value)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList.Item[System.Int32]
    
        
    
        
        :type index: System.Int32
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute
    
        
        .. code-block:: csharp
    
            public TagHelperAttribute this[int index] { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList.System.Collections.Generic.ICollection<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute>.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ICollection<TagHelperAttribute>.IsReadOnly { get; }
    

