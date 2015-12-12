

LocationTagged<TValue> Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Text.LocationTagged\<TValue>`








Syntax
------

.. code-block:: csharp

   public class LocationTagged<TValue> : IFormattable





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Text/LocationTagged.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Text.LocationTagged<TValue>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Text.LocationTagged<TValue>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Text.LocationTagged<TValue>.LocationTagged(TValue, Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type value: {TValue}
        
        
        :type location: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public LocationTagged(TValue value, SourceLocation location)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Text.LocationTagged<TValue>.LocationTagged(TValue, System.Int32, System.Int32, System.Int32)
    
        
        
        
        :type value: {TValue}
        
        
        :type offset: System.Int32
        
        
        :type line: System.Int32
        
        
        :type col: System.Int32
    
        
        .. code-block:: csharp
    
           public LocationTagged(TValue value, int offset, int line, int col)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Text.LocationTagged<TValue>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Text.LocationTagged<TValue>.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.LocationTagged<TValue>.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.LocationTagged<TValue>.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.LocationTagged<TValue>.ToString(System.String, System.IFormatProvider)
    
        
        
        
        :type format: System.String
        
        
        :type formatProvider: System.IFormatProvider
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ToString(string format, IFormatProvider formatProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Text.LocationTagged<TValue>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Text.LocationTagged<TValue>.Location
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public SourceLocation Location { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.LocationTagged<TValue>.Value
    
        
        :rtype: {TValue}
    
        
        .. code-block:: csharp
    
           public TValue Value { get; }
    

