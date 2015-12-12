

ReadOnlyTagHelperAttributeList<TAttribute> Class
================================================



.. contents:: 
   :local:



Summary
-------

A read-only collection of ``TAttribute`s``.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList\<TAttribute>`








Syntax
------

.. code-block:: csharp

   public class ReadOnlyTagHelperAttributeList<TAttribute> : IReadOnlyList<TAttribute>, IReadOnlyCollection<TAttribute>, IEnumerable<TAttribute>, IEnumerable where TAttribute : IReadOnlyTagHelperAttribute





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/ReadOnlyTagHelperAttributeList.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>.ReadOnlyTagHelperAttributeList()
    
        
    
        Instantiates a new instance of :any:`Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList\`1` with an empty
        collection.
    
        
    
        
        .. code-block:: csharp
    
           protected ReadOnlyTagHelperAttributeList()
    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>.ReadOnlyTagHelperAttributeList(System.Collections.Generic.IEnumerable<TAttribute>)
    
        
    
        Instantiates a new instance of :any:`Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList\`1` with the specified
        ``attributes``.
    
        
        
        
        :param attributes: The collection to wrap.
        
        :type attributes: System.Collections.Generic.IEnumerable{{TAttribute}}
    
        
        .. code-block:: csharp
    
           public ReadOnlyTagHelperAttributeList(IEnumerable<TAttribute> attributes)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>.Contains(TAttribute)
    
        
    
        Determines whether a ``TAttribute`` matching ``item`` exists in the
        collection.
    
        
        
        
        :param item: The  to locate.
        
        :type item: {TAttribute}
        :rtype: System.Boolean
        :return: <c>true</c> if an <typeparamref name="TAttribute" /> matching <paramref name="item" /> exists in the
            collection; otherwise, <c>false</c>.
    
        
        .. code-block:: csharp
    
           public bool Contains(TAttribute item)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>.ContainsName(System.String)
    
        
    
        Determines whether a ``TAttribute`` with the same 
        :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute.Name` exists in the collection.
    
        
        
        
        :param name: The  of the
            to get.
        
        :type name: System.String
        :rtype: System.Boolean
        :return: <c>true</c> if a <typeparamref name="TAttribute" /> with the same
            <see cref="P:Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute.Name" /> exists in the collection; otherwise, <c>false</c>.
    
        
        .. code-block:: csharp
    
           public bool ContainsName(string name)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{{TAttribute}}
    
        
        .. code-block:: csharp
    
           public IEnumerator<TAttribute> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>.IndexOf(TAttribute)
    
        
    
        Searches for a ``TAttribute`` matching ``item`` in the collection and
        returns the zero-based index of the first occurrence.
    
        
        
        
        :param item: The  to locate.
        
        :type item: {TAttribute}
        :rtype: System.Int32
        :return: The zero-based index of the first occurrence of a <typeparamref name="TAttribute" /> matching
            <paramref name="item" /> in the collection, if found; otherwise, â€“1.
    
        
        .. code-block:: csharp
    
           public int IndexOf(TAttribute item)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>.NameEquals(System.String, TAttribute)
    
        
    
        Determines if the specified ``attribute`` has the same name as ``name``.
    
        
        
        
        :param name: The value to compare against s
            .
        
        :type name: System.String
        
        
        :param attribute: The attribute to compare against.
        
        :type attribute: {TAttribute}
        :rtype: System.Boolean
        :return: <c>true</c> if <paramref name="name" /> case-insensitively matches <paramref name="attribute" />s
            <see cref="P:Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute.Name" />.
    
        
        .. code-block:: csharp
    
           protected static bool NameEquals(string name, TAttribute attribute)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>.TryGetAttribute(System.String, out TAttribute)
    
        
    
        Retrieves the first ``TAttribute`` with :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute.Name`
        matching ``name``.
    
        
        
        
        :param name: The  of the
            to get.
        
        :type name: System.String
        
        
        :param attribute: When this method returns, the first  with
            matching , if found; otherwise,
            null.
        
        :type attribute: {TAttribute}
        :rtype: System.Boolean
        :return: <c>true</c> if a <typeparamref name="TAttribute" /> with the same
            <see cref="P:Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute.Name" /> exists in the collection; otherwise, <c>false</c>.
    
        
        .. code-block:: csharp
    
           public bool TryGetAttribute(string name, out TAttribute attribute)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>.TryGetAttributes(System.String, out System.Collections.Generic.IEnumerable<TAttribute>)
    
        
    
        Retrieves ``TAttribute``s in the collection with 
        :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute.Name` matching ``name``.
    
        
        
        
        :param name: The  of the
            s to get.
        
        :type name: System.String
        
        
        :param attributes: When this method returns, the s with
            matching , if at least one is
            found; otherwise, null.
        
        :type attributes: System.Collections.Generic.IEnumerable{{TAttribute}}
        :rtype: System.Boolean
        :return: <c>true</c> if at least one <typeparamref name="TAttribute" /> with the same
            <see cref="P:Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute.Name" /> exists in the collection; otherwise, <c>false</c>.
    
        
        .. code-block:: csharp
    
           public bool TryGetAttributes(string name, out IEnumerable<TAttribute> attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>.Attributes
    
        
    
        The underlying collection of ``TAttribute`s``.
    
        
        :rtype: System.Collections.Generic.List{{TAttribute}}
    
        
        .. code-block:: csharp
    
           protected List<TAttribute> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>.Item[System.Int32]
    
        
        
        
        :type index: System.Int32
        :rtype: {TAttribute}
    
        
        .. code-block:: csharp
    
           public TAttribute this[int index] { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.ReadOnlyTagHelperAttributeList<TAttribute>.Item[System.String]
    
        
    
        Gets the first ``TAttribute`` with :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute.Name`
        matching ``name``.
    
        
        
        
        :param name: The  of the  to get.
        
        :type name: System.String
        :rtype: {TAttribute}
        :return: The first <typeparamref name="TAttribute" /> with <see cref="P:Microsoft.AspNet.Razor.TagHelpers.IReadOnlyTagHelperAttribute.Name" />
            matching <paramref name="name" />.
    
        
        .. code-block:: csharp
    
           public TAttribute this[string name] { get; }
    

