

StringValues Struct
===================






Represents zero/null, one, or many strings in an efficient way.


Namespace
    :dn:ns:`Microsoft.Extensions.Primitives`
Assemblies
    * Microsoft.Extensions.Primitives

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct StringValues : IList<string>, ICollection<string>, IReadOnlyList<string>, IReadOnlyCollection<string>, IEnumerable<string>, IEnumerable, IEquatable<StringValues>, IEquatable<string>, IEquatable<string[]>








.. dn:structure:: Microsoft.Extensions.Primitives.StringValues
    :hidden:

.. dn:structure:: Microsoft.Extensions.Primitives.StringValues

Properties
----------

.. dn:structure:: Microsoft.Extensions.Primitives.StringValues
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Primitives.StringValues.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Count
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Primitives.StringValues.Item[System.Int32]
    
        
    
        
        :type index: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string this[int index]
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Primitives.StringValues.System.Collections.Generic.ICollection<System.String>.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ICollection<string>.IsReadOnly
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Primitives.StringValues.System.Collections.Generic.IList<System.String>.Item[System.Int32]
    
        
    
        
        :type index: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string IList<string>.this[int index]
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.Extensions.Primitives.StringValues
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Primitives.StringValues.StringValues(System.String)
    
        
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public StringValues(string value)
    
    .. dn:constructor:: Microsoft.Extensions.Primitives.StringValues.StringValues(System.String[])
    
        
    
        
        :type values: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public StringValues(string[] values)
    

Fields
------

.. dn:structure:: Microsoft.Extensions.Primitives.StringValues
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.Primitives.StringValues.Empty
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public static readonly StringValues Empty
    

Methods
-------

.. dn:structure:: Microsoft.Extensions.Primitives.StringValues
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.Concat(Microsoft.Extensions.Primitives.StringValues, Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type values1: Microsoft.Extensions.Primitives.StringValues
    
        
        :type values2: Microsoft.Extensions.Primitives.StringValues
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public static StringValues Concat(StringValues values1, StringValues values2)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.Equals(Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type other: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(StringValues other)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.Equals(Microsoft.Extensions.Primitives.StringValues, Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type left: Microsoft.Extensions.Primitives.StringValues
    
        
        :type right: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool Equals(StringValues left, StringValues right)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.Equals(Microsoft.Extensions.Primitives.StringValues, System.String)
    
        
    
        
        :type left: Microsoft.Extensions.Primitives.StringValues
    
        
        :type right: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool Equals(StringValues left, string right)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.Equals(Microsoft.Extensions.Primitives.StringValues, System.String[])
    
        
    
        
        :type left: Microsoft.Extensions.Primitives.StringValues
    
        
        :type right: System.String<System.String>[]
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool Equals(StringValues left, string[] right)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.Equals(System.String)
    
        
    
        
        :type other: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(string other)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.Equals(System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type left: System.String
    
        
        :type right: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool Equals(string left, StringValues right)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.Equals(System.String[])
    
        
    
        
        :type other: System.String<System.String>[]
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(string[] other)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.Equals(System.String[], Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type left: System.String<System.String>[]
    
        
        :type right: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool Equals(string[] left, StringValues right)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.GetEnumerator()
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues.Enumerator
    
        
        .. code-block:: csharp
    
            public StringValues.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.IsNullOrEmpty(Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type value: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool IsNullOrEmpty(StringValues value)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.System.Collections.Generic.ICollection<System.String>.Add(System.String)
    
        
    
        
        :type item: System.String
    
        
        .. code-block:: csharp
    
            void ICollection<string>.Add(string item)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.System.Collections.Generic.ICollection<System.String>.Clear()
    
        
    
        
        .. code-block:: csharp
    
            void ICollection<string>.Clear()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.System.Collections.Generic.ICollection<System.String>.Contains(System.String)
    
        
    
        
        :type item: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ICollection<string>.Contains(string item)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.System.Collections.Generic.ICollection<System.String>.CopyTo(System.String[], System.Int32)
    
        
    
        
        :type array: System.String<System.String>[]
    
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
            void ICollection<string>.CopyTo(string[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.System.Collections.Generic.ICollection<System.String>.Remove(System.String)
    
        
    
        
        :type item: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ICollection<string>.Remove(string item)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.System.Collections.Generic.IEnumerable<System.String>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            IEnumerator<string> IEnumerable<string>.GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.System.Collections.Generic.IList<System.String>.IndexOf(System.String)
    
        
    
        
        :type item: System.String
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int IList<string>.IndexOf(string item)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.System.Collections.Generic.IList<System.String>.Insert(System.Int32, System.String)
    
        
    
        
        :type index: System.Int32
    
        
        :type item: System.String
    
        
        .. code-block:: csharp
    
            void IList<string>.Insert(int index, string item)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.System.Collections.Generic.IList<System.String>.RemoveAt(System.Int32)
    
        
    
        
        :type index: System.Int32
    
        
        .. code-block:: csharp
    
            void IList<string>.RemoveAt(int index)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.ToArray()
    
        
        :rtype: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public string[] ToArray()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

