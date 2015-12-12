

RangeItemHeaderValue Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Headers.RangeItemHeaderValue`








Syntax
------

.. code-block:: csharp

   public class RangeItemHeaderValue





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.Net.Http.Headers/RangeItemHeaderValue.cs>`_





.. dn:class:: Microsoft.Net.Http.Headers.RangeItemHeaderValue

Constructors
------------

.. dn:class:: Microsoft.Net.Http.Headers.RangeItemHeaderValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Net.Http.Headers.RangeItemHeaderValue.RangeItemHeaderValue(System.Nullable<System.Int64>, System.Nullable<System.Int64>)
    
        
        
        
        :type from: System.Nullable{System.Int64}
        
        
        :type to: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public RangeItemHeaderValue(long ? from, long ? to)
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.RangeItemHeaderValue
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.RangeItemHeaderValue.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Net.Http.Headers.RangeItemHeaderValue.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.Net.Http.Headers.RangeItemHeaderValue.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.RangeItemHeaderValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.RangeItemHeaderValue.From
    
        
        :rtype: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public long ? From { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.RangeItemHeaderValue.To
    
        
        :rtype: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public long ? To { get; }
    

