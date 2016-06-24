

RangeConditionHeaderValue Class
===============================





Namespace
    :dn:ns:`Microsoft.Net.Http.Headers`
Assemblies
    * Microsoft.Net.Http.Headers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Headers.RangeConditionHeaderValue`








Syntax
------

.. code-block:: csharp

    public class RangeConditionHeaderValue








.. dn:class:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue
    :hidden:

.. dn:class:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue

Constructors
------------

.. dn:class:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue.RangeConditionHeaderValue(Microsoft.Net.Http.Headers.EntityTagHeaderValue)
    
        
    
        
        :type entityTag: Microsoft.Net.Http.Headers.EntityTagHeaderValue
    
        
        .. code-block:: csharp
    
            public RangeConditionHeaderValue(EntityTagHeaderValue entityTag)
    
    .. dn:constructor:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue.RangeConditionHeaderValue(System.DateTimeOffset)
    
        
    
        
        :type lastModified: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            public RangeConditionHeaderValue(DateTimeOffset lastModified)
    
    .. dn:constructor:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue.RangeConditionHeaderValue(System.String)
    
        
    
        
        :type entityTag: System.String
    
        
        .. code-block:: csharp
    
            public RangeConditionHeaderValue(string entityTag)
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue.EntityTag
    
        
        :rtype: Microsoft.Net.Http.Headers.EntityTagHeaderValue
    
        
        .. code-block:: csharp
    
            public EntityTagHeaderValue EntityTag { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue.LastModified
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        .. code-block:: csharp
    
            public DateTimeOffset? LastModified { get; }
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue.Parse(System.String)
    
        
    
        
        :type input: System.String
        :rtype: Microsoft.Net.Http.Headers.RangeConditionHeaderValue
    
        
        .. code-block:: csharp
    
            public static RangeConditionHeaderValue Parse(string input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.Net.Http.Headers.RangeConditionHeaderValue.TryParse(System.String, out Microsoft.Net.Http.Headers.RangeConditionHeaderValue)
    
        
    
        
        :type input: System.String
    
        
        :type parsedValue: Microsoft.Net.Http.Headers.RangeConditionHeaderValue
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParse(string input, out RangeConditionHeaderValue parsedValue)
    

