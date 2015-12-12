

SetCookieHeaderValue Class
==========================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.Net.Http.Headers/SetCookieHeaderValue.cs>`_





.. dn:class:: Microsoft.Net.Http.Headers.SetCookieHeaderValue

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
    
        
        
        
        :type inputs: System.Collections.Generic.IList{System.String}
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.SetCookieHeaderValue}
    
        
        .. code-block:: csharp
    
           public static IList<SetCookieHeaderValue> ParseList(IList<string> inputs)
    
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
    
        
        
        
        :type inputs: System.Collections.Generic.IList{System.String}
        
        
        :type parsedValues: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.SetCookieHeaderValue}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool TryParseList(IList<string> inputs, out IList<SetCookieHeaderValue> parsedValues)
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.SetCookieHeaderValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.Domain
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Domain { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.Expires
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? Expires { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.HttpOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HttpOnly { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.MaxAge
    
        
        :rtype: System.Nullable{System.TimeSpan}
    
        
        .. code-block:: csharp
    
           public TimeSpan? MaxAge { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Path { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.Secure
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Secure { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.SetCookieHeaderValue.Value
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Value { get; set; }
    

