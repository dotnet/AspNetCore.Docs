

StringValues Struct
===================






Represents zero/null, one, or many strings in an efficient way.


Namespace
    :dn:ns:`Microsoft.Extensions.Primitives.VSRC1`
Assemblies
    * Microsoft.Extensions.Primitives.VSRC1

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct StringValues : IList<string>, ICollection<string>, IReadOnlyList<string>, IReadOnlyCollection<string>, IEnumerable<string>, IEnumerable, IEquatable<StringValues>, IEquatable<string>, IEquatable<string[]>








.. dn:structure:: Microsoft.Extensions.Primitives.VSRC1.StringValues
    :hidden:

.. dn:structure:: Microsoft.Extensions.Primitives.VSRC1.StringValues

Properties
----------

.. dn:structure:: Microsoft.Extensions.Primitives.VSRC1.StringValues
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Primitives.VSRC1.StringValues.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Count
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Primitives.VSRC1.StringValues.Item[System.Int32]
    
        
    
        
        :type index: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string this[int index]
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Primitives.VSRC1.StringValues.System.Collections.Generic.ICollection<System.String>.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ICollection<string>.IsReadOnly
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Primitives.VSRC1.StringValues.System.Collections.Generic.IList<System.String>.Item[System.Int32]
    
        
    
        
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

.. dn:structure:: Microsoft.Extensions.Primitives.VSRC1.StringValues
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Primitives.VSRC1.StringValues.StringValues(System.String)
    
        
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public StringValues(string value)
    
    .. dn:constructor:: Microsoft.Extensions.Primitives.VSRC1.StringValues.StringValues(System.String[])
    
        
    
        
        :type values: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public StringValues(string[] values)
    

Fields
------

.. dn:structure:: Microsoft.Extensions.Primitives.VSRC1.StringValues
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.Primitives.VSRC1.StringValues.Empty
    
        
        :rtype: Microsoft.Extensions.Primitives.VSRC1.StringValues
    
        
        .. code-block:: csharp
    
            public static readonly StringValues Empty
    

Methods
-------

.. dn:structure:: Microsoft.Extensions.Primitives.VSRC1.StringValues
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.Concat(Microsoft.Extensions.Primitives.VSRC1.StringValues, Microsoft.Extensions.Primitives.VSRC1.StringValues)
    
        
    
        
        :type values1: Microsoft.Extensions.Primitives.VSRC1.StringValues
    
        
        :type values2: Microsoft.Extensions.Primitives.VSRC1.StringValues
        :rtype: Microsoft.Extensions.Primitives.VSRC1.StringValues
    
        
        .. code-block:: csharp
    
            public static StringValues Concat(StringValues values1, StringValues values2)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.Equals(Microsoft.Extensions.Primitives.VSRC1.StringValues)
    
        
    
        
        :type other: Microsoft.Extensions.Primitives.VSRC1.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(StringValues other)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.Equals(Microsoft.Extensions.Primitives.VSRC1.StringValues, Microsoft.Extensions.Primitives.VSRC1.StringValues)
    
        
    
        
        :type left: Microsoft.Extensions.Primitives.VSRC1.StringValues
    
        
        :type right: Microsoft.Extensions.Primitives.VSRC1.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool Equals(StringValues left, StringValues right)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.Equals(Microsoft.Extensions.Primitives.VSRC1.StringValues, System.String)
    
        
    
        
        :type left: Microsoft.Extensions.Primitives.VSRC1.StringValues
    
        
        :type right: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool Equals(StringValues left, string right)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.Equals(Microsoft.Extensions.Primitives.VSRC1.StringValues, System.String[])
    
        
    
        
        :type left: Microsoft.Extensions.Primitives.VSRC1.StringValues
    
        
        :type right: System.String<System.String>[]
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool Equals(StringValues left, string[] right)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.Equals(System.String)
    
        
    
        
        :type other: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(string other)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.Equals(System.String, Microsoft.Extensions.Primitives.VSRC1.StringValues)
    
        
    
        
        :type left: System.String
    
        
        :type right: Microsoft.Extensions.Primitives.VSRC1.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool Equals(string left, StringValues right)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.Equals(System.String[])
    
        
    
        
        :type other: System.String<System.String>[]
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(string[] other)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.Equals(System.String[], Microsoft.Extensions.Primitives.VSRC1.StringValues)
    
        
    
        
        :type left: System.String<System.String>[]
    
        
        :type right: Microsoft.Extensions.Primitives.VSRC1.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool Equals(string[] left, StringValues right)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.GetEnumerator()
    
        
        :rtype: Microsoft.Extensions.Primitives.VSRC1.StringValues.Enumerator
    
        
        .. code-block:: csharp
    
            public StringValues.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.IsNullOrEmpty(Microsoft.Extensions.Primitives.VSRC1.StringValues)
    
        
    
        
        :type value: Microsoft.Extensions.Primitives.VSRC1.StringValues
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool IsNullOrEmpty(StringValues value)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.System.Collections.Generic.ICollection<System.String>.Add(System.String)
    
        
    
        
        :type item: System.String
    
        
        .. code-block:: csharp
    
            void ICollection<string>.Add(string item)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.System.Collections.Generic.ICollection<System.String>.Clear()
    
        
    
        
        .. code-block:: csharp
    
            void ICollection<string>.Clear()
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.System.Collections.Generic.ICollection<System.String>.Contains(System.String)
    
        
    
        
        :type item: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ICollection<string>.Contains(string item)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.System.Collections.Generic.ICollection<System.String>.CopyTo(System.String[], System.Int32)
    
        
    
        
        :type array: System.String<System.String>[]
    
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
            void ICollection<string>.CopyTo(string[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.System.Collections.Generic.ICollection<System.String>.Remove(System.String)
    
        
    
        
        :type item: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ICollection<string>.Remove(string item)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.System.Collections.Generic.IEnumerable<System.String>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            IEnumerator<string> IEnumerable<string>.GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.System.Collections.Generic.IList<System.String>.IndexOf(System.String)
    
        
    
        
        :type item: System.String
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int IList<string>.IndexOf(string item)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.System.Collections.Generic.IList<System.String>.Insert(System.Int32, System.String)
    
        
    
        
        :type index: System.Int32
    
        
        :type item: System.String
    
        
        .. code-block:: csharp
    
            void IList<string>.Insert(int index, string item)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.System.Collections.Generic.IList<System.String>.RemoveAt(System.Int32)
    
        
    
        
        :type index: System.Int32
    
        
        .. code-block:: csharp
    
            void IList<string>.RemoveAt(int index)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.ToArray()
    
        
        :rtype: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public string[] ToArray()
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringValues.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

