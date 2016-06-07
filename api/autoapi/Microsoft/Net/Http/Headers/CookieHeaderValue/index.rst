

CookieHeaderValue Class
=======================





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
* :dn:cls:`Microsoft.Net.Http.Headers.CookieHeaderValue`








Syntax
------

.. code-block:: csharp

    public class CookieHeaderValue








.. dn:class:: Microsoft.Net.Http.Headers.CookieHeaderValue
    :hidden:

.. dn:class:: Microsoft.Net.Http.Headers.CookieHeaderValue

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.CookieHeaderValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.CookieHeaderValue.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CookieHeaderValue.Value
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Net.Http.Headers.CookieHeaderValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Net.Http.Headers.CookieHeaderValue.CookieHeaderValue(System.String)
    
        
    
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
            public CookieHeaderValue(string name)
    
    .. dn:constructor:: Microsoft.Net.Http.Headers.CookieHeaderValue.CookieHeaderValue(System.String, System.String)
    
        
    
        
        :type name: System.String
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public CookieHeaderValue(string name, string value)
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.CookieHeaderValue
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.CookieHeaderValue.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Net.Http.Headers.CookieHeaderValue.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.Net.Http.Headers.CookieHeaderValue.Parse(System.String)
    
        
    
        
        :type input: System.String
        :rtype: Microsoft.Net.Http.Headers.CookieHeaderValue
    
        
        .. code-block:: csharp
    
            public static CookieHeaderValue Parse(string input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.CookieHeaderValue.ParseList(System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.CookieHeaderValue<Microsoft.Net.Http.Headers.CookieHeaderValue>}
    
        
        .. code-block:: csharp
    
            public static IList<CookieHeaderValue> ParseList(IList<string> inputs)
    
    .. dn:method:: Microsoft.Net.Http.Headers.CookieHeaderValue.ParseStrictList(System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.CookieHeaderValue<Microsoft.Net.Http.Headers.CookieHeaderValue>}
    
        
        .. code-block:: csharp
    
            public static IList<CookieHeaderValue> ParseStrictList(IList<string> inputs)
    
    .. dn:method:: Microsoft.Net.Http.Headers.CookieHeaderValue.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.Net.Http.Headers.CookieHeaderValue.TryParse(System.String, out Microsoft.Net.Http.Headers.CookieHeaderValue)
    
        
    
        
        :type input: System.String
    
        
        :type parsedValue: Microsoft.Net.Http.Headers.CookieHeaderValue
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParse(string input, out CookieHeaderValue parsedValue)
    
    .. dn:method:: Microsoft.Net.Http.Headers.CookieHeaderValue.TryParseList(System.Collections.Generic.IList<System.String>, out System.Collections.Generic.IList<Microsoft.Net.Http.Headers.CookieHeaderValue>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :type parsedValues: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.CookieHeaderValue<Microsoft.Net.Http.Headers.CookieHeaderValue>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParseList(IList<string> inputs, out IList<CookieHeaderValue> parsedValues)
    
    .. dn:method:: Microsoft.Net.Http.Headers.CookieHeaderValue.TryParseStrictList(System.Collections.Generic.IList<System.String>, out System.Collections.Generic.IList<Microsoft.Net.Http.Headers.CookieHeaderValue>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :type parsedValues: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.CookieHeaderValue<Microsoft.Net.Http.Headers.CookieHeaderValue>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParseStrictList(IList<string> inputs, out IList<CookieHeaderValue> parsedValues)
    

