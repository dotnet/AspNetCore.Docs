

SetCookieHeaderValue Class
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
* :dn:cls:`Microsoft.Net.Http.Headers.SetCookieHeaderValue`








Syntax
------

.. code-block:: csharp

    public class SetCookieHeaderValue








.. dn:class:: Microsoft.Net.Http.Headers.SetCookieHeaderValue
    :hidden:

.. dn:class:: Microsoft.Net.Http.Headers.SetCookieHeaderValue

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.SetCookieHeaderValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.Domain
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Domain
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.Expires
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        .. code-block:: csharp
    
            public DateTimeOffset? Expires
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.HttpOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HttpOnly
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.MaxAge
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.TimeSpan<System.TimeSpan>}
    
        
        .. code-block:: csharp
    
            public TimeSpan? MaxAge
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Path
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.Secure
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Secure
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.Value
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Net.Http.Headers.SetCookieHeaderValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.SetCookieHeaderValue(System.String)
    
        
    
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
            public SetCookieHeaderValue(string name)
    
    .. dn:constructor:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.SetCookieHeaderValue(System.String, System.String)
    
        
    
        
        :type name: System.String
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public SetCookieHeaderValue(string name, string value)
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.SetCookieHeaderValue
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.AppendToStringBuilder(System.Text.StringBuilder)
    
        
    
        
        Append string representation of this :any:`Microsoft.Net.Http.Headers.SetCookieHeaderValue` to given
        <em>builder</em>.
    
        
    
        
        :param builder: 
            The :any:`System.Text.StringBuilder` to receive the string representation of this
            :any:`Microsoft.Net.Http.Headers.SetCookieHeaderValue`\.
        
        :type builder: System.Text.StringBuilder
    
        
        .. code-block:: csharp
    
            public void AppendToStringBuilder(StringBuilder builder)
    
    .. dn:method:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.Parse(System.String)
    
        
    
        
        :type input: System.String
        :rtype: Microsoft.Net.Http.Headers.SetCookieHeaderValue
    
        
        .. code-block:: csharp
    
            public static SetCookieHeaderValue Parse(string input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.ParseList(System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.SetCookieHeaderValue<Microsoft.Net.Http.Headers.SetCookieHeaderValue>}
    
        
        .. code-block:: csharp
    
            public static IList<SetCookieHeaderValue> ParseList(IList<string> inputs)
    
    .. dn:method:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.ParseStrictList(System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.SetCookieHeaderValue<Microsoft.Net.Http.Headers.SetCookieHeaderValue>}
    
        
        .. code-block:: csharp
    
            public static IList<SetCookieHeaderValue> ParseStrictList(IList<string> inputs)
    
    .. dn:method:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.TryParse(System.String, out Microsoft.Net.Http.Headers.SetCookieHeaderValue)
    
        
    
        
        :type input: System.String
    
        
        :type parsedValue: Microsoft.Net.Http.Headers.SetCookieHeaderValue
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParse(string input, out SetCookieHeaderValue parsedValue)
    
    .. dn:method:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.TryParseList(System.Collections.Generic.IList<System.String>, out System.Collections.Generic.IList<Microsoft.Net.Http.Headers.SetCookieHeaderValue>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :type parsedValues: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.SetCookieHeaderValue<Microsoft.Net.Http.Headers.SetCookieHeaderValue>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParseList(IList<string> inputs, out IList<SetCookieHeaderValue> parsedValues)
    
    .. dn:method:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.TryParseStrictList(System.Collections.Generic.IList<System.String>, out System.Collections.Generic.IList<Microsoft.Net.Http.Headers.SetCookieHeaderValue>)
    
        
    
        
        :type inputs: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :type parsedValues: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.SetCookieHeaderValue<Microsoft.Net.Http.Headers.SetCookieHeaderValue>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParseStrictList(IList<string> inputs, out IList<SetCookieHeaderValue> parsedValues)
    

