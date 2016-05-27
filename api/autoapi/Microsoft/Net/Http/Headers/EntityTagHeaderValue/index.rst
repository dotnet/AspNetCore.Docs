

EntityTagHeaderValue Class
==========================





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
* :dn:cls:`Microsoft.Net.Http.Headers.EntityTagHeaderValue`








Syntax
------

.. code-block:: csharp

    public class EntityTagHeaderValue








.. dn:class:: Microsoft.Net.Http.Headers.EntityTagHeaderValue
    :hidden:

.. dn:class:: Microsoft.Net.Http.Headers.EntityTagHeaderValue

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.EntityTagHeaderValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.EntityTagHeaderValue.Any
    
        
        :rtype: Microsoft.Net.Http.Headers.EntityTagHeaderValue
    
        
        .. code-block:: csharp
    
            public static EntityTagHeaderValue Any
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.EntityTagHeaderValue.IsWeak
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsWeak
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.EntityTagHeaderValue.Tag
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Tag
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Net.Http.Headers.EntityTagHeaderValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Net.Http.Headers.EntityTagHeaderValue.EntityTagHeaderValue(System.String)
    
        
    
        
        :type tag: System.String
    
        
        .. code-block:: csharp
    
            public EntityTagHeaderValue(string tag)
    
    .. dn:constructor:: Microsoft.Net.Http.Headers.EntityTagHeaderValue.EntityTagHeaderValue(System.String, System.Boolean)
    
        
    
        
        :type tag: System.String
    
        
        :type isWeak: System.Boolean
    
        
        .. code-block:: csharp
    
            public EntityTagHeaderValue(string tag, bool isWeak)
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.EntityTagHeaderValue
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.EntityTagHeaderValue.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Net.Http.Headers.EntityTagHeaderValue.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.Net.Http.Headers.EntityTagHeaderValue.Parse(System.String)
    
        
    
        
        :type input: System.String
        :rtype: Microsoft.Net.Http.Headers.EntityTagHeaderValue
    
        
        .. code-block:: csharp
    
            public static EntityTagHeaderValue Parse(string input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.EntityTagHeaderValue.ParseList(System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.EntityTagHeaderValue<Microsoft.Net.Http.Headers.EntityTagHeaderValue>}
    
        
        .. code-block:: csharp
    
            public static IList<EntityTagHeaderValue> ParseList(IList<string> inputs)
    
    .. dn:method:: Microsoft.Net.Http.Headers.EntityTagHeaderValue.ParseStrictList(System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.EntityTagHeaderValue<Microsoft.Net.Http.Headers.EntityTagHeaderValue>}
    
        
        .. code-block:: csharp
    
            public static IList<EntityTagHeaderValue> ParseStrictList(IList<string> inputs)
    
    .. dn:method:: Microsoft.Net.Http.Headers.EntityTagHeaderValue.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.Net.Http.Headers.EntityTagHeaderValue.TryParse(System.String, out Microsoft.Net.Http.Headers.EntityTagHeaderValue)
    
        
    
        
        :type input: System.String
    
        
        :type parsedValue: Microsoft.Net.Http.Headers.EntityTagHeaderValue
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParse(string input, out EntityTagHeaderValue parsedValue)
    
    .. dn:method:: Microsoft.Net.Http.Headers.EntityTagHeaderValue.TryParseList(System.Collections.Generic.IList<System.String>, out System.Collections.Generic.IList<Microsoft.Net.Http.Headers.EntityTagHeaderValue>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :type parsedValues: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.EntityTagHeaderValue<Microsoft.Net.Http.Headers.EntityTagHeaderValue>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParseList(IList<string> inputs, out IList<EntityTagHeaderValue> parsedValues)
    
    .. dn:method:: Microsoft.Net.Http.Headers.EntityTagHeaderValue.TryParseStrictList(System.Collections.Generic.IList<System.String>, out System.Collections.Generic.IList<Microsoft.Net.Http.Headers.EntityTagHeaderValue>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :type parsedValues: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.EntityTagHeaderValue<Microsoft.Net.Http.Headers.EntityTagHeaderValue>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParseStrictList(IList<string> inputs, out IList<EntityTagHeaderValue> parsedValues)
    

