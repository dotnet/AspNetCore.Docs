

RangeHeaderValue Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Headers.RangeHeaderValue`








Syntax
------

.. code-block:: csharp

   public class RangeHeaderValue





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.Net.Http.Headers/RangeHeaderValue.cs>`_





.. dn:class:: Microsoft.Net.Http.Headers.RangeHeaderValue

Constructors
------------

.. dn:class:: Microsoft.Net.Http.Headers.RangeHeaderValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Net.Http.Headers.RangeHeaderValue.RangeHeaderValue()
    
        
    
        
        .. code-block:: csharp
    
           public RangeHeaderValue()
    
    .. dn:constructor:: Microsoft.Net.Http.Headers.RangeHeaderValue.RangeHeaderValue(System.Nullable<System.Int64>, System.Nullable<System.Int64>)
    
        
        
        
        :type from: System.Nullable{System.Int64}
        
        
        :type to: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public RangeHeaderValue(long ? from, long ? to)
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.RangeHeaderValue
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.RangeHeaderValue.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Net.Http.Headers.RangeHeaderValue.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.Net.Http.Headers.RangeHeaderValue.Parse(System.String)
    
        
        
        
        :type input: System.String
        :rtype: Microsoft.Net.Http.Headers.RangeHeaderValue
    
        
        .. code-block:: csharp
    
           public static RangeHeaderValue Parse(string input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.RangeHeaderValue.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    
    .. dn:method:: Microsoft.Net.Http.Headers.RangeHeaderValue.TryParse(System.String, out Microsoft.Net.Http.Headers.RangeHeaderValue)
    
        
        
        
        :type input: System.String
        
        
        :type parsedValue: Microsoft.Net.Http.Headers.RangeHeaderValue
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool TryParse(string input, out RangeHeaderValue parsedValue)
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.RangeHeaderValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.RangeHeaderValue.Ranges
    
        
        :rtype: System.Collections.Generic.ICollection{Microsoft.Net.Http.Headers.RangeItemHeaderValue}
    
        
        .. code-block:: csharp
    
           public ICollection<RangeItemHeaderValue> Ranges { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.RangeHeaderValue.Unit
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Unit { get; set; }
    

