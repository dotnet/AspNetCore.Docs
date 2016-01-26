

TagHelperAttributeList Class
============================



.. contents:: 
   :local:



Summary
-------

A collection of :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList{Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute}`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList`








Syntax
------

.. code-block:: csharp

   public class TagHelperAttributeList : ReadOnlyTagHelperAttributeList<TagHelperAttribute>, IReadOnlyList<TagHelperAttribute>, IReadOnlyCollection<TagHelperAttribute>, IList<TagHelperAttribute>, ICollection<TagHelperAttribute>, IEnumerable<TagHelperAttribute>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/TagHelperAttributeList.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList.TagHelperAttributeList()
    
        
    
        Instantiates a new instance of :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList` with an empty collection.
    
        
    
        
        .. code-block:: csharp
    
           public TagHelperAttributeList()
    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList.TagHelperAttributeList(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute>)
    
        
    
        Instantiates a new instance of :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList` with the specified
        ``attributes``.
    
        
        
        
        :param attributes: The collection to wrap.
        
        :type attributes: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute}
    
        
        .. code-block:: csharp
    
           public TagHelperAttributeList(IEnumerable<TagHelperAttribute> attributes)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList.Add(Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute)
    
        
        
        
        :type attribute: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute
    
        
        .. code-block:: csharp
    
           public void Add(TagHelperAttribute attribute)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList.Add(System.String, System.Object)
    
        
    
        Adds a :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute` to the end of the collection with the specified
        ``name`` and ``value``.
    
        
        
        
        :param name: The  of the attribute to add.
        
        :type name: System.String
        
        
        :param value: The  of the attribute to add.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public void Add(string name, object value)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList.Clear()
    
        
    
        
        .. code-block:: csharp
    
           public void Clear()
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList.CopyTo(Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute[], System.Int32)
    
        
        
        
        :type array: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute[]
        
        
        :type index: System.Int32
    
        
        .. code-block:: csharp
    
           public void CopyTo(TagHelperAttribute[] array, int index)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList.Insert(System.Int32, Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute)
    
        
        
        
        :type index: System.Int32
        
        
        :type attribute: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute
    
        
        .. code-block:: csharp
    
           public void Insert(int index, TagHelperAttribute attribute)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList.Remove(Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute)
    
        
        
        
        :type attribute: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Remove(TagHelperAttribute attribute)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList.RemoveAll(System.String)
    
        
    
        Removes all :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute`\s with :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute.Name` matching
        ``name``.
    
        
        
        
        :param name: The  of s to remove.
        
        :type name: System.String
        :rtype: System.Boolean
        :return: <c>true</c> if at least 1 <see cref="T:Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute" /> was removed; otherwise, <c>false</c>.
    
        
        .. code-block:: csharp
    
           public bool RemoveAll(string name)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList.RemoveAt(System.Int32)
    
        
        
        
        :type index: System.Int32
    
        
        .. code-block:: csharp
    
           public void RemoveAt(int index)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList.Item[System.Int32]
    
        
        
        
        :type index: System.Int32
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute
    
        
        .. code-block:: csharp
    
           public TagHelperAttribute this[int index] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList.Item[System.String]
    
        
    
        Gets the first :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute` with :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute.Name` matching
        ``name``. When setting, replaces the first matching 
        :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute` with the specified ``value`` and removes any additional
        matching :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute`\s. If a matching :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute` is not found,
        adds the specified ``value`` to the end of the collection.
    
        
        
        
        :param name: The  of the  to get or set.
        
        :type name: System.String
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute
        :return: The first <see cref="T:Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute" /> with <see cref="P:Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute.Name" /> matching
            <paramref name="name" />.
    
        
        .. code-block:: csharp
    
           public TagHelperAttribute this[string name] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperAttributeList.System.Collections.Generic.ICollection<Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute>.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool ICollection<TagHelperAttribute>.IsReadOnly { get; }
    

