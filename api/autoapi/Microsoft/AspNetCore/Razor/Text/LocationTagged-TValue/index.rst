

LocationTagged<TValue> Class
============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Text`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Text.LocationTagged\<TValue>`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("({Location})\"{Value}\"")]
    public class LocationTagged<TValue> : IFormattable








.. dn:class:: Microsoft.AspNetCore.Razor.Text.LocationTagged`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>.LocationTagged(TValue, Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type value: TValue
    
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public LocationTagged(TValue value, SourceLocation location)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>.LocationTagged(TValue, System.Int32, System.Int32, System.Int32)
    
        
    
        
        :type value: TValue
    
        
        :type offset: System.Int32
    
        
        :type line: System.Int32
    
        
        :type col: System.Int32
    
        
        .. code-block:: csharp
    
            public LocationTagged(TValue value, int offset, int line, int col)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>.ToString(System.String, System.IFormatProvider)
    
        
    
        
        :type format: System.String
    
        
        :type formatProvider: System.IFormatProvider
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ToString(string format, IFormatProvider formatProvider)
    

Operators
---------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>
    :noindex:
    :hidden:

    
    .. dn:operator:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>.Equality(Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>, Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>)
    
        
    
        
        :type left: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{TValue}
    
        
        :type right: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{TValue}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool operator ==(LocationTagged<TValue> left, LocationTagged<TValue> right)
    
    .. dn:operator:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>.Implicit(Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue> to TValue)
    
        
    
        
        :type value: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{TValue}
        :rtype: TValue
    
        
        .. code-block:: csharp
    
            public static implicit operator TValue(LocationTagged<TValue> value)
    
    .. dn:operator:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>.Inequality(Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>, Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>)
    
        
    
        
        :type left: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{TValue}
    
        
        :type right: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{TValue}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool operator !=(LocationTagged<TValue> left, LocationTagged<TValue> right)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>.Location
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public SourceLocation Location { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.LocationTagged<TValue>.Value
    
        
        :rtype: TValue
    
        
        .. code-block:: csharp
    
            public TValue Value { get; }
    

